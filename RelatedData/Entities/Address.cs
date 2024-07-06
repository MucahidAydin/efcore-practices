namespace RelatedData.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string PersonAddress { get; set; }

        public Person Person { get; set; }
    }
}