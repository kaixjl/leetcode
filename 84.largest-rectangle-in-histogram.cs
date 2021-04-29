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
    // public int[] Maximum(int[] heights)
    // {
    //     // assert(heights.Length >= 2)
    //     List<int> maximum = new List<int>();
    //     int last = 0, curr, next;
    //     for(int i = 0; i < heights.Length - 1; i++)
    //     {
    //         curr = heights[i];
    //         next = heights[i + 1];
    //         if(last < curr && curr > next)
    //             maximum.Add(i);
    //         last = curr;
    //     }
    //     curr = heights[heights.Length - 1];
    //     next = 0;
    //     if(last < curr && curr > next)
    //         maximum.Add(heights.Length - 1);

    //     return maximum.ToArray();
    // }
    public int[] LeftEdges(int[] heights)
    {
        int[] leftEdges = new int[heights.Length];
        for(int i = 0; i < leftEdges.Length; i++)
            leftEdges[i] = -1;

        void IterBody(int currIdx)
        {
            int lowestHeight = heights[currIdx];
            for(int i = currIdx; i < heights.Length; i++)
            {
                int currentHeight = heights[i];
                if(leftEdges[i]==-1 && currentHeight <= lowestHeight)
                    leftEdges[i] = currIdx;

                lowestHeight = Math.Min(lowestHeight, currentHeight);
            }
        }

        for(int i = 0; i < heights.Length; i++)
            IterBody(i);

        return leftEdges;
    }
    public int[] RightEdges(int[] heights)
    {
        // assert(heights.Length >= 3)
        int[] rightEdges = new int[heights.Length];
        for(int i = 0; i < rightEdges.Length; i++)
            rightEdges[i] = -1;

        void IterBody(int currIdx)
        {
            int lowestHeight = heights[currIdx];
            for(int i = currIdx; i >= 0; i--)
            {
                int currentHeight = heights[i];
                if(rightEdges[i]==-1 && currentHeight <= lowestHeight)
                    rightEdges[i] = currIdx;

                lowestHeight = Math.Min(lowestHeight, currentHeight);
            }
        }

        for(int i = heights.Length - 1; i >= 0; i--)
            IterBody(i);

        return rightEdges;
    }
    public int LargestRectangleArea(int[] heights) {
        var leftEdges = LeftEdges(heights);
        var rightEdges = RightEdges(heights);

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
