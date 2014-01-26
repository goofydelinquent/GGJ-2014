using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Parallaxer : MonoBehaviour {

	public List<GameObject> layers = new List<GameObject>();
	public float parallaxFactor = 0.3f;

	// Update is called once per frame
	void Update () {


		Vector3 mousePosition = Input.mousePosition;
		Vector2 position = new Vector2( 
		                               -1 * ( ( Mathf.Clamp01( mousePosition.x / Screen.width ) ) - 0.5f ), 
		                               -1 * ( ( Mathf.Clamp01( mousePosition.y / Screen.height ) ) - 0.5f ) );

		for( int i = 0; i < layers.Count; i++ ) {

			GameObject current = layers[ i ];
			Vector3 newPosition = new Vector3( 
			                                  position.x * ( parallaxFactor * i ),
			                                  position.y * (parallaxFactor * i ),
			                                  current.transform.position.z );

			current.transform.position = newPosition;

		}
	}
}
