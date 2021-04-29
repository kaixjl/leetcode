/*
 * @lc app=leetcode id=84 lang=csharp
 *
 * [84] Largest Rectangle in Histogram
 *
 * https://leetcode.com/problems/largest-rectangle-in-histogram/description/
 *
 * algorithms
 * Hard (36.02%)
 * Likes:    5695
 * Dislikes: 112
 * Total Accepted:    356.4K
 * Total Submissions: 949.5K
 * Testcase Example:  '[2,1,5,6,2,3]'
 *
 * Given an array of integers heights representing the histogram's bar height
 * where the width of each bar is 1, return the area of the largest rectangle
 * in the histogram.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: heights = [2,1,5,6,2,3]
 * Output: 10
 * Explanation: The above is a histogram where width of each bar is 1.
 * The largest rectangle is shown in the red area, which has an area = 10
 * units.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: heights = [2,4]
 * Output: 4
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= heights.length <= 10^5
 * 0 <= heights[i] <= 10^4
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace LP84 {
// @lc code=start
public class Solution {
    public (int[], int[]) LeftRightEdges(int[] heights)
    {
        int[] leftEdges = new int[heights.Length];
        int[] rightEdges = new int[heights.Length];
        Stack<int> stack = new Stack<int>(); // 单调栈
        stack.Push(-1);
        for(int i = 0; i < heights.Length; i++)
        {
            int curr = heights[i];

            while(stack.Count > 1 && curr <= heights[stack.Peek()]) // 保证当前元素高度严格大于栈中元素
                rightEdges[stack.Pop()] = i - 1; // 高度大于等于当前元素的栈中元素的右边界为当前元素 - 1。
                                                 // 虽然这样会使栈中元素高度等于当前元素的右边界错误（本应该右边界 + 1的元素高度应严格小于当前元素，
                                                 // 这样会使用当前元素右侧第一个高度等于当前元素的元素 - 1的元素作为右边界），
                                                 // 但实际上，高度相同元素最右的元素的左右边界是正确的，所以针对本题（P84）的结果是对的。
                                                 // 不想要这种错误的左右边界可以把该句删除，仅剔除大于等于的元素。然后把该函数再反向跑一遍。

            leftEdges[i] = stack.Peek() + 1; // 此时栈中元素高度严格小于当前元素，当前元素左边界为栈顶元素 + 1.
            stack.Push(i);
        }

        while(stack.Count > 1)
            rightEdges[stack.Pop()] = heights.Length - 1;

        return (leftEdges, rightEdges);
    }
    public int LargestRectangleArea(int[] heights) {
        var (leftEdges, rightEdges) = LeftRightEdges(heights);

        int[] areas = new int[heights.Length];
        for(int i = 0; i < areas.Length; i++)
            areas[i] = (rightEdges[i] + 1 - leftEdges[i]) * heights[i];

        int maxArea = int.MinValue;
        foreach(var area in areas)
            maxArea = Math.Max(maxArea, area);

        return maxArea;
    }
}
// @lc code=end
}
