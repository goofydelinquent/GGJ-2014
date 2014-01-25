using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public string m_candyLayer = "Candies";

	void Start () {
	
	}

	void Update () {

		// 0 - Left, 1 - Right, 2 - Middle 
		if( Input.GetMouseButtonUp( 0 ) ) {

			int cLayer = 1 << LayerMask.NameToLayer( m_candyLayer );

			Vector3 position = Input.mousePosition;

			Vector3 worldPoint = Camera.main.ScreenToWorldPoint( position );
			Collider2D collider = Physics2D.OverlapPoint( new Vector2( worldPoint.x, worldPoint.y ), cLayer );
			if ( collider != null  )
			{
				Debug.Log( "Collided: " + collider.name );
				Candy c = collider.GetComponent<Candy>();
				GridObject go = collider.GetComponent<GridObject>();
				if ( c != null ) {


				}

				if ( go != null ) {

					Debug.Log( go.grid_x + ", " + go.grid_y );

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
