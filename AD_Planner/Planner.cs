using System;
using System.Collections.Generic;
using System.Text;

namespace AD_Planner
{
    public class Planner
    {
        private static BasePlanner m_PlannerInstance = null;
        private static bool m_IsCreator = false;

        public static bool IsCreator
        {
            get { return Planner.m_IsCreator; }
        }

        public static void CreatePlanner(string planner, List<List<Cell>> grid)
        {
            Planner.m_IsCreator = true;
            switch (planner)
            {
                case "AStar":
                    m_PlannerInstance = AStar.CreatePlanner(grid);
                    break;
                default:
                    m_PlannerInstance = null;
                    break;
            }
            Planner.m_IsCreator = false;
        }

        private Planner()
        {
        }

        public static void BeginPlanning()
        {
            if (m_PlannerInstance == null)
                return;

            Planner.m_IsCreator = true;
            m_PlannerInstance.BeginPlanning();
            Planner.m_IsCreator = false;
        }
    }
}
