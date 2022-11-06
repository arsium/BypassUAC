using System;
using System.Runtime.InteropServices;
using static Special.Commons;

/* 
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
*/

namespace Special
{
    internal class ASM
    {
        internal static GetPeb GetPebAddres;

        internal static void PreparePebProc() 
        {
            GetPebAddres = (GetPeb)Marshal.GetDelegateForFunctionPointer(IntPtr.Size == 4 ? ASM.PebFucker(true) : ASM.PebFucker(false), typeof(GetPeb));
        }

        private unsafe static IntPtr PebFucker(bool isWoW64)
        {
            byte[] shellcode;
            if (isWoW64)
            {
                shellcode = new byte[] { 0x53, 0x31, 0xDB, 0x31, 0xC0, 0x64, 0x8B, 0x1D, 0x30, 0x00, 0x00, 0x00, 0x89, 0xD8, 0x5B, 0xC3 };
            }
            else
            {
                shellcode = new byte[] { 0x53, 0x48, 0x31, 0xDB, 0x48, 0x31, 0xC0, 0x65, 0x48, 0x8B, 0x1C, 0x25, 0x60, 0x00, 0x00, 0x00, 0x48, 0x89, 0xD8, 0x5B, 0xC3 };
            }

            IntPtr ntVirtualAlloc = Resolver.GetExportAddress("ntdll.dll", "NtAllocateVirtualMemory");
            NtAllocateVirtualMemory ntAllocateVirtualMemory = (NtAllocateVirtualMemory)Marshal.GetDelegateForFunctionPointer(ntVirtualAlloc, typeof(NtAllocateVirtualMemory));

            IntPtr ntWriteVirtualBy = IntPtr.Zero;
            uint shellSize = (uint)shellcode.Length;

            void* theShell = &ntWriteVirtualBy;

            NtStatus n = ntAllocateVirtualMemory((void*)(-1), theShell, 0, &shellSize, MemoryAllocationType.MEM_COMMIT | MemoryAllocationType.MEM_RESERVE, PageAccessType.PAGE_EXECUTE_READWRITE);

            Marshal.Copy(shellcode, 0, ntWriteVirtualBy, shellcode.Length);

            return ntWriteVirtualBy;
        }
    }
}
