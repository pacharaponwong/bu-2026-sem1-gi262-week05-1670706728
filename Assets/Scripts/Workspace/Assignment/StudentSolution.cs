using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public int[] LCT01_SelectionSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = numbers[minIndex];
                numbers[minIndex] = numbers[i];
                numbers[i] = temp;
            }

            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        public int[] LCT02_BubbleSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        public int[] LCT03_InsertionSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n; i++)
            {
                int key = numbers[i];
                int j = i - 1;
                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = key;
            }
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }
        #endregion

        #region Assignment

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