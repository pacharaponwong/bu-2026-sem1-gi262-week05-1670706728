using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{

    public interface IAssignment
    {
        #region Lecture 
        /// <summary>
        /// เรียงลำดับตัวเลขจากน้อยไปมากโดยใช้ Selection Sort
        /// </summary>
        /// <param name="numbers"></param>
        public int[] LCT01_SelectionSortAscending(int[] numbers);

        /// <summary>
        /// เรียงลำดับตัวเลขจากน้อยไปมากโดยใช้ Bubble Sort
        /// </summary>
        /// <param name="numbers"></param>
        public int[] LCT02_BubbleSortAscending(int[] numbers);

        /// <summary>
        /// เรียงลำดับตัวเลขจากน้อยไปมากโดยใช้ Insertion Sort
        /// </summary>
        /// <param name="numbers"></param>
        public int[] LCT03_InsertionSortAscending(int[] numbers);

        #endregion

        #region Assignment

        /// <summary>
        /// เรียงลำดับตัวเลขจากมากไปน้อยโดยใช้ Selection Sort
        /// </summary>
        /// <param name="numbers"></param>
        public int[] AS01_SelectionSortDescending(int[] numbers)
        {
            int[] result = (int[])numbers.Clone();
            int n = result.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (result[j] > result[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                int temp = result[maxIndex];
                result[maxIndex] = result[i];
                result[i] = temp;
            }

            foreach (var n_ in result)
            {
                Debug.Log(n_);
            }
            return result;
        }
        /// <summary>
        /// เรียงลำดับตัวเลขจากมากไปน้อยโดยใช้ Bubble Sort
        /// </summary>
        /// <param name="numbers"></param>
        public int[] AS02_BubbleSortDescending(int[] numbers)
        {
            int[] result = (int[])numbers.Clone();
            int n = result.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (result[j] < result[j + 1])
                    {
                        int temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            foreach (var n_ in result)
            {
                Debug.Log(n_);
            }
            return result;
        }

        /// <summary>
        /// เรียงลำดับตัวเลขจากมากไปน้อยโดยใช้ Insertion Sort
        /// </summary>
        /// <param name="numbers"></param>
        public int[] AS03_InsertionSortDescending(int[] numbers)
        {
            int[] result = (int[])numbers.Clone();
            int n = result.Length;
            for (int i = 1; i < n; i++)
            {
                int key = result[i];
                int j = i - 1;
                while (j >= 0 && result[j] < key)
                {
                    result[j + 1] = result[j];
                    j--;
                }
                result[j + 1] = key;
            }

            foreach (var n_ in result)
            {
                Debug.Log(n_);
            }
            return result;
        }

        /// <summary>
        /// ค้นหาตัวเลขที่มีค่ามากเป็นอันดับสองใน array
        /// ให้เขียนโปรแกรมเพื่อค้นหาตัวเลขที่มีค่ามากเป็นอันดับสองจาก array ที่ได้รับเป็น input
        /// เช่น input ที่ได้รับมาคือ[1 2 3 4 5] ตัวเลขที่มีค่ามากเป็นอันดับสองคือ 4
        /// </summary>
        /// <param name="numbers"></param>
        public int AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;

            int[] sorted = (int[])numbers.Clone();
            System.Array.Sort(sorted);
            System.Array.Reverse(sorted);

            int max = sorted[0];
            for (int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i] < max)
                {
                    return sorted[i];
                }
            }
            return max;
        }

        #endregion

        #region Extra

        /// <summary>
        /// ค้นหาความยาวชุดตัวเลขที่เรียงลำดับติดต่อกันที่ยาวที่สุด
        /// ให้เขียนโปรแกรมเพื่อค้นหาความยาวของชุดตัวเลขที่เรียงลำดับติดต่อกันที่ยาวที่สุดจาก array ที่ได้รับเป็น input
        /// ตัวอย่างความยาวชุดตัวเลขที่เรียงลำดับติดต่อกันที่ยาวที่สุด เช่น input ที่ได้รับมาคือ[1 9 3 10 4 20 2] เมื่อนำมาเรียงจากน้อยไปมากแล้วจะได้เป็น[1 2 3 4 9 10 20]
        /// ซึ่งเราจะได้ชุดตัวเลขย่อยๆที่เรียง 3 ชุดคือ
        /// [1 2 3 4]
        /// [9 10]
        /// [20]
        /// จะเห็นว่า[1 2 3 4] มีความยาวเท่ากับ4 ซึ่งเป็นชุดตัวเลขที่ยาวที่สุดเมื่อเทียบกับ 2 ชุดที่เหลือ
        /// ดังนั้นเราสามารถบอกได้ว่าชุดตัวเลขนี้[1 9 3 10 4 20 2] มี longest consecutive sequence ความยาวเท่ากับ 4
        /// </summary>
        /// <param name="numbers"></param>
        public int EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;
            if (numbers.Length == 1)
            {
                Debug.Log("The longest consecutive sequence is: 1");
                return 1;
            }

            int[] sorted = (int[])numbers.Clone();
            System.Array.Sort(sorted);

            int longestStreak = 1;
            int currentStreak = 1;

            for (int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i] != sorted[i - 1])
                {
                    if (sorted[i] == sorted[i - 1] + 1)
                    {
                        currentStreak++;
                    }
                    else
                    {
                        longestStreak = System.Math.Max(longestStreak, currentStreak);
                        currentStreak = 1;
                    }
                }
            }

            longestStreak = System.Math.Max(longestStreak, currentStreak);
            Debug.Log($"The longest consecutive sequence is: {longestStreak}");

            return longestStreak;
        }

        #endregion 
    }
}
