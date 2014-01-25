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

	public virtual void Consume(Candy candy){
		this.currentCandy = candy.candyType;
	}


}
