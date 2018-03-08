using DontSpy.Interfaces;

namespace DontSpy.Presentation.Validation.Rules
{
    internal class EqualsRule<T> : IValidationRule<T>
    {
        private readonly T _comparativeObj;

        public EqualsRule(T comparativeObj)
        {
            _comparativeObj = comparativeObj;
        }

        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            return value != null && value.Equals(_comparativeObj);
        }
    }
}
