//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class SampleInfo : MonoBehaviour
{
    private void OnGUI()
    {
        GUILayout.Label("iTween can spin, shake, punch, move, handle audio, fade color and transparency \nand much more with each task needing only one line of code.");
        GUILayout.BeginHorizontal();
        GUILayout.Label("iTween works with C#, JavaScript and Boo. For full documentation and examples visit:");
        if (GUILayout.Button("http://itween.pixelplacement.com"))
        {
            Application.OpenURL("http://itween.pixelplacement.com");
        }
        GUILayout.EndHorizontal();
    }
}

