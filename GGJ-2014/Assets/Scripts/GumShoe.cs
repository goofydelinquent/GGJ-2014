using UnityEngine;
using System.Collections;

public class GumShoe : GridObject {

	public CandyType currentCandy = 0;
	public GameObject topStache = null;
	public GameObject topHat = null;
	private Animator animator = null;

	private CellObject m_targetCell = null;

	public bool isEating = false;

	// Use this for initialization
	void Start (){
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update (){
	
	}

	public virtual void Consume( Candy candy ){

		this.currentCandy = candy.candyType;

		CellObject candycell = candy.transform.parent.gameObject.GetComponent<CellObject>();
		m_targetCell = candycell;

		//prepare to back
		animator.SetTrigger( "PrepareToEat" );

		StartCoroutine( "ConsumeAnimation" );
	}

	public bool CanConsume( Candy p_candy ) {

		// Zero type - can eat any.
		if ( currentCandy == 0 ) { return true; }

		// Same type - can eat
		if ( currentCandy == p_candy.candyType ) { return true; }

		if( p_candy.candyType == CandyType.CANDYTYPE_KING && InGameCore.Instance.currentSession.IsMovesSatisfied() )
		{
			return true;
		}

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
		isEating = true;
	
		Vector3 endPosition = m_targetCell.transform.position;

		while( this.transform.position != endPosition ) {
			Vector3 result = Vector3.MoveTowards( this.transform.position, endPosition, 4.5f * Time.deltaTime );
			this.transform.position = result;

			yield return new WaitForEndOfFrame();

		}

		animator.SetTrigger( "PopIn" );

		CellObject gumShoeCell = this.transform.parent.gameObject.GetComponent<CellObject>();

		GridObject go = m_targetCell.removeGridObject();
		Candy otherCandy = go.GetComponent<Candy>();
		Candy gumshoeCandy = this.GetComponent<Candy>();

		otherCandy.candyBody.transform.parent = this.transform;
		GameObject oldBody = gumshoeCandy.candyBody;
		oldBody.transform.parent = null;
		gumshoeCandy.candyBody = otherCandy.candyBody;


		gumShoeCell.removeGridObject();
		m_targetCell.addGridObject( this );

		Destroy( go.gameObject );
		Destroy( oldBody.gameObject );

		isEating = false;

		if( currentCandy == CandyType.CANDYTYPE_KING ){
			InGameCore.Instance.LevelFinished();
		}
	}
}
