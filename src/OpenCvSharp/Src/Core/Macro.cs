﻿/*
 * (C) 2008 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp2.Utilities;

namespace OpenCvSharp2
{
#if LANG_JP
    /// <summary>
    /// OpenCvのcvXXX関数のラッパー。
    /// </summary>
#else
    /// <summary>
    /// Managed wrapper of all OpenCV functions
    /// </summary>
#endif
    public static partial class Cv
    {
        // ReSharper disable InconsistentNaming

        #region Helper Method

        /// <summary>
        /// References the specified object, which makes it ineligible for garbage collection 
        /// from the start of the current routine to the point where this method is called.
        /// </summary>
        /// <param name="arg1"></param>
        private static void KeepAlive(object arg1)
        {
            GC.KeepAlive(arg1);
        }

        /// <summary>
        /// References the specified object, which makes it ineligible for garbage collection 
        /// from the start of the current routine to the point where this method is called.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private static void KeepAlive(object arg1, object arg2)
        {
            GC.KeepAlive(arg1);
            GC.KeepAlive(arg2);
        }

        /// <summary>
        /// References the specified object, which makes it ineligible for garbage collection 
        /// from the start of the current routine to the point where this method is called.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        private static void KeepAlive(object arg1, object arg2, object arg3)
        {
            GC.KeepAlive(arg1);
            GC.KeepAlive(arg2);
            GC.KeepAlive(arg3);
        }

        /// <summary>
        /// References the specified object, which makes it ineligible for garbage collection 
        /// from the start of the current routine to the point where this method is called.
        /// </summary>
        /// <param name="args"></param>
        private static void KeepAlive(params object[] args)
        {
            if (args == null)
                return;
            foreach (var o in args)
            {
                GC.KeepAlive(o);
            }
        }

        /// <summary>
        /// Returns obj.CvPtr if obj != null; otherwise, IntPtr.Zero
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static IntPtr ToPtr(ICvPtrHolder obj)
        {
            return (obj == null) ? IntPtr.Zero : obj.CvPtr;
        }

        /// <summary>
        /// Converts IEnumerable to Array
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static T[] ToArray<T>(IEnumerable<T> obj)
        {
            if (obj == null)
                return null;
            return new List<T>(obj).ToArray();
        }
        #endregion

        #region Constants
        /// <summary>
        /// CV_AA
        /// </summary>
        public const LineType AA = (LineType)CvConst.CV_AA;
        /// <summary>
        /// CV_AUTOSTEP
        /// </summary>
        public const int AUTOSTEP = CvConst.CV_AUTOSTEP;
        /// <summary>
        /// CV_FILLED
        /// </summary>
        public const int FILLED = CvConst.CV_FILLED;
        /// <summary>
        /// CV_LOG2
        /// </summary>
        public const double LOG2 = CvConst.CV_LOG2;
        /// <summary>
        /// CV_PI
        /// </summary>
        public const double PI = CvConst.CV_PI;
        /// <summary>
        /// CV_WHOLE_SEQ_END_INDEX
        /// </summary>
        public const int WHOLE_SEQ_END_INDEX = CvConst.CV_WHOLE_SEQ_END_INDEX;
        /// <summary>
        /// CV_WHOLE_SEQ
        /// </summary>
        public static readonly CvSlice WHOLE_SEQ = CvSlice.WholeSeq;
#if LANG_JP
        /// <summary>
        /// セットされている場合は，現在のピクセルとシードピクセルとの差が対象となる．それ以外は，隣接同士の差が対象となる（つまりこのフラグがセットされない場合，レンジは変動的である）． 
        /// </summary>
#else
        /// <summary>
        /// if set, the difference between the current pixel and seed pixel is considered, otherwise the difference between neighbor pixels is considered (the range is floating)
        /// </summary>
#endif
        public const int FLOODFILL_FIXED_RANGE = CvConst.CV_FLOODFILL_FIXED_RANGE;
#if LANG_JP
        /// <summary>
        /// セットされている場合は，この関数では画像を塗りつぶさない（new_val は無視される）が， マスク（この場合，マスクはnull以外の値でないといけない）は塗りつぶす. 
        /// </summary>
#else
        /// <summary>
        /// if set, the function does not fill the image (new_val is ignored), but fills the mask (that must be non-null in this case)
        /// </summary>
#endif
        public const int FLOODFILL_MASK_ONLY = CvConst.CV_FLOODFILL_MASK_ONLY;
        /// <summary>
        /// 
        /// </summary>
        public const int CV_MAX_DIM = CvConst.CV_MAX_DIM;
        /// <summary>
        /// 
        /// </summary>
        public const int CV_FOURCC_DEFAULT = CvConst.CV_FOURCC_DEFAULT;
        /// <summary>
        /// 
        /// </summary>
        public const int CV_FOURCC_PROMPT = CvConst.CV_FOURCC_PROMPT;
        #endregion

        #region ARE_TYPES_EQ
#if LANG_JP
        /// <summary>
        /// 指定した2つの行列のデータタイプが等しければtrueを返す
        /// </summary>
        /// <param name="mat1">1つ目の入力行列</param>
        /// <param name="mat2">2つ目の入力行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns></returns>
#endif
        public static bool ARE_TYPES_EQ(CvMat mat1, CvMat mat2)
        {
            if (mat1 == null)
                throw new ArgumentNullException("mat1");
            if (mat2 == null)
                throw new ArgumentNullException("mat2");
            return ((mat1.Type ^ mat2.Type) & CvConst.CV_MAT_TYPE_MASK) == 0;
        }
#if LANG_JP
        /// <summary>
        /// 指定した2つの行列のデータタイプが等しければtrueを返す
        /// </summary>
        /// <param name="mat1">1つ目の入力行列</param>
        /// <param name="mat2">2つ目の入力行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns></returns>
#endif
        public static bool ARE_TYPES_EQ( CvMatND mat1, CvMatND mat2 )
        {
            if (mat1 == null)
                throw new ArgumentNullException("mat1");
            if (mat2 == null)
                throw new ArgumentNullException("mat2");
            return ((mat1.Type ^ mat2.Type) & CvConst.CV_MAT_TYPE_MASK) == 0;
        }
#if LANG_JP
        /// <summary>
        /// 指定した2つの行列のデータタイプが等しければtrueを返す
        /// </summary>
        /// <param name="mat1">1つ目の入力行列</param>
        /// <param name="mat2">2つ目の入力行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns></returns>
#endif
        public static bool ARE_TYPES_EQ( CvSparseMat mat1, CvSparseMat mat2 )
        {
            if (mat1 == null)
                throw new ArgumentNullException("mat1");
            if (mat2 == null)
                throw new ArgumentNullException("mat2");
            return ((mat1.Type ^ mat2.Type) & CvConst.CV_MAT_TYPE_MASK) == 0;
        }
        #endregion
        #region ARE_CNS_EQ
#if LANG_JP
        /// <summary>
        /// 指定した2つの行列のチャンネル数が同じならばtrueを返す
        /// </summary>
        /// <param name="mat1">1つ目の入力行列</param>
        /// <param name="mat2">2つ目の入力行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns></returns>
#endif
        public static bool ARE_CNS_EQ(CvMat mat1, CvMat mat2)
        {
            return ((mat1.Type ^ mat2.Type) & CvConst.CV_MAT_CN_MASK) == 0;
        }
        #endregion
        #region ARE_DEPTHS_EQ
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1">1つ目の入力行列</param>
        /// <param name="mat2">2つ目の入力行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns></returns>
#endif
        public static bool ARE_DEPTHS_EQ(CvMat mat1, CvMat mat2) 
        {
            return ((mat1.Type ^ mat2.Type) & CvConst.CV_MAT_DEPTH_MASK) == 0;
        }
        #endregion
        #region ARE_SIZES_EQ
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1">1つ目の入力行列</param>
        /// <param name="mat2">2つ目の入力行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns></returns>
#endif
        public static bool ARE_SIZES_EQ(CvMat mat1, CvMat mat2) 
        {
            return (mat1.Rows == mat2.Rows && mat1.Cols == mat2.Cols);
        }
        #endregion
        #region ELEM_SIZE1
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
#endif
        public static int ELEM_SIZE1(int type)
        {
            // 0x124489 = 1000 0100 0100 0010 0010 0001 0001 ~ array of sizeof(arr_type_elem)
            return (((sizeof(uint)<<28)|0x8442211) >> MAT_DEPTH(type)*4) & 15;
        }
        #endregion
        #region ELEM_SIZE
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
#endif
        public static int ELEM_SIZE(int type) 
        {
            // 0x3a50 = 11 10 10 01 01 00 00 ~ array of log2(sizeof(arr_type_elem))
            return (MAT_CN(type) << ((((sizeof(uint) / 4 + 1) * 16384 | 0x3a50) >> MAT_DEPTH(type) * 2) & 3));
        }
        #endregion
        #region FOURCC
        /// <summary>
        /// 4つの文字からFOURCCの整数値を得る
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="c3"></param>
        /// <param name="c4"></param>
        /// <returns></returns>
        public static int FOURCC(byte c1, byte c2, byte c3, byte c4)
        {
            return (((c1) & 255) + (((c2) & 255) << 8) + (((c3) & 255) << 16) + (((c4) & 255) << 24));
        }
        /// <summary>
        /// 4つの文字からFOURCCの整数値を得る
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="c3"></param>
        /// <param name="c4"></param>
        /// <returns></returns>
        public static int FOURCC(char c1, char c2, char c3, char c4)
        {
            byte b1 = System.Convert.ToByte(c1);
            byte b2 = System.Convert.ToByte(c2);
            byte b3 = System.Convert.ToByte(c3);
            byte b4 = System.Convert.ToByte(c4);
            return FOURCC(b1, b2, b3, b4);
        }
        /// <summary>
        /// 4つの文字からFOURCCの整数値を得る
        /// </summary>
        /// <param name="fourcc"></param>
        /// <returns></returns>
        public static int FOURCC(string fourcc)
        {
            if (string.IsNullOrEmpty(fourcc))
                return -1;
            if (fourcc.Length != 4)
                throw new ArgumentOutOfRangeException("fourcc");
            byte c1 = System.Convert.ToByte(fourcc[0]);
            byte c2 = System.Convert.ToByte(fourcc[1]);
            byte c3 = System.Convert.ToByte(fourcc[2]);
            byte c4 = System.Convert.ToByte(fourcc[3]);
            return FOURCC(c1, c2, c3, c4);
        }
        #endregion
        #region IS_IMAGE_HDR
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static bool IS_IMAGE_HDR(IntPtr img) 
        {
            unsafe
            {
                return (img != IntPtr.Zero && ((WIplImage*)img)->nSize == IplImage.SizeOf);
            }
        }
        #endregion
        #region IS_IMAGE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static bool IS_IMAGE(IntPtr img)
        {
            unsafe
            {
                return (IS_IMAGE_HDR(img) && ((WIplImage*)img)->imageData != (byte*)0);
            }
        }
        #endregion
        #region IS_GRAPH_EDGE_VISITED
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
#endif
        public static bool IS_GRAPH_EDGE_VISITED(CvGraphEdge edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException("edge");
            }
            return IS_GRAPH_EDGE_VISITED(edge.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
#endif
        public static bool IS_GRAPH_EDGE_VISITED(ICvPtrHolder edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException("edge");
            }
            return IS_GRAPH_EDGE_VISITED(edge.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
#endif
        public static bool IS_GRAPH_EDGE_VISITED( IntPtr edge )
        {
            try
            {
                unsafe
                {
                    return (((WCvGraphEdge*)edge)->flags & CvConst.CV_GRAPH_ITEM_VISITED_FLAG) != 0;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region IS_GRAPH_VERTEX_VISITED
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vtx"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vtx"></param>
        /// <returns></returns>
#endif
        public static bool IS_GRAPH_VERTEX_VISITED(CvGraphVtx vtx)
        {
            if (vtx == null)
            {
                throw new ArgumentNullException("vtx");
            }
            return IS_GRAPH_VERTEX_VISITED(vtx.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vtx"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vtx"></param>
        /// <returns></returns>
#endif
        public static bool IS_GRAPH_VERTEX_VISITED(ICvPtrHolder vtx)
        {
            if (vtx == null)
            {
                throw new ArgumentNullException("vtx");
            }
            return IS_GRAPH_VERTEX_VISITED(vtx.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vtx"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vtx"></param>
        /// <returns></returns>
#endif
        public static bool IS_GRAPH_VERTEX_VISITED(IntPtr vtx)
        {
            try
            {
                unsafe
                {
                    return (((WCvGraphVtx*)vtx)->flags & CvConst.CV_GRAPH_ITEM_VISITED_FLAG) != 0;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region IS_MAT_HDR
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static bool IS_MAT_HDR(IntPtr mat) 
        {
            unsafe
            {
                return (mat != IntPtr.Zero && 
                    (((WCvMat*)mat)->type & CvConst.CV_MAGIC_MASK) == CvConst.CV_MAT_MAGIC_VAL && 
                    ((WCvMat*)mat)->cols > 0 && ((WCvMat*)mat)->rows > 0);
            }
        }
        #endregion
        #region IS_MAT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static bool IS_MAT(IntPtr mat) 
        {
            unsafe
            {
                return (IS_MAT_HDR(mat) && ((WCvMat*)mat)->data != null);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static bool IS_MAT(ICvPtrHolder mat)
        {
            return IS_MAT(ToPtr(mat));
        }
        #endregion
        #region IS_SET_ELEM
#if LANG_JP
        /// <summary>
        /// 指定したノードが使用されているかどうかを判断する
        /// </summary>
        /// <param name="elem">ノードポインタ</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
#endif
        public static bool IS_SET_ELEM(CvSetElem elem)
        {

            return elem.Flags;
        }
#if LANG_JP
        /// <summary>
        /// 指定したノードが使用されているかどうかを判断する
        /// </summary>
        /// <param name="ptr">ノードポインタ</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
#endif
        public static bool IS_SET_ELEM(ICvPtrHolder ptr)
        {
            return IS_SET_ELEM(ptr.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 指定したノードが使用されているかどうかを判断する
        /// </summary>
        /// <param name="ptr">ノードポインタ</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
#endif
        public static bool IS_SET_ELEM(IntPtr ptr)
        {
            
            try
            {
                unsafe
                {
                    return ((WCvSetElem*)ptr)->flags >= 0;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region MAKETYPE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="cn"></param>
        /// <returns></returns>
        public static int MAKETYPE(int depth, int cn)
        {
            return (MAT_DEPTH(depth) + ((cn - 1) << CvConst.CV_CN_SHIFT));
        }
        #endregion
        #region MAT_CN
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static int MAT_CN(int flags)
        {
            return (((flags & CvConst.CV_MAT_CN_MASK) >> CvConst.CV_CN_SHIFT) + 1);
        }
        #endregion
        #region MAT_DEPTH
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static int MAT_DEPTH(int flags) 
        {
            return (flags & CvConst.CV_MAT_DEPTH_MASK);
        }
        #endregion
        #region MAT_ELEM
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="pixSize"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="pixSize"></param>
        /// <returns></returns>
#endif
        public static unsafe byte* MAT_ELEM_PTR_FAST(CvMat mat, int row, int col, int pixSize)
        {
            /*if ((uint)row < (uint)mat.Rows && (uint)col < (uint)mat.Cols)
            {
                throw new ArgumentException();
            }*/
            return mat.DataByte + (uint)(mat.Step * row) + (pixSize * col);
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
#endif
        public static unsafe byte* MAT_ELEM_PTR(CvMat mat, int row, int col)
		{
            return MAT_ELEM_PTR_FAST(mat, row, col, ELEM_SIZE(mat.Type));
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
#endif
        public static T CV_MAT_ELEM<T>(CvMat mat, int row, int col) where T : struct
		{
            unsafe
            {
                Type type = typeof (T);
                byte* result = MAT_ELEM_PTR_FAST(mat, row, col, Marshal.SizeOf(type));
                return (T)Marshal.PtrToStructure(new IntPtr(result), type);
            }
		}
        #endregion
        #region MAT_TYPE
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static int MAT_TYPE(int flags)
        {
            return (flags & CvConst.CV_MAT_TYPE_MASK);
        }
        #endregion
        #region NEXT_LINE_POINT
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineIterator"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineIterator"></param>
#endif
        public static void NEXT_LINE_POINT(CvLineIterator lineIterator)
        {
            int lineIteratorMask = lineIterator.Err < 0 ? -1 : 0;
            lineIterator.Err += lineIterator.MinusDelta + (lineIterator.PlusDelta & lineIteratorMask);
            lineIterator.Ptr = new IntPtr(lineIterator.Ptr.ToInt64() + lineIterator.MinusStep + (lineIterator.PlusStep & lineIteratorMask));
        }
        #endregion
        #region NEXT_SEQ_ELEM
#if LANG_JP
        /// <summary>
        /// 次のシーケンスへ
        /// </summary>
        /// <param name="elemSize"></param>
        /// <param name="reader"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemSize"></param>
        /// <param name="reader"></param>
#endif
        public static void NEXT_SEQ_ELEM(int elemSize, CvSeqReader reader)
        {
            reader.Ptr = new IntPtr(reader.Ptr.ToInt64() + elemSize);
            if (reader.Ptr.ToInt64() >= reader.BlockMax.ToInt64())
            {
                NativeMethods.cvChangeSeqBlock(reader.CvPtr, 1);                
            }
        }
        #endregion
        #region NODE_IDX
#if LANG_JP
        /// <summary>
        /// CV_NODE_IDX
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="node"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// CV_NODE_IDX
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="node"></param>
        /// <returns></returns>
#endif
        public static PointerAccessor1D_Int32 NODE_IDX(CvSparseMat mat, CvSparseNode node)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            if (node == null)
                throw new ArgumentNullException("node");

            unsafe
            {
                int* p = (int*)((byte*)node.CvPtr + mat.IdxOffset);
                return new PointerAccessor1D_Int32(p);
            }
        }
        #endregion
        #region NODE_VAL
