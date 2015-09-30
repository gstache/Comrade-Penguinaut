﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject target;
	private Transform _t;
	// Use this for initialization
	void Awake() {
		GetComponent<Camera>().orthographicSize = ((Screen.height / 2.8f) / 100f);
	}
	void Start () {
		_t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(_t)
		transform.position = new Vector3 (_t.position.x, _t.position.y, transform.position.z);
	}
}
