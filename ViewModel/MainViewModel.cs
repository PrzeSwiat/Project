using System.Windows;
using Model;
using ViewModel;
using static Logika.LogicApi;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string _spheresAmount;
        public RelayCommand _summon { get; }
        public RelayCommand _pause { get; }
        public RelayCommand _resume { get; }

        public bool _summonFlag = true;
        public bool _resumeFlag = false;
        public bool _pauseFlag = false;

        public DataStore _DataStore { get; }

        public int _width { get; }
        public int _height { get; }

        public MainViewModel()
        {
            _width = 800;
            _height = 500;
            _spheresAmount = "";
            _summon = new RelayCommand(Summon, SummonProperties);
            _resume = new RelayCommand(Resume, ResumeProperties);
            _pause = new RelayCommand(Pause, PauseProperties);
            _DataStore = new DataStore(_width, _height);
            SummonFlag = true;
            ResumeFlag = false;
            PauseFlag = false;
        }

        public string SpheresAmount
        {
            get => _spheresAmount;
            set
            {
                _spheresAmount = value;
                OnPropertyChanged();
            }
        }

        public bool SummonFlag
        {
            get => _summonFlag;

            set
            {
                _summonFlag = value;
                _summon.OnCanExecuteChanged();
            }
        }

        public bool ResumeFlag
        {
            get => _resumeFlag;

            set
            {
                _resumeFlag = value;
                _resume.OnCanExecuteChanged();
            }
        }

        public bool PauseFlag
        {
            get => _pauseFlag;

            set
            {
                _pauseFlag = value;
                _pause.OnCanExecuteChanged();
            }
        }

        public Object[]? GetSpheres { get => _DataStore.GetSpheres().ToArray(); }

        public void Summon()
        {
            try
            {
                int numberOfSpheres = int.Parse(_spheresAmount);

                if (numberOfSpheres < 1)
                {
                    throw new ArgumentException("Number of Spheres is less than 1");
                }

                _DataStore.CreateSpheres(numberOfSpheres);
                OnPropertyChanged("GetSpheres");
                SummonFlag = false;
                ResumeFlag = true;
                Tick();
            }
            catch (Exception)
            {
                SpheresAmount = "";
            }
        }
        public async void Tick()
        {
            while (true)
            {
                await Task.Delay(10);
                OnPropertyChanged("GetSpheres");
            }
        }

        public void Resume()
        {
            PauseFlag = true;
            ResumeFlag = false;
            Tick();
        }

        public void Pause()
        {
            ResumeFlag = true;
            PauseFlag = false;
        }

        private bool SummonProperties()
        {
            return SummonFlag;
        }
        private bool ResumeProperties()
        {
            return ResumeFlag;
        }

        private bool PauseProperties()
        {
            return PauseFlag;
        }
    }
}
