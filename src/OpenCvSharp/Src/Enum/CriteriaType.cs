﻿using System;

namespace OpenCvSharp2
{
#if LANG_JP
    /// <summary>
	/// 終了条件の種類
	/// </summary>
#else
    /// <summary>
    /// Type of termination criteria 
    /// </summary>
#endif
    [Flags]
    public enum CriteriaType : int
    {
#if LANG_JP
		/// <summary>
        /// 繰り返し回数による条件
		/// [CV_TERMCRIT_ITER]
		/// </summary>
#else
        /// <summary>
        /// [CV_TERMCRIT_ITER]
        /// </summary>
#endif
        Iteration = CvConst.CV_TERMCRIT_ITER,


#if LANG_JP
		/// <summary>
        /// 繰り返し回数による条件
		/// [CV_TERMCRIT_NUMBER]
		/// </summary>
#else
        /// <summary>
        /// [CV_TERMCRIT_NUMBER]
        /// </summary>
#endif
        Number = CvConst.CV_TERMCRIT_NUMBER,


#if LANG_JP
		/// <summary>
        /// 目標精度(ε)による条件
		/// [CV_TERMCRIT_EPS]
		/// </summary>
#else
        /// <summary>
        /// [CV_TERMCRIT_EPS]
        /// </summary>
#endif
        Epsilon = CvConst.CV_TERMCRIT_EPS,
    }
}
