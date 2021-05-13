/*
 * @lc app=leetcode id=1514 lang=csharp
 *
 * [1514] Path with Maximum Probability
 *
 * https://leetcode.com/problems/path-with-maximum-probability/description/
 *
 * algorithms
 * Medium (38.38%)
 * Likes:    592
 * Dislikes: 13
 * Total Accepted:    20.8K
 * Total Submissions: 50.3K
 * Testcase Example:  '3\n[[0,1],[1,2],[0,2]]\n[0.5,0.5,0.2]\n0\n2'
 *
 * You are given an undirected weighted graph of n nodes (0-indexed),
 * represented by an edge list where edges[i] = [a, b] is an undirected edge
 * connecting the nodes a and b with a probability of success of traversing
 * that edge succProb[i].
 * 
 * Given two nodes start and end, find the path with the maximum probability of
 * success to go from start to end and return its success probability.
 * 
 * If there is no path from start to end, return 0. Your answer will be
 * accepted if it differs from the correct answer by at most 1e-5.
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * 
 * Input: n = 3, edges = [[0,1],[1,2],[0,2]], succProb = [0.5,0.5,0.2], start =
 * 0, end = 2
 * Output: 0.25000
 * Explanation: There are two paths from start to end, one having a probability
 * of success = 0.2 and the other has 0.5 * 0.5 = 0.25.
 * 
 * 
 * Example 2:
 * 
 * 
 * 
 * 
 * Input: n = 3, edges = [[0,1],[1,2],[0,2]], succProb = [0.5,0.5,0.3], start =
 * 0, end = 2
 * Output: 0.30000
 * 
 * 
 * Example 3:
 * 
 * 
 * 
 * 
 * Input: n = 3, edges = [[0,1]], succProb = [0.5], start = 0, end = 2
 * Output: 0.00000
 * Explanation: There is no path between 0 and 2.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= n <= 10^4
 * 0 <= start, end < n
 * start != end
 * 0 <= a, b < n
 * a != b
 * 0 <= succProb.length == edges.length <= 2*10^4
 * 0 <= succProb[i] <= 1
 * There is at most one edge between every two nodes.
 * 
 */
using System;
using System.Collections.Generic;

namespace LP1514 {
// @lc code=start
public class Solution {
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end) {
        List<double>[] edgeList = new List<double>[n];
        List<int>[] adjList = new List<int>[n];
        for(int i = 0; i < n; i++) {
            edgeList[i] = new List<double>();
            adjList[i] = new List<int>();
        }
        for(int i = 0; i < edges.Length; i++) {
            adjList[edges[i][0]].Add(edges[i][1]);
            edgeList[edges[i][0]].Add(succProb[i]);
            adjList[edges[i][1]].Add(edges[i][0]);
            edgeList[edges[i][1]].Add(succProb[i]);
        }

        double[] probs = new double[n];
        probs[start] = 1;
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        int curr;
        while(queue.TryDequeue(out curr)) {
            if(curr==end) continue;
            for(int i = 0; i < adjList[curr].Count; i++) {
                double prob;
                if((prob = edgeList[curr][i] * probs[curr]) > probs[adjList[curr][i]]) {
                    queue.Enqueue(adjList[curr][i]);
                    probs[adjList[curr][i]] = prob;
                }
            }
        }
        return probs[end];
    }
}
// @lc code=end
}
