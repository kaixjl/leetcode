/*
 * @lc app=leetcode id=65 lang=csharp
 *
 * [65] Valid Number
 *
 * https://leetcode.com/problems/valid-number/description/
 *
 * algorithms
 * Hard (15.58%)
 * Likes:    896
 * Dislikes: 5559
 * Total Accepted:    198.5K
 * Total Submissions: 1.2M
 * Testcase Example:  '"0"'
 *
 * A valid number can be split up into these components (in order):
 * 
 * 
 * A decimal number or an integer.
 * (Optional) An 'e' or 'E', followed by an integer.
 * 
 * 
 * A decimal number can be split up into these components (in order):
 * 
 * 
 * (Optional) A sign character (either '+' or '-').
 * One of the following formats:
 * 
 * At least one digit, followed by a dot '.'.
 * At least one digit, followed by a dot '.', followed by at least one
 * digit.
 * A dot '.', followed by at least one digit.
 * 
 * 
 * 
 * 
 * An integer can be split up into these components (in order):
 * 
 * 
 * (Optional) A sign character (either '+' or '-').
 * At least one digit.
 * 
 * 
 * For example, all the following are valid numbers: ["2", "0089", "-0.1",
 * "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93",
 * "-123.456e789"], while the following are not valid numbers: ["abc", "1a",
 * "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53"].
 * 
 * Given a string s, return true if s is a valid number.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "0"
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "e"
 * Output: false
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "."
 * Output: false
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: s = ".1"
 * Output: true
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 20
 * s consists of only English letters (both uppercase and lowercase), digits
 * (0-9), plus '+', minus '-', or dot '.'.
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

// @lc code=start
public partial class Solution {
    int ParseSign(string s, int p)
    {
        if (p>=s.Length) return 0;

        if(s[p]=='+' || s[p]=='-')
            return 1;
        else
            return 0;
    }

    int ParseDigits(string s, int p)
    {
        if (p>=s.Length) return 0;

        int q = p;
        while(q<s.Length && Char.IsDigit(s[q]))
            q++;

        return q - p;
    }

    int ParseDot(string s, int p)
    {
        if (p>=s.Length) return 0;

        if(s[p]=='.')
            return 1;
        else
            return 0;
    }

    int ParseE(string s, int p)
    {
        if (p>=s.Length) return 0;

        if(s[p]=='E' || s[p]=='e')
            return 1;
        else
            return 0;
    }

    int ParseDecimal(string s, int p)
    {
        int n ;
        bool digits1 = false, digits2 = false;
        int q = p;
        
        if (q>=s.Length) return 0;

        n = ParseSign(s, q);
        q += n;
        
        if (q==s.Length) return 0;

        n = ParseDigits(s, q);
        q += n;
        digits1 = n!=0;

        if (q==s.Length) return 0;

        n = ParseDot(s, q);
        if(n==0)
            return 0;

        q += n;

        if (q==s.Length)
            if(!digits1)
                return 0;
            else
                return q - p;

        n = ParseDigits(s, q);
        q += n;
        digits2 = n!=0;

        if(!digits1 && !digits2)
            return 0;

        return q - p;
    }

    int ParseInteger(string s, int p)
    {
        int n ;
        int q = p;
        n = ParseSign(s, q);
        q += n;

        n = ParseDigits(s, q);
        if(n==0)
            return 0;

        q += n;

        return q - p;
    }

    public bool IsNumber(string s) {
        int p = 0;
        int n;
        n = ParseDecimal(s, p);
        if(n!=0)
        {
            p += n;
        }
        else
        {
            n = ParseInteger(s, p);
            if(n!=0)
            {
                p += n;
            }
            else return false;
        }

        if (p==s.Length)
            return true;

        n = ParseE(s, p);
        if(n==0)
            return false;

        p += n;
        n = ParseInteger(s, p);
        if(n==0)
            return false;
        
        p += n;

        if(p==s.Length)
            return true;
        else
            return false;
    }
}
// @lc code=end

