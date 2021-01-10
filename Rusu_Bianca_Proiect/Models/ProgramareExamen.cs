using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rusu_Bianca_Proiect.Models
{
    public class ProgramareExamen
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Descriere { get; set; }
        public DateTime Date { get; set; }
    }
}
