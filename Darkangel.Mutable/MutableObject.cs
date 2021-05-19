using System.Collections.Generic;
using System.ComponentModel;

namespace Darkangel.Mutable
{
    /// <summary>
    /// <para>Объект с изменяемыми данными</para>
    /// </summary>
    public abstract class MutableObject
    {
        private bool _IsDirty = false;
        /// <summary>
        /// <para>Данные были изменены - требуется сохранение</para>
        /// </summary>
        public bool IsDirty => _IsDirty;
        /// <summary>
        /// <para>Изменить значение поля</para>
        /// </summary>
        /// <typeparam name="T">Тип поля</typeparam>
        /// <param name="field">Ссылка на поле</param>
        /// <param name="value">Новое значение поля</param>
        /// <param name="fieldName">Имя поля</param>
        protected void SetField<T>(ref T field, T value, string fieldName)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                _IsDirty = true;
                OnPropertyChanged(fieldName);
            }
        }
        /// <summary>
        /// <para>Принудительно установить флаг "данные изменены"</para>
        /// </summary>
        protected void SetDirty()
        {
            _IsDirty = true;
        }
        /// <summary>
        /// <para>Событие, вызываемое, когда какое-то свойство было изменено</para>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
