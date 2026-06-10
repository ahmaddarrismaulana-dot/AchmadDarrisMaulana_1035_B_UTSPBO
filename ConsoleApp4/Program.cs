using System;
using System.Collections.Generic;

abstract class TiketBioskop
{
    private string namaPenonton;
    private string idBooking;
    private string judulFilm;

    public string NamaPenonton 
    { 
        get { return namaPenonton; } 
        set { namaPenonton = value; } 
    }
    public string IdBooking 
    {
        get { return idBooking; } 
        set { idBooking = value; } 
    }
    public string JudulFilm 
    { 
        get { return judulFilm; } 
        set { judulFilm = value; } 
    }


    private List<RiwayatNonton> daftarRiwayat = new List<RiwayatNonton>();

    public TiketBioskop(string namaPenonton, string idBooking, string judulFilm)
    {
        this.namaPenonton = namaPenonton;
        this.idBooking = idBooking;
        this.judulFilm = judulFilm;
    }

    public void tampilininfo()
    {
        Console.WriteLine("== Detail Tiket ==");
        Console.WriteLine($"Nama Penonton : {namaPenonton}");
        Console.WriteLine($"ID Booking    : {idBooking}");
        Console.WriteLine($"Judul Film    : {judulFilm}");
    }

    // Method optional
    public void tambahRiwayat(string jenisStudio, int jumlahTiket, DateTime tanggalNonton)
    {
        daftarRiwayat.Add(new RiwayatNonton(jenisStudio, jumlahTiket, tanggalNonton));
    }

    public void cetakRiwayat()
    {
        Console.WriteLine("\n== Riwayat Nonton ==");

        if (daftarRiwayat.Count == 0)
        {
            Console.WriteLine("Belum ada riwayat.");
            return;
        }

        foreach (RiwayatNonton r in daftarRiwayat)
        {
            Console.WriteLine(
                $"Studio : {r.JenisStudio} | " +
                $"Jumlah Tiket : {r.JumlahTiket} | " +
                $"Tanggal : {r.TanggalNonton:dd-MM-yyyy}"
            );
        }
    }

    public abstract void hitungtotalHarga(int jumlahTiket);
}

class RiwayatNonton
{
    public string JenisStudio { get; set; }
    public int JumlahTiket { get; set; }
    public DateTime TanggalNonton { get; set; }

    public RiwayatNonton(string jenisStudio, int jumlahTiket, DateTime tanggalNonton)
    {
        JenisStudio = jenisStudio;
        JumlahTiket = jumlahTiket;
        TanggalNonton = tanggalNonton;
    }
}

class TiketReguler : TiketBioskop
{
    public int hargaTiket;

    public TiketReguler(int hargaTiket, string idBooking,
        string judulFilm, string namaPenonton)
        : base(namaPenonton, idBooking, judulFilm)
    {
        this.hargaTiket = hargaTiket;
    }

    public override void hitungtotalHarga(int jumlahTiket)
    {
        double total = hargaTiket * jumlahTiket;
        Console.WriteLine($"Total : {total}");
    }
}

class TiketPremiere : TiketBioskop
{
    public int hargaTiket;
    public int biayaLounge;

    public TiketPremiere(int hargaTiket, int biayaLounge,
        string judulFilm, string namaPenonton, string idBooking)
        : base(namaPenonton, idBooking, judulFilm)
    {
        this.hargaTiket = hargaTiket;
        this.biayaLounge = biayaLounge;
    }

    public override void hitungtotalHarga(int jumlahTiket)
    {
        double total = (jumlahTiket * hargaTiket) + biayaLounge;
        Console.WriteLine($"Total : {total}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        TiketPremiere P = new TiketPremiere(
            10000,
            100000,
            "Jokowi The Movie",
            "Prabowo",
            "1986"
        );

        P.tampilininfo();
        P.hitungtotalHarga(3);

        P.tambahRiwayat(
            "Premiere",
            3,
            new DateTime(2026, 6, 4)
        );

        P.cetakRiwayat();

        Console.WriteLine();

        TiketReguler R = new TiketReguler(
            20000,
            "1945",
            "Soekarno",
            "IstriSoekarno"
        );

        R.tampilininfo();
        R.hitungtotalHarga(4);

        R.tambahRiwayat(
            "Reguler",
            4,
            DateTime.Now
        );

        R.cetakRiwayat();
    }
}