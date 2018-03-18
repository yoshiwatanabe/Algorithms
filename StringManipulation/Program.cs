using System.Diagnostics;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(CountWords.CountWordsSimpler("I sleep") == 2);
            Debug.Assert(CountWords.CountWordsSimpler("    I sleep") == 2);
            Debug.Assert(CountWords.CountWordsSimpler("I sleep    ") == 2);
            Debug.Assert(CountWords.CountWordsSimpler("I      sleep") == 2);            
        }
    }
}
