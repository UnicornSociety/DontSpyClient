﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace ModernEncryption
{
    public class Decryption
    {
        public Dictionary<char, int> BackTransformationTable { get; set; } = new Dictionary<char, int>();
        public int [] BackTransformation(char [] chiffre)
        {

            BackTransformationTable.Add('a', 1);
            BackTransformationTable.Add('b', 2);
            BackTransformationTable.Add('c', 3);
            BackTransformationTable.Add('d', 4);
            BackTransformationTable.Add('e', 5);
            BackTransformationTable.Add('f', 6);
            BackTransformationTable.Add('g', 7);
            BackTransformationTable.Add('h', 8);
            BackTransformationTable.Add('i', 9);
            BackTransformationTable.Add('j', 10);
            BackTransformationTable.Add('k', 11);
            BackTransformationTable.Add('l', 12);
            BackTransformationTable.Add('m', 13);
            BackTransformationTable.Add('n', 14);
            BackTransformationTable.Add('o', 15);
            BackTransformationTable.Add('p', 16);
            BackTransformationTable.Add('q', 17);
            BackTransformationTable.Add('r', 18);
            BackTransformationTable.Add('s', 19);
            BackTransformationTable.Add('t', 20);
            BackTransformationTable.Add('u', 21);
            BackTransformationTable.Add('v', 22);
            BackTransformationTable.Add('w', 23);
            BackTransformationTable.Add('x', 24);
            BackTransformationTable.Add('y', 25);
            BackTransformationTable.Add('z', 26);
            BackTransformationTable.Add('ß', 27);
            BackTransformationTable.Add('.', 28);
            BackTransformationTable.Add(',', 29);
            BackTransformationTable.Add(' ', 30);
            BackTransformationTable.Add('1', 31);
            BackTransformationTable.Add('2', 32);
            BackTransformationTable.Add('3', 33);
            BackTransformationTable.Add('4', 34);
            BackTransformationTable.Add('5', 35);
            BackTransformationTable.Add('6', 36);
            BackTransformationTable.Add('7', 37);
            BackTransformationTable.Add('8', 38);
            BackTransformationTable.Add('9', 39);
            BackTransformationTable.Add('0', 40);
            int[] integers = new int[chiffre.Length];
            for (int i = 0; i < chiffre.Length;i++)
            {
                var a = BackTransformationTable[chiffre[i]];
                i++;
                var b = BackTransformationTable[chiffre[i]];
                int value = (a - 1) * 40 + b;
                Debug.WriteLine(value);
                integers[(i+1) / 2] = value;
            }
            return integers;

        }

        public char[] NumberToLetter(int[] integers)
        {
            var plaintext = new List<char> ();
            for (var number = 1; number <= integers.Length; number++)
            {
                int counter;
                for (counter = 1; counter < 40; counter++)
                {
                    var symbol = TransformationTable.transformationTable[number];
                    var helper = new Symbol();
                    var interval = helper.IntervalAssignment();
                    if (number >= interval.Start && number <= interval.End)
                    {
                        break;
                    }
                }
                var letterOfPlaintext = TransformationTable.transformationTable[counter];
                Debug.WriteLine("Decryption");
                Debug.WriteLine(letterOfPlaintext);
                plaintext.Add(letterOfPlaintext);
            }
            var finalPlaintext = plaintext.ToArray();
            return finalPlaintext;
        }
    }
}
