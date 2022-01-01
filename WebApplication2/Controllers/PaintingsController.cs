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
                    paintingName = "Y�ld�zl� Gece",
                    aboutPainter = "Vincent Willem Van Gogh, Hollandal� ard izlenimci ressam. Bat� d�nyas� sanat tarihinin en tan�nm�� ve en etkili �ahsiyetlerinden biridir. On y�ldan biraz fazla bir s�re i�inde aralar�nda 860 ya�l� boya tablonun da oldu�u 2.100 kadar resim ve �izim �al��mas� �retti ve bunlar�n �o�u ya�am�n�n son iki y�l�nda yap�ld�.",
                    paintingDate = "Haziran 1889",
                    technique = "Ya�l� Boya"
                });
            paintings.Add(
                new Painting
                {
                    paintingId = 2,
                    painter = "John Everett Millais",
                    paintingName = "Ophelia",
                    aboutPainter = "Sir John Everett Millais, Kraliyet Akademisi �yesi �ngiliz ressam ve �izer. William Holman Hunt ve Dante Gabriel Rossetti ile birlikte �n-Raffaeloculuk ak�m�n�n kurucular�ndand�r.",
                    paintingDate = "1851",
                    technique = "Ya�l� Boya"
                });
            paintings.Add(
                new Painting
                {
                    paintingId = 3,
                    painter = "Marco Melgrati",
                    paintingName = "Stay Cool No Matter What",
                    aboutPainter = "Marco Melgrati 1984 y�l�nda Milano'da do�du. 2006 y�l�nda Santa Giulia G�zel Sanatlar Okulu'ndan mezun oldu. 2008 y�l�nda serbest ill�strat�r olarak �al��maya ba�lad�.",
                    paintingDate = "2021",
                    technique = "Illustrasyon"
                });
            paintings.Add(
                new Painting
                {
                    paintingId = 4,
                    painter = "Pablo Picasso",
                    paintingName = "Guernica",
                    aboutPainter = "Pablo Picasso, Fransa'da ya�am�� �spanyol ressam, heykelt�ra�, sahne tasar�mc�s�, �air ve oyun yazar�d�r. 20. y�zy�l sanat�n�n en iyi bilinen isimlerindendir.",
                    paintingDate = "1937",
                    technique = "Tuval �zerine Ya�l� Boya"
                });
            paintings.Add(
                new Painting
                {
                    paintingId = 5,
                    painter = "Edvard Munch",
                    paintingName = "���l�k",
                    aboutPainter = "Edvard Munch �zellikle ���l�k isimli tablosuyla tan�nm�� Norve�li ekspresyonist ressamd�r. Ruhsal ve duygusal konular� i�ledi�i resimleriyle tan�nd�. Alman d��avurumculuk ak�m�n�n geli�mesine �nemli katk�lar� oldu.",
                    paintingDate = "1893",
                    technique = "Ya�l� Boya"
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
                result.message =painting.paintingId + " id'li tablo listeye eklenmi�tir.";
                result.pList = paintings.OrderBy(p => p.paintingId).ToList();
            }
            else
            {
                result.status = 0;
                result.message = "!! "+painting.paintingId + " id'li tablo listeye eklenememi�tir. !!";
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
                result.message = id + " id'li kullan�c� ba�ar�yla g�ncellendi.";
                result.pList = paintings.OrderBy(p=>p.paintingId).ToList();
            }
            else
            {
                result.status = 1;
                result.message = "!! "+id + " id'li kullan�c� bilgileri g�ncellenirken bir hata olu�tu. !!";
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
                result.message = id + " id'li kullan�c� ba�ar�yla silindi.";
                result.pList= paintings.OrderBy(p => p.paintingId).ToList();
            }
            else
            {
                result.status = 0;
                result.message ="!! "+id + " id'li kullan�c� silinirken bir hata meydana geldi. !!";
            }
            return result;
        }

      
    }
}