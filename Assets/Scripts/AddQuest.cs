using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddQuest : MonoBehaviour
{
    public Text gender;
    public Text lvlText;
    public Text text;

    public Color cMan;
    public Color cWoman;
    public Color cEveryone;
    public Color clvl1;
    public Color clvl2;
    public Color clvl3;
    public Color clvl4;
    public Color clvl5;

    public Image image;
    public Image imageGender;
    public InputField inputField;

    public Quest quest;
    public Image editButton;

    public void ChangeGender()
    {
        if (quest.gender == Quest.Gender.man)
        {
            gender.text = "woman";
            imageGender.color = cWoman;
            quest.gender = Quest.Gender.woman;
        }
        else if (quest.gender == Quest.Gender.woman)
        {
            gender.text = "everyone";
            imageGender.color = cEveryone;
            quest.gender = Quest.Gender.everyone;
        }
        else
        {
            gender.text = "man";
            imageGender.color = cMan;
            quest.gender = Quest.Gender.man;
        }
    }
    public void ChangeLvl()
    {
        if (quest.lvl == 5) quest.lvl = 1;
        else quest.lvl++;

        lvlText.text = "lvl " + quest.lvl;

        switch (quest.lvl)
        {
            case 1: image.color = clvl1; break;
            case 2: image.color = clvl2; break;
            case 3: image.color = clvl3; break;
            case 4: image.color = clvl4; break;
            case 5: image.color = clvl5; break;
        }
    }
    public void DeleteQuest()
    {
        Destroy(gameObject);
    }
    public void EditQuest()
    {
        if (!inputField.IsInteractable())
        {
            editButton.color = new Color(255, 255, 255, 255);
            inputField.image.enabled = true;
            inputField.interactable = true;
            inputField.MoveTextEnd(true);
        }
        else
        {
            editButton.color = new Color(255, 255, 255, 60);
            inputField.image.enabled = false;
            quest.quest = inputField.text;
            StartCoroutine(DisableInput());
        }
    }
    IEnumerator DisableInput()
    {
        yield return new WaitForEndOfFrame();
        inputField.interactable = false;
    }
    public void UpdateQuest()
    {
        quest.lvl--;
        ChangeLvl();
        if (quest.gender == Quest.Gender.man)
        {
            gender.text = "man";
            imageGender.color = cMan;
            quest.gender = Quest.Gender.man;
        }
        else if (quest.gender == Quest.Gender.woman)
        {
            gender.text = "woman";
            imageGender.color = cWoman;
            quest.gender = Quest.Gender.woman;
        }
        else
        {
            gender.text = "everyone";
            imageGender.color = cEveryone;
            quest.gender = Quest.Gender.everyone;
        }
        text.text = quest.quest;
        inputField.text = quest.quest;
        inputField.interactable = false;
        inputField.image.enabled = false;
    }
}
