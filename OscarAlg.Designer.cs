namespace OscarAlg
{
    partial class OscarAlg
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lblSpendTime = new System.Windows.Forms.TabPage();
            this.gbSortMethod = new System.Windows.Forms.GroupBox();
            this.cbGoodORWorse = new System.Windows.Forms.ComboBox();
            this.lblGoodorWorse = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSendTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAns = new System.Windows.Forms.TextBox();
            this.btnInsetSort = new System.Windows.Forms.Button();
            this.gbMakeArray = new System.Windows.Forms.GroupBox();
            this.gbRandomGiveParam = new System.Windows.Forms.GroupBox();
            this.btnDeepCopy = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRandomCount = new System.Windows.Forms.TextBox();
            this.btnRadom = new System.Windows.Forms.Button();
            this.gbManualParam = new System.Windows.Forms.GroupBox();
            this.btnCleanArray = new System.Windows.Forms.Button();
            this.btnMakeArray = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnBubbleSort = new System.Windows.Forms.Button();
            this.btnSelectSort = new System.Windows.Forms.Button();
            this.btnCSharpSort = new System.Windows.Forms.Button();
            this.btnMergeSort = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.lblSpendTime.SuspendLayout();
            this.gbSortMethod.SuspendLayout();
            this.gbMakeArray.SuspendLayout();
            this.gbRandomGiveParam.SuspendLayout();
            this.gbManualParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.tabControl1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 0);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(877, 501);
            this.pnlBottom.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.lblSpendTime);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(877, 501);
            this.tabControl1.TabIndex = 0;
            // 
            // lblSpendTime
            // 
            this.lblSpendTime.Controls.Add(this.gbSortMethod);
            this.lblSpendTime.Controls.Add(this.gbMakeArray);
            this.lblSpendTime.Location = new System.Drawing.Point(4, 22);
            this.lblSpendTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblSpendTime.Name = "lblSpendTime";
            this.lblSpendTime.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblSpendTime.Size = new System.Drawing.Size(869, 475);
            this.lblSpendTime.TabIndex = 0;
            this.lblSpendTime.Text = "SpendTime";
            this.lblSpendTime.UseVisualStyleBackColor = true;
            // 
            // gbSortMethod
            // 
            this.gbSortMethod.Controls.Add(this.btnMergeSort);
            this.gbSortMethod.Controls.Add(this.btnCSharpSort);
            this.gbSortMethod.Controls.Add(this.btnSelectSort);
            this.gbSortMethod.Controls.Add(this.btnBubbleSort);
            this.gbSortMethod.Controls.Add(this.cbGoodORWorse);
            this.gbSortMethod.Controls.Add(this.lblGoodorWorse);
            this.gbSortMethod.Controls.Add(this.label4);
            this.gbSortMethod.Controls.Add(this.txtSendTime);
            this.gbSortMethod.Controls.Add(this.label1);
            this.gbSortMethod.Controls.Add(this.txtAns);
            this.gbSortMethod.Controls.Add(this.btnInsetSort);
            this.gbSortMethod.Enabled = false;
            this.gbSortMethod.Location = new System.Drawing.Point(6, 216);
            this.gbSortMethod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbSortMethod.Name = "gbSortMethod";
            this.gbSortMethod.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbSortMethod.Size = new System.Drawing.Size(307, 214);
            this.gbSortMethod.TabIndex = 5;
            this.gbSortMethod.TabStop = false;
            this.gbSortMethod.Text = "SortMethod";
            // 
            // cbGoodORWorse
            // 
            this.cbGoodORWorse.FormattingEnabled = true;
            this.cbGoodORWorse.Items.AddRange(new object[] {
            "Great",
            "Worse"});
            this.cbGoodORWorse.Location = new System.Drawing.Point(190, 103);
            this.cbGoodORWorse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbGoodORWorse.Name = "cbGoodORWorse";
            this.cbGoodORWorse.Size = new System.Drawing.Size(99, 20);
            this.cbGoodORWorse.TabIndex = 8;
            // 
            // lblGoodorWorse
            // 
            this.lblGoodorWorse.AutoSize = true;
            this.lblGoodorWorse.Location = new System.Drawing.Point(125, 106);
            this.lblGoodorWorse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGoodorWorse.Name = "lblGoodorWorse";
            this.lblGoodorWorse.Size = new System.Drawing.Size(40, 12);
            this.lblGoodorWorse.TabIndex = 7;
            this.lblGoodorWorse.Text = "Factor :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Spend\r\nTime (ns):";
            // 
            // txtSendTime
            // 
            this.txtSendTime.Location = new System.Drawing.Point(190, 61);
            this.txtSendTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSendTime.Name = "txtSendTime";
            this.txtSendTime.Size = new System.Drawing.Size(99, 22);
            this.txtSendTime.TabIndex = 4;
            this.txtSendTime.Text = "SendTime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ans :";
            // 
            // txtAns
            // 
            this.txtAns.Location = new System.Drawing.Point(190, 25);
            this.txtAns.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAns.Name = "txtAns";
            this.txtAns.Size = new System.Drawing.Size(99, 22);
            this.txtAns.TabIndex = 2;
            this.txtAns.Text = "Ans";
            // 
            // btnInsetSort
            // 
            this.btnInsetSort.Location = new System.Drawing.Point(4, 19);
            this.btnInsetSort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInsetSort.Name = "btnInsetSort";
            this.btnInsetSort.Size = new System.Drawing.Size(68, 26);
            this.btnInsetSort.TabIndex = 0;
            this.btnInsetSort.Text = "Insert";
            this.btnInsetSort.UseVisualStyleBackColor = true;
            this.btnInsetSort.Click += new System.EventHandler(this.btnMySort_Click);
            // 
            // gbMakeArray
            // 
            this.gbMakeArray.Controls.Add(this.gbRandomGiveParam);
            this.gbMakeArray.Controls.Add(this.gbManualParam);
            this.gbMakeArray.Location = new System.Drawing.Point(6, 14);
            this.gbMakeArray.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbMakeArray.Name = "gbMakeArray";
            this.gbMakeArray.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbMakeArray.Size = new System.Drawing.Size(326, 197);
            this.gbMakeArray.TabIndex = 4;
            this.gbMakeArray.TabStop = false;
            this.gbMakeArray.Text = "MakeArray";
            // 
            // gbRandomGiveParam
            // 
            this.gbRandomGiveParam.Controls.Add(this.btnDeepCopy);
            this.gbRandomGiveParam.Controls.Add(this.label5);
            this.gbRandomGiveParam.Controls.Add(this.txtRandomCount);
            this.gbRandomGiveParam.Controls.Add(this.btnRadom);
            this.gbRandomGiveParam.Location = new System.Drawing.Point(5, 144);
            this.gbRandomGiveParam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbRandomGiveParam.Name = "gbRandomGiveParam";
            this.gbRandomGiveParam.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbRandomGiveParam.Size = new System.Drawing.Size(316, 48);
            this.gbRandomGiveParam.TabIndex = 9;
            this.gbRandomGiveParam.TabStop = false;
            this.gbRandomGiveParam.Text = "RandomGiveParam";
            // 
            // btnDeepCopy
            // 
            this.btnDeepCopy.Enabled = false;
            this.btnDeepCopy.Location = new System.Drawing.Point(96, 19);
            this.btnDeepCopy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeepCopy.Name = "btnDeepCopy";
            this.btnDeepCopy.Size = new System.Drawing.Size(70, 22);
            this.btnDeepCopy.TabIndex = 10;
            this.btnDeepCopy.Text = "Copy";
            this.btnDeepCopy.UseVisualStyleBackColor = true;
            this.btnDeepCopy.Click += new System.EventHandler(this.btnDeepCopy_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Count :";
            // 
            // txtRandomCount
            // 
            this.txtRandomCount.Location = new System.Drawing.Point(219, 19);
            this.txtRandomCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRandomCount.Name = "txtRandomCount";
            this.txtRandomCount.Size = new System.Drawing.Size(72, 22);
            this.txtRandomCount.TabIndex = 8;
            this.txtRandomCount.Text = "10000";
            // 
            // btnRadom
            // 
            this.btnRadom.Location = new System.Drawing.Point(10, 19);
            this.btnRadom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRadom.Name = "btnRadom";
            this.btnRadom.Size = new System.Drawing.Size(81, 22);
            this.btnRadom.TabIndex = 7;
            this.btnRadom.Text = "Random";
            this.btnRadom.UseVisualStyleBackColor = true;
            this.btnRadom.Click += new System.EventHandler(this.btnRadom_Click);
            // 
            // gbManualParam
            // 
            this.gbManualParam.Controls.Add(this.btnCleanArray);
            this.gbManualParam.Controls.Add(this.btnMakeArray);
            this.gbManualParam.Controls.Add(this.label3);
            this.gbManualParam.Controls.Add(this.txtOutput);
            this.gbManualParam.Controls.Add(this.label2);
            this.gbManualParam.Controls.Add(this.txtInput);
            this.gbManualParam.Location = new System.Drawing.Point(4, 19);
            this.gbManualParam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbManualParam.Name = "gbManualParam";
            this.gbManualParam.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbManualParam.Size = new System.Drawing.Size(316, 119);
            this.gbManualParam.TabIndex = 8;
            this.gbManualParam.TabStop = false;
            this.gbManualParam.Text = "ManualParam";
            // 
            // btnCleanArray
            // 
            this.btnCleanArray.Location = new System.Drawing.Point(11, 50);
            this.btnCleanArray.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCleanArray.Name = "btnCleanArray";
            this.btnCleanArray.Size = new System.Drawing.Size(81, 26);
            this.btnCleanArray.TabIndex = 6;
            this.btnCleanArray.Text = "CleanArray";
            this.btnCleanArray.UseVisualStyleBackColor = true;
            this.btnCleanArray.Click += new System.EventHandler(this.btnCleanArray_Click);
            // 
            // btnMakeArray
            // 
            this.btnMakeArray.Location = new System.Drawing.Point(11, 19);
            this.btnMakeArray.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMakeArray.Name = "btnMakeArray";
            this.btnMakeArray.Size = new System.Drawing.Size(81, 26);
            this.btnMakeArray.TabIndex = 3;
            this.btnMakeArray.Text = "MakeArray";
            this.btnMakeArray.UseVisualStyleBackColor = true;
            this.btnMakeArray.Click += new System.EventHandler(this.btnMakeArray_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output :";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(128, 81);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(163, 22);
            this.txtOutput.TabIndex = 2;
            this.txtOutput.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Input :";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(128, 35);
            this.txtInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(163, 22);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "Input";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(869, 475);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnBubbleSort
            // 
            this.btnBubbleSort.Location = new System.Drawing.Point(5, 49);
            this.btnBubbleSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnBubbleSort.Name = "btnBubbleSort";
            this.btnBubbleSort.Size = new System.Drawing.Size(68, 26);
            this.btnBubbleSort.TabIndex = 9;
            this.btnBubbleSort.Text = "Bubble";
            this.btnBubbleSort.UseVisualStyleBackColor = true;
            this.btnBubbleSort.Click += new System.EventHandler(this.btnMySort_Click);
            // 
            // btnSelectSort
            // 
            this.btnSelectSort.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.btnSelectSort.Location = new System.Drawing.Point(4, 79);
            this.btnSelectSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectSort.Name = "btnSelectSort";
            this.btnSelectSort.Size = new System.Drawing.Size(68, 26);
            this.btnSelectSort.TabIndex = 10;
            this.btnSelectSort.Text = "Select";
            this.btnSelectSort.UseVisualStyleBackColor = true;
            this.btnSelectSort.Click += new System.EventHandler(this.btnMySort_Click);
            // 
            // btnCSharpSort
            // 
            this.btnCSharpSort.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.btnCSharpSort.Location = new System.Drawing.Point(4, 109);
            this.btnCSharpSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnCSharpSort.Name = "btnCSharpSort";
            this.btnCSharpSort.Size = new System.Drawing.Size(68, 26);
            this.btnCSharpSort.TabIndex = 11;
            this.btnCSharpSort.Text = "CSharpSort";
            this.btnCSharpSort.UseVisualStyleBackColor = true;
            this.btnCSharpSort.Click += new System.EventHandler(this.btnMySort_Click);
            // 
            // btnMergeSort
            // 
            this.btnMergeSort.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.btnMergeSort.Location = new System.Drawing.Point(5, 139);
            this.btnMergeSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnMergeSort.Name = "btnMergeSort";
            this.btnMergeSort.Size = new System.Drawing.Size(68, 26);
            this.btnMergeSort.TabIndex = 12;
            this.btnMergeSort.Text = "MergeSort";
            this.btnMergeSort.UseVisualStyleBackColor = true;
            this.btnMergeSort.Click += new System.EventHandler(this.btnMySort_Click);
            // 
            // OscarAlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 501);
            this.Controls.Add(this.pnlBottom);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OscarAlg";
            this.Text = "Form1";
            this.pnlBottom.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.lblSpendTime.ResumeLayout(false);
            this.gbSortMethod.ResumeLayout(false);
            this.gbSortMethod.PerformLayout();
            this.gbMakeArray.ResumeLayout(false);
            this.gbRandomGiveParam.ResumeLayout(false);
            this.gbRandomGiveParam.PerformLayout();
            this.gbManualParam.ResumeLayout(false);
            this.gbManualParam.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage lblSpendTime;
        private System.Windows.Forms.Button btnMakeArray;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnInsetSort;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbSortMethod;
        private System.Windows.Forms.TextBox txtAns;
        private System.Windows.Forms.GroupBox gbMakeArray;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCleanArray;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSendTime;
        private System.Windows.Forms.Button btnRadom;
        private System.Windows.Forms.GroupBox gbRandomGiveParam;
        private System.Windows.Forms.GroupBox gbManualParam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRandomCount;
        private System.Windows.Forms.Label lblGoodorWorse;
        private System.Windows.Forms.ComboBox cbGoodORWorse;
        private System.Windows.Forms.Button btnDeepCopy;
        private System.Windows.Forms.Button btnBubbleSort;
        private System.Windows.Forms.Button btnSelectSort;
        private System.Windows.Forms.Button btnCSharpSort;
        private System.Windows.Forms.Button btnMergeSort;
    }
}

