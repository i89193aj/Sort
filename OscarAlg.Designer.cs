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
            this.label4 = new System.Windows.Forms.Label();
            this.txtSendTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAns = new System.Windows.Forms.TextBox();
            this.btnInsetSort = new System.Windows.Forms.Button();
            this.gbMakeArray = new System.Windows.Forms.GroupBox();
            this.btnRadom = new System.Windows.Forms.Button();
            this.btnCleanArray = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMakeArray = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbManualParam = new System.Windows.Forms.GroupBox();
            this.gbRandomGiveParam = new System.Windows.Forms.GroupBox();
            this.txtRandomCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGoodorWorse = new System.Windows.Forms.Label();
            this.cbGoodORWorse = new System.Windows.Forms.ComboBox();
            this.btnDeepCopy = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.lblSpendTime.SuspendLayout();
            this.gbSortMethod.SuspendLayout();
            this.gbMakeArray.SuspendLayout();
            this.gbManualParam.SuspendLayout();
            this.gbRandomGiveParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.tabControl1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 0);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1169, 626);
            this.pnlBottom.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.lblSpendTime);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1169, 626);
            this.tabControl1.TabIndex = 0;
            // 
            // lblSpendTime
            // 
            this.lblSpendTime.Controls.Add(this.gbSortMethod);
            this.lblSpendTime.Controls.Add(this.gbMakeArray);
            this.lblSpendTime.Location = new System.Drawing.Point(4, 25);
            this.lblSpendTime.Name = "lblSpendTime";
            this.lblSpendTime.Padding = new System.Windows.Forms.Padding(3);
            this.lblSpendTime.Size = new System.Drawing.Size(1161, 597);
            this.lblSpendTime.TabIndex = 0;
            this.lblSpendTime.Text = "SpendTime";
            this.lblSpendTime.UseVisualStyleBackColor = true;
            // 
            // gbSortMethod
            // 
            this.gbSortMethod.Controls.Add(this.cbGoodORWorse);
            this.gbSortMethod.Controls.Add(this.lblGoodorWorse);
            this.gbSortMethod.Controls.Add(this.label4);
            this.gbSortMethod.Controls.Add(this.txtSendTime);
            this.gbSortMethod.Controls.Add(this.label1);
            this.gbSortMethod.Controls.Add(this.txtAns);
            this.gbSortMethod.Controls.Add(this.btnInsetSort);
            this.gbSortMethod.Location = new System.Drawing.Point(8, 270);
            this.gbSortMethod.Name = "gbSortMethod";
            this.gbSortMethod.Size = new System.Drawing.Size(409, 268);
            this.gbSortMethod.TabIndex = 5;
            this.gbSortMethod.TabStop = false;
            this.gbSortMethod.Text = "SortMethod";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "Spend\r\nTime (ns):";
            // 
            // txtSendTime
            // 
            this.txtSendTime.Location = new System.Drawing.Point(254, 76);
            this.txtSendTime.Name = "txtSendTime";
            this.txtSendTime.Size = new System.Drawing.Size(131, 25);
            this.txtSendTime.TabIndex = 4;
            this.txtSendTime.Text = "SendTime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ans :";
            // 
            // txtAns
            // 
            this.txtAns.Location = new System.Drawing.Point(254, 31);
            this.txtAns.Name = "txtAns";
            this.txtAns.Size = new System.Drawing.Size(131, 25);
            this.txtAns.TabIndex = 2;
            this.txtAns.Text = "Ans";
            // 
            // btnInsetSort
            // 
            this.btnInsetSort.Location = new System.Drawing.Point(6, 24);
            this.btnInsetSort.Name = "btnInsetSort";
            this.btnInsetSort.Size = new System.Drawing.Size(91, 32);
            this.btnInsetSort.TabIndex = 0;
            this.btnInsetSort.Text = "Insert";
            this.btnInsetSort.UseVisualStyleBackColor = true;
            this.btnInsetSort.Click += new System.EventHandler(this.btnMySort_Click);
            // 
            // gbMakeArray
            // 
            this.gbMakeArray.Controls.Add(this.gbRandomGiveParam);
            this.gbMakeArray.Controls.Add(this.gbManualParam);
            this.gbMakeArray.Location = new System.Drawing.Point(8, 18);
            this.gbMakeArray.Name = "gbMakeArray";
            this.gbMakeArray.Size = new System.Drawing.Size(434, 246);
            this.gbMakeArray.TabIndex = 4;
            this.gbMakeArray.TabStop = false;
            this.gbMakeArray.Text = "MakeArray";
            // 
            // btnRadom
            // 
            this.btnRadom.Location = new System.Drawing.Point(14, 24);
            this.btnRadom.Name = "btnRadom";
            this.btnRadom.Size = new System.Drawing.Size(108, 28);
            this.btnRadom.TabIndex = 7;
            this.btnRadom.Text = "Random";
            this.btnRadom.UseVisualStyleBackColor = true;
            this.btnRadom.Click += new System.EventHandler(this.btnRadom_Click);
            // 
            // btnCleanArray
            // 
            this.btnCleanArray.Location = new System.Drawing.Point(15, 62);
            this.btnCleanArray.Name = "btnCleanArray";
            this.btnCleanArray.Size = new System.Drawing.Size(108, 32);
            this.btnCleanArray.TabIndex = 6;
            this.btnCleanArray.Text = "CleanArray";
            this.btnCleanArray.UseVisualStyleBackColor = true;
            this.btnCleanArray.Click += new System.EventHandler(this.btnCleanArray_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Input :";
            // 
            // btnMakeArray
            // 
            this.btnMakeArray.Location = new System.Drawing.Point(15, 24);
            this.btnMakeArray.Name = "btnMakeArray";
            this.btnMakeArray.Size = new System.Drawing.Size(108, 32);
            this.btnMakeArray.TabIndex = 3;
            this.btnMakeArray.Text = "MakeArray";
            this.btnMakeArray.UseVisualStyleBackColor = true;
            this.btnMakeArray.Click += new System.EventHandler(this.btnMakeArray_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(171, 44);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(216, 25);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "Input";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(171, 101);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(216, 25);
            this.txtOutput.TabIndex = 2;
            this.txtOutput.Text = "Output";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1161, 597);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbManualParam
            // 
            this.gbManualParam.Controls.Add(this.btnCleanArray);
            this.gbManualParam.Controls.Add(this.btnMakeArray);
            this.gbManualParam.Controls.Add(this.label3);
            this.gbManualParam.Controls.Add(this.txtOutput);
            this.gbManualParam.Controls.Add(this.label2);
            this.gbManualParam.Controls.Add(this.txtInput);
            this.gbManualParam.Location = new System.Drawing.Point(6, 24);
            this.gbManualParam.Name = "gbManualParam";
            this.gbManualParam.Size = new System.Drawing.Size(422, 149);
            this.gbManualParam.TabIndex = 8;
            this.gbManualParam.TabStop = false;
            this.gbManualParam.Text = "ManualParam";
            // 
            // gbRandomGiveParam
            // 
            this.gbRandomGiveParam.Controls.Add(this.btnDeepCopy);
            this.gbRandomGiveParam.Controls.Add(this.label5);
            this.gbRandomGiveParam.Controls.Add(this.txtRandomCount);
            this.gbRandomGiveParam.Controls.Add(this.btnRadom);
            this.gbRandomGiveParam.Location = new System.Drawing.Point(7, 180);
            this.gbRandomGiveParam.Name = "gbRandomGiveParam";
            this.gbRandomGiveParam.Size = new System.Drawing.Size(421, 60);
            this.gbRandomGiveParam.TabIndex = 9;
            this.gbRandomGiveParam.TabStop = false;
            this.gbRandomGiveParam.Text = "RandomGiveParam";
            // 
            // txtRandomCount
            // 
            this.txtRandomCount.Location = new System.Drawing.Point(292, 24);
            this.txtRandomCount.Name = "txtRandomCount";
            this.txtRandomCount.Size = new System.Drawing.Size(94, 25);
            this.txtRandomCount.TabIndex = 8;
            this.txtRandomCount.Text = "10000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Count :";
            // 
            // lblGoodorWorse
            // 
            this.lblGoodorWorse.AutoSize = true;
            this.lblGoodorWorse.Location = new System.Drawing.Point(167, 132);
            this.lblGoodorWorse.Name = "lblGoodorWorse";
            this.lblGoodorWorse.Size = new System.Drawing.Size(51, 15);
            this.lblGoodorWorse.TabIndex = 7;
            this.lblGoodorWorse.Text = "Factor :";
            // 
            // cbGoodORWorse
            // 
            this.cbGoodORWorse.FormattingEnabled = true;
            this.cbGoodORWorse.Items.AddRange(new object[] {
            "Great",
            "Worse"});
            this.cbGoodORWorse.Location = new System.Drawing.Point(254, 129);
            this.cbGoodORWorse.Name = "cbGoodORWorse";
            this.cbGoodORWorse.Size = new System.Drawing.Size(131, 23);
            this.cbGoodORWorse.TabIndex = 8;
            // 
            // btnDeepCopy
            // 
            this.btnDeepCopy.Location = new System.Drawing.Point(128, 24);
            this.btnDeepCopy.Name = "btnDeepCopy";
            this.btnDeepCopy.Size = new System.Drawing.Size(93, 28);
            this.btnDeepCopy.TabIndex = 10;
            this.btnDeepCopy.Text = "Copy";
            this.btnDeepCopy.UseVisualStyleBackColor = true;
            this.btnDeepCopy.Click += new System.EventHandler(this.btnDeepCopy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 626);
            this.Controls.Add(this.pnlBottom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlBottom.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.lblSpendTime.ResumeLayout(false);
            this.gbSortMethod.ResumeLayout(false);
            this.gbSortMethod.PerformLayout();
            this.gbMakeArray.ResumeLayout(false);
            this.gbManualParam.ResumeLayout(false);
            this.gbManualParam.PerformLayout();
            this.gbRandomGiveParam.ResumeLayout(false);
            this.gbRandomGiveParam.PerformLayout();
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
    }
}

