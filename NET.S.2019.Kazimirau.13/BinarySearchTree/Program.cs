using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> bst = new BinaryTree<int>();
            bst.Insert(7);
            bst.Insert(5);
            bst.Insert(9);
            bst.Insert(6);
            bst.Insert(4);
            bst.Insert(11);
            bst.Insert(8);
            bst.Insert(2);
            bst.Insert(10);
            bst.Insert(19);

            bst.Print();

            Console.WriteLine("____Remove______");
            bst.Remove(2);
            bst.Remove(5);
            bst.Print();
            Console.WriteLine("___InOrder Traversal___");
            bst.InOrderTraversal(Console.WriteLine);
            Console.WriteLine("___PreOrder Traversal___");
            bst.PreOrderTraversal(Console.WriteLine);
            Console.WriteLine("___PostOrder Traversal___");
            bst.PostOrderTraversal(Console.WriteLine);
        }
    }
}
