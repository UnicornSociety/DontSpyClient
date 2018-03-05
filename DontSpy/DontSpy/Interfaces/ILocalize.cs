using System.Globalization;

namespace DontSpy.Interfaces
{
    internal interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
