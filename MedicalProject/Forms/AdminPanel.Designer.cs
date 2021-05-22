
namespace MedicalProject
{
    partial class AdminPanel
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
            this.ChangeUserButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.producerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicalFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.substanseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preparationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChangeUserButton
            // 
            this.ChangeUserButton.Location = new System.Drawing.Point(625, 12);
            this.ChangeUserButton.Name = "ChangeUserButton";
            this.ChangeUserButton.Size = new System.Drawing.Size(163, 34);
            this.ChangeUserButton.TabIndex = 0;
            this.ChangeUserButton.Text = "Logout";
            this.ChangeUserButton.UseVisualStyleBackColor = true;
            this.ChangeUserButton.Click += new System.EventHandler(this.ChangeUserButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.fieldsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(14, 24);
            // 
            // fieldsToolStripMenuItem
            // 
            this.fieldsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.producerToolStripMenuItem,
            this.medicalFormsToolStripMenuItem,
            this.diToolStripMenuItem,
            this.substanseToolStripMenuItem,
            this.preparationToolStripMenuItem,
            this.licenseToolStripMenuItem});
            this.fieldsToolStripMenuItem.Name = "fieldsToolStripMenuItem";
            this.fieldsToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.fieldsToolStripMenuItem.Text = "Fields";
            // 
            // producerToolStripMenuItem
            // 
            this.producerToolStripMenuItem.Name = "producerToolStripMenuItem";
            this.producerToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.producerToolStripMenuItem.Text = "Producer";
            // 
            // medicalFormsToolStripMenuItem
            // 
            this.medicalFormsToolStripMenuItem.Name = "medicalFormsToolStripMenuItem";
            this.medicalFormsToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.medicalFormsToolStripMenuItem.Text = "Medical Forms";
            // 
            // diToolStripMenuItem
            // 
            this.diToolStripMenuItem.Name = "diToolStripMenuItem";
            this.diToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.diToolStripMenuItem.Text = "Disease";
            // 
            // substanseToolStripMenuItem
            // 
            this.substanseToolStripMenuItem.Name = "substanseToolStripMenuItem";
            this.substanseToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.substanseToolStripMenuItem.Text = "Substance";
            // 
            // preparationToolStripMenuItem
            // 
            this.preparationToolStripMenuItem.Name = "preparationToolStripMenuItem";
            this.preparationToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.preparationToolStripMenuItem.Text = "Preparation";
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.licenseToolStripMenuItem.Text = "License";
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChangeUserButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminPanel_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChangeUserButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fieldsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem producerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicalFormsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem substanseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preparationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
    }
}