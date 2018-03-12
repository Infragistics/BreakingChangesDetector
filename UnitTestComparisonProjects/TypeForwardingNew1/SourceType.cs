using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeForwardingOld
{
    public class SourceType
    {
		public void Method(TargetType1 x) { }

		public void Method(TargetType2 x) { }
    }
}
