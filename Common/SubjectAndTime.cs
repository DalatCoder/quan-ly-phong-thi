using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

	[Serializable]
	public class SubjectAndTime
	{
		public string Subject { get; set; }
		public int Minute { get; set; }

		public SubjectAndTime()
		{

		}

		public SubjectAndTime(string subject, int minute)
		{
			Subject = subject;
			Minute = minute;
		}
	}
}
