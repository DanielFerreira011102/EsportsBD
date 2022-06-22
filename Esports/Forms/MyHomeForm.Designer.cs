namespace Esports.Forms
{
    partial class MyHomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyHomeForm));
            this.wave = new System.Windows.Forms.PictureBox();
            this.header = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wave)).BeginInit();
            this.SuspendLayout();
            // 
            // wave
            // 
            this.wave.Image = ((System.Drawing.Image)(resources.GetObject("wave.Image")));
            this.wave.Location = new System.Drawing.Point(1028, 22);
            this.wave.Name = "wave";
            this.wave.Size = new System.Drawing.Size(119, 126);
            this.wave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.wave.TabIndex = 4;
            this.wave.TabStop = false;
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Quicksand", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.header.ForeColor = System.Drawing.Color.Black;
            this.header.Location = new System.Drawing.Point(12, 23);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1037, 119);
            this.header.TabIndex = 3;
            this.header.Text = "Welcome Back, Username!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 158);
            this.label2.MaximumSize = new System.Drawing.Size(1319, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1298, 578);
            this.label2.TabIndex = 5;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // MyHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 768);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wave);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MyHomeForm";
            this.Text = "MyHomeForm";
            this.Load += new System.EventHandler(this.MyHomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox wave;
        private Label header;
        private Label label2;
    }
}