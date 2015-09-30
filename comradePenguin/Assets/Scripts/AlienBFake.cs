using UnityEngine;
using System.Collections;

public class AlienBFake : MonoBehaviour {
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponentInParent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Player") {
			animator.SetInteger ("AnimState", 1);
		}
	
	}
	void OnTriggerExit2D(Collider2D target){
		if (target.tag == "Player") {
			animator.SetInteger ("AnimState", 0);
		}
		
	}
}
