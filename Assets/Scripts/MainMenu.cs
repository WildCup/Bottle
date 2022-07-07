using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject playPanel;
    public GameObject playersPanel;
    public GameObject questsPanel;
    public GameObject addQuestPanel;
    public GameObject optionsPanel;
    public GameObject instructionPanel;

    public GameObject playerPref;
    public GameObject questPref;

    public Transform playersParent;
    public Transform questsParent;

    int lvl = 0;
    public Image image;
    public Text text;
    public Text instructionText;
    int i = 0;

    private void Start()
    {
        //load and add all players UI
        int s = Game.instance.players.Count;
        if (s > 0)
        {
            Destroy(playersParent.GetChild(0).gameObject);
            for(int i = 0; i < s; i++)
            {
                GameObject o = Instantiate(playerPref, playersParent);
                AddPlayer p = o.GetComponent<AddPlayer>();
                p.player = Game.instance.players[i];
                p.UpdatePlayer();
            }
        }

        //load and add all quests UI
        s = Game.instance.quests.Count;
        if (s > 0)
        {
            Destroy(questsParent.GetChild(0).gameObject);
            for (int i = 0; i < s; i++)
            {
                GameObject o = Instantiate(questPref, questsParent);
                AddQuest p = o.GetComponent<AddQuest>();
                p.quest = Game.instance.quests[i];
                p.UpdateQuest();
            }
        }
    }

    public void Play()
    {
        playPanel.SetActive(true);
    }
    public void Players()
    {
        playersPanel.SetActive(true);
    }
    public void Quests()
    {
        questsPanel.SetActive(true);
    }
    public void Options()
    {
        optionsPanel.SetActive(true);
    }
    public void Exit()
    {
        playPanel.SetActive(false);
        playersPanel.SetActive(false);
        questsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void AddPlayer()
    {
        Instantiate(playerPref, playersParent);
    }
    public void AddQuest()
    {
        Instantiate(questPref, questsParent);
    }
    public void SubmitPlayers()
    {
        Game.instance.players.Clear();
        foreach (Transform child in playersParent)
        {
            AddPlayer p = child.GetComponent<AddPlayer>();
            if(p != null)
            {
                Game.instance.players.Add(p.player);
            }
        }
    }
    public void SubmitQuest()
    {
        Game.instance.quests.Clear();
        foreach (Transform child in questsParent)
        {
            AddQuest q = child.GetComponent<AddQuest>();
            if (q != null)
            {
                Game.instance.quests.Add(q.quest);
            }
        }
        Game.instance.updateQuests();
    }

    public void ChangeLvl()
    {
        lvl++;
        if (lvl > 5) lvl = 0;
        switch (lvl)
        {
            case 0: image.color = new Color(255, 255, 255, 255); break;
            case 1: image.color = Colors.instance.cLvl1; break;
            case 2: image.color = Colors.instance.cLvl2; break;
            case 3: image.color = Colors.instance.cLvl3; break;
            case 4: image.color = Colors.instance.cLvl4; break;
            case 5: image.color = Colors.instance.cLvl5; break;
        }
        if (lvl == 0) text.text = "all";
        else text.text = "lvl " + lvl;


        //load and add all quests UI
        foreach (Transform t in questsParent)
        {
            if(lvl == 0 || t.GetComponent<AddQuest>().quest.lvl == lvl)
                t.gameObject.SetActive(true);
            else t.gameObject.SetActive(false);
        }
    }

    public void ShowInstruction()
    {
        instructionPanel.SetActive(true);
    }
    public void ShowNextInstruction()
    {
        string[] ss = {"Meaning of levels:\n\n" +
                "lvl 1:\nno problem for sober, comfortable\n\n"+
                "lvl 2:\nno problem for sober, less comfortable\n\n"+
                "lvl 3:\nI'd like to be less sober\n\n"+
                "lvl 4:\nI'd like to be drunk\n\n"+
                "lvl 5:\nI'd like to be drunk as hell",

                "If sb don't want to do a challange they must drink!\n\n" +
                "If the challange does include drinking already, you can't skip it.\n\n" +
                "Click on the right if the challange was complerted - it won't appear again. Click on the left otherwise.\n\n" +
                "Restart progress button - sets all quests to notUsed.\n"+
                "It won't delete or restore anything,\nso be carefull with your decisions."
        };
        i++;
        if (i < ss.Length) instructionText.text = ss[i];
        else instructionPanel.SetActive(false);
    }
}
