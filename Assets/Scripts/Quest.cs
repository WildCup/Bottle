using UnityEngine;

[System.Serializable]
public class Quest
{
    public string quest;
    public int lvl = 1;
    public bool isDare = true;
    public bool used = false;

    public Quest(string quest, int lvl)
    {
        this.quest = quest;
        this.lvl = lvl;
    }
}
