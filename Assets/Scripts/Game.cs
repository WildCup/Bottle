using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game instance;
    public List<Quest> quests = new List<Quest>();
    public List<Player> players = new List<Player>();

    List<int> q1 = new List<int>();
    List<int> q2 = new List<int>();
    List<int> q3 = new List<int>();
    List<int> q4 = new List<int>();
    List<int> q5 = new List<int>();

    public Text text;
    public Image image;

    int current = -1;
    int used = 0;

    private void Awake()
    {
        instance = this;
        SaveLoad.Load();
        updateQuests();
        RollNextQuestion();
        Sort();
    }

    public void updateQuests()
    {
        q1.Clear();
        q2.Clear();
        q3.Clear();
        q4.Clear();
        q5.Clear();

        for (int i = 0; i < quests.Count; i++)
        {
            if (!quests[i].used)
            {
                switch (quests[i].lvl)
                {
                    case 1: q1.Add(i); break;
                    case 2: q2.Add(i); break;
                    case 3: q3.Add(i); break;
                    case 4: q4.Add(i); break;
                    case 5: q5.Add(i); break;
                }
            }
            else used++;
        }
    }

    public void RollNextQuestion()
    {
        current++;
        float chanse5 = 0.01f + (0.01f / 12 * used); //%
        float chanse4 = 0.09f + (0.09f / 12 * used); //%
        float chanse3 = 1.9f + (1.9f / 12 * used); //%
        float chanse2 = 10f + (10 / 12 * used); //%
        float chanse1 = 88f - used; //%

        float random = Random.Range(0, 100);
        if ((random < chanse5 || q4.Count == 0) && q5.Count > 0)
        {
            int i = Random.Range(0, q5.Count);
            current = q5[i];
        }
        else if ((random < chanse4 || q3.Count == 0) && q4.Count > 0)
        {
            int i = Random.Range(0, q4.Count);
            current = q4[i];
        }
        else if ((random < chanse3 || q2.Count == 0) && q3.Count > 0)
        {
            int i = Random.Range(0, q3.Count);
            current = q3[i];
        }
        else if ((random < chanse2 || q1.Count == 0) && q2.Count > 0)
        {
            int i = Random.Range(0, q2.Count);
            current = q2[i];
        }
        else if (q1.Count > 0)
        {
            int i = Random.Range(0, q1.Count);
            current = q1[i];
        }
        else
        {
            text.text = "You finished the game.\nPlease restart your profress.";
            return;
        }
        
        text.text = quests[current].quest;

        switch (quests[current].lvl)
        {
            case 1: image.color = Colors.instance.cLvl1; break;
            case 2: image.color = Colors.instance.cLvl2; break;
            case 3: image.color = Colors.instance.cLvl3; break;
            case 4: image.color = Colors.instance.cLvl4; break;
            case 5: image.color = Colors.instance.cLvl5; break;
        }

        Debug.Log(q1.Count + ", " + q2.Count + ", " + q3.Count + ", " + q4.Count + ", " + q4.Count);
    }

    public void Done()
    {
        quests[current].used = true;
        used++;
        switch (quests[current].lvl)
        {
            case 1: q1.Remove(current); break;
            case 2: q2.Remove(current); break;
            case 3: q3.Remove(current); break;
            case 4: q4.Remove(current); break;
            case 5: q5.Remove(current); break;
        }
        RollNextQuestion();
    }
    public void Reject()
    {
        RollNextQuestion();
    }

    private void OnApplicationQuit()
    {
        SaveLoad.Save();
    }
    public void ResetProgres()
    {
        foreach(Quest q in quests)
            q.used = false;

        updateQuests();
    }
    public void Sort()
    {
        quests.Sort(delegate(Quest a, Quest b) {
            if (a.lvl != b.lvl) return a.lvl.CompareTo(b.lvl);
            else return a.quest.CompareTo(b.quest);
        });
        updateQuests();
    }
}
