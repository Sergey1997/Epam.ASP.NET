using NUnit.Framework;

namespace MathExtension.Tests
{
    [TestFixture]
    public class QueueClassTest
    {
        [Test]
        public void QueueAddTest()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("qqq");
            queue.Enqueue("www");
            Assert.AreEqual(new string[2] { "qqq", "www" }, queue.ToArray());
        }

        [Test]
        public void QueueRemoveTest()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("qqq");
            queue.Enqueue("www");
            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual(new string[0] { }, queue.ToArray());
        }

        [Test]
        public void QueueTrueContainsTest()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("qqq");
            Assert.AreEqual(true, queue.Contains("qqq"));
        }

        [Test]
        public void QueueFalseContainsTest()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("qqq");
            Assert.AreEqual(false, queue.Contains("www"));
        }

        [Test]
        public void QueueClearTest()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("qqq");
            queue.Clear();
            Assert.AreEqual(new string[0] { }, queue.ToArray());
        }
    }
}
