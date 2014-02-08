﻿namespace LicenseUtils.Controls
{
    partial class WorkPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelNoLicense = new System.Windows.Forms.Label();
            this.labelLicense = new DotNetUtils.Controls.LinkLabel2();
            this.textBoxAuthors = new DotNetUtils.Controls.SelectableLabel();
            this.labelProject = new DotNetUtils.Controls.HyperlinkLabel();
            this.labelSource = new DotNetUtils.Controls.HyperlinkLabel();
            this.labelPackage = new DotNetUtils.Controls.HyperlinkLabel();
            this.labelArticle = new DotNetUtils.Controls.HyperlinkLabel();
            this.labelWorkName = new DotNetUtils.Controls.SelectableLabel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.labelProject);
            this.flowLayoutPanel1.Controls.Add(this.labelSource);
            this.flowLayoutPanel1.Controls.Add(this.labelPackage);
            this.flowLayoutPanel1.Controls.Add(this.labelArticle);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(406, 20);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.labelLicense);
            this.flowLayoutPanel2.Controls.Add(this.labelNoLicense);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 166);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(565, 24);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // labelNoLicense
            // 
            this.labelNoLicense.AutoSize = true;
            this.labelNoLicense.Location = new System.Drawing.Point(54, 3);
            this.labelNoLicense.Margin = new System.Windows.Forms.Padding(3);
            this.labelNoLicense.Name = "labelNoLicense";
            this.labelNoLicense.Size = new System.Drawing.Size(57, 13);
            this.labelNoLicense.TabIndex = 3;
            this.labelNoLicense.Text = "No license";
            // 
            // labelLicense
            // 
            this.labelLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLicense.DisabledColor = System.Drawing.Color.Empty;
            this.labelLicense.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelLicense.HoverColor = System.Drawing.Color.Empty;
            this.labelLicense.Location = new System.Drawing.Point(3, 3);
            this.labelLicense.Name = "labelLicense";
            this.labelLicense.RegularColor = System.Drawing.Color.Empty;
            this.labelLicense.Size = new System.Drawing.Size(45, 14);
            this.labelLicense.TabIndex = 2;
            this.labelLicense.Text = "License";
            // 
            // textBoxAuthors
            // 
            this.textBoxAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAuthors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAuthors.Location = new System.Drawing.Point(7, 54);
            this.textBoxAuthors.Multiline = true;
            this.textBoxAuthors.Name = "textBoxAuthors";
            this.textBoxAuthors.ReadOnly = true;
            this.textBoxAuthors.Size = new System.Drawing.Size(403, 106);
            this.textBoxAuthors.TabIndex = 3;
            this.textBoxAuthors.Text = "(C) 2014 Authors";
            // 
            // labelProject
            // 
            this.labelProject.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelProject.DisabledColor = System.Drawing.Color.Empty;
            this.labelProject.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelProject.HoverColor = System.Drawing.Color.Empty;
            this.labelProject.Location = new System.Drawing.Point(3, 3);
            this.labelProject.Name = "labelProject";
            this.labelProject.RegularColor = System.Drawing.Color.Empty;
            this.labelProject.Size = new System.Drawing.Size(96, 14);
            this.labelProject.TabIndex = 0;
            this.labelProject.Text = "Project Homepage";
            // 
            // labelSource
            // 
            this.labelSource.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelSource.DisabledColor = System.Drawing.Color.Empty;
            this.labelSource.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelSource.HoverColor = System.Drawing.Color.Empty;
            this.labelSource.Location = new System.Drawing.Point(105, 3);
            this.labelSource.Name = "labelSource";
            this.labelSource.RegularColor = System.Drawing.Color.Empty;
            this.labelSource.Size = new System.Drawing.Size(70, 14);
            this.labelSource.TabIndex = 1;
            this.labelSource.Text = "Source Code";
            // 
            // labelPackage
            // 
            this.labelPackage.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelPackage.DisabledColor = System.Drawing.Color.Empty;
            this.labelPackage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelPackage.HoverColor = System.Drawing.Color.Empty;
            this.labelPackage.Location = new System.Drawing.Point(181, 3);
            this.labelPackage.Name = "labelPackage";
            this.labelPackage.RegularColor = System.Drawing.Color.Empty;
            this.labelPackage.Size = new System.Drawing.Size(85, 14);
            this.labelPackage.TabIndex = 2;
            this.labelPackage.Text = "NuGet Package";
            // 
            // labelArticle
            // 
            this.labelArticle.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelArticle.DisabledColor = System.Drawing.Color.Empty;
            this.labelArticle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelArticle.HoverColor = System.Drawing.Color.Empty;
            this.labelArticle.Location = new System.Drawing.Point(272, 3);
            this.labelArticle.Name = "labelArticle";
            this.labelArticle.RegularColor = System.Drawing.Color.Empty;
            this.labelArticle.Size = new System.Drawing.Size(37, 14);
            this.labelArticle.TabIndex = 3;
            this.labelArticle.Text = "Article";
            // 
            // labelWorkName
            // 
            this.labelWorkName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWorkName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelWorkName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorkName.Location = new System.Drawing.Point(4, 4);
            this.labelWorkName.Name = "labelWorkName";
            this.labelWorkName.ReadOnly = true;
            this.labelWorkName.Size = new System.Drawing.Size(406, 16);
            this.labelWorkName.TabIndex = 0;
            this.labelWorkName.Text = "Work Name";
            // 
            // WorkPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.textBoxAuthors);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelWorkName);
            this.Name = "WorkPanel";
            this.Size = new System.Drawing.Size(413, 193);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DotNetUtils.Controls.SelectableLabel labelWorkName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DotNetUtils.Controls.HyperlinkLabel labelProject;
        private DotNetUtils.Controls.HyperlinkLabel labelSource;
        private DotNetUtils.Controls.HyperlinkLabel labelPackage;
        private DotNetUtils.Controls.HyperlinkLabel labelArticle;
        private DotNetUtils.Controls.SelectableLabel textBoxAuthors;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private DotNetUtils.Controls.LinkLabel2 labelLicense;
        private System.Windows.Forms.Label labelNoLicense;
    }
}
