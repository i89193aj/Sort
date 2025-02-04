using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace OscarAlg
{
    public partial class OscarAlg : Form
    {
        Sort SortAlg;
        public OscarAlg()
        {
            InitializeComponent();
            SortAlg = new Sort();

            cbGoodORWorse.SelectedIndex = 0;
        }
        int[] iInputnum;
        int[] iRandomCopy;
        Random random = new Random();
        public Stopwatch AlgSendTime = new Stopwatch();    //算法花費時間


        private void btnMakeArray_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(txtInput.Text, out int _arraynums))
            {
                MessageBox.Show("請輸入數字");
                return;
            }

            iInputnum = new int[txtInput.Text.Length];
            txtOutput.Text = "[";
            for (int i = 0;i< txtInput.Text.Length; i++)
            {
                iInputnum[i] = _arraynums % 10;
                _arraynums /= 10;
                if(i != txtInput.Text.Length - 1)
                    txtOutput.Text += txtInput.Text[i] + ", ";
                else
                    txtOutput.Text += txtInput.Text[i];
            }
            txtOutput.Text += "]";

            gbSortMethod.Enabled = true;
        }
        
        private void btnMySort_Click(object sender, EventArgs e)
        {
            int[] temp = iInputnum;
            int[] ans = null;
            Alg.SortMethod method = Alg.SortMethod.Insert;
            Button button = (Button)sender;
            button.Enabled = false;
            string sModelFactor = cbGoodORWorse.Text;

            switch (button.Name)
            {
                case "btnInsetSort":
                    method = Alg.SortMethod.Insert;
                    break;
                case "btnSelectSort":
                    method = Alg.SortMethod.Select;

                    break;
                case "btnBubbleSort":
                    method = Alg.SortMethod.Bubble;

                    break;
                case "btnMergeSort":
                    method = Alg.SortMethod.Merge;

                    break;
                case "btnQuicklySort":
                    method = Alg.SortMethod.Quickly;

                    break;

                case "btnCSharpSort":
                    method = Alg.SortMethod.C_Sharp_Lib;

                    break;

                default: break;
            }

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
                    break;
                case Alg.SortMethod.C_Sharp_Lib:
                    ans = SortAlg.CSharpSort(temp, sModelFactor);

                    break;
                default: break;
            }
            AlgSendTime.Stop();


            if (ans == null)
            {
                MessageBox.Show("Array is null");
                button.Enabled = true;
                return;
            }

            //手動的才給答案
            if (temp.Length < 10)
            {
                txtAns.Text = "[";
                for (int i = 0; i < ans.Length; i++)
                {
                    if (i != txtInput.Text.Length - 1)
                        txtAns.Text += ans[i].ToString() + ", ";
                    else
                        txtAns.Text += ans[i].ToString();
                }
                txtAns.Text += "]";
            }
            //因為這裡不可能像LeeCode那樣去自動代入那麼多參數測，所以用微秒看
            int iChangeunit = 1000;
            txtSendTime.Text = (AlgSendTime.Elapsed.TotalMilliseconds*iChangeunit).ToString("0.000");
            button.Enabled = true;
        }


        private void btnCleanArray_Click(object sender, EventArgs e)
        {
            if (iInputnum == null)
                return;

            Array.Clear(iInputnum, 0, iInputnum.Length);
            txtInput.Text = "";
            txtOutput.Text = "";
        }

        private void btnRadom_Click(object sender, EventArgs e)
        {
            btnRadom.Enabled = false;
            if(!int.TryParse(txtRandomCount.Text,out int count))
            {
                MessageBox.Show("請輸入要隨機給予的最大數字");
            }
            else if(count>10000)
            {
                MessageBox.Show("不得設大於10000(1w)");
            }
            else if(count<=0)
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
            Array.Copy(iRandomCopy,0, iInputnum,0, iInputnum.Length);
        }
    }
}
