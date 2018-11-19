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
    public class BinarySearchTree<T> : IEnumerable, IEnumerable<T>
    {
        private readonly IComparer<T> _comparer;
        private int _version;
        private BinaryTreeNode _root;

        #region BinarySearchTree.Constructors

        /// <summary>
        /// Initializes an empty instance of the BinarySearchTree class.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// T type does not have a default comparison rule.
        /// </exception>
        public BinarySearchTree() : this(true, null)
        {
        }

        /// <summary>
        /// Initializes an empty instance of the BinarySearchTree class.
        /// </summary>
        /// <param name="traversal">
        /// A constant that determines how to traverse the BinarySearchTree.
        /// </param>
        /// <exception cref="ArgumentException">
        /// T type does not have a default comparison rule.
        /// </exception>
        public BinarySearchTree(Traversal traversal) : this(true, null, traversal)
        {
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
        public BinarySearchTree(IComparer<T> comparer) : this(false, comparer)
        {
        }

        /// <summary>
        /// Initializes an empty instance of the BinarySearchTree class.
        /// </summary>
        /// <param name="comparer">
        /// T type comparator.
        /// </param>
        /// <param name="traversal">
        /// A constant that determines how to traverse the BinarySearchTree.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// comparer is null.
        /// </exception>
        public BinarySearchTree(IComparer<T> comparer, Traversal traversal) : this(false, comparer, traversal)
        {
        }

        /// <summary>
        /// Initializes a non-empty instance of the Binary Search Tree class.
        /// </summary>
        /// <param name="item">
        /// Class instance stores item.
        /// </param>
        /// <exception cref="ArgumentException">
        /// T type does not have a default comparison rule.
        /// </exception>
        public BinarySearchTree(T item) : this(true, null)
        {
            _root = new BinaryTreeNode(item);
        }

        /// <summary>
        /// Initializes a non-empty instance of the Binary Search Tree class.
        /// </summary>
        /// <param name="item">
        /// Class instance stores item.
        /// </param>
        /// <param name="traversal">
        /// A constant that determines how to traverse the BinarySearchTree.
        /// </param>
        /// <exception cref="ArgumentException">
        /// T type does not have a default comparison rule.
        /// </exception>
        public BinarySearchTree(T item, Traversal traversal) : this(true, null, traversal)
        {
            _root = new BinaryTreeNode(item);
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
        public BinarySearchTree(T item, IComparer<T> comparer) : this(false, comparer)
        {
            _root = new BinaryTreeNode(item);
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
        /// <param name="traversal">
        /// A constant that determines how to traverse the BinarySearchTree.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// comparer is null.
        /// </exception>
        public BinarySearchTree(T item, IComparer<T> comparer, Traversal traversal) : this(false, comparer, traversal)
        {
            _root = new BinaryTreeNode(item);
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
        /// <exception cref="ArgumentException">
        /// T type does not have a default comparison rule.
        /// </exception>
        public BinarySearchTree(IEnumerable<T> collection) : this(collection, true, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BinarySearchTree class that contains elements copied from the specified collection. 
        /// </summary>
        /// <param name="collection">
        /// The collection whose elements are copied to the new BinarySearchTree.
        /// </param>
        /// <param name="traversal">
        /// A constant that determines how to traverse the BinarySearchTree.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// collection is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// T type does not have a default comparison rule.
        /// </exception>
        public BinarySearchTree(IEnumerable<T> collection, Traversal traversal) : 
            this(collection, true, null, traversal)
        {
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
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer) : this(collection, false, comparer)
        {
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
        /// <param name="traversal">
        /// A constant that determines how to traverse the BinarySearchTree.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// collection  is null or comparer is null.
        /// </exception>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer, Traversal traversal) : this(
            collection, false, comparer, traversal)
        {
        }

        private BinarySearchTree(bool isDefaultComparer, IComparer<T> comparer, Traversal traversal = Traversal.Default)
        {
            _version = 0;
            Count = 0;

            if (isDefaultComparer)
            {
                var typeInterfaces = (IList)typeof(T).GetInterfaces();
                if (!typeInterfaces.Contains(typeof(IComparable)) && !typeInterfaces.Contains(typeof(IComparable<T>)))
                {
                    throw new ArgumentException();
                }

                _comparer = Comparer<T>.Default;
            }
            else
            {
                _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            }

            DefaultTraversal = traversal;
        }

        private BinarySearchTree(
            IEnumerable<T> collection, 
            bool isDefaultComparer, 
            IComparer<T> comparer,
            Traversal traversal = Traversal.Default) : this(isDefaultComparer, comparer, traversal)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (var element in collection)
            {
                this.Add(element);
            }
        }

        #endregion

        #region BinarySearchTree.Traversal

        public enum Traversal
        {
            Default = 1,
            InOrder = 1,
            PreOrder = 2,
            PostOrder = 3
        }

        #endregion

        #region BinarySearchTree.Properties

        /// <summary>
        /// Gets the number of elements contained in the BinarySearchTree.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the BinarySearchTree.
        /// </returns>
        public int Count { get; private set; }

        /// <summary>
        /// Determines whether BinarySearchTree is empty.
        /// </summary>
        /// <returns>
        /// true if BinarySearchTree is empty; otherwise, false.
        /// </returns>
        public bool IsEmpty => _root == null;

        /// <summary>
        /// A constant that determines how to traverse the BinarySearchTree.
        /// </summary>
        /// <returns>
        /// A constant that determines how to traverse the BinarySearchTree.
        /// </returns>
        public Traversal DefaultTraversal { get; set; }

        #endregion

        #region BinarySearchTree.PublicMethods

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
                _root = new BinaryTreeNode(item);
                _version++;
                Count++;
            }
            else
            {
                BinaryTreeNode parent = null, current = _root;
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
                    parent.Left = new BinaryTreeNode(item, parent);
                    _version++;
                    Count++;
                }
                else if (comparerResult > 0)
                {
                    parent.Right = new BinaryTreeNode(item, parent);
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

        /// <summary>
        /// In-order tree traversal.
        /// </summary>
        /// <returns>
        /// A IEnumerable'1 of BinarySearchTree.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The collection was modified after the enumerator was created.
        /// </exception>
        public IEnumerable<T> InOrderTraversal()
        {
            return InOrderTraversal(_root);
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
        public IEnumerable<T> PreOrderTraversal()
        {
            return PreOrderTraversal(_root);
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
        public IEnumerable<T> PostOrderTraversal()
        {
            return PostOrderTraversal(_root);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the BinarySearchTree.
        /// </summary>
        /// <returns>
        /// A IEnumerator'1 for the BinarySearchTree.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            switch (DefaultTraversal)
            {
                case Traversal.InOrder:
                    return InOrderTraversal().GetEnumerator();
                case Traversal.PostOrder:
                    return PostOrderTraversal().GetEnumerator();
                case Traversal.PreOrder:
                    return PreOrderTraversal().GetEnumerator();
                default:
                    return InOrderTraversal().GetEnumerator();
            }
        }

        #endregion

        #region BinarySearchTree.ExplicitInterfacesImplementations

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region BinarySearchTree.PrivateMethods

        private IEnumerable<T> InOrderTraversal(BinaryTreeNode node)
        {
            Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
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

        private IEnumerable<T> PreOrderTraversal(BinaryTreeNode node)
        {
            Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
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

        private IEnumerable<T> PostOrderTraversal(BinaryTreeNode node)
        {
            var dict = new Dictionary<BinaryTreeNode, BinaryTreeNode> { [node] = null };
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

        private BinaryTreeNode Find(T item)
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

        private void RemoveNodeWithOneOrZeroSubtree(
            BinaryTreeNode parent, 
            BinaryTreeNode nodeToPaste,
            T itemToRemove)
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

        private T FindNodeToReplace(BinaryTreeNode current)
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

        #endregion

        #region BinarySearchTree.BinaryTreeNode

        /// <summary>
        /// Class contains node of binary search tree.
        /// </summary>
        private class BinaryTreeNode
        {
            #region BinaryTreeNode.Constructors

            /// <summary>
            /// Create an instance of BinaryTreeNode where parent, left and right nodes are null.
            /// </summary>
            /// <param name="info">
            /// Node information.
            /// </param>
            public BinaryTreeNode(T info)
            {
                Info = info;
            }

            /// <summary>
            /// Create an instance of BinaryTreeNode where left and right nodes are null.
            /// </summary>
            /// <param name="info"></param>
            /// <param name="parent">
            /// Parent node.
            /// </param>
            public BinaryTreeNode(T info, BinaryTreeNode parent) : this(info)
            {
                Parent = parent;
            }

            #endregion

            #region BinaryTreeNode.Properties

            /// <summary>
            /// Parent node.
            /// </summary>
            public BinaryTreeNode Parent { get; set; }

            /// <summary>
            /// Left node.
            /// </summary>
            public BinaryTreeNode Left { get; set; }

            /// <summary>
            /// Right node.
            /// </summary>
            public BinaryTreeNode Right { get; set; }

            /// <summary>
            /// Node information.
            /// </summary>
            public T Info { get; set; }

            #endregion

            #region BinaryTreeNode.PublicMethods

            public override string ToString()
            {
                return "node: " + Info + ", left: " + (Left != null ? Left.Info.ToString() : "null") + ", right: " +
                       (Right != null ? Right.Info.ToString() : "null");
            }

            #endregion
        }

        #endregion
    }
}