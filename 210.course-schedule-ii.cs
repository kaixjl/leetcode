/*
 * @lc app=leetcode id=210 lang=csharp
 *
 * [210] Course Schedule II
 *
 * https://leetcode.com/problems/course-schedule-ii/description/
 *
 * algorithms
 * Medium (41.69%)
 * Likes:    3507
 * Dislikes: 164
 * Total Accepted:    379.9K
 * Total Submissions: 886.1K
 * Testcase Example:  '2\n[[1,0]]'
 *
 * There are a total of n courses you have to take labelled from 0 to n - 1.
 * 
 * Some courses may have prerequisites, for example, if prerequisites[i] = [ai,
 * bi] this means you must take the course bi before the course ai.
 * 
 * Given the total number of courses numCourses and a list of the prerequisite
 * pairs, return the ordering of courses you should take to finish all
 * courses.
 * 
 * If there are many valid answers, return any of them. If it is impossible to
 * finish all courses, return an empty array.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: numCourses = 2, prerequisites = [[1,0]]
 * Output: [0,1]
 * Explanation: There are a total of 2 courses to take. To take course 1 you
 * should have finished course 0. So the correct course order is [0,1].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
 * Output: [0,2,1,3]
 * Explanation: There are a total of 4 courses to take. To take course 3 you
 * should have finished both courses 1 and 2. Both courses 1 and 2 should be
 * taken after you finished course 0.
 * So one correct course order is [0,1,2,3]. Another correct ordering is
 * [0,2,1,3].
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: numCourses = 1, prerequisites = []
 * Output: [0]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= numCourses <= 2000
 * 0 <= prerequisites.length <= numCourses * (numCourses - 1)
 * prerequisites[i].length == 2
 * 0 <= ai, bi < numCourses
 * ai != bi
 * All the pairs [ai, bi] are distinct.
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

public partial class Solution {
    public bool CheckP210(int[] seq, int[][] prerequisites){
        Dictionary<int, CourseTreeNode> nodes = PrerequisitesToCourseTreeNodes(seq.Length, prerequisites);
        foreach(var course in seq)
        {
            if (nodes[course].learned)
                return false;
            foreach(var pre in nodes[course].prerequisites)
                if (pre.learned == false)
                    return false;
            
            nodes[course].learned = true;
        }
        return true;
    }
}

// @lc code=start
public class CourseTreeNode {
    public int val = 0;
    public CourseTreeNode parrent = null;
    public bool learned = false;
    public List<CourseTreeNode> prerequisites;
    public CourseTreeNode(int val=0) {
        this.val = val;
        prerequisites = new List<CourseTreeNode>();
    }

    public bool Equals(CourseTreeNode other)
    {
        if (other == null)
            return false;

        return this.val == other.val;
    }

    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;

        CourseTreeNode treeNodeObj = obj as CourseTreeNode;
        if (treeNodeObj == null)
            return false;
        else
            return Equals(treeNodeObj);
    }

    public override int GetHashCode()
    {

        return this.val.GetHashCode();
    }

    public static bool operator == (CourseTreeNode treeNode1, CourseTreeNode treeNode2)
    {
        if (((object)treeNode1) == null || ((object)treeNode2) == null)
            return Object.Equals(treeNode1, treeNode2);

        return treeNode1.Equals(treeNode2);
    }

    public static bool operator != (CourseTreeNode treeNode1, CourseTreeNode treeNode2)
    {
        if (((object)treeNode1) == null || ((object)treeNode2) == null)
            return ! Object.Equals(treeNode1, treeNode2);

        return ! (treeNode1.Equals(treeNode2));
    }

    public override String ToString()
    {
        return this.val.ToString();
    }
}
public partial class Solution {
    public Dictionary<int ,CourseTreeNode> PrerequisitesToCourseTreeNodes(int numCourses, int[][] prerequisites)
    {
        Dictionary<int, CourseTreeNode> nodes = new Dictionary<int, CourseTreeNode>();
        for (int i = 0; i < numCourses; i++)
            nodes.Add(i, new CourseTreeNode(i));
        for(int i = 0; i < prerequisites.GetLength(0); i++)
        {
            int f = prerequisites[i][0];
            int c = prerequisites[i][1];
            CourseTreeNode node_f = nodes[f], node_c = nodes[c];

            node_f.prerequisites.Add(node_c);
            node_c.parrent = node_f;
        }
        
        return nodes;
    }

    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int, CourseTreeNode> nodes = PrerequisitesToCourseTreeNodes(numCourses, prerequisites);
        List<List<int>> orders = new List<List<int>>();
        HashSet<CourseTreeNode> close = new HashSet<CourseTreeNode>();

        for(int i = 0; i < numCourses; i++)
        {
            Queue<CourseTreeNode> open_l = new Queue<CourseTreeNode>();
            HashSet<CourseTreeNode> close_l = new HashSet<CourseTreeNode>();
            List<int> order = new List<int>();

            CourseTreeNode head = nodes[i];

            open_l.Enqueue(head);
            while(open_l.Count>0)
            {
                CourseTreeNode curr = open_l.Dequeue();
                if(close.Contains(curr))
                    continue;
                if(close_l.Contains(curr))
                    return new int[0];
                order.Add(curr.val);

                foreach(var child in curr.prerequisites)
                    if (!open_l.Contains(child))
                        open_l.Enqueue(child);

                close_l.Add(curr);
            }
            orders.Add(order);
            close.UnionWith(close_l);
        }

        List<int> o = new List<int>(numCourses);
        foreach(var order in orders)
            foreach(var val in order.Reverse<int>())
                o.Add(val);
        return o.ToArray();
    }
}
// @lc code=end

