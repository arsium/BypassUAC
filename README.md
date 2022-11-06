# BypassUAC
A rework of CMLuaUtil AutoElevated 

Original C# version : [0xlane](https://github.com/0xlane/BypassUAC)

## Why ?

The original version does not work anymore because of wrong import' signatures. I added some dinvoke delegates with manual address resolver.
Works for both X86 (wow64) & X64 architecture.

## What imports does it contain ?

### Functions 
* RtlInitUnicodeString (delegate)
* RtlEnterCriticalSection (delegate)
* RtlLeaveCriticalSection (delegate)
* CoGetObject (delegate)
* NtProtectVirtualMemory (delegate)
* NtWriteVirtualMemory (delegate)
* NtAllocateVirtualMemory (delegate)
* NtQueryInformationProcess (extern)

### Interface

* 6EDD6D74-C007-4E75-B76A-E5740995E24C

### Structures 

* ImageDosHeader
* ImageOptionalHeader32/64
* ImageDataDirectory
* ImageExportDirectory
* ImageFileHeader
* ProcessBasicInformation
* PEB32/64 (not full but useful fields)
* ListEntry
* PebLdrData
* LdrDataTableEntry
* UnicodeString
* LargeInteger
* BIND_OPTS3

### Enumerations 

* MagicType
* SubSystemType (2-4 bytes size)
* DllCharacteristics
* Characteristics
* Machine
* ProcessInfoClass (not full)
* NtStatus (not full)
* PebFlags
* PageAccessType
* MemoryAllocationType
* CLSCTX

<img src="https://github.com/arsium/BypassUAC/blob/main/Gif/BypassUAC.gif?raw=true" width="900" height="600" />
