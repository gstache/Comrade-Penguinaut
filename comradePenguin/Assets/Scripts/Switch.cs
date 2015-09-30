using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
	private Animator animator;
	public DoorTrigger[] doorTriggers; 
	public bool sticky;
	private bool down;
	public AudioClip sound;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collider){
		animator.SetInteger ("AnimState", 1);
		if(sound)
			AudioSource.PlayClipAtPoint(sound, transform.position);
		down = true;
		foreach (DoorTrigger trigger in doorTriggers) {
			if (trigger != null)
				trigger.toggle (true);
		}
	}
	void OnTriggerExit2D(Collider2D collider) {
		if (sticky && down) {
			return;
		}
		animator.SetInteger ("AnimState", 2);
		down = false;
		foreach (DoorTrigger trigger in doorTriggers) {
			if (trigger != null)
				trigger.toggle (false);
	
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = sticky ? Color.red : Color.green;
		foreach (DoorTrigger trigger in doorTriggers) {
			if (trigger != null)
				Gizmos.DrawLine(transform.position, trigger.door.transform.position);
		}
	}
}
