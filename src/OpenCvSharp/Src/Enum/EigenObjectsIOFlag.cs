﻿
namespace OpenCvSharp2
{
#if LANG_JP
    /// <summary>
	/// 主成分分析関数の入出力フラグ
	/// </summary>
#else
    /// <summary>
    /// Input/output flags for Eigen Objects (PCA) Functions
    /// </summary>
#endif
    public enum EigenObjectsIOFlag : int
    {
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_EIGOBJ_NO_CALLBACK]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_EIGOBJ_NO_CALLBACK]
        /// </summary>
#endif
        NoCallback = CvConst.CV_EIGOBJ_NO_CALLBACK,

#if LANG_JP
		/// <summary>
		/// 
        /// [CV_EIGOBJ_INPUT_CALLBACK]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_EIGOBJ_INPUT_CALLBACK]
        /// </summary>
#endif
        InputCallback = CvConst.CV_EIGOBJ_INPUT_CALLBACK,

#if LANG_JP
		/// <summary>
		/// 
        /// [CV_EIGOBJ_OUTPUT_CALLBACK]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_EIGOBJ_OUTPUT_CALLBACK]
        /// </summary>
#endif
        OutputCallback = CvConst.CV_EIGOBJ_OUTPUT_CALLBACK,

#if LANG_JP
		/// <summary>
		/// 
        /// [CV_EIGOBJ_BOTH_CALLBACK]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_EIGOBJ_BOTH_CALLBACK]
        /// </summary>
#endif
        BothCallback = CvConst.CV_EIGOBJ_BOTH_CALLBACK,
    }
}
