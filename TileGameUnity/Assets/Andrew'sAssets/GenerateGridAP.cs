using UnityEngine;
using System.Collections;

public class GenerateGridAP : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject square = new GameObject ("square", typeof(Plane));
		//GameObject square = new Rect (100, 100, 100, 100);
		//square.transform.localScale = new Vector3(0f, 0f, 0.00f);
		//square.transform.rotation =  new Quaternion(1.5f, 1f, 1f, 0f);
		square.transform.parent = GameObject.Find("GamePanel").transform;
		square.AddComponent<CanvasRenderer> ();
		square.AddComponent<UnityEngine.UI.Image> ();
		//GameObject tile = new GameObject ("tile", CanvasRenderer, Image, Panel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
