using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject restartButton;

    [Header("Missile Count Display")]

    [SerializeField]
    private GameObject panelMissiles;

    [SerializeField]
    private GameObject iconMissle;

    [SerializeField]
    private Color usedIconMissileColor; 


    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void SetInitialDisplayedMissileCount(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(iconMissle, panelMissiles.transform);
    }

    private int missileIconIndexToChange = 0;
    public void DecrementDisplyedMissileCount()
    {
        panelMissiles.transform.GetChild(missileIconIndexToChange++).GetComponent<Image>().color = usedIconMissileColor;
    }
    

}
