using UnityEngine;
using System.Collections;

public class MapSquare : MonoBehaviour {
	public string scene;
	private bool selected;
	public delegate void TapAction(Touch t);
	public static event TapAction OnTap;
	public int level;
	private int completed;
	// Use this for initialization
	void Start () {
		completed = PlayerPrefs.GetInt ("level");
		selected = (level <= completed);
		print (selected);
		print (completed + " " + level);
		SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer> ();
		if (completed < level) {
			sp.color = new Color(0.2f, 0.2f, 0.2f);
		} else {
			sp.color = new Color(1.0f, 1.0f, 1.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount> 0) {
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;
			bool moving = Physics.Raycast (ray,out hit);
			Transform trans = hit.transform;
			if(hit.collider != null && selected && trans.position == gameObject.transform.position) {

				Application.LoadLevel(scene);

			}
		}
		
		

		if (Input.GetMouseButtonDown(0)) {
			print ("click");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			bool moving = Physics.Raycast (ray,out hit);
			Transform trans = hit.transform;

			if(hit.collider != null && selected && trans.position == gameObject.transform.position) {
				print (level + " " + completed);
				Application.LoadLevel(scene);
				
			}
		}
			
			

		if (Input.GetKey(KeyCode.Escape)) {
			PlayerPrefs.Save();
			Application.LoadLevel ("Splash");
		}
	}


}
