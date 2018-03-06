using ModernEncryption.Interfaces;
using Xamarin.Forms;

namespace ModernEncryption
{
    internal class DebuggingOptions
    {
        public static void ExecuteCode(string code)
        {
            switch (code)
            {
                case "angryUnicorn":
                    ResetApplication();
                    break;
            }
        }

        private static void ResetApplication()
        {
            new LocalDatabaseOptions(LocalDatabaseOptions.ConnectionMode.DropAndRecreate);
            DependencyService.Get<IStorage>().ClearKeyValueStorage();
            // TODO: Maybe clear generated files, too?
        }
    }
}
