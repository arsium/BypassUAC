using System;
using static Special.Resolver;
using static Special.Commons;
using System.Runtime.InteropServices;

/* 
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
*/

namespace Special
{
    internal class DelegatesHandling
    {
        internal unsafe static void PrepareDelegate()
        {
            IntPtr ntWriteVirtual = GetExportAddress("ntdll.dll", "NtWriteVirtualMemory");
            IntPtr ntVirtualProtect = GetExportAddress("ntdll.dll", "NtProtectVirtualMemory");
            IntPtr rtlInitUnicode = GetExportAddress("ntdll.dll", "RtlInitUnicodeString");
            IntPtr rtlEnterCritical = GetExportAddress("ntdll.dll", "RtlEnterCriticalSection");
            IntPtr rtlLeaveCritical = GetExportAddress("ntdll.dll", "RtlLeaveCriticalSection");
            //IntPtr ntQueryInfo = GetExportAddress("ntdll.dll", "NtQueryInformationProcess");
            IntPtr coGet = GetExportAddress("ole32.dll", "CoGetObject");


            ntWriteVirtualMemory = (NtWriteVirtualMemory)Marshal.GetDelegateForFunctionPointer(ntWriteVirtual, typeof(NtWriteVirtualMemory));
            ntProtectVirtualMemory = (NtProtectVirtualMemory)Marshal.GetDelegateForFunctionPointer(ntVirtualProtect, typeof(NtProtectVirtualMemory));
            rtlInitUnicodeString = (RtlInitUnicodeString)Marshal.GetDelegateForFunctionPointer(rtlInitUnicode, typeof(RtlInitUnicodeString));
            rtlEnterCriticalSection = (RtlEnterCriticalSection)Marshal.GetDelegateForFunctionPointer(rtlEnterCritical, typeof(RtlEnterCriticalSection));

            rtlLeaveCriticalSection = (RtlLeaveCriticalSection)Marshal.GetDelegateForFunctionPointer(rtlLeaveCritical, typeof(RtlLeaveCriticalSection));
            //ntQueryInformationProcess = (NtQueryInformationProcessDel)Marshal.GetDelegateForFunctionPointer(ntQueryInfo, typeof(NtQueryInformationProcessDel));

            coGetObject = (CoGetObject)Marshal.GetDelegateForFunctionPointer(coGet, typeof(CoGetObject));
        }
    }
}
