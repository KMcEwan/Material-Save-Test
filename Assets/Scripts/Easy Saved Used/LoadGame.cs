using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        if (ES3.FileExists("SaveFile.es3"))
        {
            string loadScene = "SaveFile.es3";

            ES3.Load<List<Material>>("materials", loadScene);

            foreach (var key in ES3.Load<List<Material>>("materials", loadScene))
                Debug.Log(" load - key name " + key.name);

            ES3AutoSaveMgr.Current.Load();

        }
    }
}
