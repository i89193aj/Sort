using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;


namespace OscarAlg
{
    internal class Alg
    {

        internal enum SortMethod
        {
            Insert = 0,
            Bubble,
            Select,
            C_Sharp_Lib,
            Merge,
            Quickly,
            Radix,
            Counting,
            Buket,
            Heap,
        }

        internal enum MemoryMethod
        {
            malloc,
            calloc
        }

        //不需要額外的內存來儲存中介變數，並且使用位元運算的方式可能略快
        /// <summary>
        /// 備：當Array[i]跟Array[i]自己跟自己換的時候，會出現問題(因為都是操作同一個記憶體位置)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
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
                case MemoryMethod.calloc:
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

        /// <summary>
        /// 這個跟下面那個ref取出來的第一個矩陣記憶體位置一樣
        /// </summary>
        /// <param name="_nums"></param>
        /// <returns></returns>
        public unsafe static string[] FindAddress(int[] _nums, bool isCcapital = true)
        {
            string[] sPointerAddess = new string[2];
            //用這個找出
            fixed (int* p = &_nums[0])
            {
                int[]* Point_pointer = &_nums;
                IntPtr pointer = (IntPtr)p;                 //指向"矩陣的第一個值的位置"(這個會跟外面的指標位置一樣，因為本來就是兩個物件指向同一個記憶體位置而已)
                IntPtr pointer2 = (IntPtr)Point_pointer;    //指向"矩陣的指標的記憶體位置"(這個會跟外面的指標位置不一樣，因為本來就是兩個物件指向同一個記憶體位置而已，可以把物件想成指標)
                sPointerAddess[0] = isCcapital? pointer.ToString("X"): string.Format("{0:x}", pointer);
                sPointerAddess[1] = isCcapital? pointer2.ToString("X"): string.Format("{0:x}", pointer2);
            }
            return sPointerAddess; 
        }

        public unsafe static string FindAddressReference(ref int[] _nums, bool isCcapital = false)
        {
            string sPointerAddess = "";
            //用這個找出
            fixed (int* p = &_nums[0])
            {
                IntPtr pointer = (IntPtr)p;
                sPointerAddess = isCcapital? pointer.ToString("X") : string.Format("{0:x}", pointer);
            }
            return sPointerAddess;
        }

    }

    /// <summary>
    /// Reference：https://leetcode.com/problems/sort-an-array/solutions/1401412/c-clean-code-solution-fastest-all-15-sorting-methods-detailed/
    /// CountSort(98.97%) 、 RadixSort(97.71%)
    /// </summary>
    internal class Sort : Alg
    {
        //所有的index跟length的關係就是 +1 or -1
        #region - Stable VS Unstable -
        /*
        一、穩定排序（Stable Sort）：
        插入排序（Insert Sort）：
        穩定排序。因為插入排序在處理相同元素時會保持其相對順序。

        氣泡排序（Bubble Sort）：
        穩定排序。氣泡排序會將相同元素保持原來順序。

        合併排序（Merge Sort）：
        穩定排序。在合併過程中，會保留相同元素的原始順序。

        計數排序（Counting Sort）：
        穩定排序。在計數過程中，計數排序會保留相同元素的相對順序。

        基數排序（Radix Sort）：
        穩定排序。在對各個數字位進行排序時，基數排序會保留相同元素的順序。

        二、不穩定排序（Unstable Sort）：(打亂再重組)
        選擇排序（Selection Sort）：
        不穩定排序。由於選擇排序在每輪選擇最小或最大元素時，會交換元素，可能會改變相同元素的順序。

        快速排序（Quick Sort）：
        不穩定排序。快速排序在分割過程中可能會打亂相同元素的順序。

        桶排序（Bucket Sort）：
        不穩定排序。桶排序會將元素分配到不同的桶中，然後排序桶中的元素，這個過程會改變原始順序。

        堆排序（Heap Sort）：
        不穩定排序。堆排序是基於堆結構的，在過程中可能會打亂相同元素的順序。

        總結：
        穩定排序：插入排序、氣泡排序、合併排序、計數排序、基數排序
        不穩定排序：選擇排序、快速排序、桶排序、堆排序

        Ex：(Alice, 25)  (Bob, 30)  (Carol, 25) 根據年齡排序：
            不穩定結果：
            (Carol, 25) (Alice, 25) (Bob, 30)
            穩定排序結果：
            (Alice, 25) (Carol, 25) (Bob, 30)  
        */

        #endregion

        //public new void FindAddress(int[] nums)
        //{
        //    // 子類別的實作
        //}

        //public static void FindAddress(int[] nums)
        //{
        //    // 使用 base 呼叫父類別的方法
        //    base.FindAddress(nums);
        //}

        internal enum InsertSortMethod
        {
            Great,
            Worse,
        }

        internal enum BubbleSortMethod
        {
            Great,
            Worse,
        }

