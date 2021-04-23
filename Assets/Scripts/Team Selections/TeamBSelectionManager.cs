using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamBSelectionManager : MonoBehaviour
{
    [SerializeField] List<GameObject> theTeam19 = new List<GameObject>();
    [SerializeField] List<GameObject> theTeam19BattingTiers = new List<GameObject>();
    [SerializeField] List<GameObject> theTeam19BowlingTiers = new List<GameObject>();
    public static List<string> theTeam19PlayerNames = new List<string>() {
        "KL Rahul", "Chris Gayle", "Steven Smith", "Sanju Samson", 
        "Rishabh Pant", "Jos Buttler", "Andre Russell", "Chris Morris", 
        "Sunil Narine", "Kagiso Rabada", "Mohammad Shami", "Nicholas Pooran",
        "Pat Cummins", "Jofra Archer", "Ajinkya Rahane", "Shakib Al Hasan",
        "Mayank Agrawal", "Ravichandran Ashwin", "Andrew Tye"
    };
    public static List<string> opposition19PlayerNames = new List<string>() { 
    "David Warner", "Rohit Sharma", "Virat Kohli", "Kane Williamson",
    "AB de Villiers", "MS Dhoni", "Suresh Raina",  "Jasprit Bumrah", 
    "Josh Hazelwood", "Rashid Khan", "Trent Boult", "Glenn Maxwell", 
    "Imran Tahir", "Jason Holder", "Quinton de Kock", "Kieron Pollard",
    "Jonny Bairstow", "Washington Sundar", "Deepak Chahar"
    };
    [SerializeField] List<int> theTeam19BattingTiersInt = new List<int>() 
    {5,5,5,5,5,5,4,3,1,1,1,5,1,1,5,3,5,3,1};
    [SerializeField] List<int> theTeam19BowlingTiersInt = new List<int>()
    {1,1,1,1,1,1,2,3,5,5,5,1,5,5,1,3,1,3,5};

    [SerializeField] List<int> opposition19BattingTiersInt = new List<int>() 
    {5,5,5,5,5,5,4,1,1,1,1,4,1,3,5,4,5,3,1};
    [SerializeField] List<int> opposition19BowlingTiersInt = new List<int>()
    {1,1,1,1,1,1,2,5,5,5,5,2,5,3,1,2,1,3,5};

    public static List<bool> playerPickedForSwap = new List<bool>() 
    {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false};

    public static int playersPickedForSwap, player1Position, player2Position;

    public static bool allowPlayerSelection;

    public static float myTeamAverageBowlingStrength, myTeamAverageBattingStrength, myTeamBattingTotalStrength, myTeamBowlingTotalStrength,
    oppositionAverageBowlingStrength, oppositionAverageBattingStrength, oppositionBattingTotalStrength, oppositionBowlingTotalStrength;
    
    // Start is called before the first frame update
    void Start()
    {
        myTeamAverageBowlingStrength = 0;
        myTeamAverageBattingStrength = 0;
        myTeamBattingTotalStrength = 0;
        myTeamBowlingTotalStrength = 0;
        oppositionAverageBattingStrength = 0;
        oppositionAverageBowlingStrength = 0;
        oppositionBattingTotalStrength = 0;
        oppositionBowlingTotalStrength = 0;
        theTeam19BowlingTiersInt = new List<int>()
    {1,1,1,1,1,1,2,3,5,5,5,1,5,5,1,3,1,3,5};
        theTeam19BattingTiersInt = new List<int>() 
    {5,5,5,5,5,5,4,3,1,1,1,5,1,1,5,3,5,3,1};
        theTeam19PlayerNames = new List<string>() {
        "KL Rahul", "Chris Gayle", "Steven Smith", "Sanju Samson", 
        "Rishabh Pant", "Jos Buttler", "Andre Russell", "Chris Morris", 
        "Sunil Narine", "Kagiso Rabada", "Mohammad Shami", "Nicholas Pooran",
        "Pat Cummins", "Jofra Archer", "Ajinkya Rahane", "Shakib Al Hasan",
        "Mayank Agrawal", "Ravichandran Ashwin", "Andrew Tye"
    };
        SetUp();
        allowPlayerSelection = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playersPickedForSwap == 2) {
            SwapPlayers();
        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            //finalize batting line-ups and tiers for both teams (yours and opposition)
            //myTeam (team B) finalization
            for(int i = 0; i < 11; i++) {
                //finalize batting line ups
                TeamABatsFirstTeamBChosen.bowlingTeamPlayerNames[i] = theTeam19[i].GetComponent<Text>().text;
                TeamAChasingTeamBChosen.bowlingTeamPlayerNames[i] = theTeam19[i].GetComponent<Text>().text;
                TeamBBatsFirstTeamBChosen.battingTeamPlayerNames[i] = theTeam19[i].GetComponent<Text>().text;
                TeamBChasingTeamBChosen.battingTeamPlayerNames[i] = theTeam19[i].GetComponent<Text>().text;

                //finalize batting and bowling tiers
                //team B batting
                TeamBBatsFirstTeamBChosen.battingTeamTiers[i] = int.Parse(theTeam19BattingTiers[i].GetComponent<Text>().text);
                TeamBChasingTeamBChosen.battingTeamTiers[i] = int.Parse(theTeam19BattingTiers[i].GetComponent<Text>().text);
                //team B bowling
                TeamABatsFirstTeamBChosen.bowlingTeamTiers[i] = int.Parse(theTeam19BowlingTiers[i].GetComponent<Text>().text);
                TeamAChasingTeamBChosen.bowlingTeamTiers[i] = int.Parse(theTeam19BowlingTiers[i].GetComponent<Text>().text);

                //finalize bowling tiers
                myTeamBattingTotalStrength += int.Parse(theTeam19BattingTiers[i].GetComponent<Text>().text);
                myTeamBowlingTotalStrength += int.Parse(theTeam19BowlingTiers[i].GetComponent<Text>().text);

                if(i == 10) {
                    myTeamAverageBattingStrength = myTeamBattingTotalStrength / 10f;
                    myTeamAverageBowlingStrength = myTeamBowlingTotalStrength / 10f;
                }

            }
            //opposition (team A) finalization
            for(int i = 0; i < 11; i++) {
                //finalize batting line ups
                TeamABatsFirstTeamBChosen.battingTeamPlayerNames[i] = opposition19PlayerNames[i];
                TeamAChasingTeamBChosen.battingTeamPlayerNames[i] = opposition19PlayerNames[i];
                TeamBBatsFirstTeamBChosen.bowlingTeamPlayerNames[i] = opposition19PlayerNames[i];
                TeamBChasingTeamBChosen.bowlingTeamPlayerNames[i] = opposition19PlayerNames[i];

                //finalize batting and bowling tiers
                //team B batting
                TeamBBatsFirstTeamBChosen.bowlingTeamTiers[i] = opposition19BowlingTiersInt[i];
                TeamBChasingTeamBChosen.bowlingTeamTiers[i] = opposition19BowlingTiersInt[i];
                //team B bowling
                TeamABatsFirstTeamBChosen.battingTeamTiers[i] = opposition19BattingTiersInt[i];
                TeamAChasingTeamBChosen.battingTeamTiers[i] = opposition19BattingTiersInt[i];

                oppositionBattingTotalStrength += opposition19BattingTiersInt[i];
                oppositionBowlingTotalStrength += opposition19BowlingTiersInt[i];

                //finalize bowling tiers
                if(i == 10) {
                    oppositionAverageBattingStrength = oppositionBattingTotalStrength / 10f;
                    oppositionAverageBowlingStrength = oppositionBowlingTotalStrength / 10f;
                }
            }
            SceneManager.LoadScene("Toss");
        }
    }

    void SwapPlayers() {
        string player1, player2;
        int player1BattingTier, player2BattingTier, player1BowlingTier, player2BowlingTier;
        //get all player1's info
        player1 = theTeam19PlayerNames[player1Position];
        player1BattingTier = theTeam19BattingTiersInt[player1Position];
        player1BowlingTier = theTeam19BowlingTiersInt[player1Position];
        //get all player2's info
        player2 = theTeam19PlayerNames[player2Position];
        player2BattingTier = theTeam19BattingTiersInt[player2Position];
        player2BowlingTier = theTeam19BowlingTiersInt[player2Position];
        //player1 stuff goes to player2's position
        theTeam19PlayerNames[player2Position] = player1;
        theTeam19BattingTiersInt[player2Position] = player1BattingTier;
        theTeam19BowlingTiersInt[player2Position] = player1BowlingTier;
        //player2 stuff goes to player1's position
        theTeam19PlayerNames[player1Position] = player2;
        theTeam19BattingTiersInt[player1Position] = player2BattingTier;
        theTeam19BowlingTiersInt[player1Position] = player2BowlingTier;
        //reset all
        playersPickedForSwap = 0;
        player1Position = 0;
        player2Position = 0;
        playerPickedForSwap = new List<bool>() 
            {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false};
        SetUp();
        allowPlayerSelection = true;
    }
    void SetUp() {
        playersPickedForSwap = 0;
        for(int i = 0; i < 19; i++) {
            theTeam19[i].GetComponent<Text>().text = theTeam19PlayerNames[i];
        }

        for(int i = 0; i < 19; i++) {
            theTeam19BattingTiers[i].GetComponent<Text>().text = theTeam19BattingTiersInt[i].ToString();
        }

        for(int i = 0; i < 19; i++) {
            theTeam19BowlingTiers[i].GetComponent<Text>().text = theTeam19BowlingTiersInt[i].ToString();
        }
    }
}
