//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class BTN_ToOption : MonoBehaviour
{
    private void OnClick()
    {
        NGUITools.SetActive(transform.parent.gameObject, false);
        NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelOption, true);
        GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().showKeyMap();
        GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().menuOn = true;
    }
}

