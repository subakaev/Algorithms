using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Algorithms.Common;
using Algorithms.Sort;
using Wpf.Gui.Data;
using Wpf.Utils;

namespace Wpf.Gui
{
    class MainWindowViewModel : ViewModelBase
    {
        public int ElementsCount { get; set; } = 50;

        public int Delay { get; set; } = 10;

        public event EventHandler GraphicsChanged;

        public ICommand StartStopCommand { get; }

        public ICommand NextStepCommand { get; }

        public ICommand GenerateCommand { get; }

        public ICommand ChangeSortDirectionCommand { get; }

        private int[] data;

        public int[] Data {
            get => data;
            set {
                data = value;
                OnPropertyChanged(() => Data);
            }
        }

        private bool isStarted;

        public bool IsStarted {
            get => isStarted;
            set {
                isStarted = value;
                OnPropertyChanged(() => IsStarted);
            }
        }

        private int selectedIndex;

        public int SelectedIndex {
            get => selectedIndex;
            set {
                selectedIndex = value;
                OnPropertyChanged(() => selectedIndex);
            }
        }

        private ListSortDirection direction;

        public ListSortDirection Direction {
            get => direction;
            set {
                direction = value;
                OnPropertyChanged(() => Direction);
            }
        }

        private SortAlgorithmType sortAlgorithm = SortAlgorithmType.Bubble;

        public SortAlgorithmType SortAlgorithm {
            get => sortAlgorithm;
            set {
                sortAlgorithm = value;
                OnPropertyChanged(() => sortAlgorithm);
            }
        }

        public bool CanStart => !SortUtils.IsSorted(Data, Direction);

        private Task calculationTask;

        private readonly AutoResetEvent stepEvent = new AutoResetEvent(false);

        private bool isCancelling;

        private bool isSortStarted;

        public bool IsSortStarted {
            get => isSortStarted;
            set {
                isSortStarted = value;
                OnPropertyChanged(() => IsSortStarted);
            }
        }

        public MainWindowViewModel() {
            Genetate();

            GenerateCommand = new RelayCommand(Genetate);

            StartStopCommand = new RelayCommand(Start);

            NextStepCommand = new RelayCommand(NextStep);

            ChangeSortDirectionCommand = new RelayCommand(() => {
                OnPropertyChanged(() => CanStart);
            });
        }

        private void Start() {
            IsStarted = !IsStarted;

            if (!isStarted) 
                return;

            StartSort();
        }

        private void NextStep() {
            if (!IsSortStarted)
                StartSort();

            stepEvent.Set();
        }

        private void StartSort() {
            if (IsSortStarted) {
                stepEvent.Set();
                return;
            }

            var algorithm = SortAlgorithmFactory.Get<int>(SortAlgorithm, ProgressAction);

            calculationTask = Task.Factory.StartNew(() => { algorithm.Sort(Data, Direction); })
                .ContinueWith(task => { CompleteSort(); });

            IsSortStarted = true;
        }

        private void ProgressAction(int index, int[] array = null) {
            if (isCancelling)
                return;

            if (array != null)
                Data = array;

            SelectedIndex = index;

            RaiseGraphicsChagned();

            if (isStarted)
                stepEvent.WaitOne(Delay);
            else
                stepEvent.WaitOne();
        }

        private void Genetate() {
            if (!calculationTask?.IsCompleted ?? false) {
                isCancelling = true;
                stepEvent.Set();
                calculationTask?.Wait();
            }

            SelectedIndex = -1;

            Data = ArrayGenerator.Generate(ElementsCount, false, 1, ElementsCount + 1);

            OnPropertyChanged(() => CanStart);

            IsSortStarted = false;

            RaiseGraphicsChagned();
        }

        private void CompleteSort() {
            IsSortStarted = false;
            IsStarted = false;
            
            OnPropertyChanged(() => CanStart);

            if (!isCancelling)
                RaiseGraphicsChagned();

            isCancelling = false;
        }

        private void RaiseGraphicsChagned() {
            GraphicsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}