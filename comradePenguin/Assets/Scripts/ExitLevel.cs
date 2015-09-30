using UnityEngine;
using System.Collections;

public class ExitLevel : MonoBehaviour {
	public string scene;
	public int level;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Player") {
			if(target.GetComponent<player>().hasTreasure){
				int cp = PlayerPrefs.GetInt("level");
				if (level == cp) {
					cp += 1;
					PlayerPrefs.SetInt("level", cp);
				}
				Destroy (target.gameObject);
				Application.LoadLevel ("map");
			}
		}
	}
}
