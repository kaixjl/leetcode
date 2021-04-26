/*
 * @lc app=leetcode id=1293 lang=csharp
 *
 * [1293] Shortest Path in a Grid with Obstacles Elimination
 *
 * https://leetcode.com/problems/shortest-path-in-a-grid-with-obstacles-elimination/description/
 *
 * algorithms
 * Hard (42.80%)
 * Likes:    741
 * Dislikes: 12
 * Total Accepted:    26.8K
 * Total Submissions: 62.2K
 * Testcase Example:  '[[0,0,0],[1,1,0],[0,0,0],[0,1,1],[0,0,0]]\n1'
 *
 * Given a m * n grid, where each cell is either 0 (empty) or 1 (obstacle). In
 * one step, you can move up, down, left or right from and to an empty cell.
 * 
 * Return the minimum number of steps to walk from the upper left corner (0, 0)
 * to the lower right corner (m-1, n-1) given that you can eliminate at most k
 * obstacles. If it is not possible to find such walk return -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: 
 * grid = 
 * [[0,0,0],
 * [1,1,0],
 * ⁠[0,0,0],
 * [0,1,1],
 * ⁠[0,0,0]], 
 * k = 1
 * Output: 6
 * Explanation: 
 * The shortest path without eliminating any obstacle is 10. 
 * The shortest path with one obstacle elimination at position (3,2) is 6. Such
 * path is (0,0) -> (0,1) -> (0,2) -> (1,2) -> (2,2) -> (3,2) -> (4,2).
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 
 * grid = 
 * [[0,1,1],
 * [1,1,1],
 * [1,0,0]], 
 * k = 1
 * Output: -1
 * Explanation: 
 * We need to eliminate at least two obstacles to find such a walk.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * grid.length == m
 * grid[0].length == n
 * 1 <= m, n <= 40
 * 1 <= k <= m*n
 * grid[i][j] == 0 or 1
 * grid[0][0] == grid[m-1][n-1] == 0
 * 
 * 
 */
 namespace LP1293 {

// @lc code=start
public class Solution {
    private int ShortestPathHelper(int[][] grid, int k, (int, int) pt, bool[][] walked, int[][] step)
    {
        bool InBound((int, int) pt, (int, int) ptl)
        {
            (int ptu, int ptv) = pt;
            (int ptul, int ptvl) = ptl;
            return ptu >= 0 && ptu < ptul && ptv >=0 && ptv < ptvl;
        }
        (int, int) Up((int, int) pt)
        {
            (int ptu, int ptv) = pt;
            return (ptu - 1, ptv);
        }
        (int, int) Down((int, int) pt)
        {
            (int ptu, int ptv) = pt;
            return (ptu + 1, ptv);
        }
        (int, int) Left((int, int) pt)
        {
            (int ptu, int ptv) = pt;
            return (ptu, ptv - 1);
        }
        (int, int) Right((int, int) pt)
        {
            (int ptu, int ptv) = pt;
            return (ptu, ptv + 1);
        }
        var (u, v) = pt;
        (int ul, int vl) ptl = (grid.Length, grid[0].Length);
        
        if(pt == (ptl.ul - 1, ptl.vl - 1))
            return 0;
        if(step[u][v]!=0)
            return step[u][v];

        int minStep = int.MaxValue;
        walked[u][v] = true;
        
        //Up
        var ptUp = Up(pt);
        var (uUp, vUp) = ptUp;
        if(InBound(ptUp, ptl) && !walked[uUp][vUp])
        {
            int minStep_l = int.MaxValue;
            if(grid[uUp][vUp]==1) {
                if(k > 0) {
                    minStep_l = ShortestPathHelper(grid, k-1, ptUp, walked, step);
                    if(minStep_l!=int.MaxValue)
                        minStep_l++;
                }
            }
            else {
                minStep_l = ShortestPathHelper(grid, k, ptUp, walked, step);
                if(minStep_l!=int.MaxValue)
                    minStep_l++;
            }
            if(minStep_l < minStep)
                minStep = minStep_l;
        }
        
        //Down
        var ptDown = Down(pt);
        var (uDown, vDown) = ptDown;
        if(InBound(ptDown, ptl) && !walked[uDown][vDown])
        {
            int minStep_l = int.MaxValue;
            if(grid[uDown][vDown]==1) {
                if(k > 0) {
                    minStep_l = ShortestPathHelper(grid, k-1, ptDown, walked, step);
                    if(minStep_l!=int.MaxValue)
                        minStep_l++;
                }
            }
            else {
                minStep_l = ShortestPathHelper(grid, k, ptDown, walked, step);
                if(minStep_l!=int.MaxValue)
                    minStep_l++;
            }
            if(minStep_l < minStep)
                minStep = minStep_l;
        }
        
        //Left
        var ptLeft = Left(pt);
        var (uLeft, vLeft) = ptLeft;
        if(InBound(ptLeft, ptl) && !walked[uLeft][vLeft])
        {
            int minStep_l = int.MaxValue;
            if(grid[uLeft][vLeft]==1) {
                if(k > 0) {
                    minStep_l = ShortestPathHelper(grid, k-1, ptLeft, walked, step);
                    if(minStep_l!=int.MaxValue)
                        minStep_l++;
                }
            }
            else {
                minStep_l = ShortestPathHelper(grid, k, ptLeft, walked, step);
                if(minStep_l!=int.MaxValue)
                    minStep_l++;
            }
            if(minStep_l < minStep)
                minStep = minStep_l;
        }
        
        //Right
        var ptRight = Right(pt);
        var (uRight, vRight) = ptRight;
        if(InBound(ptRight, ptl) && !walked[uRight][vRight])
        {
            int minStep_l = int.MaxValue;
            if(grid[uRight][vRight]==1) {
                if(k > 0) {
                    minStep_l = ShortestPathHelper(grid, k-1, ptRight, walked, step);
                    if(minStep_l!=int.MaxValue)
                        minStep_l++;
                }
            }
            else {
                minStep_l = ShortestPathHelper(grid, k, ptRight, walked, step);
                if(minStep_l!=int.MaxValue)
                    minStep_l++;
            }
            if(minStep_l < minStep)
                minStep = minStep_l;
        }
        return minStep;
    }
    public int ShortestPath(int[][] grid, int k) {
        bool[][] walked = new bool[grid.Length][];
        for (int i = 0; i < walked.Length; i++)
            walked[i] = new bool[grid[i].Length];
        int[][] step = new int[grid.Length][];
        for (int i = 0; i < step.Length; i++)
            step[i] = new int[grid[i].Length];
            
        var minStep = ShortestPathHelper(grid, k, (0, 0), walked, step);
        return minStep==int.MaxValue? -1 : minStep;
    }
}
// @lc code=end
}
