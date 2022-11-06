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
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr GetPeb();

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void RtlInitUnicodeString
            (
                ref UnicodeString DestinationString, 
                [MarshalAs(UnmanagedType.LPWStr)] string SourceString
            );

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void RtlEnterCriticalSection(IntPtr lpCriticalSection);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal delegate void RtlLeaveCriticalSection(IntPtr lpCriticalSection);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        internal unsafe delegate int CoGetObject
            (
                byte[] pszName,
                BIND_OPTS3* pBindOptions,
                Guid* riid,
                void** rReturnedComObject
            );

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal unsafe delegate NtStatus NtProtectVirtualMemory
            (
                void* ProcessHandle,
                void* BaseAddress,
                uint* NumberOfBytesToProtect,
                PageAccessType NewAccessProtection,
                PageAccessType* OldAccessProtection
            );


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]//Cdecl FOR MANUAL SYSCALL, StdCall for dynvoke
        internal delegate uint NtWriteVirtualMemory
            (
                IntPtr ProcessHandle, 
                IntPtr BaseAddress, 
                IntPtr buffer, 
                UIntPtr bufferSize, 
                out UIntPtr written
            );


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal unsafe delegate NtStatus NtAllocateVirtualMemory
            (
                void* ProcessHandle,
                void* BaseAddress,
                uint ZeroBits,
                uint* RegionSize,
                MemoryAllocationType AllocationType,
                PageAccessType Protect
            );

        internal static NtProtectVirtualMemory ntProtectVirtualMemory;
        internal static NtWriteVirtualMemory ntWriteVirtualMemory;
        internal static RtlInitUnicodeString rtlInitUnicodeString;
        internal static RtlEnterCriticalSection rtlEnterCriticalSection;
        internal static RtlLeaveCriticalSection rtlLeaveCriticalSection;
        //private static NtQueryInformationProcessDel ntQueryInformationProcess;
        internal static CoGetObject coGetObject;
    }
}
