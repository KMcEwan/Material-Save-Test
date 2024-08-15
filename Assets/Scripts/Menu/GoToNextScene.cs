using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    int currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);   
    }
}
