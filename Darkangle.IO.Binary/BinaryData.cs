using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IO
{
    /// <summary>
    /// <para>Обработчик загрузки данных</para>
    /// </summary>
    /// <param name="sender">Объект данных, вызвавший обработчик</param>
    public delegate void LoadDataHandler(BinaryData sender);

    /// <summary>
    /// <para>Базовый объект, инкапсулирующий функционал
    /// загрузки/сохранения двоичных данных</para>
    /// </summary>
    public abstract class BinaryData : IBinaryObject
    {
        #region События
        /// <summary>
        /// <para>Событие, генерируемое после загрузки данных из потока</para>
        /// </summary>
        public event LoadDataHandler OnAfterLoadData;
        /// <summary>
        /// <para>Событие, генерируемое перед загрузкой данных из потока</para>
        /// </summary>
        public event LoadDataHandler OnBeforeLoadData;
        /// <summary>
        /// <para>Событие, генерируемое после сохранения данных в поток</para>
        /// </summary>
        public event LoadDataHandler OnAfterStoreData;
        /// <summary>
        /// <para>Событие, генерируемое перед сохранением данных в поток</para>
        /// </summary>
        public event LoadDataHandler OnBeforeStoreData;
        #endregion События

        private long _Offset = -1;
        /// <summary>
        /// <para>Смещение в потоке, с которого начинаются загруженные данные</para>
        /// </summary>
        public long LoadOffset => _Offset;
        /// <summary>
        /// <para>Размер данных в заданном двоичном контексте</para>
        /// </summary>
        /// <param name="context">Контекст хранения двоичных данных</param>
        /// <returns>Размер данных</returns>
        public abstract long GetSize(IBinaryContext context);
        /// <summary>
        /// <para>Загрузить данные из двоичного потока</para>
        /// </summary>
        /// <param name="context">Контекст хранения двоичных данных</param>
        /// <param name="stream">Входной поток</param>
        /// <returns>Состояние выполнения</returns>
        public abstract Task LoadAsync(IBinaryContext context, Stream stream);
        /// <summary>
        /// <para>Сохранить данные в двоичный поток</para>
        /// </summary>
        /// <param name="context">Контекст хранения двоичных данных</param>
        /// <param name="stream">Выходной поток</param>
        /// <returns>Состояние выполнения</returns>
        public abstract Task StoreAsync(IBinaryContext context, Stream stream);
        /// <summary>
        /// <para>Загрузить данные из двоичного потока</para>
        /// </summary>
        /// <param name="context">Контекст хранения двоичных данных</param>
        /// <param name="stream">Входной поток</param>
        /// <returns>Состояние выполнения</returns>
        public void Load(IBinaryContext context, Stream stream)
        {
            OnBeforeLoadData?.Invoke(this);
            _Offset = stream.Position;
            var t = Task.Run(() => LoadAsync(context, stream));
            t.Wait();
            OnAfterLoadData?.Invoke(this);
        }
        /// <summary>
        /// <para>Сохранить данные в двоичный поток</para>
        /// </summary>
        /// <param name="context">Контекст хранения двоичных данных</param>
        /// <param name="stream">Выходной поток</param>
        /// <returns>Состояние выполнения</returns>
        public void Store(IBinaryContext context, Stream stream)
        {
            OnBeforeLoadData?.Invoke(this);
            var t = Task.Run(() => StoreAsync(context, stream));
            t.Wait();
            OnAfterLoadData?.Invoke(this);
        }
    }
}
