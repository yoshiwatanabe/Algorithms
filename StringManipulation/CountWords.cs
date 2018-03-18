namespace StringManipulation
{
    class CountWords
    {
        public static int CountWordsSimpler(string str)
        {
            var wordCount = 0;
            var lastWasWhitespace = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsWhiteSpace(str[i]))
                {
                    lastWasWhitespace = true;
                }
                else
                {
                    if (lastWasWhitespace)
                    {
                        wordCount++;
                    }
                    lastWasWhitespace = false;
                }
            }

            return wordCount;
        }
    }
}
