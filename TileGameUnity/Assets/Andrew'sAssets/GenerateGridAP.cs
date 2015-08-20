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
	private GameState gameState;

	// Use this for initialization
	void Start () {

		var sceneCamera = GameObject.Find ("Main Camera");
		screenWidth = sceneCamera.GetComponent<Camera> ().pixelWidth;
		screenHeight = sceneCamera.GetComponent<Camera> ().pixelHeight;
		Player player = new Player (1);
		gameState = new GameState (noRows, noCols);

		cameraComponent = GameObject.Find("Main Camera").GetComponent<Camera>();
		GameObject backgroundPanel = GameObject.CreatePrimitive(PrimitiveType.Plane);
		backgroundPanel.transform.localScale = new Vector3(1,1,1);
		backgroundPanel.transform.localPosition = new Vector3(0,0,10);
		backgroundPanel.transform.parent = GameObject.Find("GamePanel").transform;
		backgroundPanel.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
		backgroundPanel.transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));


		float squareSize = 47;

		for (int i = 0; i< noRows; i++) {
			for (int j = 0; j< noCols; j++) {
                //GameObject square = new GameObject ("square-" + i + "-" + j, typeof(Plane));

                GameObject square = GameObject.CreatePrimitive(PrimitiveType.Plane);
                square.gameObject.name = "square-" + i + "-" + j;
                square.transform.parent = GameObject.Find("GamePanel").transform;
                //square.AddComponent<MeshFilter> ();
                //square.AddComponent<MeshRenderer> ();
                //square.AddComponent<MeshCollider> ();
				//square.AddComponent<UnityEngine.UI.Image> ();

			
                //square.transform.localPosition = new Vector3 ((squareSize + 5) * i - ((noRows/2f) * (squareSize + 5)) + (squareSize/2f), (squareSize + 5) * j - ((noCols/2f) * (squareSize + 5)) + (squareSize/2f), 0f);
                var unityHeight = cameraComponent.orthographicSize * 2;
                var unityWidth = (cameraComponent.orthographicSize * 2) * cameraComponent.aspect;
                var scalingFactor = screenHeight/unityHeight;
                var newSquareSize = squareSize/scalingFactor;

                square.transform.localScale = new Vector3((float)(newSquareSize / 10f), 1f, (float)(newSquareSize / 10f));

                square.transform.localPosition = new Vector3((newSquareSize * 1.01f) * i - ((noRows / 2f) * (newSquareSize * 1.01f)) + (newSquareSize / 2f), (newSquareSize * 1.01f) * j - ((noCols / 2f) * (newSquareSize * 1.01f)) + (newSquareSize / 2f), 0f);
                
                


				planes.Add(square.transform);
				//square.GetComponent<Panel>().onClick.AddListener(() => { someFunction(); otherFunction(); }); 
                square.transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));
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
				print ("Hit Something - " + rayHitInfo.collider.transform.gameObject.name);
				foreach (Transform plane in planes)
				{
					if (rayHitInfo.collider.gameObject.transform == plane)
					{
						string rowNo = plane.name.Split('-')[2];
						string colNo = plane.name.Split('-')[1];
						gameState.AddClick(int.Parse(rowNo), int.Parse (colNo));
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
