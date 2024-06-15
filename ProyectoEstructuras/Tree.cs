using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class Node
{
    public int Data { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int data)
    {
        this.Data = data;
        Left = null;
        Right = null;
    }
}

public class Tree
{
    public Node Root { get; set; }

    public void Add(int data)
    {
        Root = AddRecursive(Root, data);
    }

    public Node AddRecursive(Node node, int data)
    {
        if (node == null)
            return new Node(data);

        if (data < node.Data)
            node.Left = AddRecursive(node.Left, data);
        else if (data > node.Data)
            node.Right = AddRecursive(node.Right, data);

        return node;
    }

    #region Prints
    public void Print()
    {
        InorderPrint(Root);
        Console.WriteLine();
    }

    public void InorderPrint(Node node)
    {
        if (node != null)
        {
            InorderPrint(node.Left);
            Console.Write(node.Data + " ");
            InorderPrint(node.Right);
        }
    }
    #endregion

    #region Finds
    public bool Find(int value)
    {
        return FindRecursive(Root, value);
    }

    public bool FindRecursive(Node node, int value)
    {
        if (node == null)
            return false;

        if (node.Data == value)
            return true;

        if (value < node.Data)
            return FindRecursive(node.Left, value);
        else
            return FindRecursive(node.Right, value);
    }
    #endregion

    #region Union
    public Tree Union(Tree other)
    {
        Tree result = new Tree();
        AddTree(Root, result);
        other.AddTree(other.Root, result);
        return result;
    }

    public void AddTree(Node node, Tree result)
    {
        if (node != null)
        {
            AddTree(node.Left, result);
            result.Add(node.Data);
            AddTree(node.Right, result);
        }
    }
    #endregion

    #region Intersection
    public Tree Intersection(Tree other)
    {
        Tree result = new Tree();
        result = IntersectionAux(Root, other, result);

        return result;
    }
  
    public Tree IntersectionAux(Node node, Tree other, Tree result)
    {
        if (node != null)
        {
            if (other.Find(node.Data))
            {
                result.Add(node.Data);
                return result;
                
            }
            IntersectionAux(node.Right, other, result);
            IntersectionAux(node.Left, other, result);
        }
        return result;
    }
    #endregion

    #region Difference
    public Tree Difference(Tree other)
    {
        Tree result = new Tree();
        //DifferenceHelper(Root, other.Root, result);
        result = DifferenceAux(Root, other, result);
        return result;
    }
    public Tree DifferenceAux(Node node, Tree other, Tree result)
    {
        if (node != null)
        {
            if (!other.Find(node.Data))
            {
                result.Add(node.Data);
            }
            DifferenceAux(node.Right, other, result);
            DifferenceAux(node.Left, other, result);
        }
        return result;
    }
    #endregion
}