/*
 * @lc app=leetcode id=1358 lang=csharp
 *
 * [1358] Number of Substrings Containing All Three Characters
 *
 * https://leetcode.com/problems/number-of-substrings-containing-all-three-characters/description/
 *
 * algorithms
 * Medium (59.94%)
 * Likes:    675
 * Dislikes: 15
 * Total Accepted:    21.4K
 * Total Submissions: 35.2K
 * Testcase Example:  '"abcabc"'
 *
 * Given a string s consisting only of characters a, b and c.
 * 
 * Return the number of substrings containing at least one occurrence of all
 * these characters a, b and c.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "abcabc"
 * Output: 10
 * Explanation: The substrings containing at least one occurrence of the
 * characters a, b and c are "abc", "abca", "abcab", "abcabc", "bca", "bcab",
 * "bcabc", "cab", "cabc" and "abc" (again). 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "aaacb"
 * Output: 3
 * Explanation: The substrings containing at least one occurrence of the
 * characters a, b and c are "aaacb", "aacb" and "acb". 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "abc"
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 3 <= s.length <= 5 x 10^4
 * s only consists of a, b or c characters.
 * 
 * 
 */
namespace LP1358 {
// @lc code=start
public class Solution {
    private int Expand(string s, int left, int right, ref int countA, ref int countB, ref int countC)
    {
        while((countA == 0 || countB == 0 || countC == 0) && right < s.Length)
        {
            var ch = s[right++];
            switch(ch)
            {
                case 'a': countA++; break;
                case 'b': countB++; break;
                case 'c': countC++; break;
            }
        }
        return right;
    }
    private int Shrink(string s, int left, int right, ref int countA, ref int countB, ref int countC)
    {
        while(countA > 0 && countB > 0 && countC > 0)
        {
            var ch = s[left++];
            switch(ch)
            {
                case 'a': countA--; break;
                case 'b': countB--; break;
                case 'c': countC--; break;
            }
        }
        return left;
    }
    public int NumberOfSubstrings(string s) {
        int count = 0;

        int left_top = 0, left_bottom = 0;
        int left = 0, right = 0;
        int countA = 0, countB = 0, countC = 0;

        for(;;)
        {
            right = Expand(s, left, right, ref countA, ref countB, ref countC);
            if (countA == 0 || countB == 0 || countC == 0)
                return count;
            left_top = left;
            left = Shrink(s, left, right, ref countA, ref countB, ref countC);
            left_bottom = left;
            count += (left_bottom - left_top) * (s.Length - right + 1);
        }

    }
}
// @lc code=end
}
