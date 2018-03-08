using System;

namespace DontSpy.Utils
{
    internal class IdentifierCreator
    {
        public static string UniqueDigits()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
