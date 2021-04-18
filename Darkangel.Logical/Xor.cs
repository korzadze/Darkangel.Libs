namespace Darkangel.Logical
{
    /// <summary>
    /// Логический XOR, применяемый к списку значений
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>2021-04-18</remarks>
    public class Xor<T> : ConditionsList<T>
        where T : IConditionalObject
    {
        /// <inheritdoc/>
        protected override bool ProceedOp(bool val1, bool val2)
        {
            return val1 ^ val2;
        }
    }
}
