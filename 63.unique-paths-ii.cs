/*
 * @lc app=leetcode id=63 lang=csharp
 *
 * [63] Unique Paths II
 *
 * https://leetcode.com/problems/unique-paths-ii/description/
 *
 * algorithms
 * Medium (36.05%)
 * Likes:    3417
 * Dislikes: 316
 * Total Accepted:    416.7K
 * Total Submissions: 1.1M
 * Testcase Example:  '[[0,0,0],[0,1,0],[0,0,0]]'
 *
 * A robot is located at the top-left corner of a m x n grid (marked 'Start' in
 * the diagram below).
 * 
 * The robot can only move either down or right at any point in time. The robot
 * is trying to reach the bottom-right corner of the grid (marked 'Finish' in
 * the diagram below).
 * 
 * Now consider if some obstacles are added to the grids. How many unique paths
 * would there be?
 * 
 * An obstacle and space is marked as 1 and 0 respectively in the grid.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]
 * Output: 2
 * Explanation: There is one obstacle in the middle of the 3x3 grid above.
 * There are two ways to reach the bottom-right corner:
 * 1. Right -> Right -> Down -> Down
 * 2. Down -> Down -> Right -> Right
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: obstacleGrid = [[0,1],[0,0]]
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == obstacleGrid.length
 * n == obstacleGrid[i].length
 * 1 <= m, n <= 100
 * obstacleGrid[i][j] is 0 or 1.
 * 
 * 
 */
using System;
using System.Collections.Generic;
namespace LP63 {

// @lc code=start
public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        if(obstacleGrid[0][0]==1) return 0;
        int M = obstacleGrid.Length, N = obstacleGrid[0].Length;
        int [,] mem = new int[obstacleGrid.Length, obstacleGrid[0].Length];
        mem[0,0] = 1;
        for(int i = 0; i < M; i++) {
            for(int j = 0; j < N; j++) {
                if(obstacleGrid[i][j] == 1) continue;
                if(i > 0 && obstacleGrid[i-1][j] != 1) {
                    mem[i,j] += mem[i-1,j];
                }
                if(j > 0 && obstacleGrid[i][j-1] != 1) {
                    mem[i,j] += mem[i,j-1];
                }
            }
        }

        return mem[M-1, N-1];
    }
}
// @lc code=end
}
