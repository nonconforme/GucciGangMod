//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class BTN_START_MULTI_SERVER : MonoBehaviour
{
    private void OnClick()
    {
        var text = GameObject.Find("InputServerName").GetComponent<UIInput>().label.text;
        var maxPlayers = int.Parse(GameObject.Find("InputMaxPlayer").GetComponent<UIInput>().label.text);
        var num2 = int.Parse(GameObject.Find("InputMaxTime").GetComponent<UIInput>().label.text);
        var selection = GameObject.Find("PopupListMap").GetComponent<UIPopupList>().selection;
        var str3 = !GameObject.Find("CheckboxHard").GetComponent<UICheckbox>().isChecked ? !GameObject.Find("CheckboxAbnormal").GetComponent<UICheckbox>().isChecked ? "normal" : "abnormal" : "hard";
        var str4 = string.Empty;
        if (IN_GAME_MAIN_CAMERA.dayLight == DayLight.Day)
        {
            str4 = "day";
        }
        if (IN_GAME_MAIN_CAMERA.dayLight == DayLight.Dawn)
        {
            str4 = "dawn";
        }
        if (IN_GAME_MAIN_CAMERA.dayLight == DayLight.Night)
        {
            str4 = "night";
        }
        var unencrypted = GameObject.Find("InputStartServerPWD").GetComponent<UIInput>().label.text;
        if (unencrypted.Length > 0)
        {
            unencrypted = new SimpleAES().Encrypt(unencrypted);
        }
        PhotonNetwork.CreateRoom(string.Concat(text, "`", selection, "`", str3, "`", num2, "`", str4, "`", unencrypted, "`", Random.Range(0, 50000)), true, true, maxPlayers);
    }
}

