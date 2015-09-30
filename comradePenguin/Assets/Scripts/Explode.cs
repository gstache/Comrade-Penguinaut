using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	public BodyPart bodyPart;
	public int totalParts= 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Deadly") {
			onExplode ();
		}
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Deadly") {
			onExplode ();
		}
	}

	public void onExplode(){
		Destroy (gameObject);
		var t = transform;
		for (int i =0; i <totalParts; i++) {
			t.TransformPoint (0, -100, 0);
			BodyPart clone = Instantiate(bodyPart, t.position, Quaternion.identity) as BodyPart;
			clone.GetComponent<Rigidbody2D>().AddForce (Vector3.right * Random.Range (-50, 50));
			clone.GetComponent<Rigidbody2D>().AddForce (Vector3.up * Random.Range (-10, 100));
		}
		GameObject go = new GameObject ("ClickToContinue");
		ClickToContinue script = go.AddComponent<ClickToContinue> ();
		script.scene = Application.loadedLevelName;
		go.AddComponent<DisplayRestartText> ();
	}
}
