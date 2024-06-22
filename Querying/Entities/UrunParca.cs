
namespace Querying.Entities
{
    public class UrunParca
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public Urun Urun { get; set; }

        public int ParcaId { get; set; }
        public Parca Parca { get; set; }
    }
}
