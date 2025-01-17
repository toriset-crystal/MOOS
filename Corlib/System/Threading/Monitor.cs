﻿#if Kernel
using Internal.Runtime.CompilerServices;
using Kernel;
using Kernel.Misc;

namespace System.Threading
{
    public static unsafe class Monitor
    {
        public static void Enter(object obj)
        {
            if (Unsafe.As<bool, ulong>(ref ThreadPool.Locked))
            {
                ThreadPool.Locked = true;
            }
        }

        public static void Exit(object obj)
        {
            if (Unsafe.As<bool, ulong>(ref ThreadPool.Locked))
            {
                ThreadPool.Locked = false;
            }
        }
    }
}
#endif