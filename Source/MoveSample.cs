//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class MoveSample : MonoBehaviour
{
    private void Start()
    {
        var args = new object[] { "x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", 0.1 };
        iTween.MoveBy(gameObject, iTween.Hash(args));
    }
}

