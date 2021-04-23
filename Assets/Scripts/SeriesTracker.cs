using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeriesTracker : MonoBehaviour
{
    [SerializeField] GameObject northScoreBox;
    [SerializeField] GameObject southScoreBox;
    [SerializeField] GameObject seriesUpdateBox;
    [SerializeField] GameObject nextSceneText;
    
    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        northScoreBox.GetComponent<Text>().text = TeamChoiceManager.northWins.ToString();
        southScoreBox.GetComponent<Text>().text = TeamChoiceManager.southWins.ToString();
        if(TeamChoiceManager.totalGames == 3) {
            nextSceneText.GetComponent<Text>().text = "Restart Series (Press Spacebar to Continue)";
            if(TeamChoiceManager.northWins > TeamChoiceManager.southWins) {
                seriesUpdateBox.GetComponent<Text>().text = "TEAM NORTH WINS THE SERIES " + TeamChoiceManager.northWins.ToString() + " - " + TeamChoiceManager.southWins.ToString();
            }
            if(TeamChoiceManager.northWins < TeamChoiceManager.southWins) {
                seriesUpdateBox.GetComponent<Text>().text = "TEAM SOUTH WINS THE SERIES " + TeamChoiceManager.southWins.ToString() + " - " + TeamChoiceManager.northWins.ToString();
            }
            if(TeamChoiceManager.northWins == TeamChoiceManager.southWins) {
                seriesUpdateBox.GetComponent<Text>().text = "THE SERIES ENDS TIED AT " + TeamChoiceManager.southWins.ToString() + " - " + TeamChoiceManager.northWins.ToString();
            }
        }
        else if(TeamChoiceManager.totalGames < 3) {
            nextSceneText.GetComponent<Text>().text = "Continue to Next Game (Press Spacebar to Continue)";
            if(TeamChoiceManager.northWins > TeamChoiceManager.southWins) {
                seriesUpdateBox.GetComponent<Text>().text = "TEAM NORTH LEADS THE SERIES " + TeamChoiceManager.northWins.ToString() + " - " + TeamChoiceManager.southWins.ToString();
            }
            if(TeamChoiceManager.northWins < TeamChoiceManager.southWins) {
                seriesUpdateBox.GetComponent<Text>().text = "TEAM SOUTH LEADS THE SERIES " + TeamChoiceManager.southWins.ToString() + " - " + TeamChoiceManager.northWins.ToString();
            }
            if(TeamChoiceManager.northWins == TeamChoiceManager.southWins) {
                seriesUpdateBox.GetComponent<Text>().text = "THE SERIES IS TIED AT " + TeamChoiceManager.southWins.ToString() + " - " + TeamChoiceManager.northWins.ToString();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(TeamChoiceManager.totalGames < 3) {
                if(TeamChoiceManager.teamNorthPicked) {
                    SceneManager.LoadScene("TeamBSelection");
                }
                if(TeamChoiceManager.teamSouthPicked) {
                    SceneManager.LoadScene("TeamASelection");
                }
            }
            if(TeamChoiceManager.totalGames == 3) {
                SceneManager.LoadScene("TeamSelectionChoice");
            }
            
        }

        if(Input.GetKeyDown(KeyCode.M)) {
            SceneManager.LoadScene("MainMenu");
        }

        if(Input.GetKeyDown(KeyCode.S)) {
            SceneManager.LoadScene("TeamSelectionChoice");
        } 
    }
}
