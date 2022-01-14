using Entities;

namespace PaintingApi.Controllers
{
    public class DBOperations
    {
        private PaintingContext context = new PaintingContext();

        public List<Painting> GetPaintings()
        {
            List<Painting> paintings = new List<Painting>();
            paintings = context.Painting.ToList();
            return paintings;
        }
        public bool AddModel(Painting painting)
        {
            context.Painting.Add(painting);
            context.SaveChanges();
            return true;
        }
        public bool DeleteModel(int id)
        {
            context.Painting.Remove(FindPainting("", id));
            context.SaveChanges();
            return true;
        }
        public Painting FindPainting(string paintingName = "", int paintingId = 0)
        {
            Painting? painting = new Painting();
            if (!string.IsNullOrEmpty(paintingName))
                painting = context.Painting.FirstOrDefault(m => m.paintingName == paintingName);
            else if (paintingId > 0)
            {
                painting = context.Painting.FirstOrDefault(m => m.paintingId == paintingId);
            }
            return painting;
        }
    }
}
