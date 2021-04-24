/*
 * @lc app=leetcode id=1140 lang=csharp
 *
 * [1140] Stone Game II
 *
 * https://leetcode.com/problems/stone-game-ii/description/
 *
 * algorithms
 * Medium (64.69%)
 * Likes:    765
 * Dislikes: 182
 * Total Accepted:    26.4K
 * Total Submissions: 40.9K
 * Testcase Example:  '[2,7,9,4,4]'
 *
 * Alice and Bob continue their games with piles of stones.  There are a number
 * of piles arranged in a row, and each pile has a positive integer number of
 * stones piles[i].  The objective of the game is to end with the most
 * stones. 
 * 
 * Alice and Bob take turns, with Alice starting first.  Initially, M = 1.
 * 
 * On each player's turn, that player can take all the stones in the first X
 * remaining piles, where 1 <= X <= 2M.  Then, we set M = max(M, X).
 * 
 * The game continues until all the stones have been taken.
 * 
 * Assuming Alice and Bob play optimally, return the maximum number of stones
 * Alice can get.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: piles = [2,7,9,4,4]
 * Output: 10
 * Explanation:  If Alice takes one pile at the beginning, Bob takes two piles,
 * then Alice takes 2 piles again. Alice can get 2 + 4 + 4 = 10 piles in total.
 * If Alice takes two piles at the beginning, then Bob can take all three piles
 * left. In this case, Alice get 2 + 7 = 9 piles in total. So we return 10
 * since it's larger. 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: piles = [1,2,3,4,5,100]
 * Output: 104
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= piles.length <= 100
 * 1 <= piles[i] <= 10^4
 * 
 * 
 */
 using System;
 using System.Collections.Generic;

// @lc code=start
public partial class Solution {
    /// <summary>
    /// StoneGamesII Helper Method.
    /// </summary>
    /// <param name="minStore"> An piles.Length*piles.Length array. </param>
    /// <param name="maxStore"> An piles.Length*piles.Length array. </param>
    public int StoneGameIIMax(int[] piles, int start, int M, int[,] minStore, int[,] maxStore)
    {
        if (start == piles.Length) return 0;
        if (maxStore[start, M-1] != 0) return maxStore[start, M-1];

        int max = 0;
        for(int X = 1; X <= M * 2 && start + X <= piles.Length; X++)
        {
            int l_max = 0;
            for(int j = 0; j < X; j++)
                l_max += piles[start + j];
             l_max += StoneGameIIMin(piles, start + X, Math.Max(X, M), minStore, maxStore);
             if (l_max > max) max = l_max;
        }
        maxStore[start, M-1] = max;
        return max;
    }

        /// <summary>
    /// StoneGamesII Helper Method.
    /// </summary>
    /// <param name="minStore"> An piles.Length*piles.Length array. </param>
    /// <param name="maxStore"> An piles.Length*piles.Length array. </param>
    public int StoneGameIIMin(int[] piles, int start, int M, int[,] minStore, int[,] maxStore)
    {
        if (start == piles.Length) return 0;
        if (minStore[start, M-1] != 0) return minStore[start, M-1];

        int min = int.MaxValue;
        for(int X = 1; X <= M * 2 && start + X <= piles.Length; X++)
        {
            int l_min = StoneGameIIMax(piles, start + X, Math.Max(X, M), minStore, maxStore);
             if (l_min < min) min = l_min;
        }
        minStore[start, M-1] = min;
        return min;
    }
    public int StoneGameII(int[] piles) {
        int [,] maxStore = new int[piles.Length, piles.Length];
        int [,] minStore = new int[piles.Length, piles.Length];
        int max = StoneGameIIMax(piles, 0, 1, minStore, maxStore);
        return max;
    }
}
// @lc code=end

