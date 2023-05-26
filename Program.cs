using HDD_Gyakorlo_app.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static HDD_Gyakorlo_app.Classes.File;
using System.Xml.Linq;

namespace HDD_Gyakorlo_app
{
	//		69. FELADAT
	//Készítsünk egy háttértároló osztályt, amely fájlok listáját kezeli az alábbi módon:
	//- A háttértárolónak van egy maximális tárolókapacitása, melyet csak konstruktorban lehet beállítani
	//- Van egy Format() metódusa, mely üríti a fájlok listáját
	//- Van egy MaximálisKapacitás tulajdonsága, amellyel le lehet kérdezni a maximális kapacitás értékét
	//- Van egy SzabadKapacitás tulajdonsága, amellyel le lehet kérdezni a meghajtó szabad kapacitását
	//- Van egy FoglaltKapacitás tulajdonsága, amellyel le lehet kérdezni a tárolt fájlok összméretét
	//- Van egy Hozzáad() metódusa, amellyel új fájlt lehet hozzáadni, ha ugyanilyen nevű fájl nincs még a
	//háttértárolón, illetve az új fájl elfér a háttértárolón
	//- Van egy Keres() metódusa, amely egy megadott fájlnév alapján megkeresi és visszaadja a fájlt - Van egy
	//Töröl() metódusa, amely letörli a megadott fájlt, amennyiben létezik A fájlok jellemzői a következők:
	//- Van nevük és méretük
	//- Van egy-egy CsakOlvasható, Rendszer és Rejtett attribútumuk
	//Fejlesszük tovább az alap háttértároló osztályt Floppy osztállyá az alábbi módosítások szerint:
	//- A floppy mérete 1440KB
	//- A floppy-nak van írásvédő tolókája, amely ha „írásvédett'”állapotba kerül, akkor a floppyn sem a Format(),
	//sem a Hozzáad(), sem a Törlés() nem működik
	//Fejlesszük tovább az alap háttértároló osztályt DVD osztállyá az alábbi módosítások szerint:
	//- A DVD mérete 4700MB
	//- A DVD alapból még írható, törölhető, de miután meghívjuk a Zárolás() metódusát(DVD felírása), akkor utána
	//már nem használható rajta sem a Format(), sem a Hozzáad(), sem a Töröl() („egyszer írható DVD”)
	//- A zárolt DVD szabad kapacitása mindig 0 legyen
	//Fejlesszük tovább a DVD osztályt DVD-RW osztállyá az alábbi módosítások szerint:
	//- A DVD-RW többször is írható DVD, ezért van egy Megnyitás() metódusa is. Ekkor a DVD lemez visszaáll egy
	//üres alapállapotba.
	//Fejlesszük tovább az alap Háttértároló osztályt HDD osztállyá a célnak megfelelő módosítások szerint.
	//Fejlesszünk ki egy Számítógép osztályt az alábbiak szerint:
	//- Több háttértárolója is lehet, melyek egy Felcsatol() metódus segítségével lehet csatolhatók a géphez
	//- Van egy Összkapacitás tulajdonsága, amely megadja az összes háttértároló teljes kapacitásának összegét - Van
	//egy SzabadKapacitás tulajdonsága, amely megadja az összes háttértároló teljes szabad kapacitásának összegét
	//- Van egy FoglaltKapacitás tulajdonsága, amely megadja az összes háttértároló teljes foglalt kapacitásának
	//összegét
	//- Van egy Archivál() metódusa, mely a megadott fájlt megkeresi a háttértárolók valamelyikén, majd a megadott
	//másik háttértárolóra a megfelelő módon archiválja a fájlt.Amennyiben nem adunk meg másik háttértárolót, a
	//metódus keres egy másik használható háttértárolót és oda végzi el az archiválást.

	internal class Program
	{

		static void Main(string[] args)
		{
			File elsofile = new File("elso", 25, filetipus.Rendszer);
			File masodikfile = new File("masodik", 50, filetipus.Rendszer);
			File harmadikfile = new File("harmadik", 125, filetipus.Rendszer);
			File negyedikfile = new File("negyedik", 225, filetipus.Rendszer);

			File otodikfile = new File("otodik", 253400, filetipus.Rendszer);
			File hatodikfile = new File("hatodik", 502300, filetipus.Rendszer);
			File hetedikfile = new File("hetedik", 125020, filetipus.Rendszer);
			File nyolcadikfile = new File("nyolcadikdik", 2253400, filetipus.Rendszer);

			FloppyStorage floppy = new FloppyStorage(1440);
			DVDStorage dvd = new DVDStorage(4700000);

            Console.WriteLine("Teszt: A fájlok másolása a floppyra elkezdődött:");
			try
			{
				floppy.AddToList(elsofile);
				floppy.AddToList(masodikfile);
				floppy.AddToList(harmadikfile);
				floppy.AddToList(negyedikfile);
                Console.WriteLine("A másolás sikeres!");
            }
			catch (Exception)
			{
                Console.WriteLine("Másolási hiba történt!");
                throw;
			}

			Console.WriteLine("Teszt: A fájlok írása a dvd elkezdődött:");
			try
			{
				dvd.AddToList(otodikfile);
				dvd.AddToList(hatodikfile);
				dvd.AddToList(hetedikfile);
			}
			catch (Exception)
			{
				Console.WriteLine("Írási hiba történt!");
				throw;
			}

			Console.WriteLine("A DVD-t lezártuk.");
			dvd.LezartAllapotbaRaktuk = true;

			Console.WriteLine("Újra próbálok írni a dvd lemezre 1 fájlt:");
			try
			{
				dvd.AddToList(nyolcadikfile);
			}
			catch (Exception)
			{
				Console.WriteLine("Írási hiba történt!");
				throw;
			}

			Console.WriteLine("Tárhely adatok: ****************************************************");
			Console.WriteLine($"A felhasznált tárhely: {floppy.UsedCapacity}KB a {floppy.MaxCapacity}KB-ból");
            Console.WriteLine($"A Floppy-n {floppy.FreeKapacitas}KB szabad tárhely maradt.");
			Console.WriteLine();
			Console.WriteLine($"A felhasznált tárhely: {dvd.UsedCapacity}KB a {dvd.MaxCapacity}KB-ból");
			Console.WriteLine($"A DVD-n {dvd.FreeKapacitas}KB szabad tárhely maradt.");


			Console.ReadKey();
		}
	}
}
