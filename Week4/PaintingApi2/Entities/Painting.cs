using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Painting
    {
        [Key]
        public int paintingId { get; set; }
        public string paintingName { get; set; }
        //public int painterId { get; set; }
       // public int detailid { get; set; }
    }
}