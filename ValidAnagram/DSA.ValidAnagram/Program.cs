string s = "anagram", t = "nagaram";
Console.WriteLine(IsAnagram(s, t));
s = "rat"; t = "car";
Console.WriteLine(IsAnagram(s, t));
s = "a"; t = "ab";
Console.WriteLine(IsAnagram(s, t));

bool IsAnagram(string s, string t)
{
    return Solution2(s, t);

    bool Solution1(string s, string t)
    {
        int sCount = 0, tCount = 0;
        char[] sChars = s.ToCharArray(), tChars = t.ToCharArray();
        if (sChars.Length < tChars.Length)
        {
            var temp = sChars;
            sChars = tChars;
            tChars = temp;
        }
        Dictionary<char, int> sCharCountTable = new Dictionary<char, int>()
                            , tCharCountTable = new Dictionary<char, int>();
        for (int i = 0; i < sChars.Length; i++)
        {
            char currentChar = sChars[i];
            if (!sCharCountTable.ContainsKey(sChars[i]))
            {
                sCount++;
                for (int j = i + 1; j < sChars.Length; j++)
                {
                    if (currentChar == sChars[j])
                    {
                        sCount++;
                    }
                }
                sCharCountTable.Add(currentChar, sCount);
            }

            if (!tCharCountTable.ContainsKey(currentChar))
            {
                for (int k = 0; k < tChars.Length; k++)
                {
                    if (currentChar == tChars[k])
                    {
                        tCount++;
                    }
                }
                tCharCountTable.Add(currentChar, tCount);
            }

            if (sCharCountTable[currentChar] != tCharCountTable[currentChar])
            {
                return false;
            }
        }

        return true;
    }

    bool Solution2(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var charFrequency = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            charFrequency.TryAdd(s[i], 0);
            charFrequency.TryAdd(t[i], 0);

            charFrequency[s[i]]++;
            charFrequency[t[i]]--;
        }
        return charFrequency.Values.All(frequency => frequency == 0);
    }
}