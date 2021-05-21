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
// ref: https://www.jianshu.com/p/6fd130084a43
using System;
using System.Collections.Generic;

namespace LP307 {
// @lc code=start
public class NumArray {
    int[] st;
    public NumArray(int[] nums) {
        st = new int[nums.Length * 2];
        for(int i = nums.Length; i < st.Length; i++)
            st[i] = nums[i - nums.Length];
        
        for(int i = nums.Length - 1; i > 0; i--)
            st[i] = st[2 * i] + st[2 * i + 1];
    }
    
    public void Update(int index, int val) {
        int oldVal = st[index + st.Length / 2];
        for(int i = index + st.Length / 2; i > 0; i /= 2)
            st[i] = st[i] - oldVal + val;
    }
    
    public int SumRange(int left, int right) {
        int n = st.Length >> 1;
        left += n;
        right += n;
        int acc = 0;
        while(left <= right) {
            if(left % 2 == 1) {
                acc += st[left];
                left++;
            }
            if(right % 2 == 0) {
                acc += st[right];
                right--;
            }
            left /= 2;
            right /= 2;
        }
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
