using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Bircoci_Alberto_Proiect.Salon
{
   public class ListServicii
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Prenotari))]
        public int PrenotariID { get; set; }
        public int ServiciiD { get; set; }
    }
}
