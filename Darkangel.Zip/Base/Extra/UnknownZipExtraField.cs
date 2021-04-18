namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Объект, для хранения информации о нереализованном типе дополнительных данных</para>
    /// </summary>
    public sealed class UnknownZipExtraField : BytestreamExtraField
    {
        /// <summary>
        /// <para>Конструктор экземляра <see cref="UnknownZipExtraField"/></para>
        /// </summary>
        /// <param name="id">Идентификатор неизвестных данных</param>
        internal UnknownZipExtraField(int id)
        {
            _Id = id;
        }

        private readonly int _Id;
        /// <inheritdoc/>
        public override int Id => _Id;
    }
}
