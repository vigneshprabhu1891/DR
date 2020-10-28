using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DataRyn.Services;
using DataRyn.Views;
using SQLite;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using DataRyn.Models;
using System.Collections.Generic;

namespace DataRyn
{
    public partial class App : Application
    {
        static SQLiteConnection database;
        public App()
        {
            InitializeComponent();
            //,\"store_name\":\"24492783  NEW RANDOLPH STORE0045\",\"store_address: \"530 3RD ST WEST, RANDOLPH AFB,  TX, 78150\",\"coding_type\": \"Item Coding\",  \"Task_State\": \"Not Started\"
            string json = "[{\"week_no\" : \"wk35\",\"week_date\" : \"08 - 09\",\"coding_type\": \"Item Coding\",\"Task_State\": \"Not Started\",\"store_name\":\"24492783 / NEW RANDOLPH STORE0045\",\"store_address\": \"530 3RD ST WEST, RANDOLPH AFB,  TX, 78150\"}," +
                " {\"week_no\" : \"wk36\",\"week_date\" : \"14 - 09\",\"coding_type\": \"Item Coding\",\"Task_State\": \"In-Progress\",\"store_name\":\"24492785 / NEW RANDOLPH STORE0085\",\"store_address\": \"350 3RD ST WEST, RANDOLPH AFB,  TX, 98150\"}," +
                " {\"week_no\" : \"wk37\",\"week_date\" : \"19 - 09\",\"coding_type\": \"Item Coding\",\"Task_State\": \"Not Started\",\"store_name\":\"24492100 / NEW RANDOLPH STORE0100\",\"store_address\": \"768 3RD ST WEST, RANDOLPH AFB,  TX, 67150\"}," +
                " {\"week_no\" : \"wk38\",\"week_date\" : \"25 - 09\",\"coding_type\": \"Item Coding\",\"Task_State\": \"In-Progress\",\"store_name\":\"24492123 / NEW RANDOLPH STORE0123\",\"store_address\": \"798 3RD ST WEST, RANDOLPH AFB,  TX, 54150\"}," +
                "{\"week_no\" : \"wk39\",\"week_date\" : \"30 - 09\",\"coding_type\": \"Item Coding\",\"Task_State\": \"Not Started\",\"store_name\":\"24492789 / NEW RANDOLPH STORE0798\",\"store_address\": \"708 3RD ST WEST, RANDOLPH AFB,  TX, 12150\"}]";
            
            List<StoreTask> list = JsonConvert.DeserializeObject<List<StoreTask>>(json);

           // int CountValue = App.Database().ExecuteScalar<int>("SELECT COUNT(*) FROM StoreTask ");
            App.Database().Execute("DELETE FROM StoreTask");
            App.Database().InsertAll(list);
            
            MainPage = new MasterDetailPage1();
        }

        public static SQLiteConnection Database()
        {
            return SQLDatabase;
        }

        public static SQLiteConnection SQLDatabase
        {
            get
            {
                if (database == null)
                {
                   
                        database = DependencyService.Get<ISQLite>().GetConnection();
                   

                }
                return database;
            }
            set
            {
                database = null;
                DependencyService.Get<ISQLite>().ResetConnection();
                
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
