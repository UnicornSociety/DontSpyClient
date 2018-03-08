using DontSpy.Interfaces;

namespace DontSpy.Presentation.Validation.Rules
{
    internal class IsNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null) return false;
            return !string.IsNullOrWhiteSpace(value as string);
        }
    }
}
