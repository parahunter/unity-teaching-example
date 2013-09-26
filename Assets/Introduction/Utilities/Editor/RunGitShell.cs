using UnityEngine;
using UnityEditor;
using System.Collections;

public class RunGitShell 
{	
	private const string gitCommand = "powershell";
	
	[MenuItem("Utilities/Version Control/Open Git Shell %&g")]
	public static void OpenShell()
	{
		System.Diagnostics.Process.Start(gitCommand);	
	}	
}