#if LANG_JP
        /// <summary>
        /// CV_NODE_VAL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat"></param>
        /// <param name="node"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// CV_NODE_VAL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat"></param>
        /// <param name="node"></param>
        /// <returns></returns>
#endif
        public static T NODE_VAL<T>(CvSparseMat mat, CvSparseNode node) where T : struct
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            if (node == null)
                throw new ArgumentNullException("node");

            IntPtr p = NODE_VAL(mat, node);

            return Util.ToObject<T>(p);
        }
#if LANG_JP
        /// <summary>
        /// CV_NODE_VAL
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="node"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// CV_NODE_VAL
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="node"></param>
        /// <returns></returns>
#endif
        public static IntPtr NODE_VAL(CvSparseMat mat, CvSparseNode node) 
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            if (node == null)
                throw new ArgumentNullException("node");

            unsafe
            {
                return new IntPtr(((byte*)node.CvPtr + mat.ValOffset));
            }
        }
        #endregion
        #region NODE_TYPE
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static int NODE_TYPE(NodeType flags)
        {
            return ((int)flags & CvConst.CV_NODE_TYPE_MASK);
        }
        #endregion
        #region NODE_IS_INT
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static bool NODE_IS_INT(NodeType flags) 
        {  
            return (NODE_TYPE(flags) == CvConst.CV_NODE_INT);
        }
        #endregion
        #region NODE_IS_REAL
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static bool NODE_IS_REAL(NodeType flags)
        {
            return (NODE_TYPE(flags) == CvConst.CV_NODE_REAL);
        }
        #endregion
        #region NODE_IS_STRING
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static bool NODE_IS_STRING(NodeType flags)
        {
            return (NODE_TYPE(flags) == CvConst.CV_NODE_STRING);
        }
        #endregion
        #region NODE_IS_SEQ
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static bool NODE_IS_SEQ(NodeType flags)   
        {
            return (NODE_TYPE(flags) == CvConst.CV_NODE_SEQ);
        }
        #endregion
        #region NODE_IS_MAP
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static bool NODE_IS_MAP(NodeType flags)   
        {
            return (NODE_TYPE(flags) == CvConst.CV_NODE_MAP);
        }
        #endregion
        #region NODE_IS_COLLECTION
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static bool NODE_IS_COLLECTION(NodeType flags)
        {
            return (NODE_TYPE(flags) >= CvConst.CV_NODE_SEQ);
        }
        #endregion
        #region NODE_IS_FLOW
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static bool NODE_IS_FLOW(NodeType flags)    
        {
            return (((int)flags & CvConst.CV_NODE_FLOW) != 0);
        }
        #endregion
        #region NODE_IS_EMPTY
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static bool NODE_IS_EMPTY(NodeType flags)   
        {
            return (((int)flags & CvConst.CV_NODE_EMPTY) != 0);
        }
        #endregion
        #region NODE_IS_USER
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static bool NODE_IS_USER(NodeType flags)    
        {
            return (((int)flags & CvConst.CV_NODE_USER) != 0);
        }
        #endregion
        #region NODE_HAS_NAME
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static bool NODE_HAS_NAME(NodeType flags)   
        {
            return (((int)flags & CvConst.CV_NODE_NAMED) != 0);
        }
        #endregion
        #region PREV_SEQ_ELEM
