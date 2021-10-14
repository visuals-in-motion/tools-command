using System.Diagnostics;
using UnityEngine;

namespace Visuals
{
    public class CommandLine : MonoBehaviour
    {
		public static string Run(string command)
		{
#if UNITY_EDITOR_WIN
			var processInfo = new ProcessStartInfo();
			processInfo.RedirectStandardOutput = true;
			processInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.FileName = "cmd.exe";
			processInfo.WorkingDirectory = Application.dataPath.Replace("/Assets", "");
			processInfo.Arguments = "/c " + command;

			var process = Process.Start(processInfo);
			string output = process.StandardOutput.ReadToEnd();
			process.Close();
			return output;
#else
			return String.Empty;
#endif
		}
	}
}