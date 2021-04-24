/*
 * @lc app=leetcode id=19 lang=csharp
 *
 * [19] Remove Nth Node From End of List
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

// namespace leetcode{

namespace LP19 {
public class ListNode: IEquatable<ListNode> {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }

    public ListNode(int[] vals) {
        if (vals == null || vals.Length==0)
            throw new Exception("arg vals in ListNode ctor could not be empty");
        this.val = vals[0];
        ListNode p = this;
        for (int i = 1; i < vals.Length; i++)
        {
            p.next = new ListNode(vals[i]);
            p = p.next;
        }
    }

    public static ListNode CreateListNode(int[] vals)
    {
        if (vals == null || vals.Length==0)
            throw new Exception("arg vals in ListNode ctor could not be empty");
        ListNode head = new ListNode();
        ListNode p = head;
        foreach(int val in vals)
        {
            p.next = new ListNode(val);
            p = p.next;
        }

        return head.next;
    }

    public List<int> ToList()
    {
        List<int> list = new List<int>();
        ListNode p = this;
        while(p!=null)
        {
            list.Add(p.val);
            p = p.next;
        }
        return list;
    }

    public bool Equals(ListNode other)
    {
        if (other == null)
            return false;

        ListNode listNode1 = this;
        ListNode listNode2 = other;
        while(listNode1!=null || listNode2!=null)
        {
            if(listNode1==null || listNode2 == null || listNode1.val != listNode2.val)
                return false;
            listNode1 = listNode1.next;
            listNode2 = listNode2.next;
        }
        
        return true;
    }

    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;

        ListNode listNodeObj = obj as ListNode;
        if (listNodeObj == null)
            return false;
        else
            return Equals(listNodeObj);
    }

    public override int GetHashCode()
    {

        return this.ToList().GetHashCode();
    }

    public static bool operator == (ListNode listNode1, ListNode listNode2)
    {
        if (((object)listNode1) == null || ((object)listNode2) == null)
            return Object.Equals(listNode1, listNode2);

        return listNode1.Equals(listNode2);
    }

    public static bool operator != (ListNode listNode1, ListNode listNode2)
    {
        if (((object)listNode1) == null || ((object)listNode2) == null)
            return ! Object.Equals(listNode1, listNode2);

        return ! (listNode1.Equals(listNode2));
    }

    public override String ToString()
    {
        var list = this.ToList();
        return "{" + String.Join(",", list.Select(x=>x.ToString())) + "}";
    }
}
// @lc code=start
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
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) { 
        ListNode f = new ListNode(0, head);
        ListNode l = f, r = head;
        
        for(int i = 0; i < n; i++)
            r = r.next;

        while(r != null)
        {
            l = l.next;
            r = r.next;
        }

        l.next = l.next.next;

        return f.next;       
    }
}
// @lc code=end
}

// }