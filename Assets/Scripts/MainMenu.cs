using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject play;
    public GameObject players;
    public GameObject quests;
    public GameObject options;

    public GameObject playerPref;
    public Transform parentPlayers;
    //Transform parentQuests;
    private void Awake()
    {
        //parentPlayers = GameObject.Find("Content").transform;
        //parentQuests = GameObject.Find("Content2").transform;
    }

    private void Start()
    {
        //load and add all players
        int s = Game.instance.players.Count;
        if (s > 0)
        {
            Destroy(parentPlayers.GetChild(0).gameObject);
            for(int i = 0; i < s; i++)
            {
                GameObject o = Instantiate(playerPref, parentPlayers);
                AddPlayer p = o.GetComponent<AddPlayer>();
                p.player = Game.instance.players[i];
                p.UpdatePlayer();
            }
        }

        //load and add all quests
    }

    public void Play()
    {
        play.SetActive(true);
    }
    public void Players()
    {
        players.SetActive(true);
    }
    public void Quests()
    {
        quests.SetActive(true);
    }
    public void Options()
    {
        options.SetActive(true);
    }
    public void Exit()
    {
        play.SetActive(false);
        players.SetActive(false);
        quests.SetActive(false);
        options.SetActive(false);
    }
    public void AddPlayer()
    {
        Instantiate(playerPref, parentPlayers);
    }
    public void SubmitPlayers()
    {
        Game.instance.players.Clear();
        foreach (Transform child in parentPlayers)
        {
            AddPlayer p = child.GetComponent<AddPlayer>();
            if(p != null)
            {
                Game.instance.players.Add(p.player);
            }
        }
    }
}
