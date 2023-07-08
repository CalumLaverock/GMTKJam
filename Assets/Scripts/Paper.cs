using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    private Camera cam;
    private Vector2 previousMousePos;
    public bool selected;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldClick = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        if (selected)
        {
            Vector3 movement = new Vector3((worldClick - previousMousePos).x, (worldClick - previousMousePos).y, 0);

            transform.position += movement;
        }

        previousMousePos = worldClick;
    }
}
