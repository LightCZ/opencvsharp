﻿using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp2.CPlusPlus
{
    static partial class NativeMethods
    {
        #region Miscellaneous
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_setNumThreads(int nthreads);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_getNumThreads();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_getThreadNum();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void core_getBuildInformation([MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, uint maxLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern long core_getTickCount();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_getTickFrequency();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern long core_getCPUTickCount();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_checkHardwareSupport([MarshalAs(UnmanagedType.I4)] HardwareSupport feature);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_getNumberOfCPUs();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_fastMalloc(IntPtr bufSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_fastFree(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_setUseOptimized(int onoff);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_useOptimized();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr core_cvarrToMat(IntPtr arr, int copyData, int allowND, int coiMode);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_extractImageCOI(IntPtr arr, IntPtr coiimg, int coi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_insertImageCOI(IntPtr coiimg, IntPtr arr, int coi);
        #endregion

        #region Array Operations

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_add(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_subtract(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_multiply(IntPtr src1, IntPtr src2, IntPtr dst, double scale, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_divide1")]
        public static extern void core_divide(double scale, IntPtr src2, IntPtr dst, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_divide2")]
        public static extern void core_divide(IntPtr src1, IntPtr src2, IntPtr dst, double scale, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_scaleAdd(IntPtr src1, double alpha, IntPtr src2,IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_addWeighted(IntPtr src1, double alpha, IntPtr src2,
            double beta, double gamma, IntPtr dst, int dtype);

        #endregion


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_convertScaleAbs(IntPtr src, IntPtr dst, double alpha, double beta);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_LUT(IntPtr src, IntPtr lut, IntPtr dst, int interpolation);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar core_sum(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_countNonZero(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_findNonZero(IntPtr src, IntPtr idx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar core_mean(IntPtr src, IntPtr mask);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_meanStdDev_OutputArray(
            IntPtr src, IntPtr mean, IntPtr stddev, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_meanStdDev_Scalar(
            IntPtr src, out CvScalar mean, out CvScalar stddev, IntPtr mask);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_norm1")]
        public static extern double core_norm(IntPtr src1, int normType, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_norm2")]
        public static extern double core_norm(IntPtr src1, IntPtr src2,
                                               int normType, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_batchDistance(IntPtr src1, IntPtr src2,
                                                     IntPtr dist, int dtype, IntPtr nidx,
                                                     int normType, int k, IntPtr mask,
                                                     int update, int crosscheck);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_normalize(IntPtr src, IntPtr dst, double alpha, double beta,
                             int normType, int dtype, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_minMaxLoc1(IntPtr src, out double minVal, out double maxVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_minMaxLoc2(IntPtr src, out double minVal, out double maxVal,
            out CvPoint minLoc, out CvPoint maxLoc, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_minMaxIdx1(IntPtr src, out double minVal, out double maxVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_minMaxIdx2(IntPtr src, out double minVal, out double maxVal,
            out int minIdx, out int maxIdx, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_reduce(IntPtr src, IntPtr dst, int dim, int rtype, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_merge([MarshalAs(UnmanagedType.LPArray)] IntPtr[] mv, uint count, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_split(IntPtr src, out IntPtr mv);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_mixChannels(IntPtr[] src, uint nsrcs,
            IntPtr[] dst, uint ndsts, int[] fromTo, uint npairs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_extractChannel(IntPtr src, IntPtr dst, int coi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_insertChannel(IntPtr src, IntPtr dst, int coi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_flip(IntPtr src, IntPtr dst, int flipCode);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_repeat1")]
        public static extern void core_repeat(IntPtr src, int ny, int nx, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_repeat2")]
        public static extern IntPtr core_repeat(IntPtr src, int ny, int nx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_hconcat1")]
        public static extern void core_hconcat([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_hconcat2")]
        public static extern void core_hconcat(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_vconcat1")]
        public static extern void core_vconcat([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_vconcat2")]
        public static extern void core_vconcat(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_bitwise_and(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_bitwise_or(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_bitwise_xor(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_bitwise_not(IntPtr src, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_absdiff(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_inRange_InputArray")]
        public static extern void core_inRange(IntPtr src, IntPtr lowerb, IntPtr upperb, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_inRange_Scalar")]
        public static extern void core_inRange(IntPtr src, CvScalar lowerb, CvScalar upperb, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_compare(IntPtr src1, IntPtr src2, IntPtr dst, int cmpop);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_min1(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_max1(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_min_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_min_MatDouble(IntPtr src1, double src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)] 
        public static extern void core_max_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_max_MatDouble(IntPtr src1, double src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_sqrt(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_pow_Mat(IntPtr src, double power, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_exp_Mat(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_log_Mat(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float core_cubeRoot(float val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float core_fastAtan2(float y, float x);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_exp_Array(float[] src, float[] dst, int n);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_log_Array(float[] src, float[] dst, int n);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_fastAtan2_Array(float[] y, float[] x, float[] dst, int n, int angleInDegrees);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_magnitude_Array(float[] x, float[] y, float[] dst, int n);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_polarToCart(IntPtr magnitude, IntPtr angle, IntPtr x, IntPtr y, int angleInDegrees);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_cartToPolar(IntPtr x, IntPtr y, IntPtr magnitude, IntPtr angle, int angleInDegrees);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_phase(IntPtr x, IntPtr y, IntPtr angle, int angleInDegrees);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_magnitude_Mat(IntPtr x, IntPtr y, IntPtr magnitude);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_checkRange(IntPtr a, int quiet, out CvPoint pos, double minVal, double maxVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_patchNaNs(IntPtr a, double val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_gemm(IntPtr src1, IntPtr src2, double alpha, IntPtr src3, double gamma, IntPtr dst, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_mulTransposed(IntPtr src, IntPtr dst, int aTa, IntPtr delta, double scale, int dtype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_transpose(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_transform(IntPtr src, IntPtr dst, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_perspectiveTransform(IntPtr src, IntPtr dst, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_completeSymm(IntPtr mtx, int lowerToUpper);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_setIdentity(IntPtr mtx, CvScalar s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_determinant(IntPtr mtx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar core_trace(IntPtr mtx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_invert(IntPtr src, IntPtr dst, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_solve(IntPtr src1, IntPtr src2, IntPtr dst, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_sort(IntPtr src, IntPtr dst, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_sortIdx(IntPtr src, IntPtr dst, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_solveCubic(IntPtr coeffs, IntPtr roots);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_solvePoly(IntPtr coeffs, IntPtr roots, int maxIters);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen1")]
        public static extern int core_eigen(IntPtr src, IntPtr eigenvalues, int lowindex, int highindex);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen2")]
        public static extern int core_eigen(IntPtr src, IntPtr eigenvalues,
            IntPtr eigenvectors, int lowindex, int highindex);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen3")]
        public static extern int core_eigen(IntPtr src, bool computeEigenvectors,
            IntPtr eigenvalues, IntPtr eigenvectors);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen3")]
        public static extern void core_calcCovarMatrix_Mat([MarshalAs(UnmanagedType.LPArray)] IntPtr[] samples, 
            int nsamples, IntPtr covar, IntPtr mean, int flags, int ctype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_eigen3")]
        public static extern void core_calcCovarMatrix_InputArray(IntPtr samples, IntPtr covar,
            IntPtr mean, int flags, int ctype);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_PCACompute(IntPtr data, IntPtr mean, IntPtr eigenvectors, int maxComponents);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_PCAComputeVar(IntPtr data, IntPtr mean, IntPtr eigenvectors, double retainedVariance);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_PCAProject(IntPtr data, IntPtr mean, IntPtr eigenvectors, IntPtr result);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_PCABackProject(IntPtr data, IntPtr mean, IntPtr eigenvectors, IntPtr result);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_SVDecomp(IntPtr src, IntPtr w, IntPtr u, IntPtr vt, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_SVBackSubst(IntPtr w, IntPtr u, IntPtr vt, IntPtr rhs, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_Mahalanobis(IntPtr v1, IntPtr v2, IntPtr icovar);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_Mahalonobis(IntPtr v1, IntPtr v2, IntPtr icovar);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_dft(IntPtr src, IntPtr dst, int flags, int nonzeroRows);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_idft(IntPtr src, IntPtr dst, int flags, int nonzeroRows);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_dct(IntPtr src, IntPtr dst, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_idct(IntPtr src, IntPtr dst, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_mulSpectrums(IntPtr a, IntPtr b, IntPtr c, int flags, int conjB);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_getOptimalDFTSize(int vecsize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double core_kmeans(IntPtr data, int k, IntPtr bestLabels,
            CvTermCriteria criteria, int attempts, int flags, IntPtr centers);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong core_theRNG();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_randu_InputArray(IntPtr dst, IntPtr low, IntPtr high);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_randu_Scalar(IntPtr dst, CvScalar low, CvScalar high);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_randn_InputArray(IntPtr dst, IntPtr mean, IntPtr stddev);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_randn_Scalar(IntPtr dst, CvScalar mean, CvScalar stddev);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_randShuffle(IntPtr dst, double iterFactor, ref ulong rng);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_randShuffle(IntPtr dst, double iterFactor, IntPtr rng);

        #region Drawing
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_line(IntPtr img, Point pt1, Point pt2, CvScalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_rectangle1")]
        public static extern void core_rectangle(IntPtr img, Point pt1, Point pt2, CvScalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_rectangle2")]
        public static extern void core_rectangle(IntPtr img, Rect rect, CvScalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_circle(IntPtr img, Point center, int radius, CvScalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_ellipse1")]
        public static extern void core_ellipse(IntPtr img, Point center, Size axes,
            double angle, double startAngle, double endAngle, CvScalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_ellipse2")]
        public static extern void core_ellipse(IntPtr img, RotatedRect box, CvScalar color, int thickness, int lineType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_fillConvexPoly(IntPtr img, Point[] pts, int npts, CvScalar color, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_fillPoly(IntPtr img, IntPtr[] pts, int[] npts, int ncontours,
            CvScalar color, int lineType, int shift, Point offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_polylines(IntPtr img, IntPtr[] pts, int[] npts,
            int ncontours, int isClosed, CvScalar color, int thickness, int lineType, int shift);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_clipLine1")]
        public static extern int core_clipLine(Size imgSize, ref Point pt1, ref Point pt2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "core_clipLine2")]
        public static extern int core_clipLine(Rect imgRect, ref Point pt1, ref Point pt2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void core_putText(IntPtr img, [MarshalAs(UnmanagedType.LPStr)] string text, CvPoint org,
            int fontFace, double fontScale, CvScalar color,
            int thickness, int lineType, int bottomLeftOrigin);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern CvSize core_getTextSize([MarshalAs(UnmanagedType.LPStr)] string text, int fontFace,
	        double fontScale, int thickness, out int baseLine);

        #endregion
    }
}