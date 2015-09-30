using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = .3f;
	public AudioClip leftFootSound;
	public AudioClip rightFootSound;
	public AudioClip thudSound;
	public AudioClip rocketSound;
	public bool hasTreasure;
	private PlayerController controller;
	private Animator animator;
	void Start(){
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}
	void playLeftFootSound(){
		if (leftFootSound) {
			AudioSource.PlayClipAtPoint (leftFootSound, transform.position);
		}
	}

	void playRightFootSound(){
		if (rightFootSound) {
			AudioSource.PlayClipAtPoint (rightFootSound, transform.position);
		}
	}

	void playThudSound(){
		if (thudSound) {
			AudioSource.PlayClipAtPoint (thudSound, transform.position);
		}
	}

	void PlayRocketSound(){
		if (!rocketSound || GameObject.Find ("RocketSound")) {
			return;
		}
		GameObject go = new GameObject ("RocketSound");
		AudioSource aSrc = go.AddComponent<AudioSource> ();
		aSrc.clip = rocketSound;
		aSrc.volume = .5f;
		aSrc.Play ();
		Destroy (go, rocketSound.length);
	}

	void OnCollisionEnter2D( Collision2D target){
		if (!standing) {
			var absVelX = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
			var absVelY = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);
			if (absVelX <= .1f || absVelY <= .1f){
				playThudSound ();
			}
		}

			

	}

	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;

		var absVelX = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
		var absVelY = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);
		if (absVelY < .2f) {
			standing = true;
		} else {
			standing = false;
		}
		if (controller.moving.x != 0) {
			if (absVelX < maxVelocity.x) {
				forceX = standing ? controller.moving.x * speed
					: controller.moving.x * (speed * airSpeedMultiplier);
			}
			transform.localScale = new Vector3 (controller.moving.x/Mathf.Abs(controller.moving.x)*1, 1, 1);
			animator.SetInteger ("AnimState", 1);
		} else {
			animator.SetInteger ("AnimState", 0);
			
		}

		if (controller.moving.y > 0) {
			PlayRocketSound();
			if (absVelY < maxVelocity.y) {
				forceY = jetSpeed * controller.moving.y;
			}
			animator.SetInteger ("AnimState", 2);
		} else if (absVelY > 0) {
			animator.SetInteger ("AnimState", 3);

		}
		GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));
	}
}
