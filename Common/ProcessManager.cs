using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class ProcessManager
	{
		List<string> processNames;
		public List<string> ProcessNames 
		{ 
			get
			{
				return new List<string>(processNames);
			}
		}

		event Action<string> _onInvalidProcessKilled;
		public event Action<string> OnInvalidProcessKilled
		{
			add
			{
				_onInvalidProcessKilled += value;
			}
			remove
			{
				_onInvalidProcessKilled -= value;
			}
		}

		public ProcessManager()
		{
			processNames = new List<string>();
			WaitForProcess();
		}

		public ProcessManager(List<string> processes)
		{
			processNames = new List<string>(processes);
			KillRunningProcess();
			WaitForProcess();
		}

		void KillRunningProcess()
		{
			try
			{
				foreach (string processName in processNames)
				{

					string processNameWithoutEXE = processName.Split('.')[0];
					Process[] pname = Process.GetProcessesByName(processNameWithoutEXE);

					if (pname.Length > 0)
					{
						foreach (Process item in pname)
						{
							if (item.ProcessName.ToUpper() == processNameWithoutEXE.ToUpper())
							{
								item.Kill();
							}
						}

						if (_onInvalidProcessKilled != null)
							_onInvalidProcessKilled(processNameWithoutEXE);
					}
				}
			}
			catch (Exception ex)
			{

			}
		}

		void WaitForProcess()
		{
			ManagementEventWatcher startWatch = new ManagementEventWatcher(
			  new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
			startWatch.EventArrived
								+= new EventArrivedEventHandler(startWatch_EventArrived);
			startWatch.Start();
		}

		void startWatch_EventArrived(object sender, EventArrivedEventArgs e)
		{
			string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
			string processNameWithoutEXE = processName.Split('.')[0];

			try
			{
				if (processNames.Contains(processName))
				{
					Process[] p = Process.GetProcessesByName(processNameWithoutEXE);

					foreach (Process item in p)
					{
						if (item.ProcessName.ToUpper() == processNameWithoutEXE.ToUpper())
						{
							item.Kill();
						}
					}

					if (_onInvalidProcessKilled != null)
						_onInvalidProcessKilled(processNameWithoutEXE);
				}
			}
			catch (Exception ex)
			{
				
			}
		}

		public void AddProcess(string process)
		{
			if (processNames.Contains(process))
				return;

			processNames.Add(process);

		}

		public void RemoveProcess(string process)
		{
			processNames.Remove(process);
		}
	}
}
