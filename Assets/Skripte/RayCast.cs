using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
   {
    private Camera mainCamera;
    private bool isDragging;
    private float dragDistance = 2f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
            {
                isDragging = true;
                dragDistance = Vector3.Distance(mainCamera.transform.position, transform.position);
            }
        }
        else if (Input.GetMouseButtonUp(0) && isDragging) 
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.origin + ray.direction * dragDistance;
        }
    }
}