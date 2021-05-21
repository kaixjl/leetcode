/*
 * @lc app=leetcode id=307 lang=csharp
 *
 * [307] Range Sum Query - Mutable
 *
 * https://leetcode.com/problems/range-sum-query-mutable/description/
 *
 * algorithms
 * Medium (35.93%)
 * Likes:    1836
 * Dislikes: 105
 * Total Accepted:    137.7K
 * Total Submissions: 370.4K
 * Testcase Example:  '["NumArray","sumRange","update","sumRange"]\n[[[1,3,5]],[0,2],[1,2],[0,2]]'
 *
 * Given an integer array nums, handle multiple queries of the following
 * types:
 * 
 * 
 * Update the value of an element in nums.
 * Calculate the sum of the elements of nums between indices left and right
 * inclusive where left <= right.
 * 
 * 
 * Implement the NumArray class:
 * 
 * 
 * NumArray(int[] nums) Initializes the object with the integer array nums.
 * void update(int index, int val) Updates the value of nums[index] to be
 * val.
 * int sumRange(int left, int right) Returns the sum of the elements of nums
 * between indices left and right inclusive (i.e. nums[left] + nums[left + 1] +
 * ... + nums[right]).
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input
 * ["NumArray", "sumRange", "update", "sumRange"]
 * [[[1, 3, 5]], [0, 2], [1, 2], [0, 2]]
 * Output
 * [null, 9, null, 8]
 * 
 * Explanation
 * NumArray numArray = new NumArray([1, 3, 5]);
 * numArray.sumRange(0, 2); // return 1 + 3 + 5 = 9
 * numArray.update(1, 2);   // nums = [1, 2, 5]
 * numArray.sumRange(0, 2); // return 1 + 2 + 5 = 8
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 3 * 10^4
 * -100 <= nums[i] <= 100
 * 0 <= index < nums.length
 * -100 <= val <= 100
 * 0 <= left <= right < nums.length
 * At most 3 * 10^4 calls will be made to update and sumRange.
 * 
 * 
 */
// ref: https://zhuanlan.zhihu.com/p/99167607
// ref: https://blog.csdn.net/Yaokai_AssultMaster/article/details/79492190
using System;
using System.Collections.Generic;

namespace LP307 {
// @lc code=start
public class NumArray {
    int[] bit;
    public NumArray(int[] nums) {
        bit = new int[nums.Length + 1];
        for(int i = 1; i < bit.Length; i++) {
            bit[i] += nums[i - 1];
            int j = i + (i & -i);
            if (j < bit.Length)
                bit[j] += bit[i];
        }
    }
    
    public void Update(int index, int val) {
        int oldVal = SumRange(index, index);
        // i + (i & -i) 为 i 的父节点
        for(int i = index + 1; i < bit.Length; i += i & -i)
            bit[i] = bit[i] - oldVal + val;
    }
    
    public int SumRange(int left, int right) {
        return PrefixSum(right) - PrefixSum(left - 1);
    }

    public int PrefixSum(int right) {
        right++;
        int acc = 0;
        // lowbit(x) := x & ~x+1 = x & -x; 即取二进制形式中最后一个1以及之后的0所构成的数。
        for(; right > 0; right -= right & -right)
            acc += bit[right];
        return acc;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */
// @lc code=end
}
