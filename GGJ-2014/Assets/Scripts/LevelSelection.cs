using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	const string pre = "Levels/";

	public AudioSource sfxSource;
	public AudioClip sfxClick;

	// Use this for initialization
	void Start () {
	
		//OnClicked4x4();
	}
	
	// Update is called once per frame
	void Update () {

		if( Input.GetMouseButtonDown(0))
		{
			Vector3 worldPoint = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			int layer = 1 << LayerMask.NameToLayer( "Default" );
			Vector2 point = new Vector2( worldPoint.x, worldPoint.y );
			Collider2D collider = Physics2D.OverlapPoint(point, layer );
			if ( collider != null  ){

				sfxSource.clip = sfxClick;
				sfxSource.Play();

				if ( collider.name == "1" ) {
					OnClicked4x4();
				}

				if ( collider.name == "2" ) {
					OnClicked5x5();
				}
				if ( collider.name == "3" ) {
					OnClicked6x6();
				}
				if ( collider.name == "4" ) {
					OnClicked7x7();
				}
				if ( collider.name == "5" ) {
					OnClicked8x8();
				}
			}
		}




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
