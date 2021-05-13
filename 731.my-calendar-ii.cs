/*
 * @lc app=leetcode id=731 lang=csharp
 *
 * [731] My Calendar II
 *
 * https://leetcode.com/problems/my-calendar-ii/description/
 *
 * algorithms
 * Medium (49.78%)
 * Likes:    684
 * Dislikes: 92
 * Total Accepted:    46.7K
 * Total Submissions: 93.8K
 * Testcase Example:  '["MyCalendarTwo","book","book","book","book","book","book"]\n' +
  '[[],[10,20],[50,60],[10,40],[5,15],[5,10],[25,55]]'
 *
 * Implement a MyCalendarTwo class to store your events. A new event can be
 * added if adding the event will not cause a triple booking.
 * 
 * Your class will have one method, book(int start, int end). Formally, this
 * represents a booking on the half open interval [start, end), the range of
 * real numbers x such that start <= x < end.
 * 
 * A triple booking happens when three events have some non-empty intersection
 * (ie., there is some time that is common to all 3 events.)
 * 
 * For each call to the method MyCalendar.book, return true if the event can be
 * added to the calendar successfully without causing a triple booking.
 * Otherwise, return false and do not add the event to the calendar.
 * Your class will be called like this: MyCalendar cal = new MyCalendar();
 * MyCalendar.book(start, end)
 * 
 * Example 1:
 * 
 * 
 * MyCalendar();
 * MyCalendar.book(10, 20); // returns true
 * MyCalendar.book(50, 60); // returns true
 * MyCalendar.book(10, 40); // returns true
 * MyCalendar.book(5, 15); // returns false
 * MyCalendar.book(5, 10); // returns true
 * MyCalendar.book(25, 55); // returns true
 * Explanation: 
 * The first two events can be booked.  The third event can be double booked.
 * The fourth event (5, 15) can't be booked, because it would result in a
 * triple booking.
 * The fifth event (5, 10) can be booked, as it does not use time 10 which is
 * already double booked.
 * The sixth event (25, 55) can be booked, as the time in [25, 40) will be
 * double booked with the third event;
 * the time [40, 50) will be single booked, and the time [50, 55) will be
 * double booked with the second event.
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
 */
using System;
using System.Collections.Generic;

namespace LP731 {
// @lc code=start
public class MyCalendarTwo {
    List<int> endpoints, books;
    private void Split(int endpoint) {
        int idx = endpoints.BinarySearch(endpoint);
        if(idx < 0) {
            idx = ~idx;
            endpoints.Insert(idx, endpoint);
            books.Insert(idx, books[idx - 1]);
        }
    }
    public MyCalendarTwo() {
        endpoints = new List<int>();
        books = new List<int>();
        endpoints.Add(0);
        books.Add(0);
    }
    
    public bool Book(int start, int end) {
        int idx_start = endpoints.BinarySearch(start);
        int idx_end = endpoints.BinarySearch(end);

        if(idx_start < 0) idx_start = ~idx_start - 1;
        if(idx_end < 0) idx_end = ~idx_end;

        for(int i = idx_start; i < idx_end; i++) {
            if(books[i] >=2) return false;
        }

        if(endpoints[idx_start] != start) {
            idx_start++;
            idx_end++;
            endpoints.Insert(idx_start, start);
            books.Insert(idx_start, books[idx_start - 1]);
        }
        if(idx_end >= endpoints.Count || endpoints[idx_end] != end) {
            endpoints.Insert(idx_end, end);
            books.Insert(idx_end, books[idx_end - 1]);
        }

        for(int i = idx_start; i < idx_end; i++)
            books[i]++;
            
        return true;
    }
}

/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */
// @lc code=end
}

// Approach 1 BF in Java
// public class MyCalendarTwo {
//     List<int[]> calendar;
//     List<int[]> overlaps;

//     MyCalendarTwo() {
//         calendar = new ArrayList();
//     }

//     public boolean book(int start, int end) {
//         for (int[] iv: overlaps) {
//             if (iv[0] < end && start < iv[1]) return false;
//         }
//         for (int[] iv: calendar) {
//             if (iv[0] < end && start < iv[1])
//                 overlaps.add(new int[]{Math.max(start, iv[0]), Math.min(end, iv[1])});
//         }
//         calendar.add(new int[]{start, end});
//         return true;
//     }
// }
//
// Approach 2 in Java
// class MyCalendarTwo {
//     TreeMap<Integer, Integer> delta;

//     public MyCalendarTwo() {
//         delta = new TreeMap();
//     }

//     public boolean book(int start, int end) {
//         delta.put(start, delta.getOrDefault(start, 0) + 1);
//         delta.put(end, delta.getOrDefault(end, 0) - 1);

//         int active = 0;
//         for (int d: delta.values()) {
//             active += d;
//             if (active >= 3) {
//                 delta.put(start, delta.get(start) - 1);
//                 delta.put(end, delta.get(end) + 1);
//                 if (delta.get(start) == 0)
//                     delta.remove(start);
//                 return false;
//             }
//         }
//         return true;
//     }
// }
