namespace movies.Infrastructure.Persistences.DataEntities
{
    public class MovieEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
