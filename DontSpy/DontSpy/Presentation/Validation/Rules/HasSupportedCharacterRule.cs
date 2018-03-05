using System.Linq;
using DontSpy.BusinessLogic.Crypto;
using DontSpy.Interfaces;

namespace DontSpy.Presentation.Validation.Rules
{
    internal class HasSupportedCharacterRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null) return false;

            var text = value as string;
            return text != null && text.ToCharArray().All(messageCharacter => MathematicalMappingLogic.IntervalTable.ContainsKey(messageCharacter));
        }
    }
}
