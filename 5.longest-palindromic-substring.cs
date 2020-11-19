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
        //special case
        if (s.Length==0 || s.Length==1) return s;

        // bool[,] is_palindrome = new bool[s.Length, s.Length];
        SortedList<int, int> on_testing_0 = new SortedList<int, int>(s.Length);
        SortedList<int, int> on_testing_1 = new SortedList<int, int>(s.Length-1);
        int i;
        
        // base case
        int bound = s.Length - 1;
        // is_palindrome[0,0] = true;
        for (i = 1; i < bound; i++)
        {
            // is_palindrome[i,i] = true;
            on_testing_0.Add(i, i);
        }
        // is_palindrome[bound, bound] = true;
        
        for (i = 1; i < s.Length; i++)
        {
            if (s[i-1] == s[i])
            {
                // is_palindrome[i-1,i] = true;
                on_testing_1.Add(i, i);
            }
            //else
                // is_palindrome[i-1,i] = false;
        }

        // testing
        int longest_length = 1, palindrome_start = 0;//, palindrome_end = 1;
        if (on_testing_1.Count>0)
        {
            longest_length = 2;
            palindrome_start = on_testing_1.Values[0] - 1;
            // palindrome_end = on_testing_1[0] + 1;
        }

        if (on_testing_1.Count>0 && on_testing_1.Values[0]==1)
            on_testing_1.Remove(1);
        
        if (on_testing_1.Count>0 && on_testing_1.Values[on_testing_1.Count-1]==s.Length-1)
            on_testing_1.Remove(s.Length-1);

        bound = (s.Length + 1) / 2;
        List<int> to_remove = new List<int>();
        int curr_len;
        for (i = 1; i < bound; i++)
        {
            if(on_testing_0.Count==0)
                break;

            to_remove.Clear();
            foreach(var (v, _) in on_testing_0)
            {
                if (v - i < 0 || v + i >= s.Length)
                {
                    to_remove.Add(v);
                }
                else if (s[v+i]==s[v-i])
                {
                    // is_palindrome[v-i, v+i] = true;
                    curr_len = 2 * i + 1;
                    if(curr_len > longest_length)
                    {
                        longest_length = curr_len;
                        palindrome_start = v - i;
                        // palindrome_end = v + i + 1;
                    }
                }
                else
                {
                    // is_palindrome[v-i, v+i] = false;
                    to_remove.Add(v);
                }
            }
            foreach(var v in to_remove)
                on_testing_0.Remove(v);

            if(on_testing_0.Count==0)
                break;
        }

        for (i = 1; i < bound; i++)
        {
            if(on_testing_1.Count==0)
                break;

            to_remove.Clear();
            foreach(var (v, _) in on_testing_1)
            {
                if (v - i - 1 < 0 || v + i >= s.Length)
                {
                    to_remove.Add(v);
                }
                else if (s[v+i]==s[v-i-1])
                {
                    // is_palindrome[v-i-1, v+i] = true;
                    curr_len = 2 * i + 2;
                    if(curr_len > longest_length)
                    {
                        longest_length = curr_len;
                        palindrome_start = v - i - 1;
                        // palindrome_end = v + i + 1;
                    }
                }
                else
                {
                    // is_palindrome[v-i-1, v+i] = false;
                    to_remove.Add(v);
                }
            }
            foreach(var v in to_remove)
                on_testing_1.Remove(v);

            if(on_testing_1.Count==0)
                break;
        }

        return s.Substring(palindrome_start, longest_length);

    }
}
// @lc code=end

