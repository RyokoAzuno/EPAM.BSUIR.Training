using System;
using System.Collections.Generic;
using BinarySearchTree.Interfaces;

namespace BinarySearchTree
{
    // Class represents binary tree
    public class BinaryTreeOld<TKey> : IPrintable, IEnumerable<TKey> where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        private Node _root;

        ////private void RotationRight(ref Node r)
        ////{
        ////    Node current = r.Left;
        ////    r.Left = current.Right;
        ////    current.Right = r;
        ////    r = current;
        ////}

        ////private void RotationLeft(ref Node r)
        ////{
        ////    Node current = r.Right;
        ////    r.Right = current.Left;
        ////    current.Left = r;
        ////    r = current;
        ////}

        public BinaryTreeOld()
        {
            _root = null;
        }

        public BinaryTreeOld(IEnumerable<TKey> items)
        {
            _root = null;

            foreach (var item in items)
            {
                Insert(item);
            }
        }

        public bool IsExist(TKey key)
        {
            return IsExist(_root, key);
        }

        public void Insert(TKey key)
        {
            Insert(ref _root, key);
        }

        /// <summary>
        /// Removes the first occurrence of the specified value from the tree.
        /// </summary>
        /// <param name="value"> The value to remove </param>
        /// <returns> True if the value was removed, false otherwise </returns>
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
            else if (current.Right.Left == null)
            {
                // Case 2: If current's right child has no left child, then current's right child replaces current
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
            else
            {
                // Case 3: If current's right child has a left child, replace current with current's
                //         right child's left-most child
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

        /// <summary>
        /// Performs the provided action on each binary tree value in pre-order traversal order.
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void PreOrderTraversal(Action<TKey> action)
        {
            PreOrderTraversal(action, _root);
        }

        /// <summary>
        /// Performs the provided action on each binary tree value in post-order traversal order.
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void PostOrderTraversal(Action<TKey> action)
        {
            PostOrderTraversal(action, _root);
        }

        /// <summary>
        /// Performs the provided action on each binary tree value in in-order traversal order.
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void InOrderTraversal(Action<TKey> action)
        {
            InOrderTraversal(action, _root);
        }
       
        /// <summary>
        /// Enumerates the values contains in the binary tree in in-order traversal order.
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<TKey> InOrderTraversal()
        {
            // This is a non-recursive algorithm using a stack to demonstrate removing
            // recursion to make using the yield syntax easier.
            if (_root != null)
            {
                // store the nodes we've skipped in this stack (avoids recursion)
                Stack<Node> stack = new Stack<Node>();

                Node current = _root;

                // when removing recursion we need to keep track of whether or not
                // we should be going to the left node or the right nodes next.
                bool goLeftNext = true;

                // start by pushing Head onto the stack
                stack.Push(current);

                while (stack.Count > 0)
                {
                    // If we're heading left...
                    if (goLeftNext)
                    {
                        // push everything but the left-most node to the stack
                        // we'll yield the left-most after this block
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    // in-order is left->yield->right
                    yield return current.Key;

                    // if we can go right then do so
                    if (current.Right != null)
                    {
                        current = current.Right;

                        // once we've gone right once, we need to start
                        // going left again.
                        goLeftNext = true;
                    }
                    else
                    {
                        // if we can't go right then we need to pop off the parent node
                        // so we can process it and then go to it's right node
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that performs an in-order traversal of the binary tree
        /// </summary>
        /// <returns>The in-order enumerator</returns>
        public IEnumerator<TKey> GetEnumerator()
        {
            return InOrderTraversal();
        }

        /// <summary>
        /// Returns an enumerator that performs an in-order traversal of the binary tree
        /// </summary>
        /// <returns>The in-order enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Print()
        {
            Console.WriteLine($"\n====================================\n");
            _root.Print();
        }

        /// <summary>
        /// Determines if the specified value exists in the binary tree.
        /// </summary>
        private bool IsExist(Node r, TKey key)
        {
            if (r == null)
            {
                return false;
            }

            Node current = r;
            if (key.Equals(current.Key))
            {
                return true;
            }

            if (key.CompareTo(current.Key) < 0)
            {
                return IsExist(current.Left, key);
            }
            else
            {
                return IsExist(current.Right, key);
            }
        }

        /// <summary>
        /// Adds the value to the binary tree.
        /// </summary>
        private void Insert(ref Node r, TKey key)
        {
            if (r == null)
            {
                r = new Node() { Key = key };
            }
            else
            {
                Node current = r;
                if (key.CompareTo(current.Key) < 0)
                {
                    Insert(ref current.Left, key);
                    ///RotationRight(ref current);
                }
                else
                {
                    Insert(ref current.Right, key);
                    ////RotationLeft(ref current);
                }
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

        private void PreOrderTraversal(Action<TKey> action, Node node)
        {
            if (node != null)
            {
                action(node.Key);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }

        private void PostOrderTraversal(Action<TKey> action, Node node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Key);
            }
        }

        private void InOrderTraversal(Action<TKey> action, Node node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.Left);

                action(node.Key);

                InOrderTraversal(action, node.Right);
            }
        }

        // Class represents binary tree node
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

                if (current != null)
                {
                    Console.WriteLine($"{current.Key}<");
                }

                if (current != null)
                {
                    current.Left?.Print(++level);
                }
            }
        }
    }
}
