using UnityEngine;
using System.Collections;

public class CellObject : MonoBehaviour {

	public GridObject gridObject;
	public int grid_x = -1;
	public int grid_y = -1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void isEmpty(){

	}

	public void addGridObject(GridObject obj){
		this.gridObject = obj;

		obj.transform.parent = this.transform;
		obj.transform.localPosition = Vector3.zero;

		// add transform here
	}
}
