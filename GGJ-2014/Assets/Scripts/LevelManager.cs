using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public List<GameObject> m_candyPrefabList = new List<GameObject>();
	private float m_gridPadding = 2f;

	// Use this for initialization
	void Start () {
		TextAsset text = Resources.Load( "Levels/1" ) as TextAsset;
		Debug.Log( text.text );

		Dictionary<string,object> levelData = MiniJSON.Json.Deserialize( text.text ) as Dictionary<string, object>;
		Dictionary<string, object> meta = levelData[ "level" ] as Dictionary<string, object>;

		int x = (int)(long)meta[ "grid_x" ];
		int y = (int)(long)meta[ "grid_y" ];
		float rotation = (float)(double)meta[ "rotation" ];

		Debug.Log ( "Grid size: " + x + " by " + y + " - rotated by: " + rotation );

		List<object> grid = levelData[ "grid" ] as List<object>;


		int numTypes = m_candyPrefabList.Count;
		for( int i = 0; i < y; i++ ) {
			List<object> row = grid[ i ] as List<object>;
			for ( int j = 0; j < x; j++ ) {

				int type = (int)(long)row[ j ] - 1;
				if ( type < 0 || type >= numTypes  ) { continue; }

				GameObject go = Instantiate( m_candyPrefabList[ type ],
				                            new Vector3( j * m_gridPadding, i * -m_gridPadding, 0f ), 
				                            Quaternion.identity ) as GameObject;

				GridObject gridObject = go.GetComponent<GridObject>();
				gridObject.grid_x = j;
				gridObject.grid_y = i;

				go.transform.parent = this.transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
