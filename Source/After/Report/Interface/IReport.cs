using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace After.Report.Interface
{
    public interface IReport
    {
        string Path { get; }
        IEnumerable GetData();
    }
}
