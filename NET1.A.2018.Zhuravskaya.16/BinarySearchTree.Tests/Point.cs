﻿namespace BinarySearchTree.Tests
{
   public struct Point
    { 
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override string ToString()
       {
           return $"({X};{Y})";
       }
   }
}
