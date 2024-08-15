using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    static GameAssets instance;

    public static GameAssets Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameAssets>("gameAssets");
            }
            return instance;
        }
    }

    public Transform PaintWallsPrefab;

}