#if LANG_JP
        /// <summary>
        /// 前のシーケンスへ
        /// </summary>
        /// <param name="elemSize"></param>
        /// <param name="reader"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemSize"></param>
        /// <param name="reader"></param>
#endif
        public static void PREV_SEQ_ELEM(int elemSize, CvSeqReader reader)
        {
            reader.Ptr = new IntPtr(reader.Ptr.ToInt64() - elemSize);
            if (reader.Ptr.ToInt64() < reader.BlockMin.ToInt64())
            {
                NativeMethods.cvChangeSeqBlock(reader.CvPtr, -1);
            }
        }
        #endregion
        #region READ_SEQ_ELEM
#if LANG_JP
        /// <summary>
        /// シーケンスの要素を一つ読みだして、読み出しポインタを次へ1つ移動させる
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="reader"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elem"></param>
        /// <param name="reader"></param>
#endif
        public static void READ_SEQ_ELEM<T>(out T elem, CvSeqReader reader) where T : struct
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            //Type t = typeof(t);
            //if (t.IsValueType)
            {
                using (StructurePointer<T> elemPtr = new StructurePointer<T>())
                {
                    if (reader.Seq.ElemSize != elemPtr.Size)
                    {
                        throw new OpenCvSharpException();
                    }

                    Util.CopyMemory(elemPtr.Ptr, reader.Ptr, elemPtr.Size);
                    NEXT_SEQ_ELEM(elemPtr.Size, reader);

                    elem = elemPtr.ToStructure();
                }
            }
            /*
            else
            {
                IntPtr elemPtr;
                READ_SEQ_ELEM<IntPtr>(out elemPtr, reader);
                elem = Util.ToObject<t>(elemPtr);
            }
            //*/
        }
        #endregion
        #region REV_READ_SEQ_ELEM
