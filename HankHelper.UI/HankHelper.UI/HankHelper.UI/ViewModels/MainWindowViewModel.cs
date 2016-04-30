using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HankHelper.UI
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Private Data Members
        private string m_HardwareModel;
        private string m_WorkingDirectory;
        private string m_ScriptTitle;
        private string m_ScriptBgColor;
        private int m_ScriptMajorVersion = 1;
        private int m_ScriptMinorVersion = 0;
        private string m_ScriptTargetExec;
        private string m_ScriptExecSwitches;
        private string m_SaveDirectory;
        #endregion

        #region Public Data Members
        public string HardwareModel
        {
            get { return m_HardwareModel; }

            set
            {
                if (value != m_HardwareModel)
                {
                    m_HardwareModel = value;
                    NotifyPropertyChanged("HardwareModel");
                }
            }
        }

        public string WorkingDirectory
        {
            get { return m_WorkingDirectory; }

            set
            {
                if (value != m_WorkingDirectory)
                {
                    m_WorkingDirectory = value;
                    NotifyPropertyChanged("WorkingDirectory");
                }
            }
        }

        public string ScriptTitle
        {
            get { return m_ScriptTitle; }

            set
            {
                if (value != m_ScriptTitle)
                {
                    m_ScriptTitle = value;
                    NotifyPropertyChanged("ScriptTitle");
                }
            }
        }

        public string ScriptBgColor
        {
            get { return m_ScriptBgColor; }

            set
            {
                if (value != m_ScriptBgColor)
                {
                    m_ScriptBgColor = value;
                    NotifyPropertyChanged("ScriptBgColor");
                }
            }
        }

        public int ScriptMajorVersion
        {
            get { return m_ScriptMajorVersion; }

            set
            {
                if (value != m_ScriptMajorVersion)
                {
                    m_ScriptMajorVersion = value;
                    NotifyPropertyChanged("ScriptMajorVersion");
                }
            }
        }

        public int ScriptMinorVersion
        {
            get { return m_ScriptMinorVersion; }

            set
            {
                if (value != m_ScriptMinorVersion)
                {
                    m_ScriptMinorVersion = value;
                    NotifyPropertyChanged("ScriptMinorVersion");
                }
            }
        }

        public string SaveDirectory
        {
            get { return m_SaveDirectory; }

            set
            {
                if (value != m_SaveDirectory)
                {
                    m_SaveDirectory = value;
                    NotifyPropertyChanged("SaveDirectory");
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        #endregion

        #region Private Classes
        private class CodeBlockEntity
        {
            public string DriverName { get; set; }
            public string InstallCommand { get; set; }
        }
        #endregion
    }
}
