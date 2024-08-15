using UnityEngine;
using System;
using System.Collections;
using Unity.Mathematics;
public class PaintWallsTimers : MonoBehaviour
{
    //testing material list save

    [SerializeField] MaterialSaveList materialSaveList;
    //

    float paintingTimer = 0f;
    float paintingTimerMax = 1.5f;


    Renderer wallRenderer;
    Material wallMaterial;

    Color newColour;                    //PaintColor
    Color oldColour;                    //Color

    GameObject wall;


    public Material newMaterialInstancePaintWalls;
    public Material newMaterialInstanceBrown;
    public float paintAmount;


    public static void paintWall(GameObject wall, Color colour, Material material)
    {
        Transform paintWallsObj = GameAssets.Instance.PaintWallsPrefab;
        Transform paintWallsTransform = Instantiate(paintWallsObj, wall.transform.position, Quaternion.identity);
        PaintWallsTimers paintWall = paintWallsTransform.GetComponent<PaintWallsTimers>();
        if (paintWall != null)
        {
            paintWall.SetWallInfo(wall, colour, material);
        }
        else
        {
            Debug.LogError("PaintWallsTimers component not found on the prefab!");
        }
    }

    private void Awake()
    {
        paintingTimer = paintingTimerMax;
    }
    private void Start()
    {
        materialSaveList = GameObject.Find("MaterialSaveList").GetComponent<MaterialSaveList>();
    }
    void Update()
    {
        paintingTimer -= Time.deltaTime;
        wallMaterial.SetColor("_PaintColor", newColour);
        wallMaterial.SetFloat("_PaintAmount", getPaintingWallsTimerNormalised());
        if (paintingTimer <= 0f)
        {
            wallMaterial.SetColor("_Color", newColour);

            materialSaveList.addToList(wallMaterial);
            materialSaveList.addToList(newMaterialInstanceBrown);
            Destroy(this.gameObject);
        }
    }
    public void SetWallInfo(GameObject wall, Color colour, Material material)
    {
        this.wall = wall;
        wallRenderer = wall.GetComponent<Renderer>();
        Material newWallMaterial = null;

        foreach (Material mat in wallRenderer.materials)                
        {
            if (mat.shader == material.shader)                                  // if material matches the paintWall Material
            {
                newWallMaterial = mat;
            }
        }

        wallMaterial = new Material(newWallMaterial);

        Material[] materials = wallRenderer.materials;


        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i] == newWallMaterial)
            {
                materials[i] = wallMaterial;
                newMaterialInstancePaintWalls = wallMaterial;
            }
            else
            {
                newMaterialInstanceBrown = materials[i];
            }
        }

        wallRenderer.materials = materials;
        newColour = colour;
    }

    public float getPaintingWallsTimerNormalised()
    {
        return 1 - paintingTimer / paintingTimerMax;
    }


}