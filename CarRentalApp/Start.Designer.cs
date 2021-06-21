
namespace CarRentalApp
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.loadingProgress = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.percentage = new System.Windows.Forms.Label();
            this.carphoto = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.loadingProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carphoto)).BeginInit();
            this.SuspendLayout();
            // 
            // loadingProgress
            // 
            this.loadingProgress.Controls.Add(this.percentage);
            this.loadingProgress.Controls.Add(this.carphoto);
            this.loadingProgress.FillColor = System.Drawing.Color.DodgerBlue;
            this.loadingProgress.FillOffset = 10;
            this.loadingProgress.FillThickness = 20;
            this.loadingProgress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.loadingProgress.ForeColor = System.Drawing.Color.White;
            this.loadingProgress.InnerColor = System.Drawing.Color.DodgerBlue;
            this.loadingProgress.Location = new System.Drawing.Point(256, 117);
            this.loadingProgress.Minimum = 0;
            this.loadingProgress.Name = "loadingProgress";
            this.loadingProgress.ProgressColor = System.Drawing.Color.White;
            this.loadingProgress.ProgressColor2 = System.Drawing.Color.White;
            this.loadingProgress.ProgressThickness = 10;
            this.loadingProgress.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.loadingProgress.ShadowDecoration.Parent = this.loadingProgress;
            this.loadingProgress.Size = new System.Drawing.Size(250, 250);
            this.loadingProgress.TabIndex = 1;
            this.loadingProgress.Text = "carLoadingProgress";
            // 
            // percentage
            // 
            this.percentage.AutoSize = true;
            this.percentage.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentage.ForeColor = System.Drawing.Color.White;
            this.percentage.Location = new System.Drawing.Point(79, 148);
            this.percentage.Name = "percentage";
            this.percentage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.percentage.Size = new System.Drawing.Size(0, 39);
            this.percentage.TabIndex = 6;
            // 
            // carphoto
            // 
            this.carphoto.BackColor = System.Drawing.Color.DodgerBlue;
            this.carphoto.Image = ((System.Drawing.Image)(resources.GetObject("carphoto.Image")));
            this.carphoto.ImageRotate = 0F;
            this.carphoto.Location = new System.Drawing.Point(55, 63);
            this.carphoto.Name = "carphoto";
            this.carphoto.ShadowDecoration.Parent = this.carphoto;
            this.carphoto.Size = new System.Drawing.Size(149, 124);
            this.carphoto.TabIndex = 2;
            this.carphoto.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "CAR RENTAL SYSTEM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(249, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Iden Solo Rentals";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(778, 491);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadingProgress);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Start_Load);
            this.loadingProgress.ResumeLayout(false);
            this.loadingProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carphoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleProgressBar loadingProgress;
        private Guna.UI2.WinForms.Guna2PictureBox carphoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label percentage;
    }
}

