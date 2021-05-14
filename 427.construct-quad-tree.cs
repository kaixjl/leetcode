/*
 * @lc app=leetcode id=427 lang=csharp
 *
 * [427] Construct Quad Tree
 *
 * https://leetcode.com/problems/construct-quad-tree/description/
 *
 * algorithms
 * Medium (62.00%)
 * Likes:    329
 * Dislikes: 496
 * Total Accepted:    28.6K
 * Total Submissions: 45.4K
 * Testcase Example:  '[[0,1],[1,0]]'
 *
 * Given a n * n matrix grid of 0's and 1's only. We want to represent the grid
 * with a Quad-Tree.
 * 
 * Return the root of the Quad-Tree representing the grid.
 * 
 * Notice that you can assign the value of a node to True or False when isLeaf
 * is False, and both are accepted in the answer.
 * 
 * A Quad-Tree is a tree data structure in which each internal node has exactly
 * four children. Besides, each node has two attributes:
 * 
 * 
 * val: True if the node represents a grid of 1's or False if the node
 * represents a grid of 0's. 
 * isLeaf: True if the node is leaf node on the tree or False if the node has
 * the four children.
 * 
 * 
 * 
 * class Node {
 * ⁠   public boolean val;
 * public boolean isLeaf;
 * public Node topLeft;
 * public Node topRight;
 * public Node bottomLeft;
 * public Node bottomRight;
 * }
 * 
 * We can construct a Quad-Tree from a two-dimensional area using the following
 * steps:
 * 
 * 
 * If the current grid has the same value (i.e all 1's or all 0's) set isLeaf
 * True and set val to the value of the grid and set the four children to Null
 * and stop.
 * If the current grid has different values, set isLeaf to False and set val to
 * any value and divide the current grid into four sub-grids as shown in the
 * photo.
 * Recurse for each of the children with the proper sub-grid.
 * 
 * 
 * If you want to know more about the Quad-Tree, you can refer to the wiki.
 * 
 * Quad-Tree format:
 * 
 * The output represents the serialized format of a Quad-Tree using level order
 * traversal, where null signifies a path terminator where no node exists
 * below.
 * 
 * It is very similar to the serialization of the binary tree. The only
 * difference is that the node is represented as a list [isLeaf, val].
 * 
 * If the value of isLeaf or val is True we represent it as 1 in the list
 * [isLeaf, val] and if the value of isLeaf or val is False we represent it as
 * 0.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: grid = [[0,1],[1,0]]
 * Output: [[0,1],[1,0],[1,1],[1,1],[1,0]]
 * Explanation: The explanation of this example is shown below:
 * Notice that 0 represnts False and 1 represents True in the photo
 * representing the Quad-Tree.
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * 
 * 
 * Input: grid =
 * [[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0]]
 * Output:
 * [[0,1],[1,1],[0,1],[1,1],[1,0],null,null,null,null,[1,0],[1,0],[1,1],[1,1]]
 * Explanation: All values in the grid are not the same. We divide the grid
 * into four sub-grids.
 * The topLeft, bottomLeft and bottomRight each has the same value.
 * The topRight have different values so we divide it into 4 sub-grids where
 * each has the same value.
 * Explanation is shown in the photo below:
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: grid = [[1,1],[1,1]]
 * Output: [[1,1]]
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: grid = [[0]]
 * Output: [[1,0]]
 * 
 * 
 * Example 5:
 * 
 * 
 * Input: grid = [[1,1,0,0],[1,1,0,0],[0,0,1,1],[0,0,1,1]]
 * Output: [[0,1],[1,1],[1,0],[1,0],[1,1]]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == grid.length == grid[i].length
 * n == 2^x where 0 <= x <= 6
 * 
 * 
 */

using System;
using System.Collections.Generic;

namespace LP427 {
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
// @lc code=start
/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/
public class Solution {
    public Node Construct(int[][] grid) {
        int nlayer = 0;
        
        for(int l = grid.Length; l > 0; nlayer++, l /= 2);
        int[][,,] grids = new int[nlayer][,,];
        
        for(int i = 0, l = grid.Length; i < grids.Length; i++, l /= 2)
            grids[i] = new int[l, l, 2];
        
        for(int i = 0; i < grid.Length; i++)
            for(int j = 0; j < grid.Length; j++) {
                grids[0][i, j, 1] = grid[i][j];
                grids[0][i, j, 0] = 1;
            }
        
        for(int layer = 1, l = grid.Length / 2; layer < nlayer; layer++, l /= 2) {
            for(int i = 0; i < l; i++)
                for(int j = 0; j < l; j++) {
                    int tl = grids[layer - 1][i * 2, j * 2, 1];
                    int tr = grids[layer - 1][i * 2, j * 2 + 1, 1];
                    int bl = grids[layer - 1][i * 2 + 1, j * 2, 1];
                    int br = grids[layer - 1][i * 2 + 1, j * 2 + 1, 1];
                    int tl_leaf = grids[layer - 1][i * 2, j * 2, 0];
                    int tr_leaf = grids[layer - 1][i * 2, j * 2 + 1, 0];
                    int bl_leaf = grids[layer - 1][i * 2 + 1, j * 2, 0];
                    int br_leaf = grids[layer - 1][i * 2 + 1, j * 2 + 1, 0];
                    if (tl_leaf == 1 && tr_leaf == 1 && bl_leaf == 1 && br_leaf == 1 &&
                        tl == tr && tl == bl && tl == br) {
                        grids[layer][i, j, 0] = 1;
                        grids[layer][i, j, 1] = tl;
                    }
                }
        }

        Node root = new Node(grids[^1][0, 0, 1] == 1, grids[^1][0, 0, 0] == 1);
        Queue<(int layer, int u, int v, Node node)> queue = new Queue<(int layer, int u, int v, Node node)>();
        queue.Enqueue((nlayer - 1, 0, 0, root));
        while(queue.Count > 0) {
            (int layer, int u, int v, Node curr) = queue.Dequeue();
            if(!curr.isLeaf) {
                Node tl = new Node(grids[layer - 1][u * 2, v * 2, 1] == 1, grids[layer - 1][u * 2, v * 2, 0] == 1);
                curr.topLeft = tl;
                queue.Enqueue((layer - 1, u * 2, v * 2, tl));

                Node tr = new Node(grids[layer - 1][u * 2, v * 2 + 1, 1] == 1, grids[layer - 1][u * 2, v * 2 + 1, 0] == 1);
                curr.topRight = tr;
                queue.Enqueue((layer - 1, u * 2, v * 2 + 1, tr));
                
                Node bl = new Node(grids[layer - 1][u * 2 + 1, v * 2, 1] == 1, grids[layer - 1][u * 2 + 1, v * 2, 0] == 1);
                curr.bottomLeft = bl;
                queue.Enqueue((layer - 1, u * 2 + 1, v * 2, bl));
                
                Node br = new Node(grids[layer - 1][u * 2 + 1, v * 2 + 1, 1] == 1, grids[layer - 1][u * 2 + 1, v * 2 + 1, 0] == 1);
                curr.bottomRight = br;
                queue.Enqueue((layer - 1, u * 2 + 1, v * 2 + 1, br));
            }
        }

        return root;
    }
}
// @lc code=end
}
