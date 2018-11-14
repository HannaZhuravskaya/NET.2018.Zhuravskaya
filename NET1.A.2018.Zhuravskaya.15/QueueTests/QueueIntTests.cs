using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace QueueTests
{
    [TestFixture]
    public class QueueIntTests
    {
        public void Queue_CreateQueueWithoutParameters_NewQueue()
        {
            Assert.IsTrue(new Queue<int>().Count == 0);
        }

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(1000)]
        public void Queue_CreateQueueWithCapacity_NewQueue(int capacity)
        {
            Assert.IsTrue(new Queue<int>(capacity).Count == 0);
        }

        [TestCase(-1)]
        public void Queue_CreateQueueWithWrongCapacity_ExpectedArgumentOutOfRangeException(int capacity)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new Queue<int>(capacity));

        [Test]
        public void Queue_CreateQueueFromNullableCollection_ExpectedArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new Queue<int>(null));

        [TestCaseSource(typeof(IntDataSource), nameof(IntDataSource.QueuesCounts))]
        public int Count_NotNullQueue_QueueCount(Queue<int> queue)
        {
            return queue.Count;
        }

        [TestCase(default(int), ExpectedResult = 1)]
        public int Enqueue_NewQueueElement_QueueCountChanged(int element)
        {
            var queue = new Queue<int>();

            queue.Enqueue(element);

            return queue.Count;
        }

        [TestCaseSource(typeof(IntDataSource), nameof(IntDataSource.QueuesCountsAfterDequeue))]
        public int Dequeue_NotEmptyQueue_QueueCountChanged(Queue<int> queue)
        {
            queue.Dequeue();

            return queue.Count;
        }

        [Test]
        public void Dequeue_EmptyQueue_ExpectedInvalidOperationException()
            => Assert.Throws<InvalidOperationException>(() => new Queue<int>().Dequeue());

        [TestCaseSource(typeof(IntDataSource), nameof(IntDataSource.Queues))]
        public void Clear_NotNullQueue_ClearedQueue(Queue<int> queue)
        {
            queue.Clear();

            Assert.IsTrue(queue.Count == 0);
        }

        [TestCaseSource(typeof(IntDataSource), nameof(IntDataSource.QueuesContains))]
        public bool Contains_NotNullQueueAndElementToFind_IsElementInQueue(Queue<int> queue, int element)
        {
            return queue.Contains(element);
        }

        [TestCaseSource(typeof(IntDataSource), nameof(IntDataSource.QueuesPeek))]
        public int Peek_NotEmptyQueues_FirstQueueElement(Queue<int> queue)
        {
            return queue.Peek();
        }

        [Test]
        public void Peek_EmptyQueue_ExpectedInvalidOperationException()
            => Assert.Throws<InvalidOperationException>(() => new Queue<int>().Peek());

        [TestCaseSource(typeof(IntDataSource), nameof(IntDataSource.QueueTrimExcess))]
        public int TrimExcess_NotNullQueues_TrimmedOrNotTrimmedQueue(Queue<int> queue)
        {
            queue.TrimExcess();

            return queue.Count;
        }

        [TestCaseSource(typeof(IntDataSource), nameof(IntDataSource.Queues))]
        public void Enumerator_Queue_ExpectedInvalidOperationException(Queue<int> queue)
            => Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var element in queue)
                {
                    queue.Enqueue(element);
                }
            });
    }

    internal class IntDataSource
    {
        public static IEnumerable QueuesCounts
        {
            get
            {
                yield return new TestCaseData(new Queue<int>()).Returns(0);
                yield return new TestCaseData(new Queue<int>(new[] {1})).Returns(1);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2})).Returns(2);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3})).Returns(3);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3, 4})).Returns(4);
            }
        }

        public static IEnumerable QueuesCountsAfterDequeue
        {
            get
            {
                yield return new TestCaseData(new Queue<int>(new[] {1})).Returns(0);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2})).Returns(1);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3})).Returns(2);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3, 4})).Returns(3);
            }
        }

        public static IEnumerable Queues
        {
            get
            {
                yield return new TestCaseData(new Queue<int>(new[] {1}));
                yield return new TestCaseData(new Queue<int>(new[] {1, 2}));
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3}));
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3, 4}));
            }
        }

        public static IEnumerable QueuesContains
        {
            get
            {
                yield return new TestCaseData(new Queue<int>(), null).Returns(false);
                yield return new TestCaseData(new Queue<int>(new[] {1}), 1).Returns(true);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2}), 4).Returns(false);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3}), 3).Returns(true);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3, 4}), null).Returns(false);
            }
        }

        public static IEnumerable QueuesPeek
        {
            get
            {
                yield return new TestCaseData(new Queue<int>(new[] {1})).Returns(1);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2})).Returns(1);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3})).Returns(1);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3, 4})).Returns(1);
            }
        }

        public static IEnumerable QueueTrimExcess
        {
            get
            {
                yield return new TestCaseData(new Queue<int>(new[] {1})).Returns(1);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2})).Returns(2);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3})).Returns(3);
                yield return new TestCaseData(new Queue<int>(new[] {1, 2, 3, 4})).Returns(4);
            }
        }
    }
}