/*
 * Copyright(c) 2022 nifanfa, This code is part of the Moos licensed under the MIT licence.
 */
namespace Kernel.Driver
{
    public static class Power
    {
        public static void Reboot()
        {
            //Use PS2 Controller To Reboot
            while ((Native.In8(0x64) & 0x02) != 0) ;
            Native.Out8(0x64, 0xFE);
            Native.Hlt();
        }

        public static void Shutdown()
        {
            ACPI.Shutdown();
        }
    }
}

