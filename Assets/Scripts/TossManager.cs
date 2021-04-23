using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TossManager : MonoBehaviour
{
    [SerializeField] GameObject wonTossText;
    [SerializeField] GameObject pickBattingText;
    [SerializeField] GameObject pickFieldingText;
    [SerializeField] GameObject lostTossFieldFirstText;
    [SerializeField] GameObject lostTossBatFirstText;
    [SerializeField] GameObject pressSpacebarToContinueText;
    int playerTossSelection, rand1, rand2;
    bool playerBattingFirst, playerFieldingFirst, batBowlPicked, headTailPicked;
    void Awake()
    {
        playerBattingFirst = false;
        playerFieldingFirst = false;
        headTailPicked = false;
        batBowlPicked = false;
        wonTossText.SetActive(false);
        pickBattingText.SetActive(false);
        pickFieldingText.SetActive(false);
        lostTossFieldFirstText.SetActive(false);
        lostTossBatFirstText.SetActive(false);
        pressSpacebarToContinueText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H) && !headTailPicked) {
            headTailPicked = true;
            playerTossSelection = 0;
            rand2 = Mathf.RoundToInt(Random.Range(0,10));
            rand1 = rand2 % 2;
            DetermineTossResult();
        }
        if(Input.GetKeyDown(KeyCode.T) && !headTailPicked) {
            headTailPicked = true;
            playerTossSelection = 1;
            rand2 = Mathf.RoundToInt(Random.Range(0,10));
            rand1 = rand2 % 2;
            DetermineTossResult();
        }
        if(playerTossSelection == rand1 && Input.GetKeyDown(KeyCode.B) && !batBowlPicked) {
            batBowlPicked = true;
            playerBattingFirst = true;
            pressSpacebarToContinueText.SetActive(true);
        }
        if(playerTossSelection == rand1 && Input.GetKeyDown(KeyCode.F) && !batBowlPicked) {
            batBowlPicked = true;
            playerFieldingFirst = true;
            pressSpacebarToContinueText.SetActive(true);
        }
        if(TeamChoiceManager.teamSouthPicked) {
            if(playerBattingFirst && Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene("TeamABatsFirstTeamAChosen");
            }
            if(playerFieldingFirst && Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene("TeamBBatsFirstTeamAChosen");
            }
        }
        if(TeamChoiceManager.teamNorthPicked) {
            if(playerBattingFirst && Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene("TeamBBatsFirstTeamBChosen");
            }
            if(playerFieldingFirst && Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene("TeamABatsFirstTeamBChosen");
            }
        }
    }

    void DetermineTossResult() {
        if(playerTossSelection == rand1) {
            //player won toss
            wonTossText.SetActive(true);
            pickBattingText.SetActive(true);
            pickFieldingText.SetActive(true);
        }
        else if(playerTossSelection != rand1) {
            int rand2 = Random.Range(0,2);
            if(rand2 == 0) {
                lostTossFieldFirstText.SetActive(true);
                pressSpacebarToContinueText.SetActive(true);
                playerFieldingFirst = true;
            }
            if(rand2 == 1) {
                lostTossBatFirstText.SetActive(true);
                pressSpacebarToContinueText.SetActive(true);
                playerBattingFirst = true;
            }
        }
    }

}
