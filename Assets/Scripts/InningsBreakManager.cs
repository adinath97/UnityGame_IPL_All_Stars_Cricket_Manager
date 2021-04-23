using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InningsBreakManager : MonoBehaviour
{
    [SerializeField] GameObject firstInningSummaryBox;
    [SerializeField] GameObject chasePreviewBox;
    public static string firstInningSummary;
    public static string chasePreview;
    public static string nextSceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        firstInningSummaryBox.GetComponent<Text>().text = firstInningSummary;
        chasePreviewBox.GetComponent<Text>().text = chasePreview;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
