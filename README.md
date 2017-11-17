# desdebugger

A debugger for DeSmuME.

![screenshot](https://raw.githubusercontent.com/oupo/desdebugger/master/screenshot.png)

## How to build

1. Open arm-disasm/arm-disasm.sln and build this.
2. Open desdebugger/desdebugger.sln and build this.
3. Then copy arm-disasm.dll into the same directory as desdebugger.exe

## How to use

1. Copy desmume.exe into the same directory as desdebugger.exe (Use DeSmuME Developer Build and let the executable file's name "desmume.exe")
2. Launch desdebugger.exe
3. Click "Launch DeSmuME"
4. Click "Connect"
5. Input the memory address that you want to debug into "Break Point" and click "Set"
6. Click "Continue"
7. In DeSmuME, open the game rom
8. When the game reached the address you inputted in 5, you can debug.

