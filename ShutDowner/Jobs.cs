﻿using System;
using System.Management;

namespace ShutDowner
{
    internal static class Jobs
    {
        public static void ShutDown()
        {
            if (BabilinaTime()) return;

            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                     mcWin32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            mboShutdownParams["Flags"] = "1";
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                               mboShutdownParams, null);
            }
        }

        private static bool BabilinaTime()
        {
            (int hour, int minute) = (DateTime.Now.Hour, DateTime.Now.Minute);

            return hour == 14 && minute < 59;
        }
    }
}
