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
	}

	private void OnClicked5x5(){
		LoadAllFromPath("5x5");
	}

	private void OnClicked6x6(){
		LoadAllFromPath("6x6");
	}

	private void OnClicked7x7(){
		LoadAllFromPath("7x7");
	}

	private void OnClicked8x8(){
		LoadAllFromPath("8x8");
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

		Application.LoadLevel("test");
	}
}
