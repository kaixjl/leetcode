/*
 * @lc app=leetcode id=1328 lang=csharp
 *
 * [1328] Break a Palindrome
 */

using System;
using System.Collections.Generic;

// @lc code=start
public partial class Solution {
    public bool isPalindrome(string str)
    {
        if(str.Length == 0) return false;
        if(str.Length == 1) return true;
        int i = 0, j = str.Length - 1;

        while(i < j)
            if(str[i++] != str[j--]) return false;
        
        return true;
    }
    public string replaceChar(string str, int index, char ch)
    {
        return str.Substring(0, index) + ch + str.Substring(index+1, str.Length-index-1);
    }
    public string BreakPalindrome(string palindrome) {
        if(palindrome.Length<=1) return "";

        int i = 0;

        for(i = 0; i < palindrome.Length; i++)
        {
            if(palindrome[i] == 'a') continue;

            for (char c = 'a'; c < palindrome[i]; c++)
            {
                var s = replaceChar(palindrome, i, c);
                if(!isPalindrome(s)) return s;
            }
        }

        for(i = palindrome.Length - 1; i >=0; i--)
        {
            if(palindrome[i] == 'z') continue;

            for (char c = (char)(palindrome[i] + 1); c <= 'z'; c++)
            {
                var s = replaceChar(palindrome, i, c);
                if(!isPalindrome(s)) return s;
            }
        }

        return "";

    }
}
// @lc code=end

