using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public string m_candyLayer = "Candies";
	public string m_uiLayer = "UI";

	void Start () {
	
	}

	void Update () {

		// 0 - Left, 1 - Right, 2 - Middle 
		if( Input.GetMouseButtonUp( 0 ) ) {

			Vector3 position = Input.mousePosition;
			Vector3 worldPoint = Camera.main.ScreenToWorldPoint( position );


			int layer = 1 << LayerMask.NameToLayer( m_candyLayer );
			Vector2 point = new Vector2( worldPoint.x, worldPoint.y );
			Collider2D collider = Physics2D.OverlapPoint(point, layer );
			if ( collider != null  )
			{
				Debug.Log( "Collided: " + collider.name );
				CellObject go = collider.GetComponent<CellObject>();

				if ( go != null ) {

					go.OnClick();

				}
			}

			layer = 1 << LayerMask.NameToLayer( m_uiLayer );
			collider = Physics2D.OverlapPoint(point, layer );
			if ( collider != null  )
			{
				if ( collider.name == "reset" ) {

					Application.LoadLevel( Application.loadedLevel );

				}
			}


			// If using 3D collider
			/*
			Ray ray = camera.ScreenPointToRay( position );
			Debug.DrawRay( ray.origin, ray.direction * 50, Color.green, 2f );

			RaycastHit hit;
			if ( Physics.Raycast( ray, out hit, Mathf.Infinity, cLayer ) ) {

				Debug.Log( "HIT: " + hit.collider.name );

			}*/

		}
	
	}
}
