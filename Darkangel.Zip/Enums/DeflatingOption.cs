namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Deflating compression option</para>
    /// </summary>
    public enum DeflatingOption
    {
        /// <summary>
        /// <para>Normal (-en) compression option was used.</para>
        /// </summary>
        Normal = 0,
        /// <summary>
        /// <para>Maximum (-exx/-ex) compression option was used.</para>
        /// </summary>
        Maximum = 2,
        /// <summary>
        /// <para>Fast (-ef) compression option was used.</para>
        /// </summary>
        Fast = 4,
        /// <summary>
        /// <para>Super Fast (-es) compression option was used.</para>
        /// </summary>
        SuperFast = Maximum | Fast,
        /// <summary>
        /// <para>Unknown</para>
        /// </summary>
        Unknown = 100,
    }
}
