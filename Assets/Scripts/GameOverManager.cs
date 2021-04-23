using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject firstInningsSummaryBox;
    [SerializeField] GameObject secondInningsSummaryBox;
    [SerializeField] GameObject gameOverSummaryBox;
    [SerializeField] GameObject nextSceneTextBox;
    public static string firstInningsText;
    public static string secondInningsText;
    public static string gameOverText;
    
    // Start is called before the first frame update
    void Start()
    {
        firstInningsSummaryBox.GetComponent<Text>().text = firstInningsText;
        secondInningsSummaryBox.GetComponent<Text>().text = secondInningsText;
        gameOverSummaryBox.GetComponent<Text>().text = gameOverText;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("SeriesScoreLineScene");
        }
    }
}
