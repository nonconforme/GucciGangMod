//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Load Level On Click")]
public class LoadLevelOnClick : MonoBehaviour
{
    public string levelName;

    private void OnClick()
    {
        if (!string.IsNullOrEmpty(levelName))
        {
            Application.LoadLevel(levelName);
        }
    }
}

