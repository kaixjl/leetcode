/*
 * @lc app=leetcode id=1210 lang=csharp
 *
 * [1210] Minimum Moves to Reach Target with Rotations
 *
 * https://leetcode.com/problems/minimum-moves-to-reach-target-with-rotations/description/
 *
 * algorithms
 * Hard (45.88%)
 * Likes:    161
 * Dislikes: 48
 * Total Accepted:    6.1K
 * Total Submissions: 13K
 * Testcase Example:  '[[0,0,0,0,0,1],[1,1,0,0,1,0],[0,0,0,0,1,1],[0,0,1,0,1,0],[0,1,1,0,0,0],[0,1,1,0,0,0]]\r'
 *
 * In an n*n grid, there is a snake that spans 2 cells and starts moving from
 * the top left corner at (0, 0) and (0, 1). The grid has empty cells
 * represented by zeros and blocked cells represented by ones. The snake wants
 * to reach the lower right corner at (n-1, n-2) and (n-1, n-1).
 * 
 * In one move the snake can:
 * 
 * 
 * Move one cell to the right if there are no blocked cells there. This move
 * keeps the horizontal/vertical position of the snake as it is.
 * Move down one cell if there are no blocked cells there. This move keeps the
 * horizontal/vertical position of the snake as it is.
 * Rotate clockwise if it's in a horizontal position and the two cells under it
 * are both empty. In that case the snake moves from (r, c) and (r, c+1) to (r,
 * c) and (r+1, c).
 * 
 * Rotate counterclockwise if it's in a vertical position and the two cells to
 * its right are both empty. In that case the snake moves from (r, c) and (r+1,
 * c) to (r, c) and (r, c+1).
 * 
 * 
 * 
 * Return the minimum number of moves to reach the target.
 * 
 * If there is no way to reach the target, return -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * 
 * Input: grid = [[0,0,0,0,0,1],
 * ⁠              [1,1,0,0,1,0],
 * [0,0,0,0,1,1],
 * [0,0,1,0,1,0],
 * [0,1,1,0,0,0],
 * [0,1,1,0,0,0]]
 * Output: 11
 * Explanation:
 * One possible solution is [right, right, rotate clockwise, right, down, down,
 * down, down, rotate counterclockwise, right, down].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: grid = [[0,0,1,1,1,1],
 * [0,0,0,0,1,1],
 * [1,1,0,0,0,1],
 * [1,1,1,0,0,1],
 * [1,1,1,0,0,1],
 * [1,1,1,0,0,0]]
 * Output: 9
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= n <= 100
 * 0 <= grid[i][j] <= 1
 * It is guaranteed that the snake starts at empty cells.
 * 
 * 
 */
using System;
using System.Collections.Generic;

namespace LP1210 {
// @lc code=start
public class Solution {
    public int MinimumMoves(int[][] grid) {
        // BFS
        int N = grid.Length;
        Queue<(int u, int v, int direct)> queue = new Queue<(int u, int v, int direct)>(); // direct: 0 for horizontal, 1 for vertical.
        bool[,,] accessed = new bool[N, N, 2];
        queue.Enqueue((0, 0, 0));
        accessed[0, 0, 0] = true;
        for(int step = 0; queue.Count > 0; step++) {
            int cnt = queue.Count;
            for(int _ = 0; _ < cnt; _++) {
                var curr = queue.Dequeue();
                
                // case base
                if(curr.u==N-1 && curr.v==N - 2 && curr.direct==0)
                    return step;
                
                // case direct==0
                if(curr.direct==0) { // horizontal
                    // case right
                    if(curr.v + 2 < N && grid[curr.u][curr.v + 2]==0) {
                        if(!accessed[curr.u, curr.v + 1, curr.direct]) {
                            queue.Enqueue((curr.u, curr.v + 1, curr.direct));
                            accessed[curr.u, curr.v + 1, curr.direct] = true;
                        }
                    }

                    if(curr.u + 1 < N && grid[curr.u + 1][curr.v]==0 && grid[curr.u + 1][curr.v + 1]==0) {
                        // case down
                        if(!accessed[curr.u + 1, curr.v, curr.direct]) {
                            queue.Enqueue((curr.u + 1, curr.v, curr.direct));
                            accessed[curr.u + 1, curr.v, curr.direct] = true;
                        }

                        //case clockwise
                        if(!accessed[curr.u, curr.v, 1]) {
                            queue.Enqueue((curr.u, curr.v, 1));
                            accessed[curr.u, curr.v, 1] = true;
                        }
                    }

                } else if(curr.direct==1) { // vertical

                    if(curr.v + 1 < N && grid[curr.u][curr.v + 1]==0 && grid[curr.u + 1][curr.v + 1]==0) {
                        // case right
                        if(!accessed[curr.u, curr.v + 1, curr.direct]) {
                            queue.Enqueue((curr.u, curr.v + 1, curr.direct));
                            accessed[curr.u, curr.v + 1, curr.direct] = true;
                        }

                        // case counterclockwise
                        if(!accessed[curr.u, curr.v, 0]) {
                            queue.Enqueue((curr.u, curr.v, 0));
                            accessed[curr.u, curr.v, 0] = true;
                        }
                    }

                    // case down
                    if(curr.u + 2 < N && grid[curr.u + 2][curr.v]==0) {
                        if(!accessed[curr.u + 1, curr.v, curr.direct]) {
                            queue.Enqueue((curr.u + 1, curr.v, curr.direct));
                            accessed[curr.u + 1, curr.v, curr.direct] = true;
                        }
                    }
                }
            }
        }
        return -1;
    }
}
// @lc code=end
}
