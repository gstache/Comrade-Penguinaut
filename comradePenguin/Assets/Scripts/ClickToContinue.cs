using UnityEngine;
using System.Collections;

public class ClickToContinue : MonoBehaviour {
	public string scene;
	public int level;
	private bool loadlock;
	// Use this for initialization
	void Start () {
		try {
			level = PlayerPrefs.GetInt("level");
			if (level < 1) {
				PlayerPrefs.SetInt ("level", 1);
			}
		} catch {
			PlayerPrefs.SetInt ("level", 1);
			level = 1;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !loadlock)
			loadScene ();
	}

	void loadScene() {
		loadlock = true;
		Application.LoadLevel (scene);
	}
}
