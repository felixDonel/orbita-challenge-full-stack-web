using Orbita.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbita.Tests
{
    public static class HelperTest
    {
        public static Student StudentValid() 
        { 
            return new Student(1,"Felix","FelixGusta@GMAIL.COM",10058778950);
        }
        public static Student StudentNameInvalid() 
        { 
            return new Student(1,"A", "FelixGusta@GMAIL.COM", 10058778950);
        }
        public static Student StudentEmailInvalid() 
        { 
            return new Student(1, "Felix", "A",10058778950);
        }
        public static Student StudentCPFInvalid() 
        { 
            return new Student(1, "Felix", "FelixGusta@GMAIL.COM", 100);
        }
    }
}
