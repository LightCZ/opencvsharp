using System;

namespace OpenCvSharp2.CPlusPlus.Gpu
{
#pragma warning disable 1591

    [Flags]
    public enum CudaMemAllocType
    {
        Locked = 1,
        ZeroCopy = 2,
        WhiteCombined = 4
    }
}