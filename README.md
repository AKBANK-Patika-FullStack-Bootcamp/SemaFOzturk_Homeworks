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
            Doldur();
            return paintings;
        }
```
