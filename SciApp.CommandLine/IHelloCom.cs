using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SciApp.CommandLine
{
    [Guid("B24DA285-7FA9-4A31-8E1D-478FA4DB6B10")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHelloCom
    {
        [return:MarshalAs(UnmanagedType.BStr)]
        string SayHello();
    }
}
