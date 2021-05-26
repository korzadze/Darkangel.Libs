using Darkangel.IntegerX;
using Darkangel.IO;
using System;
using System.IO;

namespace Darkangel.Compression.Dune92
{
    /// <summary>
    /// <para>Функционал для упаковки/распаковки файлов сохраненной игры Dune (1992)</para>
    /// </summary>
    /// <remarks>
    /// <para>thread unsafe</para>
    /// <para>Формат сохраненной игры предполагает, что первые два байт содержат
    /// временную метку сохранения, дальше идут данные об упаковке (4 байта) и
    /// собственно, упакованные данные. Упаковщик о временной метке ничего не знает.
    /// При упаковке/распаковке вызывающий код должен сам обрабатывать загрузку/сохранение
    /// временной метки.</para>
    /// </remarks>
    public class SavegameCompressor : ICompressor, IDecompressor
    {
        private const int CompressedSizeOffset = 2;
        /// <inheritdoc/>
        public long Compress(Stream inStream, Stream outStream, long count = -1, object compressorSettings = null)
        {
            if(count < 0)
            {
                count = inStream.Length - inStream.Position;
            }
            if(count == 0)
            {
                return 0;
            }
            var buf = inStream.ReadBytes(count);
            var res = Compress(buf, 0, buf.LongLength, compressorSettings);
            return outStream.WriteBytes(res);
        }
        /// <inheritdoc/>
        /// <remarks>decompressorSettings не используется. Настройки берутся из входного потока.</remarks>
        public long Decompress(Stream inStream, Stream outStream, long count = -1, object decompressorSettings = null)
        {
            if (count < 0)
            {
                count = inStream.Length - inStream.Position;
            }
            if (count == 0)
            {
                return 0;
            }
            var buf = inStream.ReadBytes(count);
            var res = Decompress(buf, 0, buf.LongLength, decompressorSettings);
            return outStream.WriteBytes(res);
        }
        /// <inheritdoc/>
        public object InitDefaultCompressSettings() =>
            new SavegameCompressonSettings();
        /// <inheritdoc/>
        /// <remarks>Не используется. Настройки берутся из входного потока.</remarks>
        public object InitDefaultDecompressSettings() =>
            new SavegameCompressonSettings();
        /// <inheritdoc/>
        public byte[] Compress(byte[] data, long start = 0, long count = -1, object compressorSettings = null)
        {
            if(count == 0)
            {
                return Array.Empty<byte>();
            }
            #region Проверка аргументов
#if CHECK_ARGS
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if ((start < 0) || (start >= data.LongLength))
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            if ((start + count) > data.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
#endif
            #endregion Проверка аргументов
            #region Инициализация
            var last = (count < 0) ? (data.LongLength) : (start + count);
            var setting = compressorSettings as SavegameCompressonSettings;
            setting ??= new SavegameCompressonSettings();
            var res = new MemoryStream();
            #endregion Инициализация
            #region Зарезервируем место для заголовка
            res.Store(setting.ControlCode, true);
            res.Store(setting.MaxUnRLEValueCount, true);
            res.Store((UInt16)0, true);
            #endregion Зарезервируем место для заголовка
            #region Упаковка данных
            var rcount = 0;
            var b = data[start];
            for (var i = start + 1; i < last; i++)
            {
                if (b == data[i])
                {
                    rcount++;
                }
                else
                {
                    WriteRLE(res, b, rcount, setting);
                    rcount = 1;
                    b = data[i];
                }
            }
            WriteRLE(res, b, rcount, setting);
            #endregion Упаковка данных
            #region Записываем размер данных
            res.Position = CompressedSizeOffset;
            res.Store((UInt16)res.Length, true);
            #endregion Записываем размер данных
            return res.ToArray();
        }
        /// <summary>
        /// <para>Записать упаковочную последовательность байт в поток</para>
        /// </summary>
        /// <param name="outStream">Целевой поток</param>
        /// <param name="val">Значение</param>
        /// <param name="count">Количество повторов</param>
        /// <param name="settings">Параметры упаковки</param>
        private static void WriteRLE(Stream outStream, byte val, int count, SavegameCompressonSettings settings)
        {
            if (count > 0)
            {
                if (val == settings.ControlCode)
                {
                    WritePackedSequence(outStream, val, count, settings);
                }
                else if (count <= settings.MaxUnRLEValueCount)
                {
                    for (var i = 0; i < count; i++)
                    {
                        outStream.WriteByte(val);
                    }
                }
                else
                {
                    WritePackedSequence(outStream, val, count, settings);
                }
            }
        }
        /// <summary>
        /// <para>Записать кодовую последовательность в поток</para>
        /// </summary>
        /// <param name="outStream">Целевой поток</param>
        /// <param name="val">Значение</param>
        /// <param name="count">Количество повторов</param>
        /// <param name="settings">Параметры упаковки</param>
        private static void WritePackedSequence(Stream outStream, byte val, int count, SavegameCompressonSettings settings)
        {
            if (count > 0)
            {
                while (count > byte.MaxValue)
                {
                    outStream.WriteByte(settings.ControlCode);
                    outStream.WriteByte(byte.MaxValue);
                    outStream.WriteByte(val);
                    count -= byte.MaxValue;
                }
                outStream.WriteByte(settings.ControlCode);
                outStream.WriteByte((byte)count);
                outStream.WriteByte(val);
            }
        }
        /// <inheritdoc/>
        public byte[] Decompress(byte[] data, long start = 0, long count = -1, object decompressorSettings = null)
        {
            if (count == 0)
            {
                return Array.Empty<byte>();
            }
            #region Проверка аргументов
#if CHECK_ARGS
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if ((start < 0) || (start >= data.LongLength))
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            if ((start + count) > data.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
#endif
            #endregion Проверка аргументов
            #region Инициализация
            var last = (count < 0) ? (data.LongLength) : (start + count);
            var pos = start;
            var settings = new SavegameCompressonSettings(data[start], data[start + 1]);
            int size = data.LoadUInt16(start + 2, isLittleEndian: true);
            var res = new MemoryStream();
            #endregion Инициализация
            #region Распаковка
            for (var i = start; i < last; i++)
            {
                if (data[i] == settings.ControlCode)
                {
                    if ((i + 2) >= last)
                    {
                        throw new IncompleteDataException();
                    }
                    var cnt = data[++i];
                    var val = data[++i];
                    for (var j = 0; j < cnt; j++)
                    {
                        res.WriteByte(val);
                    }
                }
                else
                {
                    res.WriteByte(data[i]);
                }
            }
            #endregion Распаковка
            return res.ToArray();
        }
    }
}
