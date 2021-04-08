using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class DirectoryHelper
	{
        public static void DeleteAllFileInDirectory(string target_dir)
        {
            DirectoryInfo di = new DirectoryInfo(target_dir);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
