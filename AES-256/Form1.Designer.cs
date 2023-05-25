using System;
using System.Windows.Forms;

namespace AES_256
{
    partial class Form1
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

            plaintextTextBox = new TextBox();
            plaintextTextBox.Location = new System.Drawing.Point(10, 10);
            plaintextTextBox.Size = new System.Drawing.Size(300, 20);

            encryptedTextBox = new TextBox();
            encryptedTextBox.Location = new System.Drawing.Point(10, 40);
            encryptedTextBox.Size = new System.Drawing.Size(300, 20);
            encryptedTextBox.ReadOnly = true;

            decryptedTextBox = new TextBox();
            decryptedTextBox.Location = new System.Drawing.Point(10, 70);
            decryptedTextBox.Size = new System.Drawing.Size(300, 20);
            decryptedTextBox.ReadOnly = true;

            encryptButton = new Button();
            encryptButton.Location = new System.Drawing.Point(10, 100);
            encryptButton.Size = new System.Drawing.Size(100, 30);
            encryptButton.Text = "Encrypt";
            encryptButton.Click += EncryptButton_Click;

            decryptButton = new Button();
            decryptButton.Location = new System.Drawing.Point(120, 100);
            decryptButton.Size = new System.Drawing.Size(100, 30);
            decryptButton.Text = "Decrypt";
            decryptButton.Click += DecryptButton_Click;

            this.Controls.Add(plaintextTextBox);
            this.Controls.Add(encryptedTextBox);
            this.Controls.Add(decryptedTextBox);
            this.Controls.Add(encryptButton);
            this.Controls.Add(decryptButton);

            this.Size = new System.Drawing.Size(330, 150);
            this.Text = "AES Encryption/Decryption";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 412);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            string encryptedText = encryptedTextBox.Text;

            if (!string.IsNullOrEmpty(encryptedText))
            {
                try
                {
                    byte[] encryptedData = Convert.FromBase64String(encryptedText);
                    string decryptedText = AesEncryption.Decrypt(encryptedData);
                    decryptedTextBox.Text = decryptedText;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid encrypted data. Please enter a valid Base64 string.");
                }
            }
            else
            {
                MessageBox.Show("Please enter the encrypted data to decrypt.");
            }
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            string plaintext = plaintextTextBox.Text;

            if (!string.IsNullOrEmpty(plaintext))
            {
                byte[] encryptedData = AesEncryption.Encrypt(plaintext);
                string encryptedText = Convert.ToBase64String(encryptedData);
                encryptedTextBox.Text = encryptedText;
                decryptedTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please enter the plaintext to encrypt.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

