using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ekzamen
{
    partial class partialPersonal
    {
        public byte[] Photo
        {
            get
            {
                if (File.Exists($"photo/{LastName} {FirstName} {MiddleName}.jpg"))
                {
                    return File.ReadAllBytes($"photo/{LastName} {FirstName} {MiddleName}.jpg");
                }
                if (File.Exists($"photo/{LastName} {FirstName} {MiddleName}.png"))
                {
                    return File.ReadAllBytes($"photo/{LastName} {FirstName} {MiddleName}.png");
                }
                return null;
            }

        }
    }
}
