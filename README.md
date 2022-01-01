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

**Girilen id'ye göre paintings listesindeki belirli id'li verinin gösterildiği *ListPaintingbyId()* methodu**
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

**Tablo(painting) eklemeyi sağlayan *PostPainting()* methodu**
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
                //nesne kontrol edilerek listeye eklendi.
                paintings.Add(painting);

                //oluşturulan result nesnesine gerekli durum, mesaj atamaları yapıldı.
                result.status = 1;
                result.message = painting.paintingId + " id'li tablo listeye eklenmiştir.";
                result.pList = paintings.OrderBy(p => p.paintingId).ToList();
            }
            else
            {
                //oluşturulan result nesnesine gerekli durum, mesaj atamaları yapıldı.
                result.status = 0;
                result.message = "!! " + painting.paintingId + " id'li tablo listeye eklenememiştir. !!";
            }
            return result;
        }
```

**Girilen id'ye göre veri güncellemeyi sağlayan *UpdatePainting()* methodu**
```C#
[HttpPut("{id}")]
        public Result UpdatePainting(int id, Painting painting)
        {
            //veriler listeye eklendi.
            Doldur();
            Result result = new Result();
            
            //güncellenecek nesne oluşturulan willUpdate nesnesine atandı.
            Painting willUpdate = paintings.Find(p => p.paintingId == id);

            if (willUpdate != null)
            {
                //güncellenecek nesne listeden silinerek güncel değerleriyle eklendi.
                paintings.Add(painting);
                paintings.Remove(willUpdate);
                
                //oluşturulan result nesnesine gerekli durum, mesaj atamaları yapıldı.
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
```

**Girilen id'ye göre veri silmeyi sağlayan *DeletePainting()* methodu**
```C#
[HttpDelete("{id}")]
        public Result DeletePainting(int id)
        {
            //veriler listeye eklendi.
            Doldur();
            Result result = new Result();

            //silinecek nesne oluşturulan willDelete nesnesine atandı.
            Painting willDelete = paintings.Find(p => p.paintingId == id);
            if (willDelete != null)
            {
                //willDelete nesnesi listeden silindi.
                paintings.Remove(willDelete);
                
                //oluşturulan result nesnesine gerekli durum, mesaj atamaları yapıldı.
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
```


