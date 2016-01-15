﻿using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp2
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
#else
    /// <summary>
    /// 
    /// </summary>
#endif
    [StructLayout(LayoutKind.Sequential)]
    public struct CvString
    {
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int Len;


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IntPtr Ptr;


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="len"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="len"></param>
#endif
        public CvString(IntPtr ptr, int len)
        {
            this.Ptr = ptr;
            this.Len = len;
        }


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public static implicit operator string(CvString self)
        {
            return self.ToString();
        }


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public override string ToString()
        {
            unsafe
            {
                return new string((char*)Ptr, 0, Len);
            }
        }
    }
}
