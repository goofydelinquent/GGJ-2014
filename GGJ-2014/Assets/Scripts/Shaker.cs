using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour {

	public bool bIsEnabled = false;
	private float m_time = 0f;
	public float rotation = 10f;
	public float timeFactor = 10f;

	// Update is called once per frame
	void Update () {

		if ( ! bIsEnabled ) { return; }

		m_time += Time.deltaTime * timeFactor;
		float currentRotation = Mathf.Sin( m_time ) * rotation;
		this.gameObject.transform.rotation = Quaternion.Euler( 0, 0, currentRotation );
	}
}
