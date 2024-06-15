using ProyectoEstructuras;
using System.Diagnostics;
using System.Text.Json;

/*
#region Trees

Tree tree1 = new Tree();
Tree tree2 = new Tree();

// Add elements into tree1
tree1.Add(5);
tree1.Add(3);
tree1.Add(7);
tree1.Add(2);
tree1.Add(1);
tree1.Add(4);

// Add elements into tree2
tree2.Add(6);
tree2.Add(8);
tree2.Add(4);
tree2.Add(7);
tree2.Add(2);

Console.WriteLine("tree 1");
tree1.Print();
Console.WriteLine("tree 2");
tree2.Print();
// Union of tree1 and tree2
Tree unionTree = tree1.Union(tree2); 
Console.WriteLine("Union tree "); unionTree.Print();

// Intersection of tree1 and tree2
Tree intersectionTree = tree1.Intersection(tree2); 
Console.WriteLine("Intersection tree"); intersectionTree.Print();

// Difference of tree1 and tree2
Tree differenceTree = tree1.Difference(tree2); 
Console.WriteLine("Difference tree"); differenceTree.Print();
#endregion
*/

/*
1. Bubble Sort 
2. Selection Sort 
3. Insertion Sort 
4. Merge Sort 
5. Quick Sort 
6. Heap Sort 
7. Counting Sort  
 */


Vectores vectGen= new Vectores();
SortingMethods sortingMethods = new SortingMethods();

//10000
List<int> list = vectGen.GenerateSortedList(10700);
list.Reverse();
vectGen.ListToJson(list, "ArraySorted.json");


int[] array = vectGen.ReadJson("ArraySorted.json");

Stopwatch timeMeasure = new Stopwatch();
timeMeasure.Start();
sortingMethods.BubbleSort(array);
timeMeasure.Stop();
Console.WriteLine($"Time Bubble Sort: {timeMeasure.Elapsed.TotalMilliseconds} ms");




/*
Stopwatch timeMeasure = new Stopwatch();
timeMeasure.Start();
//sortingMethods.
timeMeasure.Stop();
Console.WriteLine($"Time sorting: {timeMeasure.Elapsed.TotalMilliseconds} ms");

//Bubble 
timeMeasure.Start();
sortingMethods.BubbleSort(array);
timeMeasure.Stop();
Console.WriteLine($"Time Bubble Sort: {timeMeasure.Elapsed.TotalMilliseconds} ms");

//Selection
timeMeasure.Start();
sortingMethods.SelectionSort(array);
timeMeasure.Stop();
Console.WriteLine($"Time Selection Sort: {timeMeasure.Elapsed.TotalMilliseconds} ms");

//Insertion
timeMeasure.Start();
sortingMethods.InsertionSort(array);
timeMeasure.Stop();
Console.WriteLine($"Time Insertion Sort: {timeMeasure.Elapsed.TotalMilliseconds} ms");

//Merge
timeMeasure.Start();
sortingMethods.MergeSort(array, 0, array.Length - 1);
timeMeasure.Stop();
Console.WriteLine($"Time Merge Sort: {timeMeasure.Elapsed.TotalMilliseconds} ms");

// Quick
timeMeasure.Start();
sortingMethods.QuickSort(array, 0, array.Length - 1);
timeMeasure.Stop();
Console.WriteLine($"Time Quick Sort: {timeMeasure.Elapsed.TotalMilliseconds} ms");

//Heap
timeMeasure.Start();
sortingMethods.HeapSort(array);
timeMeasure.Stop();
Console.WriteLine($"Time Heap Sort: {timeMeasure.Elapsed.TotalMilliseconds} ms");

// Counting
List<int> list = new List<int>();
list = vectGen.ReadJsonToList("ArraySemiSorted.json");
timeMeasure.Start();
sortingMethods.CountSort(list);
timeMeasure.Stop();
Console.WriteLine($"Time Count Sort: {timeMeasure.Elapsed.TotalMilliseconds} ms");
*/
