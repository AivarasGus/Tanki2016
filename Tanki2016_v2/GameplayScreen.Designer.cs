namespace Tanki2016_v2
{
    partial class GameplayScreen
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gameBorders = new System.Windows.Forms.PictureBox();
            this.life1 = new System.Windows.Forms.PictureBox();
            this.life2 = new System.Windows.Forms.PictureBox();
            this.life3 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameBorders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gameBorders
            // 
            this.gameBorders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameBorders.Location = new System.Drawing.Point(12, 79);
            this.gameBorders.Name = "gameBorders";
            this.gameBorders.Size = new System.Drawing.Size(750, 450);
            this.gameBorders.TabIndex = 1;
            this.gameBorders.TabStop = false;
            // 
            // life1
            // 
            this.life1.Image = global::Tanki2016_v2.Properties.Resources.lifes;
            this.life1.Location = new System.Drawing.Point(702, 13);
            this.life1.Name = "life1";
            this.life1.Size = new System.Drawing.Size(60, 60);
            this.life1.TabIndex = 2;
            this.life1.TabStop = false;
            // 
            // life2
            // 
            this.life2.Image = global::Tanki2016_v2.Properties.Resources.lifes;
            this.life2.Location = new System.Drawing.Point(636, 13);
            this.life2.Name = "life2";
            this.life2.Size = new System.Drawing.Size(60, 60);
            this.life2.TabIndex = 3;
            this.life2.TabStop = false;
            // 
            // life3
            // 
            this.life3.Image = global::Tanki2016_v2.Properties.Resources.lifes;
            this.life3.Location = new System.Drawing.Point(570, 13);
            this.life3.Name = "life3";
            this.life3.Size = new System.Drawing.Size(60, 60);
            this.life3.TabIndex = 4;
            this.life3.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 13);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(175, 60);
            this.progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(193, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Score: ";
            // 
            // GameplayScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 541);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.life3);
            this.Controls.Add(this.life2);
            this.Controls.Add(this.life1);
            this.Controls.Add(this.gameBorders);
            this.Name = "GameplayScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tanki2016";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameBorders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox gameBorders;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox brick;
        private System.Windows.Forms.PictureBox life1;
        private System.Windows.Forms.PictureBox life2;
        private System.Windows.Forms.PictureBox life3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
    }
}

