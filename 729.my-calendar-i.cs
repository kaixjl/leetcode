/*
 * @lc app=leetcode id=729 lang=csharp
 *
 * [729] My Calendar I
 *
 * https://leetcode.com/problems/my-calendar-i/description/
 *
 * algorithms
 * Medium (52.72%)
 * Likes:    1086
 * Dislikes: 45
 * Total Accepted:    90.7K
 * Total Submissions: 168.8K
 * Testcase Example:  '["MyCalendar","book","book","book"]\n[[],[10,20],[15,25],[20,30]]'
 *
 * Implement a MyCalendar class to store your events. A new event can be added
 * if adding the event will not cause a double booking.
 * 
 * Your class will have the method, book(int start, int end). Formally, this
 * represents a booking on the half open interval [start, end), the range of
 * real numbers x such that start <= x < end.
 * 
 * A double booking happens when two events have some non-empty intersection
 * (ie., there is some time that is common to both events.)
 * 
 * For each call to the method MyCalendar.book, return true if the event can be
 * added to the calendar successfully without causing a double booking.
 * Otherwise, return false and do not add the event to the calendar.
 * Your class will be called like this: MyCalendar cal = new MyCalendar();
 * MyCalendar.book(start, end)
 * 
 * Example 1:
 * 
 * 
 * MyCalendar();
 * MyCalendar.book(10, 20); // returns true
 * MyCalendar.book(15, 25); // returns false
 * MyCalendar.book(20, 30); // returns true
 * Explanation: 
 * The first event can be booked.  The second can't because time 15 is already
 * booked by another event.
 * The third event can be booked, as the first event takes every time less than
 * 20, but not including 20.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * The number of calls to MyCalendar.book per test case will be at most
 * 1000.
 * In calls to MyCalendar.book(start, end), start and end are integers in the
 * range [0, 10^9].
 * 
 * 
 * 
 * 
 */
using System;
using System.Collections.Generic;

namespace LP729 {
// @lc code=start
public class MyCalendar {

    List<int[]> list = new List<int[]>();

    public MyCalendar() {
        
    }
    
    public bool Book(int start, int end) {
        var pt = new int[]{start, end};
        if(list.Count == 0) {
            list.Add(pt);
            return true;
        } else {
            int idx = list.BinarySearch(pt, new Array2Comparer());
            if(idx >= 0) {
                return false;
            } else { // idx < 0
                idx = ~idx;
                int idx_l = idx - 1;
                int idx_r = idx;
                if(idx_l >= 0) {
                    var pt_l = list[idx_l];
                    if(pt_l[1] > pt[0]) return false;
                }
                if(idx_r < list.Count) {
                    var pt_r = list[idx_r];
                    if(pt_r[0] < pt[1]) return false;
                }
                list.Insert(idx, pt);
                return true;
            }

        }
    }
}
public class Array2Comparer : Comparer<int[]>
{
    public override int Compare(int[] x, int[] y)
    {
        return x[0].CompareTo(y[0]);
    }
}
/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */
// @lc code=end
}
