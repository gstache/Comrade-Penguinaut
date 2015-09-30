using UnityEngine;
using System.Collections;

public class AlienC : MonoBehaviour {
	public float attackDelay = 3f;
	private Animator anim;
	public Projectile projectile;
	public AudioClip attackSound;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		if (attackDelay > 0) {
			StartCoroutine (OnAttack ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetInteger ("AnimState", 0);
	}

	IEnumerator OnAttack(){
		yield return new WaitForSeconds (attackDelay);
		Fire ();
		StartCoroutine (OnAttack ());
	}

	void Fire() {
		anim.SetInteger ("AnimState", 1);
		if(attackSound)
			AudioSource.PlayClipAtPoint(attackSound, transform.position);
	}

	void OnShoot(){
		if (projectile) {
			Projectile clone = Instantiate (projectile, transform.position, Quaternion.identity) as Projectile;
		}
	}
}
