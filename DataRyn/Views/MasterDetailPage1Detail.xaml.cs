using DataRyn.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataRyn.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1Detail : ContentPage
    {
        public MasterDetailPage1Detail()
        {
            InitializeComponent();

            BindingContext = new StoreTaskVM();
        }

        private void ST_LIST_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ST_LIST.SelectedItem = null;
        }
    }
}