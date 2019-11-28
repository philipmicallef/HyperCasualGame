using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEvents : MonoBehaviour
{
    public void GoToGame()
    {
        Debug.Log("This script works!");
        SceneManager.LoadScene("Level1");

    }
}
