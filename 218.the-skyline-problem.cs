/*
 * @lc app=leetcode id=218 lang=csharp
 *
 * [218] The Skyline Problem
 *
 * https://leetcode.com/problems/the-skyline-problem/description/
 *
 * algorithms
 * Hard (37.08%)
 * Likes:    2998
 * Dislikes: 166
 * Total Accepted:    175.3K
 * Total Submissions: 472.8K
 * Testcase Example:  '[[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]'
 *
 * A city's skyline is the outer contour of the silhouette formed by all the
 * buildings in that city when viewed from a distance. Given the locations and
 * heights of all the buildings, return the skyline formed by these buildings
 * collectively.
 * 
 * The geometric information of each building is given in the array buildings
 * where buildings[i] = [lefti, righti, heighti]:
 * 
 * 
 * lefti is the x coordinate of the left edge of the i^th building.
 * righti is the x coordinate of the right edge of the i^th building.
 * heighti is the height of the i^th building.
 * 
 * 
 * You may assume all buildings are perfect rectangles grounded on an
 * absolutely flat surface at height 0.
 * 
 * The skyline should be represented as a list of "key points" sorted by their
 * x-coordinate in the form [[x1,y1],[x2,y2],...]. Each key point is the left
 * endpoint of some horizontal segment in the skyline except the last point in
 * the list, which always has a y-coordinate 0 and is used to mark the
 * skyline's termination where the rightmost building ends. Any ground between
 * the leftmost and rightmost buildings should be part of the skyline's
 * contour.
 * 
 * Note: There must be no consecutive horizontal lines of equal height in the
 * output skyline. For instance, [...,[2 3],[4 5],[7 5],[11 5],[12 7],...] is
 * not acceptable; the three lines of height 5 should be merged into one in the
 * final output as such: [...,[2 3],[4 5],[12 7],...]
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: buildings = [[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]
 * Output: [[2,10],[3,15],[7,12],[12,0],[15,10],[20,8],[24,0]]
 * Explanation:
 * Figure A shows the buildings of the input.
 * Figure B shows the skyline formed by those buildings. The red points in
 * figure B represent the key points in the output list.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: buildings = [[0,2,3],[2,5,3]]
 * Output: [[0,3],[5,0]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= buildings.length <= 10^4
 * 0 <= lefti < righti <= 2^31 - 1
 * 1 <= heighti <= 2^31 - 1
 * buildings is sorted by lefti in non-decreasing order.
 * 
 * 
 */
using System;
using System.Collections.Generic;

namespace LP218 {
// @lc code=start
public class Solution {
    private int ListMax(IList<int> list) {
        int m = int.MinValue;
        foreach(var v in list) {
            m = Math.Max(v, m);
        }
        return m;
    }
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        List<int[]> ll = new List<int[]>(buildings);
        List<int[]> rl = new List<int[]>(buildings);
        rl.Sort(new Comparison<int[]>((x, y) => x[1].CompareTo(y[1])));

        List<int[]> list = new List<int[]>(buildings.Length * 2);
        int i = 0, j = 0;
        for(; i < ll.Count && j < rl.Count;) {
            if(ll[i][0] <= rl[j][1]) {
                list.Add(new int[]{ll[i][0], ll[i][2]});
                i++;
            }
            else {
                list.Add(new int[]{rl[j][1], -rl[j][2]});
                j++;
            }
        }
        for(;j < rl.Count;j++) {
            list.Add(new int[]{rl[j][1], -rl[j][2]});
        }
        List<int> sl = new List<int>(buildings.Length);
        List<int[]> outputs = new List<int[]>();
        for(int k = 0; k < list.Count;) {
            var v = list[k];
            while(k < list.Count && list[k][0] == v[0]) {
                v = list[k];
                if(v[1] > 0)
                    sl.Add(v[1]);
                else
                    sl.Remove(-v[1]);
                k++;
            }
            if(outputs.Count==0) {
                outputs.Add(new int[]{v[0], ListMax(sl)});
            }
            else {
                if(sl.Count == 0) {
                    if(0 != outputs[^1][1]) {
                        outputs.Add(new int[]{v[0], 0});
                    }
                }
                else if(ListMax(sl) != outputs[^1][1]) {
                    if(outputs[^1][0] == v[0]) {
                        if(ListMax(sl) > outputs[^1][1]) {
                            outputs.RemoveAt(outputs.Count - 1);
                            outputs.Add(new int[]{v[0], ListMax(sl)});
                        }
                    } else {
                        outputs.Add(new int[]{v[0], ListMax(sl)});
                    }
                }
            }
            
        }

        return outputs.ToArray();
    }
}
// @lc code=end
}
