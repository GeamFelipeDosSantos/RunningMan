using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RunningApp.Models
{
    public class Passo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        // chave estrangeira
        [ForeignKey(typeof(Treino))]
        public int TreinoId { get; set; }

        public int duracao { get; set; }
        public string tipo { get; set; }
        public string velocidade { get; set; }

        [ManyToOne]
        public Treino treino { get; set; }

    }
}