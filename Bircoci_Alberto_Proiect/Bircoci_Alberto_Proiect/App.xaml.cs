using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Bircoci_Alberto_Proiect.Data;
using System.IO;

namespace Bircoci_Alberto_Proiect
{
    public partial class App : Application
    {
        static SalonDatabase database;
        public static SalonDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SalonDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                    LocalApplicationData), "Salon.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
           
            MainPage = new MainPage();
            MainPage = new NavigationPage(new ListEntryPage());
        }
    }

        

        
    }
