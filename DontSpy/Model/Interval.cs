﻿namespace DontSpy.Model
{
    internal class Interval
    {
        public int Start { get; }
        public int End { get; }
        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}
