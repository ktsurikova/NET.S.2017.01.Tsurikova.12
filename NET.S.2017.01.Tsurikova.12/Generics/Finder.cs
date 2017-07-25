using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    /// <summary>
    /// class for searching element in array
    /// </summary>
    public class Finder
    {
        /// <summary>
        /// method for searching elemtent in array using binary search
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="arr">array in which search is performed</param>
        /// <param name="value">element to be searched</param>
        /// <param name="comparer">comparer according to which comparison is performed</param>
        /// <exception cref="ArgumentNullException">throws when arr is null</exception>
        /// <returns>index of element otherwise index of position in which this element can be inserted</returns>
        public static int BinarySearch<T>(T[] arr, T value, IComparer<T> comparer) =>
            BinarySearch(arr, value, comparer.Compare);

        /// <summary>
        /// method for searching elemtent in array using binary search
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="arr">array in which search is performed</param>
        /// <param name="value">element to be searched</param>
        /// <exception cref="ArgumentNullException">throws when arr is null</exception>
        /// <exception cref="ArgumentException">throws when T doesn't provide default comparison</exception>
        /// <returns>index of element otherwise index of position in which this element can be inserted</returns>
        public static int BinarySearch<T>(T[] arr, T value) =>
            BinarySearch(arr, value, null as Comparison<T>);

        /// <summary>
        /// method for searching elemtent in array using binary search
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="arr">array in which search is performed</param>
        /// <param name="value">element to be searched</param>
        /// <param name="comparer">comparer according to which comparison is performed</param>
        /// <exception cref="ArgumentNullException">throws when arr is null</exception>
        /// <exception cref="ArgumentException">throws when there is no comparer</exception>
        /// <returns>index of element otherwise index of position in which this element can be inserted</returns>
        public static int BinarySearch<T>(T[] arr, T value, Comparison<T> comparer)
        {
            if (ReferenceEquals(arr, null)) throw new ArgumentNullException($"{nameof(arr)} is null");
            if (arr.Length == 0) return -1;
            if (ReferenceEquals(comparer, null))
            {
                comparer = DefaultComparison(arr);
            }

            int left = 0;
            int right = arr.Length;
            int mid = 0;

            while (left < right)
            {
                mid = left + (right - left) / 2;

                if (comparer(arr[mid], value) == 0)
                    return mid;

                if (comparer(arr[mid], value) > 0)
                    right = mid;
                else
                    left = mid + 1;
            }

            return -(1 + left);
        }

        private static Comparison<T> DefaultComparison<T>(T[] arr)
        {
            if (arr[0] is IComparable<T>)
                return (x, y) => (x as IComparable<T>).CompareTo(y);
            if (arr[0] is IComparable)
                return (x, y) => (x as IComparable).CompareTo(y);
            throw new ArgumentException("there is no comparer");
        }

    }
}
