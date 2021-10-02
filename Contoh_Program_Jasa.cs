dotusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Input
{//Membuat class parent untuk membuat variabel yang akan dipakai di class di bawah.
	private string[] nama = new string[20];
	public string[] barang = new string[20];
    public double[] harga = new double[20];
    public int[] jumlah = new int[20];
    public double[] total = new double[20];
    public string[] kelas = new string[20];
	public int i, n = 0;
	public int pilih;   
	
	public string[] Nama
        {//melakukan proses enkapsulasi variable nama
            get
            {
                return nama;
            }
            set
            {
                this.nama = value;
            }
        }
	
}	

public class Proses : Input //Mendapatkan warisan data dari class OngkosOjek atau child dari OngkosOjek
 {
 	public void Eksekusi()
	{//method untuk melakukan Eksekusi data.
		Input input = new Input();
        Console.Write("Masukan Jumlah Pembeli =  ");
        n = int.Parse(Console.ReadLine());
            for (i = 1; i <= n; i++)//melakukan perulangan sejumlah berapa banyak data pembeli yang di input(i);
            {
                Console.WriteLine("Masukan data Pembeli ke-" + i);
                Console.Write("Masukan Nama = ");
                input.Nama[i] = Console.ReadLine();
				Console.Write("Masukan Barang = ");
				input.barang[i] = Console.ReadLine();
                Console.Write("Masukan Harga = ");
                input.harga[i] = int.Parse(Console.ReadLine());
                Console.Write("Masukan Jumlah = ");
                input.jumlah[i] = int.Parse(Console.ReadLine());
                input.total[i] = input.jumlah[i] * input.harga[i];
				
				Console.WriteLine();

                if (input.total[i] >= 100000)//Decision untuk menunjukan Status mahal/murah nya barang tersebut.
                {
                    input.kelas[i] = "Mahal";
                }
                else if (input.total[i] >= 50000 && input.total[i] <= 99000)
                {
                    input.kelas[i] = "Normal";
                }
                else if (input.total[i] >= 0 && input.total[i] <= 49000)
                {
                    input.kelas[i] = "Murah";
                }
                
	}
	Console.Clear();
     for (i = 1; i <= n; i++)//Perulangan untuk menampilkan berapa banyak data yang akan di tampilkan(sejumlah dengan i);
       {
        Console.WriteLine("Data ke = " + i);
        Console.WriteLine("Nama Pembeli = " + input.Nama[i]);
		Console.WriteLine("Barang = " + input.barang[i]);
        Console.WriteLine("Harga = " + input.harga[i]);
        Console.WriteLine("Jumlah = " + input.jumlah[i]);
        Console.WriteLine("Total Bayar = " + input.total[i]);
        Console.WriteLine("Status = " + input.kelas[i]);
        Console.Write("\n");        
        }     
         Console.WriteLine("MENU");
            Console.WriteLine("1. Contoh Program Barang");
            Console.WriteLine("2. Contoh Program Jasa");
            Console.WriteLine("===============");


       Console.WriteLine("Masukkan Pilihan Anda! (1/2)");
                pilih = Convert.ToInt16(Console.ReadLine());

                if (pilih == 1)
                {
                    Proses proses = new Proses();
                    proses.Eksekusi();
                }
                if ( pilih == 2)
                {
                 Jasaa jasjek = new Jasaa();
                 jasjek.Jalankan();
                 }  
}

public class Jasaa
{ //Merupakan Class dari program kedua yaitu program Jasa.
	public void Jalankan()
	{ // Merupakan method untuk menjalankan program ini.
		//Menginisiasi JasaOjek.
		JasaOjek jajek = new JasaOjek("Adi","Motor"); 

		//print hasil dengan memanggil method dibawah.
		jajek.namaDriver(); 
		jajek.jenisKendaraan(); 

		//Menginisiasi HitungBiayaAplikasi
	   HitungBiayaAplikasi hitungba = new HitungBiayaAplikasi(); 
	   hitungba.total(1500,2); // Memberi Value pada (x, y) untuk menghitung biaya Aplikasi.

	   //Menginisiasi Identitas
	   Identitas idn = new Identitas(); 
	   idn.Nope = 0812456789; // Memberi Value pada (x) yang berisikan No. Telf Driver
	   Console.WriteLine("No Telp Driver " + idn.Nope + " : Bapak Rudi"); //Mencetak No. Telf Driver

       //Menginisiasi HitungOngkos
	   HitungOngkos ho = new HitungOngkos(); 
	   Console.WriteLine("Total Bayar : " + ho.rumusOngkos(10,8000,3000)); //Memberikan Value untuk x,y dan z dimana x merupakan jarak, y merupakan harga perkilo meter dan z biaya aplikasi.
	   ho.infoOngkos = "***Total Bayar = Jarak * harga/km(8000)  + Biaya Aplikasi***"; //Memberi Value String.
	   Console.WriteLine(ho.infoOngkos); //mencetak infoOngkos

	   Console.WriteLine();

       int pilih;
       Console.WriteLine("MENU");
       Console.WriteLine("1. Contoh Program Barang");
       Console.WriteLine("2. Contoh Program Jasa");
       Console.WriteLine("===============");


       Console.WriteLine("Masukkan Pilihan Anda! (1/2)");
       pilih = Convert.ToInt16(Console.ReadLine());

       if (pilih == 1)
        {
          Proses proses = new Proses();
          proses.Eksekusi();
        }
       if ( pilih == 2)
        {
          Jasaa jasjek = new Jasaa();
          jasjek.Jalankan();
        }

	}
}

public class JasaOjek
{ // Membuat Class JasaOjek

	public string namaDriver_proses; 
	public string jenisKendaraan_proses;



	public JasaOjek()
	{

	}

	public JasaOjek(string namaDriver, string jenisKendaraan)
	{ //konstruktor untuk polymorphisme
		this.namaDriver_proses = namaDriver;
		this.jenisKendaraan_proses = jenisKendaraan;
	}

	public virtual void namaDriver()
	{ //method
		Console.WriteLine("Nama Penumpang : " + namaDriver_proses);
	}

	public virtual void jenisKendaraan()
	{ //method
		Console.WriteLine("Jenis Kendaraan adalah : " + jenisKendaraan_proses);
	}

	 public virtual void total(int x, int y)
	 { //Contoh class yang memakai fungsi polymorphisme
		Console.WriteLine("Total harga");
	 }

}

public class HitungBiayaAplikasi : JasaOjek
{ ////Mendapatkan warisan data dari class JasaOjek atau child dari JasaOjek
	public override void total(int x, int y)
	{ //Contoh class yang memakai fungsi polymorphisme
		int total = x * y; //Rumus untuk menghitung total biaya aplikasi
		Console.WriteLine("Biaya Aplikasi : " + total); //Mencetak Total Biaya Aplikasi
	}
}

public class Identitas
{ //Contoh class yang memakai fungsi enkapsulasi
	private int nope; //Mendeklarasikan variable dalam class Identitas

	public virtual int Nope
	{//proses enkapsulasi variable nope
		set
		{ 
			this.nope = value;
		}
		get
		{ 
			return nope;
		}
	}

}

public abstract class OngkosOjek
{ //membuat class abstract OngkosOjek
	public string infoOngkos; 
	public abstract float rumusOngkos(float jarak, float perkm, float ba); 
}

public class HitungOngkos : OngkosOjek
{ //Mendapatkan warisan data dari class OngkosOjek atau child dari OngkosOjek
	public override float rumusOngkos(float jarak, float perkm, float ba)
	{ //method yang mengambil abstract pada OngkosOjek
		return  jarak * perkm  + ba ; 
	}
}

public static void Main(string[] args)
{
	
	int pilih;

                Console.WriteLine("MENU");
                Console.WriteLine("1. Contoh Program Barang");
                Console.WriteLine("2. Contoh Program Jasa");
                Console.WriteLine("===============");

                Console.WriteLine("Masukkan Pilihan Anda! (1/2)");
                pilih = Convert.ToInt16(Console.ReadLine());

                if (pilih == 1)
                {
                    Proses proses = new Proses();
                    proses.Eksekusi();
                }
				if ( pilih == 2)
				{
				 Jasaa jasjek = new Jasaa();
				 jasjek.Jalankan();
				 }
}
}