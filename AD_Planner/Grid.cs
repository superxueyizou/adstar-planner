using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AD_Planner
{
    public class Grid
    {
        private static List<List<Cell>> m_Grid = null;

        public static List<List<Cell>> Instance
        {
            get { return Grid.m_Grid; }
            set { Grid.m_Grid = value; }
        }

        private static float m_Unit;
        private static float m_AbsX;
        private static float m_AbsY;
        private static int m_Width;
        private static int m_Height;
        private static int m_Padding = 10;
        private static int m_MinUnitSize = 5;
        private static int m_MaxUnitSize = 80;
        private static Point startState = new Point(0, 0);
        private static Point goalState = new Point(0, 0);
        private static bool m_IsModified = false;

        public static bool IsModified
        {
            get { return Grid.m_IsModified; }
            set { Grid.m_IsModified = value; }
        }
        public static int Width
        {
            get { return Grid.m_Width; }
            set { Grid.m_Width = value; }
        }
        public static int Height
        {
            get { return Grid.m_Height; }
            set { Grid.m_Height = value; }
        }
        public static float Unit
        {
            get { return Grid.m_Unit; }
        }
        public static float X
        {
            get { return Grid.m_AbsX; }
            set { Grid.m_AbsX = value; }
        }
        public static float Y
        {
            get { return Grid.m_AbsY; }
            set { Grid.m_AbsY = value; }
        }
        public static Point StartState
        {
            get { return Grid.startState; }
            set { Grid.startState = value; }
        }
        public static Point GoalState
        {
            get { return Grid.goalState; }
            set { Grid.goalState = value; }
        }

        private Grid(int width, int height)
        {

        }

        public static void SetUnit(int width, int height)
        {
            int w = width - 2 * m_Padding;
            int h = height - 2 * m_Padding;
            m_Unit = Math.Min(Math.Max(Math.Min(w * 1.0f / Grid.Width, h * 1.0f / Grid.Height), m_MinUnitSize), m_MaxUnitSize);
            m_AbsX = w / 2 - m_Unit * (Grid.Width) / 2 + m_Padding;
            m_AbsY = h / 2 - m_Unit * (Grid.Height) / 2 + m_Padding;
        }

        public static void Draw(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.White);

            g.FillRectangle(brush, Grid.X, Grid.Y, Grid.Width * Grid.Unit, Grid.Height * Grid.Unit);

            for (int r = 0; r < Grid.Height; r++)
            {
                for (int c = 0; c < Grid.Width; c++)
                {
                    Grid.Instance[r][c].Draw(g);
                }
            }

            pen.Width = 2f;
            g.DrawRectangle(pen, Grid.X, Grid.Y, Grid.Width * Grid.Unit, Grid.Height * Grid.Unit);

            Robot.Instance.Draw(g);
        }

        public static void SetGoalCell(MouseEventArgs e)
        {
            int nx = 0;
            int ny = 0;

            FindCellInGrid(e, ref nx, ref ny);

            if (Grid.Instance[GoalState.Y][GoalState.X].Type == CellType.Goal)
                Grid.Instance[GoalState.Y][GoalState.X].Type = CellType.Empty;

            GoalState = new Point(nx, ny);
            Grid.Instance[GoalState.Y][GoalState.X].Type = CellType.Goal;

            MainForm.GridPanel.Invalidate();
            MainForm.Write(String.Format("Goal set to ({0}, {1})", GoalState.X, GoalState.Y));
        }
        public static void SetStartCell(MouseEventArgs e)
        {
            int nx = 0;
            int ny = 0;
            FindCellInGrid(e, ref nx, ref ny);
            if (Grid.Instance[StartState.Y][StartState.X].Type == CellType.Start)
                Grid.Instance[StartState.Y][StartState.X].Type = CellType.Empty;
            StartState = new Point(nx, ny);
            Grid.Instance[StartState.Y][StartState.X].Type = CellType.Start;

            MainForm.GridPanel.Invalidate();
            MainForm.Write(String.Format("Start set to ({0}, {1})", StartState.X, StartState.Y));
        }
        public static void ToggleGridCell(MouseEventArgs e)
        {
            int nx = 0;
            int ny = 0;
            FindCellInGrid(e, ref nx, ref ny);
            if (Grid.Instance[ny][nx].Type != CellType.Start && Grid.Instance[ny][nx].Type != CellType.Goal)
                Grid.Instance[ny][nx].Type = (e.Button == MouseButtons.Left) ? CellType.Obstacle : CellType.Empty;
            MainForm.GridPanel.Invalidate();
        }
        public static void FindCellInGrid(MouseEventArgs e, ref int nx, ref int ny)
        {
            int w = MainForm.GridPanel.Width - 2 * m_Padding;
            int h = MainForm.GridPanel.Height - 2 * m_Padding;
            float unit = Math.Min(Math.Max(Math.Min(w * 1.0f / Grid.Width, h * 1.0f / Grid.Height), m_MinUnitSize), m_MaxUnitSize);
            float x = w / 2 - unit * (Grid.Width) / 2 + m_Padding;
            float y = h / 2 - unit * (Grid.Height) / 2 + m_Padding;

            nx = (int)((e.X - x) / unit);
            ny = (int)((e.Y - y) / unit);
        }
    }
}
