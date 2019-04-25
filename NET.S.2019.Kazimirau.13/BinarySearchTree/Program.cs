using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            bst.Remove(2);
            Console.WriteLine("____________________");
            bst.Print();
        }
    }
}
