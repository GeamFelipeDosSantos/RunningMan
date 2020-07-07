using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RunningApp.Models
{
    public class Treino
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string nome { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Passo> passos { get; set; }


    }
}