using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Session : MonoBehaviour {

	public GridManager gridManager;
	public List<object> moves = new List<object>();

	public int currentMoves = 0;
	public int movesIndex = 0;
	public bool canEatKing = false;

	void Awake(){
		//add a grid manager to session 
		GameObject go = new GameObject("GridManager");
		gridManager = go.AddComponent<GridManager>();
		go.transform.parent = this.transform;
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void PurgeMoves(){
		moves.RemoveAt(0);
	}

	public void IncrementMoves(){
		this.currentMoves++;
		if( !canEatKing ){
			if( IsMovesSatisfied() ){
				OnMovesSatisfied();
			}
		}
	}

	public bool NoMoreKings(){
		return moves.Count == 0;
	}

	private void OnMovesSatisfied(){
		//moves satisfied event
		Debug.Log("Moves Satisfied");
		canEatKing = true;
	}

	public bool IsMovesSatisfied()
	{
		Debug.Log ("Count " + this.moves);
		return( this.currentMoves >= 2 /*(int)(long)moves[this.movesIndex] */ );
		
	}

}
