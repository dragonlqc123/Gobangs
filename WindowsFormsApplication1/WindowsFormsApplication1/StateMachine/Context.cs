using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Context
    {
        public  Operation user;
        public  Operation computer;

        private Operation m_operator;
        public Context(LayoutNode layoutNodes, Operation _operator)
        {
            this.user = new User(layoutNodes);
            this.computer = new Computer(layoutNodes);
            this.SetState(_operator);
        }

        public ReturnInfo Next(int state, int x, int y, int qz)
        {
            ReturnInfo returnInfo = m_operator.GetReturn(false);
            if (IsVaild( state,  x,  y,qz))
            {
                return m_operator.GetReturn(true);
            }
            var _operator = m_operator.Next(this);
            this.SetState(_operator);
            if (m_operator.GetType() == typeof(Computer))
            {
               Node node = m_operator.Defense(x, y,this,qz);
                if (node == null)
                {
                    return ReturnInfo.GetDefaultInfo();
                }
                return this.Next(state, node.cpoint.X,node.cpoint.Y, qz);
            }
            return returnInfo;
        }

        private bool IsVaild(int state, int x, int y, int qz)
        {
            return m_operator.Check(state, x, y,qz);
        }

        private void SetState(Operation _operator)
        {
            m_operator = _operator;
        }

        public void InitState(Operation _operator)
        {
            this.SetState(_operator);
        }
        public Operation GetState()
        {
            return m_operator;
        }
    }
}
