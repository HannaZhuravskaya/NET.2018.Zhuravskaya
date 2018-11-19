using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region BinarySearchTree.ConstructorWithoutParameters

        [Test]
        public void BinarySearchTree_IntegerTreeWithDefaultComparer_NewTree()
        {
            var tree = new BinarySearchTree<int>();

            Assert.IsTrue(tree.Count == 0);
        }

        [Test]
        public void BinarySearchTree_IntegerTreeWithComparer_NewTree()
        {
            var comparer = Comparer<int>.Create((x, y) => x.ToString().Length - y.ToString().Length);
            var tree = new BinarySearchTree<int>(comparer);

            Assert.IsTrue(tree.Count == 0);
        }

        [Test]
        public void BinarySearchTree_StringTreeWithDefaultComparer_NewTree()
        {
            var tree = new BinarySearchTree<string>();

            Assert.IsTrue(tree.Count == 0);
        }

        [Test]
        public void BinarySearchTree_StringTreeWithComparer_NewTree()
        {
            var comparer = Comparer<string>.Create((x, y) => x.Length - y.Length);
            var tree = new BinarySearchTree<string>(comparer);

            Assert.IsTrue(tree.Count == 0);
        }

        [Test]
        public void BinarySearchTree_PointTreeWithDefaultComparer_ExpectedArgumentException()
            => Assert.Throws<ArgumentException>(() => new BinarySearchTree<Point>());

        [Test]
        public void BinarySearchTree_PointTreeWithComparer_NewTree()
        {
            var comparer = Comparer<Point>.Create((x, y) => x.Y - y.Y);
            var tree = new BinarySearchTree<Point>(comparer);

            Assert.IsTrue(tree.Count == 0);
        }

        #endregion

        #region BinarySearchTree.Add

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] {1, 2, 3, 4}, new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {1, 1, 1, 1, 1, 1}, new int[] {1})]
        public void Add_IntegerTreeWithDefaultComparer_TreeWithAddedNodes(int[] nodes, int[] expectedArray)
        {
            var tree = new BinarySearchTree<int>(BinarySearchTree<int>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            var resultArray = tree.ToArray();
            CollectionAssert.AreEqual(expectedArray, resultArray);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] {1, 2, 3, 4}, new int[] {1})]
        [TestCase(new int[] {100, 10, 1000}, new int[] {100, 10, 1000})]
        public void Add_IntegerTreeWithComparer_TreeWithAddedNodes(int[] nodes, int[] expectedArray)
        {
            var comparer = Comparer<int>.Create((x, y) => x.ToString().Length - y.ToString().Length);
            var tree = new BinarySearchTree<int>(comparer, BinarySearchTree<int>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            var resultArray = tree.ToArray();
            CollectionAssert.AreEqual(expectedArray, resultArray);
        }

        [TestCase("ab b a ba", "ab a b ba")]
        [TestCase("a a a a", "a")]
        public void Add_StringTreeWithDefaultComparer_TreeWithAddedNodes(string inputNodes, string expectedNodes)
        {
            var nodes = inputNodes.Split(' ');
            var tree = new BinarySearchTree<string>(BinarySearchTree<string>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            var expectedArray = expectedNodes.Split(' ');

            var resultArray = tree.ToArray();

            CollectionAssert.AreEqual(expectedArray, resultArray);
        }

        [TestCase("ab b a ba", "ab b")]
        [TestCase("a a a a", "a")]
        public void Add_StringTreeWithComparer_TreeWithAddedNodes(string inputNodes, string expectedNodes)
        {
            var nodes = inputNodes.Split(' ');
            var comparer = Comparer<string>.Create((x, y) => x.Length - y.Length);
            var tree = new BinarySearchTree<string>(comparer, BinarySearchTree<string>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            var expectedArray = expectedNodes.Split(' ');

            var resultArray = tree.ToArray();

            CollectionAssert.AreEqual(expectedArray, resultArray);
        }

        [TestCase("Title2 Title1 Title3", "Title2 Author2", "Title3 Author3", "Title1 Author1")]
        [TestCase("Title1", "Title1 Author1", "Title1 Author2", "Title1 Author3")]
        public void Add_BookTreeWithDefaultComparer_TreeWithAddedNodes(string expectedNodes, params string[] inputNodes)
        {
            var nodes = new List<string[]>();
            foreach (var node in inputNodes.Select(element => element.Split(' ')))
            {
                nodes.Add(node);
            }

            var tree = new BinarySearchTree<Book>(BinarySearchTree<Book>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(new Book(node[0], node[1]));
            }

            var expectedArray = expectedNodes.Split(' ');

            var resultArray = tree.ToArray();

            CollectionAssert.AreEqual(expectedArray, resultArray.Select(element => element.Title));
        }

        [TestCase("Title2 Title2 Title2", "Title2 Author2", "Title2 Author1", "Title2 Author3")]
        [TestCase("Title2", "Title2 Author1", "Title3 Author1", "Title1 Author1")]
        public void Add_BookTreeWithComparer_TreeWithAddedNodes(string expectedNodes, params string[] inputNodes)
        {
            var nodes = new List<string[]>();
            foreach (var node in inputNodes.Select(element => element.Split(' ')))
            {
                nodes.Add(node);
            }

            var comparer =
                Comparer<Book>.Create((x, y) => string.Compare(x.Author, y.Author, StringComparison.Ordinal));
            var tree = new BinarySearchTree<Book>(comparer, BinarySearchTree<Book>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(new Book(node[0], node[1]));
            }

            var expectedArray = expectedNodes.Split(' ');

            var resultArray = tree.ToArray();

            CollectionAssert.AreEqual(expectedArray, resultArray.Select(element => element.Title));
        }

        [TestCase(new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, "(1;1) (1;2) (1;3) (1;4)")]
        [TestCase(new int[] {1, 2, 3, 4}, new int[] {1, 1, 1, 1}, "(1;1)")]
        public void Add_PointTreeWithComparer_TreeWithAddedNodes(int[] nodesX, int[] nodesY, string expectedInput)
        {
            var comparer = Comparer<Point>.Create((x, y) => x.Y - y.Y);
            var tree = new BinarySearchTree<Point>(comparer, BinarySearchTree<Point>.Traversal.PreOrder);
            for (int i = 0; i < nodesX.Length; ++i)
            {
                tree.Add(new Point(nodesX[i], nodesY[i]));
            }

            var expectedArray = expectedInput.Split(' ');

            var resultArray = tree.ToArray();

            CollectionAssert.AreEqual(expectedArray, resultArray.Select(element => element.ToString()));
        }

        #endregion

        #region BinarySearchTree.Count

        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new int[] {1, 2, 3, 4}, ExpectedResult = 4)]
        [TestCase(new int[] {1, 1, 1, 1, 1, 1}, ExpectedResult = 1)]
        public int Count_IntegerTreeWithDefaultComparer_TreeCount(int[] nodes)
        {
            var tree = new BinarySearchTree<int>(BinarySearchTree<int>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            return tree.Count;
        }

        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new int[] {1, 2, 3, 4}, ExpectedResult = 1)]
        [TestCase(new int[] {100, 10, 1000}, ExpectedResult = 3)]
        public int Count_IntegerTreeWithComparer_TreeCount(int[] nodes)
        {
            var comparer = Comparer<int>.Create((x, y) => x.ToString().Length - y.ToString().Length);
            var tree = new BinarySearchTree<int>(comparer, BinarySearchTree<int>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            return tree.Count;
        }

        [TestCase("ab b a ba", ExpectedResult = 4)]
        [TestCase("a a a a", ExpectedResult = 1)]
        public int Count_StringTreeWithDefaultComparer_TreeCount(string inputNodes)
        {
            var nodes = inputNodes.Split(' ');
            var tree = new BinarySearchTree<string>(BinarySearchTree<string>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            return tree.Count;
        }

        [TestCase("ab b a ba", ExpectedResult = 2)]
        [TestCase("a a a a", ExpectedResult = 1)]
        public int Count_StringTreeWithComparer_TreeCount(string inputNodes)
        {
            var nodes = inputNodes.Split(' ');
            var comparer = Comparer<string>.Create((x, y) => x.Length - y.Length);
            var tree = new BinarySearchTree<string>(comparer, BinarySearchTree<string>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            return tree.Count;
        }

        [TestCase("Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = 3)]
        [TestCase("Title1 Author1", "Title1 Author2", "Title1 Author3", ExpectedResult = 1)]
        public int Count_BookTreeWithDefaultComparer_TreeCount(params string[] inputNodes)
        {
            var nodes = new List<string[]>();
            foreach (var node in inputNodes.Select(element => element.Split(' ')))
            {
                nodes.Add(node);
            }

            var tree = new BinarySearchTree<Book>(BinarySearchTree<Book>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(new Book(node[0], node[1]));
            }

            return tree.Count;
        }

        [TestCase("Title2 Author2", "Title2 Author1", "Title2 Author3", ExpectedResult = 3)]
        [TestCase("Title2 Author1", "Title3 Author1", "Title1 Author1", ExpectedResult = 1)]
        public int Count_BookTreeWithComparer_TreeCount(params string[] inputNodes)
        {
            var nodes = new List<string[]>();
            foreach (var node in inputNodes.Select(element => element.Split(' ')))
            {
                nodes.Add(node);
            }

            var comparer =
                Comparer<Book>.Create((x, y) => string.Compare(x.Author, y.Author, StringComparison.Ordinal));
            var tree = new BinarySearchTree<Book>(comparer, BinarySearchTree<Book>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(new Book(node[0], node[1]));
            }

            return tree.Count;
        }

        [TestCase(new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, ExpectedResult = 4)]
        [TestCase(new int[] {1, 2, 3, 4}, new int[] {1, 1, 1, 1}, ExpectedResult = 1)]
        public int Count_PointTreeWithComparer_TreeCount(int[] nodesX, int[] nodesY)
        {
            var comparer = Comparer<Point>.Create((x, y) => x.Y - y.Y);
            var tree = new BinarySearchTree<Point>(comparer, BinarySearchTree<Point>.Traversal.PreOrder);
            for (int i = 0; i < nodesX.Length; ++i)
            {
                tree.Add(new Point(nodesX[i], nodesY[i]));
            }

            return tree.Count;
        }

        #endregion

        #region BinarySearchTree.Clear

        [TestCase(new int[] { })]
        [TestCase(new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {1, 1, 1, 1, 1, 1})]
        public void Clear_IntegerTreeWithDefaultComparer_EmptyTree(int[] nodes)
        {
            var tree = new BinarySearchTree<int>(BinarySearchTree<int>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            tree.Clear();

            Assert.IsTrue(tree.Count == 0);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {100, 10, 1000})]
        public void Clear_IntegerTreeWithComparer_EmptyTree(int[] nodes)
        {
            var comparer = Comparer<int>.Create((x, y) => x.ToString().Length - y.ToString().Length);
            var tree = new BinarySearchTree<int>(comparer, BinarySearchTree<int>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            tree.Clear();

            Assert.IsTrue(tree.Count == 0);
        }

        [TestCase("ab b a ba")]
        [TestCase("a a a a")]
        public void Clear_StringTreeWithDefaultComparer_EmptyTree(string inputNodes)
        {
            var nodes = inputNodes.Split(' ');
            var tree = new BinarySearchTree<string>(BinarySearchTree<string>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            tree.Clear();

            Assert.IsTrue(tree.Count == 0);
        }

        [TestCase("ab b a ba")]
        [TestCase("a a a a")]
        public void Clear_StringTreeWithComparer_EmptyTree(string inputNodes)
        {
            var nodes = inputNodes.Split(' ');
            var comparer = Comparer<string>.Create((x, y) => x.Length - y.Length);
            var tree = new BinarySearchTree<string>(comparer, BinarySearchTree<string>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            tree.Clear();

            Assert.IsTrue(tree.Count == 0);
        }

        [TestCase("Title2 Author2", "Title3 Author3", "Title1 Author1")]
        [TestCase("Title1 Author1", "Title1 Author2", "Title1 Author3")]
        public void Clear_BookTreeWithDefaultComparer_EmptyTree(params string[] inputNodes)
        {
            var nodes = new List<string[]>();
            foreach (var node in inputNodes.Select(element => element.Split(' ')))
            {
                nodes.Add(node);
            }

            var tree = new BinarySearchTree<Book>(BinarySearchTree<Book>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(new Book(node[0], node[1]));
            }

            tree.Clear();

            Assert.IsTrue(tree.Count == 0);
        }

        [TestCase("Title2 Author2", "Title2 Author1", "Title2 Author3")]
        [TestCase("Title2 Author1", "Title3 Author1", "Title1 Author1")]
        public void Clear_BookTreeWithComparer_EmptyTree(params string[] inputNodes)
        {
            var nodes = new List<string[]>();
            foreach (var node in inputNodes.Select(element => element.Split(' ')))
            {
                nodes.Add(node);
            }

            var comparer =
                Comparer<Book>.Create((x, y) => string.Compare(x.Author, y.Author, StringComparison.Ordinal));
            var tree = new BinarySearchTree<Book>(comparer, BinarySearchTree<Book>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(new Book(node[0], node[1]));
            }

            tree.Clear();

            Assert.IsTrue(tree.Count == 0);
        }

        [TestCase(new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {1, 2, 3, 4}, new int[] {1, 1, 1, 1})]
        public void Clear_PointTreeWithComparer_TreeWithAddedNodes(int[] nodesX, int[] nodesY)
        {
            var comparer = Comparer<Point>.Create((x, y) => x.Y - y.Y);
            var tree = new BinarySearchTree<Point>(comparer, BinarySearchTree<Point>.Traversal.PreOrder);
            for (int i = 0; i < nodesX.Length; ++i)
            {
                tree.Add(new Point(nodesX[i], nodesY[i]));
            }

            tree.Clear();

            Assert.IsTrue(tree.Count == 0);
        }

        #endregion

        #region BinarySearchTree.Contains

        [TestCase(1, new int[] { }, ExpectedResult = false)]
        [TestCase(2, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase(1, new int[] {1, 1, 1, 1, 1, 1}, ExpectedResult = true)]
        [TestCase(3, new int[] {1, 1, 1, 1, 1, 1}, ExpectedResult = false)]
        public bool Contains_IntegerTreeWithDefaultComparer_IsNodeInTheTree(int nodeToSearch, int[] nodes)
        {
            var tree = new BinarySearchTree<int>(BinarySearchTree<int>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            return tree.Contains(nodeToSearch);
        }

        [TestCase(1, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase(5, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase(1234, new int[] {100, 10, 1000}, ExpectedResult = true)]
        [TestCase(12, new int[] {100, 10, 1000}, ExpectedResult = true)]
        [TestCase(10000, new int[] {100, 10, 1000}, ExpectedResult = false)]
        public bool Contains_IntegerTreeWithComparer_IsNodeInTheTree(int nodeToSearch, int[] nodes)
        {
            var comparer = Comparer<int>.Create((x, y) => x.ToString().Length - y.ToString().Length);
            var tree = new BinarySearchTree<int>(comparer, BinarySearchTree<int>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            return tree.Contains(nodeToSearch);
        }

        [TestCase("ab", "ab b a ba", ExpectedResult = true)]
        [TestCase("a", "ab b a ba", ExpectedResult = true)]
        [TestCase("bb", "ab b a ba", ExpectedResult = false)]
        [TestCase("a", "a a a a", ExpectedResult = true)]
        public bool Contains_StringTreeWithDefaultComparer_IsNodeInTheTree(string nodeToSearch, string inputNodes)
        {
            var nodes = inputNodes.Split(' ');
            var tree = new BinarySearchTree<string>(BinarySearchTree<string>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            return tree.Contains(nodeToSearch);
        }

        [TestCase("ab", "ab b a ba", ExpectedResult = true)]
        [TestCase("cc", "ab b a ba", ExpectedResult = true)]
        [TestCase("c", "ab b a ba", ExpectedResult = true)]
        [TestCase("aaa", "ab b a ba", ExpectedResult = false)]
        [TestCase("c", "a a a a", ExpectedResult = true)]
        public bool Contains_StringTreeWithComparer_IsNodeInTheTree(string nodeToSearch, string inputNodes)
        {
            var nodes = inputNodes.Split(' ');
            var comparer = Comparer<string>.Create((x, y) => x.Length - y.Length);
            var tree = new BinarySearchTree<string>(comparer, BinarySearchTree<string>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            return tree.Contains(nodeToSearch);
        }

        [TestCase("Title2 Author444", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title1 Author444", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title3 Author444", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title Author444", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = false)]
        public bool Contains_BookTreeWithDefaultComparer_IsNodeInTheTree(
            string inputToSearch,
            params string[] inputNodes)
        {
            var nodes = new List<string[]>();
            foreach (var node in inputNodes.Select(element => element.Split(' ')))
            {
                nodes.Add(node);
            }

            var tree = new BinarySearchTree<Book>(BinarySearchTree<Book>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(new Book(node[0], node[1]));
            }

            var bookToSearch = inputToSearch.Split(' ');
            var nodeToSearch = new Book(bookToSearch[0], bookToSearch[1]);

            return tree.Contains(nodeToSearch);
        }

        [TestCase("Title444 Author1", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title444 Author2", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title444 Author3", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title444 Author", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = false)]
        public bool Contains_BookTreeWithComparer_IsNodeInTheTree(string inputToSearch, params string[] inputNodes)
        {
            var nodes = new List<string[]>();
            foreach (var node in inputNodes.Select(element => element.Split(' ')))
            {
                nodes.Add(node);
            }

            var comparer =
                Comparer<Book>.Create((x, y) => string.Compare(x.Author, y.Author, StringComparison.Ordinal));
            var tree = new BinarySearchTree<Book>(comparer, BinarySearchTree<Book>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(new Book(node[0], node[1]));
            }

            var bookToSearch = inputToSearch.Split(' ');
            var nodeToSearch = new Book(bookToSearch[0], bookToSearch[1]);

            return tree.Contains(nodeToSearch);
        }

        [TestCase("5 1", new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase("5 2", new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase("5 3", new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase("5 4", new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase("1 5", new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, ExpectedResult = false)]
        [TestCase("6 1", new int[] {1, 2, 3, 4}, new int[] {1, 1, 1, 1}, ExpectedResult = true)]
        public bool Contains_PointTreeWithComparer_IsNodeInTheTree(string inputToSearch, int[] nodesX, int[] nodesY)
        {
            var comparer = Comparer<Point>.Create((x, y) => x.Y - y.Y);
            var tree = new BinarySearchTree<Point>(comparer, BinarySearchTree<Point>.Traversal.PreOrder);
            for (int i = 0; i < nodesX.Length; ++i)
            {
                tree.Add(new Point(nodesX[i], nodesY[i]));
            }

            var pointToSearch = inputToSearch.Split(' ');
            var nodeToSearch = new Point(int.Parse(pointToSearch[0]), int.Parse(pointToSearch[1]));

            return tree.Contains(nodeToSearch);
        }

        #endregion

        #region BinarySearchTree.Remove

        [TestCase(1, new int[] { }, ExpectedResult = false)]
        [TestCase(2, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase(1, new int[] {1, 1, 1, 1, 1, 1}, ExpectedResult = true)]
        [TestCase(3, new int[] {1, 1, 1, 1, 1, 1}, ExpectedResult = false)]
        public bool Remove_IntegerTreeWithDefaultComparer_ResultOfRemoving(int nodeToRemove, int[] nodes)
        {
            var tree = new BinarySearchTree<int>(BinarySearchTree<int>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            var isNodeInTheTree = tree.Contains(nodeToRemove);
            var countBeforeRemoving = tree.Count;

            tree.Remove(nodeToRemove);

            if (isNodeInTheTree && countBeforeRemoving == tree.Count + 1 && !tree.Contains(nodeToRemove))
            {
                return true;
            }

            if (!isNodeInTheTree && countBeforeRemoving == tree.Count)
            {
                return false;
            }

            throw new InvalidOperationException();
        }

        [TestCase(1, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase(5, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase(1234, new int[] {100, 10, 1000}, ExpectedResult = true)]
        [TestCase(12, new int[] {100, 10, 1000}, ExpectedResult = true)]
        [TestCase(10000, new int[] {100, 10, 1000}, ExpectedResult = false)]
        public bool Remove_IntegerTreeWithComparer_ResultOfRemoving(int nodeToRemove, int[] nodes)
        {
            var comparer = Comparer<int>.Create((x, y) => x.ToString().Length - y.ToString().Length);
            var tree = new BinarySearchTree<int>(comparer, BinarySearchTree<int>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            var isNodeInTheTree = tree.Contains(nodeToRemove);
            var countBeforeRemoving = tree.Count;

            tree.Remove(nodeToRemove);

            if (isNodeInTheTree && countBeforeRemoving == tree.Count + 1 && !tree.Contains(nodeToRemove))
            {
                return true;
            }

            if (!isNodeInTheTree && countBeforeRemoving == tree.Count)
            {
                return false;
            }

            throw new InvalidOperationException();
        }

        [TestCase("ab", "ab b a ba", ExpectedResult = true)]
        [TestCase("a", "ab b a ba", ExpectedResult = true)]
        [TestCase("bb", "ab b a ba", ExpectedResult = false)]
        [TestCase("a", "a a a a", ExpectedResult = true)]
        public bool Remove_StringTreeWithDefaultComparer_ResultOfRemoving(string nodeToRemove, string inputNodes)
        {
            var nodes = inputNodes.Split(' ');
            var tree = new BinarySearchTree<string>(BinarySearchTree<string>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            var isNodeInTheTree = tree.Contains(nodeToRemove);
            var countBeforeRemoving = tree.Count;

            tree.Remove(nodeToRemove);

            if (isNodeInTheTree && countBeforeRemoving == tree.Count + 1 && !tree.Contains(nodeToRemove))
            {
                return true;
            }

            if (!isNodeInTheTree && countBeforeRemoving == tree.Count)
            {
                return false;
            }

            throw new InvalidOperationException();
        }

        [TestCase("ab", "ab b a ba", ExpectedResult = true)]
        [TestCase("cc", "ab b a ba", ExpectedResult = true)]
        [TestCase("c", "ab b a ba", ExpectedResult = true)]
        [TestCase("aaa", "ab b a ba", ExpectedResult = false)]
        [TestCase("c", "a a a a", ExpectedResult = true)]
        public bool Remove_StringTreeWithComparer_ResultOfRemoving(string nodeToRemove, string inputNodes)
        {
            var nodes = inputNodes.Split(' ');
            var comparer = Comparer<string>.Create((x, y) => x.Length - y.Length);
            var tree = new BinarySearchTree<string>(comparer, BinarySearchTree<string>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(node);
            }

            var isNodeInTheTree = tree.Contains(nodeToRemove);
            var countBeforeRemoving = tree.Count;

            tree.Remove(nodeToRemove);

            if (isNodeInTheTree && countBeforeRemoving == tree.Count + 1 && !tree.Contains(nodeToRemove))
            {
                return true;
            }

            if (!isNodeInTheTree && countBeforeRemoving == tree.Count)
            {
                return false;
            }

            throw new InvalidOperationException();
        }

        [TestCase("Title2 Author444", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title1 Author444", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title3 Author444", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title Author444", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = false)]
        public bool Remove_BookTreeWithDefaultComparer_ResultOfRemoving(
            string inputToRemove,
            params string[] inputNodes)
        {
            var nodes = new List<string[]>();
            foreach (var node in inputNodes.Select(element => element.Split(' ')))
            {
                nodes.Add(node);
            }

            var tree = new BinarySearchTree<Book>(BinarySearchTree<Book>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(new Book(node[0], node[1]));
            }

            var bookToRemove = inputToRemove.Split(' ');
            var nodeToRemove = new Book(bookToRemove[0], bookToRemove[1]);

            var isNodeInTheTree = tree.Contains(nodeToRemove);
            var countBeforeRemoving = tree.Count;

            tree.Remove(nodeToRemove);

            if (isNodeInTheTree && countBeforeRemoving == tree.Count + 1 && !tree.Contains(nodeToRemove))
            {
                return true;
            }

            if (!isNodeInTheTree && countBeforeRemoving == tree.Count)
            {
                return false;
            }

            throw new InvalidOperationException();
        }

        [TestCase("Title444 Author1", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title444 Author2", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title444 Author3", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = true)]
        [TestCase("Title444 Author", "Title2 Author2", "Title3 Author3", "Title1 Author1", ExpectedResult = false)]
        public bool Remove_BookTreeWithComparer_ResultOfRemoving(string inputToRemove, params string[] inputNodes)
        {
            var nodes = new List<string[]>();
            foreach (var node in inputNodes.Select(element => element.Split(' ')))
            {
                nodes.Add(node);
            }

            var comparer =
                Comparer<Book>.Create((x, y) => string.Compare(x.Author, y.Author, StringComparison.Ordinal));
            var tree = new BinarySearchTree<Book>(comparer, BinarySearchTree<Book>.Traversal.PreOrder);
            foreach (var node in nodes)
            {
                tree.Add(new Book(node[0], node[1]));
            }

            var bookToRemove = inputToRemove.Split(' ');
            var nodeToRemove = new Book(bookToRemove[0], bookToRemove[1]);

            var isNodeInTheTree = tree.Contains(nodeToRemove);
            var countBeforeRemoving = tree.Count;

            tree.Remove(nodeToRemove);

            if (isNodeInTheTree && countBeforeRemoving == tree.Count + 1 && !tree.Contains(nodeToRemove))
            {
                return true;
            }

            if (!isNodeInTheTree && countBeforeRemoving == tree.Count)
            {
                return false;
            }

            throw new InvalidOperationException();
        }

        [TestCase("5 1", new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase("5 2", new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase("5 3", new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase("5 4", new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, ExpectedResult = true)]
        [TestCase("1 5", new int[] {1, 1, 1, 1}, new int[] {1, 2, 3, 4}, ExpectedResult = false)]
        [TestCase("6 1", new int[] {1, 2, 3, 4}, new int[] {1, 1, 1, 1}, ExpectedResult = true)]
        public bool Remove_PointTreeWithComparer_ResultOfRemoving(string inputToRemove, int[] nodesX, int[] nodesY)
        {
            var comparer = Comparer<Point>.Create((x, y) => x.Y - y.Y);
            var tree = new BinarySearchTree<Point>(comparer, BinarySearchTree<Point>.Traversal.PreOrder);
            for (int i = 0; i < nodesX.Length; ++i)
            {
                tree.Add(new Point(nodesX[i], nodesY[i]));
            }

            var pointToRemove = inputToRemove.Split(' ');
            var nodeToRemove = new Point(int.Parse(pointToRemove[0]), int.Parse(pointToRemove[1]));

            var isNodeInTheTree = tree.Contains(nodeToRemove);
            var countBeforeRemoving = tree.Count;

            tree.Remove(nodeToRemove);

            if (isNodeInTheTree && countBeforeRemoving == tree.Count + 1 && !tree.Contains(nodeToRemove))
            {
                return true;
            }

            if (!isNodeInTheTree && countBeforeRemoving == tree.Count)
            {
                return false;
            }

            throw new InvalidOperationException();
        }

        #endregion
    }
}