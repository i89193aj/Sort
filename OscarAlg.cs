using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace OscarAlg
{
    public partial class OscarAlg : Form
    {

        Sort SortAlg;
        Sort.SolutionSort SolutionSort;
        int[] iInputnum;
        int[] iRandomCopy;
        int m_RadioButtom_Tag = 0;
        bool m_bShowOnly = false;
        int iLeetCodeNum = 0;
        Alg.SortMethod method = Alg.SortMethod.Insert;
        Random random = new Random();
        public Stopwatch AlgSendTime = new Stopwatch();    //算法花費時間
        public OscarAlg()
        {
            InitializeComponent();
            SortAlg = new Sort();
            SolutionSort = new Sort.SolutionSort();

            cbGoodORWorse.SelectedIndex = 0;
        }

        private void OscarAlg_Load(object sender, EventArgs e)
        {
            //foreach(Control _control in gbSortMethod.Controls)
            //{
            //    if (_control.Name == "gbSort"
            //        || _control.Name == "cbGoodORWorse"
            //        || _control.Name == "btnSubmit")
            //        continue;
            //    _control.Enabled = false;
            //}
        }


        private void btnMakeArray_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInput.Text, out int _arraynums))
            {
                MessageBox.Show("請輸入數字");
                return;
            }

            iInputnum = new int[txtInput.Text.Length];
            txtOutput.Text = "[";
            for (int i = 0; i < txtInput.Text.Length; i++)
            {
                iInputnum[i] = _arraynums % 10;
                _arraynums /= 10;
                if (i != txtInput.Text.Length - 1)
                    txtOutput.Text += txtInput.Text[i] + ", ";
                else
                    txtOutput.Text += txtInput.Text[i];
            }
            txtOutput.Text += "]";

            gbSortMethod.Enabled = true;
        }

        private unsafe void btnMySort_Click(object sender, EventArgs e)
        {
            if (iInputnum == null)
            {
                MessageBox.Show("請先輸入數字");
                return;
            }
            String[] Ans_Address = new string[2];
            String[] temp_Address = new string[2];
            String[] iInputnum_Address = new string[2];

            int[] temp = iInputnum;
            int[] ans = iInputnum;
            //Alg.SortMethod method = Alg.SortMethod.Insert;
            Button button = (Button)sender;
            button.Enabled = false;
            string sModelFactor = cbGoodORWorse.Text;

            if (ans != null)
            {
                Ans_Address = Sort.FindAddress(ans);
                //Console.WriteLine(method.ToString() + "Ans_Address(Before)：Address_FirstIndex = " + Sort.FindAddress(ans)[0] + "，Address_ArrayPointer = " + Sort.FindAddress(ans)[1]);
                MessageBoxRich(method.ToString() + "Ans_Address(Before)：Address_FirstIndex = " + Ans_Address[0] + "，Address_ArrayPointer = " + Ans_Address[1]);
            }

            #region - 這兩個先不用 -
            //if (temp != null)
            //{
            //    temp_Address = Sort.FindAddress(temp);
            //    Console.WriteLine(method.ToString() + "temp_Address(Before)：Address_FirstIndex = " + Sort.FindAddress(temp)[0] + "，Address_ArrayPointer = " + Sort.FindAddress(temp)[1]);
            //    MessageBoxRich(method.ToString() + "Ans_Address(Before)：Address_FirstIndex = " + temp_Address[0] + "，Address_ArrayPointer = " + temp_Address[1]);
            //}

            //if (iInputnum != null)
            //{
            //    iInputnum_Address = Sort.FindAddress(iInputnum);
            //    Console.WriteLine(method.ToString() + "iInputnum_Address(Before)：Address_FirstIndex = " + Sort.FindAddress(iInputnum)[0] + "，Address_ArrayPointer = " + Sort.FindAddress(iInputnum)[1]);
            //    MessageBoxRich(method.ToString() + "Ans_Address(Before)：Address_FirstIndex = " + iInputnum_Address[0] + "，Address_ArrayPointer = " + iInputnum_Address[1]);
            //}
            #endregion


            AlgSendTime.Restart();
            switch (method)
            {
                case Alg.SortMethod.Insert:
                    ans = SortAlg.InsertSort(temp, sModelFactor);
                    break;
                case Alg.SortMethod.Select:
                    ans = SortAlg.SelectSort(temp, sModelFactor);
                    break;
                case Alg.SortMethod.Bubble:
                    ans = SortAlg.BubbleSort(temp, sModelFactor);
                    break;
                case Alg.SortMethod.Merge:
                    ans = SortAlg.MergeSort(temp, sModelFactor);
                    break;
                case Alg.SortMethod.Quickly:
                    ans = SortAlg.QuickSort(temp, sModelFactor);
                    break;
                case Alg.SortMethod.C_Sharp_Lib:
                    ans = SortAlg.CSharpSort(temp, sModelFactor);
                    break;
                case Alg.SortMethod.Counting:
                    ans = SortAlg.CountSort(temp, sModelFactor);
                    break;
                case Alg.SortMethod.Radix:
                    ans = SortAlg.RadixSort(temp, sModelFactor);
                    break;
                case Alg.SortMethod.Buket:
                    ans = SortAlg.BucketSort(temp, sModelFactor);
                    break;
                case Alg.SortMethod.Heap:
                    ans = SortAlg.HeapSort(temp, sModelFactor);
                    break;
                default: break;
            }
            AlgSendTime.Stop();

            if (ans != null)
            {
                Ans_Address = Sort.FindAddress(ans);
                //Console.WriteLine(method.ToString() + "Ans_Address(After)：Address_FirstIndex = " + Sort.FindAddress(ans)[0] + "，Address_ArrayPointer = " + Sort.FindAddress(ans)[1]);
                MessageBoxRich(method.ToString() + "Ans_Address(After)：Address_FirstIndex = " + Ans_Address[0] + "，Address_ArrayPointer = " + Ans_Address[1]);
            }

            #region - 這兩個先不用 -
            //if (temp != null)
            //{
            //    temp_Address = Sort.FindAddress(temp);
            //    Console.WriteLine(method.ToString() + "temp_Address(After)：Address_FirstIndex = " + Sort.FindAddress(temp)[0] + "，Address_ArrayPointer = " + Sort.FindAddress(temp)[1]);
            //    MessageBoxRich(method.ToString() + "Ans_Address(After)：Address_FirstIndex = " + temp_Address[0] + "，Address_ArrayPointer = " + temp_Address[1]);
            //}

            //if (iInputnum != null)
            //{
            //    iInputnum_Address = Sort.FindAddress(iInputnum);
            //    Console.WriteLine(method.ToString() + "iInputnum_Address(After)：Address_FirstIndex = " + Sort.FindAddress(iInputnum)[0] + "，Address_ArrayPointer = " + Sort.FindAddress(iInputnum)[1]);
            //    MessageBoxRich(method.ToString() + "Ans_Address(After)：Address_FirstIndex = " + iInputnum_Address[0] + "，Address_ArrayPointer = " + iInputnum_Address[1]);
            //}
            #endregion

            if (ans == null)
            {
                MessageBox.Show("Array is null");
                button.Enabled = true;
                return;
            }

            //手動的才給答案
            if (temp.Length <= 10)
            {
                txtAns.Text = "[";
                for (int i = 0; i < ans.Length; i++)
                {
                    if (i != ans.Length - 1)
                        txtAns.Text += ans[i].ToString() + ", ";
                    else
                        txtAns.Text += ans[i].ToString();
                }
                txtAns.Text += "]";
            }
            //因為這裡不可能像LeeCode那樣去自動代入那麼多參數測，所以用微秒看
            int iChangeunit = 1000;
            txtSendTime.Text = (AlgSendTime.Elapsed.TotalMilliseconds * iChangeunit).ToString("0.000");
            button.Enabled = true;
        }




        private void btnCleanArray_Click(object sender, EventArgs e)
        {
            if (iInputnum == null)
                return;
            else
                iInputnum = null;

            //Array.Clear(iInputnum, 0, iInputnum.Length);
            txtInput.Text = "";
            txtOutput.Text = "";
        }

        private void btnRadom_Click(object sender, EventArgs e)
        {
            btnRadom.Enabled = false;
            if (!int.TryParse(txtRandomCount.Text, out int count))
            {
                MessageBox.Show("請輸入要隨機給予的最大數字");
            }
            else if (count > 10000)
            {
                MessageBox.Show("不得設大於10000(1w)");
            }
            else if (count <= 0)
            {
                MessageBox.Show("不得小於or等於 0");
            }

            iInputnum = new int[count];
            // 用隨機數填充陣列
            for (int i = 0; i < iInputnum.Length; i++)
            {
                iInputnum[i] = random.Next(1, 1000001);  // 隨機數範圍從 1 到 1000001
            }

            // 深拷貝
            iRandomCopy = new int[iInputnum.Length];
            for (int i = 0; i < iInputnum.Length; i++)
            {
                iRandomCopy[i] = iInputnum[i];
            }
            //Array.Copy(iInputnum,0, iRandomCopy,0, iRandomCopy.Length);


            btnRadom.Enabled = true;
            btnDeepCopy.Enabled = true;
            gbSortMethod.Enabled = true;
        }

        private void btnDeepCopy_Click(object sender, EventArgs e)
        {
            //這裡是深拷貝(因為int是值類型)
            iInputnum = null;
            iInputnum = new int[iRandomCopy.Length];
            Array.Copy(iRandomCopy, 0, iInputnum, 0, iInputnum.Length);
        }

        private void btnMakeNegative_Value_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "[";

            String[] snegativeValue = txtInput.Text.Split(',');
            iInputnum = new int[snegativeValue.Length];

            for (int i = 0; i < snegativeValue.Length; i++)
            {
                if (!int.TryParse(snegativeValue[i], out int _arraynums))
                {
                    MessageBox.Show("請輸入數字");
                    return;
                }
                else
                {
                    iInputnum[i] = _arraynums;
                    if (i != snegativeValue.Length - 1)
                        txtOutput.Text += snegativeValue[i] + ", ";
                    else
                        txtOutput.Text += snegativeValue[i];
                }
            }

            txtOutput.Text += "]";
            gbSortMethod.Enabled = true;
        }

        private void rdbSort_Clicked(object sender, EventArgs e)
        {
            RadioButton rbSort = (RadioButton)sender;
            m_RadioButtom_Tag = Convert.ToInt32(rbSort.Tag);//這個不能直接轉 => X：(int)rbSort.Tag

            // 清空 ComboBox 中的所有项
            cbGoodORWorse.Items.Clear();

            switch (rbSort.Name)
            {
                case "rdbInsetSort":
                    method = Alg.SortMethod.Insert;

                    foreach (Sort.InsertSortMethod method in Enum.GetValues(typeof(Sort.InsertSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rabBubbleSort":
                    method = Alg.SortMethod.Bubble;
                    foreach (Sort.BubbleSortMethod method in Enum.GetValues(typeof(Sort.BubbleSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbSelectSort":
                    method = Alg.SortMethod.Select;
                    foreach (Sort.SelectSortMethod method in Enum.GetValues(typeof(Sort.SelectSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbCSharpSort":
                    method = Alg.SortMethod.C_Sharp_Lib;
                    foreach (Sort.CSharpSortMethod method in Enum.GetValues(typeof(Sort.CSharpSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbMergeSort":
                    method = Alg.SortMethod.Merge;
                    foreach (Sort.MergeSortMethod method in Enum.GetValues(typeof(Sort.MergeSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbQuickSort":
                    method = Alg.SortMethod.Quickly;
                    foreach (Sort.QuickSortMethod method in Enum.GetValues(typeof(Sort.QuickSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbRadixSort":
                    method = Alg.SortMethod.Radix;
                    foreach (Sort.RadixSortMethod method in Enum.GetValues(typeof(Sort.RadixSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbCountingSort":
                    method = Alg.SortMethod.Counting;
                    foreach (Sort.CoutingSortMethod method in Enum.GetValues(typeof(Sort.CoutingSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbBuketSort":
                    method = Alg.SortMethod.Buket;
                    foreach (Sort.BuketSortMethod method in Enum.GetValues(typeof(Sort.BuketSortMethod)))
                        cbGoodORWorse.Items.Add(method);
                    break;
                case "rdbHeapSort":
                    method = Alg.SortMethod.Heap;
                    foreach (Sort.HeapSortMethod method in Enum.GetValues(typeof(Sort.HeapSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
            }

            cbGoodORWorse.SelectedIndex = 0;
        }

        public void MessageBoxRich(string _str)
        {
            if (!_str.EndsWith("\n"))
            {
                _str += "\n";
            }

            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    Rtxt_Sort.AppendText(_str);
                }));
            else
                Rtxt_Sort.AppendText(_str);
        }
        ///
        public void RtxtExaminationMessage(string _str, int iFront = 12)
        {
            string[] sSplit = Regex.Split(_str, "([.])");
            string result = "\r\n";
            _str = "";

            #region - 字串格式 (有興趣自己看) -
            /* 定義匹配模式 
             * \s ： 空格 or Tab
             * \d ： 0~9數字 (-?\d+：表示"負號")
             * \w ： 混和字(數字 + a~z + '_')
             * '+'和 '*'：表示「匹配前面的元素一次或多次)
             * ( )：標記所要記錄的元素
             * Ex：\s* => 多個空格; \d+ => 78543
             * Ex：_PPCID = 90 ,缺陷總數 = 0, 檢測結果： OK                
             * string str_Pattern = @"_PPCID\s*=\s*(\d+)\s*,\s*缺陷總數\s*=\s*(\d+)\s*,\s*檢測結果：\s*(\w+)";
             * 
             * 其他表達式：
             * a-z：小写字母
             * A-Z：大写字母
             * 0-9：数字
             * _：下划线
             * \-：连字符（-）
             * \.：点号（.），需要转义
             * +：表示匹配一个或多个上述字符。
             * Ex：string _Pattern = @"料號：([a-zA-Z0-9_\-\.]+)";
             */
            #endregion
            for (int i = 0; i < sSplit.Length; i++)
            {
                sSplit[i] = sSplit[i].Trim(); //去除前後空格
                if (/*sSplit[i] != "," &&*/ sSplit[i] != "." && i + 1 < sSplit.Length)
                    sSplit[i] += sSplit[i + 1] + "\r\n";

                // 1. 確保 "Example X:" 前後只有一次換行
                sSplit[i] = Regex.Replace(sSplit[i], @"(\r\n)+Example (\d+):", match =>
                {
                    // match.Groups[2] 是捕獲到的數字部分
                    return $"\r\nExample {match.Groups[2]}:";
                });
                // 2. 在每個 "Example:" 後面加上 "\r\n"，如果後面沒有的話
                sSplit[i] = Regex.Replace(sSplit[i], @"Example \d+:(\r\n)+", match =>
                {
                    // match.Groups[2] 是捕獲到的數字部分
                    return $"\r\nExample {match.Groups[2]}:";
                });

                // 3. 移除多餘的換行符號（將多個換行符號替換為一個）
                sSplit[i] = Regex.Replace(sSplit[i], @"(\r\n)+", "\r\n");
            }

            _str = "";
            for (int i = 0; i < sSplit.Length; i++)
            {
                if (/*sSplit[i] != "," &&*/ sSplit[i] != ".")
                    _str += sSplit[i];
            }

            if (!_str.EndsWith("\n"))
            {
                _str += "\n";
            }

            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    Font currentFont = RtxtExamination.SelectionFont;
                    RtxtExamination.SelectionFont = new Font(currentFont.FontFamily, iFront);
                    RtxtExamination.AppendText(_str);
                }));
            else
            {
                Font currentFont = RtxtExamination.SelectionFont;
                RtxtExamination.SelectionFont = new Font(currentFont.FontFamily, iFront);
                RtxtExamination.AppendText(_str);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Enabled = false;
            string sModelFactor = cbGoodORWorse.Text;
            MessageBoxRich(method.ToString() + " StartCase");

            #region - 跑Case -  
            int[] Case;
            Queue<int[]> iRunCase = new Queue<int[]>();

            Case = new int[1] { 0 };
            iRunCase.Enqueue(Case);

            Case = new int[2] { 2, 2 };
            iRunCase.Enqueue(Case);

            Case = new int[6] { 0, 0, 2, 1, 1, 5 };
            iRunCase.Enqueue(Case);

            Case = new int[3] { -2, 3, -5 };
            iRunCase.Enqueue(Case);

            Case = new int[4] { -1, 2, -8, -10 };
            iRunCase.Enqueue(Case);

            Case = new int[10] { -7, -5, 4, 0, -4, -1, 0, -1, 7, 9 };
            iRunCase.Enqueue(Case);
            #endregion

            int iRunCase_Count = iRunCase.Count;
            for (int i = 0; i < iRunCase_Count; i++)
            {
                int[] iSrc = iRunCase.Dequeue();
                int[] ans = new int[iSrc.Length];
                Array.Copy(iSrc, 0, ans, 0, ans.Length);

                switch (method)
                {
                    case Alg.SortMethod.Insert:
                        ans = SortAlg.InsertSort(ans, sModelFactor);
                        break;
                    case Alg.SortMethod.Select:
                        ans = SortAlg.SelectSort(ans, sModelFactor);
                        break;
                    case Alg.SortMethod.Bubble:
                        ans = SortAlg.BubbleSort(ans, sModelFactor);
                        break;
                    case Alg.SortMethod.Merge:
                        ans = SortAlg.MergeSort(ans, sModelFactor);
                        break;
                    case Alg.SortMethod.Quickly:
                        ans = SortAlg.QuickSort(ans, sModelFactor);
                        break;
                    case Alg.SortMethod.C_Sharp_Lib:
                        ans = SortAlg.CSharpSort(ans, sModelFactor);
                        break;
                    case Alg.SortMethod.Counting:
                        ans = SortAlg.CountSort(ans, sModelFactor);
                        break;
                    case Alg.SortMethod.Radix:
                        ans = SortAlg.RadixSort(ans, sModelFactor);
                        break;
                    case Alg.SortMethod.Buket:
                        ans = SortAlg.BucketSort(ans, sModelFactor);
                        break;
                    case Alg.SortMethod.Heap:
                        ans = SortAlg.HeapSort(ans, sModelFactor);
                        break;
                    default: break;
                }
                string sSrc = "{" + string.Join(", ", ans) + "}";
                string sResult = "{" + string.Join(", ", ans) + "}";
                MessageBoxRich("Input：" + sSrc + "，Output：" + sResult);
            }

            button.Enabled = true;
        }

        private void btnContest_Click(object sender, EventArgs e)
        {
            if (!m_bShowOnly)
            {
                MessageBox.Show("Please Show the Examination, first!");
                return;
            }

            if (iLeetCodeNum.ToString() != txtLeetCodeNum.Text)
            {
                MessageBox.Show("Please Change the Show the current Examination, first!");
                return;
            }
            //int[] arr1 = { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 };
            //int[] arr2 = new int[] { 2, 1, 4, 3, 9, 6 };
            string input1 = txtInput1.Text.Trim();
            string input2 = txtInput2.Text.Trim();

            string[] sElements1 = input1.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] sElements2 = input2.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            int[] iExamArry1 = new int[sElements1.Length];
            int[] iExamArry2 = new int[sElements2.Length];
            int[] iAnsArray = iExamArry1; int iAns = 0;


            // 解析每個數字並存入一維陣列
            for (int i = 0; i < sElements1.Length; i++)
            {
                if (int.TryParse(sElements1[i], out int value)) // 處理數字（零、正負數）
                    iExamArry1[i] = value;
                else
                {
                    MessageBox.Show("無效的數字格式：" + sElements1[i]);
                    return;
                }
            }

            for (int i = 0; i < sElements2.Length; i++)
            {
                if (int.TryParse(sElements2[i], out int value)) // 處理數字（零、正負數）
                    iExamArry2[i] = value;
                else
                {
                    MessageBox.Show("無效的數字格式：" + sElements2[i]);
                    return;
                }
            }

            string sSrc = ""; string sResult = null;
            Invoke(new Action(() => {Rtxt_Sort.Clear(); }));

            if (int.TryParse(txtLeetCodeNum.Text,out iLeetCodeNum))
            {
                switch(iLeetCodeNum)
                {
                    case 1122:
                        //  解題：
                        iAnsArray = SolutionSort.RelativeSortArray(iExamArry1, iExamArry2);
                        //  測試答案：
                        sSrc = "{" + string.Join(", ", iExamArry1) + "}" + "，{" + string.Join(", ", iExamArry2) + "}";
                        sResult = "{" + string.Join(", ", iAnsArray) + "}";
                        MessageBoxRich("Input：" + sSrc + "，Output：" + sResult);
                        break;
                    case 581:

                        //  解題：
                        iAns = SolutionSort.FindUnsortedSubarray(iExamArry1);
                        //  測試答案：
                        sSrc = "{" + string.Join(", ", iExamArry1) + "}";
                        sResult = "{" + string.Join(", ", iAns) + "}";
                        MessageBoxRich("Input：" + sSrc + "，Output：" + sResult);
                        break;
                    

                }
            }
            else
            {
                MessageBox.Show("請輸入號碼!");
            }
        }

        private void btnOnlyShowExamination_Click(object sender, EventArgs e)
        {
            string sExamination = null; string sTitle = null;
            m_bShowOnly = true;
            Invoke(new Action(() => { RtxtExamination.Clear();}));

            if (int.TryParse(txtLeetCodeNum.Text, out iLeetCodeNum))
            {
                switch (iLeetCodeNum)
                {
                    case 1122:
                        //  題型敘述：
                        sTitle = iLeetCodeNum.ToString() + ". Relative Sort Array：";
                        RtxtExaminationMessage(sTitle, 16);
                        sExamination = "Given two arrays arr1 and arr2, the elements of arr2 are distinct, and all elements in arr2 are also in arr1." +
                                       "Sort the elements of arr1 such that the relative ordering of items in arr1 are the same as in arr2. " +
                                       "Elements that do not appear in arr2 should be placed at the end of arr1 in ascending order." +
                                       "Example 1:\r\n\r\nInput: arr1 = [2,3,1,3,2,4,6,7,9,2,19], arr2 = [2,1,4,3,9,6]\r\nOutput: [2,2,2,1,4,3,3,9,6,7,19]\r\nExample 2:\r\n\r\nInput: arr1 = [28,6,22,8,44,17], arr2 = [22,28,8,6]\r\nOutput: [22,28,8,6,17,44]\r\n \r\n\r\nConstraints:\r\n\r\n1 <= arr1.length, arr2.length <= 1000\r\n0 <= arr1[i], arr2[i] <= 1000\r\nAll the elements of arr2 are distinct.\r\nEach arr2[i] is in arr1.";
                        RtxtExaminationMessage(sExamination);

                        break;
                    case 581:
                        //  題型敘述：
                        sTitle = iLeetCodeNum.ToString() + ". Shortest Unsorted Continuous Subarray：";
                        RtxtExaminationMessage(sTitle, 16);
                        sExamination = "Given an integer array nums, you need to find one continuous subarray such that if you only sort this subarray in non-decreasing order, " +
                                       "then the whole array will be sorted in non-decreasing order." +
                                       "Return the shortest such subarray and output its length." +
                                       "Example 1:\r\n\r\nInput: nums = [2,6,4,8,10,9,15]\r\nOutput: 5\r\nExplanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make the whole array sorted in ascending order.\r\nExample 2:\r\n\r\nInput: nums = [1,2,3,4]\r\nOutput: 0\r\nExample 3:\r\n\r\nInput: nums = [1]\r\nOutput: 0\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 104\r\n-105 <= nums[i] <= 105\r\n \r\n\r\nFollow up: Can you solve it in O(n) time complexity?";
                        RtxtExaminationMessage(sExamination);

                        break;
                    default:
                        MessageBox.Show("The question of No."+ iLeetCodeNum.ToString() + " is still pending.");
                        break;


                }
            }
            else
            {
                MessageBox.Show("請輸入號碼!");
            }
        }
    }
}
