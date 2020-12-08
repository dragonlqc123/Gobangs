using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Contrast
    {
        /// <summary>
        /// 防
        /// </summary>
        private Analysis analysis;
        /// <summary>
        /// 攻
        /// </summary>
        private Analysis analysisN;
        public Contrast(Analysis analysis, Analysis analysisN)
        {
            this.analysis = analysis;
            this.analysisN = analysisN;
        }
        //public Contrast(Analysis analysis)
        //{
        //    this.analysis = analysis;
        //}
        public Node ContrastFX()
        {
            Node defense = analysis.AnalysisData();
            Node attack = analysisN.AnalysisData();
            if (defense != null && attack != null)
            {
                if (defense.Rate <= attack.Rate)
                {
                    return attack;
                }
                else
                    return defense;
            }
            else
            {
                if (defense != null)
                {
                    return attack;
                }
                else if (attack != null)
                {
                    return attack;
                }
            }
            return null;
        }
        
    }
}
