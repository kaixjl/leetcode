/*
 * @lc app=leetcode id=695 lang=csharp
 *
 * [695] Max Area of Island
 *
 * https://leetcode.com/problems/max-area-of-island/description/
 *
 * algorithms
 * Medium (63.68%)
 * Likes:    2897
 * Dislikes: 100
 * Total Accepted:    225.1K
 * Total Submissions: 346K
 * Testcase Example:  '[[1,1,0,0,0],[1,1,0,0,0],[0,0,0,1,1],[0,0,0,1,1]]'
 *
 * Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's
 * (representing land) connected 4-directionally (horizontal or vertical.) You
 * may assume all four edges of the grid are surrounded by water.
 * 
 * Find the maximum area of an island in the given 2D array. (If there is no
 * island, the maximum area is 0.)
 * 
 * Example 1:
 * 
 * 
 * [[0,0,1,0,0,0,0,1,0,0,0,0,0],
 * ⁠[0,0,0,0,0,0,0,1,1,1,0,0,0],
 * ⁠[0,1,1,0,1,0,0,0,0,0,0,0,0],
 * ⁠[0,1,0,0,1,1,0,0,1,0,1,0,0],
 * ⁠[0,1,0,0,1,1,0,0,1,1,1,0,0],
 * ⁠[0,0,0,0,0,0,0,0,0,0,1,0,0],
 * ⁠[0,0,0,0,0,0,0,1,1,1,0,0,0],
 * ⁠[0,0,0,0,0,0,0,1,1,0,0,0,0]]
 * 
 * Given the above grid, return 6. Note the answer is not 11, because the
 * island must be connected 4-directionally.
 * 
 * Example 2:
 * 
 * 
 * [[0,0,0,0,0,0,0,0]]
 * Given the above grid, return 0.
 * 
 * Note: The length of each dimension in the given grid does not exceed 50.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public struct Point {
    public int x;
    public int y;
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
public partial class Solution {
    public IEnumerable<int[]> Neighbor(int x, int y, int height, int width) {
        if(x - 1 >= 0)
            yield return new int[]{x-1, y};
        if(x+1 < width)
            yield return new int[]{x+1, y};
        if(y-1 >= 0)
            yield return new int[]{x, y-1};
        if(y+1 < height)
            yield return new int[]{x, y+1};
    }
    public List<List<T>> Create2DList<T>(int dim1, int dim2) where T: new()
    {
        List<List<T>> list = new List<List<T>>(dim1);

        for(int i = 0; i < dim1; i++)
        {
            List<T> list_l = new List<T>(dim2);
            for(int j = 0; j < dim2; j++)
                list_l.Add(new T());
            list.Add(list_l);
        }
        return list;
    }
    public int SearchIsland(int[][] grid, int startX, int startY, List<List<bool>> opened)
    {
        Queue<int[]> open = new Queue<int[]>();
        open.Enqueue(new int[]{startX, startY});
        opened[startY][startX] = true;
        int area = 0;
        while(open.Count>0)
        {
            int[] pt = open.Dequeue();
            area++;
            foreach(var p in Neighbor(pt[0], pt[1], grid.Length, grid[0].Length))
            {
                if(grid[p[1]][p[0]] == 1 && !opened[p[1]][p[0]])
                {
                    open.Enqueue(p);
                    opened[p[1]][p[0]] = true;
                }
            }
        }

        return area;
    }
    public int MaxAreaOfIsland(int[][] grid) {
        List<int> areas = new List<int>();
        List<List<bool>> searched = Create2DList<bool>(grid.Length, grid[0].Length);
        for(int i = 0; i < grid.Length; i++)
            for(int j = 0; j < grid[i].Length; j++)
            {
                if(grid[i][j]==1 && !searched[i][j])
                    areas.Add(SearchIsland(grid, j, i, searched));
            }
    
        if(areas.Count==0)
            return 0;
        else
            return areas.Max();
    }
}
// @lc code=end

