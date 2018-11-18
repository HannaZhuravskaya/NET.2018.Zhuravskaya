using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// Represents a binary search tree collection of objects.
    /// </summary>
    /// <typeparam name="T">
    /// Specifies the type of elements in the binary search tree.
    /// </typeparam>
    public class BinarySearchTree<T> : ICollection<T>
    {
        private readonly IComparer<T> _comparer;
        private int _version;
        private BinaryTreeNode<T> _root;

        /// <summary>
        /// Initializes an empty instance of the BinarySearchTree class.
        /// </summary>
        public BinarySearchTree()
        {
            _root = null;
            _comparer = Comparer<T>.Default;
            _version = 0;
            Count = 0;
        }

        /// <summary>
        /// Initializes an empty instance of the BinarySearchTree class.
        /// </summary>
        /// <param name="comparer">
        /// T type comparator.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// comparer is null.
        /// </exception>
        public BinarySearchTree(IComparer<T> comparer)
        {
            _root = null;
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            _version = 0;
            Count = 0;
        }

        /// <summary>
        /// Initializes a non-empty instance of the Binary Search Tree class.
        /// </summary>
        /// <param name="item">
        /// Class instance stores item.
        /// </param>
        public BinarySearchTree(T item)
        {
            _root = new BinaryTreeNode<T>(item);
            _comparer = Comparer<T>.Default;
            _version = 0;
            Count = 1;
        }

        /// <summary>
        /// Initializes a non-empty instance of the Binary Search Tree class.
        /// </summary>
        /// <param name="item">
        /// Class instance stores item.
        /// </param>
        /// <param name="comparer">
        /// T type comparator.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// comparer is null.
        /// </exception>
        public BinarySearchTree(T item, IComparer<T> comparer)
        {
            _root = new BinaryTreeNode<T>(item);
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            _version = 0;
            Count = 1;
        }

        /// <summary>
        /// Initializes a new instance of the BinarySearchTree class that contains elements copied from the specified collection. 
        /// </summary>
        /// <param name="collection">
        /// The collection whose elements are copied to the new BinarySearchTree.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// collection is null.
        /// </exception>
        public BinarySearchTree(IEnumerable<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            _root = null;
            _comparer = Comparer<T>.Default;
            _version = 0;
            Count = 0;

            foreach (var element in collection)
            {
                this.Add(element);
            }
        }

        /// <summary>
        /// Initializes a new instance of the BinarySearchTree class that contains elements copied from the specified collection. 
        /// </summary>
        /// <param name="collection">
        /// The collection whose elements are copied to the new BinarySearchTree.
        /// </param>
        /// <param name="comparer">
        /// T type comparator.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// collection  is null or comparer is null.
        /// </exception>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            _root = null;
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            _version = 0;
            Count = 0;

            foreach (var element in collection)
            {
                this.Add(element);
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the BinarySearchTree.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the BinarySearchTree.
        /// </returns>
        public int Count { get; private set; }

        bool ICollection<T>.IsReadOnly => false;

        /// <summary>
        /// In-order tree traversal.
        /// </summary>
        /// <returns>
        /// A IEnumerable'1 of BinarySearchTree.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The collection was modified after the enumerator was created.
        /// </exception>
        public IEnumerable<T> InorderTraversal()
        {
            return InorderTraversal(_root);
        }

        /// <summary>
        /// Pre-order tree traversal.
        /// </summary>
        /// <returns>
        /// A IEnumerable'1 of BinarySearchTree.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The collection was modified after the enumerator was created.
        /// </exception>
        public IEnumerable<T> PreorderTraversal()
        {
            return PreorderTraversal(_root);
        }

        /// <summary>
        /// Post-order tree traversal.
        /// </summary>
        /// <returns>
        /// A IEnumerable'1 of BinarySearchTree.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The collection was modified after the enumerator was created.
        /// </exception>
        public IEnumerable<T> PostorderTraversal()
        {
            return PostorderTraversal(_root);
        }

        /// <summary>
        /// Adds an object to BinarySearchTree if it is unique.
        /// </summary>
        /// <param name="item">
        /// The object to add to the BinarySearchTree. The value can be null for reference types.
        /// </param>
        public void Add(T item)
        {
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(item);
                _version++;
                Count++;
            }
            else
            {
                BinaryTreeNode<T> parent = null, current = _root;
                int comparerResult = -1;
                while (current != null)
                {
                    comparerResult = _comparer.Compare(item, current.Info);

                    if (comparerResult < 0)
                    {
                        parent = current;
                        current = current.Left;
                    }
                    else if (comparerResult > 0)
                    {
                        parent = current;
                        current = current.Right;
                    }
                    else
                    {
                        return;
                    }
                }

                if (comparerResult < 0)
                {
                    parent.Left = new BinaryTreeNode<T>(item, parent);
                    _version++;
                    Count++;
                }
                else if (comparerResult > 0)
                {
                    parent.Right = new BinaryTreeNode<T>(item, parent);
                    _version++;
                    Count++;
                }
            }
        }

        /// <summary>
        /// Removes all objects from the BinarySearchTree.
        /// </summary>
        public void Clear()
        {
            _root = null;
            _version++;
            Count = 0;
        }

        /// <summary>
        /// Determines whether an element is in the BinarySearchTree.
        /// </summary>
        /// <param name="item">
        /// The object to locate in the BinarySearchTree. The value can be null for reference types.
        /// </param>
        /// <returns>
        /// true if item is found in the BinarySearchTree; otherwise, false.
        /// </returns>
        public bool Contains(T item)
        {
            var current = Find(item);

            if (current == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Copies the BinarySearchTree elements to an existing one-dimensional System.Array, starting at the specified array index.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional System.Array that is the destination of the elements copied from BinarySearchTree. The System.Array must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">
        /// The zero-based index in array at which copying begins.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// array is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// arrayIndex is less than zero.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The number of elements in the source BinarySearchTree is greater than the available space from arrayIndex to the end of the destination array.
        /// </exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentException(nameof(arrayIndex));
            }

            foreach (var node in this)
            {
                array[arrayIndex] = node;
                arrayIndex++;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the BinarySearchTree.
        /// </summary>
        /// <returns>
        /// A IEnumerator'1 for the BinarySearchTree.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return PreorderTraversal().GetEnumerator();
        }
        
        /// <summary>
        /// Removes the node with the specified element from the BinarySearchTree.
        /// </summary>
        /// <param name="item">
        /// item to remove.
        /// </param>
        /// <returns>
        ///  true if the element is successfully found and removed; otherwise, false. This method returns false if item is not found in the BinarySearchTree.
        /// </returns>
        public bool Remove(T item)
        {
            var current = Find(item);
            if (current is null)
            {
                return false;
            }

            var parent = current.Parent;
            Count--;
            _version++;

            if (current.Left == null || current.Right == null)
            {
                RemoveNodeWithOneOrZeroSubtree(parent, current.Right ?? current.Left, current.Info);
            }
            else
            {
                current.Info = FindNodeToReplace(current.Right);
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> InorderTraversal(BinaryTreeNode<T> node)
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            var current = node;
            var currentVersion = this._version;

            while (current != null || stack.Count != 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();

                if (_version != currentVersion)
                {
                    throw new InvalidOperationException(nameof(_version));
                }

                yield return current.Info;

                current = current.Right;
            }
        }

        private IEnumerable<T> PreorderTraversal(BinaryTreeNode<T> node)
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            var current = node;
            var currentVersion = this._version;

            while (current != null || stack.Count != 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    yield return current.Info;
                    current = current.Left;
                }

                current = stack.Pop();

                if (_version != currentVersion)
                {
                    throw new InvalidOperationException(nameof(_version));
                }

                current = current.Right;
            }
        }

        private IEnumerable<T> PostorderTraversal(BinaryTreeNode<T> node)
        {
            var dict = new Dictionary<BinaryTreeNode<T>, BinaryTreeNode<T>> { [node] = null };
            var currentVersion = _version;

            while (node != null)
            {
                if (node.Left != null && !dict.ContainsKey(node.Left))
                {
                    dict[node.Left] = node;
                    node = node.Left;
                }
                else if (node.Right != null && !dict.ContainsKey(node.Right))
                {
                    dict[node.Right] = node;
                    node = node.Right;
                }
                else
                {
                    if (_version != currentVersion)
                    {
                        throw new InvalidOperationException(nameof(_version));
                    }

                    yield return node.Info;
                    dict.TryGetValue(node, out node);
                }
            }
        }

        private BinaryTreeNode<T> Find(T item)
        {
            if (_root == null)
            {
                return null;
            }

            var current = _root;

            int comparerResult = -1;
            while (comparerResult != 0)
            {
                comparerResult = _comparer.Compare(current.Info, item);

                if (comparerResult > 0)
                {
                    current = current.Left;
                }
                else if (comparerResult < 0)
                {
                    current = current.Right;
                }

                if (current == null)
                {
                    return null;
                }
            }

            return current;
        }

        private void RemoveNodeWithOneOrZeroSubtree(BinaryTreeNode<T> parent, BinaryTreeNode<T> nodeToPaste, T itemToRemove)
        {
            if (parent == null)
            {
                _root = nodeToPaste;
                if (nodeToPaste != null)
                {
                    nodeToPaste.Parent = null;
                }
            }
            else
            {
                int comparerResult = _comparer.Compare(parent.Info, itemToRemove);
                if (comparerResult > 0)
                {
                    parent.Left = nodeToPaste;
                    if (nodeToPaste != null)
                    {
                        nodeToPaste.Parent = parent;
                    }
                }
                else if (comparerResult < 0)
                {
                    parent.Right = nodeToPaste;
                    if (nodeToPaste != null)
                    {
                        nodeToPaste.Parent = parent;
                    }
                }
            }
        }

        private T FindNodeToReplace(BinaryTreeNode<T> current)
        {
            var parent = current.Parent;
            while (current.Left != null)
            {
                current = current.Left;
            }

            T result = current.Info;
            RemoveNodeWithOneOrZeroSubtree(current.Parent, current.Right, current.Info);

            return result;
        }
    }
}