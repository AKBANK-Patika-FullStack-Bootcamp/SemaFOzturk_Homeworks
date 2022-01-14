using Entities;
using Microsoft.AspNetCore.Mvc;
using PaintingApi.Models;
using Painting = Entities.Painting;

namespace PaintingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaintingsController : ControllerBase
    {
        private List<Painting> paintings = new List<Painting>();
        PaintingContext db = new PaintingContext();
        DBOperations dbOperation = new DBOperations();
        /* public void Doldur()
         {
             paintings.Add(
                 new Models.Painting
                 {
                     paintingId = 1,
                     painter = "Vincent Van Gogh",
                     paintingName = "Yıldızlı Gece",
                     aboutPainter = "Vincent Willem Van Gogh, Hollandalı ard izlenimci ressam. Batı dünyası sanat tarihinin en tanınmış ve en etkili şahsiyetlerinden biridir. On yıldan biraz fazla bir süre içinde aralarında 860 yağlı boya tablonun da olduğu 2.100 kadar resim ve çizim çalışması üretti ve bunların çoğu yaşamının son iki yılında yapıldı.",
                     paintingDate = "Haziran 1889",
                     technique = "Yağlı Boya"
                 });
             paintings.Add(
                 new Models.Painting
                 {
                     paintingId = 2,
                     painter = "John Everett Millais",
                     paintingName = "Ophelia",
                     aboutPainter = "Sir John Everett Millais, Kraliyet Akademisi Üyesi İngiliz ressam ve çizer. William Holman Hunt ve Dante Gabriel Rossetti ile birlikte Ön-Raffaeloculuk akımının kurucularındandır.",
                     paintingDate = "1851",
                     technique = "Yağlı Boya"
                 });
             paintings.Add(
                 new Models.Painting
                 {
                     paintingId = 3,
                     painter = "Marco Melgrati",
                     paintingName = "Stay Cool No Matter What",
                     aboutPainter = "Marco Melgrati 1984 yılında Milano'da doğdu. 2006 yılında Santa Giulia Güzel Sanatlar Okulu'ndan mezun oldu. 2008 yılında serbest illüstratör olarak çalışmaya başladı.",
                     paintingDate = "2021",
                     technique = "Illustrasyon"
                 });
             paintings.Add(
                 new Models.Painting
                 {
                     paintingId = 4,
                     painter = "Pablo Picasso",
                     paintingName = "Guernica",
                     aboutPainter = "Pablo Picasso, Fransa'da yaşamış İspanyol ressam, heykeltıraş, sahne tasarımcısı, şair ve oyun yazarıdır. 20. yüzyıl sanatının en iyi bilinen isimlerindendir.",
                     paintingDate = "1937",
                     technique = "Tuval Üzerine Yağlı Boya"
                 });
             paintings.Add(
                 new Models.Painting
                 {
                     paintingId = 5,
                     painter = "Edvard Munch",
                     paintingName = "Çığlık",
                     aboutPainter = "Edvard Munch özellikle Çığlık isimli tablosuyla tanınmış Norveçli ekspresyonist ressamdır. Ruhsal ve duygusal konuları işlediği resimleriyle tanındı. Alman dışavurumculuk akımının gelişmesine önemli katkıları oldu.",
                     paintingDate = "1893",
                     technique = "Yağlı Boya"
                 });
         }*/

        [HttpGet()]
        public List<Painting> ListPainting()
        {
           // Doldur();
            return dbOperation.GetPaintings();
        }

        [HttpGet("{id}")]
        public Painting ListPaintingbyId(int id)
        {
            //Doldur();
            Painting selectedP = paintings.FirstOrDefault(p => p.paintingId == id);
            return selectedP;
        }

        [HttpPost]
        public Result PostPainting(Painting painting)
        {
            Painting pt = dbOperation.FindPainting(painting.paintingName, painting.paintingId);
            bool paintingCheck = (pt != null) ? true : false;
            //Doldur();

            Result result = new Result();

            //Painting paintingCheck = paintings.FirstOrDefault(p => p.paintingId == painting.paintingId && p.paintingName == painting.paintingName);
            if (paintingCheck == false)
            {
                if (dbOperation.AddModel(painting) == true)
                {
                    result.status = 1;
                    result.message = "Yeni eleman listeye eklendi.";
                }
                else
                {
                    result.status = 0;
                    result.message = "Hata, kullanıcı eklenemedi.";
                    result.pList = paintings.OrderBy(p => p.paintingId).ToList();
                }
            


                //paintings.Add(painting);

                //result.status = 1;
                //result.message = painting.paintingId + " id'li tablo listeye eklenmiştir.";
                //result.pList = paintings.OrderBy(p => p.paintingId).ToList();
            }
            else
            {
                result.status = 0;
                result.message = "!! " + painting.paintingId + " id'li tablo listeye eklenememiştir. !!";
            }
            return result;
        }

        [HttpPut("{id}")]
        public Result UpdatePainting(int id, Painting painting)
        {
            //Doldur();
            Result result = new Result();
            Painting willUpdate = paintings.Find(p => p.paintingId == id);

            if (willUpdate != null)
            {
                paintings.Add(painting);
                paintings.Remove(willUpdate);

                result.status = 1;
                result.message = id + " id'li kullanıcı başarıyla güncellendi.";
                result.pList = paintings.OrderBy(p => p.paintingId).ToList();
            }
            else
            {
                result.status = 1;
                result.message = "!! " + id + " id'li kullanıcı bilgileri güncellenirken bir hata oluştu. !!";
            }
            return result;
        }
        [HttpDelete("{id}")]
        public Result DeletePainting(int id)
        {
            //Doldur();
            Result result = new Result();

            Painting willDelete = paintings.Find(p => p.paintingId == id);
            if (willDelete != null)
            {
                paintings.Remove(willDelete);
                result.status = 1;
                result.message = id + " id'li kullanıcı başarıyla silindi.";
                result.pList = paintings.OrderBy(p => p.paintingId).ToList();
            }
            else
            {
                result.status = 0;
                result.message = "!! " + id + " id'li kullanıcı silinirken bir hata meydana geldi. !!";
            }
            return result;
        }
    }
}