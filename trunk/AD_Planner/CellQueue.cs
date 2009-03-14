using System;
using System.Collections.Generic;
using System.Text;

namespace AD_Planner
{
    public class CellQueue
    {
        private List<Cell> m_Queue = null;
        private string m_Name = "";

        public CellQueue(string name)
        {
            m_Queue = new List<Cell>();
            m_Name = name;
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public int Count
        {
            get
            {
                return m_Queue.Count;
            }
        }
        public Cell Peek
        {
            get
            {
                if (Count < 1)
                    return null;

                return m_Queue[0];
            }
        }
        public void Enqueue(Cell cell)
        {
            m_Queue.Add(cell);
        }
        public Cell Dequeue()
        {
            if (Count < 1)
                return null;

            Cell cell = m_Queue[0];
            m_Queue.RemoveAt(0);
            return cell;
        }
        public override string ToString()
        {
            string str = Name + ": ";
            foreach (Cell c in m_Queue)
                str += c.ToString();
            return str;
        }
    }
}
