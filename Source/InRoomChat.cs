//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using UnityEngine;
using GGM;

public class InRoomChat : Photon.MonoBehaviour
{
    internal static InRoomChat Chat;
    private const bool _alignBottom = true;
    public static Rect GuiRect = new Rect(0f, 100f, 300f, 470f);
    public static Rect GuiRect2 = new Rect(30f, 575f, 300f, 25f);
    private string _inputLine = string.Empty;
    public static bool IsVisible = true;
    public static List<string> Messages = new List<string>();
    private Vector2 _scrollPos = Vector2.zero;

    /// <param name="type">
    /// 0 - MC
    /// 1 - Exist
    /// 2 - Myself
    /// 3 - GGM User
    /// </param>
    /// <param name="text">Action</param>
    public static string Error(int type, string text = "")
    {
        switch (type)
        {
            case 0:
                return "You are not MasterClient.";
            case 1:
                return "No such Player.";
            case 2:
                return string.Concat("You can't ", text, " yourself.");
            case 3:
                return string.Concat("You can't ", text, " GucciGangProject user.");
            default:
                return "Error.";
        }
    }

    public static string RCLine(string text)
    {
        return "<color=#FFC000>" + text + "</color>";
    }

    private static string ChatFormatting(string text, string color, int bold, int italic, string size = "")
    {
        return "<color=#" + color + ">" + (size != "" ? "<size=" + size + ">" : "") + (bold == 1 ? "<b>" : "") + (italic == 1 ? "<i>" : "") + text + (italic == 1 ? "</i>" : "") + (bold == 1 ? "</b>" : "") + (size != "" ? "</size>" : "") + "</color>";
    }

    #region Messages
    public void AddLine(string newLine)
    {
        Messages.Add(newLine);
    }

    public static void Message(string str = "")
    {
        Messages.Add(Settings.RCFormatting == 1 ? RCLine(str) :
            ChatFormatting(str, Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic, Settings.ChatSize));
    }
    public static void Message(string str, string str2)
    {
        Messages.Add(Settings.RCFormatting == 1 ? RCLine(str) + str2 :
            ChatFormatting(str, Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic, Settings.ChatSize) + ChatFormatting(str2, "", Settings.ChatMajorBold, Settings.ChatMajorItalic, Settings.ChatSize));
    }
    public static void Message(string str, PhotonPlayer player)
    {
        Messages.Add(Settings.RCFormatting == 1 ? RCLine(str + " [" + player.ID + "]" + player.Name.hexColor() + ".") :
            ChatFormatting(str, Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic, Settings.ChatSize) +
            ChatFormatting(" [" + player.ID + "]" + player.Name.hexColor(), Settings.ChatMinorColor, Settings.ChatMinorBold, Settings.ChatMinorItalic, Settings.ChatSize) +
            ChatFormatting(".", Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic, Settings.ChatSize));
    }
    public static void Message(PhotonPlayer player, string str)
    {
        Messages.Add(Settings.RCFormatting == 1 ? RCLine("[" + player.ID + "]" + player.Name.hexColor() + " " + str) :
            ChatFormatting("[" + player.ID + "]" + player.Name.hexColor() + " ", Settings.ChatMinorColor, Settings.ChatMinorBold, Settings.ChatMinorItalic, Settings.ChatSize) +
            ChatFormatting(str, Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic, Settings.ChatSize));

    }
    public static void Message(string str, PhotonPlayer player, string str2)
    {
        Messages.Add(Settings.RCFormatting == 1 ? RCLine(str + " [" + player.ID + "]" + player.Name.hexColor() + str2) :
            ChatFormatting(str, Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic, Settings.ChatSize) +
            ChatFormatting(" [" + player.ID + "]" + player.Name.hexColor(), Settings.ChatMinorColor, Settings.ChatMinorBold, Settings.ChatMinorItalic, Settings.ChatSize) +
            ChatFormatting(" " + str2, Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic, Settings.ChatSize));
    }

