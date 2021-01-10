using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Rusu_Bianca_Proiect.Models
{
    public class ListExamen
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(ProgramareExamen))]
        public int ProgramareExamenID { get; set; }
        public int ExamenID { get; set; }
    }
}
