using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscarAlg
{
    internal class Alg
    {
        internal enum SortMethod
        {
            Insert,
            Selecting,
            bubble,
            Merge,
            Quickly
        }
    }

    internal class Sort: Alg
    {

        /// <summary>
        /// Insert排序法
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
                                nums[index2 + 1] = nums[index2] ^ nums[index2 + 1];  // 第二步：b = (a ^ b) ^ b = a
                                nums[index2] = nums[index2] ^ nums[index2 + 1];      // 第三步：a = (a ^ b) ^ a = b
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
    }
}
