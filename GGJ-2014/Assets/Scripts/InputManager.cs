using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public string m_candyLayer = "Candies";
	public string m_uiLayer = "UI";

	void Start (){
	
	}

	float startTime;
	Vector2 startPos;
	bool couldBeSwipe;
	float comfortZone;
	float minSwipeDist;
	float maxSwipeTime;

	MousePhase mousePhase;

	Vector3 currentTouchPosition;

	/*
	void Update(){
		
		if (iPhoneInput.touchCount > 0) {
			
			Touch touch = Input.touches[0];
			
			
			
			switch (touch.phase) {
				
			case TouchPhase.Began:{
				
				couldBeSwipe = true;
				
				startPos = touch.position;
				
				startTime = Time.time;

				Debug.Log("TouchBegan!");

				break;
			}
				
				
			case TouchPhase.Moved:
				
				if (Mathf.Abs(touch.position.y - startPos.y) > comfortZone) {
					
					couldBeSwipe = false;
					
				}
				
				break;
				
				
				
			case TouchPhase.Stationary:
				
				couldBeSwipe = false;
				
				break;
				
				
				
			case TouchPhase.Ended:
				
				float swipeTime = Time.time - startTime;
				
				float swipeDist = (touch.position - startPos).magnitude;
				
				
				
				if (couldBeSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist)) {
					
					// It's a swiiiiiiiiiiiipe!
					
					var swipeDirection = Mathf.Sign(touch.position.y - startPos.y);
					
					
					
					// Do something here in reaction to the swipe.
					
				}
				
				break;
				
			}
			
		}
		
	}
*/



	void Update (){

		switch( mousePhase ){
			case MousePhase.Normal_Phase: {


				if( Input.GetMouseButtonDown(0) ){
				CellObject obj = CheckCollision( Input.mousePosition );

					if( obj != null ) {
							if( obj.ContainsGumShoe() ){
								mousePhase = MousePhase.Drag_Phase;
							}
							
						}
					
				}

				if( Input.GetMouseButtonUp(0) ){
					CellObject obj = CheckCollision( Input.mousePosition );
						if( obj!=null ){
							obj.OnClick();
						}
						
					}

			currentTouchPosition = Input.mousePosition;
				}

			break;
			case MousePhase.Drag_Phase: {

			if( (Input.mousePosition - this.currentTouchPosition).sqrMagnitude < 55 )
			{
				break;
			}

			if( Input.GetMouseButtonUp(0) ){
				mousePhase = MousePhase.Normal_Phase; break;
			}
			CellObject obj = CheckCollision( Input.mousePosition );
				if( obj!=null ){
					obj.OnClick();
				}
				
		
			}
			break;
	
		}

		/*
		// 0 - Left, 1 - Right, 2 - Middle 
		if( Input.GetMouseButtonUp( 0 ) ) {

			Vector3 position = Input.mousePosition;
			Vector3 worldPoint = Camera.main.ScreenToWorldPoint( position );

			int layer = 1 << LayerMask.NameToLayer( m_candyLayer );
			Vector2 point = new Vector2( worldPoint.x, worldPoint.y );
			Collider2D collider = Physics2D.OverlapPoint(point, layer );
			if ( collider != null  )
			{
				Debug.Log( "Collided: " + collider.name );
				CellObject go = collider.GetComponent<CellObject>();

				if ( go != null ) {

					go.OnClick();

				}
			}

			layer = 1 << LayerMask.NameToLayer( m_uiLayer );
			collider = Physics2D.OverlapPoint(point, layer );
			if ( collider != null  )
			{
				if ( collider.name == "reset" ) {

					Application.LoadLevel( Application.loadedLevel );

				}
			}




		}
	*/
	}

	private CellObject CheckCollision(Vector3 position){
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint( position );
		
		int layer = 1 << LayerMask.NameToLayer( m_candyLayer );
		Vector2 point = new Vector2( worldPoint.x, worldPoint.y );
		Collider2D collider = Physics2D.OverlapPoint(point, layer );
		if ( collider != null  ){

			if ( collider.name == "reset" ) {
				
				InGameCore.Instance.Reset();
				return null;
				
			}

			CellObject go = collider.GetComponent<CellObject>();



			return go;
		}

		return null;
	}
}

public enum MousePhase{
	Normal_Phase,
	Drag_Phase
}
