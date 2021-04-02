/*
 * @lc app=leetcode id=1632 lang=csharp
 *
 * [1632] Rank Transform of a Matrix
 *
 * https://leetcode.com/problems/rank-transform-of-a-matrix/description/
 *
 * algorithms
 * Hard (29.23%)
 * Likes:    192
 * Dislikes: 6
 * Total Accepted:    3.5K
 * Total Submissions: 10.9K
 * Testcase Example:  '[[1,2],[3,4]]'
 *
 * Given an m x n matrix, return a new matrix answer where answer[row][col] is
 * the rank of matrix[row][col].
 * 
 * The rank is an integer that represents how large an element is compared to
 * other elements. It is calculated using the following rules:
 * 
 * 
 * The rank is an integer starting from 1.
 * If two elements p and q are in the same row or column, then:
 * 
 * If p < q then rank(p) < rank(q)
 * If p == q then rank(p) == rank(q)
 * If p > q then rank(p) > rank(q)
 * 
 * 
 * The rank should be as small as possible.
 * 
 * 
 * It is guaranteed that answer is unique under the given rules.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: matrix = [[1,2],[3,4]]
 * Output: [[1,2],[2,3]]
 * Explanation:
 * The rank of matrix[0][0] is 1 because it is the smallest integer in its row
 * and column.
 * The rank of matrix[0][1] is 2 because matrix[0][1] > matrix[0][0] and
 * matrix[0][0] is rank 1.
 * The rank of matrix[1][0] is 2 because matrix[1][0] > matrix[0][0] and
 * matrix[0][0] is rank 1.
 * The rank of matrix[1][1] is 3 because matrix[1][1] > matrix[0][1],
 * matrix[1][1] > matrix[1][0], and both matrix[0][1] and matrix[1][0] are rank
 * 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: matrix = [[7,7],[7,7]]
 * Output: [[1,1],[1,1]]
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: matrix = [[20,-21,14],[-19,4,19],[22,-47,24],[-19,4,19]]
 * Output: [[4,2,3],[1,3,4],[5,1,6],[1,3,4]]
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: matrix = [[7,3,6],[1,4,5],[9,8,2]]
 * Output: [[5,1,4],[1,2,3],[6,3,1]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == matrix.length
 * n == matrix[i].length
 * 1 <= m, n <= 500
 * -10^9 <= matrix[row][col] <= 10^9
 * 
 * 
 */

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Linq;

// @lc code=start
public partial class Solution {
    public int[][] MatrixRankTransform(int[][] matrix) {
        SortedList<int, List<int[]>> vals = new SortedList<int, List<int[]>>();
        for(int i = 0; i < matrix.Length; i++)
            for(int j = 0; j < matrix[i].Length; j++)
            {
                var val = matrix[i][j];
                if(vals.ContainsKey(val))
                    vals[val].Add(new int[]{i, j});
                else
                {
                    List<int[]> list = new List<int[]>();
                    list.Add(new int[]{i, j});
                    vals.Add(val, list);
                }
            }
        
        int[][] rank = new int[matrix.Length][];
        for(int i = 0; i < rank.Length; i++)
        {
            rank[i] = new int[matrix[i].Length];
            for(int j = 0; j < rank[i].Length; j++)
                rank[i][j] = 0;
        }

        int[] max_rank_in_rows = new int[matrix.Length];
        for(int i = 0; i < max_rank_in_rows.Length; i++)
            max_rank_in_rows[i] = 0;

        int[] max_rank_in_cols = new int[matrix[0].Length];
        for(int i = 0; i < max_rank_in_cols.Length; i++)
            max_rank_in_cols[i] = 0;

        // 从最小开始检查每个元素行列
        foreach(var pts in vals.Values)
        {
            var v = matrix[pts[0][0]][pts[0][1]];
            var curr_rank = Math.Max(max_rank_in_rows[i], max_rank_in_cols[j]) + 1;
            foreach (var pt in pts)
            {
                var i = pt[0];
                var j = pt[1];
                rank[i][j] = curr_rank;
                max_rank_in_rows[i] = curr_rank;
                max_rank_in_cols[j] = curr_rank;
            }
        }

        return rank;
    }
}
// @lc code=end

