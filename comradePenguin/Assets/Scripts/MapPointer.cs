using UnityEngine;
using System.Collections;

public class MapPointer : MonoBehaviour {
	float distance = 5.0f;
	Vector2 move;  
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		move.x = 0;
		move.y = 0;
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			move = Input.GetTouch(0).deltaPosition.normalized * -1;

		}

		if(Input.GetKey("left")){
			move.x = -1;
		} else if (Input.GetKey("right")){
			move.x = 1;
		}
		if (Input.GetKey ("up")) {
			move.y = 1;
		}
		if (Input.GetKey ("down")) {
			move.y = -1;
		}

		GetComponent<Rigidbody2D>().AddForce(new Vector2(move.x*5.0f, move.y*5.0f));
	}
}
