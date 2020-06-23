using System;
using System.Collections.Generic;

namespace FuturePros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the numbers:");
            List<int> List = new List<int>();
            String temp = Console.ReadLine();
            while (temp != "")
            {
                List.Add(Int32.Parse(temp));
                temp = Console.ReadLine();
            }

            int[] array = List.ToArray();

            int[] jumpPath = new int[50];
            int position = 0;
            int jumpCount = minJumps(array, 0, array.Length - 1, jumpPath);
            if (jumpCount != int.MaxValue)
            {
                Console.WriteLine("Moves: " + jumpCount);
                for (int a = jumpCount; a >= 0; a--)
                {
                    Console.Write(jumpPath[a] + " -> ");
                }
                Console.WriteLine("Solution found");
            }
            else
            {
                Console.WriteLine("Impossible to find thesolution");
            }
        }
        
        static int minJumps(int[] arr, int q, int w, int[] path) 
        {
            if (w == q) 
                return 0; 
            
            if (arr[q] == 0) 
                return int.MaxValue; 
            
            int minJumpCount = int.MaxValue; 
            for (int i = q + 1; i <= w && i <= q + arr[q]; i++) { 
                int jumps = minJumps(arr, i, w, path);
                if (jumps != int.MaxValue && jumps + 1 < minJumpCount)
                {
                    minJumpCount = jumps + 1;
                    path[minJumpCount - 1] = arr[i];
                    path[minJumpCount] = arr[0];
                }
            } 
            return minJumpCount; 
        } 
    }
}