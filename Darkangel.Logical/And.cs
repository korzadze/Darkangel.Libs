namespace Darkangel.Logical
{
    /// <summary>
    /// Логический AND, применяемый к списку значений
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>2021-04-18</remarks>
    public class And<T> : ConditionsList<T>
            where T : IConditionalObject
    {
        /// <inheritdoc/>
        protected override bool ProceedOp(bool val1, bool val2)
        {
            return val1 && val2;
        }
    }
}
