using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AD_Planner
{
    public enum CellType { Empty, Obstacle, Path, Start, Goal };

    public partial class MainForm : Form
    {
        private bool m_IsSetStart = false;
        private bool m_IsSetGoal = false;
        private bool m_IsModified = false;

        public MainForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        public bool IsModified
        {
            get { return m_IsModified; }
            set
            {
                m_IsModified = value;
                Grid.IsModified = value;
            }
        }

        #region Console RTB
        private static RichTextBox m_RTB;
        public static void Write(string str)
        {
            m_RTB.AppendText("> " + str + "\n");
        }
        #endregion

        #region Grid Panel Painting Code
        private bool m_IsDrawingGridMode = false;
        private void pnlGrid_Paint(object sender, PaintEventArgs e)
        {
            if (Grid.Instance == null) return;

            Grid.SetUnit(e.ClipRectangle.Width, e.ClipRectangle.Height);
            Grid.Draw(e.Graphics);
        }
        #endregion

        #region Grid Panel Mouse Event Handlers
        private static Panel m_GridPanel = null;
        public static Panel GridPanel
        {
            get
            {
                return m_GridPanel;
            }
        }

        private void pnlGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_IsDrawingGridMode && e.Button != MouseButtons.None)
            {
                Grid.ToggleGridCell(e);
            }
        }
        private void pnlGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None)
            {
                if (m_IsSetStart)
                {
                    Grid.SetStartCell(e);
                    m_IsSetStart = false;
                }
                else
                    if (m_IsSetGoal)
                    {
                        Grid.SetGoalCell(e);
                        m_IsSetGoal = false;
                    }
                    else
                        if (m_IsDrawingGridMode)
                        {
                            Grid.ToggleGridCell(e);
                        }
            }
        }
        #endregion

        #region Load/Save Congfiguration Code
        private void LoadConfigurationFile(string file)
        {
            StreamReader sr = new StreamReader(file);
            string str = "";
            string[] cells;

            str = sr.ReadLine();
            Grid.Width = int.Parse(str.Substring(str.IndexOf(":") + 1));
            nudWidth.Value = Grid.Width;
            str = sr.ReadLine();
            Grid.Height = int.Parse(str.Substring(str.IndexOf(":") + 1));
            nudHeight.Value = Grid.Height;

            str = sr.ReadLine().Trim();
            str = str.Substring(str.IndexOf(":") + 1);
            cells = str.Split(' ');
            Grid.StartState = new Point(int.Parse(cells[0]), int.Parse(cells[1]));

            str = sr.ReadLine().Trim();
            str = str.Substring(str.IndexOf(":") + 1);
            cells = str.Split(' ');
            Grid.GoalState = new Point(int.Parse(cells[0]), int.Parse(cells[1]));

            sr.ReadLine(); // "-grid:"

            Grid.Instance = new List<List<Cell>>(Grid.Height);

            for (int r = 0; r < Grid.Height; r++)
            {
                str = sr.ReadLine().Trim();
                cells = str.Split(' ');

                Grid.Instance.Add(new List<Cell>(Grid.Width));
                for (int c = 0; c < Grid.Width; c++)
                {
                    Grid.Instance[r].Add(new Cell(c, r, (CellType)int.Parse(cells[c])));
                }
            }
            sr.Close();
            pnlGrid.Invalidate();

            Write("Configuraion Loaded: " + ofd.FileName.Substring(ofd.FileName.LastIndexOf("\\") + 1));
            IsModified = false;

            //-------------------------------
            Planner.CreatePlanner("AStar", Grid.Instance);
            Planner.BeginPlanning();
        }
        private void SaveConfigurationFile(string file)
        {
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine("-width:{0}", Grid.Width);
            sw.WriteLine("-height:{0}", Grid.Height);
            sw.WriteLine("-start:{0} {1}", Grid.StartState.X, Grid.StartState.Y);
            sw.WriteLine("-goal:{0} {1}", Grid.GoalState.X, Grid.GoalState.Y);
            sw.WriteLine("-grid:");
            for (int r = 0; r < Grid.Height; r++)
            {
                for (int c = 0; c < Grid.Width; c++)
                {
                    sw.Write((int)Grid.Instance[r][c].Type + " ");
                }
                sw.WriteLine();
            }

            sw.Close();

            Write("Configuraion Saved: " + sfd.FileName.Substring(sfd.FileName.LastIndexOf("\\") + 1));
            IsModified = false;
        }
        #endregion

        #region From Event Handlers
        private void MainForm_Resize(object sender, EventArgs e)
        {
            pnlGrid.Invalidate();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsModified)
                return;

            DialogResult result = MessageBox.Show("Save the new configuration?", Text, MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Cancel)
                e.Cancel = true;
            else
                if (result == DialogResult.Yes)
                    btnSaveConfig.PerformClick();
        }
        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadConfigurationFile(ofd.FileName);
            }
        }
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveConfigurationFile(sfd.FileName);
            }
        }
        private void btnToggleDraw_Click(object sender, EventArgs e)
        {
            m_IsDrawingGridMode = !m_IsDrawingGridMode;
            EnableControls(!m_IsDrawingGridMode);
            ShowDrawingControls(m_IsDrawingGridMode);
        }
        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            IsModified = true;

            if (nudWidth.Value > Grid.Width)
            {
                List<List<Cell>> newGrid = new List<List<Cell>>(Grid.Height);

                for (int r = 0; r < Grid.Height; r++)
                {
                    newGrid.Add(new List<Cell>((int)nudWidth.Value));
                    for (int c = 0; c < nudWidth.Value; c++)
                        if (c < Grid.Width)
                            newGrid[r].Add(new Cell(c, r, Grid.Instance[r][c].Type));
                        else
                            newGrid[r].Add(new Cell(c, r));
                }

                Grid.Instance = newGrid;
            }
            Grid.Width = (int)nudWidth.Value;
            pnlGrid.Invalidate();
        }
        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {
            IsModified = true;

            if (nudHeight.Value > Grid.Height)
            {
                List<List<Cell>> newGrid = new List<List<Cell>>((int)nudHeight.Value);

                for (int r = 0; r < nudHeight.Value; r++)
                {
                    newGrid.Add(new List<Cell>(Grid.Width));
                    for (int c = 0; c < Grid.Width; c++)
                        if (r < Grid.Height)
                            newGrid[r].Add(new Cell(c, r, Grid.Instance[r][c].Type));
                        else
                            newGrid[r].Add(new Cell(c, r));
                }

                Grid.Instance = newGrid;
            }
            Grid.Height = (int)nudHeight.Value;
            pnlGrid.Invalidate();
        }
        private void btnSetStart_Click(object sender, EventArgs e)
        {
            IsModified = true;
            m_IsSetStart = true;
        }
        private void btnSetGoal_Click(object sender, EventArgs e)
        {
            IsModified = true;
            m_IsSetGoal = true;
        }
        private void splitBody_SplitterMoved(object sender, SplitterEventArgs e)
        {
            pnlGrid.Invalidate();
        }
        #endregion

        #region Helper Methods
        private void InitializeForm()
        {
            m_RTB = txtConsole;
            m_GridPanel = pnlGrid;

            ShowDrawingControls(false);

            Grid.Width = 1;
            Grid.Height = 1;

            Grid.Instance = new List<List<Cell>>(Grid.Height);

            for (int r = 0; r < Grid.Height; r++)
            {
                Grid.Instance.Add(new List<Cell>(Grid.Width));
                for (int c = 0; c < Grid.Width; c++)
                {
                    Grid.Instance[r].Add(new Cell(c, r));
                }
            }
        }
        private void EnableControls(bool enable)
        {
            btnLoadConfig.Enabled = enable;
            btnSaveConfig.Enabled = enable;
        }
        private void ShowDrawingControls(bool show)
        {
            nudWidth.Visible = show;
            nudHeight.Visible = show;
            btnSetGoal.Visible = show;
            btnSetStart.Visible = show;
        }
        #endregion
    }
}