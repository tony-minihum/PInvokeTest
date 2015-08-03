#ifndef _NATIVELIB_H_
#define _NATIVELIB_H_

#ifdef __cplusplus
extern "C" {
#endif

__declspec(dllexport)
void print_line(const char* str);

__declspec(dllexport)
void get_string(char* buf, int len);

__declspec(dllexport)
void takes_an_int_array(int* buf, int len);

__declspec(dllexport)
void managed_ptr_class(void* pManagedPtr);

__declspec(dllexport)
void managed_ptr_struct(void* pManagedPtr);

#ifdef __cplusplus
}
#endif

#endif // _NATIVELIB_H_
