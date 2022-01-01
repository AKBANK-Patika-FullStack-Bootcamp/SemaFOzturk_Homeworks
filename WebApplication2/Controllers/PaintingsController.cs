using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaintingsController : ControllerBase
    {
       private List<Painting> paintings = new List<Painting>();
        
        public void Doldur()
        {
            paintings.Add(
                new Painting
                {
                    paintingId = 1,
                    painter = "Vincent Van Gogh",
                    paintingName = "Yýldýzlý Gece",
                    aboutPainter = "Vincent Willem Van Gogh, Hollandalý ard izlenimci ressam. Batý dünyasý sanat tarihinin en tanýnmýþ ve en etkili þahsiyetlerinden biridir. On yýldan biraz fazla bir süre içinde aralarýnda 860 yaðlý boya tablonun da olduðu 2.100 kadar resim ve çizim çalýþmasý üretti ve bunlarýn çoðu yaþamýnýn son iki yýlýnda yapýldý.",
                    paintingDate = "Haziran 1889",
                    technique = "Yaðlý Boya"
                });
            paintings.Add(
                new Painting
                {
                    paintingId = 2,
                    painter = "John Everett Millais",
                    paintingName = "Ophelia",
                    aboutPainter = "Sir John Everett Millais, Kraliyet Akademisi Üyesi Ýngiliz ressam ve çizer. William Holman Hunt ve Dante Gabriel Rossetti ile birlikte Ön-Raffaeloculuk akýmýnýn kurucularýndandýr.",
                    paintingDate = "1851",
                    technique = "Yaðlý Boya"
                });
            paintings.Add(
                new Painting
                {
                    paintingId = 3,
                    painter = "Marco Melgrati",
                    paintingName = "Stay Cool No Matter What",
                    aboutPainter = "Marco Melgrati 1984 yýlýnda Milano'da doðdu. 2006 yýlýnda Santa Giulia Güzel Sanatlar Okulu'ndan mezun oldu. 2008 yýlýnda serbest illüstratör olarak çalýþmaya baþladý.",
                    paintingDate = "2021",
                    technique = "Illustrasyon"
                });
            paintings.Add(
                new Painting
                {
                    paintingId = 4,
                    painter = "Pablo Picasso",
                    paintingName = "Guernica",
                    aboutPainter = "Pablo Picasso, Fransa'da yaþamýþ Ýspanyol ressam, heykeltýraþ, sahne tasarýmcýsý, þair ve oyun yazarýdýr. 20. yüzyýl sanatýnýn en iyi bilinen isimlerindendir.",
                    paintingDate = "1937",
                    technique = "Tuval Üzerine Yaðlý Boya"
                });
            paintings.Add(
                new Painting
                {
                    paintingId = 5,
                    painter = "Edvard Munch",
                    paintingName = "Çýðlýk",
                    aboutPainter = "Edvard Munch özellikle Çýðlýk isimli tablosuyla tanýnmýþ Norveçli ekspresyonist ressamdýr. Ruhsal ve duygusal konularý iþlediði resimleriyle tanýndý. Alman dýþavurumculuk akýmýnýn geliþmesine önemli katkýlarý oldu.",
                    paintingDate = "1893",
                    technique = "Yaðlý Boya"
                });
        }
       
        [HttpGet()]
        public List<Painting> ListPainting()
        {
            Doldur();
            return paintings;
        }

        [HttpGet("{id}")]
        public Painting ListPaintingbyId(int id)
        {
            Doldur();
            Painting selectedP = paintings.FirstOrDefault(p => p.paintingId == id);
            return selectedP;
        }

        [HttpPost]
        public Result PostPainting(Painting painting)
        {
            Doldur();
            Result result= new Result();

            Painting paintingCheck = paintings.FirstOrDefault(p => p.paintingId == painting.paintingId && p.paintingName == painting.paintingName);
            if (paintingCheck == null)
            {
                paintings.Add(painting);

                result.status = 1;
                result.message =painting.paintingId + " id'li tablo listeye eklenmiþtir.";
                result.pList = paintings.OrderBy(p => p.paintingId).ToList();
            }
            else
            {
                result.status = 0;
                result.message = "!! "+painting.paintingId + " id'li tablo listeye eklenememiþtir. !!";
            }
            return result;
        }

        [HttpPut("{id}")]
        public Result UpdatePainting(int id, Painting painting)
        {
            Doldur();
            Result result = new Result();
            Painting willUpdate = paintings.Find(p => p.paintingId == id);

            if (willUpdate != null)
            {
                paintings.Add(painting);
                paintings.Remove(willUpdate);

                result.status = 1;
                result.message = id + " id'li kullanýcý baþarýyla güncellendi.";
                result.pList = paintings.OrderBy(p=>p.paintingId).ToList();
            }
            else
            {
                result.status = 1;
                result.message = "!! "+id + " id'li kullanýcý bilgileri güncellenirken bir hata oluþtu. !!";
            }
            return result;
        }
        [HttpDelete("{id}")]
        public Result DeletePainting(int id)
        {
            Doldur();
            Result result = new Result();

            Painting willDelete = paintings.Find(p => p.paintingId == id);
            if (willDelete!=null)
            {
                paintings.Remove(willDelete);
                result.status = 1;
                result.message = id + " id'li kullanýcý baþarýyla silindi.";
                result.pList= paintings.OrderBy(p => p.paintingId).ToList();
            }
            else
            {
                result.status = 0;
                result.message ="!! "+id + " id'li kullanýcý silinirken bir hata meydana geldi. !!";
            }
            return result;
        }

      
    }
}