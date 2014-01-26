using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	public AudioSource sfxSource;
	public AudioClip sfxClick;
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
				sfxSource.clip = sfxClick;
				sfxSource.Play();
				if ( collider.name == "btn_play" ) {
					Application.LoadLevel("Levelselection");
					}
					
				if ( collider.name == "btn_credits" ) {
					Application.LoadLevel("Credits");
					}
					
				}
			}
	}
			

}
