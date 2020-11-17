/*
 * @lc app=leetcode id=4 lang=csharp
 *
 * [4] Median of Two Sorted Arrays
 */
using System;
using System.Collections.Generic;
// @lc code=start
public partial class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var ln = Console.ReadLine();
        int idx1l = ln.IndexOf('[') + 1;
        int idx1r = ln.IndexOf(']', idx1l + 1);
        int idx2l = ln.IndexOf('[', idx1r + 1) + 1;
        int idx2r = ln.IndexOf(']', idx2l + 1);
        string str1 = ln.Substring(idx1l, idx1r-idx1l);
        string str2 = ln.Substring(idx2l, idx2r-idx2l);
        int len1 = str1.Length;
        int len2 = str2.Length;
        int start = 0;
        int next = 0;

        next = str1.IndexOf(',', start);
        while(next<len1)
        {
            
        }

    }
}
// @lc code=end

