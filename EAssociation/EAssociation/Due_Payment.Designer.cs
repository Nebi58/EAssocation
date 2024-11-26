namespace EAssociation
{
    partial class Due_Payment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.dgwPayment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwPayment
            // 
            this.dgwPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPayment.Location = new System.Drawing.Point(571, 1);
            this.dgwPayment.Name = "dgwPayment";
            this.dgwPayment.RowHeadersWidth = 62;
            this.dgwPayment.RowTemplate.Height = 28;
            this.dgwPayment.Size = new System.Drawing.Size(723, 827);
            this.dgwPayment.TabIndex = 0;
            // 
            // Due_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 825);
            this.Controls.Add(this.dgwPayment);
            this.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "Due_Payment";
            this.Text = "Due_Payment";
            this.Load += new System.EventHandler(this.Due_Payment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwPayment;
    }
}