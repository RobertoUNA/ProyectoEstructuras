﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProyectoEstructuras
{
    public class Vectores // 100000
    {

        public void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);   
            }
        }
        public void PrintList(int[]? list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public List<int> GenerateSortedList(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            List<int> list = new List<int>(size);

            for (int i = 1; i<=size; i++)
            {
                list.Add(i);
            }

            return list;
        }

        public  List<int> GenerateTotallyRandomList(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            List<int> list = new List<int>(size);

            for (int i = 0; i < size; i++)
            {
                int randomNumber = random.Next(minValue, maxValue + 1);
                list.Add(randomNumber);
            }

            return list;
        }

        public  List<int> GenerateRandomSemiSortedList(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            List<int> SemiSortedList = new List<int>();
            int portion = size/ 10;
            List<int> RandomList = new List<int>();


            for (int i = 1; i <= size; i++)
            {
                Console.WriteLine($"Generates randoms from {minValue + (i - 1) * portion} to {portion * i}");
                RandomList = GenerateTotallyRandomList(portion, minValue + (i - 1) * portion, portion*i);

                // Add the generated portion to the semi-sorted list
                SemiSortedList.AddRange(RandomList);
            }
        
            return SemiSortedList;
        }

        public int[] ReadArray(string fileName)
        {
          
            string jsonString = File.ReadAllText(fileName);           
            int[] ArrayRandom = JsonSerializer.Deserialize<int[]>(jsonString);
            //this.PrintList(VectorRandom);
            return ArrayRandom;

        }

        public List<int> ReadArrayToList(string fileName)
        {

            string jsonString = File.ReadAllText(fileName);
            List<int> ArrayRandom = JsonSerializer.Deserialize<List<int>>(jsonString);
            //this.PrintList(VectorRandom);
            return ArrayRandom;

        }


    }
}
