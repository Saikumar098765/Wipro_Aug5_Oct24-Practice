using System;

public class KMPAlgorithm
{
   
    private static void ComputeLPSArray(string pattern, int patternLength, int[] lps)
    {
        int length = 0; 
        int i = 1; 
        lps[0] = 0; 

     
        while (i < patternLength)
        {
            if (pattern[i] == pattern[length])
            {
                length++;
                lps[i] = length;
                i++;
            }
            else
            {
                if (length != 0)
                {
                  
                    length = lps[length - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }
    }

    
    public static void KMPSearch(string text, string pattern)
    {
        int textLength = text.Length;
        int patternLength = pattern.Length;

      
        int[] lps = new int[patternLength];
        ComputeLPSArray(pattern, patternLength, lps);

        int i = 0; 
        int j = 0; 

        while (i < textLength)
        {
            if (pattern[j] == text[i])
            {
                i++;
                j++;
            }

            if (j == patternLength)
            {
                Console.WriteLine($"Pattern found at index {i - j}");
                j = lps[j - 1]; 
            }
            else if (i < textLength && pattern[j] != text[i])
            {
                if (j != 0)
                {
                    j = lps[j - 1]; 
                }
                else
                {
                    i++;
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        string text = "ABABDABACDABABCABAB";
        string pattern = "ABABCABAB";

        KMPSearch(text, pattern);
    }
}
