using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace StreamTest
{
    public class DriverInfoTest
    {
        public void ConsoleS()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    WriteLine($"Drive name: {drive.Name}");
                    WriteLine($"Format: {drive.DriveFormat}");
                    WriteLine($"Type: {drive.DriveType}");
                    WriteLine($"Root directory: {drive.RootDirectory}");
                    WriteLine($"Volume label: {drive.VolumeLabel}");
                    WriteLine($"Free space: {drive.TotalFreeSpace}");
                    WriteLine($"Available space: {drive.AvailableFreeSpace}");
                    WriteLine($"Total size: {drive.TotalSize}");

                    WriteLine();

                }
            }
        }

    }
}
