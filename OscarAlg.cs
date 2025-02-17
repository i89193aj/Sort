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
using System.Runtime.InteropServices;
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
        Alg.SortMethod m_method = Alg.SortMethod.Insert;
        Alg.LevelOfExam m_LevelOfExam = Alg.LevelOfExam.Easy;
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
                Ans_Address = global::OscarAlg.Sort.FindAddress(ans);
                //Console.WriteLine(method.ToString() + "Ans_Address(Before)：Address_FirstIndex = " + Sort.FindAddress(ans)[0] + "，Address_ArrayPointer = " + Sort.FindAddress(ans)[1]);
                MessageBoxRich(m_method.ToString() + "Ans_Address(Before)：Address_FirstIndex = " + Ans_Address[0] + "，Address_ArrayPointer = " + Ans_Address[1]);
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
            switch (m_method)
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
                Ans_Address = global::OscarAlg.Sort.FindAddress(ans);
                //Console.WriteLine(method.ToString() + "Ans_Address(After)：Address_FirstIndex = " + Sort.FindAddress(ans)[0] + "，Address_ArrayPointer = " + Sort.FindAddress(ans)[1]);
                MessageBoxRich(m_method.ToString() + "Ans_Address(After)：Address_FirstIndex = " + Ans_Address[0] + "，Address_ArrayPointer = " + Ans_Address[1]);
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
                    m_method = Alg.SortMethod.Insert;

                    foreach (Sort.InsertSortMethod method in Enum.GetValues(typeof(Sort.InsertSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rabBubbleSort":
                    m_method = Alg.SortMethod.Bubble;
                    foreach (Sort.BubbleSortMethod method in Enum.GetValues(typeof(Sort.BubbleSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbSelectSort":
                    m_method = Alg.SortMethod.Select;
                    foreach (Sort.SelectSortMethod method in Enum.GetValues(typeof(Sort.SelectSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbCSharpSort":
                    m_method = Alg.SortMethod.C_Sharp_Lib;
                    foreach (Sort.CSharpSortMethod method in Enum.GetValues(typeof(Sort.CSharpSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbMergeSort":
                    m_method = Alg.SortMethod.Merge;
                    foreach (Sort.MergeSortMethod method in Enum.GetValues(typeof(Sort.MergeSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbQuickSort":
                    m_method = Alg.SortMethod.Quickly;
                    foreach (Sort.QuickSortMethod method in Enum.GetValues(typeof(Sort.QuickSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbRadixSort":
                    m_method = Alg.SortMethod.Radix;
                    foreach (Sort.RadixSortMethod method in Enum.GetValues(typeof(Sort.RadixSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbCountingSort":
                    m_method = Alg.SortMethod.Counting;
                    foreach (Sort.CoutingSortMethod method in Enum.GetValues(typeof(Sort.CoutingSortMethod)))
                        cbGoodORWorse.Items.Add(method);

                    break;
                case "rdbBuketSort":
                    m_method = Alg.SortMethod.Buket;
                    foreach (Sort.BuketSortMethod method in Enum.GetValues(typeof(Sort.BuketSortMethod)))
                        cbGoodORWorse.Items.Add(method);
                    break;
                case "rdbHeapSort":
                    m_method = Alg.SortMethod.Heap;
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
                {
                    //第一個是數字，先跳過
                    if (int.TryParse(sSplit[0], out int itFirstnum))
                    {
                        sSplit[0] += ". ";
                        continue;
                    }

                    if (i + 3 < sSplit.Length && sSplit[i] + sSplit[i + 1] + sSplit[i + 2] + sSplit[i + 3] == "(i.e.")
                    {
                        sSplit[i] = sSplit[i] + sSplit[i + 1];
                        sSplit[i + 2] = sSplit[i + 2] + sSplit[i + 3];
                        i += 3;
                        continue;
                    }
                    //0<= t.Length <= 10^4，也跳過換行
                    if(i + 2 < sSplit.Length && sSplit[i+1].Contains(".") && sSplit[i+2].Contains("<")|| sSplit[i+2].Contains("<="))
                    {
                        sSplit[i] = sSplit[i] + sSplit[i + 1];
                        RN_Motify(ref sSplit[i]);
                        i += 1;
                        continue;
                    }

                    sSplit[i] += sSplit[i + 1] + "\r\n";
                }

                int sSplit_Pointer = 1;bool bConsecutiveOfPoint =false; int sSplit_Pointer2 = 0;
                while (i + sSplit_Pointer < sSplit.Length && sSplit[i + sSplit_Pointer] == "" && sSplit[i + sSplit_Pointer2] == ".")
                {
                    bConsecutiveOfPoint = true;
                    sSplit[i] += " .";
                    sSplit_Pointer += 2;
                    sSplit_Pointer2 += 2;
                }

                RN_Motify(ref sSplit[i]);

                if (bConsecutiveOfPoint)
                    i += sSplit_Pointer2;
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

        private void RN_Motify(ref string _str)
        {
            // 1. 確保 "Example X:" 前後只有一次換行
            _str = Regex.Replace(_str, @"(\r\n)+Example (\d+):", match =>
            {
                // match.Groups[2] 是捕獲到的數字部分
                return $"\r\nExample {match.Groups[2]}:";
            });
            // 2. 在每個 "Example:" 後面加上 "\r\n"，如果後面沒有的話
            _str = Regex.Replace(_str, @"Example \d+:(\r\n)+", match =>
            {
                // match.Groups[2] 是捕獲到的數字部分
                return $"\r\nExample {match.Groups[2]}:";
            });

            // 3. 移除多餘的換行符號（將多個換行符號替換為一個）
            _str = Regex.Replace(_str, @"(\r\n)+", "\r\n");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Enabled = false;
            string sModelFactor = cbGoodORWorse.Text;
            MessageBoxRich(m_method.ToString() + " StartCase");

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

                switch (m_method)
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
            //介面上輸入
            string input1 = txtInput1.Text.Trim();
            string input2 = txtInput2.Text.Trim();
            string[] sDoubleArry = txtInput1.Text.Trim('[', ']').Split(new string[] { "],[" }, StringSplitOptions.None);

            string[] sElements1 = input1.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] sElements2 = input2.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            //輸入資料
            int[] iExamArry1 = new int[sElements1.Length];
            int[] iExamArry2 = new int[sElements2.Length];
            int[][] iExamDoubleArry1 = sDoubleArry.Select(row => row.Split(',').Select(int.Parse).ToArray()).ToArray(); // 將每個部分轉換成 int[] 並儲存為二維陣列

            //輸出資料
            int[] iAnsArray = iExamArry1; int iAns = 0; string sAns = null; List<string> lstAns = null;
            bool bAns = false;


            // 解析每個數字並存入一維陣列
            if (txtInput1.Text.Contains('[') && txtInput1.Text.Contains(']')) ;
            else
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
            if (txtInput1.Text.Contains('[') && txtInput1.Text.Contains(']')) ;
            else
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
                    case 2191:

                        //  解題：
                        iAnsArray = SolutionSort.SortJumbled(iExamArry1, iExamArry2);
                        //  測試答案：
                        sSrc = "{" + string.Join(", ", iExamArry1) + "}" + "，{" + string.Join(", ", iExamArry2) + "}";
                        sResult = "{" + string.Join(", ", iAnsArray) + "}";
                        MessageBoxRich("Input：" + sSrc + "，Output：" + sResult);
                        break;
                    case 392:

                        //  解題：
                        bAns = SolutionSort.IsSubsequence(input1, input2);
                        //  測試答案：
                        sSrc = "{" + string.Join(", ", input1) + "}" + "，{" + string.Join(", ", input2) + "}";
                        sResult = bAns.ToString();
                        MessageBoxRich("Input：" + sSrc + "，Output：" + sResult);
                        break;
                    case 179:

                        //  解題：
                        sAns = SolutionSort.LargestNumber(iExamArry1);
                        //  測試答案：
                        sSrc = "{" + string.Join(", ", input1) + "}" ;
                        sResult = sAns;
                        MessageBoxRich("Input：" + sSrc + "，Output：" + sResult);
                        break;
                    case 435:
                        //  解題：
                        iAns = SolutionSort.EraseOverlapIntervals(iExamDoubleArry1);
                        //  測試答案：
                        for(int i = 0;i < iExamDoubleArry1.Length; i++)
                            sSrc += "{" + string.Join(", ", iExamDoubleArry1[i]) + "}";
                        sResult = "{" + string.Join(", ", iAns) + "}";
                        MessageBoxRich("Input：" + sSrc + "，Output：" + sResult);
                        break;
                    case 228:
                        //  解題：
                        lstAns = SolutionSort.SummaryRanges(iExamArry1);
                        //  測試答案：
                        sSrc = "{" + string.Join(", ", iExamArry1) + "}";
                        sResult = "{" + string.Join(", ", lstAns) + "}";

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
            string sExamination = null; string sTitle = null; string sExam = null;
            m_bShowOnly = true;
            Invoke(new Action(() => { RtxtExamination.Clear();}));

            if (int.TryParse(txtLeetCodeNum.Text, out iLeetCodeNum))
            {
                switch (iLeetCodeNum)
                {
                    case 1122:
                        //  題目標題：
                        m_LevelOfExam = Alg.LevelOfExam.Easy; sExam = "Relative Sort Array：";
                        sTitle = iLeetCodeNum.ToString() + ". " + sExam + "(" + m_LevelOfExam.ToString() + ")";
                        RtxtExaminationMessage(sTitle, 16);

                        //  題型敘述：
                        sExamination = "Given two arrays arr1 and arr2, the elements of arr2 are distinct, and all elements in arr2 are also in arr1." +
                                       "Sort the elements of arr1 such that the relative ordering of items in arr1 are the same as in arr2. " +
                                       "Elements that do not appear in arr2 should be placed at the end of arr1 in ascending order." +
                                       "Example 1:\r\n\r\nInput: arr1 = [2,3,1,3,2,4,6,7,9,2,19], arr2 = [2,1,4,3,9,6]\r\nOutput: [2,2,2,1,4,3,3,9,6,7,19]\r\nExample 2:\r\n\r\nInput: arr1 = [28,6,22,8,44,17], arr2 = [22,28,8,6]\r\nOutput: [22,28,8,6,17,44]\r\n \r\n\r\nConstraints:\r\n\r\n1 <= arr1.length, arr2.length <= 1000\r\n0 <= arr1[i], arr2[i] <= 1000\r\nAll the elements of arr2 are distinct.\r\nEach arr2[i] is in arr1.";
                        RtxtExaminationMessage(sExamination);

                        break;
                    case 581:
                        //  題目標題：
                        m_LevelOfExam = Alg.LevelOfExam.Medium; sExam = "Shortest Unsorted Continuous Subarray：";
                        sTitle = iLeetCodeNum.ToString() + ". " + sExam + "(" + m_LevelOfExam.ToString() + ")";
                        RtxtExaminationMessage(sTitle, 16);

                        //  題型敘述：
                        sExamination = "Given an integer array nums, you need to find one continuous subarray such that if you only sort this subarray in non-decreasing order, " +
                                       "then the whole array will be sorted in non-decreasing order." +
                                       "Return the shortest such subarray and output its length." +
                                       "Example 1:\r\n\r\nInput: nums = [2,6,4,8,10,9,15]\r\nOutput: 5\r\nExplanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make the whole array sorted in ascending order.\r\nExample 2:\r\n\r\nInput: nums = [1,2,3,4]\r\nOutput: 0\r\nExample 3:\r\n\r\nInput: nums = [1]\r\nOutput: 0\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 10^4\r\n-10^5 <= nums[i] <= 10^5\r\n \r\n\r\nFollow up: Can you solve it in O(n) time complexity?";
                        RtxtExaminationMessage(sExamination);

                        break;
                    case 2191:
                        //  題目標題：
                        m_LevelOfExam = Alg.LevelOfExam.Medium; sExam = "Sort the Jumbled Numbers：";
                        sTitle = iLeetCodeNum.ToString() + ". " + sExam + "(" + m_LevelOfExam.ToString() + ")";
                        RtxtExaminationMessage(sTitle, 16);
                        //  題型敘述：
                        sExamination = "You are given a 0-indexed integer array mapping which represents the mapping rule of a shuffled decimal system. " +
                            "mapping[i] = j means digit i should be mapped to digit j in this system.\r\n\r\n" +
                            "The mapped value of an integer is the new integer obtained by replacing each occurrence of digit i in the integer with mapping[i] for all 0 <= i <= 9.\r\n\r\n" +
                            "You are also given another integer array nums. Return the array nums sorted in non-decreasing order based on the mapped values of its elements." +
                            "\r\n\r\nNotes:\r\n\r\n" +
                            "Elements with the same mapped values should appear in the same relative order as in the input.\r\n" +
                            "The elements of nums should only be sorted based on their mapped values and not be replaced by them." +
                            "Example 1:\r\n\r\nInput: mapping = [8,9,4,0,2,1,3,5,7,6], nums = [991,338,38]\r\nOutput: [338,38,991]\r\nExplanation: \r\nMap the number 991 as follows:\r\n1. mapping[9] = 6, so all occurrences of the digit 9 will become 6.\r\n2. mapping[1] = 9, so all occurrences of the digit 1 will become 9.\r\nTherefore, the mapped value of 991 is 669.\r\n338 maps to 007, or 7 after removing the leading zeros.\r\n38 maps to 07, which is also 7 after removing leading zeros.\r\nSince 338 and 38 share the same mapped value, they should remain in the same relative order, so 338 comes before 38.\r\nThus, the sorted array is [338,38,991].\r\nExample 2:\r\n\r\nInput: mapping = [0,1,2,3,4,5,6,7,8,9], nums = [789,456,123]\r\nOutput: [123,456,789]\r\nExplanation: 789 maps to 789, 456 maps to 456, and 123 maps to 123. Thus, the sorted array is [123,456,789].";
                        RtxtExaminationMessage(sExamination);

                        break;
                    case 392:
                        //  題目標題：
                        m_LevelOfExam = Alg.LevelOfExam.Easy; sExam = "Is Subsequence：";
                        sTitle = iLeetCodeNum.ToString() + ". " + sExam + "(" + m_LevelOfExam.ToString() + ")";
                        RtxtExaminationMessage(sTitle, 16);
                        //  題型敘述：
                        sExamination = "Given two strings s and t, return true if s is a subsequence of t, or false otherwise." +
                            "\r\n\r\nA subsequence of a string is a new string that is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. " +
                            "(i.e., \"ace\" is a subsequence of \"abcde\" while \"aec\" is not)." +
                            "Example 1:\r\n\r\nInput: s = \"abc\", t = \"ahbgdc\"\r\nOutput: true\r\nExample 2:\r\n\r\nInput: s = \"axc\", t = \"ahbgdc\"\r\nOutput: false\r\n \r\n\r\nConstraints:\r\n\r\n0 <= s.length <= 100\r\n0 <= t.length <= 10^4\r\ns and t consist only of lowercase English letters.\r\n \r\n\r\nFollow up: Suppose there are lots of incoming s, say s1, s2, ..., sk where k >= 10^9, and you want to check one by one to see if t has its subsequence. In this scenario, how would you change your code?";
                        RtxtExaminationMessage(sExamination);

                        break;
                    case 179:
                        //  題目標題：
                        m_LevelOfExam = Alg.LevelOfExam.Medium; sExam = "Largest Number：";
                        sTitle = iLeetCodeNum.ToString() + ". " + sExam + "(" + m_LevelOfExam.ToString() + ")";
                        RtxtExaminationMessage(sTitle, 16);
                        //  題型敘述：
                        sExamination = "Given a list of non-negative integers nums, arrange them such that they form the largest number and return it." +
                            "\r\n\r\nSince the result may be very large, so you need to return a string instead of an integer."+
                            "Example 1:\r\n\r\nInput: nums = [10,2]\r\nOutput: \"210\"\r\nExample 2:\r\n\r\nInput: nums = [3,30,34,5,9]\r\n" +
                            "Output: \"9534330\"\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 100\r\n0 <= nums[i] <= 10^9";
                        RtxtExaminationMessage(sExamination);

                        break;
                    case 435:
                        //  題目標題：
                        m_LevelOfExam = Alg.LevelOfExam.Medium; sExam = "Non-overlapping Intervals：";
                        sTitle = iLeetCodeNum.ToString() + ". " + sExam + "(" + m_LevelOfExam.ToString() + ")";
                        RtxtExaminationMessage(sTitle, 16);
                        //  題型敘述：
                        sExamination = "Given an array of intervals intervals where intervals[i] = [starti, endi], return the minimum number of intervals you need to remove to make the rest of the intervals non-overlapping.\r\n\r\nNote that intervals which only touch at a point are non-overlapping. For example, [1, 2] and [2, 3] are non-overlapping.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: intervals = [[1,2],[2,3],[3,4],[1,3]]\r\nOutput: 1\r\nExplanation: [1,3] can be removed and the rest of the intervals are non-overlapping.\r\nExample 2:\r\n\r\nInput: intervals = [[1,2],[1,2],[1,2]]\r\nOutput: 2\r\nExplanation: You need to remove two [1,2] to make the rest of the intervals non-overlapping.\r\nExample 3:\r\n\r\nInput: intervals = [[1,2],[2,3]]\r\nOutput: 0\r\nExplanation: You don't need to remove any of the intervals since they're already non-overlapping.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= intervals.length <= 105\r\nintervals[i].length == 2\r\n-5 * 104 <= starti < endi <= 5 * 104";
                        RtxtExaminationMessage(sExamination);

                        break;
                    case 228:
                        //  題目標題：
                        m_LevelOfExam = Alg.LevelOfExam.Easy; sExam = ". Summary Ranges：";
                        sTitle = iLeetCodeNum.ToString() + ". " + sExam + "(" + m_LevelOfExam.ToString() + ")";
                        RtxtExaminationMessage(sTitle, 16);
                        //  題型敘述：
                        sExamination = "You are given a sorted unique integer array nums.\r\n\r\nA range [a,b] is the set of all integers from a to b (inclusive).\r\n\r\nReturn the smallest sorted list of ranges that cover all the numbers in the array exactly. That is, each element of nums is covered by exactly one of the ranges, and there is no integer x such that x is in one of the ranges but not in nums.\r\n\r\nEach range [a,b] in the list should be output as:\r\n\r\n\"a->b\" if a != b\r\n\"a\" if a == b\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [0,1,2,4,5,7]\r\nOutput: [\"0->2\",\"4->5\",\"7\"]\r\nExplanation: The ranges are:\r\n[0,2] --> \"0->2\"\r\n[4,5] --> \"4->5\"\r\n[7,7] --> \"7\"\r\nExample 2:\r\n\r\nInput: nums = [0,2,3,4,6,8,9]\r\nOutput: [\"0\",\"2->4\",\"6\",\"8->9\"]\r\nExplanation: The ranges are:\r\n[0,0] --> \"0\"\r\n[2,4] --> \"2->4\"\r\n[6,6] --> \"6\"\r\n[8,9] --> \"8->9\"\r\n \r\n\r\nConstraints:\r\n\r\n0 <= nums.length <= 20\r\n-231 <= nums[i] <= 231 - 1\r\nAll the values of nums are unique.\r\nnums is sorted in ascending order.";
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

        private void btnLinkedlistBuild_Click(object sender, EventArgs e)
        {
            string str = null;
            #region - String(Utest) -
            Linkedlist myListStr = new Linkedlist(true);

            for (int i = 0; i <= 6; i++)
                myListStr.Add(i.ToString());

            str = myListStr.GetString(6);
            string str1 = myListStr.GetString(7);
            myListStr.PopString();
            str = myListStr.GetString(6);
            myListStr.Add("4");
            str = myListStr.PrintAllString();
            //myListStr.DeleteString("4");

            myListStr.InsertString(0, "321");
            str = myListStr.GetString(0);
            str = myListStr.GetString(1);
            str = myListStr.PrintAllString();

            myListStr.RemoveStringAt(0);
            str = myListStr.GetString(0);
            str = myListStr.GetString(1);
            str = myListStr.PrintAllString();

            myListStr.InsertString(4, "456");
            str = myListStr.GetString(4);
            str = myListStr.GetString(5);
            str = myListStr.PrintAllString();

            myListStr.RemoveStringAt(4);
            str = myListStr.GetString(4);
            str = myListStr.GetString(5);
            str = myListStr.PrintAllString();

            myListStr.FreeALLString();
            myListStr.Dispose();
            str = myListStr.List == IntPtr.Zero ? "It null" : myListStr.GetString(0);
            #endregion

            #region - Int(Utest) -
            Linkedlist myListInt = new Linkedlist(false);

            for (int i = 0; i <= 6; i++)
                myListInt.Add(i);

            int iAns = myListInt.Get(6);
            try
            {
                //試試超出索引(結果真的會報錯)
                int aa = myListInt.Get(7);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            myListInt.Pop();
            try
            {
                //試試超出索引(結果真的會報錯)
                int aa = myListInt.Get(6);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            myListInt.Add(4);
            str = myListInt.PrintAll();
            myListInt.Delete(4);
            str = myListInt.PrintAll();

            myListInt.Insert(0, 321);
            iAns = myListInt.Get(0);
            iAns = myListInt.Get(1);
            str = myListInt.PrintAll();

            myListInt.RemoveAt(0);
            iAns = myListInt.Get(0);
            iAns = myListInt.Get(1);
            str = myListInt.PrintAll();


            myListInt.Insert(4, 456);
            iAns = myListInt.Get(4);
            iAns = myListInt.Get(5);
            str = myListInt.PrintAll();

            myListInt.RemoveAt(4);
            iAns = myListInt.Get(4);
            try
            {
                iAns = myListInt.Get(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            str = myListInt.PrintAll();


            myListInt.FreeALLInt();
            myListInt.Dispose();
            #endregion
        }
    }
}
