using System;
using System.Collections.Generic;
using FilterDigitLogic;
using NUnit.Framework;
using static FilterDigitLogic.FilterLogic;

namespace FilterDigitLogicTests.NUnit
{
    public abstract class AbstractFilterClassTest<T>
    {
        public virtual void FilterDigit_DigitLogicTest(T[] array, T value, T[] expected, Func<T,T,bool> predicate)
        {
            T[] result = array.FilterDigit(value, predicate);
            Assert.AreEqual(expected, result);
        }
        
        public virtual void FilterDigit_TransformationLogicTest(T[] array, T[] expected, Func<T, T> transformer)
        {
            T[] result = array.TransformationArray(transformer);
            Assert.AreEqual(expected, result);
        }
    }
    public class FilterClassTestInt : AbstractFilterClassTest<int>
    {
        private static object[] sourceList =
        {
             new object[] { new int[] {  33, 24, 3, 37, 4 }, 4, new int[] { 24, 4 }, new Func<int, int, bool> (Filter<int>.IsSuitable) },
             new object[] { new int[] {  33, 24, 3, 37, 4 }, 7, new int[] { 37 } , new Func<int, int, bool> (Filter<int>.IsSuitable) },
        };

        private static object[] sourceListTransform =
        {
             new object[] { new int[] {  4, 2, 6, 1, 4 }, new int[] { 16, 4, 36, 1, 16 } , new Func<int,int> (Transformer<int>.Square) }

        };

        [Test, TestCaseSource("sourceList")]
        public override void FilterDigit_DigitLogicTest(int[] array, int value, int[] expected, Func<int, int, bool> predicate)
        {
            int[] result = array.FilterDigit(value, predicate);
            Assert.AreEqual(expected, result);
        }
        [Test, TestCaseSource("sourceListTransform")]
        public override void FilterDigit_TransformationLogicTest(int[] array, int[] expected, Func<int, int> transformer)
        {
            int[] result = array.TransformationArray(transformer);
            Assert.AreEqual(expected, result);
        }
    }
    public class FilterClassTestString : AbstractFilterClassTest<string>
    {
        private static object[] sourceList =
        {
             new object[] { new string[] {  "Petya","123","Minsk" }, "e", new string[] { "Petya" } , new Func<string, string, bool> (Filter<string>.IsSuitable) },
             new object[] { new string[] {  "Petya","123","Minsk", "insert" }, "i", new string[] { "Minsk", "insert" } , new Func<string, string, bool> (Filter<string>.IsSuitable) },
        };

        private static object[] sourceListTransform =
        {
             new object[] { new string[] {  "qwestory", "asdof","zxcLove" }, new string[] { "story","of","Love" } , new Func<string, string> (Transformer<string>.Square) }

        };

        [Test, TestCaseSource("sourceList")]
        public override void FilterDigit_DigitLogicTest(string[] array, string value, string[] expected, Func<string, string, bool> predicate)
        {
            string[] result = array.FilterDigit(value, predicate);
            Assert.AreEqual(expected, result);
        }
        [Test, TestCaseSource("sourceListTransform")]
        public override void FilterDigit_TransformationLogicTest(string[] array, string[] expected, Func<string, string> transformer)
        {
            string[] result = array.TransformationArray(transformer);
            Assert.AreEqual(expected, result);
        }
    }
    public class FilterClassTestDouble : AbstractFilterClassTest<double>
    {
        private static object[] sourceList =
        {
             new object[] { new double[] { 123.2, 342.1, 32 }, 4, new double[] { 342.1 } , new Func<double, double, bool> (Filter<double>.IsSuitable) },
        };

        private static object[] sourceListTransform =
        {
             new object[] { new double[] {  123.2,342.1, 32 }, new double[] { 123.2, 342.1, 32 } , new Func<double, double> (Transformer<double>.Square) }

        };

        [Test, TestCaseSource("sourceList")]
        public new void FilterDigit_DigitLogicTest(double[] array, double value, double[] expected, Func<double, double, bool> predicate)
        {
            double[] result = array.FilterDigit(value, predicate);
            Assert.AreEqual(expected, result);
        }
        [Test, TestCaseSource("sourceListTransform")]
        public new void FilterDigit_TransformationLogicTest(double[] array, double[] expected, Func<double, double> transformer)
        {
            double[] result = array.TransformationArray(transformer);
            Assert.AreEqual(expected, result);
        }
    }
}
