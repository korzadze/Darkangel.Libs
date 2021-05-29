using System.Collections;
using System.Collections.Generic;

namespace Darkangel.CommandLine
{
    /// <summary>
    /// <para>Список аргументов командной строки</para>
    /// </summary>
    public class ArgumentCollection: IEnumerable<Argument>
    {
        private readonly List<Argument> _Items = new();
        /// <inheritdoc/>
        public IEnumerator<Argument> GetEnumerator() =>
            ((IEnumerable<Argument>)_Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() =>
            ((IEnumerable)_Items).GetEnumerator();

        internal void Add(Argument arg) =>
            _Items.Add(arg);
        /// <summary>
        /// <para>Количество аргументов в списке</para>
        /// </summary>
        public int Count => _Items.Count;
        /// <summary>
        /// <para>Получить значение аргумента по индексу</para>
        /// </summary>
        /// <param name="index">Индекс аргумента в списке</param>
        /// <returns></returns>
        public Argument this[int index] => _Items[index];
    }
}
