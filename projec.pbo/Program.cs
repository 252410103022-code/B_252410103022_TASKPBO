using System;
using System.Collections.Generic;
class Item
{
    public string Judul { get; set; }
    public int Tahun { get; set; }
    public Item(string judul, int tahun)
    {
        Judul = judul;
        Tahun = tahun;
    }

    public virtual void Deskripsi()
    {
        Console.WriteLine("Ini adalah item perpustakaan.");
    }
    public void InfoItem()
    {
        Console.WriteLine("Judul: " + Judul + ", Tahun: " + Tahun);
    }
}
class Buku : Item
{
    public string Penulis { get; set; }
    public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
    {
        Penulis = penulis;
    }
    public override void Deskripsi() { Console.WriteLine("Ini adalah buku karya " + Penulis + "."); }
    public void CekPenulis() { Console.WriteLine("Penulis: " + Penulis); }
}
class Novel : Buku
{
    public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }
    public override void Deskripsi() { Console.WriteLine("Ini adalah novel karya " + Penulis + "."); }
    public void BacaSinopsis() { Console.WriteLine("Sinopsis novel " + Judul + ":Kisah mahasiswa aktivis di masa Orde Baru yang diculik dan hilang. " +
        "Adanya konflik pemerintah dan masyarakat, " +
        "menyebabkan proses demo menjadi lama. " +
        "Adiknya bersama keluarga terus menunggu kabarnya."); }
}
class Komik : Buku
{
    public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }
    public override void Deskripsi() { Console.WriteLine("Ini adalah komik karya " + Penulis + "."); }
    public void TampilkanIlustrasi() { Console.WriteLine("Menampilkan ilustrasi komik " + Judul + "."); }
}
class Majalah : Item
{
    public int Edisi { get; set; }
    public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
    {
        Edisi = edisi;
    }
    public override void Deskripsi() { Console.WriteLine("Ini adalah majalah edisi " + Edisi + "."); }
    public void InfoEdisi() { Console.WriteLine("Edisi: " + Edisi); }
}
class MajalahAnak : Majalah
{
    public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }
    public override void Deskripsi() { Console.WriteLine("Ini adalah majalah anak edisi " + Edisi + "."); }
    public void KategoriAnak() { Console.WriteLine("Kategori: bacaan untuk anak-anak."); }
}

class MajalahTeknologi : Majalah
{
    public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

    public override void Deskripsi() { Console.WriteLine("Ini adalah majalah teknologi edisi " + Edisi + "."); }
    public void TopikTeknologi() { Console.WriteLine("Topik: perkembangan teknologi terbaru."); }
}
class Perpustakaan
{
    private List<Item> daftarItem = new List<Item>();
    public void TambahItem(Item item)
    {
        daftarItem.Add(item);
        Console.WriteLine(item.Judul + " ditambahkan ke perpustakaan.");
    }
    public void DaftarItem()
    {
        foreach (Item item in daftarItem)
        {
            item.InfoItem();
            item.Deskripsi();
            Console.WriteLine();
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Perpustakaan perpus = new Perpustakaan();

        Novel novel = new Novel("Laut Bercerita", 2017, "Leila S. Chudori");
        Komik komik = new Komik("Doraemon", 1970, "Fujiko F. Fujio");
        MajalahAnak mAnak = new MajalahAnak("Bobo", 2023, 12);
        MajalahTeknologi mTek = new MajalahTeknologi("Tech Today", 2024, 5);

        Console.WriteLine("=== Tambah Item ===");
        perpus.TambahItem(novel);
        perpus.TambahItem(komik);
        perpus.TambahItem(mAnak);
        perpus.TambahItem(mTek);

        Console.WriteLine("\n=== Daftar Item ===");
        perpus.DaftarItem();

        Console.WriteLine("=== Polymorphism ===");
        Item[] semua = { novel, komik, mAnak, mTek };
        foreach (Item i in semua)
        {
            i.Deskripsi();
        }

        Console.WriteLine("\n== Method Khusus ==");
        komik.TampilkanIlustrasi();
        mAnak.KategoriAnak();
        mAnak.InfoEdisi();

        Console.WriteLine("\n=== Soal 1 ===");
        Majalah majalah = new Majalah("Kawanku", 2022, 3);
        novel.Deskripsi();
        majalah.Deskripsi();

        Console.WriteLine("\n== Soal 2 ==");
        novel.BacaSinopsis();

        Console.WriteLine("\n== Soal 3 ==");
        novel.InfoItem();
        novel.CekPenulis();

        Console.WriteLine("\n== Soal 4 ==");
        mTek.TopikTeknologi();

        Console.WriteLine("\n== Soal 5 ==");
        Item item = new Komik("One Piece", 1997, "Eiichiro Oda");
        item.Deskripsi();
        ((Komik)item).TampilkanIlustrasi(); 
    }
}