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

using System;
using System.Collections.Generic;
 namespace LP1293 {

// @lc code=start
public class Solution {
    private int ShortestPathHelper(int[][] grid, int k, bool[,,] visited)
    {
        int[,] move = new int[,]{{1, 0}, {-1, 0}, {0, 1}, {0, -1}};

        int ul = grid.Length;
        int vl = grid[0].Length;

        Queue<(int u, int v, int k)> queue = new Queue<(int u, int v, int k)>();
        queue.Enqueue((0, 0, k));
        for(int step = 0; queue.Count > 0; step++)
        {
            int cnt = queue.Count;
            for(int i = 0; i < cnt; i++)
            {
                var ptk = queue.Dequeue();
                if(ptk.u == ul - 1 && ptk.v == vl - 1)
                    return step;
                for(int j = 0; j < 4; j++)
                {
                    int uNew = ptk.u + move[j,0];
                    int vNew = ptk.v + move[j,1];
                    if(uNew >= 0 && uNew < ul && vNew >=0 && vNew < vl)
                    {
                        if(grid[uNew][vNew]==1 && ptk.k > 0 && !visited[uNew, vNew, ptk.k - 1]) {
                            queue.Enqueue((uNew, vNew, ptk.k - 1));
                            visited[uNew, vNew, ptk.k - 1] = true;
                        }
                        else if(grid[uNew][vNew]==0  && !visited[uNew, vNew, ptk.k]) {
                            queue.Enqueue((uNew, vNew, ptk.k));
                            visited[uNew, vNew, ptk.k] = true;
                        }
                    }
                }
            }
        }
        return -1;
    }
    public int ShortestPath(int[][] grid, int k) {
        bool[,,] visited = new bool[grid.Length, grid[0].Length, k + 1];
       return ShortestPathHelper(grid, k, visited);
    }
}
// @lc code=end
}
