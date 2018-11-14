using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using QueueTests.CustomTypes;

namespace QueueTests
{
    [TestFixture]
    public class QueueProfileTests
    {
        public void Queue_CreateQueueWithoutParameters_NewQueue()
        {
            Assert.IsTrue(new Queue<Profile>().Count == 0);
        }

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(1000)]
        public void Queue_CreateQueueWithCapacity_NewQueue(int capacity)
        {
            Assert.IsTrue(new Queue<Profile>(capacity).Count == 0);
        }

        [TestCase(-1)]
        public void Queue_CreateQueueWithWrongCapacity_ExpectedArgumentOutOfRangeException(int capacity)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new Queue<Profile>(capacity));

        [Test]
        public void Queue_CreateQueueFromNullableCollection_ExpectedArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new Queue<Profile>(null));

        [TestCaseSource(typeof(ProfileDataSource), nameof(ProfileDataSource.QueuesCounts))]
        public int Count_NotNullQueue_QueueCount(Queue<Profile> queue)
        {
            return queue.Count;
        }

        [TestCase(default(Profile), ExpectedResult = 1)]
        public int Enqueue_NewQueueElement_QueueCountChanged(Profile element)
        {
            var queue = new Queue<Profile>();

            queue.Enqueue(element);

            return queue.Count;
        }

        [TestCaseSource(typeof(ProfileDataSource), nameof(ProfileDataSource.QueuesCountsAfterDequeue))]
        public int Dequeue_NotEmptyQueue_QueueCountChanged(Queue<Profile> queue)
        {
            queue.Dequeue();

            return queue.Count;
        }

        [Test]
        public void Dequeue_EmptyQueue_ExpectedInvalidOperationException()
            => Assert.Throws<InvalidOperationException>(() => new Queue<Profile>().Dequeue());

        [TestCaseSource(typeof(ProfileDataSource), nameof(ProfileDataSource.Queues))]
        public void Clear_NotNullQueue_ClearedQueue(Queue<Profile> queue)
        {
            queue.Clear();

            Assert.IsTrue(queue.Count == 0);
        }

        [TestCaseSource(typeof(ProfileDataSource), nameof(ProfileDataSource.QueuesContains))]
        public bool Contains_NotNullQueueAndElementToFind_IsElementInQueue(Queue<Profile> queue, Profile element)
        {
            return queue.Contains(element);
        }

        [TestCaseSource(typeof(ProfileDataSource), nameof(ProfileDataSource.QueuesPeek))]
        public Profile Peek_NotEmptyQueues_FirstQueueElement(Queue<Profile> queue)
        {
            return queue.Peek();
        }

        [Test]
        public void Peek_EmptyQueue_ExpectedInvalidOperationException()
            => Assert.Throws<InvalidOperationException>(() => new Queue<Profile>().Peek());

        [TestCaseSource(typeof(ProfileDataSource), nameof(ProfileDataSource.QueueTrimExcess))]
        public int TrimExcess_NotNullQueues_TrimmedOrNotTrimmedQueue(Queue<Profile> queue)
        {
            queue.TrimExcess();

            return queue.Count;
        }

        [TestCaseSource(typeof(ProfileDataSource), nameof(ProfileDataSource.Queues))]
        public void Enumerator_Queue_ExpectedInvalidOperationException(Queue<Profile> queue)
            => Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var element in queue)
                {
                    queue.Enqueue(element);
                }
            });
    }

    internal class ProfileDataSource
    {
        public static IEnumerable QueuesCounts
        {
            get
            {
                var profile1 = new Profile("profile1");
                var profile2 = new Profile("profile2");
                var profile3 = new Profile("profile3");
                var profile4 = new Profile("profile4");

                yield return new TestCaseData(new Queue<Profile>()).Returns(0);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1 })).Returns(1);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2 })).Returns(2);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3 })).Returns(3);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3, profile4 })).Returns(4);
            }
        }

        public static IEnumerable QueuesCountsAfterDequeue
        {
            get
            {
                var profile1 = new Profile("profile1");
                var profile2 = new Profile("profile2");
                var profile3 = new Profile("profile3");
                var profile4 = new Profile("profile4");

                yield return new TestCaseData(new Queue<Profile>(new[] { profile1 })).Returns(0);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2 })).Returns(1);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3 })).Returns(2);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3, profile4 })).Returns(3);
            }
        }

        public static IEnumerable Queues
        {
            get
            {
                var profile1 = new Profile("profile1");
                var profile2 = new Profile("profile2");
                var profile3 = new Profile("profile3");
                var profile4 = new Profile("profile4");

                yield return new TestCaseData(new Queue<Profile>(new[] { profile1 }));
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2 }));
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3 }));
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3, profile4 }));
            }
        }

        public static IEnumerable QueuesContains
        {
            get
            {
                var profile1 = new Profile("profile1");
                var profile2 = new Profile("profile2");
                var profile3 = new Profile("profile3");
                var profile4 = new Profile("profile4");

                yield return new TestCaseData(new Queue<Profile>(), null).Returns(false);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1 }), profile1).Returns(true);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2 }), profile4).Returns(false);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3 }), profile3).Returns(true);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3, profile4 }), null).Returns(false);
            }
        }

        public static IEnumerable QueuesPeek
        {
            get
            {
                var profile1 = new Profile("profile1");
                var profile2 = new Profile("profile2");
                var profile3 = new Profile("profile3");
                var profile4 = new Profile("profile4");

                yield return new TestCaseData(new Queue<Profile>(new[] { profile1 })).Returns(profile1);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2 })).Returns(profile1);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3 })).Returns(profile1);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3, profile4 })).Returns(profile1);
            }
        }

        public static IEnumerable QueueTrimExcess
        {
            get
            {
                var profile1 = new Profile("profile1");
                var profile2 = new Profile("profile2");
                var profile3 = new Profile("profile3");
                var profile4 = new Profile("profile4");

                yield return new TestCaseData(new Queue<Profile>(new[] { profile1 })).Returns(1);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2 })).Returns(2);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3 })).Returns(3);
                yield return new TestCaseData(new Queue<Profile>(new[] { profile1, profile2, profile3, profile4 })).Returns(4);
            }
        }
    }
}