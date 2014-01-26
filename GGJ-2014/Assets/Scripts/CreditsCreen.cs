using UnityEngine;
using System.Collections;

public class CreditsCreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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

			
					Application.LoadLevel("TitleScreen");

			}
		}


	}
}
