using UnityEngine;
using System.Collections;

public class Candy : GridObject {
	
	public CandyType candyType = CandyType.CANDYTYPE_1;
	public GameObject candyBody = null;
	public iTween tween;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public override void Jump(){
		Hashtable ht = new Hashtable();
		ht.Add("x",0);
		ht.Add("y",.2);
		ht.Add("time",2);
		ht.Add("delay",UnityEngine.Random.Range(0,0.5f));
		//ht.Add("looptype",iTween.LoopType.pingPong);
		iTween.PunchPosition( gameObject, ht );
	}
	
	public override void OnIntro(){
		//Debug.Log ("OnIntro");

		Hashtable ht = new Hashtable();
			ht.Add("x",.2);
			ht.Add("y",.2);
			ht.Add("time",1);
			ht.Add("delay",UnityEngine.Random.Range(0,0.5f));
			//ht.Add("looptype",iTween.LoopType.pingPong);
			iTween.PunchScale( gameObject, ht );
	}

	public override void Die(){
		Debug.Log ("OnDead");
		
		Hashtable ht = new Hashtable();
		ht.Add("x",0);
		ht.Add("y",0);
		ht.Add("time",UnityEngine.Random.Range(0,1.5f));
		ht.Add("delay",UnityEngine.Random.Range(0,.5f));
		//ht.Add("looptype",iTween.LoopType.pingPong);
		iTween.ScaleTo( gameObject, ht );
	}

	
	public virtual void OnConsumed(){
		//play consume animation
	}


}

public enum CandyType{
	CANDYTYPE_NONE = 0,
	CANDYTYPE_1,
	CANDYTYPE_2,
	CANDYTYPE_3,
	CANDYTYPE_KING
}