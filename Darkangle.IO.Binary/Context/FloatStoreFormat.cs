using System;

namespace Darkangel.IO
{
    /// <summary>
    /// <para>Формат хранения чисел с плавающей точкой</para>
    /// </summary>
    [Serializable]
    public enum FloatStoreFormat
    {
        /// <summary>
        /// <para>IEEE 754 — 1985, 2008</para>
        /// </summary>
        IEEE754,
        /// <summary>
        /// <para>Microsoft Binary Format (MBF)</para>
        /// </summary>
        MSBinary
    }
}
