# Ödev 1
## CRUD işlemleri barındıran Web APİ Oluşturma

### Painting Modeli
```C#
public class Painting
    {
        public int paintingId { get; set; }
        public string? painter { get; set; }
        public string? paintingName { get; set; }
        public string? aboutPainter { get; set; }
        public string? paintingDate { get; set; }
        public string? technique { get; set; }
    }
```
## PaintingController

**paintings listesini doldurma fonksiyonu :** 
```C#
public void Doldur()
{
    paintings.Add(
                new Painting
                {
                    paintingId = 1,
                    painter = "Vincent Van Gogh",
                    paintingName = "Yıldızlı Gece",
                    aboutPainter = "Vincent Willem Van Gogh, Hollandalı ard izlenimci ressam. Batı dünyası sanat tarihinin en tanınmış ve en etkili şahsiyetlerinden biridir. On yıldan biraz fazla bir süre içinde aralarında 860 yağlı boya tablonun da olduğu 2.100 kadar resim ve çizim çalışması üretti ve bunların çoğu yaşamının son iki yılında yapıldı.",
                    paintingDate = "Haziran 1889",
                    technique = "Yağlı Boya"
                });
                
.....
...
..
}
```

**paintings listesindeki verilerin listelendiği *ListPainting()* methodu**
```C#
[HttpGet()]
        public List<Painting> ListPainting()
        {
            //veriler listeye eklendi.
            Doldur();
            return paintings;
        }
```

**girilen id'ye göre paintings listedeki belirli id'li verinin gösterildiği *ListPaintingbyId()* methodu**
```C#
[HttpGet("{id}")]
        public Painting ListPaintingbyId(int id)
        {
           //veriler listeye eklendi.
            Doldur();
            //id'ye göre return edilecek nesne oluşturulan painting nesnesine atandı.
            Painting selectedP = paintings.FirstOrDefault(p => p.paintingId == id);
            return selectedP;
        }
```

**Tablo(painting) eklemeyi sağlayan *ListPaintingbyId()* methodu**
```C#
[HttpPost]
        public Result PostPainting(Painting painting)
        {
           //veriler listeye eklendi.
            Doldur();
            Result result = new Result();

            //eklenecek nesne ataması yapıldı.
            Painting paintingCheck = paintings.FirstOrDefault(p => p.paintingId == painting.paintingId && p.paintingName == painting.paintingName);
            if (paintingCheck == null)
            {
                paintings.Add(painting);

                result.status = 1;
                result.message = painting.paintingId + " id'li tablo listeye eklenmiştir.";
                result.pList = paintings.OrderBy(p => p.paintingId).ToList();
            }
            else
            {
                result.status = 0;
                result.message = "!! " + painting.paintingId + " id'li tablo listeye eklenememiştir. !!";
            }
            return result;
        }
```

