using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateGridAP : MonoBehaviour {

	private int noRows = 10;
	private int noCols = 10;
	private int screenWidth;
	private int screenHeight;
	[HideInInspector] public List<Transform> planes = new List<Transform>();
	Camera cameraComponent;

	// Use this for initialization
	void Start () {

		var sceneCamera = GameObject.Find ("Main Camera");
		screenWidth = sceneCamera.GetComponent<Camera> ().pixelWidth;
		screenHeight = sceneCamera.GetComponent<Camera> ().pixelHeight;

		cameraComponent = GameObject.Find("Main Camera").GetComponent<Camera>();

		float squareSize = 47;

		for (int i = 0; i< noRows; i++) {
			for (int j = 0; j< noCols; j++) {
				GameObject square = new GameObject ("square-" + i + "-" + j, typeof(Plane));
				square.transform.parent = GameObject.Find ("GamePanel").transform;
				square.AddComponent<MeshRenderer> ();
				square.AddComponent<MeshCollider> ();
				square.AddComponent<UnityEngine.UI.Image> ();

				square.transform.localScale = new Vector3 ((float)(squareSize/100f), (float)(squareSize/100f), 1f);
				square.transform.localPosition = new Vector3 ((squareSize + 5) * i - ((noRows/2f) * (squareSize + 5)) + (squareSize/2f), (squareSize + 5) * j - ((noCols/2f) * (squareSize + 5)) + (squareSize/2f), 0f);


				planes.Add(square.transform);
				//square.GetComponent<Panel>().onClick.AddListener(() => { someFunction(); otherFunction(); }); 
				//square.transform.rotation =  new Quaternion(1.5f, 1f, 1f, 0f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {

			Ray clickRay = cameraComponent.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHitInfo;
			
			if (Physics.Raycast(clickRay, out rayHitInfo))
			{
				print ("Hit Something");
				foreach (Transform plane in planes)
				{
					if (rayHitInfo.collider.gameObject.transform == plane)
					{
						plane.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
					}
				}
			}
		}
	}

	/*void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			
			Ray clickRay = cameraComponent.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHitInfo;
			
			if (Physics.Raycast(clickRay, out rayHitInfo))
			{
				print ("Hit Something");
				foreach (Transform plane in planes)
				{
					if (rayHitInfo.collider.gameObject.transform == plane)
					{
						plane.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
					}
				}
			}
		}
	}*/
}
