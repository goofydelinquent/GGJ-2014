using UnityEngine;
using System.Collections;

public class GumShoe : GridObject {

	public CandyType currentCandy = 0;
	public GameObject topStache = null;
	public GameObject topHat = null;

	private CellObject m_targetCell = null;


	// Use this for initialization
	void Start (){

	}
	
	// Update is called once per frame
	void Update (){
	
	}

	public virtual void Consume( Candy candy ){

		this.currentCandy = candy.candyType;

		CellObject candycell = candy.transform.parent.gameObject.GetComponent<CellObject>();
		m_targetCell = candycell;

		StartCoroutine( "ConsumeAnimation" );

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


	public IEnumerator ConsumeAnimation()
	{
		Vector3 endPosition = m_targetCell.transform.position;

		while( this.transform.position != endPosition ) {
			Vector3 result = Vector3.MoveTowards( this.transform.position, endPosition, 3.5f * Time.deltaTime );
			this.transform.position = result;

			yield return new WaitForEndOfFrame();

		}

		CellObject gumShoeCell = this.transform.parent.gameObject.GetComponent<CellObject>();

		GridObject go = m_targetCell.removeGridObject();
		gumShoeCell.removeGridObject();
		m_targetCell.addGridObject( this );

		Destroy( go.gameObject );
	}
}
