﻿using System;

namespace OpenCvSharp2.CPlusPlus
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// ML 統計モデルのための基本クラス
    /// </summary>
#else
	/// <summary>
    /// Base class for statistical models in ML
    /// </summary>
#endif
    abstract public class CvStatModel : DisposableCvObject
	{
	    private bool disposed;

		#region Constants
#pragma warning disable 1591
		public const int CV_VAR_NUMERICAL    = 0;
		public const int CV_VAR_ORDERED      = 0;
		public const int CV_VAR_CATEGORICAL  = 1;

		public const string CV_TYPE_NAME_ML_SVM = "opencv-ml-svm";
		public const string CV_TYPE_NAME_ML_KNN = "opencv-ml-knn";
		public const string CV_TYPE_NAME_ML_NBAYES = "opencv-ml-bayesian";
		public const string CV_TYPE_NAME_ML_EM = "opencv-ml-em";
		public const string CV_TYPE_NAME_ML_BOOSTING = "opencv-ml-boost-tree";
		public const string CV_TYPE_NAME_ML_TREE =  "opencv-ml-tree";
		public const string CV_TYPE_NAME_ML_ANN_MLP = "opencv-ml-ann-mlp";
		public const string CV_TYPE_NAME_ML_CNN = "opencv-ml-cnn";
		public const string CV_TYPE_NAME_ML_RTREES = "opencv-ml-random-trees";
#pragma warning restore 1591
        #endregion

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        protected CvStatModel()
        {
            disposed = false;
        }

        /// <summary>
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
                base.Dispose(disposing);
            }
        }

        #endregion

        #region Methods
#if LANG_JP
        /// <summary>
        /// メモリを解放し，モデルの状態をリセットする
        /// </summary>
#else
        /// <summary>
        /// Deallocates memory and resets the model state
        /// </summary>
#endif
        public virtual void Clear()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.ml_CvStatModel_clear(ptr);
        }

#if LANG_JP
        /// <summary>
        /// モデルをファイルに保存する
        /// </summary>
        /// <param name="filename"></param>
#else
		/// <summary>
        /// Saves the model to file
        /// </summary>
        /// <param name="filename"></param>
#endif
        public virtual void Save(string filename)
        {
            Save(filename, null);
        }
#if LANG_JP
        /// <summary>
        /// モデルをファイルに保存する
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="name"></param>
#else
		/// <summary>
        /// Saves the model to file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="name"></param>
#endif
        public virtual void Save(string filename, string name)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");

            NativeMethods.ml_CvStatModel_save(ptr, filename, name);
        }

#if LANG_JP
        /// <summary>
        /// ファイルからモデルを読み込む
        /// </summary>
        /// <param name="filename"></param>
#else
		/// <summary>
        /// Loads the model from file
        /// </summary>
        /// <param name="filename"></param>
#endif
        public virtual void Load(string filename)
        {
            Load(filename, null);
        }
#if LANG_JP
        /// <summary>
        /// ファイルからモデルを読み込む
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="name"></param>
#else
		/// <summary>
        /// Loads the model from file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="name"></param>
#endif
        public virtual void Load(string filename, string name)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");

            NativeMethods.ml_CvStatModel_load(ptr, filename, name);
        }

#if LANG_JP
        /// <summary>
        /// モデルをファイルに書き込む
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="name"></param>
#else
	    /// <summary>
	    /// Writes the model to file storage
	    /// </summary>
	    /// <param name="storage"></param>
	    /// <param name="name"></param>
#endif
	    public virtual void Write(CvFileStorage storage, string name)
	    {
            // OPENCV_ERROR( CV_StsNotImplemented, "CvStatModel::write", "" );
	        throw new NotImplementedException();
	    }

#if LANG_JP
        /// <summary>
        /// ファイルストレージからモデルを読み込む
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="node"></param>
#else
		/// <summary>
        /// Reads the model from file storage
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="node"></param>
#endif
        public virtual void Read(CvFileStorage storage, CvFileNode node)
        {
            // OPENCV_ERROR( CV_StsNotImplemented, "CvStatModel::read", "" );
            throw new NotImplementedException();
        }
        #endregion
    }
}
