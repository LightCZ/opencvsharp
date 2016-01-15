﻿using System;

namespace OpenCvSharp2
{
#if LANG_JP
    /// <summary>
    /// OpenCVのネイティブデータポインタを持つことを示すインターフェイス
    /// </summary>
#else
    /// <summary>
    /// Represents a OpenCV-based class which have a native pointer. 
    /// </summary>
#endif
    public interface ICvPtrHolder
    {
        /// <summary>
        /// Unmanaged OpenCV data pointer
        /// </summary>
        IntPtr CvPtr { get; }

    }
}
