using UnityEngine;
using System.Collections;

public class GumShoe : GridObject {

	public CandyType currentCandy = 0;

	// Use this for initialization
	void Start (){

	}
	
	// Update is called once per frame
	void Update (){
	
	}

	public virtual void Consume( Candy candy ){

		this.currentCandy = candy.candyType;

	}

	public bool CanConsume( Candy p_candy ) {

		// Zero type - can eat any.
		if ( currentCandy == 0 ) { return true; }

		// Same type - can eat
		if ( currentCandy == p_candy.candyType ) { return true; }

		//TODO rollover
		if ( ( (int)currentCandy - (int)p_candy.candyType ) == 1 ) {
			return true;
		} else if ( currentCandy == CandyType.CANDYTYPE_1 && p_candy.candyType == CandyType.CANDYTYPE_3 ) {
			return true;
		}

		return false;
	}
}
