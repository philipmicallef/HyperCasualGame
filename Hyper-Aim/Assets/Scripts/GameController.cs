using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField]
    private int missileCount;

    [Header("Missile Spawning")]
    private Vector2 missileSpawnPosition;

    [SerializeField]
    private GameObject missileObject;

    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        Instance = this;
        GameUI = GetComponent<GameUI>();
    }

    private void Start() 
    {
        GameUI.SetInitialDisplayedMissileCount(missileCount);
        SpawnMissile();
    }

    public void OnSuccessfulMissileHit()
    {
        if(missileCount > 0)
        {
            SpawnMissile();
        }
        else 
        {
            StartGameOverSequence(true);
        }
    }

    private void SpawnMissile()
    {
        missileCount--;
        Instantiate(missileObject, missileSpawnPosition, Quaternion.identity);
    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequenceCoroutine", win);
    }

    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win)
        {
            yield return new WaitForSecondsRealtime(0.3f);
        }
        else 
        {
            GameUI.ShowRestartButton();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    } 
}
