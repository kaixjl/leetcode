/*
 * @lc app=leetcode id=7 lang=csharp
 *
 * [7] Reverse Integer
 */

// @lc code=start
using System;
using System.Collections.Generic;
public partial class Solution {

    public int Reverse(int x) {
        int rev = 0;
        while (x!=0) 
        {
            int n = x%10;
            x=x/10;
            if(rev>214748364 || rev==214748364 && n > 7)
            {
                rev=0;
                break;
            }
            else if(rev<-214748364 || rev==214748364 && n<-8)
            {
                rev=0;
                break;
            }
            rev=rev*10+n;

        }
        return rev;
    }

    // public int Reverse(int x) {
    //     List<int> numberList = new List<int>(10);
    //     while (x!=0) 
    //     {
    //         numberList.Add(x%10);
    //         x=x/10;
    //     }
    //     foreach(var n in numberList)
    //     {
    //         if(x>214748364 || x==214748364 && n > 7)
    //         {
    //             x=0;
    //             break;
    //         }
    //         else if(x<-214748364 || x==214748364 && n<-8)
    //         {
    //             x=0;
    //             break;
    //         }
    //         x=x*10+n;
    //     }
    //     return x;
    // }
}

// @lc code=end

