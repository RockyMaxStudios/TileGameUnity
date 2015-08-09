using UnityEngine;
using System.Collections;

public class LoadSceneM : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Loads the Game Scene Specifically for my game
    public void LoadAScene()
    {
        Application.LoadLevel("AlliGameScene 2");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
