using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using QueueTests.CustomTypes;

namespace QueueTests
{
    [TestFixture]
    public class QueueTelephoneNumberTests
    {
        public void Queue_CreateQueueWithoutParameters_NewQueue()
        {
            Assert.IsTrue(new Queue<TelephoneNumber>().Count == 0);
        }

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(1000)]
        public void Queue_CreateQueueWithCapacity_NewQueue(int capacity)
        {
            Assert.IsTrue(new Queue<TelephoneNumber>(capacity).Count == 0);
        }

        [TestCase(-1)]
        public void Queue_CreateQueueWithWrongCapacity_ExpectedArgumentOutOfRangeException(int capacity)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new Queue<TelephoneNumber>(capacity));

        [Test]
        public void Queue_CreateQueueFromNullableCollection_ExpectedArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new Queue<TelephoneNumber>(null));

        [TestCaseSource(typeof(TelephoneNumberDataSource), nameof(TelephoneNumberDataSource.QueuesCounts))]
        public int Count_NotNullQueue_QueueCount(Queue<TelephoneNumber> queue)
        {
            return queue.Count;
        }

        [TestCase(default(TelephoneNumber), ExpectedResult = 1)]
        public int Enqueue_NewQueueElement_QueueCountChanged(TelephoneNumber element)
        {
            var queue = new Queue<TelephoneNumber>();

            queue.Enqueue(element);

            return queue.Count;
        }

        [TestCaseSource(typeof(TelephoneNumberDataSource), nameof(TelephoneNumberDataSource.QueuesCountsAfterDequeue))]
        public int Dequeue_NotEmptyQueue_QueueCountChanged(Queue<TelephoneNumber> queue)
        {
            queue.Dequeue();

            return queue.Count;
        }

        [Test]
        public void Dequeue_EmptyQueue_ExpectedInvalidOperationException()
            => Assert.Throws<InvalidOperationException>(() => new Queue<TelephoneNumber>().Dequeue());

        [TestCaseSource(typeof(TelephoneNumberDataSource), nameof(TelephoneNumberDataSource.Queues))]
        public void Clear_NotNullQueue_ClearedQueue(Queue<TelephoneNumber> queue)
        {
            queue.Clear();

            Assert.IsTrue(queue.Count == 0);
        }

        [TestCaseSource(typeof(TelephoneNumberDataSource), nameof(TelephoneNumberDataSource.QueuesContains))]
        public bool Contains_NotNullQueueAndElementToFind_IsElementInQueue(Queue<TelephoneNumber> queue, TelephoneNumber element)
        {
            return queue.Contains(element);
        }

        [TestCaseSource(typeof(TelephoneNumberDataSource), nameof(TelephoneNumberDataSource.QueuesPeek))]
        public TelephoneNumber Peek_NotEmptyQueues_FirstQueueElement(Queue<TelephoneNumber> queue)
        {
            return queue.Peek();
        }

        [Test]
        public void Peek_EmptyQueue_ExpectedInvalidOperationException()
            => Assert.Throws<InvalidOperationException>(() => new Queue<TelephoneNumber>().Peek());

        [TestCaseSource(typeof(TelephoneNumberDataSource), nameof(TelephoneNumberDataSource.QueueTrimExcess))]
        public int TrimExcess_NotNullQueues_TrimmedOrNotTrimmedQueue(Queue<TelephoneNumber> queue)
        {
            queue.TrimExcess();

            return queue.Count;
        }

        [TestCaseSource(typeof(TelephoneNumberDataSource), nameof(TelephoneNumberDataSource.Queues))]
        public void Enumerator_Queue_ExpectedInvalidOperationException(Queue<TelephoneNumber> queue)
            => Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var element in queue)
                {
                    queue.Enqueue(element);
                }
            });
    }

    internal class TelephoneNumberDataSource
    {
        public static IEnumerable QueuesCounts
        {
            get
            {
                var telephoneNumber1 = new TelephoneNumber("telephoneNumber1");
                var telephoneNumber2 = new TelephoneNumber("telephoneNumber2");
                var telephoneNumber3 = new TelephoneNumber("telephoneNumber3");
                var telephoneNumber4 = new TelephoneNumber("telephoneNumber4");

                yield return new TestCaseData(new Queue<TelephoneNumber>()).Returns(0);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1 })).Returns(1);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2 })).Returns(2);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3 })).Returns(3);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3, telephoneNumber4 })).Returns(4);
            }
        }

        public static IEnumerable QueuesCountsAfterDequeue
        {
            get
            {
                var telephoneNumber1 = new TelephoneNumber("telephoneNumber1");
                var telephoneNumber2 = new TelephoneNumber("telephoneNumber2");
                var telephoneNumber3 = new TelephoneNumber("telephoneNumber3");
                var telephoneNumber4 = new TelephoneNumber("telephoneNumber4");

                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1 })).Returns(0);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2 })).Returns(1);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3 })).Returns(2);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3, telephoneNumber4 })).Returns(3);
            }
        }

        public static IEnumerable Queues
        {
            get
            {
                var telephoneNumber1 = new TelephoneNumber("telephoneNumber1");
                var telephoneNumber2 = new TelephoneNumber("telephoneNumber2");
                var telephoneNumber3 = new TelephoneNumber("telephoneNumber3");
                var telephoneNumber4 = new TelephoneNumber("telephoneNumber4");

                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1 }));
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2 }));
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3 }));
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3, telephoneNumber4 }));
            }
        }

        public static IEnumerable QueuesContains
        {
            get
            {
                var telephoneNumber1 = new TelephoneNumber("telephoneNumber1");
                var telephoneNumber2 = new TelephoneNumber("telephoneNumber2");
                var telephoneNumber3 = new TelephoneNumber("telephoneNumber3");
                var telephoneNumber4 = new TelephoneNumber("telephoneNumber4");

                yield return new TestCaseData(new Queue<TelephoneNumber>(), null).Returns(false);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1 }), telephoneNumber1).Returns(true);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2 }), telephoneNumber4).Returns(false);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3 }), telephoneNumber3).Returns(true);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3, telephoneNumber4 }), null).Returns(false);
            }
        }

        public static IEnumerable QueuesPeek
        {
            get
            {
                var telephoneNumber1 = new TelephoneNumber("telephoneNumber1");
                var telephoneNumber2 = new TelephoneNumber("telephoneNumber2");
                var telephoneNumber3 = new TelephoneNumber("telephoneNumber3");
                var telephoneNumber4 = new TelephoneNumber("telephoneNumber4");

                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1 })).Returns(telephoneNumber1);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2 })).Returns(telephoneNumber1);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3 })).Returns(telephoneNumber1);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3, telephoneNumber4 })).Returns(telephoneNumber1);
            }
        }

        public static IEnumerable QueueTrimExcess
        {
            get
            {
                var telephoneNumber1 = new TelephoneNumber("telephoneNumber1");
                var telephoneNumber2 = new TelephoneNumber("telephoneNumber2");
                var telephoneNumber3 = new TelephoneNumber("telephoneNumber3");
                var telephoneNumber4 = new TelephoneNumber("telephoneNumber4");

                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1 })).Returns(1);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2 })).Returns(2);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3 })).Returns(3);
                yield return new TestCaseData(new Queue<TelephoneNumber>(new[] { telephoneNumber1, telephoneNumber2, telephoneNumber3, telephoneNumber4 })).Returns(4);
            }
        }
    }
}