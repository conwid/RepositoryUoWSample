using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Clock : IClock
    {
        public DateTime Now => DateTime.Now;
    }
}
