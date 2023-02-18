namespace ProEventos.Domain
{
    // Associação 
    public class PalestranteEvento
    {
        // Chave estrangeira
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
        // Chave estrangeira
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}