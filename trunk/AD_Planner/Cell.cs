using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AD_Planner
{
    public class Cell
    {
        protected int m_X;
        protected int m_Y;
        private CellType m_Type = CellType.Empty;
        protected static Font m_Font = new Font("Arial", 8, FontStyle.Bold);

        public int X
        {
            get { return m_X; }
            set { m_X = value; }
        }
        public int Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }
        public CellType Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }
        
        public Cell(int x, int y)
        {
            m_X = x;
            m_Y = y;
        }
        public Cell(int x, int y, CellType type)
            : this(x, y)
        {
            Type = type;
        }

        public virtual void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.DimGray);
            SolidBrush brush = new SolidBrush(Color.White);
            SolidBrush textBrush = new SolidBrush(Color.Black);

            switch (Type)
            {
                case CellType.Empty:
                    brush.Color = Color.White;
                    textBrush.Color = Color.Gray;
                    break;
                case CellType.Obstacle:
                    brush.Color = Color.Black;
                    textBrush.Color = Color.Gray;
                    break;
                case CellType.Path:
                    brush.Color = Color.LightGray;
                    textBrush.Color = Color.DimGray;
                    break;
                case CellType.Start:
                    brush.Color = Color.Khaki;
                    textBrush.Color = Color.Gray;
                    break;
                case CellType.Goal:
                    brush.Color = Color.Red;
                    textBrush.Color = Color.LightGray;
                    break;
                default:
                    break;
            }

            g.FillRectangle(brush, Grid.X + m_X * Grid.Unit, Grid.Y + m_Y * Grid.Unit, Grid.Unit, Grid.Unit);
            g.DrawRectangle(pen, Grid.X + m_X * Grid.Unit, Grid.Y + m_Y * Grid.Unit, Grid.Unit, Grid.Unit);
            g.DrawString("" + (m_Y * Grid.Width + m_X), m_Font, textBrush, Grid.X + 3 + m_X * Grid.Unit, Grid.Y + 3 + m_Y * Grid.Unit);
            //g.DrawString(String.Format("{0},{1}", m_Y, m_X), m_Font, textBrush, Grid.X + 3 + m_X * Grid.Unit, Grid.Y + 3 + m_Y * Grid.Unit);
        }
        public override string ToString()
        {
            return String.Format("({0},{1})", m_Y, m_X);
        }
    }
}
