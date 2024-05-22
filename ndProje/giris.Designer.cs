namespace ndProje
{
    partial class giris
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
            kullaniciText = new TextBox();
            sifreText = new TextBox();
            girisButton = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // kullaniciText
            // 
            kullaniciText.Location = new Point(281, 128);
            kullaniciText.Name = "kullaniciText";
            kullaniciText.Size = new Size(100, 23);
            kullaniciText.TabIndex = 0;
            // 
            // sifreText
            // 
            sifreText.Location = new Point(416, 128);
            sifreText.Name = "sifreText";
            sifreText.Size = new Size(100, 23);
            sifreText.TabIndex = 1;
            // 
            // girisButton
            // 
            girisButton.Location = new Point(362, 176);
            girisButton.Name = "girisButton";
            girisButton.Size = new Size(75, 23);
            girisButton.TabIndex = 2;
            girisButton.Text = "Giris";
            girisButton.UseVisualStyleBackColor = true;
            girisButton.Click += girisButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(291, 99);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 3;
            label1.Text = "Kullanici Adi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(445, 99);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 4;
            label2.Text = "Sifre";
            // 
            // giris
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(girisButton);
            Controls.Add(sifreText);
            Controls.Add(kullaniciText);
            Name = "giris";
            Text = "giris";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox kullaniciText;
        private TextBox sifreText;
        private Button girisButton;
        private Label label1;
        private Label label2;
    }
}