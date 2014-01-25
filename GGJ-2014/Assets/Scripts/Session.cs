using UnityEngine;
using System.Collections;

public class Session : MonoBehaviour {

	public GridManager gridManager;

	void Awake(){
		//add a grid manager to session 
		GameObject go = new GameObject("GridManager");
		gridManager = go.AddComponent<GridManager>();
		go.transform.parent = this.transform;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}



}
