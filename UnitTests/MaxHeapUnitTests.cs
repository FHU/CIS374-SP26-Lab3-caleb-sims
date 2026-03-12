using System;
using Lab3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MaxHeapUnitTests
    {
        [TestMethod]
        public void TestAddPeekInt1()
        {
            MaxHeap<int> heap1 = new MaxHeap<int>();

            heap1.Add(9);
            heap1.Add(8);
            heap1.Add(7);
            heap1.Add(6);
            heap1.Add(0);
            heap1.Add(1);
            heap1.Add(2);
            heap1.Add(3);
            heap1.Add(4);
            heap1.Add(5);
            
            Assert.AreEqual(9, heap1.Peek());
        }

        [TestMethod]
        public void TestAddExtractCountInt1()
        {
            MaxHeap<int> heap1 = new MaxHeap<int>();

            heap1.Add(4);
            heap1.Add(3);
            heap1.Add(2);
            heap1.Add(1);
            heap1.Add(0);
            Assert.AreEqual(5, heap1.Count);

            Assert.AreEqual(4, heap1.ExtractMax());
            Assert.AreEqual(4, heap1.Count);
            Assert.AreEqual(3, heap1.ExtractMax());
            Assert.AreEqual(3, heap1.Count);
            Assert.AreEqual(2, heap1.ExtractMax());
            Assert.AreEqual(2, heap1.Count);
            Assert.AreEqual(1, heap1.ExtractMax());
            Assert.AreEqual(1, heap1.Count);
            Assert.AreEqual(0, heap1.ExtractMax());
            Assert.AreEqual(0, heap1.Count);
            Assert.Throws<InvalidOperationException>(() => heap1.ExtractMax());
            Assert.AreEqual(0, heap1.Count);
            Assert.Throws<InvalidOperationException>(() => heap1.ExtractMax());
            Assert.AreEqual(0, heap1.Count);

        }

        [TestMethod]
        public void TestAddExtractInt1()
        {
            MaxHeap<int> heap1 = new MaxHeap<int>();

            heap1.Add(0);
            heap1.Add(1);
            heap1.Add(2);
            heap1.Add(3);
            heap1.Add(4);
            
            Assert.AreEqual(4, heap1.ExtractMax());
            Assert.AreEqual(3, heap1.ExtractMax());
            Assert.AreEqual(2, heap1.ExtractMax());
            Assert.AreEqual(1, heap1.ExtractMax());
            Assert.AreEqual(0, heap1.ExtractMax());
            Assert.Throws<InvalidOperationException>(() => heap1.ExtractMax());
            Assert.Throws<InvalidOperationException>(() => heap1.ExtractMax());

        }

        [TestMethod]
        public void TestAddExtractString1()
        {
            MaxHeap<string> heap1 = new MaxHeap<string>();

            heap1.Add("kaden");
            heap1.Add("caleb");
            heap1.Add("kenan");
            heap1.Add("dallas");
            heap1.Add("cameron");

            Assert.AreEqual("kenan", heap1.ExtractMax());
            Assert.AreEqual("kaden", heap1.ExtractMax());
            Assert.AreEqual("dallas", heap1.ExtractMax());
            Assert.AreEqual("cameron", heap1.ExtractMax());
            Assert.AreEqual("caleb", heap1.ExtractMax());
            Assert.Throws<InvalidOperationException>(() => heap1.ExtractMax());
        }

        [TestMethod]
        public void TestExtract1()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            MaxHeap<int> heap1 = new MaxHeap<int>(array);
            Assert.AreEqual(7, heap1.ExtractMax());
            Assert.AreEqual(6, heap1.ExtractMax());
            Assert.AreEqual(5, heap1.ExtractMax());
        }

        [TestMethod]
        public void TestMinExtract()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            MaxHeap<int> heap1 = new MaxHeap<int>(array);
            Assert.AreEqual(1, heap1.ExtractMin());
            Assert.AreEqual(2, heap1.ExtractMin());
            Assert.AreEqual(3, heap1.ExtractMin());
        }

        [TestMethod]
        public void TestAddExtractIsEmptyString()
        {
            MaxHeap<string> heap1 = new MaxHeap<string>();

            heap1.Add("kaden");
            heap1.Add("caleb");
            heap1.Add("kenan");
            heap1.Add("dallas");
            heap1.Add("cameron");

            Assert.IsFalse(heap1.IsEmpty);

            Assert.AreEqual("kenan", heap1.ExtractMax());
            heap1.ExtractMax();
            heap1.ExtractMax();
            heap1.ExtractMax();
            heap1.ExtractMax();
            Assert.IsTrue(heap1.IsEmpty);
        }

        [TestMethod]
        public void TestAddResizeInt2()
        {
            MaxHeap<int> heap1 = new MaxHeap<int>();

            heap1.Add(1);
            heap1.Add(2);
            heap1.Add(3);
            heap1.Add(4);
            heap1.Add(5);
            heap1.Add(6);
            heap1.Add(7);
            heap1.Add(8);
            heap1.Add(9);
            heap1.Add(10);
            heap1.Add(11);
            heap1.Add(12);
            heap1.Add(13);
            heap1.Add(14);
            heap1.Add(15);
            heap1.Add(16);
            heap1.Add(17);
            heap1.Add(18);
            heap1.Add(19);
            heap1.Add(20);
            heap1.Add(21);
            heap1.Add(22);
            heap1.Add(23);
            heap1.Add(24);
            heap1.Add(25);
            heap1.Add(26);
            heap1.Add(27);
            heap1.Add(28);
            heap1.Add(29);
            heap1.Add(30);
            heap1.Add(31);
            heap1.Add(32);
            heap1.Add(33);
            heap1.Add(34);
            heap1.Add(35);
            heap1.Add(36);
            heap1.Add(37);
            heap1.Add(38);
            heap1.Add(39);
            heap1.Add(40);

            Assert.AreEqual(40, heap1.Peek());
            Assert.AreEqual(40, heap1.Count);
        }

        [TestMethod]
        public void TestConstructorInt1()
        {
            MaxHeap<int> heap1 = new MaxHeap<int>();
            Assert.AreEqual(0, heap1.Count);

            int[] array = { 1, 2, 3, 4 };
            MaxHeap<int> heap2 = new MaxHeap<int>(array);
            Assert.AreEqual(4, heap2.Count);
        }

        [TestMethod]
        public void TestConstructorInt2()
        {
            int[] array = { };
            MaxHeap<int> heap1 = new MaxHeap<int>();
            Assert.AreEqual(0, heap1.Count);

            array = null;
            MaxHeap<int> heap2 = new MaxHeap<int>(array);
            Assert.AreEqual(0, heap2.Count);
        }

        [TestMethod]
        public void TestContainsInt1()
        {

            MaxHeap<int> heap1 = new MaxHeap<int>();
            heap1.Add(0);
            heap1.Add(25);
            heap1.Add(50);
            heap1.Add(75);
            heap1.Add(100);
            heap1.Add(125);
            heap1.Add(150);

            Assert.IsTrue(heap1.Contains(25));
            Assert.IsFalse(heap1.Contains(5000));
            Assert.IsTrue(heap1.Contains(150));

        }

        [TestMethod]
        public void TestAddExtractIsEmptyContainsInt()
        {
            MaxHeap<int> heap1 = new MaxHeap<int>();
            heap1.Add(0);
            heap1.Add(25);
            heap1.Add(50);
            heap1.Add(75);
            heap1.Add(100);
            heap1.Add(125);
            heap1.Add(150);

            Assert.IsTrue(heap1.Contains(25));
            Assert.IsFalse(heap1.Contains(5000));
            heap1.Add(5000);
            Assert.IsTrue(heap1.Contains(5000));
            Assert.IsTrue(heap1.Contains(150));
            heap1.ExtractMax();
            Console.WriteLine( heap1.Peek() );
            Assert.IsFalse(heap1.Contains(5000));

        }

        [TestMethod]
        public void TestAddExtractIsEmptyInt()
        {
            MaxHeap<int> heap1 = new MaxHeap<int>();
            int temp1;
            int temp2;

            heap1.Add(5);
            heap1.Add(7);
            heap1.Add(10);
            heap1.Add(13);
            heap1.Add(14);
            heap1.Add(16);
            heap1.Add(47);
            heap1.Add(82);
            heap1.Add(1769);

            temp1 = heap1.ExtractMax();

            while (!heap1.IsEmpty)
            {
                temp2 = heap1.ExtractMax();
                Assert.IsTrue(temp2 < temp1);
                temp1 = temp2;
            }
        }

        [TestMethod]
        public void TestPeek()
        {
            MaxHeap<int> heap0 = new MaxHeap<int>();

            heap0.Add(0);
            Assert.AreEqual(0, heap0.Peek());
            heap0.Add(30);
            Assert.AreEqual(30, heap0.Peek());
            heap0.Add(60);
            Assert.AreEqual(60, heap0.Peek());
            heap0.Add(90);
            Assert.AreEqual(90, heap0.Peek());
            heap0.Add(100);
            Assert.AreEqual(100, heap0.Peek());
            heap0.Add(130);
            Assert.AreEqual(130, heap0.Peek());
            heap0.Add(160);
            Assert.AreEqual(160, heap0.Peek());
            
        }

        [TestMethod]
        public void TestRemove()
        {
            MaxHeap<int> heap0 = new MaxHeap<int>();
            heap0.Add(160);
            heap0.Add(130);
            heap0.Add(100);
            heap0.Add(90);
            heap0.Add(60);


            heap0.Remove(160);
            Assert.AreEqual(4, heap0.Count);
            Assert.IsFalse(heap0.Contains(160));

            heap0.Remove(100);
            Assert.AreEqual(3, heap0.Count);
            Assert.IsFalse(heap0.Contains(100));

            heap0.Remove(60);
            Assert.AreEqual(2, heap0.Count);
            Assert.IsFalse(heap0.Contains(60));

            heap0.Remove(130);
            Assert.AreEqual(1, heap0.Count);
            Assert.IsFalse(heap0.Contains(130));
            
            heap0.Remove(90);
            Assert.AreEqual(0, heap0.Count);
            Assert.IsFalse(heap0.Contains(90));

            Assert.Throws<InvalidOperationException>(() => heap0.Remove(0));

        }

        [TestMethod]
        public void TestUpdate()
        {
            MaxHeap<int> heap0 = new MaxHeap<int>();
            heap0.Add(160);
            heap0.Add(130);
            heap0.Add(100);
            heap0.Add(90);
            heap0.Add(60);

            heap0.Update(60, 65);
            Assert.AreEqual(5, heap0.Count);
            Assert.IsFalse(heap0.Contains(60));
            Assert.IsTrue(heap0.Contains(65));

            heap0.Update(130, 85);
            Assert.AreEqual(5, heap0.Count);
            Assert.IsFalse(heap0.Contains(130));
            Assert.IsTrue(heap0.Contains(85));

            heap0.Update(90, 165);
            Assert.AreEqual(5, heap0.Count);
            Assert.IsFalse(heap0.Contains(90));
            Assert.IsTrue(heap0.Contains(165));

            heap0.Update(160, 250);
            Assert.AreEqual(5, heap0.Count);
            Assert.IsFalse(heap0.Contains(160));
            Assert.IsTrue(heap0.Contains(250));
            Assert.AreEqual(250, heap0.Peek());

            Assert.Throws<InvalidOperationException>(() => heap0.Update(0, 10));

        }

        [TestMethod]
        public void TestUpdateandRemoveEmpty()
        {
            MaxHeap<int> heap0 = new MaxHeap<int>();

            Assert.Throws<InvalidOperationException>(() => heap0.Update(0, 10));
            Assert.Throws<InvalidOperationException>(() => heap0.Remove(0));

        }
    }
}