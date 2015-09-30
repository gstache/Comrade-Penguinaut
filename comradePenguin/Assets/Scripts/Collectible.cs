using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
	public AudioClip pickupSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "Player") {
			if(gameObject.tag == "Artifact"){
				target.GetComponent<player>().hasTreasure = true;
				Meter m = target.GetComponent<Meter> ();
				m.air += 5;
				if (m.air > m.maxAir) {
					m.air = m.maxAir;
				}
				target.GetComponent<Meter>().air = m.air;
			}
			if (gameObject.tag == "crystal"){
				Meter m = target.GetComponent<Meter> ();
				m.air += 5;
				if (m.air > m.maxAir) {
					m.air = m.maxAir;
				}
				target.GetComponent<Meter>().air = m.air;
			}
			if(pickupSound)
				AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			Destroy(gameObject);
		}
	}
}
