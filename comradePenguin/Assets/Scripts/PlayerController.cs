using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Vector2 moving = new Vector2();
	public delegate void TapAction(Touch t);
	public static event TapAction OnTap;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moving.x = moving.y = 0;
		if (Input.acceleration.x < -0.2) {
			moving.x = Input.acceleration.x;
		} else if (Input.acceleration.x > 0.2) {
			moving.x = Input.acceleration.x;
		}
		if(Input.GetKey("left")){
			moving.x = -1;
		} else if (Input.GetKey("right")){
			moving.x = 1;
		}
		if (Input.touchCount > 0) {
			moving.y = 1;
		} 
		if (Input.GetKey ("up")) {
			moving.y = 1;
		}
		if (Input.GetKey(KeyCode.Escape)) {
			Application.LoadLevel ("map");
		}
	}
}
