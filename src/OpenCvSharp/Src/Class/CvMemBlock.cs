﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp2
{
#if LANG_JP
    /// <summary>
    /// メモリストレージブロック
    /// </summary>
#else
    /// <summary>
    /// Memory storage block
    /// </summary>
#endif
    public class CvMemBlock : CvObject
    {
        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvMemBlock*</param>
#else
        /// <summary>
        /// Constructs from native pointer
        /// </summary>
        /// <param name="ptr">struct CvMemBlock*</param>
#endif
        public CvMemBlock(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvMemBlock) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvMemBlock));


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public CvMemBlock Prev
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvMemBlock*)ptr)->prev);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvMemBlock(p);
            }
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
        public CvMemBlock Next
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvMemBlock*)ptr)->next);
                }
                if (p == IntPtr.Zero)
                    return null;
                else
                    return new CvMemBlock(p);
            }
        }
        #endregion
    }
}
