using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Algorithms.Common;
using Algorithms.Sort;
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

        public bool CanStart => !SortUtils.IsSorted(Data, ListSortDirection.Ascending);

        private Task calculationTask;

        private readonly AutoResetEvent stepEvent = new AutoResetEvent(false);

        private bool isCancelling;

        private bool isSortStarted;

        public MainWindowViewModel() {
            Genetate();

            GenerateCommand = new RelayCommand(Genetate);

            StartStopCommand = new RelayCommand(Start);

            NextStepCommand = new RelayCommand(NextStep);
        }

        private void Start() {
            IsStarted = !IsStarted;

            if (!isStarted) 
                return;

            StartSort();
        }

        private void NextStep() {
            if (!isSortStarted)
                StartSort();

            stepEvent.Set();
        }

        private void StartSort() {
            if (isSortStarted) {
                stepEvent.Set();
                return;
            }

            var algorithm = new BubbleSort<int>(ProgressAction);

            calculationTask = Task.Factory.StartNew(() => { algorithm.Sort(Data, ListSortDirection.Ascending); })
                .ContinueWith(task => CompleteSort());

            isSortStarted = true;
        }

        private void ProgressAction(int index) {
            if (isCancelling)
                return;

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

            Data = ArrayGenerator.Generate(ElementsCount, false, 1, ElementsCount + 1);

            OnPropertyChanged(() => CanStart);

            isSortStarted = false;

            RaiseGraphicsChagned();
        }

        private void CompleteSort() {
            isSortStarted = false;
            IsStarted = false;
            isCancelling = false;
            OnPropertyChanged(() => CanStart);

            RaiseGraphicsChagned();
        }

        private void RaiseGraphicsChagned() {
            GraphicsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}