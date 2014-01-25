using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public GameObject cellObjectPrefab;
	public List<GameObject> m_candyPrefabList = new List<GameObject>();
	private float m_gridPadding = 0.2f;
	private float m_candySize = 0.85f;

	// Use this for initialization
	void Start () {

		//temp
		//LoadResource("Levels/1");

	}

	public void LoadResource(Session session,string levelName){

		GridManager gridManager = session.gridManager;
		Debug.Log ("LevelName:" + levelName);
		TextAsset text = Resources.Load( levelName ) as TextAsset;
		Debug.Log( text.text );
		
		Dictionary<string,object> levelData = MiniJSON.Json.Deserialize( text.text ) as Dictionary<string, object>;
		Dictionary<string, object> meta = levelData[ "level" ] as Dictionary<string, object>;
		
		int x = (int)(long)meta[ "grid_x" ];
		int y = (int)(long)meta[ "grid_y" ];
		int moves = (int)(long)meta[ "moves" ];
		

		float rotation = (float)(double)meta[ "rotation" ];
		
		Debug.Log ( "Grid size: " + x + " by " + y + " - rotated by: " + rotation );
		
		List<object> grid = levelData[ "grid" ] as List<object>;
		Vector2 offset = new Vector2(
			( ( ( x * m_candySize ) + ( m_gridPadding * ( x - 1 ) ) ) / 2f ) - ( m_candySize / 2f ),
			( ( ( y * m_candySize ) + ( m_gridPadding * ( y - 1 ) ) ) / 2f ) - ( m_candySize / 2f )
			);
		
		Debug.Log( "Offset: " + offset );


		//GameObject currentLevel = new GameObject( "GeneratedLevel" );
		//currentLevel.transform.position = Vector3.zero;
		
		gridManager.dimension = new Vector2(x,y);

		int numTypes = m_candyPrefabList.Count;
		for( int i = 0; i < y; i++ ) {
			List<object> row = grid[ i ] as List<object>;
			for ( int j = 0; j < x; j++ ) {
				
				int type = (int)(long)row[ j ];
				
				
				GameObject cellObj = Instantiate( cellObjectPrefab,
				                                 new Vector3( 
				            ( j * ( m_gridPadding + m_candySize ) ) - offset.x, 
				            ( i * -( m_gridPadding + m_candySize ) ) + offset.y, 
				            0f ), Quaternion.Euler( 0, 0, -rotation ) ) as GameObject;
				
				
				//if( cellObj == null ) Debug.Log ("Cell");
				//cellObj.transform.parent = currentLevel.transform;
				
				gridManager.addCellObject(cellObj.GetComponent<CellObject>(),j,i);
				
				if ( type < 0 || type >= numTypes  ) { continue; }
				
				
				GameObject go = Instantiate( m_candyPrefabList[ type ],
				                            new Vector3( 
				            0,0,0 ), 
				                            Quaternion.Euler( 0, 0, -rotation ) ) as GameObject;
				
				GridObject gObj = go.GetComponent<GridObject>();
				gridManager.addGridObject(gObj,j,i);
				
				if( gObj.type == GridObjectType.GRIDOBJECTTYPE_GUMSHOE ){
					gridManager.gumShoe = gObj as GumShoe;
				}
				
				//go.transform.parent = cellObj.transform;
				//GridObject gridObject = go.GetComponent<GridObject>();
				//gridObject.grid_x = j;
				//gridObject.grid_y = i;
				
				
				
			}
		}
		
		//currentLevel.transform.rotation = Quaternion.Euler( 0, 0, rotation );

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
