using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject gameManager;
    Vector3 boardMiddle;
    public float zoomSpeed = 1;
    public float rotationSpeed = 2;
    private Camera mainCamera;
    // Use this for initialization
    void Start () {
        boardMiddle = gameManager.GetComponent<BoardGenerator>().boardMiddle;
        transform.position = boardMiddle;
        mainCamera = GetComponentInChildren<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        float d = Input.GetAxis("Mouse ScrollWheel");
        if (d != 0f)
        {
            
            Vector3 stick = boardMiddle - mainCamera.transform.position;
            stick = stick - stick * d*zoomSpeed;
            mainCamera.transform.position = boardMiddle - stick;
        }
        if (Input.GetMouseButton(2))
        {
            float dx = rotationSpeed*Input.GetAxis("Mouse X");
            float dy = rotationSpeed*Input.GetAxis("Mouse Y");
            transform.Rotate(-dy, dx, dy);
        }

    }
}
