﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Week1
{
public static class BigMath
    {
        public static string Add(string a, string b)
        {
            int sizeA = a.Length,
                sizeB = b.Length,
                maxResult = Math.Max(sizeA, sizeB)+1;

            char[] charArrayA = ReverseCharArray(a.ToCharArray()),
                   charArrayB = ReverseCharArray(b.ToCharArray()),
                   temp = new char[maxResult];
            for (int i=0; i<sizeA; i++)
            {
                temp[i] = charArrayA[i];
            }
            int digitSum = sumChars(temp[0], charArrayB[0]);
            temp[0] = NumToASCII(digitSum);
            if (digitSum > 9)             {
                temp[1] = temp[1] == 0 ? '1' : NumToASCII(sumChars(temp[1], '1'));
            }
            
            if (temp[maxResult-1] == 0)
            {
                char[] temp2 = new char[maxResult - 1];
                for (int i=0; i<maxResult-1; i++)
                {
                    temp2[i] = temp[i];
                }
                return new String(ReverseCharArray(temp2));
            }
            else
            {
                return new String(ReverseCharArray(temp));
            }
        }

        private static char NumToASCII(int num)
        {
            return ReverseCharArray(num.ToString().ToCharArray())[0];
        }

        private static int sumChars(char a, char b)
        {
            return (int)char.GetNumericValue(a) + (int)char.GetNumericValue(b);
        }

        private static char[] ReverseCharArray(char[] input)
        {
            int arraySize = input.Length;
            char[] reversed = new char[arraySize];
            for (int i = 0; i<arraySize; i++)
            {
                reversed[i] = input[arraySize - i - 1];
            }
            return reversed;
        }
    }

}