    public static void Message_2(string str = "")
    {
        FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, Settings.RCFormatting == 1 ? RCLine(str) :
                ChatFormatting(str, Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic), string.Empty);
    }
    public static void Message_2(string str, PhotonPlayer player)
    {
        FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, Settings.RCFormatting == 1 ? RCLine(str + " [" + player.ID + "]" + player.Name.hexColor() + ".") :
                ChatFormatting(str, Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic) +
                ChatFormatting(" [" + player.ID + "]" + player.Name.hexColor(), Settings.ChatMinorColor, Settings.ChatMinorBold, Settings.ChatMinorItalic) +
                ChatFormatting(".", Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic), string.Empty);
    }
    public static void Message_2(PhotonPlayer player, string str)
    {
        FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, Settings.RCFormatting == 1 ? RCLine("[" + player.ID + "]" + player.Name.hexColor() + " " + str) :
                ChatFormatting("[" + player.ID + "]" + player.Name.hexColor() + " ", Settings.ChatMinorColor, Settings.ChatMinorBold, Settings.ChatMinorItalic) +
                ChatFormatting(str, Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic), string.Empty);
    }
    public static void Message_2(string str, PhotonPlayer player, string str2)
    {
        FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, Settings.RCFormatting == 1 ? RCLine(str + " [" + player.ID + "]" + player.Name.hexColor() + str2) :
                ChatFormatting(str, Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic) +
                ChatFormatting(" [" + player.ID + "]" + player.Name.hexColor(), Settings.ChatMinorColor, Settings.ChatMinorBold, Settings.ChatMinorItalic) +
                ChatFormatting(" " + str2, Settings.ChatMajorColor, Settings.ChatMajorBold, Settings.ChatMajorItalic), string.Empty);
    }

    public static void Message_3(string str = "")
    {
        FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.Others, RCLine(str), string.Empty);
    }
    public static void Message_3(string str, PhotonPlayer player)
    {
        FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.Others, RCLine(str + " [" + player.ID + "]" + player.Name.hexColor() + "."), string.Empty);
    }
    public static void Message_3(PhotonPlayer player, string str)
    {
        FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.Others, RCLine("[" + player.ID + "]" + player.Name.hexColor() + " " + str), string.Empty);
    }
    public static void Message_3(string str, PhotonPlayer player, string str2)
    {
        FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.Others, RCLine(str + " [" + player.ID + "]" + player.Name.hexColor() + str2), string.Empty);
    }
    #endregion

    private void CommandSwitch(string[] command)
    {
        switch (command[0])
        {
            case "pos":
                {
                    var player = GGM.Extensions.Player();
                    var x = player.transform.position.x;
                    var y = player.transform.position.y;
                    var z = player.transform.position.z;
                    Message($"Your position is [{x};{y};{z}].");
                    break;
                }
            case "info":
                {
                    var player = GGM.Extensions.Player();
                    Message(player.collider.material.bounciness.ToString());
                    break;
                }
            case "/clear":
            case "/clean":
                {
                    for (var i = 0; i < 15; i++)
                        Message_2();
                    break;
                }
            case "clear":
            case "clean":
                {
                    for (var i = 0; i < 15; i++)
                        Message();
                    break;
                }
            case "reconnect":
                {
                    PhotonNetwork.networkingPeer.OnStatusChanged(StatusCode.DisconnectByServerLogic);
                    break;
                }
            case "tp":
                {
                    var player = PhotonPlayer.Find(Convert.ToInt32(command[1]));
                    HotKeys.TPRemember = player;
                    var obj = new GameObject();
                    var obj2 = new GameObject();
                    var tpPlayers = GameObject.FindGameObjectsWithTag("Player");
                    for (var i = 0; i < tpPlayers.Length; i++)
                    {
                        var obj3 = tpPlayers[i];
                        if (obj3.GetPhotonView().owner == PhotonPlayer.Find(Convert.ToInt32(_inputLine.Remove(0, 4))))
                        {
                            obj = obj3;
                        }
                        if (obj3.GetPhotonView().owner == PhotonNetwork.player)
                        {
                            obj2 = obj3;
                        }
                    }
                    Message("Teleported to ", player, ".");
                    obj2.transform.position = obj.transform.position;
                    break;
                }
            case "time":
                {
                    var time = (FengGameManagerMKII.instance.time - (int)FengGameManagerMKII.instance.timeTotalServer - Convert.ToInt32(command[1])) * -1;
                    FengGameManagerMKII.instance.addTime(time);
                    Message("Time set to ", command[1]);
                    return;
                }
            case "ban":
                {
                    var player = Convert.ToInt32(command[1]);
                    if (player == PhotonNetwork.player.ID)
                    {
                        Message(Error(3, "yourself."));
                    }
                    else
                    {
                        foreach (var player3 in PhotonNetwork.playerList)
                        {
                            if (player == player3.ID)
                            {
                                if (FengGameManagerMKII.OnPrivateServer)
                                {
                                    FengGameManagerMKII.instance.kickPlayerRC(player3, true, "");
                                }
                                else if (PhotonNetwork.isMasterClient)
                                {
                                    FengGameManagerMKII.instance.kickPlayerRC(player3, true, "");
                                    Message_3(player3, "has been banned");
                                    Message(player3, "has been banned");
                                }
                            }
                        }
                        if (PhotonPlayer.Find(player) == null)
                        {
                            Message(Error(1));
                        }
                    }

                    return;
                }
            case "aso":
                {
                    if (!PhotonNetwork.isMasterClient)
                    {
                        Message(Error(0));
                        return;
                    }

                    switch (command[1])
                    {
                        case "kdr":
                            RCSettings.asoPreservekdr = RCSettings.asoPreservekdr == 0 ? 1 : 0;
                            Message("Players stats will " + (RCSettings.asoPreservekdr == 1 ? " " : "not ") +
                                      "be preserved from disconnects.");
                            break;
                        case "racing":
                            RCSettings.racingStatic = RCSettings.racingStatic == 0 ? 1 : 0;
                            Message("Racing will " + (RCSettings.asoPreservekdr == 1 ? " " : "not ") + "end on finish.");
                            break;
                        case "damage":
                            if (PhotonNetwork.isMasterClient)
                            {
                                if (!GGM.Extensions.ASODamage())
                                {
                                    FengGameManagerMKII.settings[210] = 1;
                                    FengGameManagerMKII.settings[211] = "100";
                                    FengGameManagerMKII.settings[212] = "0";
                                    FengGameManagerMKII.settings[213] = "0";
                                    FengGameManagerMKII.settings[214] = "0";
                                    FengGameManagerMKII.settings[215] = "0";
                                    FengGameManagerMKII.settings[207] = 1;
                                    FengGameManagerMKII.settings[208] = "2.5";
                                    FengGameManagerMKII.settings[209] = "3";
                                    FengGameManagerMKII.settings[205] = 1;
                                    FengGameManagerMKII.settings[206] = "1000";
                                    FengGameManagerMKII.instance.restartRC();
                                    Message_2("ASO Damage rules enabled.");
                                }
                                else
                                {
                                    FengGameManagerMKII.settings[210] = 0;
                                    FengGameManagerMKII.settings[207] = 0;
                                    FengGameManagerMKII.settings[205] = 0;
                                    FengGameManagerMKII.instance.restartRC();
                                    Message_2("ASO Damage rules disabled.");
                                }
                            }
                            break;
                        default:
                            Message("Possible:\n" +
                                "/aso damage - Enable/Disable ASO settings." +
                                "/aso kdr - Enable/Disable stats preserve.\n" +
                                "/aso racing - Enable/Disable endless finish time.\n");
                            break;
                    }
                    return;
                }
            case "pause":
                {
                    if (PhotonNetwork.isMasterClient)
                    {
                        FengGameManagerMKII.instance.photonView.RPC("pauseRPC", PhotonTargets.All, true);
                        Message("MasterClient has paused the game.");
                        Message_3("MasterClient has paused the game.");
                    }
                    else
                    {
                        Message(Error(0));
                    }
                    return;
                }
            case "unpause":
                {
                    if (PhotonNetwork.isMasterClient)
                    {
                        FengGameManagerMKII.instance.photonView.RPC("pauseRPC", PhotonTargets.All, false);
                        Message("MasterClient has unpaused the game.");
                        Message_3("MasterClient has unpaused the game.");
                    }
                    else
                    {
                        Message(Error(0));
                    }
                    return;
                }
            case "isrc":
                {
                    Message((FengGameManagerMKII.masterRC ? "is" : "not") + " RC");
                    return;
                }
            case "ignorelist":
                {
                    foreach (var id in FengGameManagerMKII.ignoreList)
                    {
                        Message(id.ToString());
                    }

                    return;
                }
            case "room":
                {
                    //if (!PhotonNetwork.isMasterClient)
                    //{
                    //    Message(Error(0));
                    //    return;
                    //}

                    var roomValue = Convert.ToInt32(command[2]);
                    switch (command[1])
                    {
                        case "max":
                            PhotonNetwork.room.maxPlayers = roomValue;
                            if (PhotonNetwork.isMasterClient)
                                Message_3("Max players changed to " + roomValue + "!");
                            Message("Max players changed to " + roomValue + "!");
                            break;
                        case "time":
                            FengGameManagerMKII.instance.addTime(roomValue);
                            if (PhotonNetwork.isMasterClient)
                                Message_3(roomValue + " seconds added to the clock.");
                            Message(roomValue + " seconds added to the clock.");
                            break;
                        default:
                            Message("Possible commands:\n/room max <count>\n/room time <time>");
                            break;
                    }
                    return;
                }
            case "resetkd":
            case "rkd":
                {
                    PhotonNetwork.player.SetCustomProperties(new Hashtable()
                    {
                        { "kills", 0},
                        { "deaths", 0},
                        { "max_dmg", 0},
                        { "total_dmg", 0}
                    });
                    Message("Your stats have been reset.");
                    return;
                }
            case "formula":
            case "f":
                {
                    switch (command[1])
                    {
                        case "1":
                        case "balance":
                        case "b":
                            {
                                var player = PhotonPlayer.Find(Convert.ToInt32(command[2]));
                                double k = RCextensions.returnIntFromObject(
                                    player.customProperties[PhotonPlayerProperty.kills]);
                                double d = RCextensions.returnIntFromObject(
                                    player.customProperties[PhotonPlayerProperty.deaths]);
                                double md = RCextensions.returnIntFromObject(
                                    player.customProperties[PhotonPlayerProperty.max_dmg]);
                                double td = RCextensions.returnIntFromObject(
                                    player.customProperties[PhotonPlayerProperty.total_dmg]);

                                Message_3("Your result is " +
                                          (1200 * k + td) * (Math.Pow(10, 4) + md) /
                                          (5 * Math.Pow(10, 5) * (20 + d))
                                );
                                Message("Your result is " +
                                          (1200 * k + td) * (Math.Pow(10, 4) + md) /
                                          (5 * Math.Pow(10, 5) * (20 + d))
                                );

                                return;
                            }
                        case "2":
                        case "tens":
                        case "t":
                            {
                                var player = PhotonPlayer.Find(Convert.ToInt32(command[2]));
                                double k = RCextensions.returnIntFromObject(
                                    player.customProperties[PhotonPlayerProperty.kills]);
                                double td = RCextensions.returnIntFromObject(
                                    player.customProperties[PhotonPlayerProperty.total_dmg]);

                                Message_3("Your result is " +
                                          (100 * k - td)
                                );
                                Message("Your result is " +
                                          (100 * k - td)
                                );

                                return;
                            }
                        case "3":
                        case "oldbalance":
                        case "ob":
                            {
                                var player = PhotonPlayer.Find(Convert.ToInt32(command[2]));
                                double k = RCextensions.returnIntFromObject(
                                    player.customProperties[PhotonPlayerProperty.kills]);
                                double d = RCextensions.returnIntFromObject(
                                    player.customProperties[PhotonPlayerProperty.deaths]);
                                double md = RCextensions.returnIntFromObject(
                                    player.customProperties[PhotonPlayerProperty.max_dmg]);
                                double td = RCextensions.returnIntFromObject(
                                    player.customProperties[PhotonPlayerProperty.total_dmg]);

                                Message_3("Your result is " +
                                          (800 * k + td) * (10 - Math.Sqrt(d)) + 100 * md /
                                          Math.Pow(10, 4)
                                );
                                Message("Your result is " +
                                          (800 * k + td) * (10 - Math.Sqrt(d)) + 100 * md /
                                          Math.Pow(10, 4)
                                );

                                return;
                            }
                    }
                    return;
                }
            case "mathb":
                {
                    double k = Convert.ToInt32(command[1]);
                    double d = Convert.ToInt32(command[2]);
                    double md = Convert.ToInt32(command[3]);
                    double td = Convert.ToInt32(command[4]);

                    Message_3("Your result is " +
                              ((1200 * k + td) * (Math.Pow(10, 4) + md) /
                              (5 * Math.Pow(10, 5) * (20 + d)) + ".")
                    );
                    Message("Your result is " +
                              ((1200 * k + td) * (Math.Pow(10, 4) + md) /
                               (5 * Math.Pow(10, 5) * (20 + d)) + ".")
                    );
                    return;
                }
            case "resetkdall":
                {
                    if (!PhotonNetwork.isMasterClient)
                    {
                        Message(Error(0));
                        return;
                    }

                    var hash = new Hashtable() { { "kills", 0 }, { "deaths", 0 }, { "max_dmg", 0 }, { "total_dmg", 0 } };
                    foreach (var player in PhotonNetwork.playerList)
                    {
                        player.SetCustomProperties(hash);
                    }

                    Message_3("All stats have been reset.");
                    Message("All stats have been reset.");

                    return;
                }
            case "revive":
                {
                    var player = PhotonPlayer.Find(Convert.ToInt32(command[1]));
                    FengGameManagerMKII.instance.photonView.RPC("respawnHeroInNewRound", player);
                    Message_3("Player [" + player.ID + "] has been revived.");
                    Message("Player [" + player.ID + "] has been revived.");

                    return;
                }
            case "reviveall":
                {
                    FengGameManagerMKII.instance.photonView.RPC("respawnHeroInNewRound", PhotonTargets.All);
                    Message_3("All players have been revived.");
                    Message("All players have been revived.");

                    return;
                }
            case "pm":
                {
                    var player = PhotonPlayer.Find(Convert.ToInt32(command[1]));
                    var msg = "";
                    for (var i = 2; i < command.Length; i++)
                    {
                        msg += command[i] + (i == command.Length - 1 ? "" : " ");
                    }

                    var myName = RCextensions.returnStringFromObject(PhotonNetwork.player.customProperties["name"]).hexColor();
                    string sendName;
                    switch (RCextensions.returnIntFromObject(PhotonNetwork.player.customProperties["RCteam"]))
                    {
                        case 1:
                            sendName = "<color=cyan>" + myName + "</color>";
                            break;
                        case 2:
                            sendName = "<color=magenta>" + myName + "</color>";
                            break;
                        default:
                            sendName = myName;
                            break;
                    }

                    FengGameManagerMKII.instance.photonView.RPC("ChatPM", player, sendName, msg);
                    Message("Sent PM [" + player.ID + "] " + msg);
                    return;
                }
            case "team":
                {
                    if (RCSettings.teamMode != 1)
                    {
                        Message("Error: teams are locked or disabled");
                        return;
                    }

                    var teamValue = 0;
                    var newTeamName = "Individuals";
                    switch (command[1])
                    {
                        case "0":
                        case "individual":
                            break;
                        case "1":
                        case "cyan":
                            teamValue = 1;
                            newTeamName = "Cyan";
                            break;
                        case "2":
                        case "magenta":
                            teamValue = 2;
                            newTeamName = "Magenta";
                            break;
                        default:
                            Message("Error: invalid team code/name.(use 0, 1, 2)");
                            return;
                    }

                    FengGameManagerMKII.instance.photonView.RPC("setTeamRPC", PhotonNetwork.player, teamValue);
                    Message("You have joined to team " + newTeamName);
                    foreach (var obj in FengGameManagerMKII.instance.getPlayers())
                    {
                        var her = (HERO)obj;
                        if (her.photonView.isMine)
                        {
                            her.markDie();
                            her.photonView.RPC("netDie2", PhotonTargets.All, -1, "Team Switch");
                            break;
                        }
                    }

                    return;
                }
            case "kick":
                {
                    var player = Convert.ToInt32(command[1]);
                    if (player == PhotonNetwork.player.ID)
                    {
                        Message(Error(2, "kick"));
                    }
                    else if (!(FengGameManagerMKII.OnPrivateServer || PhotonNetwork.isMasterClient))
                    {
                        FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, "/kick #" + Convert.ToString(player), LoginFengKAI.player.name);
                    }
                    else
                    {
                        foreach (var player3 in PhotonNetwork.playerList)
                        {
                            if (player == player3.ID)
                            {
                                if (FengGameManagerMKII.OnPrivateServer)
                                {
                                    FengGameManagerMKII.instance.kickPlayerRC(player3, false, string.Empty);
                                }
                                else if (PhotonNetwork.isMasterClient)
                                {
                                    FengGameManagerMKII.instance.kickPlayerRC(player3, false, string.Empty);
                                    Message_3(player3, "has been kicked from the server.");
                                    Message(player3, "has been kicked from the server.");
                                }
                            }
                        }

                        if (PhotonPlayer.Find(player) == null)
                        {
                            Message(Error(1));
                        }
                    }
                    return;
                }
            case "restart":
                {
                    if (!PhotonNetwork.isMasterClient)
                    {
                        Message(Error(0));
                        return;
                    }

                    FengGameManagerMKII.instance.restartGame();
                    Message_3("MasterClient has restarted the game.");
                    Message("MasterClient has restarted the game.");

                    return;
                }
            case "specmode":
                {
                    if ((int)FengGameManagerMKII.settings[245] == 0)
                    {
                        FengGameManagerMKII.settings[245] = 1;
                        FengGameManagerMKII.instance.EnterSpecMode(true);
                        Message("You have entered spectator mode.");
                    }
                    else
                    {
                        FengGameManagerMKII.settings[245] = 0;
                        FengGameManagerMKII.instance.EnterSpecMode(false);
                        Message("You have exited spectator mode.");
                    }

                    return;
                }
            case "fov":
                {
                    if (Convert.ToInt32(command[1]) != 0)
                    {
                        Settings.FOVvalue = Convert.ToSingle(command[1]);
                        Message($"Field of Vision set to  {command[1]}.");
                    }
                    else Settings.FOV = 0;
                    return;
                }
            case "spectate":
                {
                    var num8 = Convert.ToInt32(command[1]);
                    foreach (var obj5 in GameObject.FindGameObjectsWithTag("Player"))
                    {
                        if (obj5.GetPhotonView().owner.ID == num8)
                        {
                            Camera.main.GetComponent<IN_GAME_MAIN_CAMERA>().setMainObject(obj5);
                            Camera.main.GetComponent<IN_GAME_MAIN_CAMERA>().setSpectorMode(false);
                        }
                    }
                    return;
                }
            case "rules":
                {
                    Rules();
                    return;
                }
            default:
                Message("Wrong command.");
                return;
        }
    }

    public static void Rules()
    {
        Message("Currently activated gamemodes:");
        if (RCSettings.bombMode > 0)
        {
            Message("Bomb mode is on.");
        }

        if (RCSettings.teamMode > 0)
        {
            if (RCSettings.teamMode == 1)
            {
                Message("Team mode is on (no sort).");
            }
            else if (RCSettings.teamMode == 2)
            {
                Message("Team mode is on (sort by size).");
            }
            else if (RCSettings.teamMode == 3)
            {
                Message("Team mode is on (sort by skill).");
            }
        }

        if (RCSettings.pointMode > 0)
        {
            Message("Point mode is on (" + Convert.ToString(RCSettings.pointMode) + ").");
        }

        if (RCSettings.disableRock > 0)
        {
            Message("Punk Rock-Throwing is disabled.");
        }

        if (RCSettings.spawnMode > 0)
        {
            Message("Custom spawn rate is on (" + RCSettings.nRate.ToString("F2") + "% Normal, " +
                           RCSettings.aRate.ToString("F2") + "% Abnormal, " + RCSettings.jRate.ToString("F2") +
                           "% Jumper, " + RCSettings.cRate.ToString("F2") + "% Crawler, " +
                           RCSettings.pRate.ToString("F2") + "% Punk");
        }

        if (RCSettings.explodeMode > 0)
        {
            Message("Titan explode mode is on (" + Convert.ToString(RCSettings.explodeMode) + ").");
        }

        if (RCSettings.healthMode > 0)
        {
            Message("Titan health mode is on (" + Convert.ToString(RCSettings.healthLower) + "-" +
                           Convert.ToString(RCSettings.healthUpper) + ").");
        }

        if (RCSettings.infectionMode > 0)
        {
            Message("Infection mode is on (" + Convert.ToString(RCSettings.infectionMode) + ").");
        }

        if (RCSettings.damageMode > 0)
        {
            Message("Minimum nape damage is on (" + Convert.ToString(RCSettings.damageMode) + ").");
        }

        if (RCSettings.moreTitans > 0)
        {
            Message("Custom titan # is on (" + Convert.ToString(RCSettings.moreTitans) + ").");
        }

        if (RCSettings.sizeMode > 0)
        {
            Message("Custom titan size is on (" + RCSettings.sizeLower.ToString("F2") + "," +
                           RCSettings.sizeUpper.ToString("F2") + ").");
        }

        if (RCSettings.banEren > 0)
        {
            Message("Anti-Eren is on. Using Titan eren will get you kicked.");
        }

        if (RCSettings.waveModeOn == 1)
        {
            Message("Custom wave mode is on (" + Convert.ToString(RCSettings.waveModeNum) + ").");
        }

        if (RCSettings.friendlyMode > 0)
        {
            Message("Friendly-Fire disabled. PVP is prohibited.");
        }

        if (RCSettings.pvpMode > 0)
        {
            if (RCSettings.pvpMode == 1)
            {
                Message("AHSS/Blade PVP is on (team-based).");
            }
            else if (RCSettings.pvpMode == 2)
            {
                Message("AHSS/Blade PVP is on (FFA).");
            }
        }

        if (RCSettings.maxWave > 0)
        {
            Message("Max Wave set to " + RCSettings.maxWave.ToString());
        }

        if (RCSettings.horseMode > 0)
        {
            Message("Horses are enabled.");
        }

        if (RCSettings.ahssReload > 0)
        {
            Message("AHSS Air-Reload disabled.");
        }

        if (RCSettings.punkWaves > 0)
        {
            Message("Punk override every 5 waves enabled.");
        }

        if (RCSettings.endlessMode > 0)
        {
            Message("Endless Respawn is enabled (" + RCSettings.endlessMode.ToString() + " seconds).");
        }

        if (RCSettings.globalDisableMinimap > 0)
        {
            Message("Minimap are disabled.");
        }

        if (RCSettings.motd != string.Empty)
        {
            Message("MOTD:" + RCSettings.motd);
        }

        if (RCSettings.deadlyCannons > 0)
        {
            Message("Cannons will kill humans.");
        }
    }

    private void Awake()
    {
        Chat = this;
    }

    public void OnGUI()
    {
        int num4;
        if (!IsVisible || PhotonNetwork.connectionStateDetailed != PeerStates.Joined)
        {
            return;
        }
        if (Event.current.type == EventType.KeyDown)
        {
            if ((Event.current.keyCode == KeyCode.Tab || Event.current.character == '\t') && !IN_GAME_MAIN_CAMERA.isPausing && FengGameManagerMKII.inputRC.humanKeys[InputCodeRC.chat] != KeyCode.Tab)
            {
                Event.current.Use();
                goto Label_219C;
            }
        }
        else if (Event.current.type == EventType.KeyUp && Event.current.keyCode != KeyCode.None && Event.current.keyCode == FengGameManagerMKII.inputRC.humanKeys[InputCodeRC.chat] && GUI.GetNameOfFocusedControl() != "ChatInput")
        {
            _inputLine = string.Empty;
            GUI.FocusControl("ChatInput");
            goto Label_219C;
        }
        if (Event.current.type == EventType.KeyDown && (Event.current.keyCode == KeyCode.KeypadEnter || Event.current.keyCode == KeyCode.Return))
        {
            if (!string.IsNullOrEmpty(_inputLine))
            {
                string str2;
                if (_inputLine == "\t")
                {
                    _inputLine = string.Empty;
                    GUI.FocusControl(string.Empty);
                    return;
                }
                if (FengGameManagerMKII.RCEvents.ContainsKey("OnChatInput"))
                {
                    var key = (string)FengGameManagerMKII.RCVariableNames["OnChatInput"];
                    if (FengGameManagerMKII.stringVariables.ContainsKey(key))
                    {
                        FengGameManagerMKII.stringVariables[key] = _inputLine;
                    }
                    else
                    {
                        FengGameManagerMKII.stringVariables.Add(key, _inputLine);
                    }
                    ((RCEvent)FengGameManagerMKII.RCEvents["OnChatInput"]).checkEvent();
                }
                if (!_inputLine.StartsWith("/"))
                {
                    str2 = RCextensions.returnStringFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]).hexColor();
                    if (str2 == string.Empty)
                    {
                        str2 = RCextensions.returnStringFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]);
                        if (PhotonNetwork.player.customProperties[PhotonPlayerProperty.RCteam] != null)
                        {
                            if (RCextensions.returnIntFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.RCteam]) == 1)
                            {
                                str2 = "<color=#00FFFF>" + str2 + "</color>";
                            }
                            else if (RCextensions.returnIntFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.RCteam]) == 2)
                            {
                                str2 = "<color=#FF00FF>" + str2 + "</color>";
                            }
                        }
                    }
                    var parameters = new object[] { _inputLine, str2 };
                    FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, parameters);
                }
                else
                {
                    CommandSwitch(_inputLine.Remove(0, 1).Split(' '));
                }
                _inputLine = string.Empty;
                GUI.FocusControl(string.Empty);
                return;
            }
            _inputLine = "\t";
            GUI.FocusControl("ChatInput");
        }
    Label_219C:
        GUI.SetNextControlName(string.Empty);
        GUILayout.BeginArea(GuiRect);
        GUILayout.FlexibleSpace();
        var text = string.Empty;
        if (Messages.Count < 15)
        {
            for (num4 = 0; num4 < Messages.Count; num4++)
            {
                text = text + Messages[num4] + "\n";
            }
        }
        else
        {
            for (var i = Messages.Count - 15; i < Messages.Count; i++)
            {
                text = text + Messages[i] + "\n";
            }
        }
        GUILayout.Label(text);
        GUILayout.EndArea();
        GUILayout.BeginArea(GuiRect2);
        GUILayout.BeginHorizontal();
        GUI.SetNextControlName("ChatInput");
        _inputLine = GUILayout.TextField(_inputLine);
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    public void SetPosition()
    {
        GuiRect = new Rect(0f, Screen.height - 500, 300f, 470f);
        GuiRect2 = new Rect(30f, Screen.height - 300 + 275, 300f, 25f);
    }

    public void Start()
    {
        SetPosition();
    }
}

