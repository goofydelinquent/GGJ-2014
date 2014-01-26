//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InGameCore : MonoBehaviour
{
	public LevelManager levelManager;
	public Session currentSession;
	public string currentLevel;

	public static List<string> levelToLoad = new List<string>();
	public List<string> levelQueue = new List<string>();

	public bool debug = true;
	public string debugLevel = "Levels/4x4/1";

	public SceneFadeInOut fader;

	//public UnityEngine.Random ran = new UnityEngine.Random();

	private static InGameCore _instance = null;
    public static InGameCore Instance { get {
				return InGameCore._instance == null ? 
					new InGameCore() : InGameCore._instance;
		} }
		

	void Awake(){
		InGameCore._instance = this;
	}

	void Start(){

		FillUpLevelQueue( InGameCore.levelToLoad );
		Next ();

	}
	
	private void Run(string level)
	{
		GameObject go = new GameObject("Session");
		this.currentSession = go.AddComponent<Session>();

		this.currentLevel = level;
		this.levelManager.LoadResource( this.currentSession , this.currentLevel );
	}

	public void Next(){
		Debug.Log ("Next: " + levelQueue.Count);

		if( currentSession != null ){
			Destroy( currentSession.gameObject );
		}

	

		if( debug )
		{
			Run ( debugLevel);
		}
		else
		{
			if( NoMoreLevels() )
			{
				SequenceCompleted();
				return;
			}
			Run ( GetLevelRandom() );
		}
	}

	private void SequenceCompleted(){
		Application.LoadLevel("Levelselection");
	}

	private bool NoMoreLevels(){
		return levelQueue.Count == 0;
	}

	public void FillUpLevelQueue(List<string> paths){
		levelQueue = paths;
	}

	public string GetLevelRandom(){
		int count = RemainingLevels();
		int index = UnityEngine.Random.Range( 0 , count - 1);
		return GetLevelAt(index);
	}
	
	public string GetLevelAt(int index){
		string path = levelQueue[index];
		levelQueue.RemoveAt(index);
		return path;
	}

	public int RemainingLevels(){
		return levelQueue.Count;
	}

	public void Reset(){

		if( currentSession != null ){
			Destroy( currentSession.gameObject );
		}

		Run (this.currentLevel);
	}

	public void LevelFinished(){
		StartCoroutine( CoLevelFinished() );
	}

	IEnumerator CoLevelFinished()
	{
		this.currentSession.gridManager.OnLevelFinished();

		yield return new WaitForSeconds( 1 );

		//fader.StartScene();
		//yield return new WaitForSeconds( 1 );
		//fader.EndScene();

		this.Next();
	}

	void Update(){

		if( Input.GetKeyDown(KeyCode.R) )
		{
			//Debug.Log("RESET");
			Reset();
		}

		if( Input.GetKeyDown(KeyCode.N) )
		{
			//Debug.Log("RESET");
			Next();
		}
	}

}




