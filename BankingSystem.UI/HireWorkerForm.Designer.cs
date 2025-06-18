using System.ComponentModel;

namespace BankingSystem.UI
{
    partial class HireWorkerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstUnemployed = new System.Windows.Forms.ListBox();
            this.btnConfirmHire = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(190, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Доступные для найма работники:";
            // 
            // lstUnemployed
            // 
            this.lstUnemployed.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstUnemployed.FormattingEnabled = true;
            this.lstUnemployed.ItemHeight = 29;
            this.lstUnemployed.Location = new System.Drawing.Point(201, 78);
            this.lstUnemployed.Name = "lstUnemployed";
            this.lstUnemployed.Size = new System.Drawing.Size(377, 178);
            this.lstUnemployed.TabIndex = 1;
            // 
            // btnConfirmHire
            // 
            this.btnConfirmHire.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirmHire.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConfirmHire.Location = new System.Drawing.Point(201, 313);
            this.btnConfirmHire.Name = "btnConfirmHire";
            this.btnConfirmHire.Size = new System.Drawing.Size(172, 48);
            this.btnConfirmHire.TabIndex = 2;
            this.btnConfirmHire.Text = "Нанять";
            this.btnConfirmHire.UseVisualStyleBackColor = true;
            this.btnConfirmHire.Click += new System.EventHandler(this.btnConfirmHire_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(406, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(172, 48);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // HireWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirmHire);
            this.Controls.Add(this.lstUnemployed);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HireWorkerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Найм работника";
            this.Load += new System.EventHandler(this.HireWorkerForm_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.Button btnConfirmHire;

        private System.Windows.Forms.ListBox lstUnemployed;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}