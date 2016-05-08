using HankHelper.UI.ViewModels;

namespace HankHelper.UI.Entities
{
    public class DriverEntity : BasePropertyChanged
    {
        private string m_Name;
        private string m_Directory;
        private string m_Executable;
        private string m_Switches;

        public string Name
        {
            get { return m_Name; }

            set
            {
                if (value != m_Name)
                {
                    m_Name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public string Directory
        {
            get { return m_Directory; }

            set
            {
                if (value != m_Directory)
                {
                    m_Directory = value;
                    NotifyPropertyChanged("Directory");
                }
            }
        }

        public string Executable
        {
            get { return m_Executable; }

            set
            {
                if (value != m_Executable)
                {
                    m_Executable = value;
                    NotifyPropertyChanged("Executable");
                }
            }
        }

        public string Switches
        {
            get { return m_Switches; }

            set
            {
                if (value != m_Switches)
                {
                    m_Switches = value;
                    NotifyPropertyChanged("Switches");
                }
            }
        }
    }
}
