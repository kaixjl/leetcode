/*
 * @lc app=leetcode id=324 lang=csharp
 *
 * [324] Wiggle Sort II
 *
 * https://leetcode.com/problems/wiggle-sort-ii/description/
 *
 * algorithms
 * Medium (30.36%)
 * Likes:    1384
 * Dislikes: 669
 * Total Accepted:    98.6K
 * Total Submissions: 319.4K
 * Testcase Example:  '[1,5,1,1,6,4]'
 *
 * Given an integer array nums, reorder it such that nums[0] < nums[1] >
 * nums[2] < nums[3]....
 * 
 * You may assume the input array always has a valid answer.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,5,1,1,6,4]
 * Output: [1,6,1,5,1,4]
 * Explanation: [1,4,1,5,1,6] is also accepted.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,3,2,2,3,1]
 * Output: [2,3,1,3,1,2]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 5 * 10^4
 * 0 <= nums[i] <= 5000
 * It is guaranteed that there will be an answer for the given input nums.
 * 
 * 
 * 
 * Follow Up: Can you do it in O(n) time and/or in-place with O(1) extra space?
 */
using System;
using System.Collections.Generic;
namespace LP324{
public static class SolutionHelper {
    public static bool QuickSelectValid(int[] nums, int k)
    {
        int p = nums[k];
        for(int i = 0; i < k; i++)
            if(nums[i] > p) return false;
        for(int i = k; i < nums.Length; i++)
            if(nums[i] < p) return false;
        return true;
    }
    public static bool WiggleSortValid(int[] nums)
    {
        for(int i = 0, j = 1; i < nums.Length && j < nums.Length; i+=2, j+=2)
            if(nums[i] >= nums[j]) return false;
        for(int i = 1, j = 2; i < nums.Length && j < nums.Length; i+=2, j+=2)
            if(nums[i] <= nums[j]) return false;
        return true;
    }
}
// @lc code=start
public class Solution {
    public void Swap(ref int a, ref int b)
    { int t = a; a = b; b = t; }
    public void QuickSelect(int[] nums, int left, int right, int k, Func<int, int> index_map = null)
    {
        if(index_map==null) index_map = x => x;
        if(right - left == 1) return;
        if(right - left == 2)
        {
            if(nums[index_map(left)] > nums[index_map(left + 1)])
            { int t = nums[index_map(left)]; nums[index_map(left)] = nums[index_map(left + 1)]; nums[index_map(left + 1)] = t; }
            return;
        }
        
        int p = nums[index_map(left)], l = left, r = right - 1;
        while(l < r)
        {
            for(;l < r && nums[index_map(r)] > p; r--);
            if(l < r) nums[index_map(l++)] = nums[index_map(r)];

            for(;l < r && nums[index_map(l)] <= p; l++);
            if(l < r) nums[index_map(r--)] = nums[index_map(l)];
        }
        nums[index_map(l)] = p; // l == r
        
        if(l > k)
            QuickSelect(nums, left, l, k, index_map);
        else if(l < k)
            QuickSelect(nums, l + 1, right, k, index_map);
        return;
    }

    public void ThreeWayPartition(int[] nums, int v, Func<int, int> index_map = null)
    {
        if(index_map==null) index_map = x => x;
        for(int i = 0, j = 0, k = nums.Length - 1; i <= k;)
        {
            if(nums[index_map(i)] > v)
                Swap(ref nums[index_map(i)], ref nums[index_map(k--)]);
            else if(nums[index_map(i)] < v)
                Swap(ref nums[index_map(i++)], ref nums[index_map(j++)]);
            else
                i++;
        }
    }

    public void WiggleSort(int[] nums) {
        if(nums.Length==1) return;

        int k = nums.Length / 2;
        if(nums.Length % 2 == 1) k++;
        Func<int, int> f = x => (k - 1 - ((x / k) & (nums.Length & 1)) - (x % k)) * 2 + x / k;
        // f = x => (1|(x<<1)) % (nums.Length|1);
        QuickSelect(nums, 0, nums.Length, k, f);
        ThreeWayPartition(nums, nums[f(k)], f);
        
    }
}
// @lc code=end
}
