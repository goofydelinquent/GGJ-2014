using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	const string pre = "Levels/";



	// Use this for initialization
	void Start () {
	
		//OnClicked4x4();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnClicked4x4(){
		LoadAllFromPath("4x4");
		NarrationManager.narrationIndex = 1;
	}

	private void OnClicked5x5(){
		LoadAllFromPath("5x5");
		NarrationManager.narrationIndex = 2;

	}

	private void OnClicked6x6(){
		LoadAllFromPath("6x6");
		NarrationManager.narrationIndex = 3;
	}

	private void OnClicked7x7(){
		LoadAllFromPath("7x7");
		NarrationManager.narrationIndex = 4;
	}

	private void OnClicked8x8(){
		LoadAllFromPath("8x8");
		NarrationManager.narrationIndex = 5;
	}

	private void LoadAllFromPath( string path )
	{
		path = pre + path;
		Object[] objects = Resources.LoadAll(path);
		Debug.Log (objects.Length);

		InGameCore.levelToLoad = new List<string>();
		foreach( Object obj in objects ){
			InGameCore.levelToLoad.Add( path + "/" +obj.name  );
		}

		Application.LoadLevel("Narration");
	}
}
