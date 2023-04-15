using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekzamen.Models
{
    partial class Auto
    {
        public string MaskStateNumber
        {
            get
            {
                return $"{StateNumber[0]}**{StateNumber.Substring(3)}";
            }
        }
    }
}
