﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp2
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
    /// <param name="struct_ptr"></param>
    /// <returns></returns>
#else
    /// <summary>
    /// 
    /// </summary>
    /// <param name="struct_ptr"></param>
    /// <returns></returns>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CvCloneFunc(IntPtr struct_ptr);

}
