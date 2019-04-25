using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinaryTree<TKey> where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        private class Node
        {
            public TKey Key;
            public Node Left;
            public Node Right;

            public void Print(int level = 0)
            {
                Node current = this;
                if (current != null)
                {
                    current.Right?.Print(++level);
                }

                for (int spaces = 0; spaces < level; spaces++)
                {
                    Console.Write("  ");
                }

                if(current != null)
                {
                    Console.WriteLine($"{current.Key}<");
                }

                if(current != null)
                {
                    current.Left?.Print(++level);
                }

            }
        }

        private Node _root;
        
        private TKey Search(Node r, TKey key)
        {
            if(r == null)
            {
                return default(TKey);
            }

            Node current = r;
            if(key.Equals(current.Key))
            {
                return r.Key;
            }

            if(key.CompareTo(current.Key) < 0)
            {
                return Search(current.Left, key);
            }
            else
            {
                return Search(current.Right, key);
            }
        }

        private void Insert(ref Node r, TKey key)
        {
            if (r == null)
            {
                r = new Node() { Key = key };
                return;
            }

            Node current = r;
            if (key.CompareTo(current.Key) < 0)
            {
                Insert(ref current.Left, key);
                //RotationRight(ref current);
            }
            else
            {
                Insert(ref current.Right, key);
                //RotationLeft(ref current);
            }
        }

        private Node FindNode(TKey key, out Node r)
        {
            // Now, try to find data in the tree
            Node current = _root;
            r = null;

            // while we don't have a match
            while (current != null)
            {
                int result = current.Key.CompareTo(key);

                if (result > 0)
                {
                    // if the value is less than current, go left.
                    r = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // if the value is more than current, go right.
                    r = current;
                    current = current.Right;
                }
                else
                {
                    // we have a match!
                    break;
                }
            }

            return current;
        }

        //private void RotationRight(ref Node r)
        //{
        //    Node current = r.Left;
        //    r.Left = current.Right;
        //    current.Right = r;
        //    r = current;
        //}

        //private void RotationLeft(ref Node r)
        //{
        //    Node current = r.Right;
        //    r.Right = current.Left;
        //    current.Left = r;
        //    r = current;
        //}

        public BinaryTree()
        {
            _root = null;
        }

        public TKey Search(TKey key)
        {
            return Search(_root, key);
        }

        public void Insert(TKey key)
        {
            Insert(ref _root, key);
        }

        /// <summary>
        /// Removes the first occurance of the specified value from the tree.
        /// </summary>
        /// <param name="value">The value to remove</param>
        /// <returns>True if the value was removed, false otherwise</returns>
        public bool Remove(TKey key)
        {
            Node current, parent;

            current = FindNode(key, out parent);

            if (current == null)
            {
                return false;
            }

            // Case 1: If current has no right child, then current's left replaces current
            if (current.Right == null)
            {
                if (parent == null)
                {
                    _root = current.Left;
                }
                else
                {
                    int result = parent.Key.CompareTo(current.Key);
                    if (result > 0)
                    {
                        // if parent value is greater than current value
                        // make the current left child a left child of parent
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        // if parent value is less than current value
                        // make the current left child a right child of parent
                        parent.Right = current.Left;
                    }
                }
            }
            // Case 2: If current's right child has no left child, then current's right child
            //         replaces current
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    _root = current.Right;
                }
                else
                {
                    int result = parent.Key.CompareTo(current.Key);
                    if (result > 0)
                    {
                        // if parent value is greater than current value
                        // make the current right child a left child of parent
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        // if parent value is less than current value
                        // make the current right child a right child of parent
                        parent.Right = current.Right;
                    }
                }
            }
            // Case 3: If current's right child has a left child, replace current with current's
            //         right child's left-most child
            else
            {
                // find the right's left-most child
                Node leftmost = current.Right.Left;
                Node leftmostParent = current.Right;

                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // the parent's left subtree becomes the leftmost's right subtree
                leftmostParent.Left = leftmost.Right;

                // assign leftmost's left and right to current's left and right children
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    _root = leftmost;
                }
                else
                {
                    int result = parent.Key.CompareTo(current.Key);
                    if (result > 0)
                    {
                        // if parent value is greater than current value
                        // make leftmost the parent's left child
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        // if parent value is less than current value
                        // make leftmost the parent's right child
                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }

        public void Print()
        {
            Console.WriteLine($"\n====================================\n");
            _root.Print();
        }
    }
}
