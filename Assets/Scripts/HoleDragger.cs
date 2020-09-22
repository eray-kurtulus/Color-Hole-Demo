using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDragger : MonoBehaviour
{
    [SerializeField] private Transform theHole;
    [SerializeField] private float moveSpeedMultiplier;

    [SerializeField] private Vector3 leftBottomLimit; 
    [SerializeField] private Vector3 rightTopLimit; 
    
    [SerializeField] private float horizontalMargin; 
    [SerializeField] private float verticalMargin; 
    
    private bool isMouseDragging;
    private Vector3 clickPosition;
    private Vector3 holePositionAtClick;

    private void Start()
    {
        isMouseDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDragging = true;
            clickPosition = Input.mousePosition;
            holePositionAtClick = theHole.position;
            //print(clickPosition);
        }

        if (Input.GetMouseButtonUp(0) && isMouseDragging)
        {
            isMouseDragging = false;
        }

        if (isMouseDragging)
        {
            // Update the Hole gameobject's current position.
            UpdateHolePosition();
        }
    }

    void UpdateHolePosition()
    {
        Vector3 moveDirection = new Vector3(Input.mousePosition.x - clickPosition.x, 0, Input.mousePosition.y - clickPosition.y);
        Vector3 newPosition = holePositionAtClick + moveDirection * moveSpeedMultiplier;

        // Check for bounds
        
        float leftButtomX = leftBottomLimit.x + horizontalMargin;
        float leftButtomY = leftBottomLimit.y + verticalMargin;
        
        float rightTopX = rightTopLimit.x - horizontalMargin;
        float rightTopY = rightTopLimit.y - verticalMargin;
        
        if (newPosition.x < leftButtomX)
        {
            newPosition.x = leftButtomX;
        }
        if (newPosition.z < leftButtomY)
        {
            newPosition.z = leftButtomY;
        }
        if (newPosition.x > rightTopX)
        {
            newPosition.x = rightTopX;
        }
        if (newPosition.z > rightTopY)
        {
            newPosition.z = rightTopY;
        }
        theHole.position = newPosition;
    }
}
