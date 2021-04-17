using System;
using System.IO;
using System.Text;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Базовый класс для записей ZIP-архива</para>
    /// </summary>
    public abstract class ZipRecord
    {
        /// <summary>
        /// <para>Идентификатор записи (подпись, сигнатура)</para>
        /// </summary>
        public abstract long Id { get; }
        /// <summary>
        /// <para>Смещение начала записи в архиве</para>
        /// </summary>
        protected long StartOffset { get; private set; }
        /// <summary>
        /// <para>Считать строку из буфера</para>
        /// </summary>
        /// <param name="buf">Исходный буфер</param>
        /// <param name="offset">Смещение первого байта строки в буфере</param>
        /// <param name="length">Размер строки в байтах</param>
        /// <param name="encoding">Кодировка строки</param>
        /// <returns>Считанная строка</returns>
        protected static string GetString(byte[] buf, int offset = 0, int length = int.MaxValue, Encoding encoding = null)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = buf ?? throw new ArgumentNullException(nameof(buf));
            if (offset < 0 || offset >= buf.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            if (length < 1)
            {
                return string.Empty;
            }
            if (buf.Length < (offset + length))
            {
                length = buf.Length - offset;
            }
#endif
            #endregion Проверка аргументов
            encoding ??= Encoding.ASCII;
            var tmpStr = new byte[length];
            Array.Copy(buf, offset, tmpStr, 0, length);
            return encoding.GetString(tmpStr);
        }
        /// <summary>
        /// <para>Загрузить запись из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        public virtual void Load(Stream stream)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
#endif
            #endregion Проверка аргументов
            StartOffset = stream.Position;
        }
    }
}
