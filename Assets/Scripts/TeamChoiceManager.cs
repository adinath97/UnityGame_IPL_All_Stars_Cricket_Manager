using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamChoiceManager : MonoBehaviour
{
    public static bool teamNorthPicked, teamSouthPicked, sidePicked;
    public static bool tenOversPicked, twentyOversPicked, oversPicked;
    public static int southWins, northWins, totalGames;

    [SerializeField] GameObject nextSceneText;
    [SerializeField] GameObject pickOversText;
    [SerializeField] GameObject tenOversText;
    [SerializeField] GameObject twentyOversText;

    void Awake()
    {
        southWins = 0;
        northWins = 0;
        totalGames = 0;
        nextSceneText.SetActive(false);
        pickOversText.SetActive(false);
        tenOversText.SetActive(false);
        twentyOversText.SetActive(false);
    }

    void Start()
    {
        //north = teamB; south = teamA
        teamNorthPicked = false;
        teamSouthPicked = false;
        tenOversPicked = false;
        twentyOversPicked = false;
        sidePicked = false;
        oversPicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N) && !sidePicked) {
            teamNorthPicked = true;
            sidePicked = true;
            pickOversText.SetActive(true);
            tenOversText.SetActive(true);
            twentyOversText.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.S) && !sidePicked) {
            sidePicked = true;
            teamSouthPicked = true;
            pickOversText.SetActive(true);
            tenOversText.SetActive(true);
            twentyOversText.SetActive(true);
        }
        if(sidePicked && Input.GetKeyDown(KeyCode.T) && !oversPicked) {
            oversPicked = true;
            tenOversPicked = true;
            nextSceneText.SetActive(true);
        }
        if(sidePicked && Input.GetKeyDown(KeyCode.Y) && !oversPicked) {
            oversPicked = true;
            twentyOversPicked = true;
            nextSceneText.SetActive(true);
        }
        if(teamNorthPicked && (tenOversPicked || twentyOversPicked) && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("TeamBSelection");
        }
        else if(teamSouthPicked && (tenOversPicked || twentyOversPicked) && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("TeamASelection");
        }
    }
}
