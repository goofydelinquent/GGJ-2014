using UnityEngine;
using System.Collections;

public class ToggleWindow : MonoBehaviour {

	public bool bIsEnabled = false;
	public float toggleSpeed = 3.5f;

	// Use this for initialization
	void Start () {

		float scale = bIsEnabled ? 1f : 0f;
		this.transform.localScale = new Vector3( scale, scale, 1f );
		Color c = this.renderer.material.color;
		c.a = scale;
		this.renderer.material.color = c;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 scale = this.transform.localScale;

		if ( bIsEnabled && scale.x < 1f ) {

			scale.x = Mathf.Clamp01( scale.x + ( Time.deltaTime * toggleSpeed ) );
			scale.y = scale.x;
			this.transform.localScale = scale;

			Color c = this.renderer.material.color;
			c.a = scale.x;
			this.renderer.material.color = c;

		} else if ( ( ! bIsEnabled ) && scale.x > 0f ) {

			scale.x = Mathf.Clamp01( scale.x - ( Time.deltaTime * toggleSpeed ) );
			scale.y = scale.x;
			this.transform.localScale = scale;

			Color c = this.renderer.material.color;
			c.a = scale.x;
			this.renderer.material.color = c;

		}
	}
}
