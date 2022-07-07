using UnityEngine;

[System.Serializable]
public class Quest
{
    public string quest;
    public int lvl = 1;
    public bool used = false;
    public Gender gender = Gender.everyone;

    public Quest(string quest, int lvl)
    {
        this.quest = quest;
        this.lvl = lvl;
    }

    public enum Gender { man, woman, everyone }
}
