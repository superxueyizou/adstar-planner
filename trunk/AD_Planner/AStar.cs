using System;
using System.Collections.Generic;
using System.Text;

namespace AD_Planner
{
    public class AStar : BasePlanner
    {
        private AStar(List<List<Cell>> grid)
            : base(grid)
        {
        }

        public static BasePlanner CreatePlanner(List<List<Cell>> grid)
        {
            if (!Planner.IsCreator)
                throw new Exception("Object Creation is not allowed. Use Planner.CreatePlanner().");
            else
                return new AStar(grid);
        }

        protected override void DoWork()
        {
            if(!Planner.IsCreator)
                throw new Exception("The method or operation is not implemented.");

            int c = Math.Min(Grid.Width, Grid.Height) - 1;
            for (int i = 1; i < c; i++)
            {
                m_Queue.Enqueue(Grid.Instance[i][i]);
                Grid.Instance[i][i].Type = CellType.Path;
            }
        }

        protected override void UpdateState(Cell cell)
        {
            if (!Planner.IsCreator)
                throw new Exception("The method or operation is not implemented.");
        }

        protected override void ComputePath()
        {
            if (!Planner.IsCreator)
                throw new Exception("The method or operation is not implemented.");
        }
    }
}
