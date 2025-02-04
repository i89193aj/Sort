using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace OscarAlg
{
    internal class Alg
    {
        internal enum SortMethod
        {
            C_Sharp_Lib,
            Insert,
            Select,
            Bubble,
            Merge,
            Quickly,
        }
        //不需要額外的內存來儲存中介變數，並且使用位元運算的方式可能略快
        public void swap_Bit(ref int a, ref int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }

        public void swap_OP(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }

    internal class Sort : Alg
    {
        /// <summary>
        /// InsertSort
        /// </summary>
        /// <param name="nums"></param> Input Array
        /// <param name="_goodmodel"></param>  Choose Model
        /// <returns></returns>
        public int[] InsertSort(int[] nums, string _goodmodel = "Great")
        {
            //int[] ans = new int[nums.length];
            int index1 = 1;
            while (index1 < nums.Length)
            {
                int index2 = index1 - 1;
                int icompare = nums[index1];

                //看"Great較好!差別：第一種會一直交換;第二種只是單方便往前丟值，直到比icompare還小的才會把icompare值丟到這個位置的後一格!"
                switch (_goodmodel)
                {
                    case "Worse":
                        while (index2 >= 0)
                        {

                            if (nums[index2 + 1] < nums[index2])
                            {
                                // 使用 XOR 進行交換
                                nums[index2] = nums[index2 + 1] ^ nums[index2];      // 第一步：a = a ^ b
                                nums[index2 + 1] = nums[index2] ^ nums[index2 + 1];  // 第二步：b = (a ^ b) ^ b = a ^ b
                                nums[index2] = nums[index2] ^ nums[index2 + 1];      // 第三步：a = (a ^ b) ^ a = b ^ a
                            }
                            else
                            {
                                break;
                            }
                            index2--;
                        }
                        index1++;
                        break;

                    case "Great":
                        while (index2 >= 0)
                        {
                            if (icompare < nums[index2])
                            {
                                nums[index2 + 1] = nums[index2];
                                index2--;
                            }
                            else
                                break;
                        }
                        nums[index2 + 1] = icompare;
                        index1++;
                        break;
                }
                while (index2 >= 0)
                {
                    if (icompare < nums[index2])
                    {
                        nums[index2 + 1] = nums[index2];
                        index2--;
                    }
                    else
                        break;
                }
                nums[index2 + 1] = icompare;
                index1++;
            }
            return nums;

            #region - LeeCode 解法 -
            //int index1 = 1;
            //int index2;

            //while (index1 < nums.Length)
            //{
            //    index2 = index1 - 1;
            //    int icompare = nums[index1];
            //    while (index2 >= 0 && icompare < nums[index2])
            //    {
            //        nums[index2 + 1] = nums[index2];
            //        index2--;
            //    }
            //    nums[index2 + 1] = icompare;
            //    index1++;
            //}
            //return nums;
            #endregion
        }

        /// <summary>
        /// BubbleSort
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="_goodmodel"></param>
        /// <returns></returns>
        public int[] BubbleSort(int[] nums, string _goodmodel = "Great")
        {
            int i = 0, j = 0;
            int itemp_MAX = nums[0];
            int ilimit = nums.Length - 1;   //限制超出範圍

            //看"Great就好!
            //差別：第一種會一直交換(標準模式);第二種在交換的時候，把比較完的大值給到itemp_MAX，這樣就不需要一直交換"
            switch (_goodmodel)
            {
                case "Worse":
                    for (i = nums.Length - 1; i >= 0; i--)
                        for (j = 0; j < i; j++)
                            if (nums[j] > nums[j + 1])
                                swap_Bit(ref nums[j], ref nums[j + 1]);
                    break;

                case "Great":
                    while (j < ilimit)
                    {
                        i = 0;
                        while (i < ilimit - j)
                        {
                            //若下一個比前一個小，保留大值(itemp)，小值交換到前面
                            if (nums[i + 1] < itemp_MAX)
                                nums[i] = nums[i + 1];
                            else //若下一個比前一個大，將新的大值保留(itemp)，原本的大值給當前位置
                            {
                                nums[i] = itemp_MAX;
                                itemp_MAX = nums[i + 1];
                            }
                            i++;
                        }
                        nums[i] = itemp_MAX;
                        itemp_MAX = nums[0];
                        j++;
                    }

                    break;
            }

            return nums;
        }

        /// <summary>
        /// SelectSort
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="_goodmodel"></param>
        /// <returns></returns>
        public int[] SelectSort(int[] nums, string _goodmodel = "Great")
        {
            int i, j = 0;
            int ilimit = nums.Length - 1;   //限制超出範圍

            //差別：第一種會一直交換(標準模式);第二種在比較的時候，每輪只記錄最小值，這樣就不需要一直交換"
            switch (_goodmodel)
            {
                case "Worse":

                    while (j < nums.Length - 1)
                    {
                        i = j + 1;
                        while (i < nums.Length)
                        {
                            if (nums[i] < nums[j])
                                swap_Bit(ref nums[i], ref nums[j]);

                            i++;
                        }

                        j++;
                    }

                    break;
                case "Great":
                    while (j < nums.Length - 1)
                    {
                        i = j + 1;
                        int minIndex = j; // 假設當前 j 是最小值的索引

                        // 找到最小值的索引
                        while (i < nums.Length)
                        {
                            if (nums[i] < nums[minIndex])
                                minIndex = i;

                            i++;
                        }

                        // 只有當最小值的索引不是當前 j 時才進行交換
                        if (minIndex != j)
                            swap_Bit(ref nums[minIndex], ref nums[j]);

                        j++;
                    }

                    break;
            }
            return nums;
        }

        /// <summary>
        /// C#內建Sort
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="_goodmodel"></param>
        /// <returns></returns>
        public int[] CSharpSort(int[] nums, string _goodmodel = "Great")
        {
            #region - 差別說明 -
            /*
               差別：
               OrderBy 是 LINQ 的一部分：它的背後通常使用 合併排序（MergeSort） 或 快速排序（Quicksort），並且 OrderBy 返回的是一個新的排序集合，並"不會修改原始數組或列表"。
                                         排序完成後，你需要將結果轉換回數組（ToArray()），這樣就會有額外的開銷。
               轉換成本：由於 OrderBy 返回的是 IEnumerable<T>，你需要將排序後的結果轉換為數組或列表，這就會增加一些額外的性能開銷。
             */
            #endregion

            switch (_goodmodel)
            {
                case "Worse":   //2. Method2: Stable Sort (Accepted) [T(n) = O(n * log n)]
                    nums = nums.OrderBy(x => x).ToArray();

                    break;
                case "Great":   //1. Method1: Standard Sort (Accepted) [T(n) = O(n * log n)]
                    Array.Sort(nums);

                    break;

            }

            return nums;
        }
        #region - Merge Sort -
        /// <summary>
        /// 分解（Divide）：將問題分解為更小的子問題。
        /// 征服（Conquer）：遞迴解決這些子問題。
        /// 合併（Combine）：將子問題的解合成，得到最終的解。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="_goodmodel"></param>
        /// <returns></returns>
        public int[] MergeSort(int[] nums, string _goodmodel = "Great")
        {
            // 如果數組長度為1，直接返回，不進行排序
            //if (nums.Length <= 1) return nums; 

            MergeRecursion(nums, 0, nums.Length - 1);
            return nums;
        }

        /// <summary>
        /// Step.1 分解（Divide）：將問題分解為更小的子問題。
        /// </summary>
        /// <param name="_nums"></param>
        /// <param name="_firstIndex"></param>
        /// <param name="_LastIndex"></param>
        public void MergeRecursion(int[] _nums, int _firstIndex, int _LastIndex)
        {
            //當_LastIndex <= _firstIndex時，不再進遞迴
            if (_LastIndex <= _firstIndex) return;

            int _middleIndex = _firstIndex + (_LastIndex - _firstIndex >> 1);//注意：修先順序："* /" 大於 "+ -" 大於 ">> <<"
            MergeRecursion(_nums, _firstIndex, _middleIndex);
            MergeRecursion(_nums, _middleIndex + 1, _LastIndex);

            //MergeArray(_nums, _firstIndex, _middleIndex, _LastIndex);
            MergeArrayInPlace(_nums, _firstIndex, _middleIndex, _LastIndex);
        }

        /// <summary>
        /// Step.2 征服（Conquer）：遞迴解決這些子問題。
        /// Step.3 合併（Combine）：將子問題的解合成，得到最終的解。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="_FirstIndex"></param>
        /// <param name="_MiddleIndex"></param>
        /// <param name="_LastIndex"></param>
        public void MergeArray(int[] nums, int _FirstIndex, int _MiddleIndex, int _LastIndex)
        {
            //宣告左右長度
            int iLengthLeft = _MiddleIndex - _FirstIndex + 1;
            int iLengthRight = _LastIndex - _MiddleIndex;

            //new暫存Array
            int[] Left = new int[iLengthLeft];
            int[] Right = new int[iLengthRight];

            //賦值到暫存
            for(int i = 0;i < iLengthLeft;i++)
                Left[i] = nums[_FirstIndex + i];
            for (int i = 0; i < iLengthRight; i++)
                Right[i] = nums[_MiddleIndex + 1 + i];

            //比較兩邊的數組大小，將值重新排列給nums
            int _iLeft = 0; int _iRight = 0;//這個index是給暫存Array用的
            int iMain = _FirstIndex;
            while (_iLeft < iLengthLeft && _iRight < iLengthRight)
            {
                if (Left[_iLeft] <= Right[_iRight])
                { 
                    nums[iMain] = Left[_iLeft];
                    _iLeft++;
                }
                else
                {
                    nums[iMain] = Right[_iRight];
                    _iRight++;
                }

                iMain++;
            }

            //把剩下沒排進去的數組排進去(因為上面可以左邊 or 右邊會先排完)
            while(_iLeft < iLengthLeft)
            {
                nums[iMain] = Left[_iLeft];
                _iLeft++;
                iMain++;
            }

            while (_iRight < iLengthRight)
            {
                nums[iMain] = Right[_iRight];
                _iRight++;
                iMain++;
            }
        }

        public void MergeArrayInPlace(int[] nums, int _FirstIndex, int _MiddleIndex, int _LastIndex)
        {
            // 兩個指針：一個指向左子數組的開始，另一個指向右子數組的開始
            int left = _FirstIndex;
            int right = _MiddleIndex + 1;

            // 合併過程中用一個臨時變數 i 來處理元素插入
            while (left <= _MiddleIndex && right <= _LastIndex)
            {
                // 若左子數組的當前元素小於等於右子數組的當前元素，則不需更動
                if (nums[left] <= nums[right])
                {
                    left++;
                }
                else
                {
                    // 需要將右子數組的元素插入到左子數組位置
                    int temp = nums[right];
                    int i = right;

                    // 把左邊比右邊大的元素往右邊移動
                    while (i > left)
                    {
                        nums[i] = nums[i - 1];
                        i--;
                    }
                    // 將右邊元素放到正確位置
                    nums[left] = temp;

                    // 移動指針
                    left++;
                    right++;
                }
            }
        }
            #endregion
    }
}
