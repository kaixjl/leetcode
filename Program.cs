using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution sln = new Solution();
            // P7(sln);
            // P4_BinarySearchTest(sln);
            // P4(sln);
            // P5(sln);
            // P6(sln);
            // P1328(sln);
            // P19(sln);
            P210(sln);
            // P695(sln);
            // P99(sln);
        }

        static void AssertEquals<T>(IEquatable<T> val1, IEquatable<T> val2)
        {
            if(val1!=null && val2!=null && !val1.Equals(val2))
            {
                throw new Exception($"Equation Assertion Failed. val1 = \"{val1}\" but val2 = \"{val2}\".");
            }
        }

        static void AssertEqualsEnumerable<T>(IEnumerable<T> val1, IEnumerable<T> val2)
        {
            if(val1!=null && val2!=null && !val1.SequenceEqual(val2))
            {
                throw new Exception($"Equation Assertion Failed. val1 = \"{val1}\" but val2 = \"{val2}\".");
            }
        }

        static void P99(Solution sln)
        {
            int?[] seq_gt = new int?[]{1,3,null,null,2};
            TreeNode root = sln.CreateBST(seq_gt);
            int?[] seq = sln.BSTToNullableInt(root);
            AssertEqualsEnumerable(seq, seq_gt);

            seq_gt = new int?[]{1,3,null,null,2};
            root = sln.CreateBST(seq_gt);
            sln.RecoverTree(root);
            seq = sln.BSTToNullableInt(root);
            AssertEqualsEnumerable(seq, new int?[]{3,1,null,null,2});

            seq_gt = new int?[]{3,1,4,null,null,2};
            root = sln.CreateBST(seq_gt);
            sln.RecoverTree(root);
            seq = sln.BSTToNullableInt(root);
            AssertEqualsEnumerable(seq, new int?[]{2,1,4,null,null,3});

            seq_gt = new int?[]{2,3,1};
            root = sln.CreateBST(seq_gt);
            sln.RecoverTree(root);
            seq = sln.BSTToNullableInt(root);
            AssertEqualsEnumerable(seq, new int?[]{2,1,3});
        }

        static void P695(Solution sln)
        {
            int[][] grid = new int[][]{
                            new int[]{0,0,1,0,0,0,0,1,0,0,0,0,0},
                            new int[]{0,0,0,0,0,0,0,1,1,1,0,0,0},
                            new int[]{0,1,1,0,1,0,0,0,0,0,0,0,0},
                            new int[]{0,1,0,0,1,1,0,0,1,0,1,0,0},
                            new int[]{0,1,0,0,1,1,0,0,1,1,1,0,0},
                            new int[]{0,0,0,0,0,0,0,0,0,0,1,0,0},
                            new int[]{0,0,0,0,0,0,0,1,1,1,0,0,0},
                            new int[]{0,0,0,0,0,0,0,1,1,0,0,0,0}};
            AssertEquals(sln.MaxAreaOfIsland(grid), 6);
            grid = new int[][]{
                            new int[]{0,0,0,0,0,0,0,0}};
            AssertEquals(sln.MaxAreaOfIsland(grid), 0);
        }

        static void P210(Solution sln)
        {
            /*
             * 0-1-2
             *  \ \
             *   3-4
             *  /
             * 5
             */
            int[][] pre = new int[][]{
                            new int[]{0, 1}, new int[]{0, 3}, new int[]{1, 2}, 
                            new int[]{1, 4}, new int[]{3, 4}, new int[]{5, 3}};
            Debug.Assert(sln.CheckP210(new int[]{2, 4, 1, 3, 0, 5}, pre));
            int[] seq = sln.FindOrder(6, pre);
            Debug.Assert(sln.CheckP210(seq, pre));

            
            pre = new int[][]{
                            new int[]{1, 0}, new int[]{2, 0},  
                            new int[]{3, 1}, new int[]{3, 2}};
            seq = sln.FindOrder(4, pre);
            Debug.Assert(sln.CheckP210(seq, pre));

            
            pre = new int[0][];
            seq = sln.FindOrder(1, pre);
            Debug.Assert(sln.CheckP210(seq, pre));
        }

        static void P19(Solution sln)
        {
            AssertEquals(sln.RemoveNthFromEnd(new ListNode(new int[]{1,2}), 1), ListNode.CreateListNode(new int[]{1}));
            AssertEquals(sln.RemoveNthFromEnd(new ListNode(new int[]{1}), 1), null);
            AssertEquals(sln.RemoveNthFromEnd(new ListNode(new int[]{1,2}), 2), ListNode.CreateListNode(new int[]{2}));
            AssertEquals(sln.RemoveNthFromEnd(new ListNode(new int[]{1,2,3}), 2), ListNode.CreateListNode(new int[]{1,3}));
        }

        static void P1328(Solution sln)
        {
            AssertEquals(sln.isPalindrome(""), false);
            AssertEquals(sln.isPalindrome("a"), true);
            AssertEquals(sln.isPalindrome("aa"), true);
            AssertEquals(sln.isPalindrome("ab"), false);
            AssertEquals(sln.isPalindrome("aba"), true);
            AssertEquals(sln.isPalindrome("abaa"), false);
            AssertEquals(sln.isPalindrome("abba"), true);
            AssertEquals(sln.replaceChar("abcdefg", 0, 'z'), "zbcdefg");
            AssertEquals(sln.replaceChar("abcdefg", 1, 'z'), "azcdefg");
            AssertEquals(sln.replaceChar("abcdefg", 5, 'z'), "abcdezg");
            AssertEquals(sln.replaceChar("abcdefg", 6, 'z'), "abcdefz");
            AssertEquals(sln.BreakPalindrome("abccba"), "aaccba");
            AssertEquals(sln.BreakPalindrome("a"), "");
            AssertEquals(sln.BreakPalindrome("aa"), "ab");
            AssertEquals(sln.BreakPalindrome("aba"), "abb");
        }

        static void P7(Solution sln)
        {
            AssertEquals(sln.Reverse(1234), 4321);
            AssertEquals(sln.Reverse(-1234), -4321);
            AssertEquals(sln.Reverse(120), 21);
            AssertEquals(sln.Reverse(0), 0);
            AssertEquals(sln.Reverse(1534236469), 0);
            AssertEquals(sln.Reverse(-1534236469), 0);
        }

        static void P4(Solution sln)
        {
            AssertEquals(sln.FindMedianSortedArrays(new[]{1,3}, new[]{2}), 2.0);
            AssertEquals(sln.FindMedianSortedArrays(new[]{1,2}, new[]{3,4}), 5.0 / 2);
            AssertEquals(sln.FindMedianSortedArrays(new[]{0,0}, new[]{0,0}), 0.0);
            AssertEquals(sln.FindMedianSortedArrays(new int[]{}, new[]{1}), 1.0);
            AssertEquals(sln.FindMedianSortedArrays(new[]{2}, new int[]{}), 2.0);
            AssertEquals(sln.FindMedianSortedArrays(new[]{2}, new int[]{1,3,4}), 2.5);
        }

        static void P4_BinarySearchTest(Solution sln)
        {
            AssertEquals(sln.BinarySearch(new[]{0,0,1,2,3,4,4,5,6,7,8,9,10,10,10}, 0, 15, 0), 0);
            AssertEquals(sln.BinarySearch(new[]{0,0,1,2,3,4,4,5,6,7,8,9,10,10,10}, 0, 15, 1), 2);
            AssertEquals(sln.BinarySearch(new[]{0,0,1,2,3,4,4,5,6,7,8,9,10,10,10}, 0, 15, 2), 3);
            AssertEquals(sln.BinarySearch(new[]{0,0,1,2,3,4,4,5,6,7,8,9,10,10,10}, 0, 15, 4), 5);
            AssertEquals(sln.BinarySearch(new[]{0,0,1,2,3,4,4,5,6,7,8,9,10,10,10}, 0, 15, 10), 12);
            AssertEquals(sln.BinarySearch(new[]{0,0,1,2,3,4,4,5,6,7,8,9,10,10,10}, 2, 12, 0), 2);
            AssertEquals(sln.BinarySearch(new[]{0,0,1,2,3,4,4,5,6,7,8,9,10,10,10}, 2, 12, -1), 2);
            AssertEquals(sln.BinarySearch(new[]{0,0,1,2,3,4,4,5,6,7,8,9,10,10,10}, 2, 12, 10), 12);
            AssertEquals(sln.BinarySearch(new[]{0,0,1,2,3,4,4,5,6,7,8,9,10,10,10}, 2, 12, 15), 12);
        }

        static void P5(Solution sln)
        {
            AssertEquals(sln.LongestPalindrome("babad"), "bab");
            AssertEquals(sln.LongestPalindrome("cbbd"), "bb");
            AssertEquals(sln.LongestPalindrome("a"), "a");
            AssertEquals(sln.LongestPalindrome("ac"), "a");
            AssertEquals(sln.LongestPalindrome("aa"), "aa");
            AssertEquals(sln.LongestPalindrome("aaa"), "aaa");
            AssertEquals(sln.LongestPalindrome("aaaa"), "aaaa");
            AssertEquals(sln.LongestPalindrome("aaaaa"), "aaaaa");
            AssertEquals(sln.LongestPalindrome("aaaaaa"), "aaaaaa");
            AssertEquals(sln.LongestPalindrome("aaaaaaa"), "aaaaaaa");
            AssertEquals(sln.LongestPalindrome(""), "");
            AssertEquals(sln.LongestPalindrome("babaddtattarrattatddetartrateedredividerb"), "ddtattarrattatdd");
            AssertEquals(sln.LongestPalindrome("civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth"), "ranynar");
        }

        static void P6(Solution sln)
        {
            AssertEquals(sln.Convert("PAYPALISHIRING", 3), "PAHNAPLSIIGYIR");
            AssertEquals(sln.Convert("PAYPALISHIRING", 4), "PINALSIGYAHRPI");
            AssertEquals(sln.Convert("A", 1), "A");
        }
    }
}
