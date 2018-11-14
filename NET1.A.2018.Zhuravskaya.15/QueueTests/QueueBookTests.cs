using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using QueueTests.CustomTypes;

namespace QueueTests
{
    [TestFixture]
    public class QueueBookTests
    {
        public void Queue_CreateQueueWithoutParameters_NewQueue()
        {
            Assert.IsTrue(new Queue<Book>().Count == 0);
        }

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(1000)]
        public void Queue_CreateQueueWithCapacity_NewQueue(int capacity)
        {
            Assert.IsTrue(new Queue<Book>(capacity).Count == 0);
        }

        [TestCase(-1)]
        public void Queue_CreateQueueWithWrongCapacity_ExpectedArgumentOutOfRangeException(int capacity)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new Queue<Book>(capacity));

        [Test]
        public void Queue_CreateQueueFromNullableCollection_ExpectedArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new Queue<Book>(null));

        [TestCaseSource(typeof(BookDataSource), nameof(BookDataSource.QueuesCounts))]
        public int Count_NotNullQueue_QueueCount(Queue<Book> queue)
        {
            return queue.Count;
        }

        [TestCase(default(Book), ExpectedResult = 1)]
        public int Enqueue_NewQueueElement_QueueCountChanged(Book element)
        {
            var queue = new Queue<Book>();

            queue.Enqueue(element);

            return queue.Count;
        }

        [TestCaseSource(typeof(BookDataSource), nameof(BookDataSource.QueuesCountsAfterDequeue))]
        public int Dequeue_NotEmptyQueue_QueueCountChanged(Queue<Book> queue)
        {
            queue.Dequeue();

            return queue.Count;
        }

        [Test]
        public void Dequeue_EmptyQueue_ExpectedInvalidOperationException()
            => Assert.Throws<InvalidOperationException>(() => new Queue<Book>().Dequeue());

        [TestCaseSource(typeof(BookDataSource), nameof(BookDataSource.Queues))]
        public void Clear_NotNullQueue_ClearedQueue(Queue<Book> queue)
        {
            queue.Clear();

            Assert.IsTrue(queue.Count == 0);
        }

        [TestCaseSource(typeof(BookDataSource), nameof(BookDataSource.QueuesContains))]
        public bool Contains_NotNullQueueAndElementToFind_IsElementInQueue(Queue<Book> queue, Book element)
        {
            return queue.Contains(element);
        }

        [TestCaseSource(typeof(BookDataSource), nameof(BookDataSource.QueuesPeek))]
        public Book Peek_NotEmptyQueues_FirstQueueElement(Queue<Book> queue)
        {
            return queue.Peek();
        }

        [Test]
        public void Peek_EmptyQueue_ExpectedInvalidOperationException()
            => Assert.Throws<InvalidOperationException>(() => new Queue<Book>().Peek());

        [TestCaseSource(typeof(BookDataSource), nameof(BookDataSource.QueueTrimExcess))]
        public int TrimExcess_NotNullQueues_TrimmedOrNotTrimmedQueue(Queue<Book> queue)
        {
            queue.TrimExcess();

            return queue.Count;
        }

        [TestCaseSource(typeof(BookDataSource), nameof(BookDataSource.Queues))]
        public void Enumerator_Queue_ExpectedInvalidOperationException(Queue<Book> queue)
            => Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var element in queue)
                {
                    queue.Enqueue(element);
                }
            });
    }

    internal class BookDataSource
    {
        public static IEnumerable QueuesCounts
        {
            get
            {
                var book1 = new Book("title1", "author1");
                var book2 = new Book("title2", "author2");
                var book3 = new Book("title3", "author3");
                var book4 = new Book("title4", "author4");

                yield return new TestCaseData(new Queue<Book>()).Returns(0);
                yield return new TestCaseData(new Queue<Book>(new[] {book1})).Returns(1);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2})).Returns(2);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3})).Returns(3);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3, book4})).Returns(4);
            }
        }

        public static IEnumerable QueuesCountsAfterDequeue
        {
            get
            {
                var book1 = new Book("title1", "author1");
                var book2 = new Book("title2", "author2");
                var book3 = new Book("title3", "author3");
                var book4 = new Book("title4", "author4");

                yield return new TestCaseData(new Queue<Book>(new[] {book1})).Returns(0);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2})).Returns(1);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3})).Returns(2);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3, book4})).Returns(3);
            }
        }

        public static IEnumerable Queues
        {
            get
            {
                var book1 = new Book("title1", "author1");
                var book2 = new Book("title2", "author2");
                var book3 = new Book("title3", "author3");
                var book4 = new Book("title4", "author4");

                yield return new TestCaseData(new Queue<Book>(new[] {book1}));
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2}));
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3}));
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3, book4}));
            }
        }

        public static IEnumerable QueuesContains
        {
            get
            {
                var book1 = new Book("title1", "author1");
                var book2 = new Book("title2", "author2");
                var book3 = new Book("title3", "author3");
                var book4 = new Book("title4", "author4");

                yield return new TestCaseData(new Queue<Book>(), null).Returns(false);
                yield return new TestCaseData(new Queue<Book>(new[] {book1}), book1).Returns(true);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2}), book4).Returns(false);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3}), book3).Returns(true);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3, book4}), null).Returns(false);
            }
        }

        public static IEnumerable QueuesPeek
        {
            get
            {
                var book1 = new Book("title1", "author1");
                var book2 = new Book("title2", "author2");
                var book3 = new Book("title3", "author3");
                var book4 = new Book("title4", "author4");

                yield return new TestCaseData(new Queue<Book>(new[] {book1})).Returns(book1);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2})).Returns(book1);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3})).Returns(book1);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3, book4})).Returns(book1);
            }
        }

        public static IEnumerable QueueTrimExcess
        {
            get
            {
                var book1 = new Book("title1", "author1");
                var book2 = new Book("title2", "author2");
                var book3 = new Book("title3", "author3");
                var book4 = new Book("title4", "author4");

                yield return new TestCaseData(new Queue<Book>(new[] {book1})).Returns(1);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2})).Returns(2);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3})).Returns(3);
                yield return new TestCaseData(new Queue<Book>(new[] {book1, book2, book3, book4})).Returns(4);
            }
        }
    }
}