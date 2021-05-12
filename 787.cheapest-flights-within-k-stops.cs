/*
 * @lc app=leetcode id=787 lang=csharp
 *
 * [787] Cheapest Flights Within K Stops
 *
 * https://leetcode.com/problems/cheapest-flights-within-k-stops/description/
 *
 * algorithms
 * Medium (39.39%)
 * Likes:    3003
 * Dislikes: 98
 * Total Accepted:    152.3K
 * Total Submissions: 384.8K
 * Testcase Example:  '3\n[[0,1,100],[1,2,100],[0,2,500]]\n0\n2\n1'
 *
 * There are n cities connected by some number of flights. You are given an
 * array flights where flights[i] = [fromi, toi, pricei] indicates that there
 * is a flight from city fromi to city toi with cost pricei.
 * 
 * You are also given three integers src, dst, and k, return the cheapest price
 * from src to dst with at most k stops. If there is no such route, return
 * -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k
 * = 1
 * Output: 200
 * Explanation: The graph is shown.
 * The cheapest price from city 0 to city 2 with at most 1 stop costs 200, as
 * marked red in the picture.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k
 * = 0
 * Output: 500
 * Explanation: The graph is shown.
 * The cheapest price from city 0 to city 2 with at most 0 stop costs 500, as
 * marked blue in the picture.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 100
 * 0 <= flights.length <= (n * (n - 1) / 2)
 * flights[i].length == 3
 * 0 <= fromi, toi < n
 * fromi != toi
 * 1 <= pricei <= 10^4
 * There will not be any multiple flights between two cities.
 * 0 <= src, dst, k < n
 * src != dst
 * 
 * 
 */
using System;
using System.Collections.Generic;
namespace LP787 {
// @lc code=start
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int[,] adjMat = new int[n,n];
        int[,] costs = new int[k + 2, n];
        Queue<int> queue =  new Queue<int>();

        foreach(var flight in flights) {
            adjMat[flight[0], flight[1]] = flight[2];
        }

        for(int i = 1; i < k + 2; i++) {
            for (int j = 0; j < n; j++) {
                costs[i, j] = int.MaxValue;
            }
        }

        queue.Enqueue(src);
        for(int step = 0; step <= k && queue.Count > 0; step++) {
            int cnt = queue.Count;
            for(int _ = 0; _ < cnt; _++) {
                int curr = queue.Dequeue();
                for(int to = 0; to < n; to++) {
                    if(adjMat[curr, to] != 0) {
                        int newCost = costs[step, curr] + adjMat[curr, to];
                        if(newCost < costs[step + 1, to]) {
                            costs[step + 1, to] = newCost;
                            if(to != dst) {
                                queue.Enqueue(to);
                            }
                        }
                    }
                }
            }
        }

        int minCost = int.MaxValue;
        for(int i = 1; i < k + 2; i++) {
            if(costs[i, dst] != 0) {
                minCost = Math.Min(minCost, costs[i, dst]);
            }
        }

        return minCost == int.MaxValue ? -1 : minCost;
    }
}
// @lc code=end
}
