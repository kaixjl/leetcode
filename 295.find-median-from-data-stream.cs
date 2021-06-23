/*
 * @lc app=leetcode id=295 lang=csharp
 *
 * [295] Find Median from Data Stream
 *
 * https://leetcode.com/problems/find-median-from-data-stream/description/
 *
 * algorithms
 * Hard (45.71%)
 * Likes:    4297
 * Dislikes: 81
 * Total Accepted:    307.7K
 * Total Submissions: 640.8K
 * Testcase Example:  '["MedianFinder","addNum","addNum","findMedian","addNum","findMedian"]\n' +
  '[[],[1],[2],[],[3],[]]'
 *
 * The median is the middle value in an ordered integer list. If the size of
 * the list is even, there is no middle value and the median is the mean of the
 * two middle values.
 * 
 * 
 * For example, for arr = [2,3,4], the median is 3.
 * For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.
 * 
 * 
 * Implement the MedianFinder class:
 * 
 * 
 * MedianFinder() initializes the MedianFinder object.
 * void addNum(int num) adds the integer num from the data stream to the data
 * structure.
 * double findMedian() returns the median of all elements so far. Answers
 * within 10^-5 of the actual answer will be accepted.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input
 * ["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
 * [[], [1], [2], [], [3], []]
 * Output
 * [null, null, null, 1.5, null, 2.0]
 * 
 * Explanation
 * MedianFinder medianFinder = new MedianFinder();
 * medianFinder.addNum(1);    // arr = [1]
 * medianFinder.addNum(2);    // arr = [1, 2]
 * medianFinder.findMedian(); // return 1.5 (i.e., (1 + 2) / 2)
 * medianFinder.addNum(3);    // arr[1, 2, 3]
 * medianFinder.findMedian(); // return 2.0
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * -10^5 <= num <= 10^5
 * There will be at least one element in the data structure before calling
 * findMedian.
 * At most 5 * 10^4 calls will be made to addNum and findMedian.
 * 
 * 
 * 
 * Follow up:
 * 
 * 
 * If all integer numbers from the stream are in the range [0, 100], how would
 * you optimize your solution?
 * If 99% of all integer numbers from the stream are in the range [0, 100], how
 * would you optimize your solution?
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace LP295 {
public class PriorityQueueHelper {
    static void PrintPriorityQueue<T>(PriorityQueue<T> priorityQueue) where T: IComparable<T> {
        StringBuilder sb = new StringBuilder();
        int ptr = 0;
        for(int p = 1; p < priorityQueue.Count; p *= 2) {
            for(int i = 0; i < p; i++) {
                sb.AppendFormat("{0} ", priorityQueue.list[ptr++]);
                if(ptr >= priorityQueue.Count) break;
            }
            sb.AppendLine();
        }
        Console.Write(sb.ToString());
    }
}
// @lc code=start
public class PriorityQueue<T> where T: IComparable<T> {
    internal List<T> list;
    bool ascent = false;
    public PriorityQueue(bool ascent = false) {
        list = new List<T>();
        this.ascent = ascent;
    }

    public PriorityQueue(int capacity, bool ascent = false) {
        list = new List<T>(capacity);
        this.ascent = ascent;
    }

    public PriorityQueue(IEnumerable<T> collection, bool ascent = false) {
        list = new List<T>(collection);
        this.ascent = ascent;
        ConstructPriorityQueueWithExistingList(list, this.ascent);
    }

    static void ConstructPriorityQueueWithExistingList(List<T> list, bool ascent = false) {
        for(int i = list.Count / 2 - 1; i >= 0; i--)
            FilterDown(list, i, ascent);
    }

    static void FilterDown(List<T> list, int index, bool ascent = false) {
        int idx_lc = index * 2 + 1;
        int idx_rc = index * 2 + 2;
        if (idx_lc >= list.Count) return;
        else if (idx_rc >= list.Count) {
            if ((ascent ? -1 : 1) * list[idx_lc].CompareTo(list[index]) > 0) {
                T tmp = list[idx_lc];
                list[idx_lc] = list[index];
                list[index] = tmp;
            }
        }
        else if((ascent ? -1 : 1) * list[idx_lc].CompareTo(list[idx_rc]) > 0) {
            if((ascent ? -1 : 1) * list[idx_lc].CompareTo(list[index]) > 0) {
                T tmp = list[idx_lc];
                list[idx_lc] = list[index];
                list[index] = tmp;
                FilterDown(list, idx_lc, ascent);
            }
        }
        else if((ascent ? -1 : 1) * list[idx_rc].CompareTo(list[index]) > 0) {
            T tmp = list[idx_rc];
            list[idx_rc] = list[index];
            list[index] = tmp;
            FilterDown(list, idx_rc, ascent);
        }
    }

    static void FilterUp(List<T> list, int index, bool ascent = false) {
        int idx_p = (index + 1) / 2 - 1;
        if(idx_p >= 0 && (ascent ? -1 : 1) * list[index].CompareTo(list[idx_p]) > 0) {
            T tmp = list[idx_p];
            list[idx_p] = list[index];
            list[index] = tmp;
            FilterUp(list, idx_p, ascent);
        }
    }

    public void Offer(T val) {
        list.Add(val);
        FilterUp(list, list.Count - 1, this.ascent);
    }

    public T Peek() {
        return list[0];
    }

    public T Poll() {
        T top = list[0];
        list[0] = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        FilterDown(list, 0, this.ascent);
        return top;
    }

    public int Count => list.Count;
}

public class MedianFinder {
    PriorityQueue<int> pq_d = new PriorityQueue<int>();
    PriorityQueue<int> pq_a = new PriorityQueue<int>(true);
    /** initialize your data structure here. */
    public MedianFinder() {
        
    }
    
    public void AddNum(int num) {
        pq_d.Offer(num);
        if(pq_a.Count > 0 && pq_d.Peek() > pq_a.Peek()) {
            pq_a.Offer(pq_d.Poll());
        }
        while(pq_d.Count - pq_a.Count > 1) {
            pq_a.Offer(pq_d.Poll());
        }
        while(pq_d.Count - pq_a.Count < 0) {
            pq_d.Offer(pq_a.Poll());
        }
    }
    
    public double FindMedian() {
        if(pq_d.Count == pq_a.Count) {
            return (pq_d.Peek() + pq_a.Peek()) / 2.0;
        }
        else {
            return pq_d.Peek();
        }
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
// @lc code=end
}
