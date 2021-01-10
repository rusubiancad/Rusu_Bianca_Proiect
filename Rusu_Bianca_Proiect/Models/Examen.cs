using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Rusu_Bianca_Proiect.Models
{
    public class Examen
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Disciplina { get; set; }
        public string TitularCurs { get; set; }
        public int Credite { get; set; }
        public int Nota { get; set; }
        [OneToMany]
        public List<ListExamen> ListExamene { get; set; }
    }
}
