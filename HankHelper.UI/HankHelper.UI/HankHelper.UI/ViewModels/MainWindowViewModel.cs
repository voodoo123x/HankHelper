using GalaSoft.MvvmLight.CommandWpf;
using HankHelper.UI.Entities;
using HankHelper.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HankHelper.UI
{
    public class MainWindowViewModel : BasePropertyChanged, INotifyPropertyChanged
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
        private DriverEntity m_SelectedDriver;
        private IList<string> m_Colors;
        private ObservableCollection<DriverEntity> m_DriversToAdd = new ObservableCollection<DriverEntity>();
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
            get { return m_DriverExecSwitches; }

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

        public DriverEntity SelectedDriver
        {
            get { return m_SelectedDriver; }

            set
            {
                if (value != m_SelectedDriver)
                {
                    m_SelectedDriver = value;
                    NotifyPropertyChanged("SelectedDriver");
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

        public ObservableCollection<DriverEntity> DriversToAdd
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

        #region Commands
        #region AddDriverCommand
        private RelayCommand<object> m_AddDriverCommand;

        public RelayCommand<object> AddDriverCommand
        {
            get
            {
                if (m_AddDriverCommand == null)
                {
                    m_AddDriverCommand = new RelayCommand<object>(OnAddDriver, CanAddDriver);
                }

                return m_AddDriverCommand;
            }
        }

        public bool CanAddDriver(object param)
        {
            return (   !string.IsNullOrEmpty(DriverName)
                    && !string.IsNullOrEmpty(DriverDirectory)
                    && !string.IsNullOrEmpty(DriverTargetExec));
        }

        public void OnAddDriver(object param)
        {
            DriversToAdd.Add(new DriverEntity
            {
                Name = DriverName,
                Directory = DriverDirectory,
                Executable = DriverTargetExec,
                Switches = DriverExecSwitches
            });

            DriverName = string.Empty;
            DriverDirectory = string.Empty;
            DriverTargetExec = string.Empty;
            DriverExecSwitches = string.Empty;
        }
        #endregion

        #region RemoveDriverCommand
        private RelayCommand<object> m_RemoveDriverCommand;

        public RelayCommand<object> RemoveDriverCommand
        {
            get
            {
                if (m_RemoveDriverCommand == null)
                {
                    m_RemoveDriverCommand = new RelayCommand<object>(OnRemoveDriver, CanRemoveDriver);
                }

                return m_RemoveDriverCommand;
            }
        }

        public bool CanRemoveDriver(object param)
        {
            return (SelectedDriver != null);
        }

        public void OnRemoveDriver (object param)
        {
            DriversToAdd.Remove(SelectedDriver);
        }
        #endregion

        #region BrowseDirectoryCommand
        private RelayCommand<object> m_BrowseDirectoryCommand;

        public RelayCommand<object> BrowseDirectoryCommand
        {
            get
            {
                if (m_BrowseDirectoryCommand == null)
                {
                    m_BrowseDirectoryCommand = new RelayCommand<object>(OnBrowseDirectory);
                }

                return m_BrowseDirectoryCommand;
            }
        }

        public void OnBrowseDirectory(object param)
        {
            FolderBrowserDialog browseDialog = new FolderBrowserDialog();

            if (browseDialog.ShowDialog() == DialogResult.OK)
            {
                SaveDirectory = browseDialog.SelectedPath;
            }
        }
        #endregion

        #region GenerateScriptCommand
        private RelayCommand<object> m_GenerateScriptCommand;

        public RelayCommand<object> GenerateScriptCommand
        {
            get
            {
                if (m_GenerateScriptCommand == null)
                {
                    m_GenerateScriptCommand = new RelayCommand<object>(OnGenerateScript, CanGenerateScript);
                }

                return m_GenerateScriptCommand;
            }
        }

        public bool CanGenerateScript(object param)
        {
            return (!string.IsNullOrEmpty(ScriptTitle)
                && !string.IsNullOrEmpty(SaveName)
                && !string.IsNullOrEmpty(SaveDirectory));
        }

        public void OnGenerateScript(object param)
        {
            
        }
        #endregion
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
