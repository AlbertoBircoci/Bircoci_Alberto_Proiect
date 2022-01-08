using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Bircoci_Alberto_Proiect.Salon
{
    public class Servicii
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        [OneToMany]
        public List<ListServicii> ListServiciis { get; set; }
    }
}
