using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour {

	public List<CellObject> cellObjects;
	public Vector2 dimension = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addCellObject(CellObject obj,int col,int row){
		cellObjects.Add(obj);
		obj.grid_x = col;
		obj.grid_y = row;
	}

	public void addGridObject(GridObject obj,int col,int row){
		Debug.Log ("LOG: " + GridManager.Get1DCoordinate(this.dimension,col,row));
		cellObjects[GridManager.Get1DCoordinate(this.dimension,col,row)].addGridObject(obj); 
	} 

	public static int Get1DCoordinate(Vector2 dimension,int col,int row){
		return (row * (int)dimension.y) + col;
	}
}


