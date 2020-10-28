using DataRyn.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DataRyn.ViewModels
{
    public class StoreTaskVM : INotifyPropertyChanged
    {

        private ObservableCollection<StoreTaskModel> items;
        public ObservableCollection<StoreTaskModel> Items
        {
            get { return items; }
            set
            {

                items = value;
            }
        }

        public StoreTaskVM()
        {
            Items = new ObservableCollection<StoreTaskModel>((from i in App.Database().Query<StoreTaskModel>("SELECT * FROM StoreTask ").AsEnumerable()
                                                              select i).ToList());
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
