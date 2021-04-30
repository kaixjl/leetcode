/*
 * @lc app=leetcode id=1302 lang=csharp
 *
 * [1302] Deepest Leaves Sum
 *
 * https://leetcode.com/problems/deepest-leaves-sum/description/
 *
 * algorithms
 * Medium (83.90%)
 * Likes:    1331
 * Dislikes: 58
 * Total Accepted:    106.8K
 * Total Submissions: 125K
 * Testcase Example:  '[1,2,3,4,5,null,6,7,null,null,null,null,8]'
 *
 * Given the root of a binary tree, return the sum of values of its deepest
 * leaves.
 * 
 * Example 1:
 * 
 * 
 * Input: root = [1,2,3,4,5,null,6,7,null,null,null,null,8]
 * Output: 15
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [6,7,8,2,7,1,3,9,null,1,4,null,null,null,5]
 * Output: 19
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [1, 10^4].
 * 1 <= Node.val <= 100
 * 
 * 
 */
using System;
using System.Collections.Generic;

namespace LP1302 {
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int DeepestLeavesSum(TreeNode root) {
        Stack<TreeNode> stack1 = new Stack<TreeNode>(), stack2 = new Stack<TreeNode>();
        stack2.Push(root);
        
        while(stack2.Count>0)
        {
            Stack<TreeNode> t = stack1;
            stack1 = stack2;
            stack2 = t;
            stack2.Clear();
            foreach(var curr in stack1)
            {
                if(curr.left!=null)
                    stack2.Push(curr.left);
                if(curr.right!=null)
                    stack2.Push(curr.right);
            }
        }
    
        int sum = 0;
        foreach(var curr in stack1)
            sum += curr.val;

        return sum;
    }
}
// @lc code=end
}
