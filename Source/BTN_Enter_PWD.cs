//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class BTN_Enter_PWD : MonoBehaviour
{
    private void OnClick()
    {
        var text = GameObject.Find("InputEnterPWD").GetComponent<UIInput>().label.text;
        var eaes = new SimpleAES();
        if (text == eaes.Decrypt(PanelMultiJoinPWD.Password))
        {
            PhotonNetwork.JoinRoom(PanelMultiJoinPWD.roomName);
        }
        else
        {
            NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().PanelMultiPWD, false);
            NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelMultiROOM, true);
            GameObject.Find("PanelMultiROOM").GetComponent<PanelMultiJoin>().refresh();
        }
    }
}

