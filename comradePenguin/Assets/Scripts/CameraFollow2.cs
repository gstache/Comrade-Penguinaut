using UnityEngine;
using System.Collections;

public class CameraFollow2 : MonoBehaviour {
	void Awake() {
		GetComponent<Camera>().orthographicSize = ((Screen.height / 2.8f) / 100f);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
