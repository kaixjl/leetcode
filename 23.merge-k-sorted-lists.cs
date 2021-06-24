/*
 * @lc app=leetcode id=23 lang=csharp
 *
 * [23] Merge k Sorted Lists
 *
 * https://leetcode.com/problems/merge-k-sorted-lists/description/
 *
 * algorithms
 * Hard (43.71%)
 * Likes:    7611
 * Dislikes: 364
 * Total Accepted:    912.4K
 * Total Submissions: 2.1M
 * Testcase Example:  '[[1,4,5],[1,3,4],[2,6]]'
 *
 * You are given an array of k linked-lists lists, each linked-list is sorted
 * in ascending order.
 * 
 * Merge all the linked-lists into one sorted linked-list and return it.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: lists = [[1,4,5],[1,3,4],[2,6]]
 * Output: [1,1,2,3,4,4,5,6]
 * Explanation: The linked-lists are:
 * [
 * ⁠ 1->4->5,
 * ⁠ 1->3->4,
 * ⁠ 2->6
 * ]
 * merging them into one sorted list:
 * 1->1->2->3->4->4->5->6
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: lists = []
 * Output: []
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: lists = [[]]
 * Output: []
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * k == lists.length
 * 0 <= k <= 10^4
 * 0 <= lists[i].length <= 500
 * -10^4 <= lists[i][j] <= 10^4
 * lists[i] is sorted in ascending order.
 * The sum of lists[i].length won't exceed 10^4.
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP23 {

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class ListNodeHelper {
    public static ListNode ConstructList(IEnumerable<int> vals) {
        ListNode head = new ListNode();
        ListNode curr = head;
        foreach(var val in vals) {
            curr.next = new ListNode(val);
            curr = curr.next;
        }
        return head.next;
    }

    public static List<int> ListNode2List(ListNode head) {
        List<int> list = new List<int>();
        while(head != null) {
            list.Add(head.val);
            head = head.next;
        }
        return list;
    }
}

public class PriorityQueueHelper {
    static void PrintPriorityQueue<K, V>(PriorityQueue<K, V> priorityQueue) where K: IComparable<K> {
        StringBuilder sb = new StringBuilder();
        int ptr = 0;
        for(int p = 1; p < priorityQueue.Count; p *= 2) {
            for(int i = 0; i < p; i++) {
                sb.AppendFormat("{0} ", priorityQueue.list[ptr++].value);
                if(ptr >= priorityQueue.Count) break;
            }
            sb.AppendLine();
        }
        Console.Write(sb.ToString());
    }
}

// @lc code=start
public class PriorityQueueEntity<TKey, TValue> {
    public TKey key;
    public TValue value;

    public PriorityQueueEntity(TKey key, TValue value) {
        this.key = key;
        this.value = value;
    }
}

public class PriorityQueue<TKey, TValue> {
    internal List<PriorityQueueEntity<TKey, TValue>> list;
    bool ascent = false;
    private readonly IComparer<TKey> comparer;
    public PriorityQueue(IComparer<TKey> comparer, bool ascent = false) {
        list = new List<PriorityQueueEntity<TKey, TValue>>();
        this.ascent = ascent;
        this.comparer = comparer;
    }

    public PriorityQueue(bool ascent = false): this(Comparer<TKey>.Default, ascent) { }

    public PriorityQueue(int capacity, IComparer<TKey> comparer, bool ascent = false) {
        list = new List<PriorityQueueEntity<TKey, TValue>>(capacity);
        this.ascent = ascent;
        this.comparer = comparer;
    }

    public PriorityQueue(int capacity, bool ascent = false): this(capacity, Comparer<TKey>.Default, ascent) { }

    static void ConstructPriorityQueueWithExistingList(List<PriorityQueueEntity<TKey, TValue>> list, IComparer<TKey> comparer, bool ascent = false) {
        for(int i = list.Count / 2 - 1; i >= 0; i--)
            FilterDown(list, i, comparer, ascent);
    }

    static void FilterDown(List<PriorityQueueEntity<TKey, TValue>> list, int index, IComparer<TKey> comparer, bool ascent = false) {
        int idx_lc = index * 2 + 1;
        int idx_rc = index * 2 + 2;
        if (idx_lc >= list.Count) return;
        else if (idx_rc >= list.Count) {
            if ((ascent ? -1 : 1) * comparer.Compare(list[idx_lc].key, list[index].key) > 0) {
                var tmp = list[idx_lc];
                list[idx_lc] = list[index];
                list[index] = tmp;
            }
        }
        else if((ascent ? -1 : 1) * comparer.Compare(list[idx_lc].key, list[idx_rc].key) > 0) {
            if((ascent ? -1 : 1) * comparer.Compare(list[idx_lc].key, list[index].key) > 0) {
                var tmp = list[idx_lc];
                list[idx_lc] = list[index];
                list[index] = tmp;
                FilterDown(list, idx_lc, comparer, ascent);
            }
        }
        else if((ascent ? -1 : 1) * comparer.Compare(list[idx_rc].key, list[index].key) > 0) {
            var tmp = list[idx_rc];
            list[idx_rc] = list[index];
            list[index] = tmp;
            FilterDown(list, idx_rc, comparer, ascent);
        }
    }

    static void FilterUp(List<PriorityQueueEntity<TKey, TValue>> list, int index, IComparer<TKey> comparer, bool ascent = false) {
        int idx_p = (index + 1) / 2 - 1;
        if(idx_p >= 0 && (ascent ? -1 : 1) * comparer.Compare(list[index].key, list[idx_p].key) > 0) {
            var tmp = list[idx_p];
            list[idx_p] = list[index];
            list[index] = tmp;
            FilterUp(list, idx_p, comparer, ascent);
        }
    }
    public void Offer(PriorityQueueEntity<TKey, TValue> entity) {
        list.Add(entity);
        FilterUp(list, list.Count - 1, this.comparer, this.ascent);
    }

    public void Offer(TKey key, TValue val) {
        this.Offer(new PriorityQueueEntity<TKey, TValue>(key, val));
    }

    public TValue Peek() {
        return this.PeekEntity().value;
    }

    public PriorityQueueEntity<TKey, TValue> PeekEntity() {
        return list[0];
    }

    public TValue Poll() {
        return this.PollEntity().value;
    }

    public PriorityQueueEntity<TKey, TValue> PollEntity() {
        var top = list[0];
        list[0] = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        FilterDown(list, 0, this.comparer, this.ascent);
        return top;
    }

    public int Count => list.Count;
}
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class ListNodeComp : IComparer<ListNode>
{
    // Compares by Height, Length, and Width.
    public int Compare(ListNode x, ListNode y)
    {
        // if(x == null && y == null) {
        //     return 0;
        // }
        // else if(x != null && y != null) {
            return x.val.CompareTo(y.val);
        // }
        // else if(x != null) {
        //     return 1;
        // }
        // else {
        //     return -1;
        // }
    }
}

public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode head = new ListNode();
        ListNode ptr = head;
        PriorityQueue<ListNode, ListNode> pq = new PriorityQueue<ListNode, ListNode>(new ListNodeComp(), true);
        foreach(var l in lists) {
            if(l != null) {
                pq.Offer(l, l);
            }
        }
        while(pq.Count > 0) {
            var curr = pq.Poll();
            var next = curr.next;
            curr.next = null;
            ptr.next = curr;
            ptr = ptr.next;
            if(next != null) {
                pq.Offer(next, next);
            }
        }

        return head.next;
    }
}
// @lc code=end
}
