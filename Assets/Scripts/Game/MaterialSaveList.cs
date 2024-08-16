using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaterialSaveList : MonoBehaviour
{
    int currentScene;
    public List<Material> materials = new List<Material>();
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }


    void Update()
    {
    }

    public void addToList(Material material)
    {
        materials.Add(material); 
    }

    public void saveMaterialList()
    {


        /* DELETING THE SAVED MATERIAL LIST AND CREATING A NEW ONE
         * 
         * 
        if (ES3.FileExists("SaveFile.es3"))
        {
            List<Material> materialsSaved = ES3.Load<List<Material>>("materials", "SaveFile.es3");
            foreach (Material material in materialsSaved)
            {
                materials.Add(material);
            }
        }


        ES3.DeleteKey("materials", "SaveFile.es3");
        if (ES3.KeyExists("materials", "SaveFile.es3"))
        {
            Debug.Log("key exists after delete key");
        }
        else
        {
            Debug.Log("key doesnt exists");
        }

        */

        ES3.Save("materials", materials, "SaveFile.es3");
        foreach (var key in ES3.Load<List<Material>>("materials", "SaveFile.es3"))
            Debug.Log(" key name " + key.name);

        ES3AutoSaveMgr.Current.Save();
        SceneManager.LoadScene(currentScene - 1);
    }

}
