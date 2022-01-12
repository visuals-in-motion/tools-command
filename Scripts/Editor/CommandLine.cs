using System;
using System.Diagnostics;
using UnityEngine;

namespace Visuals
{
    public class CommandLine
    {
		public static string Run(string command, string workingDirectory = null, bool enableOutput = true)
		{
			var processInfo = new ProcessStartInfo();
			processInfo.RedirectStandardOutput = true;
			processInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;

#if UNITY_STANDALONE_WIN || UNITY_WSA || UNITY_WSA_10_0
			processInfo.FileName = "cmd.exe";
			processInfo.Arguments = "/c " + command;
#elif UNITY_STANDALONE_OSX
			processInfo.FileName = "/bin/bash";
			processInfo.Arguments = $"-c \" {command} \"";
#endif
			processInfo.WorkingDirectory = (string.IsNullOrEmpty(workingDirectory)) ? Application.dataPath.Replace("/Assets", "") : workingDirectory;			
			
			var process = Process.Start(processInfo);
			string output = (enableOutput) ? process.StandardOutput.ReadToEnd() : string.Empty;
			process.Close();
			return output;
		}
	}
}