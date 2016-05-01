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
        private string m_ScriptTitle;
        private string m_ScriptTextColor;
        private string m_ScriptBgColor;
        private string m_ScriptWorkingDirectory;
        private int m_ScriptMajorVersion = 1;
        private int m_ScriptMinorVersion = 0;
        private string m_DriverName;
        private string m_DriverDirectory;
        private string m_DriverTargetExec;
        private string m_DriverExecSwitches;
        private string m_SaveName;
        private string m_SaveDirectory;
        private IList<string> m_Colors;
        private IList<DriverEntity> m_DriversToAdd = new List<DriverEntity>();
        #endregion

        #region Public Data Members
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

        public string ScriptTextColor
        {
            get { return m_ScriptTextColor; }

            set
            {
                if (value != m_ScriptTextColor)
                {
                    m_ScriptTextColor = value;
                    NotifyPropertyChanged("ScriptTextColor");
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

        public string ScriptWorkingDirectory
        {
            get { return m_ScriptWorkingDirectory; }

            set
            {
                if (value != m_ScriptWorkingDirectory)
                {
                    m_ScriptWorkingDirectory = value;
                    NotifyPropertyChanged("ScriptWorkingDirectory");
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

        public string DriverName
        {
            get { return m_DriverName; }

            set
            {
                if (value != m_DriverName)
                {
                    m_DriverName = value;
                    NotifyPropertyChanged("DriverName");
                }
            }
        }

        public string DriverDirectory
        {
            get { return m_DriverDirectory; }

            set
            {
                if (value != m_DriverDirectory)
                {
                    m_DriverDirectory = value;
                    NotifyPropertyChanged("DriverDirectory");
                }
            }
        }

        public string DriverTargetExec
        {
            get { return m_DriverTargetExec; }

            set
            {
                if (value != m_DriverTargetExec)
                {
                    m_DriverTargetExec = value;
                    NotifyPropertyChanged("DriverTargetExec");
                }
            }
        }

        public string DriverExecSwitches
        {
            get { return m_DriverTargetExec; }

            set
            {
                if (value != m_DriverExecSwitches)
                {
                    m_DriverExecSwitches = value;
                    NotifyPropertyChanged("DriverExecSwitches");
                }
            }
        }

        public string SaveName
        {
            get { return m_SaveName; }

            set
            {
                if (value != m_SaveName)
                {
                    m_SaveName = value;
                    NotifyPropertyChanged("SaveName");
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

        public IList<string> Colors
        {
            get
            {
                if (m_Colors == null)
                {
                    m_Colors = GetColors();
                }
     
                return m_Colors;
            }
        }

        public IList<DriverEntity> DriversToAdd
        {
            get { return m_DriversToAdd; }

            set
            {
                if (value != m_DriversToAdd)
                {
                    m_DriversToAdd = value;
                    NotifyPropertyChanged("DriversToAdd");
                }
            }
        }
        #endregion

        #region Private Methods
        private IList<string> GetColors()
        {
            IList<string> colors = new List<string>();

            foreach (var c in Enum.GetValues(typeof(ScriptColor)))
            {
                colors.Add(c.ToString());
            }

            return colors;
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        #endregion

        #region Entity Classes
        public class DriverEntity
        {
            public string Name { get; set; }
            public string Directory { get; set; }
            public string Executable { get; set; }
            public string Switches { get; set; }
        }
        #endregion

        private enum ScriptColor
        {
            Black = '0',
            Blue = '1',
            Green = '2',
            Aqua = '3',
            Red = '4',
            Purple = '5',
            Yellow = '6',
            White = '7',
            Gray = '8',
            LightBlue = '9',
            LightGreen = 'A',
            LightAqua = 'B',
            LightRed = 'C',
            LightPurple = 'D',
            LightYellow = 'E',
            BrightWhite = 'F'
        }

        //Code for getting character associated with each value
        //ScriptColor sc = (ScriptColor)Enum.Parse(typeof(ScriptColor), value);
        //System.Windows.MessageBox.Show(((char)sc).ToString());
    }
}
