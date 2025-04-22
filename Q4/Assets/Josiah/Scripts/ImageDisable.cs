using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageDisable : MonoBehaviour
{
    public Image tutorialImage;

    public void HideImage()
    {
        tutorialImage.enabled = false;
    }

    public void ShowImage()
    {
        tutorialImage.enabled = true;
    }
}
