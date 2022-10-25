using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReactveUI_WPF_StartPoint
{
    public class RandomService : ReactiveObject, IRandomService
    {
        private SourceList<Point[]> _items = new SourceList<Point[]>();

        public SourceList<Point[]> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public IObservable<IChangeSet<Point[]>> ConnectList()
        {
            return _items.Connect();
        }
    }
}
