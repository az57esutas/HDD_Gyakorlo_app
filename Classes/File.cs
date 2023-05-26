using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDD_Gyakorlo_app.Classes
{
	internal class File
	{
		#region Propertyk
		public string FileName { get; set; }
		public int FileSize { get; set; }
        #endregion
        public filetipus FileType { get; set; }

        public enum filetipus
        {
            CsakOlvashato,
            Rendszer,
            Rejtett
        }


        public File(string name, int size, filetipus t)
        {
            FileName = name;
            FileSize = size;
            FileType = t;
        }
    }
}