        internal enum SelectSortMethod
        {
            Great,
            Worse,
        }

        internal enum CSharpSortMethod
        {
            Great,
            Worse,
        }

        internal enum MergeSortMethod
        {
            Great,
            Normal,
            Pointer,
            Inplace,
        }

        internal enum QuickSortMethod
        {
            Radom,
            Normal,
            Averg,
        }

        internal enum RadixSortMethod
        {
            MinVal,
            Partitioning,
        }

        internal enum CoutingSortMethod
        {
            CumulativeSum,
            NonCumulativeSum,
            Partition,
        }

        internal enum BuketSortMethod
        {
            Normal,
        }

        internal enum HeapSortMethod
        {
            MaxHeap,
            MinHeap,
        }
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

            switch (_goodmodel)
            {
                case "Inplace":
                    InplaceMerge(_nums, _firstIndex, _middleIndex, _LastIndex, _goodmodel);
                    break;
                default:
                    OutplaceMerge(_nums, _firstIndex, _middleIndex, _LastIndex, _goodmodel);
                    break;
            }
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
        public void OutplaceMerge(int[] nums, int _FirstIndex, int _MiddleIndex, int _LastIndex, string _goodmodel = "Great")
        {
            //速度差不多
            switch (_goodmodel)
            {
                //MyOutplace
                case "Normal":   
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
                //GitOutplace
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

        public void InplaceMerge(int[] nums, int _FirstIndex, int _MiddleIndex, int _LastIndex, string _goodmodel = "Great")
        {
            if (_FirstIndex >= _LastIndex) return;

            int l = _FirstIndex, r = _MiddleIndex + 1, size = _LastIndex - _FirstIndex + 1;
            while (l <= _MiddleIndex && r <= _LastIndex) {
                if (nums[l] <= nums[r]) l++;
                else
                {
                    int val = nums[r];

                    for (int k = r++; k > l; k--) //這裡的r++只是為了移動右邊數組要比較的下一個數字，而代入的k = r(並不是r++)
                        nums[k] = nums[k - 1];

                    nums[l++] = val;
                    _MiddleIndex++;
                }
            }
        }

        #region - Outplace Merging VS Inplace Merging -
        /*
          1.Outplace Merging (外部合併)：
          額外空間：需要額外的空間來存儲中間結果，通常是 O(n) 的空間，其中 n 是數組的大小。
          簡單易實現：因為合併過程不需要額外考慮如何在原數組上進行原地合併，所以實現比較直觀。
          時間複雜度：時間複雜度仍然是 O(n log n)，不受額外空間的影響。
          優點：簡單且容易理解，適合大多數情況。
          2. Inplace Merging (原地合併)：
          無需額外空間：合併過程是在原地進行的，不需要額外的 O(n) 空間。
          實現較為複雜：由於需要操作原數組，因此實現起來較為複雜，特別是需要處理元素的交換或移動，這增加了實現難度。
          時間複雜度：時間複雜度仍然是 O(n log n)，但由於原地操作，可能會有一些額外的操作（例如移動元素），從而導致實際執行效率略低。
          優點：
          不需要額外的存儲空間，節省內存。
          在內存限制較為嚴格的情況下很有用。      
         */
        #endregion
        #endregion

        #region - QuickSort -
        public int[] QuickSort(int[] nums, string _goodmodel = "Great")
        {

            quickSort(nums, 0, nums.Length - 1, _goodmodel);
            return nums;
        }

        public void quickSort(int[] _nums, int _firstIndex, int _LastIndex, string _goodmodel = "Normal")
        {
            if (_firstIndex < _LastIndex)
            {
                switch (_goodmodel)
                {
                    //MyOutplace
                    case "Normal":
                        break;
                    case "Radom":
                        swap_OP(ref _nums[new Random().Next(_firstIndex, _LastIndex)], ref _nums[_LastIndex]);
                        //swap(nums[low + rand() % (high - low + 1)], nums[low]); < = c++
                        break;
                    case "Averg":
                        swap_OP(ref _nums[AverageForPivot(_nums, _firstIndex, _LastIndex)], ref _nums[_LastIndex]);
                        break;
                }

                int pi = partition(_nums, _firstIndex, _LastIndex);

                // 對分割的兩部分進行遞迴排序
                quickSort(_nums, _firstIndex, pi - 1, _goodmodel);
                quickSort(_nums, pi + 1, _LastIndex, _goodmodel);
            }
        }

        /// <summary>
        /// 實測下來，先算平均沒有比較快
        /// </summary>
        /// <param name="_nums"></param>
        /// <param name="_firstIndex"></param>
        /// <param name="_LastIndex"></param>
        /// <returns></returns>
        public int AverageForPivot(int[] _nums, int _firstIndex, int _LastIndex)
        {
            //計算平均值
            float iaverg = 0;
            for (int k = _firstIndex; k <= _LastIndex; k++)
            {
                iaverg += _nums[k];
            }
            iaverg /= (_LastIndex - _firstIndex + 1);

            //計算哪個值最接近平均值
            float distance_Value = Math.Abs(iaverg - _nums[_firstIndex]);
            int iPivot_Index = _firstIndex;
            for (int k = _firstIndex; k <= _LastIndex; k++)
            {
                if (Math.Abs(iaverg - _nums[k]) < distance_Value)
                {
                    iPivot_Index = k;
                }
            }

            return iPivot_Index;
        }

        /// <summary>
        /// 計算pivot值最後位置
        /// </summary>
        /// <param name="_nums"></param>
        /// <param name="_firstIndex"></param>
        /// <param name="_LastIndex"></param>
        /// <param name="_goodmodel"></param>
        /// <returns></returns>
        public int partition(int[] _nums, int _firstIndex, int _LastIndex, string _goodmodel = "Normal")
        {
            int IForReturn = 0;
            
            switch (_goodmodel)
            {
                //MyOutplace
                case "MyOutplace":
                    int iIndex_temp = 0;
                    int pivot = 0;
                    pivot = _nums[_LastIndex];
                    iIndex_temp = _firstIndex - 1; //紀錄pivot交換幾次
                    for (int i = _firstIndex; i < _LastIndex; i++)
                    {
                        if (_nums[i] < pivot)
                        {
                            iIndex_temp++;
                            swap_OP(ref _nums[i], ref _nums[iIndex_temp]);
                        }
                    }
                    //最後把最後一個值丟去(iIndex_temp + 1)，因為交換次數 = 小於pivot次數
                    swap_OP(ref _nums[iIndex_temp + 1], ref _nums[_LastIndex]);
                    //回傳pivot值最後位置
                    return iIndex_temp + 1;

                    IForReturn = iIndex_temp + 1;
                    break;

                case "Normal"://寫法乾淨
                    int ipivot_Index = _LastIndex;
                    int iright_Idx = _LastIndex - 1;
                    int ileft_Idx = _firstIndex;

                    while (ileft_Idx <= iright_Idx)
                    {
                        if (_nums[ileft_Idx] < _nums[ipivot_Index]) ileft_Idx++;
                        else if (_nums[iright_Idx] >= _nums[ipivot_Index]) iright_Idx--;
                        else swap_OP(ref _nums[iright_Idx], ref _nums[ileft_Idx]);
                    }

                    swap_OP(ref _nums[ipivot_Index], ref _nums[ileft_Idx]);
                    return ileft_Idx;

                    IForReturn = ileft_Idx;
                    break;              
            }
            //回傳pivot值最後位置
            return IForReturn;
        }
        #endregion

        #region - CountSort -
        /// <summary>
        /// 計數排序法(For integers) => (98.97%)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="_goodmodel"></param>
        /// <param name="isAscending"></param> True = 升序
        /// <returns></returns>
        public int[] CountSort(int[] nums, string _goodmodel = "CumulativeSum", bool isAscending = true)
        {
            int iMax = nums[0]; int iMin = nums[0];

            //找最大值
            iMax = nums.Max();
            //找最小值
            iMin = nums.Min();

            #region- 比大小說明 -
            #region - 並行不知道為什麼沒有比較快 -
            //Parallel.For(0, nums.Length, (i) =>
            //{
            //    if (nums[i] > iMax)
            //    {
            //        iMax = nums[i];
            //    }
            //});
            #endregion

            #region - 自己寫比大小也沒比內建LINQ快 -
            //for (int i = 1; i < nums.Length; i++)
            //    if (nums[i] > iMax)
            //        iMax = nums[i];
            ////找最小值
            //for (int i = 1; i < nums.Length; i++)
            //    if (nums[i] < iMin)
            //        iMin = nums[i];
            #endregion
            #endregion

            //iFeq 他會自己創建新的矩陣，他的index就是原本nums最大值與最小值之間所有的值(Ex：iFeqPointer = num[i] - iMin)
            int iFeqSize = iMax - iMin + 1;
            int[] iFeq = new int[iFeqSize];
            int[] iSortTemp = new int[nums.Length];

            int j = 0;
            //出現過的數字，就在那個index對應的值++(表示出現過一次)
            while (j < nums.Length)
            {
                iFeq[nums[j] - iMin]++;
                j++;
            }

            int k = 0; int _iSortPointer = 0;
            switch (_goodmodel)
            {
                case "CumulativeSum":
                    //累加原因：因為當前的次數是包含前面所有的次數，所以當之後你選到這個數字時，只要把這個數字-1就直接是你要排列的index
                    if (isAscending)
                        for (int iFeqPointer = 1; iFeqPointer < iFeqSize; iFeqPointer++)
                            iFeq[iFeqPointer] += iFeq[iFeqPointer - 1];
                    else
                        for (int iFeqPointer = iFeqSize - 2; iFeqPointer <= 0; iFeqPointer--)
                            iFeq[iFeqPointer] += iFeq[iFeqPointer + 1];

                    //Stability：找出num[i]對應的"iFeq[index]-1"就是新的sort的index(記得做完要再--)，不然下一次會錯!
                    while (_iSortPointer < iSortTemp.Length)
                    {
                        iSortTemp[iFeq[nums[_iSortPointer] - iMin]-- - 1] = nums[_iSortPointer];//_iSortPointer] - iMin]--：這個會等這行整個做完才做--
                        _iSortPointer++;
                    }
                    break;
                case "NonCumulativeSum":
                    while (k < iFeqSize)
                    {
                        if (iFeq[k] > 0)//不累加：直接判斷iFeq出現幾次(所以iFeq[i] = 0，表示沒出現過這個數字)
                        {
                            iSortTemp[_iSortPointer] = iMin + k;
                            _iSortPointer++;
                            iFeq[k]--;
                        }
                        else
                        {
                            k++;
                        }
                    }
                    break;
                case "Partition":
                    CountPartitionSort(nums);   //稍微慢一點
                        return nums;
                    break;
            }

            #region - 比較記憶體的差異 -
            /*
             * 第一種會改變外部記憶體位置：
            nums = iSortTemp;   //這個會改變記憶體的位置
            第二種不會改變外部記憶體位置：(直接在記憶體上操作)
            for(int i = 0;i < nums.Length ;i++)
                nums[i] = iSortTemp[i];
            */
            #endregion
            return iSortTemp;
        }

        /// <summary>
        /// 將非負數和負數分成兩邊做CountSort
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] CountPartitionSort(int[] nums)
        {
            int NonNegMinIndex = GetNonNegMinIndex(nums); //找非負數Index
            if (NonNegMinIndex <= 1) Seperate_CountingSort(nums, NonNegMinIndex, nums.Length - 1); //如果負數只有一個，那非負數也不需要排列(所有是 <= 1)
            else
            {
                Seperate_CountingSort(nums, 0, NonNegMinIndex - 1);
                Seperate_CountingSort(nums, NonNegMinIndex + 1, nums.Length - 1);
            }

            return nums;
        }

        private void Seperate_CountingSort(int[] num, int _iFirstIdx, int _iLastIdx, bool isAscending = true)
        {
            if (_iFirstIdx >= _iLastIdx) return;

            int iMax = num.Max(); int iMin = num.Min();
            int iFeqSize = iMax - iMin + 1;
            int[] iFeq = new int[iFeqSize];
            int iSortSize = _iLastIdx - _iFirstIdx + 1;
            int[] iSort = new int[iSortSize];

            for (int i = _iFirstIdx; i <= _iLastIdx; i++)
                iFeq[num[i] - iMin]++;

            if (isAscending)
                for (int i = 1; i < iFeqSize; i++)
                    iFeq[i] += iFeq[i - 1];
            else
                for (int i = iFeqSize - 2; i >= 0; i--)
                    iFeq[i] += iFeq[i + 1];

            for (int i = _iFirstIdx; i <= _iLastIdx; i++)
                iSort[iFeq[num[i] - iMin]-- - 1] = num[i];

            for (int i = 0; i < iSortSize; i++)
                num[_iFirstIdx + i] = iSort[i];
        }
        #endregion

        #region - RadixSort -
        private int GetSingleDigit(int _num, int _factor, int _iDivisor)
        {
            return _num / _factor % _iDivisor;
        }

        /// <summary>
        /// RadixSort (97%多)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="_goodmodel"></param>
        /// <returns></returns>
        public int[] RadixSort(int[] nums, string _goodmodel = "MinVal")
        {
            switch(_goodmodel)
            {
                case "MinVal":
                    nums = RadixMinValSort(nums);
                    break;
                case "Partitioning":
                    nums = RadixPartitioningSort(nums);
                    break;
            }
            return nums;
        }

        #region - RadixMinValSort -
        public int[] RadixMinValSort(int[] nums)
        {
            int iDivisor = 10;

            //找最小值
            int iMin = nums.Min();

            //先全部往左位移(讓負值變成"+")
            int k = 0;
            while(k < nums.Length)
            {
                nums[k] -= iMin;
                k++;
            }
            //找最大值
            int iMax = nums.Max();

            //
            int factor = 1; //為了讓每個數字每一輪都能退一位
            while(iMax/factor != 0)
            {
                nums = RadixCountingSort(nums, factor, iDivisor);            
                factor *= iDivisor;
            }

            k = 0;
            while (k < nums.Length)
            {
                nums[k] += iMin;
                k++;
            }

            return nums;
        }

        /// <summary>
        /// 結合CountingSort
        /// </summary>
        /// <param name="_nums"></param>
        /// <param name="_maxValue"></param>
        /// <param name="_minValue"></param>
        /// <param name="_factor"></param>
        /// <param name="_iDivisor"></param>
        /// <param name="_isAscending"></param>
        /// <returns></returns>
        private int[] RadixCountingSort(int[] _nums, int _factor,int _iDivisor,bool _isAscending = true)
        {
            int[] iFeq = new int[_iDivisor];
            int[] iSort = new int[_nums.Length];

            for(int i = 0;i < _nums.Length ;i++)
                iFeq[GetSingleDigit(_nums[i], _factor, _iDivisor)]++;

            if (_isAscending)
                for (int i = 1; i < _iDivisor; i++)
                    iFeq[i] += iFeq[i - 1];
            else
                for (int i = _iDivisor - 2; i <= 0; i--)
                    iFeq[i] += iFeq[i + 1];

            for (int i = _nums.Length - 1; i >= 0; i--)
                iSort[iFeq[GetSingleDigit(_nums[i], _factor, _iDivisor)]-- -1] = _nums[i];           

            return iSort;
        }       
        #endregion

        #region - RadixSort Partitioning -
        /// <summary>
        /// 得到非負數的最小index
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int GetNonNegMinIndex(int[] nums)
        {
            int NonNegMinIndex = nums.Length; int NonNegMinVal = int.MaxValue;
            int NegMinIndex = nums.Length; int NegMinVal = int.MaxValue;
            //找到最小非負數的值跟index 和 找到最負數的值跟index
            for (int i=0;i < nums.Length; i++)
            {
                //非負數的最小值
                if (nums[i] >= 0 && nums[i] < NonNegMinVal)
                {
                    NonNegMinIndex = i; NonNegMinVal = nums[i];
                }
                //數組最小值
                if (nums[i] < NegMinVal)
                {
                    NegMinIndex = i; NegMinVal = nums[i];
                }

            }
            //判斷是不是只有純負數 
            if(NonNegMinIndex < nums.Length)
            {
                //先將最小非負值丟到nums的最前面(準備做一次性QuickSort(雙指標操作))
                if (NonNegMinIndex > 0) swap_OP(ref nums[0], ref nums[NonNegMinIndex]); 
                //判斷是不是有負數(如果有，把非負數與負數分開；沒有的話，直接回傳非負數index)
                if (NegMinIndex < nums.Length)
                {
                    if (nums[NegMinIndex] >= 0) NonNegMinIndex = 0;     //沒有負數
                    else NonNegMinIndex = SeparateNegAndNonNeg(nums);   //有負數(就需要找非負數的index)	
                }
            }

            return NonNegMinIndex;
        }

        /// <summary>
        /// SeparateOnce(以數組的最左邊為pivot分兩區)
        /// </summary>
        /// <param name="_nums"></param>
        /// <param name="_FirstIdx"></param>
        /// <param name="_LastIdx"></param>
        /// <returns></returns>
        public int SeparateNegAndNonNeg(int[] _nums, int _FirstIdx = 0, int _LastIdx = -1)
        {
            if(_LastIdx == -1) _LastIdx = _nums.Length - 1;
            int NonNegMinIndex_Pivot = _FirstIdx;  int ileft = NonNegMinIndex_Pivot + 1; int iRight = _LastIdx;
            //Sliding Window
            while(ileft <= iRight)
            {
                if (_nums[ileft] < _nums[NonNegMinIndex_Pivot]) ileft++;
                else if (_nums[iRight] >= _nums[NonNegMinIndex_Pivot]) iRight--;
                else swap_OP(ref _nums[iRight], ref _nums[ileft]);
            }
            //如果pivot在左側，拿irigth;在右邊，則拿ileft
            swap_OP(ref _nums[iRight], ref _nums[NonNegMinIndex_Pivot]);

            return iRight;
        }

        public int[] RadixPartitioningSort(int[] nums)
        {
            int NonNegMinIndex = GetNonNegMinIndex(nums); //找非負數Index
            if (NonNegMinIndex <= 1)
            {
                Radix_CountingSort(nums, NonNegMinIndex, nums.Length - 1); //如果負數只有一個，那非負數也不需要排列(所有是 <= 1)
            }
            else
            {
                Radix_CountingSort(nums, 0, NonNegMinIndex - 1, false, false);         //負數排列
                Radix_CountingSort(nums, NonNegMinIndex + 1, nums.Length - 1);  //非負數排列
            }

            return nums;
        }

        /// <summary>
        /// 以Radix做CountSort
        /// </summary>
        /// <param name="num"></param>
        /// <param name="_iFirstIdx"></param>
        /// <param name="_iLastIdx"></param>
        /// <param name="isAscending"></param>
        public void Radix_CountingSort(int[] num, int _iFirstIdx, int _iLastIdx, bool _MostOneNegative = true, bool isAscending = true)
        {
            if (_iFirstIdx >= _iLastIdx) return;
            int iMax = Math.Abs(num[_iFirstIdx]);
            int iMaxIndex = 0;

            if (!_MostOneNegative)
            {
                for (int i = _iFirstIdx + 1; i <= _iLastIdx; i++)
                {
                    if (Math.Abs(num[i]) > Math.Abs(iMax))
                    {
                        iMax = Math.Abs(num[i]);
                        iMaxIndex = i;
                    }
                }

                iMax = num[iMaxIndex];
            }
            else
            {
                for (int i = _iFirstIdx + 1; i <= _iLastIdx; i++)
                    if (num[i] > iMax) iMax = num[i];
            }

            int factor = 1; int iDivisor = 10;
            while(iMax/ factor != 0)
            {
                CountSortByInterval(num, _iFirstIdx, _iLastIdx, factor, iDivisor, isAscending);
                factor *= iDivisor;
            }
        }

        public void CountSortByInterval(int[] num, int _iFirstIdx, int _iLastIdx,int _factor, int _iDivisor, bool isAscending = true)
        {
            int iFeqSize = _iDivisor;
            int[] iFeq = new int[iFeqSize];
            int iSortSize = _iLastIdx - _iFirstIdx + 1;
            int[] iSort = new int[iSortSize];

            for (int i = _iFirstIdx; i <= _iLastIdx; i++)
                iFeq[GetSingleAbsDigit(num[i], _factor, _iDivisor)]++;

            //壘加平率
            if (isAscending)
                for (int i = 1; i < iFeqSize; i++)
                    iFeq[i] += iFeq[i - 1];
            else
                for (int i = iFeqSize - 2; i >= 0; i--)
                    iFeq[i] += iFeq[i + 1];

            #region - 重點說明 -
            /*
               上面累加 與 "下面num[i]找對應iFeq頻率" 要相反(因為會有進位問題)
               在下一輪位數的時候：上一輪位數是已升序排序好，因為累加是出現次數紀錄位置遞增(也就是排回去iSort會從後面排回來的位置)
               結論：上面算法跟下面算法要相反
            */
            //從前面送值
            //for (int i = 0; i < iSortSize; i++)
            //     iSort[iFeq[GetSingleAbsDigit(num[i + _iFirstIdx], _factor, _iDivisor)]-- -1] = num[_iFirstIdx + i];
            #endregion

            //從後面送值
            for (int i = iSortSize - 1; i >= 0; i--)
                iSort[iFeq[GetSingleAbsDigit(num[i + _iFirstIdx], _factor, _iDivisor)]-- - 1] = num[_iFirstIdx + i];


            for (int i = 0; i < iSortSize ; i++)
                num[i + _iFirstIdx] = iSort[i];
        }

        private int GetSingleAbsDigit(int _num, int _factor, int _iDivisor)
        {
            return Math.Abs(_num / _factor) % _iDivisor;
        }


        #endregion

        #region - HeapSort -
        /// <summary>
        /// Heap Sort (Accepted) [T(n) = O(n * lgn)] ，(beast 50.13%)(跟MergeSort差不多)
        /// Step 1. BUILD-MAX-HEAP()：維持「max-heap」結構，從第 Math.floor((arr.length/2)) 項開始一路到第 0 項都要跑過一次，時間複雜度為 O(n/2)=O(n)。
        /// Step 2. MAX-HEAPIFY()：建立「max-heap」過程，對於任一個值而言，在根與葉之間移動，最多移動(log₂ n) 層，也就是移動(log₂ n) 次，時間複雜度為 O(log₂ n)=O(log n)。
        /// Step 3. HEAP-SORT()：從最後一項到第一項每筆資料都會一一被切到陣列中，時間複雜度為 O(n)。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="_goodmodel"></param>
        /// <returns></returns>
        public int[] HeapSort(int[] nums, string _Model = "MaxHeap")
        {
            HeapSortFlow(nums, _Model);
            return nums;
        }

        private void HeapSortFlow(int[] nums, string _Model = "MaxHeap")
        {
            if (nums.Length <= 1) return;
            /// Step 1 建立最大的樹堆
            FirstHeap(nums, _Model);
            /// Step 3
            for (int iHeapTreeSize = nums.Length-1;iHeapTreeSize > 0 ;iHeapTreeSize--)  //>0：num[0]就不用堆因為他已是第一個
            {
                swap_OP(ref nums[iHeapTreeSize],ref nums[0]); //nums[0]：每次新樹的最大根部
                Build_MAX_OR_MIN_HEAP(nums, iHeapTreeSize, 0 ,_Model);
            }
        }

        /// <summary>
        /// 每個局部樹堆的根部先把他弄成最大的(為了要讓nums[0](最上根部) = 數組的最大值)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="_Model"></param>

        private void FirstHeap(int[] nums,  string _Model = "MaxHeap")
        {
            int iHeapTreeSize = nums.Length;
            int tailRootIdx = (nums.Length >> 1) - 1;
            for (int i = tailRootIdx; i >= 0; i--)
                Build_MAX_OR_MIN_HEAP(nums, iHeapTreeSize, i, _Model);
        }

        public void Build_MAX_OR_MIN_HEAP(int[] nums, int _HeapSize,int _iTailRootIdx, string _Model = "MaxHeap")
        {
            // Step 2 
            if (_HeapSize <= 1 || _iTailRootIdx < 0 || _iTailRootIdx >= _HeapSize) return;
            int iNewRoot = _iTailRootIdx; int iLeftKidIdx = 2 * _iTailRootIdx + 1; int iRightKidIdx = 2 * _iTailRootIdx + 2;
            if(iLeftKidIdx < _HeapSize && (_Model == "MaxHeap" ? nums[iLeftKidIdx] > nums[iNewRoot] : nums[iLeftKidIdx] < nums[iNewRoot]))
                iNewRoot = iLeftKidIdx;
            if (iRightKidIdx < _HeapSize && (_Model == "MaxHeap" ? nums[iRightKidIdx] > nums[iNewRoot] : nums[iRightKidIdx] < nums[iNewRoot]))
                iNewRoot = iRightKidIdx;

            //swap_OP(ref nums[iNewRoot], ref nums[_iTailRootIdx]);等等試試看這裡拔出來!

            //這裡通常會進一次因為要交換
            if (nums[iNewRoot] != nums[_iTailRootIdx])
            {
                swap_OP(ref nums[iNewRoot], ref nums[_iTailRootIdx]);
                Build_MAX_OR_MIN_HEAP(nums, _HeapSize, iNewRoot, _Model);
            }

        }
        #endregion
        #region - 舉例說明 -
        /*
              10
             /  \
            5    3
           / \  / \
          4  1  2  6

              || (取出最上面根部到底部最右邊(nums[nums.Length - 1]))
               v

               6
             /  \
            5    3
           / \  / \
          4  1 2  10
        */
        #endregion


        /// <summary>
        /// 這個需要配合其他演算法(因為他只是按比例分桶，桶內還是要排序) => O(n log n)，Lostest will become O(n ^ 2)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="_goodmodel"></param>
        /// <returns></returns>
        public int[] BucketSort(int[] nums, string _goodmodel = "Normal")
        {
            int iMax = nums.Max();
            int iMin = nums.Min();
            int range = iMax - iMin + 1;//為了不讓除數為0，ex:nums[2,2] or nums[0]會出問題!
            List<List<int>> Bucket = new List<List<int>>(); 

            for(int i = 0;i <nums.Length ;i++)
            {
                Bucket.Add(new List<int>());
            }

            for(int i = 0;i < nums.Length ;i++)
            {
                int iBucketSelect = (nums[i] - iMin) / range * (nums.Length - 1);//用比例來選擇第幾桶
                Bucket[iBucketSelect].Add(nums[i]);
            }

            for (int i = 0; i < Bucket.Count; i++)
            {
                Bucket[i].Sort();
            }

            int ans_index = 0;  //nums從0開始丟回來值
            for(int i = 0; i < Bucket.Count; i++)
            {
                int j = 0;
                while(j < Bucket[i].Count)
                {
                    nums[ans_index] = Bucket[i][j];
                    j++; ans_index++;
                }
            }

            return nums;
        }

        /// <summary>
        /// 1122
        /// Given two arrays arr1 and arr2, the elements of arr2 are distinct, and all elements in arr2 are also in arr1.
        /// Sort the elements of arr1 such that the relative ordering of items in arr1 are the same as in arr2.Elements that do not appear in arr2 should be placed at the end of arr1 in ascending order.
        /// </summary>
        public class SolutionSort
        {
            #region - LeetCode 1122 -

            public int[] RelativeSortArray(int[] arr1, int[] arr2)
            {
                Dictionary<int, int> Map_arr2 = new Dictionary<int, int>();
                Dictionary<int,int> BothExit = new Dictionary<int,int>();
                List<int> Bothdifferent = new List<int>();

                for(int i = 0; i <arr2.Length;i++)
                {
                    Map_arr2[arr2[i]] = 0;
                }

                for(int i = 0;i < arr1.Length; i++)
                    if (Map_arr2.ContainsKey(arr1[i]))
                        Map_arr2[arr1[i]]++;
                    else Bothdifferent.Add(arr1[i]);


                List<int> Sort = new List<int>(); 
                List<int> keysList = Map_arr2.Keys.ToList();
                for(int i = 0; i < keysList.Count; i++)
                {
                    while (1 < Map_arr2[keysList[i]])
                    {
                        Sort.Add(keysList[i]);
                        Map_arr2[keysList[i]]--;
                    }

                    Sort.Add(keysList[i]);
                }

                Sort.AddRange(CountSort1122(Bothdifferent));
                int iAnsSize = Sort.Count;
                int[] Ans = new int[iAnsSize]; 

                for (int i = 0 ;i < iAnsSize; i++)
                    Ans[i] = Sort[i];

                return Ans;
            }

            private int[] CountSort1122(List<int> _Bothdifferent)
            {

                int iMax = 0;
                int iMin = int.MaxValue;
                List<int> Sort = new List<int>();
                for (int i = 0; i < _Bothdifferent.Count; i++)
                    if (_Bothdifferent[i] > iMax) iMax = _Bothdifferent[i];
                for (int i = 0; i < _Bothdifferent.Count; i++)
                    if (_Bothdifferent[i] < iMin) iMin = _Bothdifferent[i];

                if (iMax <= iMin)
                {
                    int[] itemp = new int[_Bothdifferent.Count];
                    for (int i = 0; i < _Bothdifferent.Count; i++)
                        itemp[i] = _Bothdifferent[i];

                    return itemp;
                }

                int range = iMax - iMin + 1;
                int[] mapping = new int[range];
                int iSortSize = _Bothdifferent.Count;
                int[] iSort = new int[iSortSize];

                for (int i = 0; i < _Bothdifferent.Count; i++)
                    mapping[_Bothdifferent[i] - iMin]++;

                for (int i = 1; i < mapping.Length; i++)
                    mapping[i] += mapping[i - 1];

                for (int i = iSortSize - 1; i >= 0; i--)
                    iSort[mapping[_Bothdifferent[i] - iMin]-- - 1] = _Bothdifferent[i];

                return iSort;
            }
            #endregion

            #region - LeetCode 581 -
            public int FindUnsortedSubarray(int[] nums)
            {
                #region - 解圖思路 -
                /*由於升序：
                  最大值：找到最高值記錄起來，把最高值的所有右邊值與他比較，看右邊有多少個元素(代表右邊需要排序的最大index是多少)
                  最小值：找到最低值記錄起來，把最低值的所有左邊值與他比較，看左邊有多少個元素(代左右邊需要排序的最小index是多少)
                */
                #endregion
                int iMax = nums[0]; int iMin = nums[nums.Length - 1];
                int iPointer = 0; int iLeft = -1; int iRight = nums.Length - 1;
                while (iPointer < nums.Length)
                {
                    //找右邊最大index
                    if (nums[iPointer] >= iMax)
                        iMax = nums[iPointer];
                    else
                        iLeft = iPointer;

                    //找左邊最小index
                    int iRightToLeftIndex = nums.Length - 1 - iPointer;
                    if (nums[iRightToLeftIndex] <= iMin)
                        iMin = nums[iRightToLeftIndex];
                    else
                        iRight = iRightToLeftIndex;

                    iPointer++;
                }
                return iLeft - iRight + 1 > 0? iLeft - iRight + 1:0; 
                //return iLeft == -1 ? 0 : iLeft - iRight + 1;

                #region - 另一種直接排序一次，然後比較原矩陣左邊跟右邊最一開始不一樣的值 -
                //說明：這種方式就算排序是O(n)，但是下面情況最壞就是再跑兩次n，所以總共：3n!
                //if (nums.Length <= 1) return 0;
                //int[] iSort = new int[nums.Length];
                //Array.Copy(nums, 0, iSort, 0, nums.Length);
                //Array.Sort(iSort);

                //int iLeft = 0; int iRight = nums.Length - 1;

                //while (/*iRight >= 0*/nums[iLeft] == iSort[iLeft])
                //{
                //    if (iLeft == nums.Length - 1) break;
                //    iLeft++;
                //}

                //while (/*iRight >= 0*/nums[iRight] == iSort[iRight])
                //{
                //    if (iRight == 0)  break;
                //    iRight--;
                //}

                //return iRight - iLeft + 1 > 0 ? iRight - iLeft + 1  : 0;
                #endregion
            }
            #endregion

            #region - LeetCode 2191 -
            /// <summary>
            /// 這題要用Stable Sort
            /// </summary>
            /// <param name="mapping"></param>
            /// <param name="nums"></param>
            /// <returns></returns>
            public int[] SortJumbled(int[] mapping, int[] nums)
            {
                int[] iSort = new int[nums.Length];
                Dictionary<int, int> MapReturnToSrcIdx = new Dictionary<int, int>();

                //先重整新的數組
                for (int i = 0; i < nums.Length; i++)
                {
                    int iDivior = 1;
                    while (nums[i] / iDivior != 0)
                    {
                        int iRemainder = nums[i] % iDivior;
                        iSort[i] += mapping[iRemainder] * iDivior;
                        iDivior *= 10;
                    }

                    if (!MapReturnToSrcIdx.ContainsKey(iSort[i]))
                        MapReturnToSrcIdx[iSort[i]] = nums[i];
                }

                Array.Sort(iSort);

                for (int i = 0; i < nums.Length; i++)
                    iSort[i] = MapReturnToSrcIdx[iSort[i]];

                return iSort;
            }
            #endregion

        }


        #endregion
    }
}
