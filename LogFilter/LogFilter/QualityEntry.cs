using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFilter
{
    public class QualityEntry 
    {
        public int CharLevel;
        public int ItemLevel;
        public string ItemName;
        public string SkillName;
        public double Coefficient;
        public int BaseControl;
        public int CurrentControl;
        public int Condition;
        public int IqStacks;
        public bool GreatStrides;
        public bool Ingenuity1;
        public bool Ingenuity2;
        public bool Innovation;
        public int Increase;
        public int IncreaseB;
        public int SimIncrease;
        public int Error;
        public int CurQuality;
        public int MaxQuality;
        public int Hits;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            QualityEntry other = (QualityEntry) obj;
            return (CharLevel == other.CharLevel && ItemLevel == other.ItemLevel && Coefficient==other.Coefficient && BaseControl== other.BaseControl && CurrentControl==other.CurrentControl
                && Condition==other.Condition && IqStacks== other.IqStacks && GreatStrides == other.GreatStrides && Ingenuity1 == other.Ingenuity1 && Ingenuity2 == other.Ingenuity2
                && Innovation == other.Innovation);
        }

      

        public override string ToString()
        {
            return $"CharLevel:{CharLevel} ItemLevel:{ItemLevel} CControl:{CurrentControl} BaseControl:{BaseControl} Coeff:{Coefficient} Increase:{Increase} Hits:{Hits}";
        }

        public override int GetHashCode()
        {
            string hashStr = "" + CharLevel + ItemLevel + Coefficient + BaseControl + CurrentControl + Condition +
                             IqStacks + GreatStrides + Ingenuity1 + Ingenuity2 + Innovation + Increase;
            return hashStr.GetHashCode();
        }

      

        
    }
}
