//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class ChangeQuality : MonoBehaviour
{
    private bool init;
    public static bool isTiltShiftOn;

    private void OnSliderChange()
    {
        if (!init)
        {
            init = true;
            if (PlayerPrefs.HasKey("GameQuality"))
            {
                gameObject.GetComponent<UISlider>().sliderValue = PlayerPrefs.GetFloat("GameQuality");
            }
            else
            {
                PlayerPrefs.SetFloat("GameQuality", gameObject.GetComponent<UISlider>().sliderValue);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("GameQuality", gameObject.GetComponent<UISlider>().sliderValue);
        }
        setQuality(gameObject.GetComponent<UISlider>().sliderValue);
    }

    public static void setCurrentQuality()
    {
        if (PlayerPrefs.HasKey("GameQuality"))
        {
            setQuality(PlayerPrefs.GetFloat("GameQuality"));
        }
    }

    private static void setQuality(float val)
    {
        if (val < 0.167f)
        {
            QualitySettings.SetQualityLevel(0, true);
        }
        else if (val < 0.33f)
        {
            QualitySettings.SetQualityLevel(1, true);
        }
        else if (val < 0.5f)
        {
            QualitySettings.SetQualityLevel(2, true);
        }
        else if (val < 0.67f)
        {
            QualitySettings.SetQualityLevel(3, true);
        }
        else if (val < 0.83f)
        {
            QualitySettings.SetQualityLevel(4, true);
        }
        else if (val <= 1f)
        {
            QualitySettings.SetQualityLevel(5, true);
        }
    }

    public static void turnOffTiltShift()
    {
        isTiltShiftOn = false;
        if (GameObject.Find("MainCamera") != null)
        {
            GameObject.Find("MainCamera").GetComponent<TiltShift>().enabled = false;
        }
    }

    public static void turnOnTiltShift()
    {
        isTiltShiftOn = true;
        if (GameObject.Find("MainCamera") != null)
        {
            GameObject.Find("MainCamera").GetComponent<TiltShift>().enabled = true;
        }
    }
}

