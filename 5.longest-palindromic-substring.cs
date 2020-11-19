/*
 * @lc app=leetcode id=5 lang=csharp
 *
 * [5] Longest Palindromic Substring
 */
using System;
using System.Collections.Generic;
// @lc code=start
public partial class Solution {
    public string LongestPalindrome(string s) {
        int palindromeLength, palindromeStart, palindromeEnd;
        LongestPalindromeHelper(s, 0, s.Length, 0, out palindromeLength, out palindromeStart, out palindromeEnd);

        return s.Substring(palindromeStart, palindromeEnd - palindromeStart);
    }

    // @ return (isPalindrome, palindromeLength, palindromeStart, palindromeEnd)
    internal bool LongestPalindromeHelper(string s, int substring_start, int substring_end, int current_palindrome_max_len, out int palindromeLength, out int palindromeStart, out int palindromeEnd)
    {
        int substring_length = substring_end - substring_start;

        // base case
        if (substring_length==0 || substring_length==1)
        {
            palindromeLength = substring_length;
            palindromeStart = substring_start;
            palindromeEnd = substring_end;
            return true;
        }

        // normal case
        // normal case: palindrome case
        if (s[substring_start]==s[substring_end-1])
        {
            bool isPalindrome;
            int palindromeLength_m, palindromeStart_m, palindromeEnd_m;
            isPalindrome = LongestPalindromeHelper(s, substring_start+1, substring_end-1, current_palindrome_max_len, out palindromeLength_m, out palindromeStart_m, out palindromeEnd_m);
            
            if(isPalindrome)
            {
                palindromeLength = palindromeLength_m+2;
                palindromeStart = substring_start;
                palindromeEnd = substring_end;
                return true;
            }
        }

        //normal case: not palindrome case
        if(substring_length < current_palindrome_max_len) // 对于substring_length小于current_palindrome_max_len的情况，直接放弃对字串的测试
        {
            palindromeLength = 0;
            palindromeStart = 0;
            palindromeEnd = 0;
            return false;
        }

        int palindromeLength_l, palindromeStart_l, palindromeEnd_l;
        LongestPalindromeHelper(s, substring_start, substring_end-1, current_palindrome_max_len, out palindromeLength_l, out palindromeStart_l, out palindromeEnd_l);

        int palindromeLength_r, palindromeStart_r, palindromeEnd_r;
        LongestPalindromeHelper(s, substring_start+1, substring_end, Math.Max(current_palindrome_max_len, palindromeLength_l), out palindromeLength_r, out palindromeStart_r, out palindromeEnd_r);

        if (palindromeLength_l < palindromeLength_r)
        {
            palindromeLength = palindromeLength_r;
            palindromeStart = palindromeStart_r;
            palindromeEnd = palindromeEnd_r;
            return false;
        }
        else
        {
            palindromeLength = palindromeLength_l;
            palindromeStart = palindromeStart_l;
            palindromeEnd = palindromeEnd_l;
            return false;
        }    }
}
// @lc code=end

