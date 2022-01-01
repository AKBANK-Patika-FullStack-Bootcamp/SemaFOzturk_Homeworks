namespace PaintingApi.Models
{
    public class Result
    {
        public int status { get; set; }
        public string? message { get; set; }
        public List<Painting>? pList { get; set; }
    }
}
