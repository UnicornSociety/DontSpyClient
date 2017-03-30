﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ModernEncryption
{
    public class Symbol
    {

        private string chiffre { get; }
        public char symbol { get; }
        public int start { get; }
        public int end { get; }

        public Symbol(char symbol)
        {
            this.symbol = symbol;
            var interval = IntervalAssignment();
            SelectRandomIntervalNumber(interval);
            Permutation();
            Transformation();
        }
        public Interval IntervalAssignment()
        {
            return Intervals.IntervalTable[symbol];
        }

        public void SelectRandomIntervalNumber(Interval interval)
        {
            Random rnd = new Random();
            var chiffre = rnd.Next(start, end +1);
        }

        public void Permutation()
        {
            var chiffre = (chiffre * 20 - 9) % 1600;
        }

        public string Transformation()
        {
            //TODO Rückübersetzung von Zahl in Zeichenpaar
            // chiffre = (chiffre -  1) / 40;
            var permutation = chiffre -1 % 40
            return "blabla";
        }

    }
}
