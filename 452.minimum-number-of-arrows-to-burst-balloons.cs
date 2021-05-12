/*
 * @lc app=leetcode id=452 lang=csharp
 *
 * [452] Minimum Number of Arrows to Burst Balloons
 *
 * https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/description/
 *
 * algorithms
 * Medium (49.70%)
 * Likes:    1735
 * Dislikes: 63
 * Total Accepted:    113.7K
 * Total Submissions: 227.9K
 * Testcase Example:  '[[10,16],[2,8],[1,6],[7,12]]'
 *
 * There are some spherical balloons spread in two-dimensional space. For each
 * balloon, provided input is the start and end coordinates of the horizontal
 * diameter. Since it's horizontal, y-coordinates don't matter, and hence the
 * x-coordinates of start and end of the diameter suffice. The start is always
 * smaller than the end.
 * 
 * An arrow can be shot up exactly vertically from different points along the
 * x-axis. A balloon with xstart and xend bursts by an arrow shot at x if
 * xstart ≤ x ≤ xend. There is no limit to the number of arrows that can be
 * shot. An arrow once shot keeps traveling up infinitely.
 * 
 * Given an array points where points[i] = [xstart, xend], return the minimum
 * number of arrows that must be shot to burst all balloons.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: points = [[10,16],[2,8],[1,6],[7,12]]
 * Output: 2
 * Explanation: One way is to shoot one arrow for example at x = 6 (bursting
 * the balloons [2,8] and [1,6]) and another arrow at x = 11 (bursting the
 * other two balloons).
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: points = [[1,2],[3,4],[5,6],[7,8]]
 * Output: 4
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: points = [[1,2],[2,3],[3,4],[4,5]]
 * Output: 2
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= points.length <= 10^4
 * points[i].length == 2
 * -2^31 <= xstart < xend <= 2^31 - 1
 * 
 * 
 */
using System;
using System.Collections.Generic;

namespace LP452 {
// @lc code=start
public class Solution {
    public int FindMinArrowShots(int[][] points) {
        List<int[]> sortedByEnds = new List<int[]>();
        foreach(var pt in points)
        {
            sortedByEnds.Add(pt);
        }
        sortedByEnds.Sort((x,y) => { if(x[1]>y[1]) return 1;
                                     else if(x[1]<y[1]) return -1;
                                     else return 0; });

        int idxMinEnd = 0;
        int idxMinStart = 0;
        int shots = 0;
        while(idxMinEnd < points.Length)
        {
            while(idxMinStart < points.Length && sortedByEnds[idxMinEnd][1] >= sortedByEnds[idxMinStart][0])
                idxMinStart++;

            shots++;

            idxMinEnd = idxMinStart ;
        }

        return shots;
    }
}
// @lc code=end
}
