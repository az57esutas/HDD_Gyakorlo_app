using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HDD_Gyakorlo_app.Classes
{
	internal class Storage
	{
		//a tárolt fájlok listája:
		public static List<File> filelista = new List<File>();

		#region Propertyk:
		//a tároló kapacitása:
		private int maxCapacity;

		public int MaxCapacity
		{
			get
			{
				return maxCapacity;
			}
			set
			{
				maxCapacity = value;
			}
		}

		//szabad kapacitás:
		private int freeKapacitas;

		public int FreeKapacitas
		{
			get
			{
				
				int szam = (maxCapacity - UsedCapacity);
				return szam;
			}
			set
			{
				freeKapacitas = value;
			}
		}

		//felhasznált tárhely mérete:
		private int usedCapacity;
		public int UsedCapacity
		{
			get
			{

				return usedCapacity;
			}
			set
			{
				
				usedCapacity = value;
			}
		}

		#endregion

		#region Konstruktor
		protected Storage(int capacity)
		{
			this.MaxCapacity = capacity;
		}
		#endregion

		#region Metódusok
		public virtual void Format()
		{
			filelista.Clear();
		}

		//file hozzáadása a listához
		public virtual void AddToList(File file)
		{
			if (usedCapacity < maxCapacity)
			{
				foreach (File f in filelista)
				{
					if (file.FileName == f.FileName)
					{
						Console.WriteLine("Sikertelen mentés! Van már ilyen nevű file!");
						break;
					}
					
				}
				filelista.Add(file);
				usedCapacity += file.FileSize;
			}
		}
		
		//törli a megadott nevű fájlt a listából
		public virtual void DeleteFromList(string s)
		{
			foreach (File f in filelista)
			{
				if (f.FileName == s)
				{
					filelista.Remove(f);
					Console.WriteLine($"A {s} nevű fájl sikeresen törölve lett!");
				}
			}
		}

		//Megekersei a fájlt a listában, majd visszaadja
		public File SearchFile(string s)
		{
			foreach (File f in filelista)
			{
				if (f.FileName == s)
				{
					return f;
				}

			}
			return null;
		}
		
		#endregion

	}
}
