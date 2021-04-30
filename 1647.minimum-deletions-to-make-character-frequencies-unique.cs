/*
 * @lc app=leetcode id=1647 lang=csharp
 *
 * [1647] Minimum Deletions to Make Character Frequencies Unique
 *
 * https://leetcode.com/problems/minimum-deletions-to-make-character-frequencies-unique/description/
 *
 * algorithms
 * Medium (52.97%)
 * Likes:    402
 * Dislikes: 14
 * Total Accepted:    25.8K
 * Total Submissions: 46.4K
 * Testcase Example:  '"aab"'
 *
 * A string s is called good if there are no two different characters in s that
 * have the same frequency.
 * 
 * Given a string s, return the minimum number of characters you need to delete
 * to make s good.
 * 
 * The frequency of a character in a string is the number of times it appears
 * in the string. For example, in the string "aab", the frequency of 'a' is 2,
 * while the frequency of 'b' is 1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "aab"
 * Output: 0
 * Explanation: s is already good.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "aaabbbcc"
 * Output: 2
 * Explanation: You can delete two 'b's resulting in the good string "aaabcc".
 * Another way it to delete one 'b' and one 'c' resulting in the good string
 * "aaabbc".
 * 
 * Example 3:
 * 
 * 
 * Input: s = "ceabaacb"
 * Output: 2
 * Explanation: You can delete both 'c's resulting in the good string "eabaab".
 * Note that we only care about characters that are still in the string at the
 * end (i.e. frequency of 0 is ignored).
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 10^5
 * s contains only lowercase English letters.
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace LP1647{
// @lc code=start
public class Solution {
    public LinkedList<int> Count(string s)
    {
        int[] c = new int[26];
        foreach(var ch in s)
            c[ch-'a']++;
        var c_e = from i in c where i != 0 orderby i descending select i;
        LinkedList<int> linkedList = new LinkedList<int>();
        foreach (var i in c_e)
            linkedList.AddLast(i);

        return linkedList;
    }
    public int MinDeletions(string s) {
        int deletions = 0;
        LinkedListNode<int> curr, insertAfter;
        LinkedList<int> l = Count(s);
        curr = l.First;
        insertAfter = l.First;
        
        LinkedListNode<int> FindNext(int v, LinkedListNode<int> insertAfter)
        {
            while(insertAfter.Value > v || insertAfter.Next?.Value == insertAfter.Value - 1 || insertAfter.Next?.Value == insertAfter.Value)
                insertAfter = insertAfter.Next;
            return insertAfter;
        }

        while(curr!=null)
        {
            var next = curr.Next;
            if(curr.Value == curr.Next?.Value)
            {
                insertAfter = FindNext(curr.Value, insertAfter);
                l.Remove(curr);
                deletions += curr.Value - insertAfter.Value + 1;
                curr.Value = insertAfter.Value - 1;
                if(curr.Value!=0)
                {
                    l.AddAfter(insertAfter, curr);
                    insertAfter = insertAfter.Next;
                }
            }
            curr = next;
        }

        return deletions;
    }
}
// @lc code=end
}
