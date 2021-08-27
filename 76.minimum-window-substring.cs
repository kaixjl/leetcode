/*
 * @lc app=leetcode id=76 lang=csharp
 *
 * [76] Minimum Window Substring
 *
 * https://leetcode.com/problems/minimum-window-substring/description/
 *
 * algorithms
 * Hard (36.64%)
 * Likes:    7849
 * Dislikes: 488
 * Total Accepted:    603.5K
 * Total Submissions: 1.6M
 * Testcase Example:  '"ADOBECODEBANC"\n"ABC"'
 *
 * Given two strings s and t of lengths m and n respectively, return the
 * minimum window substring of s such that every character in t (including
 * duplicates) is included in the window. If there is no such substring, return
 * the empty string "".
 * 
 * The testcases will be generated such that the answer is unique.
 * 
 * A substring is a contiguous sequence of characters within the string.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "ADOBECODEBANC", t = "ABC"
 * Output: "BANC"
 * Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C'
 * from string t.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "a", t = "a"
 * Output: "a"
 * Explanation: The entire string s is the minimum window.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "a", t = "aa"
 * Output: ""
 * Explanation: Both 'a's from t must be included in the window.
 * Since the largest window of s only has one 'a', return empty string.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == s.length
 * n == t.length
 * 1 <= m, n <= 10^5
 * s and t consist of uppercase and lowercase English letters.
 * 
 * 
 * 
 * Follow up: Could you find an algorithm that runs in O(m + n) time?
 */
using System;
using System.Collections.Generic;
namespace LP76 {
// @lc code=start
public class Solution {
    public string MinWindow(string s, string t) {
        Dictionary<char, int> letters_t = new Dictionary<char, int>();
        Dictionary<char, int> letters_s = new Dictionary<char, int>();
        foreach(var ch in t) {
            letters_t[ch] = 0;
            letters_s[ch] = 0;
        }
        foreach(var ch in t) {
            letters_t[ch] ++;
        }
        List<Substring> ss = new List<Substring>();

        bool IsSatisfied() {
            foreach(var ch in letters_t.Keys) {
                if (letters_s[ch] < letters_t[ch]) return false;
            }
            return true;
        }

        int l = 0, r = 0;
        while(r < s.Length) {
            while(r < s.Length) {
                char ch = s[r];
                r++;
                if(letters_t.ContainsKey(ch)) {
                    letters_s[ch] ++;
                    if(IsSatisfied()) {
                        break;
                    }
                }
            }
            if(!IsSatisfied()) {
                break;
            }
            while(l < r) {
                char ch = s[l];
                l++;
                if(letters_t.ContainsKey(ch)) {
                    letters_s[ch] --;
                    if(!IsSatisfied()) {
                        ss.Add(new Substring(s, l-1, r));
                        break;
                    }
                }
            }
        }

        int idx_min = 0, len_min = s.Length + 1;
        for(int i = 0; i < ss.Count; i++) {
            if(ss[i].Length < len_min) {
                len_min = ss[i].Length;
                idx_min = i;
            }
        }

        if(ss.Count==0) return "";
        else return ss[idx_min].SubString;
    }
}

public struct Substring {
    int l, r;
    string s;
    public Substring(string s, int l, int r) {
        this.s = s;
        this.l = l;
        this.r = r;
    }
    public int Length => r - l;
    public string SubString => s.Substring(l, r-l);

}
// @lc code=end
}
