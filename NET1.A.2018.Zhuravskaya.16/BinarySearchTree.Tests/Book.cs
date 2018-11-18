using System;

namespace BinarySearchTree.Tests
{
    internal class Book : IComparable<Book>
    {
        public readonly string Title;

        public readonly string Author;

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public int CompareTo(Book other)
        {
            return string.Compare(Title, other.Title, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
