using System;
using System.Collections.Generic;

namespace Darkangel.Shapes
{
    using TOrd = Int32;

    /// <summary>
    /// <para>Точка координатной сетки</para>
    /// </summary>
    public abstract class Point<TOrd> : IComparable<Point<TOrd>>, IEquatable<Point<TOrd>>
        where TOrd: struct, IComparable<TOrd>
    {
        /// <summary>
        /// <para>Индекс координаты X</para>
        /// </summary>
        public const int OrdX = 0;
        /// <summary>
        /// <para>Индекс координаты Y</para>
        /// </summary>
        public const int OrdY = 1;
        /// <summary>
        /// <para>Индекс координаты Z</para>
        /// </summary>
        public const int OrdZ = 2;

        private readonly TOrd[] _Values = Array.Empty<TOrd>();
        /// <summary>
        /// <para>Количество измерений координатной сетки</para>
        /// </summary>
        public long Dimensions => _Values?.LongLength ?? 0;
        /// <summary>
        /// <para>Координата X</para>
        /// </summary>
        /// <remarks>
        /// <para>Упрощение для базовой 3-хмерной сетки</para>
        /// </remarks>
        public TOrd X => (Dimensions > OrdX) ? (_Values[OrdX]) : (default);
        /// <summary>
        /// <para>Координата Y</para>
        /// </summary>
        /// <remarks>
        /// <para>Упрощение для базовой 3-хмерной сетки</para>
        /// </remarks>
        public TOrd Y => (Dimensions > OrdY) ? (_Values[OrdY]) : (default);
        /// <summary>
        /// <para>Координата Z</para>
        /// </summary>
        /// <remarks>
        /// <para>Упрощение для базовой 3-хмерной сетки</para>
        /// </remarks>
        public TOrd Z => (Dimensions > OrdZ) ? (_Values[OrdZ]) : (default);
        /// <summary>
        /// <para>Получить значение ординаты для указанного измерения</para>
        /// </summary>
        /// <param name="dim">Измерение (0 =&gt; ордината X, 1 =&gt; Y и т.д.)</param>
        /// <returns>Значение ординаты</returns>
        public TOrd this[long dim]
        {
            get
            {
                if (dim < 0) throw new ArgumentOutOfRangeException(nameof(dim));
                if (dim < Dimensions)
                {
                    return _Values[dim];
                }
                return default;
            }
        }
        /// <inheritdoc/>
        public bool Equals(Point<TOrd> other)
        {
            if (other is null) return false;
            return CompareTo(other) == 0;
        }
        /// <inheritdoc/>
        public int CompareTo(Point<TOrd> other)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Point<TOrd> p)
                return CompareTo(p) == 0;
            else
                return false; ;
        }
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var res = 0;
            foreach(var ord in _Values)
            {
                res *= 33;
                res ^= ord.GetHashCode();
            }
            return res;
        }
    }
}
