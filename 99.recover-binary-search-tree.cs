/*
 * @lc app=leetcode id=99 lang=csharp
 *
 * [99] Recover Binary Search Tree
 *
 * https://leetcode.com/problems/recover-binary-search-tree/description/
 *
 * algorithms
 * Hard (41.64%)
 * Likes:    2344
 * Dislikes: 90
 * Total Accepted:    206K
 * Total Submissions: 482.5K
 * Testcase Example:  '[1,3,null,null,2]'
 *
 * You are given the root of a binary search tree (BST), where exactly two
 * nodes of the tree were swapped by mistake. Recover the tree without changing
 * its structure.
 * 
 * Follow up: A solution using O(n) space is pretty straight forward. Could you
 * devise a constant space solution?
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: root = [1,3,null,null,2]
 * Output: [3,1,null,null,2]
 * Explanation: 3 cannot be a left child of 1 because 3 > 1. Swapping 1 and 3
 * makes the BST valid.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: root = [3,1,4,null,null,2]
 * Output: [2,1,4,null,null,3]
 * Explanation: 2 cannot be in the right subtree of 3 because 2 < 3. Swapping 2
 * and 3 makes the BST valid.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * The number of nodes in the tree is in the range [2, 1000].
 * -2^31 <= Node.val <= 2^31 - 1
 * 
 * 
 */
 
 using System;
 using System.Collections.Generic;

namespace LP99 {
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

public class SolutionHelper {
    static public bool CheckBST(TreeNode root, TreeNode left=null, TreeNode right=null)
    {
        if(root==null)
            return true;

        if(left!=null && left.val > root.val)
        {
            return false;
        }
        if(right!=null && root.val > right.val)
        {
            return false;
        }
        return CheckBST(root.left, left, root) && CheckBST(root.right, root, right);
    }
    static public TreeNode CreateBST(int?[] seq)
    {
        Queue<TreeNode> processing = new Queue<TreeNode>();
        Queue<TreeNode> toProcess = new Queue<TreeNode>();
        if(seq.Length==0)
            return null;
        int i = 1;
        TreeNode root = new TreeNode(seq[0].Value);
        processing.Enqueue(root);
        while(processing.Count!=0)
        {
            if (i>=seq.Length)
                break;

            TreeNode curr = processing.Dequeue();
            if(seq[i].HasValue)
            {
                curr.left = new TreeNode(seq[i].Value);
                toProcess.Enqueue(curr.left);
            }
            i++;

            if (i>=seq.Length)
                break;

            if(seq[i].HasValue)
            {
                curr.right = new TreeNode(seq[i].Value);
                toProcess.Enqueue(curr.right);
            }
            i++;

            if(processing.Count==0)
            {
                var tmp = processing;
                processing = toProcess;
                toProcess = processing;
            }
        }

        return root;
    }
    static public int?[] BSTToNullableInt(TreeNode root)
    {
        List<int?> list = new List<int?>();
        Queue<TreeNode> processing = new Queue<TreeNode>();
        processing.Enqueue(root);
        while(processing.Count!=0)
        {
            var curr = processing.Dequeue();
            list.Add(curr?.val);
            if(curr!=null)
            {
                processing.Enqueue(curr.left);
                processing.Enqueue(curr.right);
            }
        }
        List<int> removeList = new List<int>();
        for(int i = list.Count-1; i >= 0; i--)
        {
            if(list[i]!=null) break;

            removeList.Add(i);
        }
        foreach(var i in removeList)
            list.RemoveAt(i);
        return list.ToArray();
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
    public void RecoverTree(TreeNode root) {
        List<TreeNode[]> disorders = new List<TreeNode[]>();
        Stack<TreeNode> open = new Stack<TreeNode>();
        TreeNode last = null;
        TreeNode p = root;
        while(p!=null || open.Count>0){
            while(p!=null)
            {
                open.Push(p);
                p = p.left;
            }
            TreeNode curr = open.Pop();
            if(last!=null)
            {
                if(last.val > curr.val)
                    disorders.Add(new TreeNode[]{last, curr});
            }
            last = curr;
            p = curr.right;
        }
        var tmp = disorders[0][0].val;
        disorders[0][0].val = disorders[disorders.Count-1][1].val;
        disorders[disorders.Count-1][1].val = tmp;
        
    }
}
// @lc code=end
}

