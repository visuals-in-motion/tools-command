using System;
using System.Diagnostics;
using UnityEngine;

namespace Visuals
{
    public class CommandLine : MonoBehaviour
    {
		public static string Run(string command)
		{
			var processInfo = new ProcessStartInfo();
			processInfo.RedirectStandardOutput = true;
			processInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;

#if UNITY_EDITOR_WIN
			processInfo.FileName = "cmd.exe";
#else
#if UNITY_EDITOR_OSX
			processInfo.FileName = "/bin/bash";
#endif
#endif
			processInfo.WorkingDirectory = Application.dataPath.Replace("/Assets", "");
			processInfo.Arguments = "/c " + command;

			var process = Process.Start(processInfo);
			string output = process.StandardOutput.ReadToEnd();
			process.Close();
			return output;
		}
	}
}