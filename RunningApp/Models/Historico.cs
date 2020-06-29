using System;
using SQLite;

namespace RunningApp.Models
{
    public class Historico
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public float Distancia { get; set; }
        // Distancia total percorrida
        public DateTime Data { get; set; }
        // Data em que exercício foi realizado
        public int Duracao { get; set; }
        // Duração total da corrida/caminhada em minutos.
        public int Passos{ get; set; }
        public int VelocidadeMedia { get; set; }
        public int GastoCalorico { get; set; }
    }
}