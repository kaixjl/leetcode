/*
 * @lc app=leetcode id=17 lang=csharp
 *
 * [17] Letter Combinations of a Phone Number
 *
 * https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
 *
 * algorithms
 * Medium (47.94%)
 * Likes:    6095
 * Dislikes: 528
 * Total Accepted:    842.8K
 * Total Submissions: 1.7M
 * Testcase Example:  '"23"'
 *
 * Given a string containing digits from 2-9 inclusive, return all possible
 * letter combinations that the number could represent. Return the answer in
 * any order.
 * 
 * A mapping of digit to letters (just like on the telephone buttons) is given
 * below. Note that 1 does not map to any letters.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: digits = "23"
 * Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: digits = ""
 * Output: []
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: digits = "2"
 * Output: ["a","b","c"]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 0 <= digits.length <= 4
 * digits[i] is a digit in the range ['2', '9'].
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LP17 {
public class SolutionHelper {
    public static string ListToString<T>(IEnumerable<T> list) {
        StringBuilder sb = new StringBuilder();
        sb.Append("{");
        sb.Append(String.Join(',', list.Select(x => { return $"\"{x.ToString()}\""; })));
        sb.Append("}");
        return sb.ToString();
    }
}
// @lc code=start
public class Solution {
    public IList<string> LetterCombinations(string digits) {
        if (digits.Length == 0) return new List<string>();
        
        string[] dials = {"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
        string[] digitsToDials = new string[digits.Length];
        List<string> letters = new List<string>();
        List<Digit> list = new List<Digit>();
        
        for (int i = 0; i < digits.Length; i++) {
            int j = int.Parse(digits.Substring(i, 1));
            digitsToDials[i] = dials[j - 2];
        }
        int nextDigitIdx = 0;
        list.Add(new Digit(digitsToDials[nextDigitIdx]));
        nextDigitIdx++;
        for(;list.Count > 0;) {
            var curr = list[^1];
            if(!curr.accessed) {
                curr.accessed = true;
                if(nextDigitIdx < digitsToDials.Length) {
                    list.Add(new Digit(digitsToDials[nextDigitIdx]));
                    nextDigitIdx++;
                } else {
                    letters.Add(DigitsToString(list));
                }
            } else {
                if(curr.idx < curr.digit.Length - 1) {
                    curr.idx++;
                    curr.accessed = false;
                }
                else {
                    list.RemoveAt(list.Count - 1);
                    nextDigitIdx--;
                }
            }
        }

        return letters;
    }

    public string DigitsToString(IList<Digit> list) {
        StringBuilder sb = new StringBuilder();
        foreach(var digit in list) {
            sb.Append(digit.digit[digit.idx]);
        }
        return sb.ToString();
    }
}

public class Digit {
    public string digit;
    public int idx;
    public bool accessed = false;
    public Digit(string digit) { this.digit = digit; }
}
// @lc code=end
}
