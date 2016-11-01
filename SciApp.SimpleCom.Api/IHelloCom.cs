using System.Runtime.InteropServices;

namespace SciApp.SimpleCom.Api
{
    [Guid("B24DA285-7FA9-4A31-8E1D-478FA4DB6B10")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHelloCom
    {
        [return:MarshalAs(UnmanagedType.BStr)]
        string SayHello();
    }
}
