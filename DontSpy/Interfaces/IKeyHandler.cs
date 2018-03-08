using System.Collections.Generic;

namespace DontSpy.Interfaces
{
    public interface IKeyHandler
    {
        int[] ProduceKeys(int n);
        Dictionary<int, int> KeyTable(int[] key);
    }
}
