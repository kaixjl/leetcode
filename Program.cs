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
            // P210(sln);
            // P695(sln);
            // P99(sln);
            // P65(sln);
            // P1632(sln);
            // P983(sln);
            // P1447(sln);
            P1140(sln);
        }

        static void AssertEquals<T>(IEquatable<T> val1, IEquatable<T> val2)
        {
            if(val1!=null && val2!=null && !val1.Equals(val2))
            {
                throw new Exception($"Equation Assertion Failed. val1 = {val1} but val2 = {val2}.");
            }
        }

        static void AssertEqualsEnumerable<T>(IEnumerable<T> val1, IEnumerable<T> val2)
        {
            if(val1!=null && val2!=null && !val1.SequenceEqual(val2))
            {
                throw new Exception($"Equation Assertion Failed. val1 = \"{val1}\" but val2 = \"{val2}\".");
            }
            if(val1==null && val2!=null && val2.Count()>0)
                throw new Exception($"val1==null, but val2.Count!=0");
            if(val2==null && val1!=null && val1.Count()>0)
                throw new Exception($"val1.Count>0, but val2==null.");
        }

        static void P1140(Solution sln)
        {
            AssertEquals(sln.StoneGameII(new int[]{2,7,9,4,4}), 10);
            AssertEquals(sln.StoneGameII(new int[]{1,2,3,4,5,100}), 104);
            AssertEquals(sln.StoneGameII(new int[]{6,4,2,8,1,8,6,6,2}), 24);
        }

        static void P1447(Solution sln)
        {
            List<T> IListToList<T>(IList<T> iList)
            {
                if(iList==null) return null;
                List<T> list = new List<T>();
                foreach(var i in iList)
                    list.Add(i);

                list.Sort();
                return list;
            }
            AssertEqualsEnumerable(IListToList(sln.SimplifiedFractions(2)), new string[]{"1/2"});
            AssertEqualsEnumerable(IListToList(sln.SimplifiedFractions(3)), new string[]{"1/2","1/3","2/3"});
            AssertEqualsEnumerable(IListToList(sln.SimplifiedFractions(4)), new string[]{"1/2","1/3","1/4","2/3","3/4"});
            AssertEqualsEnumerable(IListToList(sln.SimplifiedFractions(1)), null);
        }

        static void P983(Solution sln)
        {
            AssertEquals(sln.MincostTickets(new int[]{1,4,6,7,8,20}, new int[]{2,7,15}), 11);
            AssertEquals(sln.MincostTickets(new int[]{1,2,3,4,5,6,7,8,9,10,30,31}, new int[]{2,7,15}), 17);
            AssertEquals(sln.MincostTickets(new int[]{3,5,6,8,9,10,11,12,13,14,15,16,20,21,23,25,26,27,29,30,33,34,35,36,38,39,40,42,45,46,47,48,49,51,53,54,56,57,58,59,60,61,63,64,67,68,69,70,72,74,77,78,79,80,81,82,83,84,85,88,91,92,93,96}, new int[]{3,17,57}), 170);
        }

        static void P1632(Solution sln)
        {
            int[][] matrix, rank, result;
            matrix = new int[][]{new int []{1,2}, new int []{3,4}};
            rank = new int[][]{new int []{1,2}, new int []{2,3}};
            result = sln.MatrixRankTransform(matrix);
            foreach(var (row_m, row_r) in result.Zip(rank))
                AssertEqualsEnumerable(row_m, row_r);
            
            matrix = new int[][]{new int []{7,7}, new int []{7,7}};
            rank = new int[][]{new int []{1,1}, new int []{1,1}};
            result = sln.MatrixRankTransform(matrix);
            foreach(var (row_m, row_r) in result.Zip(rank))
                AssertEqualsEnumerable(row_m, row_r);
            
            matrix = new int[][]{new int []{20,-21,14}, new int []{-19,4,19}, new int []{22,-47,24}, new int []{-19,4,19}};
            rank = new int[][]{new int []{4,2,3}, new int []{1,3,4}, new int []{5,1,6}, new int []{1,3,4}};
            result = sln.MatrixRankTransform(matrix);
            foreach(var (row_m, row_r) in result.Zip(rank))
                AssertEqualsEnumerable(row_m, row_r);
            
            matrix = new int[][]{new int []{7,3,6}, new int []{1,4,5}, new int []{9,8,2}};
            rank = new int[][]{new int []{5,1,4}, new int []{1,2,3}, new int []{6,3,1}};
            result = sln.MatrixRankTransform(matrix);
            foreach(var (row_m, row_r) in result.Zip(rank))
                AssertEqualsEnumerable(row_m, row_r);
            
            matrix = new int [][]{new int []{-24,-9,-14,-15,44,31,-46,5,20,-5,34},
                                  new int []{9,-40,-49,-50,17,40,35,30,-39,36,-49},
                                  new int []{-18,-43,-40,-5,-30,9,-28,-41,-6,-47,12},
                                  new int []{11,42,-23,20,35,34,-39,-16,27,34,-15},
                                  new int []{32,27,-30,29,-48,15,-50,-47,-28,-21,38},
                                  new int []{45,48,-1,-18,9,-4,-13,10,9,8,-41},
                                  new int []{-42,-35,20,-17,10,5,36,47,6,1,8},
                                  new int []{3,-50,-23,16,31,2,-39,36,-25,-30,37},
                                  new int []{-48,-41,18,-31,-48,-1,-42,-3,-8,-29,-2},
                                  new int []{17,0,31,-30,-43,-20,-37,-6,-43,8,19},
                                  new int []{42,25,32,27,-2,45,12,-9,34,17,32}};
            rank = new int [][]{new int []{4,11,10,9,25,21,2,14,20,12,24},
                                new int []{18,5,2,1,21,25,23,22,6,24,2},
                                new int []{8,2,5,11,6,18,7,4,10,1,20},
                                new int []{19,24,9,20,23,22,4,10,21,22,11},
                                new int []{23,20,6,22,2,19,1,3,7,8,26},
                                new int []{26,27,11,7,19,9,8,20,19,14,3},
                                new int []{3,6,21,8,20,17,24,25,18,13,19},
                                new int []{17,1,9,18,22,16,4,23,8,5,25},
                                new int []{2,4,16,5,2,15,3,13,9,6,14},
                                new int []{20,13,22,6,3,7,5,12,3,14,21},
                                new int []{25,16,23,21,12,26,13,11,24,15,23}};
            result = sln.MatrixRankTransform(matrix);
            foreach(var (row_m, row_r) in result.Zip(rank))
                AssertEqualsEnumerable(row_m, row_r);

            //
        }

        static void P65(Solution sln)
        {
            string[] validNumberString = new string[]{
                "2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", 
                "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789",
                "0", ".1"};
            string[] invalidNumberString = new string[]{
                "abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53",
                "e", "."};
            
            foreach(var str in validNumberString)
                AssertEquals(sln.IsNumber(str), true);

            foreach(var str in invalidNumberString)
                AssertEquals(sln.IsNumber(str), false);    
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
