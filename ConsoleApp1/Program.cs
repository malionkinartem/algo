using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var board = new char[,]
            //    {{'5', '3', '.', '.', '7', '.', '.', '.', '.'}
            //    ,{'6', '.', '.', '1', '9', '5', '.', '.', '.' }
            //    ,{'.', '9', '8', '.', '.', '.', '.', '6', '.' }
            //    ,{'8', '.', '.', '.', '6', '.', '.', '.', '3' }
            //    ,{'4', '.', '.', '8', '.', '3', '.', '.', '1' }
            //    ,{'7', '.', '.', '.', '2', '.', '.', '.', '6' }
            //    ,{'.', '6', '.', '.', '.', '.', '2', '8', '.' }
            //    ,{'.', '.', '.', '4', '1', '9', '.', '.', '5' }
            //    ,{'.', '.', '.', '.', '8', '.', '.', '7', '9' } };

            var board = new char[][]
                {
                    new char[] {'8', '3', '.', '.', '7', '.', '.', '.', '.' },
                    new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.' },
                    new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.'},
                    new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                    new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                    new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                    new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                    new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                    new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'},
                };

            var board1 = new char[][]
                {
                    new char[] {'.', '.', '4', '.', '.', '.', '6', '3', '.' },
                    new char[] {'.', '.', '.', '.', '.', '.', '.', '.', '.' },
                    new char[] {'5', '.', '.', '.', '.', '.', '.', '9', '.' },
                    new char[] {'.', '.', '.', '5', '6', '.', '.', '.', '.' },
                    new char[] {'4', '.', '3', '.', '.', '.', '.', '.', '1' },
                    new char[] {'.', '.', '.', '7', '.', '.', '.', '.', '.' },
                    new char[] {'.', '.', '.', '5', '.', '.', '.', '.', '.' },
                    new char[] {'.', '.', '.', '.', '.', '.', '.', '.', '.' },
                    new char[] {'.', '.', '.', '.', '.', '.', '.', '.', '.' }
                };


            var sln = new Solution();
            var isValidaSudoku = sln.IsValidSudoku(board1);
            Console.WriteLine("IsValidSudoku: " + isValidaSudoku);


            var matrix = new int[][]
                {
                    new int [] {5, 1, 9, 11 },
                    new int [] {2, 4, 8, 10 },
                    new int [] {13, 3, 6, 7 },
                    new int [] {15, 14, 12, 16 }
                };

            Console.WriteLine("Initial matrix");
            sln.PrintMatrix(matrix);
            sln.Rotate(matrix);
            Console.WriteLine("Rotated 90 matrix");
            sln.PrintMatrix(matrix);

            Console.WriteLine("Path Sum");
            //var root = new TreeNode
            //{
            //    left = new TreeNode
            //    {
            //        val = 5,
            //        left = new TreeNode { val = 3, left = new TreeNode { val = 3 }, right = new TreeNode { val = -2 } },
            //        right = new TreeNode { val = 2, right = new TreeNode { val = 1 } }
            //    },
            //    right = new TreeNode { val = -3, right = new TreeNode { val = 11 } },
            //    val = 10
            //};
            var root = new TreeNode
            {
                left = new TreeNode
                {
                    val = -2,
                    left = new TreeNode { val = 1, left = new TreeNode { val = -1 } },
                    right = new TreeNode { val = 3 }
                },
                right = new TreeNode { val = -3, left = new TreeNode { val = -2 } },
                val = 1
            };
            //var root = new TreeNode { val = 1 };
            var sumPath = sln.PathSum(root, -2);
            Console.WriteLine($"Path Sum: {sumPath}");

            Console.WriteLine("Add Two Numbers");
            var l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))));
            var l2 = new ListNode(9, new ListNode(9));
            var res = sln.AddTwoNumbers(l1, l2);

            Console.WriteLine("Longest Substring Without Repeating Characters");
            var length = sln.LengthOfLongestSubstring("abcabcbb");
            Console.WriteLine($"Result: {length}");

            Console.WriteLine("Median of Two Sorted Arrays");
            int[] nums1 = new int[2] { 1, 3 };
            int[] nums2 = new int[1] { 2 };
            var resp = sln.FindMedianSortedArrays(nums1, nums2);


            string s = "abb";
            var polindrom = sln.LongestPalindrome(s);
            Console.WriteLine($"Longest Palindrome: {polindrom}");

            int[] prices = new int[] { 7, 6, 4, 3, 1 };
            var maxProfit = sln.MaxProfit(prices);
            Console.WriteLine($"MaxProfit: {maxProfit}");
            
            var stairsOptions = sln.ClimbStairs(44);
            Console.WriteLine($"ClimbStairs: {stairsOptions}");


            Console.ReadLine();
        }

        public bool ContainsDuplicate(int[] nums)
        {
            var sortedList = nums.AsEnumerable().ToList();
            sortedList.Sort();

            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                if (sortedList[i] == sortedList[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        public int SingleNumber(int[] nums)
        {
            var sortedList = nums.AsEnumerable().ToList();
            sortedList.Sort();

            if (sortedList.Count == 1)
                return nums[0];

            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                if (nums[i] != nums[i + 1] || i + 1 == sortedList.Count)
                {
                    return nums[i];
                }
                else
                {
                    i++;
                }

            }

            return 0;
        }

    }

    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                var horSet = new HashSet<char>();
                for (int h = 0; h < board[i].Length; h++)
                {
                    var value = board[h][i];
                    if (value != '.')
                    {
                        if (horSet.Contains(value))
                            return false;
                        else horSet.Add(value);
                    }
                }

                var set = new HashSet<char>();
                for (int j = 0; j < board[i].Length; j++)
                {
                    var value = board[i][j];
                    if (value != '.')
                    {
                        if (set.Contains(value))
                            return false;
                        else set.Add(value);
                    }
                }
            }

            for (int i = 0; i < board.Length; i += 3)
            {
                for (int j = 0; j < board[i].Length; j += 3)
                {
                    var set = new HashSet<char>();
                    for (int z = i; z < i + 3; z++)
                    {
                        for (int y = j; y < j + 3; y++)
                        {
                            var value = board[z][y];
                            if (value != '.')
                            {
                                if (set.Contains(value))
                                    return false;
                                else set.Add(value);
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void Rotate(int[][] matrix)
        {
            var depth = matrix.Length / 2;
            for (int j = 0; j < depth; j++)
            {
                for (int z = 0; z < matrix.Length - (j * 2) - 1; z++)
                {
                    var matrixLength = matrix.Length - (j * 2);
                    int temp = matrix[j][z + j];
                    matrix[j][z + j] = matrix[matrix.Length - 1 - z - j][j];
                    matrix[matrix.Length - 1 - z - j][j] = matrix[matrix.Length - 1 - j][matrix.Length - 1 - z - j];
                    matrix[matrix.Length - 1 - j][matrix.Length - 1 - z - j] = matrix[z + j][matrix.Length - 1 - j];
                    matrix[z + j][matrix.Length - 1 - j] = temp;
                }
            }
        }

        public void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int PathSum(TreeNode root, int targetSum)
        {
            var pathSum = new Dictionary<int, int>();

            int result = 0;

            result = NodePaths(root, targetSum, 0, pathSum);

            return result;
        }

        private int NodePaths(TreeNode node, int targetSum, int currSum, Dictionary<int, int> pathSum)
        {
            int paths = 0;

            if (node == null)
                return paths;

            currSum += node.val;
            if (currSum == targetSum)
                paths++;

            if (pathSum.ContainsKey(currSum - targetSum))
                paths += pathSum[currSum - targetSum];

            if (pathSum.ContainsKey(currSum))
                pathSum[currSum]++;
            else pathSum.Add(currSum, 1);


            paths += NodePaths(node.left, targetSum, currSum, pathSum.ToDictionary(entry => entry.Key, entry => entry.Value));
            paths += NodePaths(node.right, targetSum, currSum, pathSum.ToDictionary(entry => entry.Key, entry => entry.Value));


            return paths;
        }

        public int PathSum2(TreeNode root, int targetSum)
        {
            if (root == null)
                return 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int result = 0;
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);

                if (node.val == targetSum)
                    result++;
                result += NodePaths(node, targetSum, node.val);
            }

            return result;
        }

        private int NodePaths(TreeNode node, int targetSum, int currSum)
        {
            int paths = 0;

            if (node.left != null)
            {
                if (currSum + node.left.val == targetSum)
                    paths++;

                paths += NodePaths(node.left, targetSum, currSum + node.left.val);
            }

            if (node.right != null)
            {
                if (currSum + node.right.val == targetSum)
                    paths++;

                paths += NodePaths(node.right, targetSum, currSum + node.right.val);
            }

            return paths;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var currentL1 = l1;
            var currentL2 = l2;
            var rootNode = new ListNode();
            var listNode = rootNode;

            int overflow = 0;
            int i = 0;
            while (currentL1 != null || currentL2 != null)
            {
                if (i != 0)
                {
                    listNode.next = new ListNode();
                    listNode = listNode.next;
                }

                int digit = overflow;

                if (currentL1 != null)
                {
                    digit += currentL1.val;
                    currentL1 = currentL1.next;
                }

                if (currentL2 != null)
                {
                    digit += currentL2.val;
                    currentL2 = currentL2.next;
                }


                if (digit > 9)
                {
                    overflow = digit / 10;
                }
                else overflow = 0;

                digit = digit % 10;

                listNode.val = digit;

                i++;
            }

            if (overflow != 0)
                listNode.next = new ListNode(overflow);

            return rootNode;
        }

        public int LengthOfLongestSubstring(string s)
        {
            var arr = Enumerable.Repeat(-1, 256).ToArray();

            int longestStreak = 0;
            int currentStreakStartIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (arr[s[i]] != -1 && arr[s[i]] >= currentStreakStartIndex)
                {
                    longestStreak = Math.Max(longestStreak, i - currentStreakStartIndex);

                    if (longestStreak > s.Length - currentStreakStartIndex)
                        return longestStreak;

                    currentStreakStartIndex = arr[s[i]] + 1;
                }

                arr[s[i]] = i;
            }

            if (s.Length - currentStreakStartIndex > longestStreak)
                longestStreak = s.Length - currentStreakStartIndex;


            return longestStreak;

        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var median = (nums1.Length + nums2.Length) / 2;

            //var max = Math.Max(nums1.Length > 0 ? nums1[nums1.Length - 1] : 0, nums2.Length > 0 ? nums1[nums2.Length - 1] : 0);

            //var l1 = FindMedian(nums1, max / 2);
            //var l2 = FindMedian(nums2, max / 2);

            return 0;
        }

        private IEnumerable<int> FindMedian(int[] arr, int value)
        {
            if (arr.Length == 0)
                return new List<int>();

            if (arr[0] < value)
                return new List<int> { arr[0] };

            if (arr[arr.Length - 1] < value)
                return new List<int> { arr[arr.Length - 1] };

            int medianIndex = arr.Length / 2;


            if (arr[medianIndex] < value && arr[medianIndex + 1] >= value)
                return new List<int> { arr[medianIndex], arr[medianIndex + 1] };
            else if (arr[medianIndex] > value)
                return FindMedian(arr.Take(medianIndex + 1).ToArray(), value);
            else return FindMedian(arr.Skip(medianIndex + 1).ToArray(), value);

        }

        public string LongestPalindrome(string s)
        {
            string result = s[0].ToString();
            var ss = string.Join('|', s.ToArray());
            for (int i = 1; i < ss.Length; i++)
            {
                if (result.Length > (ss.Length - i / 2) + 1)
                    break;

                int index = 1;
                int polindromLength = 1;
                while (i + index < ss.Length && i - index >= 0)
                {
                    if (ss[i - index] != ss[i + index])
                        break;

                    polindromLength += 2;
                    index++;
                }

                var newString = ss.Substring(i - polindromLength / 2, polindromLength).Replace("|", "");
                if (result.Length < newString.Length)
                    result = newString;
            }

            return result;
        }

        public int MaxProfit(int[] prices)
        {
            int index = 0;

            int profit = 0;
            for (int j = 1; j < prices.Length; j++)
            {
                if (prices[index] < prices[j])
                {
                    var temp = prices[j] - prices[index];
                    if (temp > profit)
                        profit = temp;

                }
                else index = j;
            }

            return profit;
        }


        public int ClimbStairs(int n)
        {
            var path = ClimbPath(0, 1, n);
            path += ClimbPath(0, 2, n);

            return path;
        }

        private int ClimbPath(int pastStairs, int increment, int allStairs)
        {
            if (pastStairs + increment == allStairs)
                return 1;
            else if (pastStairs + increment > allStairs)
                return 0;
            else
            {
                int paths = 0;
                paths += ClimbPath(pastStairs + increment, 1, allStairs);
                paths += ClimbPath(pastStairs + increment, 2, allStairs);

                return paths;
            }
        }
    }
}
