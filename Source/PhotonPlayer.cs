//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using ExitGames.Client.Photon;
using UnityEngine;

public class PhotonPlayer
{
    private int actorID;
    public readonly bool isLocal;
    private string nameField;
    public object TagObject;

    protected internal PhotonPlayer(bool isLocal, int actorID, Hashtable properties)
    {
        this.actorID = -1;
        nameField = string.Empty;
        customProperties = new Hashtable();
        this.isLocal = isLocal;
        this.actorID = actorID;
        InternalCacheProperties(properties);
    }

    public PhotonPlayer(bool isLocal, int actorID, string name)
    {
        this.actorID = -1;
        nameField = string.Empty;
        customProperties = new Hashtable();
        this.isLocal = isLocal;
        this.actorID = actorID;
        nameField = name;
    }

    public override bool Equals(object p)
    {
        var player = p as PhotonPlayer;
        return player != null && GetHashCode() == player.GetHashCode();
    }

    public static PhotonPlayer Find(int ID)
    {
        for (var i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            var player = PhotonNetwork.playerList[i];
            if (player.ID == ID)
            {
                return player;
            }
        }
        return null;
    }

    public Hashtable ChangeLocalPlayer(int NewID, string inputname)
    {
        /*PhotonNetwork.UnAllocateViewID(PhotonView.fi);*/
        actorID = NewID;
        string memes;
        nameField = memes = string.Format("{0}_ID:{1}", inputname, NewID);
        var hashtable = new Hashtable();
        hashtable.Add(PhotonPlayerProperty.name, memes);
        hashtable.Add(PhotonPlayerProperty.guildName, LoginFengKAI.player.guildname);
        hashtable.Add(PhotonPlayerProperty.kills, 0);
        hashtable.Add(PhotonPlayerProperty.max_dmg, 0);
        hashtable.Add(PhotonPlayerProperty.total_dmg, 0);
        hashtable.Add(PhotonPlayerProperty.deaths, 0);
        hashtable.Add(PhotonPlayerProperty.dead, true);
        hashtable.Add(PhotonPlayerProperty.isTitan, 0);
        hashtable.Add(PhotonPlayerProperty.RCteam, 0);
        hashtable.Add(PhotonPlayerProperty.currentLevel, string.Empty);
        var propertiesToSet = hashtable;
        PhotonNetwork.AllocateViewID();
        PhotonNetwork.player.SetCustomProperties(propertiesToSet);
        return propertiesToSet;
    }

    public PhotonPlayer Get(int id)
    {
        return Find(id);
    }

    public override int GetHashCode()
    {
        return ID;
    }

    public PhotonPlayer GetNext()
    {
        return GetNextFor(ID);
    }

    public PhotonPlayer GetNextFor(PhotonPlayer currentPlayer)
    {
        if (currentPlayer == null)
        {
            return null;
        }
        return GetNextFor(currentPlayer.ID);
    }

    public PhotonPlayer GetNextFor(int currentPlayerId)
    {
        if (PhotonNetwork.networkingPeer == null || PhotonNetwork.networkingPeer.mActors == null || PhotonNetwork.networkingPeer.mActors.Count < 2)
        {
            return null;
        }
        var mActors = PhotonNetwork.networkingPeer.mActors;
        var num = 2147483647;
        var num2 = currentPlayerId;
        foreach (var num3 in mActors.Keys)
        {
            if (num3 < num2)
            {
                num2 = num3;
            }
            else if (num3 > currentPlayerId && num3 < num)
            {
                num = num3;
            }
        }
        return num == 2147483647 ? mActors[num2] : mActors[num];
    }

    internal void InternalCacheProperties(Hashtable properties)
    {
        if (properties != null && properties.Count != 0 && !customProperties.Equals(properties))
        {
            if (properties.ContainsKey((byte) 255))
            {
                nameField = (string) properties[(byte) 255];
            }
            customProperties.MergeStringKeys(properties);
            customProperties.StripKeysWithNullValues();
        }
    }

    internal void InternalChangeLocalID(int newID)
    {
        if (!isLocal)
        {
            Debug.LogError("ERROR You should never change PhotonPlayer IDs!");
        }
        else
        {
            actorID = newID;
        }
    }

    public void SetCustomProperties(Hashtable propertiesToSet)
    {
        if (propertiesToSet != null)
        {
            customProperties.MergeStringKeys(propertiesToSet);
            customProperties.StripKeysWithNullValues();
            var actorProperties = propertiesToSet.StripToStringKeys();
            if (actorID > 0 && !PhotonNetwork.offlineMode)
            {
                PhotonNetwork.networkingPeer.OpSetCustomPropertiesOfActor(actorID, actorProperties, true, 0);
            }
            var parameters = new object[] { this, propertiesToSet };
            NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonPlayerPropertiesChanged, parameters);
        }
    }

    public override string ToString()
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Format("#{0:00}{1}", ID, !isMasterClient ? string.Empty : "(master)");
        }
        return string.Format("'{0}'{1}", name, !isMasterClient ? string.Empty : "(master)");
    }

    public string ToStringFull()
    {
        return string.Format("#{0:00} '{1}' {2}", ID, name, customProperties.ToStringFull());
    }

    public Hashtable allProperties
    {
        get
        {
            var target = new Hashtable();
            target.Merge(customProperties);
            target[(byte) 255] = name;
            return target;
        }
    }

    public Hashtable customProperties { get; private set; }

    public int ID
    {
        get
        {
            return actorID;
        }
    }

    public bool isMasterClient
    {
        get
        {
            return PhotonNetwork.networkingPeer.mMasterClient == this;
        }
    }

    protected internal string Name
    {
        get
        {
            var a = customProperties["name"];
            var b = a as string;
            return b ?? string.Empty;
        }
        set
        {
            var propertiesToSet = new Hashtable { { "name", value } };
            SetCustomProperties(propertiesToSet);
        }
    }

    public string name
    {
        get
        {
            return nameField;
        }
        set
        {
            if (!isLocal)
            {
                Debug.LogError("Error: Cannot change the name of a remote player!");
            }
            else
            {
                nameField = value;
            }
        }
    }
}

