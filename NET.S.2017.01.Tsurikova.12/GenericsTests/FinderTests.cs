using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GenericsTests
{
    [TestFixture]
    public class FinderTests
    {
        [TestCase(new[] { 1, 4, 6, 9, 12, 45, 65 }, 9, ExpectedResult = 3)]
        [TestCase(new[] { 1, 4, 6, 9, 12, 45, 65 }, 1, ExpectedResult = 0)]
        [TestCase(new[] { 1, 4, 6, 9, 12, 45, 65 }, 65, ExpectedResult = 6)]
        [TestCase(new[] { 1, 4, 6, 9, 12, 45, 65 }, 12, ExpectedResult = 4)]
        [TestCase(new[] { 1, 4, 6, 9, 12, 45, 65 }, 4, ExpectedResult = 1)]
        [TestCase(new[] { 1, 4, 6, 9, 12, 45, 65 }, 3, ExpectedResult = -2)]
        [TestCase(new int[0], 3, ExpectedResult = -1)]
        public static int BinarySearch_Array_DefaultComparison_Index(int[] arr, int value)
        {
            return Finder.BinarySearch(arr, value);
        }

        [TestCase(new[] { 1, -4, 6, -9, 12, -45, 65 }, -9, ExpectedResult = 3)]
        public static int BinarySearch_Array_Comparison_Index(int[] arr, int value)
        {
            return Finder.BinarySearch(arr, value, (i, i1) => Math.Abs(i) - Math.Abs(i1));
        }

        [TestCase(new[] { "Cat", "Deer", "Rhino", "Canary", "Crocodile" }, "RHINO", ExpectedResult = 2)]
        public static int BinarySearch_Array_Comparison_Index(string[] arr, string value)
        {
            return Finder.BinarySearch(arr, value, (i, i1) => i.Length - i1.Length);
        }

        [Test]
        public static void BinarySearch_Array_IComparer_Index()
        {
            Point[] points = { new Point(1, 1), new Point(2, 1), new Point(2, 5), new Point(3, 2) };
            Assert.AreEqual(2, Finder.BinarySearch(points, new Point(2, 5), new PointXComparer()));
        }

        [Test]
        public static void BinarySearch_Array_ArgumentException()
        {
            Point[] points = { new Point(1, 1), new Point(2, 5) };
            Assert.Throws<ArgumentException>(() => Finder.BinarySearch(points, new Point(2, 5)));
        }
    }
}
