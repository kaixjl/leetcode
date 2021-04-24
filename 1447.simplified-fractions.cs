/*
 * @lc app=leetcode id=1447 lang=csharp
 *
 * [1447] Simplified Fractions
 *
 * https://leetcode.com/problems/simplified-fractions/description/
 *
 * algorithms
 * Medium (62.19%)
 * Likes:    143
 * Dislikes: 28
 * Total Accepted:    15.1K
 * Total Submissions: 24.2K
 * Testcase Example:  '2\r'
 *
 * Given an integer n, return a list of all simplified fractions between 0 and
 * 1 (exclusive) such that the denominator is less-than-or-equal-to n. The
 * fractions can be in any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 2
 * Output: ["1/2"]
 * Explanation: "1/2" is the only unique fraction with a denominator
 * less-than-or-equal-to 2.
 * 
 * Example 2:
 * 
 * 
 * Input: n = 3
 * Output: ["1/2","1/3","2/3"]
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: n = 4
 * Output: ["1/2","1/3","1/4","2/3","3/4"]
 * Explanation: "2/4" is not a simplified fraction because it can be simplified
 * to "1/2".
 * 
 * Example 4:
 * 
 * 
 * Input: n = 1
 * Output: []
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 100
 * 
 */

 using System;
 using System.Collections.Generic;

namespace LP1447 {
// @lc code=start
public class Solution {
    private int GCD(int a, int b)
    {
        if (a < b)
        {
            int t = a;
            a = b;
            b = t;
        }

        while(b!=0)
        {
            int t = a % b;
            a = b;
            b = t;
        }
        return a;
    }

    public IList<string> SimplifiedFractions(int n) {
        bool[,] memory = new bool[n, n];
        for(int i = 0; i < n; i++)
            for(int j = 0; j < n; j++)
                memory[i,j] = false;

        List<string> frac = new List<string>();

        for(int i = 2; i <= n; i++)
        {
            for(int j = 1; j < i; j++)
            {
                if(memory[i-1,j-1]) continue;

                if(GCD(i,j)==1)
                {
                    frac.Add($"{j}/{i}");
                    for(int k = 1; i * k <= n; k++)
                    {
                        memory[i*k-1, j*k-1] = true;
                    }
                }
            }
        }

        return frac;
    }
}
// @lc code=end
}

