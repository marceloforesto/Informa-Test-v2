using System.Collections.Generic;

namespace InformaTest_WebAPI.Models
{
    public class Track
    {
        public Track() { }
        public Track(int id, string nome, int ano, int estilo, int duracao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Ano = ano;
            this.Estilo = estilo;
            this.Duracao = duracao;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public string Estilo { get; set; }
        public string Duracao { get; set; }
        public IEnumerable<TrackAlbum> TracksAlbums { get; set; }
    }
}