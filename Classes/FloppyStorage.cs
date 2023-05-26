using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDD_Gyakorlo_app.Classes
{
	internal class FloppyStorage : Storage
	{
        #region Propertyk

        public int maxCapacity = 1440;

        public bool irasvedett { get; set; }

        #endregion
        #region Konstruktor

        public FloppyStorage(int maxCapacity) : base(maxCapacity)
        {
            base.MaxCapacity = this.maxCapacity;
        }

        #endregion


        #region Metódusok

        public override void Format()
        {
            if (!irasvedett)
            {
                base.Format();
            }
            else throw new Exception("Hiba! A Floppy ÍRÁSVÉDETT!");
              
        }

		public override void DeleteFromList(string s)
		{
            if (!irasvedett)
            {
                base.DeleteFromList(s);
            }
			else throw new Exception("Hiba! A Floppy ÍRÁSVÉDETT!");

		}

		public override void AddToList(File file)
		{
            if (!irasvedett)
            {
                base.AddToList(file);
            }
            else throw new Exception("Hiba! A Floppy ÍRÁSVÉDETT!");
		}

		#endregion

	}
}
