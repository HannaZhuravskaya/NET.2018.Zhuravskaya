using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using QueueTests.CustomTypes;

namespace QueueTests
{
    [TestFixture]
    public class QueueEmailTests
    {
        public void Queue_CreateQueueWithoutParameters_NewQueue()
        {
            Assert.IsTrue(new Queue<Email>().Count == 0);
        }

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(1000)]
        public void Queue_CreateQueueWithCapacity_NewQueue(int capacity)
        {
            Assert.IsTrue(new Queue<Email>(capacity).Count == 0);
        }

        [TestCase(-1)]
        public void Queue_CreateQueueWithWrongCapacity_ExpectedArgumentOutOfRangeException(int capacity)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new Queue<Email>(capacity));

        [Test]
        public void Queue_CreateQueueFromNullableCollection_ExpectedArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new Queue<Email>(null));

        [TestCaseSource(typeof(EmailDataSource), nameof(EmailDataSource.QueuesCounts))]
        public int Count_NotNullQueue_QueueCount(Queue<Email> queue)
        {
            return queue.Count;
        }

        [TestCase(default(Email), ExpectedResult = 1)]
        public int Enqueue_NewQueueElement_QueueCountChanged(Email element)
        {
            var queue = new Queue<Email>();

            queue.Enqueue(element);

            return queue.Count;
        }

        [TestCaseSource(typeof(EmailDataSource), nameof(EmailDataSource.QueuesCountsAfterDequeue))]
        public int Dequeue_NotEmptyQueue_QueueCountChanged(Queue<Email> queue)
        {
            queue.Dequeue();

            return queue.Count;
        }

        [Test]
        public void Dequeue_EmptyQueue_ExpectedInvalidOperationException()
            => Assert.Throws<InvalidOperationException>(() => new Queue<Email>().Dequeue());

        [TestCaseSource(typeof(EmailDataSource), nameof(EmailDataSource.Queues))]
        public void Clear_NotNullQueue_ClearedQueue(Queue<Email> queue)
        {
            queue.Clear();

            Assert.IsTrue(queue.Count == 0);
        }

        [TestCaseSource(typeof(EmailDataSource), nameof(EmailDataSource.QueuesContains))]
        public bool Contains_NotNullQueueAndElementToFind_IsElementInQueue(Queue<Email> queue, Email element)
        {
            return queue.Contains(element);
        }

        [TestCaseSource(typeof(EmailDataSource), nameof(EmailDataSource.QueuesPeek))]
        public Email Peek_NotEmptyQueues_FirstQueueElement(Queue<Email> queue)
        {
            return queue.Peek();
        }

        [Test]
        public void Peek_EmptyQueue_ExpectedInvalidOperationException()
            => Assert.Throws<InvalidOperationException>(() => new Queue<Email>().Peek());

        [TestCaseSource(typeof(EmailDataSource), nameof(EmailDataSource.QueueTrimExcess))]
        public int TrimExcess_NotNullQueues_TrimmedOrNotTrimmedQueue(Queue<Email> queue)
        {
            queue.TrimExcess();

            return queue.Count;
        }

        [TestCaseSource(typeof(EmailDataSource), nameof(EmailDataSource.Queues))]
        public void Enumerator_Queue_ExpectedInvalidOperationException(Queue<Email> queue)
            => Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var element in queue)
                {
                    queue.Enqueue(element);
                }
            });
    }

    internal class EmailDataSource
    {
        public static IEnumerable QueuesCounts
        {
            get
            {
                var email1 = new Email("email1");
                var email2 = new Email("email2");
                var email3 = new Email("email3");
                var email4 = new Email("email4");

                yield return new TestCaseData(new Queue<Email>()).Returns(0);
                yield return new TestCaseData(new Queue<Email>(new[] { email1 })).Returns(1);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2 })).Returns(2);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3 })).Returns(3);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3, email4 })).Returns(4);
            }
        }

        public static IEnumerable QueuesCountsAfterDequeue
        {
            get
            {
                var email1 = new Email("email1");
                var email2 = new Email("email2");
                var email3 = new Email("email3");
                var email4 = new Email("email4");

                yield return new TestCaseData(new Queue<Email>(new[] { email1 })).Returns(0);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2 })).Returns(1);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3 })).Returns(2);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3, email4 })).Returns(3);
            }
        }

        public static IEnumerable Queues
        {
            get
            {
                var email1 = new Email("email1");
                var email2 = new Email("email2");
                var email3 = new Email("email3");
                var email4 = new Email("email4");

                yield return new TestCaseData(new Queue<Email>(new[] { email1 }));
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2 }));
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3 }));
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3, email4 }));
            }
        }

        public static IEnumerable QueuesContains
        {
            get
            {
                var email1 = new Email("email1");
                var email2 = new Email("email2");
                var email3 = new Email("email3");
                var email4 = new Email("email4");

                yield return new TestCaseData(new Queue<Email>(), null).Returns(false);
                yield return new TestCaseData(new Queue<Email>(new[] { email1 }), email1).Returns(true);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2 }), email4).Returns(false);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3 }), email3).Returns(true);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3, email4 }), null).Returns(false);
            }
        }

        public static IEnumerable QueuesPeek
        {
            get
            {
                var email1 = new Email("email1");
                var email2 = new Email("email2");
                var email3 = new Email("email3");
                var email4 = new Email("email4");

                yield return new TestCaseData(new Queue<Email>(new[] { email1 })).Returns(email1);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2 })).Returns(email1);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3 })).Returns(email1);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3, email4 })).Returns(email1);
            }
        }

        public static IEnumerable QueueTrimExcess
        {
            get
            {
                var email1 = new Email("email1");
                var email2 = new Email("email2");
                var email3 = new Email("email3");
                var email4 = new Email("email4");

                yield return new TestCaseData(new Queue<Email>(new[] { email1 })).Returns(1);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2 })).Returns(2);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3 })).Returns(3);
                yield return new TestCaseData(new Queue<Email>(new[] { email1, email2, email3, email4 })).Returns(4);
            }
        }
    }
}