
using DataRyn.Droid;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace DataRyn.Droid
{
    public class SQLite_Android : ISQLite
    {
        private static SQLite.SQLiteConnection _dataRynconnection;
      

        #region ISQLite implementation

        public void ResetConnection()
        {
            _dataRynconnection = null;
        }

    
     
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "DataRyn.db3";
           

            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            if (!File.Exists(path))
            {
                Console.WriteLine(path);

                using (var br = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename)))
                {
                    using (var bw = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, length);
                        }
                    }
                }
            }

          

          
                if (_dataRynconnection == null)
                {
                    _dataRynconnection = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex, true);
                }
                // Return the database connection 
                return _dataRynconnection;
           
        }

        
        #endregion
    }
}


