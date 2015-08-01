#include "NativeLib.h"
#include "stdio.h"

__declspec(dllexport)
void print_line(const char* str)
{
	printf("[native] %s", str);
}

