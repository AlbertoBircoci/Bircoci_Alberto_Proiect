using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Bircoci_Alberto_Proiect.Salon
{
    public class Prenotari
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
