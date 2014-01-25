using UnityEngine;
using System.Collections;

public class Candy : GridObject {
	
	public CandyType candyType = CandyType.CANDYTYPE_1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void OnConsumed(){
		//play consume animation
	}
}

public enum CandyType{
	CANDYTYPE_NONE = 0,
	CANDYTYPE_1,
	CANDYTYPE_2,
	CANDYTYPE_3
}