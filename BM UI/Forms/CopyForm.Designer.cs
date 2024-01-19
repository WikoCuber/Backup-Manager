namespace BM_UI.Forms
{
    partial class CopyForm
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
            selectDirectoryDialog = new FolderBrowserDialog();
            selectDirectoryButton = new Button();
            directoryPathLabel = new Label();
            filesCountLabel = new Label();
            filesCountTextLabel = new Label();
            filesProgressBar = new ProgressBar();
            sizeProgressBar = new ProgressBar();
            sizeLabel = new Label();
            sizeTextLabel = new Label();
            startButton = new Button();
            cancelButton = new Button();
            currentFileTextLabel = new Label();
            currentFileLabel = new Label();
            SuspendLayout();
            // 
            // selectDirectoryButton
            // 
            selectDirectoryButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            selectDirectoryButton.Location = new Point(14, 14);
            selectDirectoryButton.Margin = new Padding(4, 3, 4, 3);
            selectDirectoryButton.Name = "selectDirectoryButton";
            selectDirectoryButton.Size = new Size(167, 40);
            selectDirectoryButton.TabIndex = 2;
            selectDirectoryButton.Text = "Wybierz folder";
            selectDirectoryButton.UseVisualStyleBackColor = true;
            selectDirectoryButton.Click += selectDirectoryButton_Click;
            // 
            // directoryPathLabel
            // 
            directoryPathLabel.AutoSize = true;
            directoryPathLabel.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            directoryPathLabel.Location = new Point(188, 17);
            directoryPathLabel.Margin = new Padding(4, 0, 4, 0);
            directoryPathLabel.Name = "directoryPathLabel";
            directoryPathLabel.Size = new Size(492, 25);
            directoryPathLabel.TabIndex = 4;
            directoryPathLabel.Text = "Nie wybrano jeszcze żadnego folderu docelowego";
            // 
            // filesCountLabel
            // 
            filesCountLabel.AutoSize = true;
            filesCountLabel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            filesCountLabel.Location = new Point(576, 60);
            filesCountLabel.Margin = new Padding(0, 0, 0, 0);
            filesCountLabel.Name = "filesCountLabel";
            filesCountLabel.Size = new Size(0, 24);
            filesCountLabel.TabIndex = 7;
            filesCountLabel.Visible = false;
            // 
            // filesCountTextLabel
            // 
            filesCountTextLabel.AutoSize = true;
            filesCountTextLabel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            filesCountTextLabel.Location = new Point(528, 60);
            filesCountTextLabel.Margin = new Padding(0, 0, 0, 0);
            filesCountTextLabel.Name = "filesCountTextLabel";
            filesCountTextLabel.Size = new Size(48, 24);
            filesCountTextLabel.TabIndex = 6;
            filesCountTextLabel.Text = "Pliki:";
            filesCountTextLabel.Visible = false;
            // 
            // filesProgressBar
            // 
            filesProgressBar.Location = new Point(14, 61);
            filesProgressBar.Margin = new Padding(4, 3, 4, 3);
            filesProgressBar.MarqueeAnimationSpeed = 1000;
            filesProgressBar.Maximum = 1000;
            filesProgressBar.Name = "filesProgressBar";
            filesProgressBar.Size = new Size(507, 27);
            filesProgressBar.TabIndex = 5;
            filesProgressBar.Visible = false;
            // 
            // sizeProgressBar
            // 
            sizeProgressBar.Location = new Point(14, 95);
            sizeProgressBar.Margin = new Padding(4, 3, 4, 3);
            sizeProgressBar.MarqueeAnimationSpeed = 1000;
            sizeProgressBar.Maximum = 1000;
            sizeProgressBar.Name = "sizeProgressBar";
            sizeProgressBar.Size = new Size(507, 27);
            sizeProgressBar.TabIndex = 8;
            sizeProgressBar.Visible = false;
            // 
            // sizeLabel
            // 
            sizeLabel.AutoSize = true;
            sizeLabel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            sizeLabel.Location = new Point(612, 93);
            sizeLabel.Margin = new Padding(0, 0, 0, 0);
            sizeLabel.Name = "sizeLabel";
            sizeLabel.Size = new Size(0, 24);
            sizeLabel.TabIndex = 10;
            sizeLabel.Visible = false;
            // 
            // sizeTextLabel
            // 
            sizeTextLabel.AutoSize = true;
            sizeTextLabel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            sizeTextLabel.Location = new Point(528, 93);
            sizeTextLabel.Margin = new Padding(0, 0, 0, 0);
            sizeTextLabel.Name = "sizeTextLabel";
            sizeTextLabel.Size = new Size(84, 24);
            sizeTextLabel.TabIndex = 9;
            sizeTextLabel.Text = "Rozmiar:";
            sizeTextLabel.Visible = false;
            // 
            // startButton
            // 
            startButton.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            startButton.Location = new Point(290, 128);
            startButton.Margin = new Padding(4, 3, 4, 3);
            startButton.Name = "startButton";
            startButton.Size = new Size(115, 42);
            startButton.TabIndex = 11;
            startButton.Text = "Zacznij";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Enabled = false;
            cancelButton.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            cancelButton.Location = new Point(413, 128);
            cancelButton.Margin = new Padding(4, 3, 4, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(113, 42);
            cancelButton.TabIndex = 13;
            cancelButton.Text = "Anuluj";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // currentFileTextLabel
            // 
            currentFileTextLabel.AutoSize = true;
            currentFileTextLabel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            currentFileTextLabel.Location = new Point(528, 128);
            currentFileTextLabel.Margin = new Padding(0, 0, 0, 0);
            currentFileTextLabel.Name = "currentFileTextLabel";
            currentFileTextLabel.Size = new Size(119, 24);
            currentFileTextLabel.TabIndex = 14;
            currentFileTextLabel.Text = "Aktualny plik:";
            currentFileTextLabel.Visible = false;
            // 
            // currentFileLabel
            // 
            currentFileLabel.AutoSize = true;
            currentFileLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            currentFileLabel.Location = new Point(647, 134);
            currentFileLabel.Margin = new Padding(0, 0, 0, 0);
            currentFileLabel.Name = "currentFileLabel";
            currentFileLabel.Size = new Size(0, 15);
            currentFileLabel.TabIndex = 16;
            currentFileLabel.Visible = false;
            // 
            // CopyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 187);
            Controls.Add(currentFileLabel);
            Controls.Add(currentFileTextLabel);
            Controls.Add(cancelButton);
            Controls.Add(startButton);
            Controls.Add(sizeLabel);
            Controls.Add(sizeTextLabel);
            Controls.Add(sizeProgressBar);
            Controls.Add(filesCountLabel);
            Controls.Add(filesCountTextLabel);
            Controls.Add(filesProgressBar);
            Controls.Add(directoryPathLabel);
            Controls.Add(selectDirectoryButton);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(10280, 226);
            MinimumSize = new Size(1135, 226);
            Name = "CopyForm";
            Text = "Wykonaj kopię";
            FormClosing += CopyForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog selectDirectoryDialog;
        private System.Windows.Forms.Button selectDirectoryButton;
        private System.Windows.Forms.Label directoryPathLabel;
        private System.Windows.Forms.Label filesCountLabel;
        private System.Windows.Forms.Label filesCountTextLabel;
        private System.Windows.Forms.ProgressBar filesProgressBar;
        private System.Windows.Forms.ProgressBar sizeProgressBar;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label sizeTextLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button cancelButton;
        private Label currentFileTextLabel;
        private Label currentFileLabel;
    }
}