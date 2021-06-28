/*
 * @lc app=leetcode id=240 lang=csharp
 *
 * [240] Search a 2D Matrix II
 *
 * https://leetcode.com/problems/search-a-2d-matrix-ii/description/
 *
 * algorithms
 * Medium (45.90%)
 * Likes:    5028
 * Dislikes: 94
 * Total Accepted:    466.8K
 * Total Submissions: 1M
 * Testcase Example:  '[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]\n' +
  '5'
 *
 * Write an efficient algorithm that searches for a target value in an m x n
 * integer matrix. The matrix has the following properties:
 * 
 * 
 * Integers in each row are sorted in ascending from left to right.
 * Integers in each column are sorted in ascending from top to bottom.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: matrix =
 * [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]],
 * target = 5
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: matrix =
 * [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]],
 * target = 20
 * Output: false
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * m == matrix.length
 * n == matrix[i].length
 * 1 <= n, m <= 300
 * -10^9 <= matix[i][j] <= 10^9
 * All the integers in each row are sorted in ascending order.
 * All the integers in each column are sorted in ascending order.
 * -10^9 <= target <= 10^9
 * 
 * 
 */
namespace LP240 {
// @lc code=start
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return false;

        int i = 0, j = matrix[0].Length - 1;
        // 对于任意元素，该元素左侧（同行）和上方（同列）的元素都小于该元素，右侧（同行）和下方（同列）的元素都大于该元素。
        // 因此，（可以将该矩阵近似看作以右上角或左下角的元素为根节点的二叉树，）从右上角向左下搜索，或从左下角向右上搜索，
        // 一次向左/下、右/上移动一步。
        while(i < matrix.Length && j >= 0) {
            int curr = matrix[i][j];
            if(target > curr) {
                i++;
            }
            else if(target < curr) {
                j--;
            }
            else {
                return true;
            }
        }

        return false;
    }
}
// @lc code=end
}
