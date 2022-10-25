using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;

namespace ReactveUI_WPF_StartPoint
{
    public class MainWindowViewModel : ReactiveObject
    {
        private readonly IRandomService m_RandomService;
        private ReadOnlyObservableCollection<Point[]> _points;

        public ReactiveCommand<Unit, Unit> GenerateDataCommand { get; set; }
        public ReactiveCommand<Unit, Unit> GenerateData2Command { get; set; }

        public MainWindowViewModel(IRandomService randomService)
        {
            m_RandomService = randomService;

            GenerateDataCommand = ReactiveCommand.Create(() => { GenerateNewData(1); });
            GenerateData2Command = ReactiveCommand.Create(() => { GenerateNewData(2); });

            m_RandomService.ConnectList()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _points)
                .Subscribe(_ => UsePoints());
        }

        private void UsePoints()
        {
            foreach(var points in _points)
            {
                foreach(var point in points)
                {
                    System.Diagnostics.Debug.WriteLine($"{point.X}||{point.Y}");
                }
            }
        }

        private void GenerateNewData(int sets)
        {
            for (int i = 0; i < sets; i++)
            {
                var newList = new List<Point>();
                Random r = new Random();

                for (int j = 0; j < 5; j++)
                {
                    newList.Add(new Point(r.Next(1, 100),
                        r.Next(1, 100)));
                }

                m_RandomService.Items.Add(newList.ToArray());
            }
        }
    }
}
