//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class LevelTriggerHint : MonoBehaviour
{
    public string content;
    public HintType myhint;
    private bool on;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            on = true;
        }
    }

    private void Start()
    {
        if (!LevelInfo.getInfo(FengGameManagerMKII.level).hint)
        {
            enabled = false;
        }
        if (content == string.Empty)
        {
            switch (myhint)
            {
                case HintType.MOVE:
                {
                    var textArray2 = new[] { "Hello soldier!\nWelcome to Attack On Titan Tribute Game!\n Press [F7D358]", GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.up], GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.left], GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.down], GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.right], "[-] to Move." };
                    content = string.Concat(textArray2);
                    break;
                }
                case HintType.TELE:
                    content = "Move to [82FA58]green warp point[-] to proceed.";
                    break;

                case HintType.CAMA:
                {
                    var textArray3 = new[] { "Press [F7D358]", GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.camera], "[-] to change camera mode\nPress [F7D358]", GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.hideCursor], "[-] to hide or show the cursor." };
                    content = string.Concat(textArray3);
                    break;
                }
                case HintType.JUMP:
                    content = "Press [F7D358]" + GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.jump] + "[-] to Jump.";
                    break;

                case HintType.JUMP2:
                    content = "Press [F7D358]" + GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.up] + "[-] towards a wall to perform a wall-run.";
                    break;

                case HintType.HOOK:
                {
                    var textArray4 = new[] { "Press and Hold[F7D358] ", GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.leftRope], "[-] or [F7D358]", GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.rightRope], "[-] to launch your grapple.\nNow Try hooking to the [>3<] box. " };
                    content = string.Concat(textArray4);
                    break;
                }
                case HintType.HOOK2:
                {
                    var textArray5 = new[] { "Press and Hold[F7D358] ", GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.bothRope], "[-] to launch both of your grapples at the same Time.\n\nNow aim between the two black blocks. \nYou will see the mark '<' and '>' appearing on the blocks. \nThen press ", GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.bothRope], " to hook the blocks." };
                    content = string.Concat(textArray5);
                    break;
                }
                case HintType.SUPPLY:
                    content = "Press [F7D358]" + GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.reload] + "[-] to reload your blades.\n Move to the supply station to refill your gas and blades.";
                    break;

                case HintType.DODGE:
                    content = "Press [F7D358]" + GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.dodge] + "[-] to Dodge.";
                    break;

                case HintType.ATTACK:
                {
                    var textArray1 = new[] { "Press [F7D358]", GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.attack0], "[-] to Attack. \nPress [F7D358]", GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().inputString[InputCode.attack1], "[-] to use special attack.\n***You can only kill a titan by slashing his [FA5858]NAPE[-].***\n\n" };
                    content = string.Concat(textArray1);
                    break;
                }
            }
        }
    }

    private void Update()
    {
        if (on)
        {
            GameObject.Find("MultiplayerManager").GetComponent<FengGameManagerMKII>().ShowHUDInfoCenter(content + "\n\n\n\n\n");
            on = false;
        }
    }
}

