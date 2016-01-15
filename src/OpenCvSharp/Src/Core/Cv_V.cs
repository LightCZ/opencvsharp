﻿using System;

namespace OpenCvSharp2
{
    public static partial class Cv
    {
        #region ValidateDisparity
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disparity"></param>
        /// <param name="cost"></param>
        /// <param name="minDisparity"></param>
        /// <param name="numberOfDisparities"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disparity"></param>
        /// <param name="cost"></param>
        /// <param name="minDisparity"></param>
        /// <param name="numberOfDisparities"></param>
#endif
        public static void ValidateDisparity(CvArr disparity, CvArr cost, int minDisparity, int numberOfDisparities)
        {
            ValidateDisparity(disparity, cost, minDisparity, numberOfDisparities, 1);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disparity"></param>
        /// <param name="cost"></param>
        /// <param name="minDisparity"></param>
        /// <param name="numberOfDisparities"></param>
        /// <param name="disp12MaxDiff"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disparity"></param>
        /// <param name="cost"></param>
        /// <param name="minDisparity"></param>
        /// <param name="numberOfDisparities"></param>
        /// <param name="disp12MaxDiff"></param>
#endif
        public static void ValidateDisparity(CvArr disparity, CvArr cost, int minDisparity, int numberOfDisparities, int disp12MaxDiff)
        {
            if (disparity == null)
                throw new ArgumentNullException("disparity");
            if (cost == null)
                throw new ArgumentNullException("cost");
            NativeMethods.cvValidateDisparity(disparity.CvPtr, cost.CvPtr, minDisparity, numberOfDisparities, disp12MaxDiff);

            GC.KeepAlive(disparity);
            GC.KeepAlive(cost);
        }
        #endregion
    }
}