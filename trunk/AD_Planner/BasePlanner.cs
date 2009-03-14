using System;
using System.Collections.Generic;
using System.Text;

namespace AD_Planner
{
    public abstract class BasePlanner
    {
        protected CellQueue m_Queue = null;

        protected BasePlanner(List<List<Cell>> grid)
        {
            m_Queue = new CellQueue("Q");
        }

        public void BeginPlanning()
        {
            if (Grid.IsModified || !Planner.IsCreator)
                return;

            DoWork();

            MainForm.Write(m_Queue.ToString());
        }
        protected abstract void DoWork();
        protected abstract void UpdateState(Cell cell);
        protected abstract void ComputePath();
    }
}
