using DynamicData;
using System;
using System.Windows;

namespace ReactveUI_WPF_StartPoint
{
    public interface IRandomService
    {
        SourceList<Point[]> Items { get; set; }
        IObservable<IChangeSet<Point[]>> ConnectList();
    }
}
