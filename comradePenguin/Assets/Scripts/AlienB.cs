using UnityEngine;
using System.Collections;

public class AlienB : MonoBehaviour {
	private Animator animator;
	private Collider2D targ;
	public bool readyToAttack;
	public Explode explode;
	public AudioClip attackSound;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (targ != null) {
			explode = targ.GetComponent<Explode> ();
			if (readyToAttack) {
				print ("explode");
				if(explode != null){
				explode.onExplode();
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		targ = target;
		explode = targ.GetComponent<Explode>();
		if (target.gameObject.tag == "Player") {
				print ("AnimationEvent");
				animator.SetInteger ("AnimState", 1);
			if(attackSound)
				AudioSource.PlayClipAtPoint(attackSound, transform.position);

		}
	}

	void OnTriggerExit2D(Collider2D target){
		readyToAttack = false;
		animator.SetInteger ("AnimState", 0);
		//gameObject.tag = "Untagged";
	}

	void Attack(){
		readyToAttack = true;
		//gameObject.tag = "Deadly";
	}
}

