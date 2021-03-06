﻿using BankLibrary;
using NUnit.Framework;

namespace MathExtension.Tests
{
    [TestFixture]
    public class SearchClassTest
    {
        [Test]
        [TestCase(ExpectedResult = 3)]
        public int BinarySearch_IntgerArray_IndexOfOccurrence()
        {
            int[] array = { 3241, 2, 1, 41, 231, 2 };
            return array.BinarySearch(41, 0, 3);
        }

        [Test]
        [TestCase(ExpectedResult = -1)]
        public int BinarySearch_DoescntContainElement_MinusOne()
        {
            int[] array = { 3241, 2, 1, 41, 231, 2 };
            return array.BinarySearch(45);
        }

        [Test]
        [TestCase(ExpectedResult = 2)]
        public int BinarySearch_StringsArray_IndexOfOccurrence()
        {
            string[] array = { "a", "b", "c", "d" };
            return array.BinarySearch("c");
        }

        [Test]
        [TestCase(ExpectedResult = 2)]
        public int BinarySearch_ClientsArray_IndexOfOccurrence()
        {
            Client a = new Client("Fedor", "Stepanov", "Igorevich", "3123", 20);
            Client b = new Client("Fedor", "Stepanov", "Igorevich", "3123", 22);
            Client c = new Client("Fedor", "Stepanov", "Igorevich", "3123", 25);
            Client d = new Client("Fedor", "Stepanov", "Igorevich", "3123", 34);

            Client[] array = new Client[] { a, b, c, d };

            return array.BinarySearch(c, 1, 2);
        }
    }
}
