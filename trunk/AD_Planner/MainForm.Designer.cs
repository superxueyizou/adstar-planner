namespace AD_Planner
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
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.btnSetGoal = new System.Windows.Forms.Button();
            this.btnSetStart = new System.Windows.Forms.Button();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.btnToggleDraw = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.splitBody = new System.Windows.Forms.SplitContainer();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.splitBody.Panel1.SuspendLayout();
            this.splitBody.Panel2.SuspendLayout();
            this.splitBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.IsSplitterFixed = true;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitMain.Panel1.Controls.Add(this.btnSetGoal);
            this.splitMain.Panel1.Controls.Add(this.btnSetStart);
            this.splitMain.Panel1.Controls.Add(this.nudHeight);
            this.splitMain.Panel1.Controls.Add(this.nudWidth);
            this.splitMain.Panel1.Controls.Add(this.btnToggleDraw);
            this.splitMain.Panel1.Controls.Add(this.btnSaveConfig);
            this.splitMain.Panel1.Controls.Add(this.btnLoadConfig);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitBody);
            this.splitMain.Size = new System.Drawing.Size(714, 516);
            this.splitMain.SplitterDistance = 47;
            this.splitMain.SplitterWidth = 1;
            this.splitMain.TabIndex = 0;
            // 
            // btnSetGoal
            // 
            this.btnSetGoal.Location = new System.Drawing.Point(450, 12);
            this.btnSetGoal.Name = "btnSetGoal";
            this.btnSetGoal.Size = new System.Drawing.Size(75, 23);
            this.btnSetGoal.TabIndex = 2;
            this.btnSetGoal.Text = "Set Goal";
            this.btnSetGoal.UseVisualStyleBackColor = true;
            this.btnSetGoal.Click += new System.EventHandler(this.btnSetGoal_Click);
            // 
            // btnSetStart
            // 
            this.btnSetStart.Location = new System.Drawing.Point(369, 12);
            this.btnSetStart.Name = "btnSetStart";
            this.btnSetStart.Size = new System.Drawing.Size(75, 23);
            this.btnSetStart.TabIndex = 2;
            this.btnSetStart.Text = "Set Start";
            this.btnSetStart.UseVisualStyleBackColor = true;
            this.btnSetStart.Click += new System.EventHandler(this.btnSetStart_Click);
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(329, 13);
            this.nudHeight.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(34, 20);
            this.nudHeight.TabIndex = 0;
            this.nudHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.ValueChanged += new System.EventHandler(this.nudHeight_ValueChanged);
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(289, 13);
            this.nudWidth.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(34, 20);
            this.nudWidth.TabIndex = 0;
            this.nudWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.nudWidth_ValueChanged);
            // 
            // btnToggleDraw
            // 
            this.btnToggleDraw.Location = new System.Drawing.Point(174, 12);
            this.btnToggleDraw.Name = "btnToggleDraw";
            this.btnToggleDraw.Size = new System.Drawing.Size(109, 23);
            this.btnToggleDraw.TabIndex = 1;
            this.btnToggleDraw.Text = "Toggle Draw Mode";
            this.btnToggleDraw.UseVisualStyleBackColor = true;
            this.btnToggleDraw.Click += new System.EventHandler(this.btnToggleDraw_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(93, 12);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSaveConfig.TabIndex = 0;
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Location = new System.Drawing.Point(12, 12);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(75, 23);
            this.btnLoadConfig.TabIndex = 1;
            this.btnLoadConfig.Text = "Load Config";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // splitBody
            // 
            this.splitBody.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBody.Location = new System.Drawing.Point(0, 0);
            this.splitBody.Name = "splitBody";
            // 
            // splitBody.Panel1
            // 
            this.splitBody.Panel1.Controls.Add(this.pnlGrid);
            // 
            // splitBody.Panel2
            // 
            this.splitBody.Panel2.Controls.Add(this.txtConsole);
            this.splitBody.Size = new System.Drawing.Size(714, 468);
            this.splitBody.SplitterDistance = 366;
            this.splitBody.SplitterWidth = 3;
            this.splitBody.TabIndex = 1;
            this.splitBody.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitBody_SplitterMoved);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.SystemColors.Control;
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(366, 468);
            this.pnlGrid.TabIndex = 0;
            this.pnlGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGrid_Paint);
            this.pnlGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlGrid_MouseMove);
            this.pnlGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlGrid_MouseDown);
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Font = new System.Drawing.Font("Courier New", 9F);
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(345, 468);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.Text = "";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            this.ofd.RestoreDirectory = true;
            // 
            // sfd
            // 
            this.sfd.RestoreDirectory = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 516);
            this.Controls.Add(this.splitMain);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.Text = "AD* Planner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.splitBody.Panel1.ResumeLayout(false);
            this.splitBody.Panel2.ResumeLayout(false);
            this.splitBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button btnToggleDraw;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Button btnSetGoal;
        private System.Windows.Forms.Button btnSetStart;
        private System.Windows.Forms.SplitContainer splitBody;
        private System.Windows.Forms.RichTextBox txtConsole;
    }
}

