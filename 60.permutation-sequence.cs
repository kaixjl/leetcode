/*
 * @lc app=leetcode id=60 lang=csharp
 *
 * [60] Permutation Sequence
 *
 * https://leetcode.com/problems/permutation-sequence/description/
 *
 * algorithms
 * Hard (38.95%)
 * Likes:    2264
 * Dislikes: 366
 * Total Accepted:    226.7K
 * Total Submissions: 569.8K
 * Testcase Example:  '3\n3'
 *
 * The set [1, 2, 3, ..., n] contains a total of n! unique permutations.
 * 
 * By listing and labeling all of the permutations in order, we get the
 * following sequence for n = 3:
 * 
 * 
 * "123"
 * "132"
 * "213"
 * "231"
 * "312"
 * "321"
 * 
 * 
 * Given n and k, return the k^th permutation sequence.
 * 
 * 
 * Example 1:
 * Input: n = 3, k = 3
 * Output: "213"
 * Example 2:
 * Input: n = 4, k = 9
 * Output: "2314"
 * Example 3:
 * Input: n = 3, k = 1
 * Output: "123"
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 9
 * 1 <= k <= n!
 * 
 * 
 */
using System;
using System.Collections.Generic;

namespace LP60 {
// @lc code=start
public class Solution {
    public string GetPermutation(int n, int k) {
        Stack<int> stack = new Stack<int>(n - 1);
        List<int> list = new List<int>(n);
        List<int> permutation = new List<int>(n);
        int acc = 1;
        for(int i = 1; i < n; i++) {
            stack.Push(acc *= i);
            list.Add(i);
        }
        list.Add(n);
        k -= 1;
        while(stack.Count > 0) {
            int b = stack.Pop();
            int idx = k / b;
            permutation.Add(list[idx]);
            list.RemoveAt(idx);
            k %= b;
        }
        permutation.Add(list[0]);
        list.RemoveAt(0);

        return String.Concat(permutation);
    }
}
// @lc code=end
}
