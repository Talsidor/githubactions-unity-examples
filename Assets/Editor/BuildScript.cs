using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Build automation helper methods, designed to be called when invoking the Editor via command line.
/// </summary>
public class BuildScript
{
	static void SetVersionNumberFromArg()
	{
		Console.WriteLine("BuildScript.SetVersionNumberFromArg() called");

		if (TryGetArg("-buildVersion", out string value))
		{
			PlayerSettings.bundleVersion = value;

			string msg = $"BuildScript.SetVersionNumberFromArg(): PlayerSettings.bundleVersion is now {PlayerSettings.bundleVersion}";
			Console.WriteLine(msg);
		}
	}

	static bool TryGetArg(string key, out string value)
	{
		if (key.StartsWith('-') == false)
		{
			Console.WriteLine($"BuildScript.TryGetArg('{key}') - key '{key}' has no leading dash, adding one");
			key = $"-{key}";
		}

		value = "";

		string[] args = System.Environment.GetCommandLineArgs();

		for (int i = 0; i < args.Length; i++)
		{
			if (args[i] == key)
			{
				if (i + 1 >= args.Length)
				{
					Console.WriteLine($"BuildScript.TryGetArg('{key}') - key was arg # '{i}' and there are only '{i}' args!");
					return false;
				}

				value = args[i + 1];
				return true;
			}
		}

		Console.WriteLine($"BuildScript.TryGetArg('{key}') - could not find any arg named '{key}'!");
		return false;
	}
}