#if LANG_JP
        /// <summary>
        /// シーケンスの要素を一つ読みだして、読み出しポインタを次へ1つ移動させる
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="reader"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elem"></param>
        /// <param name="reader"></param>
#endif
        public static void REV_READ_SEQ_ELEM<T>(out T elem, CvSeqReader reader) where T : struct
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            //Type t = typeof(t);
            //if (t.IsValueType)
            {
                using (StructurePointer<T> elemPtr = new StructurePointer<T>())
                {
                    if (reader.Seq.ElemSize != elemPtr.Size)
                    {
                        throw new OpenCvSharpException();
                    }

                    Util.CopyMemory(elemPtr.Ptr, reader.Ptr, elemPtr.Size);
                    PREV_SEQ_ELEM(elemPtr.Size, reader);

                    elem = elemPtr.ToStructure();
                }
            }
            /*
            else
            {
                IntPtr elemPtr;
                REV_READ_SEQ_ELEM<IntPtr>(out elemPtr, reader);
                elem = Util.ToObject<t>(elemPtr);
            }
            //*/
        }
        #endregion
        #region RGB
#if LANG_JP
        /// <summary>
        /// カラー値を作成する
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs a color value
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
#endif
        public static CvScalar RGB(int r, int g, int b)
        {
            return new CvScalar(b, g, r);
        }
        #endregion
        #region SUBDIV2D_NEXT_EDGE
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
#endif
        public static CvSubdiv2DEdge SUBDIV2D_NEXT_EDGE(CvSubdiv2DEdge edge)
        {
            unsafe
            {
                ulong edgeValue = (ulong)edge;
                WCvQuadEdge2D* ptr = (WCvQuadEdge2D*)((long)edgeValue & ~3L);
                int edge3 = (int)(edgeValue & 3);
                return new CvSubdiv2DEdge(ptr->next(edge3));
            }
        }
        #endregion
        #region SWAP
