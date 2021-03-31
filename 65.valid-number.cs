/*
 * @lc app=leetcode id=65 lang=csharp
 *
 * [65] Valid Number
 *
 * https://leetcode.com/problems/valid-number/description/
 *
 * algorithms
 * Hard (15.58%)
 * Likes:    896
 * Dislikes: 5559
 * Total Accepted:    198.5K
 * Total Submissions: 1.2M
 * Testcase Example:  '"0"'
 *
 * A valid number can be split up into these components (in order):
 * 
 * 
 * A decimal number or an integer.
 * (Optional) An 'e' or 'E', followed by an integer.
 * 
 * 
 * A decimal number can be split up into these components (in order):
 * 
 * 
 * (Optional) A sign character (either '+' or '-').
 * One of the following formats:
 * 
 * At least one digit, followed by a dot '.'.
 * At least one digit, followed by a dot '.', followed by at least one
 * digit.
 * A dot '.', followed by at least one digit.
 * 
 * 
 * 
 * 
 * An integer can be split up into these components (in order):
 * 
 * 
 * (Optional) A sign character (either '+' or '-').
 * At least one digit.
 * 
 * 
 * For example, all the following are valid numbers: ["2", "0089", "-0.1",
 * "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93",
 * "-123.456e789"], while the following are not valid numbers: ["abc", "1a",
 * "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53"].
 * 
 * Given a string s, return true if s is a valid number.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: s = "0"
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "e"
 * Output: false
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: s = "."
 * Output: false
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: s = ".1"
 * Output: true
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= s.length <= 20
 * s consists of only English letters (both uppercase and lowercase), digits
 * (0-9), plus '+', minus '-', or dot '.'.
 * 
 * 
 */

using System;
using System.Collections.Generic;

// @lc code=start
public enum TagType
{
    Unknown,
    Sign,
    Digits,
    Dot,
    E,
    Decimal,
    Integer,
}

public class LexNode
{
    public string content = "";
    public TagType tag = TagType.Unknown;
    public List<LexNode> subNodes = new List<LexNode>();
    public int length = 0;
    public LexNode(string content, TagType tag, int length)
    {
        this.content = content;
        this.tag = tag;
        this.length = length;
    }

    public LexNode(){}
}
public partial class Solution {
    LexNode ParseSign(string s, int p)
    {
        if (p>=s.Length) return null;

        if(s[p]=='+' || s[p]=='-')
            return new LexNode(s.Substring(p, 1), TagType.Sign, 1);
        else
            return null;
    }

    LexNode ParseDigits(string s, int p)
    {
        if (p>=s.Length) return null;

        int q = p;
        while(q<s.Length && Char.IsDigit(s[q]))
            q++;
        if(p!=q)
            return new LexNode(s.Substring(p, q-p), TagType.Digits, q-p);
        else
            return null;
    }

    LexNode ParseDot(string s, int p)
    {
        if (p>=s.Length) return null;

        if(s[p]=='.')
            return new LexNode(s.Substring(p, 1), TagType.Sign, 1);
        else
            return null;
    }

    LexNode ParseE(string s, int p)
    {
        if (p>=s.Length) return null;

        if(s[p]=='E' || s[p]=='e')
            return new LexNode(s.Substring(p, 1), TagType.Sign, 1);
        else
            return null;
    }

    LexNode ParseDecimal(string s, int p)
    {
        LexNode node = new LexNode();
        LexNode n ;
        bool digits1 = false, digits2 = false;
        int q = p;
        
        if (q>=s.Length) return null;

        n = ParseSign(s, q);
        if(n!=null)
        {
            q += n.length;
            node.subNodes.Add(n);
        }
        
        if (q==s.Length) return null;

        n = ParseDigits(s, q);
        if(n!=null)
        {
            q += n.length;
            node.subNodes.Add(n);
        }
        digits1 = n!=null;

        if (q==s.Length) return null;

        n = ParseDot(s, q);
        if(n==null)
            return null;

        q += n.length;
        node.subNodes.Add(n);

        if (q==s.Length)
            if(!digits1)
                return null;
            else
            {
                node.content = s.Substring(p, q - p);
                node.length = q - p;
                node.tag = TagType.Decimal;
                return node;
            }

        n = ParseDigits(s, q);
        if(n!=null)
        {
            q += n.length;
            node.subNodes.Add(n);
        }
        digits2 = n!=null;

        if(!digits1 && !digits2)
            return null;

        node.content = s.Substring(p, q - p);
        node.length = q - p;
        node.tag = TagType.Decimal;
        return node;
    }

    LexNode ParseInteger(string s, int p)
    {
        LexNode node = new LexNode();
        LexNode n ;
        int q = p;
        n = ParseSign(s, q);
        if(n!=null)
        {
            q += n.length;
            node.subNodes.Add(n);
        }

        n = ParseDigits(s, q);
        if(n==null)
            return null;

        q += n.length;
        node.subNodes.Add(n);

        node.content = s.Substring(p, q - p);
        node.length = q - p;
        node.tag = TagType.Integer;
        return node;
    }

    public bool IsNumber(string s) {
        int p = 0;
        LexNode n;
        n = ParseDecimal(s, p);
        if(n!=null)
        {
            p += n.length;
        }
        else
        {
            n = ParseInteger(s, p);
            if(n!=null)
            {
                p += n.length;
            }
            else return false;
        }

        if (p==s.Length)
            return true;

        n = ParseE(s, p);
        if(n==null)
            return false;

        p += n.length;
        n = ParseInteger(s, p);
        if(n==null)
            return false;
        
        p += n.length;

        if(p==s.Length)
            return true;
        else
            return false;
    }
}
// @lc code=end

