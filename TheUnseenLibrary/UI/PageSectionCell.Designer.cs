namespace TheUnseenLibrary.UI
{
    partial class PageSectionCell
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
            this.flwLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flwLayoutPanel
            // 
            this.flwLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flwLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flwLayoutPanel.Name = "flwLayoutPanel";
            this.flwLayoutPanel.Size = new System.Drawing.Size(556, 530);
            this.flwLayoutPanel.TabIndex = 0;
            // 
            // PageSectionCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flwLayoutPanel);
            this.Name = "PageSectionCell";
            this.Size = new System.Drawing.Size(556, 530);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flwLayoutPanel;
    }
}
