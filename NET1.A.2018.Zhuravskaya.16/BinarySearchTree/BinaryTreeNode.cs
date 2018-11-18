namespace BinarySearchTree
{
    /// <summary>
    /// Class contains node of binary search tree.
    /// </summary>
    /// <typeparam name="T">
    /// Type of information stored in the node.
    /// </typeparam>
    internal class BinaryTreeNode<T>
    {
        /// <summary>
        /// Create an instance of BinaryTreeNode where parent, left and right nodes are null.
        /// </summary>
        /// <param name="info">
        /// Node information.
        /// </param>
        public BinaryTreeNode(T info)
        {
            Info = info;
            Parent = null;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Create an instance of BinaryTreeNode where left and right nodes are null.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="parent">
        /// Parent node.
        /// </param>
        public BinaryTreeNode(T info, BinaryTreeNode<T> parent)
        {
            Info = info;
            Parent = parent;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Parent node.
        /// </summary>
        public BinaryTreeNode<T> Parent { get; set; }

        /// <summary>
        /// Left node.
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }

        /// <summary>
        /// Right node.
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        /// <summary>
        /// Node information.
        /// </summary>
        public T Info { get; set; }

        public override string ToString()
        {
            return "node: " + Info + ", left: " + (Left != null ? Left.Info.ToString() : "null") + ", right: " +
                   (Right != null ? Right.Info.ToString() : "null");
        }
    }
}
