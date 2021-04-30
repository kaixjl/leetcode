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
            // P7();
            // P4_BinarySearchTest();
            // P4();
            // P5();
            // P6();
            // P1328();
            // P19();
            // P210();
            // P695();
            // P99();
            // P65();
            // P1632();
            // P983();
            // P1447();
            // P1140();
            // P1293();
            // P1358();
            // P324();
            // P84();
            P1647();
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

        static void P1647()
        {
            LP1647.Solution sln = new LP1647.Solution();
            AssertEquals(sln.MinDeletions("aab"), 0);
            AssertEquals(sln.MinDeletions("aaabbbcc"), 2);
            AssertEquals(sln.MinDeletions("ceabaacb"), 2);
        }

        static void P84()
        {
            LP84.Solution sln = new LP84.Solution();
            int[] heights;
            heights = new int[]{1,2,3,8,7,6,9,3};
            int[] leftEdges, rightEdges;
            (leftEdges, rightEdges) = sln.LeftRightEdges(heights);
            AssertEqualsEnumerable(leftEdges, new int[]{0,1,2,3,3,3,6,2});
            AssertEqualsEnumerable(rightEdges, new int[]{7,7,6,3,4,6,6,7});
            AssertEquals(sln.LargestRectangleArea(heights), 24);
            heights = new int[]{4,2,3,8,7,6,9,3,4};
            (leftEdges, rightEdges) = sln.LeftRightEdges(heights);
            AssertEqualsEnumerable(leftEdges, new int[]{0,0,2,3,3,3,6,2,8});
            AssertEqualsEnumerable(rightEdges, new int[]{0,8,6,3,4,6,6,8,8});
            AssertEquals(sln.LargestRectangleArea(heights), 24);
            heights = new int[]{1,2};
            (leftEdges, rightEdges) = sln.LeftRightEdges(heights);
            AssertEqualsEnumerable(leftEdges, new int[]{0,1});
            AssertEqualsEnumerable(rightEdges, new int[]{1,1});
            AssertEquals(sln.LargestRectangleArea(heights), 2);
            heights = new int[]{2,1};
            (leftEdges, rightEdges) = sln.LeftRightEdges(heights);
            AssertEqualsEnumerable(leftEdges, new int[]{0,0});
            AssertEqualsEnumerable(rightEdges, new int[]{0,1});
            AssertEquals(sln.LargestRectangleArea(heights), 2);
            heights = new int[]{2,1,5,6,2,3};
            AssertEquals(sln.LargestRectangleArea(heights), 10);
            heights = new int[]{2,4};
            AssertEquals(sln.LargestRectangleArea(heights), 4);
            heights = new int[]{2};
            (leftEdges, rightEdges) = sln.LeftRightEdges(heights);
            AssertEqualsEnumerable(leftEdges, new int[]{0});
            AssertEqualsEnumerable(rightEdges, new int[]{0});
            AssertEquals(sln.LargestRectangleArea(heights), 2);
        }

        static void P324()
        {
            LP324.Solution sln = new LP324.Solution();
            int[] nums;
            List<int> list1, list2;
            nums = new int[]{1};
            sln.QuickSelect(nums, 0, nums.Length, nums.Length / 2);
            Debug.Assert(LP324.SolutionHelper.QuickSelectValid(nums, nums.Length / 2));
            nums = new int[]{2,1};
            sln.QuickSelect(nums, 0, nums.Length, nums.Length / 2);
            Debug.Assert(LP324.SolutionHelper.QuickSelectValid(nums, nums.Length / 2));
            sln.QuickSelect(nums, 0, nums.Length, nums.Length / 2 - 1);
            Debug.Assert(LP324.SolutionHelper.QuickSelectValid(nums, nums.Length / 2 - 1));
            nums = new int[]{3,2,1};
            sln.QuickSelect(nums, 0, nums.Length, nums.Length / 2);
            Debug.Assert(LP324.SolutionHelper.QuickSelectValid(nums, nums.Length / 2));
            sln.QuickSelect(nums, 0, nums.Length, nums.Length / 2 - 1);
            Debug.Assert(LP324.SolutionHelper.QuickSelectValid(nums, nums.Length / 2 - 1));
            nums = new int[]{2,3,5,1,6,8,7,9,4};
            sln.QuickSelect(nums, 0, nums.Length, nums.Length / 2);
            Debug.Assert(LP324.SolutionHelper.QuickSelectValid(nums, nums.Length / 2));
            sln.QuickSelect(nums, 0, nums.Length, nums.Length / 2 - 1);
            Debug.Assert(LP324.SolutionHelper.QuickSelectValid(nums, nums.Length / 2 - 1));
            nums = new int[]{5,5,4,4,4,3,3,2,2};
            sln.QuickSelect(nums, 0, nums.Length, nums.Length / 2);
            Debug.Assert(LP324.SolutionHelper.QuickSelectValid(nums, nums.Length / 2));
            sln.QuickSelect(nums, 0, nums.Length, nums.Length / 2 - 1);
            Debug.Assert(LP324.SolutionHelper.QuickSelectValid(nums, nums.Length / 2 - 1));

            AssertEquals(LP324.SolutionHelper.WiggleSortValid(new int[]{1,2,3,4}), false);
            AssertEquals(LP324.SolutionHelper.WiggleSortValid(new int[]{1,6,1,5,1,4}), true);
            Func<int, int> f = x => (2 - (x / 3) * (6 & 1) - x % 3) * 2 + x / 3;
            AssertEquals(f(0), 4);
            AssertEquals(f(1), 2);
            AssertEquals(f(2), 0);
            AssertEquals(f(3), 5);
            AssertEquals(f(4), 3);
            AssertEquals(f(5), 1);

            AssertEquals(0*2, 0);
            AssertEquals(0<<1, 0);

            f = x => (1|(x<<1)) % (5|1);
            AssertEquals(f(0), 1);
            AssertEquals(f(1), 3);
            AssertEquals(f(2), 0);
            AssertEquals(f(3), 2);
            AssertEquals(f(4), 4);

            nums = new int[]{1,5,1,1,6,4};
            list1 = new List<int>(nums);
            sln.WiggleSort(nums);
            Debug.Assert(LP324.SolutionHelper.WiggleSortValid(nums));
            list2 = new List<int>(nums);
            list1.Sort();
            list2.Sort();
            AssertEqualsEnumerable(list1, list2);
            nums = new int[]{1,3,2,2,3,1};
            list1 = new List<int>(nums);
            sln.WiggleSort(nums);
            Debug.Assert(LP324.SolutionHelper.WiggleSortValid(nums));
            list2 = new List<int>(nums);
            list1.Sort();
            list2.Sort();
            AssertEqualsEnumerable(list1, list2);
            nums = new int[]{1,5,1,1,6};
            list1 = new List<int>(nums);
            sln.WiggleSort(nums);
            Debug.Assert(LP324.SolutionHelper.WiggleSortValid(nums));
            list2 = new List<int>(nums);
            list1.Sort();
            list2.Sort();
            AssertEqualsEnumerable(list1, list2);
            nums = new int[]{2,3,3,2,2,2,1,1};
            list1 = new List<int>(nums);
            sln.WiggleSort(nums);
            Debug.Assert(LP324.SolutionHelper.WiggleSortValid(nums));
            list2 = new List<int>(nums);
            list1.Sort();
            list2.Sort();
            AssertEqualsEnumerable(list1, list2);
        }

        static void P1358()
        {
            LP1358.Solution sln = new LP1358.Solution();
            AssertEquals(sln.NumberOfSubstrings("abcabc"), 10);
            AssertEquals(sln.NumberOfSubstrings("aaacb"), 3);
            AssertEquals(sln.NumberOfSubstrings("abc"), 1);
            AssertEquals(sln.NumberOfSubstrings("ababababa"), 0);
        }

        static void P1293()
        {
            LP1293.Solution sln = new LP1293.Solution();
            int[][] grid;
            grid = new int[][]{ new int[]{0,0,0},
                                new int[]{1,1,0},
                                new int[]{0,0,0},
                                new int[]{0,1,1},
                                new int[]{0,0,0} };
            AssertEquals(sln.ShortestPath(grid, 1), 6);
            grid = new int[][]{ new int[]{0,1,1},
                                new int[]{1,1,1},
                                new int[]{1,0,0} };
            AssertEquals(sln.ShortestPath(grid, 1), -1);
            grid = new int[][]{ new int[]{0,1,0,0,0,0},
                                new int[]{0,0,0,1,1,0},
                                new int[]{1,1,1,1,1,1},
                                new int[]{1,1,1,1,1,0},
                                new int[]{0,0,0,0,0,0} };
            AssertEquals(sln.ShortestPath(grid, 1), 11);

        }

        static void P1140()
        {
            LP1140.Solution sln = new LP1140.Solution();
            AssertEquals(sln.StoneGameII(new int[]{2,7,9,4,4}), 10);
            AssertEquals(sln.StoneGameII(new int[]{1,2,3,4,5,100}), 104);
            AssertEquals(sln.StoneGameII(new int[]{6,4,2,8,1,8,6,6,2}), 24);
        }

        static void P1447()
        {
            LP1447.Solution sln = new LP1447.Solution();
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

        static void P983()
        {
            LP983.Solution sln = new LP983.Solution();
            AssertEquals(sln.MincostTickets(new int[]{1,4,6,7,8,20}, new int[]{2,7,15}), 11);
            AssertEquals(sln.MincostTickets(new int[]{1,2,3,4,5,6,7,8,9,10,30,31}, new int[]{2,7,15}), 17);
            AssertEquals(sln.MincostTickets(new int[]{3,5,6,8,9,10,11,12,13,14,15,16,20,21,23,25,26,27,29,30,33,34,35,36,38,39,40,42,45,46,47,48,49,51,53,54,56,57,58,59,60,61,63,64,67,68,69,70,72,74,77,78,79,80,81,82,83,84,85,88,91,92,93,96}, new int[]{3,17,57}), 170);
        }

        static void P1632()
        {
            LP1632.Solution sln = new LP1632.Solution();
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

        static void P65()
        {
            LP65.Solution sln = new LP65.Solution();
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

        static void P99()
        {
            LP99.Solution sln = new LP99.Solution();
            int?[] seq_gt = new int?[]{1,3,null,null,2};
            LP99.TreeNode root = LP99.SolutionHelper.CreateBST(seq_gt);
            int?[] seq = LP99.SolutionHelper.BSTToNullableInt(root);
            AssertEqualsEnumerable(seq, seq_gt);

            seq_gt = new int?[]{1,3,null,null,2};
            root = LP99.SolutionHelper.CreateBST(seq_gt);
            sln.RecoverTree(root);
            seq = LP99.SolutionHelper.BSTToNullableInt(root);
            AssertEqualsEnumerable(seq, new int?[]{3,1,null,null,2});

            seq_gt = new int?[]{3,1,4,null,null,2};
            root = LP99.SolutionHelper.CreateBST(seq_gt);
            sln.RecoverTree(root);
            seq = LP99.SolutionHelper.BSTToNullableInt(root);
            AssertEqualsEnumerable(seq, new int?[]{2,1,4,null,null,3});

            seq_gt = new int?[]{2,3,1};
            root = LP99.SolutionHelper.CreateBST(seq_gt);
            sln.RecoverTree(root);
            seq = LP99.SolutionHelper.BSTToNullableInt(root);
            AssertEqualsEnumerable(seq, new int?[]{2,1,3});
        }

        static void P695()
        {
            LP695.Solution sln = new LP695.Solution();
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

        static void P210()
        {
            LP210.Solution sln = new LP210.Solution();
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

        static void P19()
        {
            LP19.Solution sln = new LP19.Solution();
            AssertEquals(sln.RemoveNthFromEnd(new LP19.ListNode(new int[]{1,2}), 1), LP19.ListNode.CreateListNode(new int[]{1}));
            AssertEquals(sln.RemoveNthFromEnd(new LP19.ListNode(new int[]{1}), 1), null);
            AssertEquals(sln.RemoveNthFromEnd(new LP19.ListNode(new int[]{1,2}), 2), LP19.ListNode.CreateListNode(new int[]{2}));
            AssertEquals(sln.RemoveNthFromEnd(new LP19.ListNode(new int[]{1,2,3}), 2), LP19.ListNode.CreateListNode(new int[]{1,3}));
        }

        static void P1328()
        {
            LP1328.Solution sln = new LP1328.Solution();
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

        static void P7()
        {
            LP7.Solution sln = new LP7.Solution();
            AssertEquals(sln.Reverse(1234), 4321);
            AssertEquals(sln.Reverse(-1234), -4321);
            AssertEquals(sln.Reverse(120), 21);
            AssertEquals(sln.Reverse(0), 0);
            AssertEquals(sln.Reverse(1534236469), 0);
            AssertEquals(sln.Reverse(-1534236469), 0);
        }

        static void P4()
        {
            LP4.Solution sln = new LP4.Solution();
            AssertEquals(sln.FindMedianSortedArrays(new[]{1,3}, new[]{2}), 2.0);
            AssertEquals(sln.FindMedianSortedArrays(new[]{1,2}, new[]{3,4}), 5.0 / 2);
            AssertEquals(sln.FindMedianSortedArrays(new[]{0,0}, new[]{0,0}), 0.0);
            AssertEquals(sln.FindMedianSortedArrays(new int[]{}, new[]{1}), 1.0);
            AssertEquals(sln.FindMedianSortedArrays(new[]{2}, new int[]{}), 2.0);
            AssertEquals(sln.FindMedianSortedArrays(new[]{2}, new int[]{1,3,4}), 2.5);
        }

        static void P4_BinarySearchTest()
        {
            LP4.Solution sln = new LP4.Solution();
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

        static void P5()
        {
            LP5.Solution sln = new LP5.Solution();
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

        static void P6()
        {
            LP6.Solution sln = new LP6.Solution();
            AssertEquals(sln.Convert("PAYPALISHIRING", 3), "PAHNAPLSIIGYIR");
            AssertEquals(sln.Convert("PAYPALISHIRING", 4), "PINALSIGYAHRPI");
            AssertEquals(sln.Convert("A", 1), "A");
        }
    }
}
