/*
 * @lc app=leetcode id=239 lang=csharp
 *
 * [239] Sliding Window Maximum
 *
 * https://leetcode.com/problems/sliding-window-maximum/description/
 *
 * algorithms
 * Hard (45.11%)
 * Likes:    7032
 * Dislikes: 259
 * Total Accepted:    442.9K
 * Total Submissions: 974.9K
 * Testcase Example:  '[1,3,-1,-3,5,3,6,7]\n3'
 *
 * You are given an array of integers nums, there is a sliding window of size k
 * which is moving from the very left of the array to the very right. You can
 * only see the k numbers in the window. Each time the sliding window moves
 * right by one position.
 * 
 * Return the max sliding window.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
 * Output: [3,3,5,5,6,7]
 * Explanation: 
 * Window position                Max
 * ---------------               -----
 * [1  3  -1] -3  5  3  6  7       3
 * ⁠1 [3  -1  -3] 5  3  6  7       3
 * ⁠1  3 [-1  -3  5] 3  6  7       5
 * ⁠1  3  -1 [-3  5  3] 6  7       5
 * ⁠1  3  -1  -3 [5  3  6] 7       6
 * ⁠1  3  -1  -3  5 [3  6  7]      7
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1], k = 1
 * Output: [1]
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [1,-1], k = 1
 * Output: [1,-1]
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: nums = [9,11], k = 2
 * Output: [11]
 * 
 * 
 * Example 5:
 * 
 * 
 * Input: nums = [4,-2], k = 2
 * Output: [4]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * -10^4 <= nums[i] <= 10^4
 * 1 <= k <= nums.length
 * 
 * 
 */
using System;
using System.Collections.Generic;

namespace LP239 {
// @lc code=start
public class Solution {
    private void PushBackIndexWithLessValule(LinkedList<int> idxList, int[] nums, int idx) {
        int newValue = nums[idx];
        var currentNode = idxList.Last;
        for(; currentNode != null; ) {
            int currentValue = nums[currentNode.Value];
            if(currentValue < newValue) {
                currentNode = currentNode.Previous;
                idxList.RemoveLast();
            }
            else {
                break;
            }
        }
        idxList.AddLast(idx);
    }
    public int[] MaxSlidingWindow(int[] nums, int k) {
        LinkedList<int> idxList = new LinkedList<int>();
        List<int> maxes = new List<int>(nums.Length - k + 1);
        for(int i = 0; i < k; i++) {
            PushBackIndexWithLessValule(idxList, nums, i);
        }
        maxes.Add(nums[idxList.First.Value]);
        for(int i = k; i < nums.Length; i++) {
            PushBackIndexWithLessValule(idxList, nums, i);
            if(idxList.First.Value <= i - k) {
                idxList.RemoveFirst();
            }
            maxes.Add(nums[idxList.First.Value]);
        }

        return maxes.ToArray();
    }
}
// @lc code=end
}
