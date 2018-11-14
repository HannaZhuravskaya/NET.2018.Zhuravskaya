using System;

namespace QueueTests.CustomTypes
{
    public class Book : IEquatable<Book>
    {
        private readonly string _title;
        private readonly string _author;

        public Book(string title, string author)
        {
            if (title is null || author is null)
            {
                throw new ArgumentNullException();
            }

            _title = title;
            _author = author;
        }

        public bool Equals(Book other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            return this._author == other._author && this._title == other._title;
        }
    }
}