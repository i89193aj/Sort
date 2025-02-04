using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


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

        internal enum MemoryMethod
        {
            malloc,
            calloc
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

        /// <summary>
        /// 這個要去屬性那邊改允許不安全的程式碼
        /// </summary>
        /// <param name="_Size"></param>
        public unsafe void MemoryCreate(int _Size, MemoryMethod _MemoryMethod = MemoryMethod.malloc)
        {
            // 分配未初始化的記憶體
            IntPtr ptr = Marshal.AllocHGlobal(_Size * sizeof(int)); 

            switch (_MemoryMethod)
            {
                case MemoryMethod.malloc:
                    // 初始化記憶體為 0
                    for (int i = 0; i < _Size; i++)
                    {
                        Marshal.WriteInt32(ptr, i * sizeof(int), 0);
                    }
                    break;
                case MemoryMethod. calloc:
                    // 使用 memset 設為 0（等同於 calloc）
                    byte[] zeroBytes = new byte[_Size * sizeof(int)];
                    Marshal.Copy(zeroBytes.ToArray(), 0, ptr, _Size * sizeof(int));
                    break;
            }
        }

        public void MarshalWrite(IntPtr _ptr, int _size)
        {
            Marshal.WriteInt32(_ptr, sizeof(int));
        }

        /// <summary>
        /// 讀取指標矩陣
        /// </summary>
        /// <param name="_ptr"></param>
        /// <param name="_size"></param>
        /// <returns></returns>
        public int MarshalRead(IntPtr _ptr, int _size)
        {
            return Marshal.ReadInt32(_ptr, sizeof(int));
        }

        /// <summary>
        /// 釋放記憶體
        /// </summary>
        /// <param name="_ptr"></param>
        public void MarshalFree(IntPtr _ptr)
        {
            Marshal.FreeHGlobal(_ptr); 
        }
    }

    /// <summary>
    /// Reference：https://leetcode.com/problems/sort-an-array/solutions/1401412/c-clean-code-solution-fastest-all-15-sorting-methods-detailed/
    /// </summary>
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
                //看"Great較好!差別：第一種會一直交換;第二種只是單方便往前丟值，直到比icompare還小的才會把icompare值丟到這個位置的後一格!"
                switch (_goodmodel)
                {
                    case "Worse":
                        int index1 = 1;
                        while (index1 < nums.Length)
                        {
                            int index2 = index1 - 1;
                            int icompare = nums[index1];
                            while (index2 >= 0)
                            {

                                if (nums[index2 + 1] < nums[index2])
                                {
                                    // 使用 XOR 進行交換
                                    swap_Bit(ref nums[index2 + 1], ref nums[index2]);
                                }
                                else
                                {
                                    break;
                                }
                                index2--;
                            }
                            index1++;
                        }
                        break;

                    case "Great":
                        int index = 1;
                        while (index < nums.Length)
                        {
                            int index2 = index - 1;
                            int icompare = nums[index];
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
                            index++;
                        }
                        break;
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

            MergeRecursion(nums, 0, nums.Length - 1, _goodmodel);
            return nums;
        }

        /// <summary>
        /// Step.1 分解（Divide）：將問題分解為更小的子問題。
        /// </summary>
        /// <param name="_nums"></param>
        /// <param name="_firstIndex"></param>
        /// <param name="_LastIndex"></param>
        public void MergeRecursion(int[] _nums, int _firstIndex, int _LastIndex, string _goodmodel = "Great")
        {
            //當_LastIndex <= _firstIndex時，不再進遞迴
            if (_LastIndex <= _firstIndex) return;

            int _middleIndex = _firstIndex + (_LastIndex - _firstIndex >> 1);//注意：修先順序："* /" 大於 "+ -" 大於 ">> <<"
            MergeRecursion(_nums, _firstIndex, _middleIndex);
            MergeRecursion(_nums, _middleIndex + 1, _LastIndex);

            MergeArray(_nums, _firstIndex, _middleIndex, _LastIndex, _goodmodel);
        }

        /// <summary>
        /// Step.2 征服（Conquer）：遞迴解決這些子問題。
        /// Step.3 合併（Combine）：將子問題的解合成，得到最終的解。
        /// 這裡沒有Worse Great；三個方法差不多(指標還稍顯慢了)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="_FirstIndex"></param>
        /// <param name="_MiddleIndex"></param>
        /// <param name="_LastIndex"></param>
        public void MergeArray(int[] nums, int _FirstIndex, int _MiddleIndex, int _LastIndex, string _goodmodel = "Great")
        {
            //速度差不多
            switch (_goodmodel)
            {
                case "Worse":   
                    //宣告左右長度
                    int iLengthLeft = _MiddleIndex - _FirstIndex + 1;
                    int iLengthRight = _LastIndex - _MiddleIndex;

                    //new暫存Array
                    int[] Left = new int[iLengthLeft];
                    int[] Right = new int[iLengthRight];

                    //賦值到暫存
                    for (int i = 0; i < iLengthLeft; i++)
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
                    while (_iLeft < iLengthLeft)
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
                    break;
                case "Great"://編譯的比較完整(清晰易懂)
                    if (_FirstIndex >= _LastIndex) return;
                  
                    int l = _FirstIndex, r = _MiddleIndex + 1, k = 0, size = _LastIndex - _FirstIndex + 1;
                    int[] sorted = new int[size];
                    while (l <= _MiddleIndex && r <= _LastIndex)
                        sorted[k++] = nums[l] < nums[r] ? nums[l++] : nums[r++];
                    while (l <= _MiddleIndex)
                        sorted[k++] = nums[l++];
                    while (r <= _LastIndex)
                        sorted[k++] = nums[r++];

                    for (k = 0; k < size; k++)
                        nums[k + _FirstIndex] = sorted[k];


                    break;
                case "Pointer":
                    int left = _FirstIndex, right = _MiddleIndex + 1, main1 = 0, size1 = _LastIndex - _FirstIndex + 1;

                    // 使用 Marshal.AllocHGlobal 分配未初始化的記憶體
                    IntPtr ptrSorted = Marshal.AllocHGlobal(size1 * sizeof(int));

                    try
                    {
                        // Merging process
                        while (left <= _MiddleIndex && right <= _LastIndex)
                            Marshal.WriteInt32(ptrSorted, (main1++) * sizeof(int), nums[left] < nums[right] ? nums[left++] : nums[right++]);

                        while (left <= _MiddleIndex)
                            Marshal.WriteInt32(ptrSorted, (main1++) * sizeof(int), nums[left++]);

                        while (right <= _LastIndex)
                            Marshal.WriteInt32(ptrSorted, (main1++) * sizeof(int), nums[right++]);

                        // 將合併後的結果寫回 nums
                        for (k = 0; k < size1; k++)
                            nums[k + _FirstIndex] = Marshal.ReadInt32(ptrSorted, k * sizeof(int));
                    }
                    finally
                    {
                        // 釋放分配的記憶體
                        Marshal.FreeHGlobal(ptrSorted);
                    }
                    break;
            }
        }


        
        #endregion
    }
}
