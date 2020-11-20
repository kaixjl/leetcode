/*
 * @lc app=leetcode id=6 lang=csharp
 *
 * [6] ZigZag Conversion
 */
using System;
using System.Text;
// @lc code=start
public partial class Solution {
    public string Convert(string s, int numRows) {
        if (numRows==1) return s;
        StringBuilder sb = new StringBuilder(s.Length);
        int row_side = numRows - 2;
        int len_total = row_side + numRows;
        for (int r = 0; r < numRows; r++)
        {
            for (int i = 0; r + i * len_total < s.Length; i++)
            {
                if (r==0 || r==numRows-1)
                    sb.Append(s[r + i * len_total]);
                else
                {
                    sb.Append(s[r + i * len_total]);
                    if (len_total - r + i * len_total < s.Length)
                        sb.Append(s[len_total - r + i * len_total]);
                }
            }
        }
        return sb.ToString();
    }
}
// @lc code=end

