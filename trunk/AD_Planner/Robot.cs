using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AD_Planner
{
    class Robot: Cell
    {
        private static Robot m_Robot = null;

        private static Robot Instance
        {
            get {
                if(m_Robot == null)
                    m_Robot = new Robot(Grid.StartState.X, Grid.StartState.Y);
                
                return Robot.m_Robot; 
            }
        }

        private Robot(int x, int y)
            :base(x, y)
        {

        }

        public new static int X
        {
            get
            {
                return Robot.Instance.X;
            }
            set
            {
                Instance.X = value;
            }
        }
        public static int Y
        {
            get
            {
                return Instance.Y;
            }
            set
            {
                Instance.Y = value;
            }
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);

            float unit = Grid.Unit * 3 / 4;
            float x = (Grid.X + m_X * Grid.Unit) + Grid.Unit / 2 - unit / 2;
            float y = (Grid.Y + m_Y * Grid.Unit) + Grid.Unit / 2 - unit / 2;

            //g.FillEllipse(brush, x, y, unit, unit);
            //g.DrawEllipse(pen, x, y, unit, unit);
            g.DrawImage(global::AD_Planner.Properties.Resources.Robot, x, y, unit, unit);
            //g.DrawString("" + (m_Y * m_Width + m_X), m_Font, textBrush, m_AbsX + 3 + m_X * m_Unit, m_AbsY + 3 + m_Y * m_Unit);
            //g.DrawString(String.Format("{0},{1}", m_Y, m_X), m_Font, textBrush, Grid.X + 3 + m_X * Grid.Unit, Grid.Y + 3 + m_Y * Grid.Unit);
        }
    }
}
