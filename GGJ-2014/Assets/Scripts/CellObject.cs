using UnityEngine;
using System.Collections;

public class CellObject : MonoBehaviour {

	public GridObject gridObject;
	public int grid_x = -1;
	public int grid_y = -1;
	public GameObject cell_bg = null;
	public GameObject king_bg = null;
	public GameObject gumshoe_bg = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private bool isEmpty() {

		return ( gridObject == null );

	}

	public void addGridObject(GridObject obj){
		this.gridObject = obj;
		obj.transform.parent = this.transform;
		obj.transform.localPosition = Vector3.zero;

		if ( obj != null ) {
			Candy c = obj.GetComponent<Candy>();
			if ( c != null ) {

				if ( c.candyType == CandyType.CANDYTYPE_NONE ) {
					gumshoe_bg.SetActive( true );
					king_bg.SetActive( false );
				} else if ( c.candyType == CandyType.CANDYTYPE_KING ) {
					king_bg.SetActive( true );
					gumshoe_bg.SetActive( false );
				}
			}
		}

		cell_bg.SetActive( ! ( gumshoe_bg.activeSelf || king_bg.activeSelf ) );

		obj.OnIntro();
	}

	public void Jump(){
		if( isEmpty() ) return;
		if( gridObject.type != GridObjectType.GRIDOBJECTTYPE_CANDY ) return;

		gridObject.Jump();
	}

	public void Die(){
		if( isEmpty() ) return;
		if( gridObject.type != GridObjectType.GRIDOBJECTTYPE_CANDY ) return;
		
		gridObject.Die();
	}

	public GridObject removeGridObject() {
		GridObject go = gridObject;
		go.transform.parent = null;
		gridObject = null;
		Debug.Log( go );

		gumshoe_bg.SetActive( false );
		cell_bg.SetActive( true );

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
