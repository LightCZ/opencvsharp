using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591
// ReSharper disable once InconsistentNaming

namespace OpenCvSharp2.CPlusPlus
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvDTreeSplit
    {
        public int var_idx;
        public int inversed;
        public float quality;
        public void* next;
        public fixed int subset[2];
    }

#if LANG_JP
    /// <summary>
    /// ����؃m�[�h�̕���
    /// </summary>
#else
	/// <summary>
    /// Decision tree node split
    /// </summary>
#endif
	public class CvDTreeSplit : CvObject
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
		public CvDTreeSplit(IntPtr ptr)
            : base(ptr)
		{
		}

		#region Properties

#if LANG_JP
		/// <summary>
		/// ����ŗp������ϐ��̃C���f�b�N�X�D
		/// </summary>
#else
		/// <summary>
		/// Index of the variable used in the split 
		/// </summary>
#endif
		public int VarIdx
		{
			get
            { 
                unsafe
                {
                    return ((WCvDTreeSplit*)ptr)->var_idx;
                }
            }
		}

#if LANG_JP
		/// <summary>
		/// true�̏ꍇ�C�t����K�����p������i�܂荶�E�̎}�����������j�D 
		/// </summary>
#else
		/// <summary>
		/// When true, the inverse split rule is used (i.e. left and right branches are exchanged in the expressions below) 
		/// </summary>
#endif
		public bool Inversed
		{
			get
            {
                unsafe
                {
                    return ((WCvDTreeSplit*)ptr)->inversed != 0;
                }
            }
		}

#if LANG_JP
		/// <summary>
		/// ���̐��ŕ\������镪��̃N�I���e�B�D
		/// ����͍ł��d�v�ȕ���̑I���C�㗝����̑I���E�\�[�g�ɗp������D
		/// �؂��\�����ꂽ��́C�ϐ��̏d�v�x���v�Z���邽�߂ɗp������D  
		/// </summary>
#else
		/// <summary>
		/// The split quality, a positive number. 
		/// It is used to choose the best primary split, then to choose and sort the surrogate splits. 
		/// After the tree is constructed, it is also used to compute variable importance.  
		/// </summary>
#endif
		public float Quality
		{
			get
            { 
                unsafe
                {
                    return ((WCvDTreeSplit*)ptr)->quality;
                }
            }
		}

		
#if LANG_JP
		/// <summary>
		/// �m�[�h���򃊃X�g���̎��̕���ւ̃|�C���^.  
		/// </summary>
#else
		/// <summary>
		/// Pointer to the next split in the node split list. 
		/// </summary>
#endif
		public CvDTreeSplit Next
		{
			get
			{ 
                unsafe
                {
				    IntPtr p = new IntPtr(((WCvDTreeSplit*)ptr)->next);
				    if(p == IntPtr.Zero)
					    return null;
				    return new CvDTreeSplit(p);
                }
			}
		}

#if LANG_JP
		/// <summary>
		/// �J�e�S���ϐ��ɑ΂��镪��̏ꍇ�C�����W����\���r�b�g�z��D
		/// var_value �� subset �ɑ�����ꍇ next_node&lt;-left �C�����łȂ��ꍇ next_node&lt;-right�D  
		/// </summary>
#else
		/// <summary>
		/// Bit array indicating the value subset in case of split on a categorical variable.
		/// The rule is: if var_value in subset then next_node&lt;-left else next_node&lt;-right
		/// </summary>
#endif
		public PointerAccessor1D_Int32 Subset
		{
			get
			{
                unsafe
                {
                    int* subset = ((WCvDTreeSplit*)ptr)->subset;
                    return new PointerAccessor1D_Int32(subset);
                }				
			}
		}
 
#if LANG_JP
		/// <summary>
		/// �A���ϐ��ɑ΂��镪��̏ꍇ�C臒l�D
		/// var_value &lt; c �̏ꍇ next_node&lt;-left �C�����łȂ��ꍇ next_node&lt;-right�D  
		/// </summary>
#else
		/// <summary>
		/// The threshold value in case of split on an ordered variable.
		/// The rule is: if var_value &lt; c then next_node&lt;-left else next_node&lt;-right
		/// </summary>
#endif
		public float OrdC
		{
			get
            {
                unsafe
                {
                    int value = ((WCvDTreeSplit*)ptr)->subset[0];
                    return BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
                }
            }
		}

		 
#if LANG_JP
		/// <summary>
		/// �w�K�A���S���Y���œ����I�ɗ��p�����D 
		/// </summary>
#else
		/// <summary>
		/// Used internally by the training algorithm. 
		/// </summary>
#endif
		public int OrdSplitPoint
		{
			get
            {
                unsafe
                {
                    return ((WCvDTreeSplit*)ptr)->subset[1];
                }
            }
		}
		#endregion
	}
}
