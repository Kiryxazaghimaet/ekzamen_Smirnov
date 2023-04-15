using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekzamen.Models
{
    partial class Client
    {
        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName} {MiddleName}";
            }
        }
    }
}
