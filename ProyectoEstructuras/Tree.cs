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
    public Node Root { get; private set; }

    public void Add(int data)
    {
        Root = AddRecursive(Root, data);
    }

    private Node AddRecursive(Node node, int data)
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

    private void InorderPrint(Node node)
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

    private bool FindRecursive(Node node, int value)
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
        AddTreeInorder(Root, result);
        other.AddTreeInorder(other.Root, result);
        return result;
    }

    private void AddTreeInorder(Node node, Tree result)
    {
        if (node != null)
        {
            AddTreeInorder(node.Left, result);
            result.Add(node.Data);
            AddTreeInorder(node.Right, result);
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
  
    private Tree IntersectionAux(Node node, Tree other, Tree result)
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
    private Tree DifferenceAux(Node node, Tree other, Tree result)
    {
        if(node == null)
        {
            return result;
        }
        else
        {
            if(!other.Find(node.Data))
            {
                result.Add(node.Data);
            }
            DifferenceAux(node.Right, other, result);   
            DifferenceAux(node.Left, other, result);
            return result;
        }
    }
    #endregion
}