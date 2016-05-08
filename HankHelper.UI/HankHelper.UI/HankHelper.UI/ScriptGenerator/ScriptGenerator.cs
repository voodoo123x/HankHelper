using HankHelper.UI.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HankHelper.UI.ScriptGenerator
{
    public class ScriptGenerator
    {
        #region Singleton Data Members
        private static ScriptGenerator m_Instance;

        public static ScriptGenerator Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ScriptGenerator();
                }

                return m_Instance;
            }
        }

        public bool GenerateScript(IList<DriverEntity> Drivers, string ScriptModel, string SaveName, string SaveLocation, string WorkingDirectory, int ScriptMajorVersion = 1, int ScriptMinorVersion = 0, string ScriptColors = "07")
        {
            bool success = true;
            string localSaveName = SaveLocation.EndsWith("\\") ? SaveLocation : string.Format(@"{0}\", SaveLocation);
            string fullSavePath = string.Format("{0}{1}", localSaveName, SaveName);
            string localWorkingDirectory = WorkingDirectory.EndsWith("\\") ? WorkingDirectory : string.Format(@"{0}\", WorkingDirectory);
            StringBuilder builder = new StringBuilder();

            try
            {

                // Create the header information
                builder.AppendLine(string.Format("::Driver installation script for {0}", ScriptModel));
                builder.AppendLine(string.Format("::Generated on {0}", DateTime.Now.ToShortDateString()));
                builder.AppendLine();

                // Set colors and working directory
                builder.AppendLine("@echo off");
                builder.AppendLine("cls");
                builder.AppendLine(string.Format("color {0}", ScriptColors));
                builder.AppendLine("cd /D c:");
                builder.AppendLine(string.Format("set wd={0}", localWorkingDirectory));
                builder.AppendLine();

                // Set window title and output header info to screen
                builder.AppendLine(string.Format("title {0} Driver Install", ScriptModel));
                builder.AppendLine(string.Format("echo {0} Driver Install", ScriptModel));
                builder.AppendLine(string.Format("echo Version {0}.{1}", ScriptMajorVersion, ScriptMinorVersion));
                builder.AppendLine(string.Format("echo."));
                builder.AppendLine();

                // Generate each driver install code block
                foreach (var dr in Drivers)
                {
                    builder.AppendLine(string.Format("echo Installing {0}...", dr.Name));
                    builder.AppendLine(string.Format("cd %wd%{0}", dr.Directory));
                    builder.AppendLine(string.Format("call {0} {1}", dr.Executable, dr.Switches));
                    builder.AppendLine(string.Format("echo complete!"));
                    builder.AppendLine("echo.");
                    builder.AppendLine();
                }


                // Add display message to inform user driver installation is complete
                builder.AppendLine("echo Driver installation complete!");
                builder.AppendLine("echo.");
                builder.AppendLine();
                builder.AppendLine("timeout 15");

                StreamWriter writer = new StreamWriter(fullSavePath);
                writer.Write(builder.ToString());
                writer.Close();
            }
            catch
            {
                success = false;
            }

            return success;
        }
        #endregion
    }
}
