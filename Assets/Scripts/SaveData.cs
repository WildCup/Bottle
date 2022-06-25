using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<Quest> quests;
    public List<Player> players;
    public SaveData()
    {
        quests =    Game.instance.quests;
        players =   Game.instance.players;
    }
}
