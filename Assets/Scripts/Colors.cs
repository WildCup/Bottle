using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    public static Color cMan;
    public static Color cWoman;
    public static Color cEveryone;
    public Color cLvl1 = new Color32(159, 159, 159, 255);
    public Color cLvl2 = new Color32(100, 255, 80, 255);
    public Color cLvl3 = new Color32(23, 205, 255, 255);
    public Color cLvl4 = new Color32(195, 85, 255, 255);
    public Color cLvl5 = new Color32(255, 190, 64, 255);

    public static Colors instance;

    private void Awake()
    {
        instance = this;
    }
}
