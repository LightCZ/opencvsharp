﻿using System;

namespace OpenCvSharp2.CPlusPlus.Gpu
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Gaussian Mixture-based Backbround/Foreground Segmentation Algorithm
    /// </summary>
    /// <remarks>
    /// The class implements the following algorithm:
    /// "Improved adaptive Gausian mixture model for background subtraction"
    /// Z.Zivkovic
    /// International Conference Pattern Recognition, UK, August, 2004.
    /// http://www.zoranz.net/Publications/zivkovic2004ICPR.pdf
    /// </remarks>
    public class MOG2_GPU : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal
        /// <summary>
        /// the default constructor
        /// </summary>
        /// <param name="nMixtures"></param>
        public MOG2_GPU(int nMixtures = -1)
        {
            Cv2Gpu.ThrowIfGpuNotAvailable();
            ptr = NativeMethods.gpu_MOG2_GPU_new(nMixtures);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (IsEnabledDispose)
                    {
                        NativeMethods.gpu_MOG2_GPU_delete(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int History
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    return *NativeMethods.gpu_MOG2_GPU_history(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    *NativeMethods.gpu_MOG2_GPU_history(ptr) = value;
                }
            }
        }

        /// <summary>
        /// The maximum allowed number of mixture components.
        /// Actual number is determined dynamically per pixel
        /// </summary>
        public float VarThreshold
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    return *NativeMethods.gpu_MOG2_GPU_varThreshold(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    *NativeMethods.gpu_MOG2_GPU_varThreshold(ptr) = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float BackgroundRatio
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    return *NativeMethods.gpu_MOG2_GPU_backgroundRatio(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    *NativeMethods.gpu_MOG2_GPU_backgroundRatio(ptr) = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float VarThresholdGen
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    return *NativeMethods.gpu_MOG2_GPU_varThresholdGen(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    *NativeMethods.gpu_MOG2_GPU_varThresholdGen(ptr) = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float VarInit
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    return *NativeMethods.gpu_MOG2_GPU_fVarInit(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    *NativeMethods.gpu_MOG2_GPU_fVarInit(ptr) = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float VarMin
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    return *NativeMethods.gpu_MOG2_GPU_fVarMin(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    *NativeMethods.gpu_MOG2_GPU_fVarMin(ptr) = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float VarMax
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    return *NativeMethods.gpu_MOG2_GPU_fVarMax(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    *NativeMethods.gpu_MOG2_GPU_fVarMax(ptr) = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float CT
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    return *NativeMethods.gpu_MOG2_GPU_fCT(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    *NativeMethods.gpu_MOG2_GPU_fCT(ptr) = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool DoShadowDetection
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.gpu_MOG2_GPU_bShadowDetection_get(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.gpu_MOG2_GPU_bShadowDetection_set(ptr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte ShadowDetection
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    return *NativeMethods.gpu_MOG2_GPU_nShadowDetection(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    *NativeMethods.gpu_MOG2_GPU_nShadowDetection(ptr) = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Tau
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    return *NativeMethods.gpu_MOG2_GPU_fTau(ptr);
                }
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                unsafe
                {
                    *NativeMethods.gpu_MOG2_GPU_fTau(ptr) = value;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// re-initiaization method
        /// </summary>
        public void Initialize(Size frameSize, int frameType)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.gpu_MOG2_GPU_initialize(ptr, frameSize, frameType);
        }

        /// <summary>
        /// the update operator [MOG_GPU::operator()]
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="fgmask"></param>
        /// <param name="learningRate"></param>
        /// <param name="stream"></param>
        public void Update(
            GpuMat frame, GpuMat fgmask, float learningRate = -1.0f, Stream stream = null)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (frame == null)
                throw new ArgumentNullException("frame");
            if (fgmask == null)
                throw new ArgumentNullException("fgmask");

            stream = stream ?? Stream.Null;

            NativeMethods.gpu_MOG2_GPU_operator(
                ptr, frame.CvPtr, fgmask.CvPtr, learningRate, stream.CvPtr);

            GC.KeepAlive(frame);
            GC.KeepAlive(fgmask);
            GC.KeepAlive(stream);
        }

        /// <summary>
        /// Computes a background image which are the mean of all background gaussians
        /// </summary>
        /// <param name="backgroundImage"></param>
        /// <param name="stream"></param>
        public void GetBackgroundImage(
            GpuMat backgroundImage, Stream stream = null)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (backgroundImage == null)
                throw new ArgumentNullException("backgroundImage");

            stream = stream ?? Stream.Null;

            NativeMethods.gpu_MOG2_GPU_getBackgroundImage(
                ptr, backgroundImage.CvPtr, stream.CvPtr);

            GC.KeepAlive(backgroundImage);
            GC.KeepAlive(stream);
        }

        /// <summary>
        /// releases all inner buffers
        /// </summary>
        public void Release()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.gpu_MOG2_GPU_release(ptr);
        }

        #endregion
    }
}
