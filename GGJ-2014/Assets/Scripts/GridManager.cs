using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour {

	public List<CellObject> cellObjects = new List<CellObject>();
	public Vector2 dimension = Vector2.zero;

	public GumShoe gumShoe;
	public Shaker shaker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addCellObject(CellObject obj,int col,int row){
		cellObjects.Add(obj);
		obj.transform.parent = this.transform;
		obj.grid_x = col;
		obj.grid_y = row;
	}

	public void addGridObject(GridObject obj,int col,int row){
		cellObjects[GridManager.Get1DCoordinate(this.dimension,col,row)].addGridObject(obj); 
	}

	public GridObject getGridObjectAt( int col, int row ) {
		if ( col < 0 || row < 0 ) { return null; }
		int coordinate = GridManager.Get1DCoordinate(this.dimension,col,row);
		if ( coordinate >= cellObjects.Count ) { return null; }
		return cellObjects[ coordinate ].gridObject; 
	}

	public static int Get1DCoordinate(Vector2 dimension,int col,int row){
		return (row * (int)dimension.y) + col;
	}

	public void OnClickedCell( CellObject obj ){

		Debug.Log( "Clicked cell at " + obj.grid_x + " " + obj.grid_y );

		if( gumShoe.isEating ) return;

		CellObject gumShoeCell = (gumShoe.transform.parent).gameObject.GetComponent<CellObject>();

		if( !GridManager.IsAdjacent( obj, gumShoeCell ) ){

			//not adjacent return 
			Debug.Log( "Block is not adjacent" );
			return;
		}

		Candy candy = obj.gridObject as Candy;

		if ( gumShoe.CanConsume( candy ) ) {

			Debug.Log( "Can Consume => " + ((int)gumShoe.currentCandy) + " " + ((int)candy.candyType ));
			gumShoe.Consume( candy );

			InGameCore.Instance.currentSession.IncrementMoves();

			// Highlight the reset button
			if ( ! InGameCore.Instance.currentSession.NoMoreKings() ) {
				int[,] check = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

				bool hasNext = false;
				for( int i = 0; i < 4; i++ ) {

					GridObject go = this.getGridObjectAt( check[i, 0] + obj.grid_x, check[i, 1] + obj.grid_y );
					if ( go == null ) { continue; }

					Candy neighborCheck = go as Candy;
					if ( neighborCheck == null ) { continue; }
					if ( gumShoe.CanConsume( neighborCheck ) ) { 
						hasNext = true;
						break;
					}
				}

				if ( !hasNext && shaker != null ) {

					shaker.bIsEnabled = true;

				}
			}


		} else {

			Debug.Log( "Cannot Consume => " + ((int)gumShoe.currentCandy) + " " + ((int)candy.candyType ));

		}
	}

	public static bool IsAdjacent( CellObject obj1, CellObject obj2 ){
		return( Mathf.Abs( obj1.grid_x - obj2.grid_x ) + Mathf.Abs( obj1.grid_y - obj2.grid_y ) == 1 );
	}


}


