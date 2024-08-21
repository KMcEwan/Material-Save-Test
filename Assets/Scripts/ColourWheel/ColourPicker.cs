using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPicker : MonoBehaviour
{
    [SerializeField] RectTransform buttonRect;
    [SerializeField] Texture2D buttonTexture;

    [SerializeField] GameObject cube;


    public void onButtonClicked()
    {
        setColour();
    }

    void setColour()
    {
        Vector3 imagePositon = buttonRect.position;
        float globalPosX = (Input.mousePosition.x - imagePositon.x) * (1920f / Screen.width);
        float globalPosY = (Input.mousePosition.y - imagePositon.y) * (1080f / Screen.height);

        int localPosX = (int)(globalPosX * (buttonTexture.width / buttonRect.rect.width));
        int localPosY = (int)(globalPosY * (buttonTexture.height / buttonRect.rect.height));

        Color color = buttonTexture.GetPixel(localPosX, localPosY);
        setPickedColour(color);
    }

    void setPickedColour(Color c)
    {
        cube.GetComponent<Renderer>().material.color = c;
    }
}