#if LANG_JP
        /// <summary>
        /// 2つの引数の値を入れ替える (OpenCV準拠版)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
#endif
        public static void SWAP(ref object a, ref object b)
        {
            object t = a;
            a = b;
            b = t;
        }
#if LANG_JP
        /// <summary>
        /// 2つの引数の値を入れ替える (ジェネリック版)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
#endif
        public static void SWAP<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        #endregion
        #region WRITE_SEQ_ELEM_VAR
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemPtr"></param>
        /// <param name="writer"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemPtr"></param>
        /// <param name="writer"></param>
#endif
        public static void WRITE_SEQ_ELEM_VAR(IntPtr elemPtr, CvSeqWriter writer)
        {
            int elemSize = writer.Seq.ElemSize;
            if (writer.Ptr.ToInt64() >= writer.BlockMax.ToInt64())
            {
                NativeMethods.cvCreateSeqBlock(writer.CvPtr);
            }
            Util.CopyMemory(writer.Ptr, elemPtr, elemSize);
            writer.Ptr = new IntPtr(writer.Ptr.ToInt64() + elemSize);
        }
        #endregion
        #region WRITE_SEQ_ELEM
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elem"></param>
        /// <param name="writer"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elem"></param>
        /// <param name="writer"></param>
#endif
        public static void WRITE_SEQ_ELEM<T>(T elem, CvSeqWriter writer) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            if (writer.Seq.ElemSize != size)
                throw new OpenCvSharpException();
            
            if (writer.Ptr.ToInt64() >= writer.BlockMax.ToInt64())
            {
                NativeMethods.cvCreateSeqBlock(writer.CvPtr);
            }

            if (writer.Ptr.ToInt64() > writer.BlockMax.ToInt64() - size)
                throw new OpenCvSharpException();
            
            using (var elemPtr = new StructurePointer<T>(elem))
            {
                Util.CopyMemory(writer.Ptr, elemPtr, size);
            }
            writer.Ptr = new IntPtr(writer.Ptr.ToInt64() + size);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elem"></param>
        /// <param name="writer"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elem"></param>
        /// <param name="writer"></param>
#endif
        public static void WRITE_SEQ_ELEM<T>(T elem, CvSeqWriter<T> writer) where T : struct
        {
            WRITE_SEQ_ELEM(elem, (CvSeqWriter)writer);
        }
        #endregion     
    }
}
