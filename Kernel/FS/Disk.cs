/*
 * Copyright(c) 2022 nifanfa, This code is part of the Moos licensed under the MIT licence.
 */
namespace Kernel.FS
{
    public abstract unsafe class Disk
    {
        public static Disk Instance;

        public Disk()
        {
            Instance = this;
        }

        public abstract bool Read(ulong sector, uint count, byte* data);
        public abstract bool Write(ulong sector, uint count, byte* data);
    }
}
