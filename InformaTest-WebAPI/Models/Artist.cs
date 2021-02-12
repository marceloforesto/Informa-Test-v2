using System.Collections.Generic;

namespace InformaTest_WebAPI.Models
{
    public class Artist
    {
        public Artist() { }
        public Artist(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Album> Albums { get; set; }
    }
}