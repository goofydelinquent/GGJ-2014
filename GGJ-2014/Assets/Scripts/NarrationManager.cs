using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NarrationManager : MonoBehaviour {

	private List<string> m_narrations = new List<string>();
	private List<float> m_delays = new List<float>();
	private float m_appearTime = 0.5f;
	private float m_disappearTime = 0.5f;
	private float m_currentTime = 0;
	private int m_currentIndex = 0;
	
	public TextMesh m_textMesh = null;

	public int id = 1;

	public List<AudioSource> audio = new List<AudioSource>();
	public static int narrationIndex = 1;


	// Use this for initialization
	void Start () 
	{
		id = narrationIndex;

		TextAsset text = Resources.Load( "Narrations/" + id ) as TextAsset;

		List<object> narrationData = MiniJSON.Json.Deserialize( text.text ) as List<object>;

		m_textMesh.text = string.Empty;

		foreach( List<object> o in narrationData ) {

			m_narrations.Add( (string)o[ 0 ] );
			m_delays.Add( (float)(double)o[ 1 ] );
		}

		m_textMesh.text = m_narrations[ 0 ];
		m_textMesh.color = new Color( m_textMesh.color.r, m_textMesh.color.g, m_textMesh.color.b, 0f );
		m_currentTime = -m_appearTime;

		audio[ id - 1 ].Play();
	}
		
	// Update is called once per frame
	void Update () {

		if( Input.GetMouseButtonDown(0) ){
			Application.LoadLevel("test");
		}

		if ( m_currentIndex >= m_narrations.Count ) {
			return;
		}

		m_currentTime += Time.deltaTime;
		float currentDelay = m_delays[ m_currentIndex ];
		float alpha = 0;
		if ( m_currentTime < 0 ) {
			alpha = Mathf.Lerp( 0f, 1f, ( m_appearTime + m_currentTime ) / m_appearTime );
		} else if ( m_currentTime > currentDelay ) {

			alpha = Mathf.Lerp( 1f, 0f, ( m_currentTime - currentDelay ) / m_disappearTime );

		} else {
			alpha = 1f;
		}

		m_textMesh.color = new Color( m_textMesh.color.r, m_textMesh.color.g, m_textMesh.color.b, alpha );


		if ( m_currentTime > currentDelay + m_disappearTime ) {

			m_currentIndex++;

			if ( m_currentIndex >= m_narrations.Count ) {

				Application.LoadLevel("test");
				return;
			}

			m_currentTime = -m_appearTime;
			m_textMesh.text = m_narrations[ m_currentIndex ];

		}


	}


}
