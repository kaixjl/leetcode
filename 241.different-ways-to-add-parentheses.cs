/*
 * @lc app=leetcode id=241 lang=csharp
 *
 * [241] Different Ways to Add Parentheses
 *
 * https://leetcode.com/problems/different-ways-to-add-parentheses/description/
 *
 * algorithms
 * Medium (58.14%)
 * Likes:    2297
 * Dislikes: 122
 * Total Accepted:    126.2K
 * Total Submissions: 216.9K
 * Testcase Example:  '"2-1-1"'
 *
 * Given a string expression of numbers and operators, return all possible
 * results from computing all the different possible ways to group numbers and
 * operators. You may return the answer in any order.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: expression = "2-1-1"
 * Output: [0,2]
 * Explanation:
 * ((2-1)-1) = 0 
 * (2-(1-1)) = 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: expression = "2*3-4*5"
 * Output: [-34,-14,-10,-10,10]
 * Explanation:
 * (2*(3-(4*5))) = -34 
 * ((2*3)-(4*5)) = -14 
 * ((2*(3-4))*5) = -10 
 * (2*((3-4)*5)) = -10 
 * (((2*3)-4)*5) = 10
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= expression.length <= 20
 * expression consists of digits and the operator '+', '-', and '*'.
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace LP241 {
// @lc code=start
public class Solution {
    public IList<int> DiffWaysToCompute(string expression) {
        List<int> numsList = new List<int>();
        List<Operator> opLists = new List<Operator>();
        int p = 0;
        while(p < expression.Length) {
            int l = ParseInteger(expression, p);
            if(l == 0) break;
            numsList.Add(int.Parse(expression.Substring(p, l)));
            p += l;

            l = ParseOperator(expression, p);
            if(l == 0) break;
            opLists.Add(expression[p] switch {
                '+' => Operator.Plus,
                '-' => Operator.Minus,
                '*' => Operator.Multipilication,
                _ => throw new Exception()
            });
            p += l;
        }
        if(numsList.Count != opLists.Count + 1) throw new Exception();

        IList<int>[,] mem = new IList<int>[numsList.Count + 1, numsList.Count + 1];
        return DiffWaysToComputeHelper(numsList.ToArray(), 0, numsList.Count, opLists.ToArray(), 0, opLists.Count, mem);
        
    }

    IList<int> DiffWaysToComputeHelper(int[] nums, int nums_l, int nums_r, Operator[] ops, int ops_l, int ops_r, IList<int>[,] mem) {
        if(nums_r - nums_l == 0) return null;
        if(mem[nums_l, nums_r] != null) return mem[nums_l, nums_r];
        if(nums_r - nums_l == 1) return mem[nums_l, nums_r] = new List<int>(){ nums[nums_l] };

        List<int> results = new List<int>();
        for(int i = 1; i < nums_r - nums_l; i++) {
            IList<int> r1 = DiffWaysToComputeHelper(nums, nums_l, nums_l + i, ops, ops_l, ops_l + i - 1, mem);
            IList<int> r2 = DiffWaysToComputeHelper(nums, nums_l + i, nums_r, ops, ops_l + i, ops_r, mem);
            Func<int, int, int> op = ops[ops_l+i-1] switch {
                Operator.Plus => (x, y) => x + y,
                Operator.Minus => (x, y) => x - y,
                Operator.Multipilication => (x, y) => x * y,
                _ => throw new Exception()
            };
            var rst = from x in r1
                      from y in r2
                      select op(x, y);
            results.AddRange(rst);
        }
        mem[nums_l, nums_r] = results.ToList();
        return mem[nums_l, nums_r];
    }

    int ParseOperator(string s, int p)
    {
        if (p>=s.Length) return 0;

        if(s[p]=='+' || s[p]=='-' || s[p]=='*')
            return 1;
        else
            return 0;
    }

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
}

enum Operator {
    Plus, Minus, Multipilication
}
// @lc code=end
}
