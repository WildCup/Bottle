using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game instance;
    public List<Quest> quests = new List<Quest>();
    public List<Player> players = new List<Player>();
    private void Awake()
    {
        instance = this;
        SaveLoad.Load();
    }
    void Start()
    {
        /*Quest q1 = new Quest("Take your bra off", 3);
        Quest q2 = new Quest("Kiss PLAYER", 2);
        Quest q3 = new Quest("Drink", 1);
        quests.Add(q1);
        quests.Add(q2);
        quests.Add(q3);*/
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SaveLoad.Save();
        if (Input.GetKeyDown(KeyCode.L))
            SaveLoad.Load();
    }
}
