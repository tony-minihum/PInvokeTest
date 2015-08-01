#include "NativeLib.h"
#include "stdio.h"

__declspec(dllexport)
void print_line(const char* str)
{
	printf("[native] %s", str);
}

__declspec(dllexport)
void get_string(char* buf, int len)
{
	printf("get_stirng %p %d\n", buf, len);
	len = 8;

	for (int i = 0; i < len - 1; i++)
	{
		buf[i] = 'A' + i;
	}
	buf[len - 1] = '\0';
}

__declspec(dllexport)
void takes_an_int_array(int* buf, int len)
{
	for (int i = 0; i < len + 5; i++)
	{
		buf[i] = 0xff;
	}
}
