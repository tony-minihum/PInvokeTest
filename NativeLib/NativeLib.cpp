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
	for (int i = 0; i < len; i++)
	{
		buf[i] = 0xff;
	}
}

void managed_ptr(void* pManagedPtr)
{
	printf("[native] Managed Ptr %p\n", pManagedPtr);
	int size = 30;
	unsigned char* ptr = (unsigned char*)pManagedPtr;
	for (int i = -5; i < size; i++)
	{
		printf("%02x ", ptr[i]);
//		printf("%02x %p ", ptr[i], &ptr[i]);
	}
	printf("\n[native]\n");
}

__declspec(dllexport)
void managed_ptr_class(void* pManagedPtr)
{
	managed_ptr(pManagedPtr);
//	managed_ptr(&(*(int*)pManagedPtr));
}

__declspec(dllexport)
void managed_ptr_struct(void* pManagedPtr)
{
	managed_ptr(pManagedPtr);
}

__declspec(dllexport)
void managed_ptr_if(void* pManagedPtr)
{
	managed_ptr(pManagedPtr);
}

