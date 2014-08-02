using UnityEngine;
using UnityEditor;
using System.Collections;


public class steamWorksEditor : EditorWindow {


	[MenuItem("Window/SteamWorks.Net")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(steamWorksEditor));
	}

	void OnGUI()
	{
		EditorGUILayout.LabelField("Steamworks.Net");
		//Pull this from a file on github?
		EditorGUILayout.LabelField("Version: Stable - 4.0.0");

		GUILayout.Space(10);

		EditorGUILayout.LabelField("Steamworks.Net Versions");

		if(GUILayout.Button("Go To GitHub"))
		{
			Application.OpenURL("https://github.com/rlabrecque/Steamworks.NET");
		}

		if(GUILayout.Button("Download Stable"))
		{
			Application.OpenURL("https://github.com/rlabrecque/Steamworks.NET/archive/4.0.0.zip");
		}
		if(GUILayout.Button("Download Experimental/Cutting Edge"))
		{
			Application.OpenURL("https://github.com/rlabrecque/Steamworks.NET/archive/master.zip");
		}
		GUILayout.Space(10);
		EditorGUILayout.LabelField("Resources/Help");
		if(GUILayout.Button("Example Project"))
		{
			Application.OpenURL("https://github.com/rlabrecque/Steamworks.NET-Example");
		}

		if(GUILayout.Button("Report A Bug"))
		{
			Application.OpenURL("https://github.com/rlabrecque/Steamworks.NET/issues");
		}

		if(GUILayout.Button("Steam Discussion Forum"))
		{
			Application.OpenURL("http://steamcommunity.com/groups/steamworks/discussions/0/666827974770212954/");
		}

		if(GUILayout.Button("License"))
		{
			Application.OpenURL("http://www.opensource.org/licenses/mit-license.php");
		}


		GUILayout.Space(10);
		EditorGUILayout.LabelField("Contact");

		if(GUILayout.Button("Email: support@rileylabrecque.com"))
		{
			Application.OpenURL("support@rileylabrecque.com");
		}


		if(GUILayout.Button("Skype"))
		{
			Application.OpenURL("http://rileylabrecque.com/skype");
		}

		if(GUILayout.Button("Steam: rlabrecque"))
		{
			Application.OpenURL("http://steamcommunity.com/id/rlabrecque");
		}
	}

}



