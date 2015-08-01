#ifndef _NATIVELIB_H_
#define _NATIVELIB_H_

#ifdef __cplusplus
extern "C" {
#endif

__declspec(dllexport)
void print_line(const char* str);

#ifdef __cplusplus
}
#endif

#endif // _NATIVELIB_H_
