namespace EAssociation
{
    partial class BloodGraph
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BloodGraph));
            this.closeSecretecgraphbtn = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // closeSecretecgraphbtn
            // 
            this.closeSecretecgraphbtn.Animated = true;
            this.closeSecretecgraphbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.closeSecretecgraphbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.closeSecretecgraphbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.closeSecretecgraphbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.closeSecretecgraphbtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.closeSecretecgraphbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.closeSecretecgraphbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(192)))), ((int)(((byte)(244)))));
            this.closeSecretecgraphbtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(94)))));
            this.closeSecretecgraphbtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.closeSecretecgraphbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(213)))), ((int)(((byte)(224)))));
            this.closeSecretecgraphbtn.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(192)))), ((int)(((byte)(244)))));
            this.closeSecretecgraphbtn.HoverState.ForeColor = System.Drawing.Color.Black;
            this.closeSecretecgraphbtn.Location = new System.Drawing.Point(916, 12);
            this.closeSecretecgraphbtn.Name = "closeSecretecgraphbtn";
            this.closeSecretecgraphbtn.PressedColor = System.Drawing.Color.Aqua;
            this.closeSecretecgraphbtn.PressedDepth = 45;
            this.closeSecretecgraphbtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.closeSecretecgraphbtn.Size = new System.Drawing.Size(52, 50);
            this.closeSecretecgraphbtn.TabIndex = 15;
            this.closeSecretecgraphbtn.Text = "X";
            this.closeSecretecgraphbtn.TextFormatNoPrefix = true;
            this.closeSecretecgraphbtn.Click += new System.EventHandler(this.closeSecretecgraphbtn_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 50;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockForm = false;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Location = new System.Drawing.Point(11, 70);
            this.zedGraphControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(956, 549);
            this.zedGraphControl2.TabIndex = 16;
            // 
            // BloodGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(980, 584);
            this.Controls.Add(this.zedGraphControl2);
            this.Controls.Add(this.closeSecretecgraphbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BloodGraph";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BloodGraph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BloodGraph_FormClosing);
            this.Load += new System.EventHandler(this.BloodGraph_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientCircleButton closeSecretecgraphbtn;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private ZedGraph.ZedGraphControl zedGraphControl2;
    }
}