using System.Collections;
using System.Collections.Generic;
using Darkangel.IntegerX;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Коллекция объектов с дополнительной информацией о записи архива</para>
    /// </summary>
    public class ZipExtraFieldCollection: IEnumerable<ZipExtraField>
    {
        private readonly List<ZipExtraField> _Fields = new();
        /// <inheritdoc/>
        public IEnumerator<ZipExtraField> GetEnumerator() =>
            ((IEnumerable<ZipExtraField>)_Fields).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() =>
            ((IEnumerable)_Fields).GetEnumerator();
        /// <summary>
        /// <para>Количество объектов в коллекции</para>
        /// </summary>
        public int Count => _Fields.Count;
        /// <summary>
        /// <para>Получить объект коллекции по индексу</para>
        /// </summary>
        /// <param name="index">Индекс объекта</param>
        /// <returns></returns>
        public ZipExtraField this[int index] => _Fields[index];
        /// <summary>
        /// <para>Загрузить данные объекта из потока</para>
        /// </summary>
        /// <param name="file">Исходный файл архива</param>
        /// <param name="dataSize">Размер дополнительных данных</param>
        internal void Load(ZipFile file, int dataSize)
        {
            _Fields.Clear();
            var readed = 0;
            var startPos = file.Stream.Position;
            while (readed < dataSize)
            {
                var chunkSize = 0;
                var pos = file.Stream.Position;
                var id = file.Stream.LoadUInt16(); chunkSize += 2;
                var fieldSize = file.Stream.LoadUInt16(); chunkSize += 2;
                ZipExtraField fl = file.CreateExtraDataById(id);
                fl.Load(file.Stream, fieldSize); chunkSize += fieldSize;
                _Fields.Add(fl);
                file.Stream.Position = pos + chunkSize;
                readed += chunkSize;
            }
            file.Stream.Position = startPos + dataSize;
        }
    }
}
