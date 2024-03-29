/*
 * @lc app=leetcode id=983 lang=csharp
 *
 * [983] Minimum Cost For Tickets
 *
 * https://leetcode.com/problems/minimum-cost-for-tickets/description/
 *
 * algorithms
 * Medium (62.78%)
 * Likes:    2670
 * Dislikes: 49
 * Total Accepted:    96K
 * Total Submissions: 152.9K
 * Testcase Example:  '[1,4,6,7,8,20]\n[2,7,15]'
 *
 * In a country popular for train travel, you have planned some train
 * travelling one year in advance.  The days of the year that you will travel
 * is given as an array days.  Each day is an integer from 1 to 365.
 * 
 * Train tickets are sold in 3 different ways:
 * 
 * 
 * a 1-day pass is sold for costs[0] dollars;
 * a 7-day pass is sold for costs[1] dollars;
 * a 30-day pass is sold for costs[2] dollars.
 * 
 * 
 * The passes allow that many days of consecutive travel.  For example, if we
 * get a 7-day pass on day 2, then we can travel for 7 days: day 2, 3, 4, 5, 6,
 * 7, and 8.
 * 
 * Return the minimum number of dollars you need to travel every day in the
 * given list of days.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: days = [1,4,6,7,8,20], costs = [2,7,15]
 * Output: 11
 * Explanation: 
 * For example, here is one way to buy passes that lets you travel your travel
 * plan:
 * On day 1, you bought a 1-day pass for costs[0] = $2, which covered day 1.
 * On day 3, you bought a 7-day pass for costs[1] = $7, which covered days 3,
 * 4, ..., 9.
 * On day 20, you bought a 1-day pass for costs[0] = $2, which covered day 20.
 * In total you spent $11 and covered all the days of your travel.
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: days = [1,2,3,4,5,6,7,8,9,10,30,31], costs = [2,7,15]
 * Output: 17
 * Explanation: 
 * For example, here is one way to buy passes that lets you travel your travel
 * plan:
 * On day 1, you bought a 30-day pass for costs[2] = $15 which covered days 1,
 * 2, ..., 30.
 * On day 31, you bought a 1-day pass for costs[0] = $2 which covered day 31.
 * In total you spent $17 and covered all the days of your travel.
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= days.length <= 365
 * 1 <= days[i] <= 365
 * days is in strictly increasing order.
 * costs.length == 3
 * 1 <= costs[i] <= 1000
 * 
 * 
 */

using System;

namespace LP983 {
// @lc code=start
public class Solution {
    private int MincostTicketsHelper(int[] days, int[] costs, int start, int[] memory)
    {
        if(memory[start] != int.MaxValue) return memory[start];

        if(days.Length - start == 0)
        {
            memory[start] = 0;
            return 0;
        }

        int firstDay = days[start];
        int minTicket1 = 0, minTicket7 = 0, minTicket30 = 0;
        int end = start + 1;
        
        for(; end < days.Length && days[end] - firstDay < 1; end++);
        minTicket1 = costs[0] + MincostTicketsHelper(days, costs, end, memory);
        
        for(; end < days.Length && days[end] - firstDay < 7; end++);
        minTicket7 = costs[1] + MincostTicketsHelper(days, costs, end, memory);
        
        for(; end < days.Length && days[end] - firstDay < 30; end++);
        minTicket30 = costs[2] + MincostTicketsHelper(days, costs, end, memory);

        memory[start] = Math.Min(minTicket1, Math.Min(minTicket7, minTicket30));
        return memory[start];
        
    }
    public int MincostTickets(int[] days, int[] costs) {
        int[] memory = new int[days.Length + 1];
        for (int i = 0; i < memory.Length; i++) memory[i] = int.MaxValue;
        return MincostTicketsHelper(days, costs, 0, memory);
    }
}
// @lc code=end
}

