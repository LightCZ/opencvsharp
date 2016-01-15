﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp2.CPlusPlus
{
    /// <summary>
    /// Principal Component Analysis
    /// </summary>
    public class PCA : DisposableCvObject
    {
        private bool disposed;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        public PCA()
        {
            ptr = NativeMethods.core_PCA_new1();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        /// <param name="maxComponents"></param>
        public PCA(InputArray data, InputArray mean, PCAFlag flags, int maxComponents = 0)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (mean == null)
                throw new ArgumentNullException("mean");
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            ptr = NativeMethods.core_PCA_new2(data.CvPtr, mean.CvPtr, (int)flags, maxComponents);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        /// <param name="retainedVariance"></param>
        public PCA(InputArray data, InputArray mean, PCAFlag flags, double retainedVariance)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (mean == null)
                throw new ArgumentNullException("mean");
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            ptr = NativeMethods.core_PCA_new3(data.CvPtr, mean.CvPtr, (int)flags, retainedVariance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (ptr != IntPtr.Zero)
                    {
                        NativeMethods.core_PCA_delete(ptr);
                        ptr = IntPtr.Zero;
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
        /// eigenvalues of the covariation matrix
        /// </summary>
        public Mat Eigenvectors
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("PCA");
                IntPtr ret = NativeMethods.core_PCA_eigenvectors(ptr);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// eigenvalues of the covariation matrix
        /// </summary>
        public Mat Eigenvalues
        {
            get
            {
                if(disposed)
                    throw new ObjectDisposedException("PCA");
                IntPtr ret = NativeMethods.core_PCA_eigenvalues(ptr);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// mean value subtracted before the projection and added after the back projection
        /// </summary>
        public Mat Mean
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("PCA");
                IntPtr ret = NativeMethods.core_PCA_mean(ptr);
                return new Mat(ret);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// operator that performs PCA. The previously stored data, if any, is released
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        /// <param name="maxComponents"></param>
        /// <returns></returns>
        public PCA Compute(InputArray data, InputArray mean, PCAFlag flags, int maxComponents = 0)
        {
            if (disposed)
                throw new ObjectDisposedException("PCA");
            if (data == null)
                throw new ArgumentNullException("data");
            if (mean == null)
                throw new ArgumentNullException("mean");
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            NativeMethods.core_PCA_operatorThis(ptr, data.CvPtr, mean.CvPtr, (int)flags, maxComponents);
            return this;
        }

        /// <summary>
        /// operator that performs PCA. The previously stored data, if any, is released
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        /// <param name="retainedVariance"></param>
        /// <returns></returns>
        public PCA ComputeVar(InputArray data, InputArray mean, PCAFlag flags, double retainedVariance)
        {
            if (disposed)
                throw new ObjectDisposedException("PCA");
            if (data == null)
                throw new ArgumentNullException("data");
            if (mean == null)
                throw new ArgumentNullException("mean");
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            NativeMethods.core_PCA_computeVar(ptr, data.CvPtr, mean.CvPtr, (int)flags, retainedVariance);
            return this;
        }

        /// <summary>
        /// projects vector from the original space to the principal components subspace
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public Mat Project(InputArray vec)
        {
            if (disposed)
                throw new ObjectDisposedException("PCA");
            if (vec == null)
                throw new ArgumentNullException("vec");
            vec.ThrowIfDisposed();
            IntPtr ret = NativeMethods.core_PCA_project(ptr, vec.CvPtr);
            return new Mat(ret);
        }
        /// <summary>
        /// projects vector from the original space to the principal components subspace
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="result"></param>
        public void Project(InputArray vec, OutputArray result)
        {
            if (disposed)
                throw new ObjectDisposedException("PCA");
            if (vec == null)
                throw new ArgumentNullException("vec");
            if (result == null)
                throw new ArgumentNullException("result");
            vec.ThrowIfDisposed();
            result.ThrowIfNotReady();
            NativeMethods.core_PCA_project(ptr, vec.CvPtr, result.CvPtr);
            result.Fix();
        }

        /// <summary>
        /// reconstructs the original vector from the projection
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public Mat BackProject(InputArray vec)
        {
            if (disposed)
                throw new ObjectDisposedException("PCA");
            if (vec == null)
                throw new ArgumentNullException("vec");
            vec.ThrowIfDisposed();
            IntPtr ret = NativeMethods.core_PCA_backProject(ptr, vec.CvPtr);
            return new Mat(ret);
        }
        /// <summary>
        /// reconstructs the original vector from the projection
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="result"></param>
        public void BackProject(InputArray vec, OutputArray result)
        {
            if (disposed)
                throw new ObjectDisposedException("PCA");
            if (vec == null)
                throw new ArgumentNullException("vec");
            if (result == null)
                throw new ArgumentNullException("result");
            vec.ThrowIfDisposed();
            result.ThrowIfNotReady();
            NativeMethods.core_PCA_backProject(ptr, vec.CvPtr, result.CvPtr);
            result.Fix();
        }
        #endregion
    }
}
