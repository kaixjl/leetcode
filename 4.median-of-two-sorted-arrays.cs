/*
 * @lc app=leetcode id=4 lang=csharp
 *
 * [4] Median of Two Sorted Arrays
 */
using System;
using System.Collections.Generic;
// @lc code=start
public partial class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int start1 = 0, start2 = 0, end1 = nums1.Length, end2 = nums2.Length;
        int len_total = end1 + end2;
        int len_half = len_total / 2;
        double result;
        if (nums1.Length==0) // spectial case
        {
            if(nums2.Length % 2 ==1) // odd
            {
                result = nums2[nums2.Length/2];
                return result;
            }
            else
            {
                result = System.Convert.ToDouble(nums2[nums2.Length/2] + nums2[nums2.Length/2-1]) / 2;
                return result;
            }
        }
        else if (nums2.Length==0) // spectial case
        {
            if(nums1.Length % 2 ==1) // odd
            {
                result = nums1[nums1.Length/2];
                return result;
            }
            else
            {
                result = System.Convert.ToDouble(nums1[nums1.Length/2] + nums1[nums1.Length/2-1]) / 2;
                return result;
            }
        }
        
        while (true)
        {
            if(Process(nums1, nums2, ref start1, ref end1, ref start2, ref end2, len_total, len_half, out result))
                return result;
            
            if(Process(nums2, nums1, ref start2, ref end2, ref start1, ref end1, len_total, len_half, out result))
                return result;
        }

    }

    public bool Process(int[] nums1, int[] nums2, ref int start1, ref int end1, ref int start2, ref int end2, int len_total, int len_half, out double result)
    {
        int index1 = (start1 + end1) / 2;
        int curr1 = nums1[index1];

        if (start2==end2)
        {
            int len_of_nums1_left = start1;
            int len_of_nums1_right = nums1.Length - end1;
            int len_of_nums2_left = start2;
            int len_of_nums2_right = nums2.Length - end2;

            int len_of_left = len_of_nums1_left + len_of_nums2_left;
            int len_of_right = len_of_nums1_right + len_of_nums2_right;

            int diff = len_of_left - len_of_right;

            if(diff>0)
            {
                end1 -= diff;
            }
            else
            {
                start1 -= diff;
            }

            int sum = end1 + start1;
            index1 = sum/2;
            if(sum%2==1)
            {
                result = System.Convert.ToDouble(nums1[index1]);
                return true;
            }
            else
            {
                curr1 = nums1[index1];
                int another=0;
                if(index1 == 0) another = nums2[start2-1];
                else if(start2 == 0) another = nums1[index1-1];
                else another = Math.Max(nums1[index1-1], nums2[start2-1]);
                
                result = (System.Convert.ToDouble(another) + curr1) / 2;
                return true;
            }
        }


        int index1r = FindRight(nums1, start1, end1, index1);
        index1 = FindLeftEquals(nums1, start1, end1, index1);
        int idx = BinarySearch(nums2, start2, end2, curr1);

        int idxr = 0;

        if(idx==end2) // out of bound
        {
            idxr = idx;
        }
        else if(nums2[idx] == curr1)
        {
            idxr = FindRight(nums2, start2, end2, idx);
        }
        else
        {
            idxr = idx;
        }

        int len_of_curr1 = index1r - index1 + idxr - idx;
        int len_of_curr1_l = index1 - 0 + idx - 0;
        int len_of_curr1_r = nums1.Length - index1r + nums2.Length - idxr;

        if (len_half < len_of_curr1_l)
        {
            end1 = index1;
        }
        else if(len_half < len_of_curr1_l + len_of_curr1) // median is in it
        {
            if (len_total%2==1) // odd
            {
                result = curr1;
                return true;
            }
            else // even
            {
                if (len_half == len_of_curr1_l) // 边界条件
                {
                    int another=0;
                    if(index1 == 0) another = nums2[idx-1];
                    else if(idx == 0) another = nums1[index1-1];
                    else another = Math.Max(nums1[index1-1], nums2[idx-1]);
                    
                    result = (System.Convert.ToDouble(another) + curr1) / 2;
                    return true;
                }
                else
                {
                    result = curr1;
                    return true;
                }
            }
        }
        else
        {
            start1 = index1r;
        }
        
        result = 0;
        return false;

    }

    public int BinarySearch(int[] nums, int start, int end, int value)
    {
        int start0 = start, end0 = end;
        if (start == end) return end;

        int index = (start + end) / 2;
        int curr = nums[index];
        while(end - start > 1)
        {
            if (value < curr)
            {
                end = index;
            } 
            else
            {
                start = index;
            }
            index = (start + end) / 2;
            curr = nums[index];
        }

        if(value > curr)
        {
            index = FindRight(nums, start0, end0, index);
        }
        else
        {
            index = FindLeftEquals(nums, start0, end0, index);
        }

        return index;
    }

    public int FindLeftEquals(int[] nums, int start, int end, int index)
    {
        int value = nums[index];
        while(index >= start && nums[index] == value)
        {
            index--;
        }
        index++;
        return index;
    }
    // public int FindLeft(int[] nums, int start, int end, int index)
    // {
    //     int value = nums[index];
    //     while(index >= start && nums[index] == value)
    //     {
    //         index--;
    //     }
    //     return index;
    // }
    // public int FindRightEquals(int[] nums, int start, int end, int index)
    // {
    //     int value = nums[index];
    //     while(index < end && nums[index] == value)
    //     {
    //         index++;
    //     }
    //     index--;
    //     return index;
    // }
    public int FindRight(int[] nums, int start, int end, int index)
    {
        int value = nums[index];
        while(index < end && nums[index] == value)
        {
            index++;
        }
        return index;
    }
}
// @lc code=end

