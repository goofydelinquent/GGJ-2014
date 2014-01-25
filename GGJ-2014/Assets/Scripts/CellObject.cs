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

	private bool isEmpty() {

		return (gridObject == null);

	}

	public void addGridObject(GridObject obj){
		this.gridObject = obj;
		obj.transform.parent = this.transform;
		obj.transform.localPosition = Vector3.zero;
	}

	public GridObject removeGridObject() {
		GridObject go = gridObject;
		go.transform.parent = null;
		gridObject = null;
		Debug.Log( go );
		return go;
	}

	public void OnClick(){
		//Debug.Log("onclick");

		if( isEmpty() ) return;
		if( gridObject.type != GridObjectType.GRIDOBJECTTYPE_CANDY ) return;

		this.SendMessageUpwards( "OnClickedCell" , this );
	}

	public bool ContainsGumShoe(){
		if( isEmpty() ) return false;
		return( gridObject.type == GridObjectType.GRIDOBJECTTYPE_GUMSHOE );
	} 
}
