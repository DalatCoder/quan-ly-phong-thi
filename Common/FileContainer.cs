using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	[Serializable]
    public class FileContainer
    {
        public byte[] FileContent { get; private set; }
        public FileInfo FileInfo { get; private set; }
		public string ClientPath { get; set; }
		public string ServerPath { get; set; }

		public FileContainer(string fileNameURL, string clientPath, string serverPath)
        {
            FileInfo = new FileInfo(fileNameURL);

            using (FileStream file = new FileStream(fileNameURL, FileMode.Open))
            {
                MemoryStream stream = new MemoryStream();
                file.CopyTo(stream);

                FileContent = stream.ToArray();
            }

            ClientPath = clientPath;
            ServerPath = serverPath;
        }
    }
}
