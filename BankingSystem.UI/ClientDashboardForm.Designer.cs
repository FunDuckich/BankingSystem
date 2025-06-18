using System.ComponentModel;

namespace BankingSystem.UI
{
    partial class ClientDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtClientInfo = new System.Windows.Forms.RichTextBox();
            this.txtDepositAmount = new System.Windows.Forms.TextBox();
            this.btnOpenDeposit = new System.Windows.Forms.Button();
            this.btnCloseDeposit = new System.Windows.Forms.Button();
            this.depLabel = new System.Windows.Forms.Label();
            this.gbDeposit = new System.Windows.Forms.GroupBox();
            this.btnTakeLoan = new System.Windows.Forms.Button();
            this.txtLoanAmount = new System.Windows.Forms.TextBox();
            this.btnPayLoan = new System.Windows.Forms.Button();
            this.kreLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTransactionAmount = new System.Windows.Forms.TextBox();
            this.btnTopUp = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.operationsGroup = new System.Windows.Forms.GroupBox();
            this.gbPersonnel = new System.Windows.Forms.GroupBox();
            this.btnPayWages = new System.Windows.Forms.Button();
            this.btnHire = new System.Windows.Forms.Button();
            this.lstCurrentWorkers = new System.Windows.Forms.ListBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.gbDeposit.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.operationsGroup.SuspendLayout();
            this.gbPersonnel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtClientInfo
            // 
            this.txtClientInfo.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtClientInfo.Location = new System.Drawing.Point(469, 80);
            this.txtClientInfo.Name = "txtClientInfo";
            this.txtClientInfo.ReadOnly = true;
            this.txtClientInfo.Size = new System.Drawing.Size(285, 226);
            this.txtClientInfo.TabIndex = 0;
            this.txtClientInfo.Text = "";
            // 
            // txtDepositAmount
            // 
            this.txtDepositAmount.Location = new System.Drawing.Point(149, 53);
            this.txtDepositAmount.Name = "txtDepositAmount";
            this.txtDepositAmount.Size = new System.Drawing.Size(116, 31);
            this.txtDepositAmount.TabIndex = 0;
            // 
            // btnOpenDeposit
            // 
            this.btnOpenDeposit.Location = new System.Drawing.Point(17, 103);
            this.btnOpenDeposit.Name = "btnOpenDeposit";
            this.btnOpenDeposit.Size = new System.Drawing.Size(116, 32);
            this.btnOpenDeposit.TabIndex = 1;
            this.btnOpenDeposit.Text = "Открыть";
            this.btnOpenDeposit.UseVisualStyleBackColor = true;
            this.btnOpenDeposit.Click += new System.EventHandler(this.btnOpenDeposit_Click);
            // 
            // btnCloseDeposit
            // 
            this.btnCloseDeposit.Location = new System.Drawing.Point(149, 103);
            this.btnCloseDeposit.Name = "btnCloseDeposit";
            this.btnCloseDeposit.Size = new System.Drawing.Size(116, 32);
            this.btnCloseDeposit.TabIndex = 2;
            this.btnCloseDeposit.Text = "Закрыть";
            this.btnCloseDeposit.UseVisualStyleBackColor = true;
            this.btnCloseDeposit.Click += new System.EventHandler(this.btnCloseDeposit_Click);
            // 
            // depLabel
            // 
            this.depLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.depLabel.Location = new System.Drawing.Point(17, 51);
            this.depLabel.Name = "depLabel";
            this.depLabel.Size = new System.Drawing.Size(116, 33);
            this.depLabel.TabIndex = 3;
            this.depLabel.Text = "Сумма:";
            this.depLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbDeposit
            // 
            this.gbDeposit.Controls.Add(this.depLabel);
            this.gbDeposit.Controls.Add(this.btnCloseDeposit);
            this.gbDeposit.Controls.Add(this.btnOpenDeposit);
            this.gbDeposit.Controls.Add(this.txtDepositAmount);
            this.gbDeposit.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbDeposit.Location = new System.Drawing.Point(37, 487);
            this.gbDeposit.Name = "gbDeposit";
            this.gbDeposit.Size = new System.Drawing.Size(285, 161);
            this.gbDeposit.TabIndex = 1;
            this.gbDeposit.TabStop = false;
            this.gbDeposit.Text = "Депозит";
            // 
            // btnTakeLoan
            // 
            this.btnTakeLoan.Location = new System.Drawing.Point(18, 103);
            this.btnTakeLoan.Name = "btnTakeLoan";
            this.btnTakeLoan.Size = new System.Drawing.Size(117, 32);
            this.btnTakeLoan.TabIndex = 1;
            this.btnTakeLoan.Text = "Взять";
            this.btnTakeLoan.UseVisualStyleBackColor = true;
            this.btnTakeLoan.Click += new System.EventHandler(this.btnTakeLoan_Click);
            // 
            // txtLoanAmount
            // 
            this.txtLoanAmount.Location = new System.Drawing.Point(156, 53);
            this.txtLoanAmount.Name = "txtLoanAmount";
            this.txtLoanAmount.Size = new System.Drawing.Size(117, 31);
            this.txtLoanAmount.TabIndex = 0;
            // 
            // btnPayLoan
            // 
            this.btnPayLoan.Location = new System.Drawing.Point(156, 103);
            this.btnPayLoan.Name = "btnPayLoan";
            this.btnPayLoan.Size = new System.Drawing.Size(117, 32);
            this.btnPayLoan.TabIndex = 2;
            this.btnPayLoan.Text = "Вернуть";
            this.btnPayLoan.UseVisualStyleBackColor = true;
            this.btnPayLoan.Click += new System.EventHandler(this.btnPayLoan_Click);
            // 
            // kreLabel
            // 
            this.kreLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.kreLabel.Location = new System.Drawing.Point(19, 51);
            this.kreLabel.Name = "kreLabel";
            this.kreLabel.Size = new System.Drawing.Size(116, 33);
            this.kreLabel.TabIndex = 4;
            this.kreLabel.Text = "Сумма:";
            this.kreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kreLabel);
            this.groupBox1.Controls.Add(this.btnPayLoan);
            this.groupBox1.Controls.Add(this.txtLoanAmount);
            this.groupBox1.Controls.Add(this.btnTakeLoan);
            this.groupBox1.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(469, 487);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 161);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Кредит";
            // 
            // txtTransactionAmount
            // 
            this.txtTransactionAmount.Location = new System.Drawing.Point(150, 34);
            this.txtTransactionAmount.Name = "txtTransactionAmount";
            this.txtTransactionAmount.Size = new System.Drawing.Size(116, 31);
            this.txtTransactionAmount.TabIndex = 0;
            // 
            // btnTopUp
            // 
            this.btnTopUp.Location = new System.Drawing.Point(17, 84);
            this.btnTopUp.Name = "btnTopUp";
            this.btnTopUp.Size = new System.Drawing.Size(136, 32);
            this.btnTopUp.TabIndex = 1;
            this.btnTopUp.Text = "Пополнить";
            this.btnTopUp.UseVisualStyleBackColor = true;
            this.btnTopUp.Click += new System.EventHandler(this.btnTopUp_Click);
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(159, 84);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(116, 32);
            this.btnWithdraw.TabIndex = 2;
            this.btnWithdraw.Text = "Снять";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // operationsGroup
            // 
            this.operationsGroup.Controls.Add(this.btnWithdraw);
            this.operationsGroup.Controls.Add(this.btnTopUp);
            this.operationsGroup.Controls.Add(this.txtTransactionAmount);
            this.operationsGroup.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationsGroup.Location = new System.Drawing.Point(465, 314);
            this.operationsGroup.Name = "operationsGroup";
            this.operationsGroup.Size = new System.Drawing.Size(293, 127);
            this.operationsGroup.TabIndex = 4;
            this.operationsGroup.TabStop = false;
            this.operationsGroup.Text = "Счёт";
            // 
            // gbPersonnel
            // 
            this.gbPersonnel.Controls.Add(this.btnPayWages);
            this.gbPersonnel.Controls.Add(this.btnHire);
            this.gbPersonnel.Controls.Add(this.lstCurrentWorkers);
            this.gbPersonnel.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbPersonnel.Location = new System.Drawing.Point(37, 46);
            this.gbPersonnel.Name = "gbPersonnel";
            this.gbPersonnel.Size = new System.Drawing.Size(285, 401);
            this.gbPersonnel.TabIndex = 5;
            this.gbPersonnel.TabStop = false;
            this.gbPersonnel.Text = "Управление персоналом";
            // 
            // btnPayWages
            // 
            this.btnPayWages.Location = new System.Drawing.Point(28, 341);
            this.btnPayWages.Name = "btnPayWages";
            this.btnPayWages.Size = new System.Drawing.Size(233, 46);
            this.btnPayWages.TabIndex = 2;
            this.btnPayWages.Text = "Выплатить зарплату";
            this.btnPayWages.UseVisualStyleBackColor = true;
            this.btnPayWages.Click += new System.EventHandler(this.btnPayWages_Click);
            // 
            // btnHire
            // 
            this.btnHire.Location = new System.Drawing.Point(91, 289);
            this.btnHire.Name = "btnHire";
            this.btnHire.Size = new System.Drawing.Size(99, 42);
            this.btnHire.TabIndex = 1;
            this.btnHire.Text = "Нанять";
            this.btnHire.UseVisualStyleBackColor = true;
            this.btnHire.Click += new System.EventHandler(this.btnHire_Click);
            // 
            // lstCurrentWorkers
            // 
            this.lstCurrentWorkers.FormattingEnabled = true;
            this.lstCurrentWorkers.ItemHeight = 26;
            this.lstCurrentWorkers.Location = new System.Drawing.Point(18, 34);
            this.lstCurrentWorkers.Name = "lstCurrentWorkers";
            this.lstCurrentWorkers.Size = new System.Drawing.Size(248, 238);
            this.lstCurrentWorkers.TabIndex = 0;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLogOut.Location = new System.Drawing.Point(535, 25);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(144, 49);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "Выйти";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // ClientDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 684);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.gbPersonnel);
            this.Controls.Add(this.operationsGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDeposit);
            this.Controls.Add(this.txtClientInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClientDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно клиента банка";
            this.Load += new System.EventHandler(this.ClientDashboardForm_Load);
            this.gbDeposit.ResumeLayout(false);
            this.gbDeposit.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.operationsGroup.ResumeLayout(false);
            this.operationsGroup.PerformLayout();
            this.gbPersonnel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnLogOut;

        private System.Windows.Forms.Button btnPayWages;

        private System.Windows.Forms.Button btnHire;

        private System.Windows.Forms.ListBox lstCurrentWorkers;

        private System.Windows.Forms.GroupBox gbPersonnel;
        
        private System.Windows.Forms.GroupBox operationsGroup;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnTopUp;
        private System.Windows.Forms.TextBox txtTransactionAmount;

        private System.Windows.Forms.Label kreLabel;

        private System.Windows.Forms.Label depLabel;

        private System.Windows.Forms.Button btnPayLoan;

        private System.Windows.Forms.Button btnTakeLoan;

        private System.Windows.Forms.TextBox txtLoanAmount;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Button btnCloseDeposit;

        private System.Windows.Forms.Button btnOpenDeposit;

        private System.Windows.Forms.TextBox txtDepositAmount;

        private System.Windows.Forms.GroupBox gbDeposit;

        private System.Windows.Forms.RichTextBox txtClientInfo;

        #endregion
    }
}