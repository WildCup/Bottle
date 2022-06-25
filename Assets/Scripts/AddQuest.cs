using UnityEngine;
using UnityEngine.UI;

public class AddQuest : MonoBehaviour
{
    public Text gender;
    public Color cDare;
    public Color cTruth;
    public Image image;

    public InputField inputField;

    public bool isDare = true;
    public string quest;

    public void ChangeGender()
    {
        if (isDare)
        {
            gender.text = "Truth";
            image.color = cTruth;
        } else
        {
            gender.text = "Dare";
            image.color = cDare;
        }
        isDare = !isDare;
    }
    public void ChangeName()
    {
        quest = inputField.text;
    }
    public void DeletePlayer()
    {
        Destroy(gameObject);
    }
}
