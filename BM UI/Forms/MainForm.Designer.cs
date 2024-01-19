namespace BM_UI.Forms
{
    partial class MainForm
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
            elementsListBox = new ListBox();
            selectDirectoryDialog = new FolderBrowserDialog();
            selectDirectoryButton = new Button();
            progressBar = new ProgressBar();
            elementsCountLabel = new Label();
            elementsTextLabel = new Label();
            titleLabel = new Label();
            makeCopyButton = new Button();
            selectFileButton = new Button();
            selectFileDialog = new OpenFileDialog();
            checkFileSizeCheckBox = new CheckBox();
            subTitleLabel = new Label();
            subelementsListBox = new CheckedListBox();
            selectAllButtton = new Button();
            unselectAllButton = new Button();
            elementNotExistLabel = new Label();
            deleteAdditionalFileCheckBox = new CheckBox();
            whiteListCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // elementsListBox
            // 
            elementsListBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            elementsListBox.FormattingEnabled = true;
            elementsListBox.ItemHeight = 20;
            elementsListBox.Location = new Point(19, 44);
            elementsListBox.Margin = new Padding(4, 3, 4, 3);
            elementsListBox.Name = "elementsListBox";
            elementsListBox.Size = new Size(828, 244);
            elementsListBox.TabIndex = 0;
            elementsListBox.SelectedIndexChanged += elementsListBox_SelectedIndexChanged;
            elementsListBox.KeyDown += elementsListBox_KeyDown;
            // 
            // selectDirectoryButton
            // 
            selectDirectoryButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            selectDirectoryButton.Location = new Point(19, 327);
            selectDirectoryButton.Margin = new Padding(4, 3, 4, 3);
            selectDirectoryButton.Name = "selectDirectoryButton";
            selectDirectoryButton.Size = new Size(149, 48);
            selectDirectoryButton.TabIndex = 1;
            selectDirectoryButton.Text = "Wybierz folder";
            selectDirectoryButton.UseVisualStyleBackColor = true;
            selectDirectoryButton.Click += selectDirectoryButton_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(248, 324);
            progressBar.Margin = new Padding(4, 3, 4, 3);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(189, 27);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 2;
            progressBar.Visible = false;
            // 
            // elementsCountLabel
            // 
            elementsCountLabel.AutoSize = true;
            elementsCountLabel.Font = new Font("Microsoft Sans Serif", 12F);
            elementsCountLabel.Location = new Point(600, 324);
            elementsCountLabel.Margin = new Padding(0, 0, 0, 0);
            elementsCountLabel.Name = "elementsCountLabel";
            elementsCountLabel.Size = new Size(0, 20);
            elementsCountLabel.TabIndex = 4;
            elementsCountLabel.Visible = false;
            // 
            // elementsTextLabel
            // 
            elementsTextLabel.AutoSize = true;
            elementsTextLabel.Font = new Font("Microsoft Sans Serif", 12F);
            elementsTextLabel.Location = new Point(444, 324);
            elementsTextLabel.Margin = new Padding(0, 0, 0, 0);
            elementsTextLabel.Name = "elementsTextLabel";
            elementsTextLabel.Size = new Size(156, 20);
            elementsTextLabel.TabIndex = 3;
            elementsTextLabel.Text = "Przeskanowane pliki:";
            elementsTextLabel.Visible = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            titleLabel.Location = new Point(266, 10);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(256, 25);
            titleLabel.TabIndex = 5;
            titleLabel.Text = "Elementy do skopiowania";
            // 
            // makeCopyButton
            // 
            makeCopyButton.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            makeCopyButton.Location = new Point(327, 382);
            makeCopyButton.Margin = new Padding(4, 3, 4, 3);
            makeCopyButton.Name = "makeCopyButton";
            makeCopyButton.Size = new Size(198, 74);
            makeCopyButton.TabIndex = 6;
            makeCopyButton.Text = "Wykonaj kopię";
            makeCopyButton.UseVisualStyleBackColor = true;
            makeCopyButton.Click += makeCopyButton_Click;
            // 
            // selectFileButton
            // 
            selectFileButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            selectFileButton.Location = new Point(18, 382);
            selectFileButton.Margin = new Padding(4, 3, 4, 3);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new Size(149, 50);
            selectFileButton.TabIndex = 7;
            selectFileButton.Text = "Wybierz pliki";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += selectFileButton_Click;
            // 
            // selectFileDialog
            // 
            selectFileDialog.FileName = "openFileDialog1";
            // 
            // checkFileSizeCheckBox
            // 
            checkFileSizeCheckBox.AutoSize = true;
            checkFileSizeCheckBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            checkFileSizeCheckBox.Location = new Point(18, 460);
            checkFileSizeCheckBox.Margin = new Padding(4, 3, 4, 3);
            checkFileSizeCheckBox.Name = "checkFileSizeCheckBox";
            checkFileSizeCheckBox.Size = new Size(205, 24);
            checkFileSizeCheckBox.TabIndex = 8;
            checkFileSizeCheckBox.Text = "Sprawdzaj rozmiar plików";
            checkFileSizeCheckBox.UseVisualStyleBackColor = true;
            checkFileSizeCheckBox.CheckedChanged += fileCheckingCheckBox_CheckedChanged;
            // 
            // subTitleLabel
            // 
            subTitleLabel.AutoSize = true;
            subTitleLabel.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            subTitleLabel.Location = new Point(973, 12);
            subTitleLabel.Margin = new Padding(4, 0, 4, 0);
            subTitleLabel.Name = "subTitleLabel";
            subTitleLabel.Size = new Size(137, 25);
            subTitleLabel.TabIndex = 10;
            subTitleLabel.Text = "Podelementy";
            // 
            // subelementsListBox
            // 
            subelementsListBox.CheckOnClick = true;
            subelementsListBox.FormattingEnabled = true;
            subelementsListBox.Location = new Point(854, 44);
            subelementsListBox.Margin = new Padding(4, 3, 4, 3);
            subelementsListBox.Name = "subelementsListBox";
            subelementsListBox.Size = new Size(374, 400);
            subelementsListBox.TabIndex = 11;
            subelementsListBox.ItemCheck += subelementsListBox_ItemCheck;
            // 
            // selectAllButtton
            // 
            selectAllButtton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            selectAllButtton.Location = new Point(854, 452);
            selectAllButtton.Margin = new Padding(4, 3, 4, 3);
            selectAllButtton.Name = "selectAllButtton";
            selectAllButtton.Size = new Size(186, 36);
            selectAllButtton.TabIndex = 12;
            selectAllButtton.Text = "Zaznacz wszystko";
            selectAllButtton.UseVisualStyleBackColor = true;
            selectAllButtton.Click += selectAllButtton_Click;
            // 
            // unselectAllButton
            // 
            unselectAllButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            unselectAllButton.Location = new Point(1043, 452);
            unselectAllButton.Margin = new Padding(4, 3, 4, 3);
            unselectAllButton.Name = "unselectAllButton";
            unselectAllButton.Size = new Size(186, 36);
            unselectAllButton.TabIndex = 13;
            unselectAllButton.Text = "Odznacz wszystko";
            unselectAllButton.UseVisualStyleBackColor = true;
            unselectAllButton.Click += unsellectAllButton_Click;
            // 
            // elementNotExistLabel
            // 
            elementNotExistLabel.AutoSize = true;
            elementNotExistLabel.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            elementNotExistLabel.Location = new Point(883, 186);
            elementNotExistLabel.Margin = new Padding(4, 0, 4, 0);
            elementNotExistLabel.Name = "elementNotExistLabel";
            elementNotExistLabel.Size = new Size(313, 39);
            elementNotExistLabel.TabIndex = 14;
            elementNotExistLabel.Text = "Ścieżka nie istnieje";
            elementNotExistLabel.Visible = false;
            // 
            // deleteAdditionalFileCheckBox
            // 
            deleteAdditionalFileCheckBox.AutoSize = true;
            deleteAdditionalFileCheckBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            deleteAdditionalFileCheckBox.Location = new Point(264, 460);
            deleteAdditionalFileCheckBox.Margin = new Padding(4, 3, 4, 3);
            deleteAdditionalFileCheckBox.Name = "deleteAdditionalFileCheckBox";
            deleteAdditionalFileCheckBox.Size = new Size(219, 24);
            deleteAdditionalFileCheckBox.TabIndex = 15;
            deleteAdditionalFileCheckBox.Text = "Usuwaj pliki z innych źródeł";
            deleteAdditionalFileCheckBox.UseVisualStyleBackColor = true;
            deleteAdditionalFileCheckBox.CheckedChanged += deleteAdditionalFileCheckBox_CheckedChanged;
            // 
            // whiteListCheckBox
            // 
            whiteListCheckBox.AutoSize = true;
            whiteListCheckBox.Enabled = false;
            whiteListCheckBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            whiteListCheckBox.Location = new Point(746, 459);
            whiteListCheckBox.Margin = new Padding(4, 3, 4, 3);
            whiteListCheckBox.Name = "whiteListCheckBox";
            whiteListCheckBox.Size = new Size(101, 24);
            whiteListCheckBox.TabIndex = 16;
            whiteListCheckBox.Text = "White lista";
            whiteListCheckBox.UseVisualStyleBackColor = true;
            whiteListCheckBox.CheckedChanged += whiteListCheckBox_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 502);
            Controls.Add(whiteListCheckBox);
            Controls.Add(deleteAdditionalFileCheckBox);
            Controls.Add(elementNotExistLabel);
            Controls.Add(unselectAllButton);
            Controls.Add(selectAllButtton);
            Controls.Add(subelementsListBox);
            Controls.Add(subTitleLabel);
            Controls.Add(checkFileSizeCheckBox);
            Controls.Add(selectFileButton);
            Controls.Add(makeCopyButton);
            Controls.Add(titleLabel);
            Controls.Add(elementsCountLabel);
            Controls.Add(elementsTextLabel);
            Controls.Add(progressBar);
            Controls.Add(selectDirectoryButton);
            Controls.Add(elementsListBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Backup Menager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox elementsListBox;
        private System.Windows.Forms.FolderBrowserDialog selectDirectoryDialog;
        private System.Windows.Forms.Button selectDirectoryButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label elementsCountLabel;
        private System.Windows.Forms.Label elementsTextLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button makeCopyButton;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.OpenFileDialog selectFileDialog;
        private System.Windows.Forms.CheckBox checkFileSizeCheckBox;
        private System.Windows.Forms.Label subTitleLabel;
        private System.Windows.Forms.CheckedListBox subelementsListBox;
        private System.Windows.Forms.Button selectAllButtton;
        private System.Windows.Forms.Button unselectAllButton;
        private System.Windows.Forms.Label elementNotExistLabel;
        private System.Windows.Forms.CheckBox deleteAdditionalFileCheckBox;
        private CheckBox whiteListCheckBox;
    }
}

