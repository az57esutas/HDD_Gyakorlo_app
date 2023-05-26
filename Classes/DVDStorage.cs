using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDD_Gyakorlo_app.Classes
{
	internal class DVDStorage : Storage
	{
		#region Propertyk

		public int maxCapacity = 4700000;

		
		private bool zarolt;
		
		public bool Zarolt
		{
			get 
			{ 
				return zarolt; 
			}
			set 
			{
				if (!lezartAllapotbaRaktuk)
				{
					zarolt = value;
					lezartAllapotbaRaktuk = true;
				}				 
			}
		}

		private bool lezartAllapotbaRaktuk;

		public bool LezartAllapotbaRaktuk
		{
			get 
			{ 
				return lezartAllapotbaRaktuk; 
			}
			set 
			{ 
				lezartAllapotbaRaktuk = value; 
			}
		}

		#endregion

		#region Konstruktor

		public DVDStorage(int maxCapacity) : base(maxCapacity)
		{
			base.MaxCapacity = this.maxCapacity;
		}

		#endregion
		#region Metódusok
		
		public override void Format()
		{
			if (!lezartAllapotbaRaktuk)
			{
				base.Format();
			}
			else throw new Exception("Hiba! A DVD Le lett zárva!");

		}

		public override void DeleteFromList(string s)
		{
			if (!lezartAllapotbaRaktuk)
			{
				base.DeleteFromList(s);
			}
			else throw new Exception("Hiba! A DVD Le lett zárva!");

		}

		public override void AddToList(File file)
		{
			if (!lezartAllapotbaRaktuk)
			{
				base.AddToList(file);
			}
            //else throw new Exception("Hiba! A DVD Le lett zárva!");
            else Console.WriteLine("Hiba! A DVD Le lett zárva!");
        }

		#endregion

	}
}
