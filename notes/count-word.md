Count the number of words in a given string

Details to consider
- Does the string ends with a certain terminator? In case of C/C++, this would be a null. (Assumed No)
- Can we have a length of the string? (Assumed Yes)
- Would tabs and newlines appear in the string? OK to treat them as "whitspace"? (Assumed Yes)
- Are punctuations (comma, period, etc.) considered as "whitespace" (Assumed Yes)
- Can multiple consecutive whitespace characters appear in the statement? (Assumed Yes)

We know we will have to scan the entire string. We know we will be using index, so it will be probably using a typical `for` statemnet.

```
for i = 0; i < length; i++
 do-something here
```

What do we do in the body? Most likely, we will be making a choice between "the current character is a whitespace" and "the current character is not a whitespace", so lets develop a function.

```
function isWhitespace(c) : boolean
```

The body of the function is not important right now. Just believe that there is such function (and most programming language library contain one).

Next, we have to think about what to do in these two cases:
* When the current character is a whitespace
* When the current character is not a whitespace

Let's think about the case for when it is not a whitespace first. This is the case where we see alphanumeric character, which is a member of a "word". In a sense, we found a word (or a beginning of a word). We remember that the original objective of this task is to count words, so let's do just that.

* When the current character is not a whitepace
    * Increment wordCount variable

Is that it? Not really. This is going to end up couting all "non-whitespace characters" in a string, not counting "words". We have to somehow skip until we see the end of a word. What is the end of the word? It will be either a whitespace or a situation where string just ended.

* When the current character is not a whitepace
    * Increment wordCount variable
    * Skip until we encounter a whitepsace or a situation where string just ended

Hmm, its getting kind of complex. Does this mean we have to have a mini-loop inside of an outer loop? Maybe? Let's proceed, with this a bit of uneasiness.

What we have to do for when the current character is a whitespace is somewhat similar with an obvious characteristics of not affect wordCount variable at all

* When the current character is a whitespace
    * Skip until we encounter a non-whitespacce or a situation where string just ended

If put all of what we go so far together:


```
wordCount = 0
for i = 0; i < str.length; i++
 if isWhitespace(str[i])
  skip-until-next-non-whitespace or a situation where str ended
 else
  wordCount++
  skip-until-next-whitespace or a situation where str ended
```

What we really don't like about this setup is that we are dealing with the "situation where str ended" in three locations: as part of the for-loop expression, the if-block, and the else-block. Kind of ugly, and implementing this looks complicated and challenging.

To eliminate any duplicate logic, let's say that only the outer loop will take care of detecting the "situation where str ended". 

For this, we can introduce a mode to keep track of whether the last character was whitespace or not:

```
wordCount = 0
lastWasWhitespace = true
for i = 0; i < str.length; i++
 if isWhitespace(str[i])
  lastWasWhitespace = true
 else
  if lastWasWhitespace
   wordCount++
  lastWasWhitespace = false
```

Note that only when the last character was whitespace, we increment the wordCount variable. 

Visually, this will only count the following locations where "it is an alpharnumeric character where the last/previous character was whitespace"

```
 v     v  v  v
 This  is a  word
```

Will this work with "I sleep"? Running in my head, it seems to work fine.

How about " I sleep"? Works fine.
How about " I sleep "? Seems to work fine.
How about "  I  sleep  "? Seems ot work fine.

Using the psudocode, here is a C# implementation


```
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
```

This is the test.

```
static void Main(string[] args)
{
    Debug.Assert(CountWords.CountWordsSimpler("I sleep") == 2);
    Debug.Assert(CountWords.CountWordsSimpler("    I sleep") == 2);
    Debug.Assert(CountWords.CountWordsSimpler("I sleep    ") == 2);
    Debug.Assert(CountWords.CountWordsSimpler("I      sleep") == 2);            
}
```