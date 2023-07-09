using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentManager : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var Docs = GameObject.FindGameObjectsWithTag("Document");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 worldClick = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

            GameObject topDoc = null;
            float closest = 25;

            foreach (GameObject doc in Docs)
            {
                Vector2 size = doc.GetComponent<BoxCollider2D>().bounds.size;

                if (worldClick.x > doc.transform.position.x - size.x / 2 &&
                    worldClick.x < doc.transform.position.x + size.x / 2 &&
                    worldClick.y > doc.transform.position.y - size.y / 2 &&
                    worldClick.y < doc.transform.position.y + size.y / 2)
                {
                    if(doc.transform.position.z < closest)
                    {
                        topDoc = doc;
                        closest = doc.transform.position.z;
                    }
                }
            }

            if(topDoc)
                topDoc.GetComponent<Paper>().selected = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            foreach(GameObject doc in Docs)
            {
                doc.GetComponent<Paper>().selected = false;
            }
        }
    }
}
