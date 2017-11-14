#include "Disassembler.h"

extern "C"
{
	__declspec(dllexport) void Disasm(u32 adr, u32 ins, char *str);
	__declspec(dllexport) void DisasmThumb(u32 adr, u32 ins, char *str);
	__declspec(dllexport) void Hoge(char *str);
}

#define INDEX(i) ((((i)>>16)&0xFF0)|(((i)>>4)&0xF))

void Disasm(u32 adr, u32 ins, char *str)
{
	des_arm_instructions_set[INDEX(ins)](adr, ins, str);
}
void DisasmThumb(u32 adr, u32 ins, char *str)
{
	des_thumb_instructions_set[ins >> 6](adr, ins, str);
}



void Hoge(char *str)
{
	str[0] = 'H';
	str[1] = 'O';
	str[2] = 'G';
	str[3] = 'E';
	str[4] = 0;
}