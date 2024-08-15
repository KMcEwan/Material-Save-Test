using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PaintWalls : MonoBehaviour
{
    bool paintingWalls = false;
    static Camera mainCamera;

    [SerializeField] Material paintWallMaterial;
    Color NewColor = Color.blue;
    Color oldColor;


    private void Awake()
    {
        
    }
    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) { NewColor = Color.yellow; }
        if (Input.GetKeyDown(KeyCode.X)) { NewColor = Color.red; }
        if (Input.GetKeyDown(KeyCode.C)) { NewColor = Color.black; }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            //Debug.Log("game object hit " + hitObject);
            if(hit.collider == null )
            {
                return;
            }
            if (hit.transform.gameObject == this.gameObject)
            {
                if (hit.transform.gameObject.TryGetComponent<PaintWalls>(out PaintWalls walls))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    PaintWallsTimers.paintWall(hit.transform.gameObject, NewColor, paintWallMaterial);
                }
            }
        }
    }

}
