using System;
using System.Runtime.InteropServices;

/*
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
*/

namespace Special
{
    internal partial class Commons
    {
        [DllImport("ntdll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern NtStatus NtQueryInformationProcess
           (
               IntPtr ProcessHandle,
               ProcessInfoClass ProcessInforationClass,
               IntPtr ProcessInformation,
               uint ProcessInformationLength,
               out uint ReturnLength
           );
    }
}
