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
        Stack<TreeNode> stack = new Stack<TreeNode>();
        int deepest = 0;
        int sum = 0;
        stack.Push(root);
        while(stack.Count>0)
        {
            var curr = stack.Pop();
            var currDeep = curr.val / 1000;
            if(curr.left!=null)
            {
                var child = curr.left;
                var childDeep = currDeep + 1;
                child.val += childDeep * 1000;
                if(childDeep > deepest)
                {
                    sum = child.val % 1000;
                    deepest = childDeep;
                } else if (childDeep == deepest)
                    sum += child.val % 1000;
                stack.Push(child);
            }
            if(curr.right!=null)
            {
                var child = curr.right;
                var childDeep = currDeep + 1;
                child.val += childDeep * 1000;
                if(childDeep > deepest)
                {
                    sum = child.val % 1000;
                    deepest = childDeep;
                } else if (childDeep == deepest)
                    sum += child.val % 1000;
                stack.Push(child);
            }
        }

        return sum;
    }
}
// @lc code=end
}
