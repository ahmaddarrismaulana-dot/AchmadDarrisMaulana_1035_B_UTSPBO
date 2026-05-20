using System.Runtime.InteropServices.Marshalling;

class TiketBioskop
{
    private string namaPenonton {  get; set; }
    private string idBooking { get; set; }
    private string judulFilm { get; set; }

    public TiketBioskop(string namaPenonton, string idBooking, string judulFilm)
    {
        this.namaPenonton = namaPenonton;
        this.idBooking = idBooking;
        this.judulFilm = judulFilm;
    }
    public void tampilininfo()
    {
        Console.WriteLine("== Detail ==");
        Console.WriteLine($"Nama: {namaPenonton} | ID: {idBooking} | Film: {judulFilm}");

    }
    public virtual void hitungtotalHarga(int jumlahTiket)
    {

    }
}
class TiketReguler : TiketBioskop
{
    public int hargaTiket;
    public TiketReguler (int hargaTiket, string idBooking, string judulFilm, string namaPenonton) : base(namaPenonton,idBooking,judulFilm)
    {
        this.hargaTiket = hargaTiket;
        
    }
    public override void hitungtotalHarga(int jumlahTiket)
    {
       double total =  hargaTiket * jumlahTiket;
        Console.WriteLine($"Total : {total}");
    }
}
class TiketPremiere : TiketBioskop
{
    public int hargaTiket;
    public int biayaLounge;
    string jenisStudio = "Premiere";
    
    public TiketPremiere (int hargaTiket, int biayaLounge, string judulFIlm, string namaPenonton, string idBooking) : base(namaPenonton,idBooking, judulFIlm)
    {
        this.hargaTiket = hargaTiket;
        this.biayaLounge = biayaLounge;
    }
    public override void hitungtotalHarga(int jumlahTiket)
    {
        double total = jumlahTiket * hargaTiket + biayaLounge;
        Console.WriteLine($"Total: {total}");
    }
}
class program
{
    static void Main(string[] args)
    {
        TiketPremiere P = new TiketPremiere(10000, 100000, "Jokowi The Movie", "Prabowo", "1986");
        P.tampilininfo();
        P.hitungtotalHarga(3);
        TiketReguler R = new TiketReguler(20000, "1945", "Soekarno", "IstriSoekarno");
        R.tampilininfo();
        R.hitungtotalHarga(4);
    }


}
    


