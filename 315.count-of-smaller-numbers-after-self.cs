/*
 * @lc app=leetcode id=315 lang=csharp
 *
 * [315] Count of Smaller Numbers After Self
 *
 * https://leetcode.com/problems/count-of-smaller-numbers-after-self/description/
 *
 * algorithms
 * Hard (42.31%)
 * Likes:    4433
 * Dislikes: 134
 * Total Accepted:    198.5K
 * Total Submissions: 472.2K
 * Testcase Example:  '[5,2,6,1]'
 *
 * You are given an integer array nums and you have to return a new counts
 * array. The counts array has the property where counts[i] is the number of
 * smaller elements to the right of nums[i].
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [5,2,6,1]
 * Output: [2,1,1,0]
 * Explanation:
 * To the right of 5 there are 2 smaller elements (2 and 1).
 * To the right of 2 there is only 1 smaller element (1).
 * To the right of 6 there is 1 smaller element (1).
 * To the right of 1 there is 0 smaller element.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [-1]
 * Output: [0]
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [-1,-1]
 * Output: [0,0]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * -10^4 <= nums[i] <= 10^4
 * 
 * 
 */
using System;
using System.Collections.Generic;

namespace LP315 {
// @lc code=start
public class Solution {
    public IList<int> CountSmaller(int[] nums) {
        BIT bit = new BIT(20001);
        int[] rst = new int[nums.Length];
        bit[nums[^1] + 10000] += 1;
        for(int i = nums.Length - 2; i >= 0; i--) {
            int idx = nums[i] + 10000;
            rst[i] = bit.PrefixSum(idx);
            bit[idx] += 1;
        }
        return rst;
    }
}

class BIT {
    int[] arr;
    public BIT(int[] nums) {
        this.arr = new int[nums.Length + 1];
        for(int i = 1; i <= nums.Length; i++) {
            this.arr[i] += nums[i - 1];
            int j = i + (i & -i);
            if(j <= this.arr.Length) {
                this.arr[j] += this.arr[i];
            }
        }
    }
    public BIT(int length) {
        this.arr = new int[length + 1];
    }

    public int PrefixSum(int length) {
        int sum = 0;
        for(int i = length; i > 0; i -= i & -i) {
            sum += this.arr[i];
        }
        return sum;
    }

    public int RangeSum(int index, int length) {
        return PrefixSum(index + length) - PrefixSum(index);
    }

    public int this[int index] {
        get {
            return GetValue(index);
        }

        set {
            SetValue(index, value);
        }
    }

    public int GetValue(int index) {
        return RangeSum(index, 1);
    }

    public void SetValue(int index, int val) {
        int oldVal = this[index];
        for(int i = index + 1; i < this.arr.Length; i += i & -i) {
            this.arr[i] = this.arr[i] - oldVal + val;
        }
    }
}
// @lc code=end
}
