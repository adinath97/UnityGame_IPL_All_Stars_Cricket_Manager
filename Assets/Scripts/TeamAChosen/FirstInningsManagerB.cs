using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstInningsManagerB : MonoBehaviour
{
    int maxOvers;
    int maxOversPerBowler;
    int totalOversBowled, totalWickets;

    public static int battingTeamTotal;
    bool overComplete;
    
    [Header("Team Names")]
    [SerializeField] GameObject teamANameText;
    [SerializeField] GameObject teamBNameText;

    [Header("Team B (Batting)")]
    [SerializeField] List<GameObject> teamBPlayers = new List<GameObject>();
    [SerializeField] List<GameObject> teamBRuns = new List<GameObject>();
    [SerializeField] List<GameObject> teamBBalls = new List<GameObject>();
    [SerializeField] GameObject overProgressionBox;

    public static List<int> battingTeamTiers = new List<int>() {5,5,5,5,5,5,4,3,1,1,1};

    string batter1, batter2, currentBatter;

    int batter1Score, batter2Score, batter1DeliveriesFaced, batter2DeliveriesFaced, batter1Position, batter2Position, currentBatterShot, batter1Tier, batter2Tier;
    List<int> tier5BatterOptions = new List<int>() {0,1,1,2,2,2,3,3,3,3,4,4,4,4,4,6,6,6,6,6,6,6};
    List<int> tier4BatterOptions = new List<int>() {0,0,1,1,2,2,2,3,3,3,3,3,4,4,4,4,4,6,6,6,6,6,6};
    List<int> tier3BatterOptions = new List<int>() {0,0,0,1,1,2,2,2,2,3,3,3,3,4,4,4,4,4,4,6,6,6,6,6};
    List<int> tier2BatterOptions = new List<int>() {0,0,0,0,1,1,2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,6,6,6,6};
    List<int> tier1BatterOptions = new List<int>() {0,0,0,0,1,1,2,2,2,2,2,2,3,3,3,3,3,4,4,4,4,6,6,6,6};

    List<int> battingTeamRunsInt = new List<int>() {0,0,0,0,0,0,0,0,0,0,0};
    List<int> battingTeamDeliveriesFacedInt = new List<int>() {0,0,0,0,0,0,0,0,0,0,0};
    List<bool> battersAvailable = new List<bool>() {true,true,true,true,true,true,true,true,true,true,true};
    List<string> currentOverProgression = new List<string>() {"a","a","a","a","a","a"};

    [Header("Team A (Bowling)")]
    [SerializeField] List<GameObject> teamAPlayers = new List<GameObject>();
    [SerializeField] List<GameObject> teamAOversBowled = new List<GameObject>();
    [SerializeField] List<GameObject> teamARunsGiven = new List<GameObject>();
    [SerializeField] List<GameObject> teamAWicketsTaken = new List<GameObject>();

    public static List<int> bowlingTeamTiers = new List<int>() {5,5,5,5,5,5,5,1,1,1,1};

    List<int> teamAOversBowledInt = new List<int>() {0,0,0,0,0,0,0,0,0,0,0};
    List<int> teamARunsGivenInt = new List<int>() {0,0,0,0,0,0,0,0,0,0,0};
    List<int> teamAWicketsTakenInt = new List<int>() {0,0,0,0,0,0,0,0,0,0,0};
    List<bool> bowlersBowledOut = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};

    string currentBowler, previousBowler;

    int currentBowlerPosition, previousBowlerPosition, runsThisOver, 
    deliveriesThisOver, wicketsThisOver, runsPreviousOver, deliveriesPreviousOver, 
    wicketsPreviousOver, tier1BowlerCap, tier2BowlerCap, tier3BowlerCap,
    tier4BowlerCap, tier5BowlerCap, currentDelivery, currentBowlerTier;

    public static List<bool> teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
     List<bool> teamABowlerJustBowled = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
     List<bool> teamABowlerBowledOut = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};

    public static List<string> teamAPlayerNames = new List<string>() { 
    "David Warner", "Rohit Sharma", "Virat Kohli", "Kane Williamson",
    "AB de Villiers", "MS Dhoni", "Suresh Raina",  "Jasprit Bumrah", 
    "Josh Hazelwood", "Rashid Khan", "Trent Boult"
    };
    public static List<string> teamBPlayerNames = new List<string>() {
        "KL Rahul", "Chris Gayle", "Steven Smith", "Sanju Samson", 
        "Rishabh Pant", "Jos Buttler", "Andre Russell", "Chris Morris", 
        "Sunil Narine", "Kagiso Rabada", "Mohammad Shami"
    };

    [Header("Both Teams")] 

    [SerializeField] GameObject battingTeamTotalBox;
    [SerializeField] GameObject playerInstructionBox;

    bool randomBool, bowlerPickAccepted, skipOut, skipNotOut, pickedBowler, battingTeamBowledOut, inningsComplete;
    public static bool bowlerPicked;
    public static bool clickAllowed;

    void Awake()
    {
        battingTeamTotal = 0;
        totalWickets = 0;
        deliveriesThisOver = 0;
        totalOversBowled = 0;
        if(TeamChoiceManager.tenOversPicked) {
            maxOvers = 10;
            maxOversPerBowler = 2;
        }
        if(TeamChoiceManager.twentyOversPicked) {
            maxOvers = 20;
            maxOversPerBowler = 4;
        }

        float tier1Cap = Random.Range(1.2f,1.6f);
        float tier2Cap = Random.Range(1.6f,2f);
        float tier3Cap = Random.Range(2f,2.4f);
        float tier4Cap = Random.Range(2.4f,2.8f);
        float tier5Cap = Random.Range(2.8f,3.2f);
        
        /*
        if(TeamASelectionManager.myTeamAverageBowlingStrength < tier1Cap) {
            tier5BatterOptions = new List<int>() {0,1,1,2,2,3,3,3,4,4,4,4,4,4,4,4,6,6,6,6,6,6,6,6,6};
            tier4BatterOptions = new List<int>() {0,1,1,1,2,2,3,3,3,4,4,4,4,4,4,4,4,4,6,6,6,6,6,6,6};
            tier3BatterOptions = new List<int>() {0,1,1,1,2,2,2,3,3,3,4,4,4,4,4,4,4,4,4,4,4,6,6,6,6};
            tier2BatterOptions = new List<int>() {0,1,1,1,1,2,2,2,2,2,3,3,3,4,4,4,4,4,4,4,4,6,6,6,6};
            tier1BatterOptions = new List<int>() {0,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4,6,6,6};
        }
        else if(TeamASelectionManager.myTeamAverageBowlingStrength < tier2Cap && TeamASelectionManager.myTeamAverageBowlingStrength > tier1Cap) {
            tier5BatterOptions = new List<int>() {0,1,1,2,2,2,3,3,3,4,4,4,4,4,4,4,4,6,6,6,6,6,6,6,6};
            tier4BatterOptions = new List<int>() {0,1,1,2,2,2,2,3,3,3,4,4,4,4,4,4,4,4,4,6,6,6,6,6,6};
            tier3BatterOptions = new List<int>() {0,1,1,1,2,2,2,2,2,3,3,4,4,4,4,4,4,4,4,4,4,6,6,6,6};
            tier2BatterOptions = new List<int>() {0,0,1,1,1,1,2,2,2,2,2,3,3,3,4,4,4,4,4,4,4,6,6,6,6};
            tier1BatterOptions = new List<int>() {0,0,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,4,4,4,4,4,6,6,6};
        }
        else if(TeamASelectionManager.myTeamAverageBowlingStrength < tier3Cap && TeamASelectionManager.myTeamAverageBowlingStrength > tier2Cap) {
            tier5BatterOptions = new List<int>() {0,1,1,2,2,2,3,3,3,3,4,4,4,4,4,4,4,4,6,6,6,6,6,6,6};
            tier4BatterOptions = new List<int>() {0,1,1,2,2,2,2,3,3,3,3,4,4,4,4,4,4,4,4,4,6,6,6,6,6};
            tier3BatterOptions = new List<int>() {0,0,1,1,1,2,2,2,2,3,3,3,4,4,4,4,4,4,4,4,4,6,6,6,6};
            tier2BatterOptions = new List<int>() {0,0,0,1,1,1,2,2,2,2,2,3,3,3,3,4,4,4,4,4,4,4,6,6,6};
            tier1BatterOptions = new List<int>() {0,0,0,1,1,1,1,2,2,2,2,2,2,2,3,3,3,3,4,4,4,4,4,6,6};
        }
        else if(TeamASelectionManager.myTeamAverageBowlingStrength < tier4Cap && TeamBSelectionManager.myTeamAverageBowlingStrength > tier3Cap) {
            tier5BatterOptions = new List<int>() {0,1,1,2,2,2,3,3,3,3,4,4,4,4,4,4,4,4,6,6,6,6,6,6,6};
            tier4BatterOptions = new List<int>() {0,1,1,2,2,2,2,3,3,3,3,4,4,4,4,4,4,4,4,4,6,6,6,6,6};
            tier3BatterOptions = new List<int>() {0,0,1,1,1,2,2,2,2,3,3,3,4,4,4,4,4,4,4,4,4,6,6,6,6};
            tier2BatterOptions = new List<int>() {0,0,0,1,1,1,2,2,2,2,2,3,3,3,3,4,4,4,4,4,4,4,6,6,6};
            tier1BatterOptions = new List<int>() {0,0,0,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3,4,4,4,4,6,6};
        }
        else if(TeamASelectionManager.myTeamAverageBowlingStrength > tier4Cap) {
            tier5BatterOptions = new List<int>() {0,1,1,2,2,2,3,3,3,3,4,4,4,4,4,4,4,4,4,6,6,6,6,6,6};
            tier4BatterOptions = new List<int>() {0,1,1,2,2,2,2,3,3,3,3,3,4,4,4,4,4,4,4,4,6,6,6,6,6};
            tier3BatterOptions = new List<int>() {0,0,1,1,1,2,2,2,2,3,3,3,3,4,4,4,4,4,4,4,4,6,6,6,6};
            tier2BatterOptions = new List<int>() {0,0,0,1,1,1,2,2,2,2,2,3,3,3,3,4,4,4,4,4,4,4,6,6,6};
            tier1BatterOptions = new List<int>() {0,0,0,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3,4,4,4,4,6,6};
        }
        */
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        //tier 5 == 10 batting/0 bowling; tier 1 = 0 batting / 10 bowling. higher tier = better at batting & worse at bowling
        //team A players from: Chennai Super Kings, Royal Challengers Bangalore, Sunrisers Hyderabad and Mumbai
        //team B players from: Kings XI Punjab, Delhi Capitals, Rajasthan Royals and Kolkata Knight Riders
        overProgressionBox.GetComponent<Text>().text = "";
        teamANameText.GetComponent<Text>().text = "Team South";
        teamBNameText.GetComponent<Text>().text = "Team North";
        battingTeamTotalBox.GetComponent<Text>().text = "0/0 in 0.0 overs";
        playerInstructionBox.GetComponent<Text>().text = "Start the innings - Select a bowler to bowl by clicking the button next to their name";

        tier1BowlerCap = Random.Range(17,20);
        tier2BowlerCap = Random.Range(14,17);
        tier3BowlerCap = Random.Range(11,14);
        tier4BowlerCap = Random.Range(9,11);
        tier5BowlerCap = Random.Range(7,9);

        overComplete = false;

        for(int i = 0; i < 11; i++) {
            teamAPlayers[i].GetComponent<Text>().text = teamAPlayerNames[10 - i];
        }

        for(int i = 0; i < 11; i++) {
            teamBPlayers[i].GetComponent<Text>().text = teamBPlayerNames[i];
        }

        clickAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(inningsComplete) {
            playerInstructionBox.GetComponent<Text>().text = "Continue (Press Spacebar)";
        }
        if(clickAllowed && bowlerPicked) {
           clickAllowed = false; 
            if(bowlerPicked) {
                bowlerPicked = false;
                bowlerPickAccepted = false;
                randomBool = false;
                //determine which bowler was picked
                for(int i = 0; i < 11; i++) {
                    //bowler 10 corresponds to player in position 0
                    if(!pickedBowler && !randomBool && teamABowlerPicked[i]) {
                        //set the rest to false! 'reset' the list after every over? or just the position should be good
                        currentBowlerPosition = i;
                        pickedBowler = true;
                        randomBool = true;
                    }
                }
            }
            if(pickedBowler) {
                pickedBowler = false;
                //see if the bowler is available. ie. didn't ball the last over and is not bowled out
                //if bowler just bowled, reset. nothing to be done and wait for player to pick a different bowler
                if(teamABowlerJustBowled[currentBowlerPosition] || teamABowlerBowledOut[currentBowlerPosition]) {
                    bowlerPickAccepted = false;
                    if(teamABowlerJustBowled[currentBowlerPosition] && !teamABowlerBowledOut[currentBowlerPosition]) {
                        Debug.Log("THIS BOWLER JUST BOWLED!!! (NOT BOWLED OUT)");
                    }
                    else if(!teamABowlerJustBowled[currentBowlerPosition] && teamABowlerBowledOut[currentBowlerPosition]) {
                        Debug.Log("THIS BOWLER IS BOWLED OUT!!! (DIDN'T JUST BOWL)");
                    }
                    else if(teamABowlerJustBowled[currentBowlerPosition] && teamABowlerBowledOut[currentBowlerPosition]) {
                        Debug.Log("THIS BOWLER IS BOWLED OUT AND JUST BOWLED!!!");
                    }
                    clickAllowed = true;
                }
                else if(!teamABowlerJustBowled[currentBowlerPosition] && !teamABowlerBowledOut[currentBowlerPosition]) {
                    bowlerPickAccepted = true;
                    playerInstructionBox.GetComponent<Text>().text = "Select a bowler to bowl by clicking the button next to their name";
                }
                if(bowlerPickAccepted) {
                    //found a suitable bowler. determine bowler tier
                    currentBowlerTier = bowlingTeamTiers[currentBowlerPosition];
                    if(totalOversBowled == 0) {
                        batter1Position = 0;
                        batter2Position = 1;
                        currentBowler = teamAPlayerNames[currentBowlerPosition];
                        batter1 = teamBPlayerNames[batter1Position];
                        batter2 = teamBPlayerNames[batter2Position];
                        currentBatter = batter1;
                        battersAvailable[batter1Position] = false;
                        battersAvailable[batter2Position] = false;
                    }
                    if(totalOversBowled > 0) {
                        deliveriesThisOver = 0;
                        currentBowler = teamAPlayerNames[currentBowlerPosition];
                    }
                    overComplete = false;
                    StartCoroutine(BowlOverRoutine());
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && inningsComplete) {
                if(deliveriesThisOver == 6) {
                    GameOverManager.firstInningsText = "Team North: " + battingTeamTotal.ToString() + " / " + totalWickets.ToString() + " in " + totalOversBowled.ToString() + ".0 overs";
                    InningsBreakManager.firstInningSummary = "Team North: " + battingTeamTotal.ToString() + " / " + totalWickets.ToString() + " in " + totalOversBowled.ToString() + ".0 overs";
                    int total = battingTeamTotal + 1;
                    int deliveriesTotal = maxOvers * 6;
                    InningsBreakManager.chasePreview = "Team South needs " + total.ToString() + " runs in " + deliveriesTotal.ToString() + " balls to win.";
                    InningsBreakManager.nextSceneName = "TeamAChasingTeamAChosen";
                    SceneManager.LoadScene("InningsBreakScene");
                }
                else {
                    GameOverManager.firstInningsText = "Team North: " + battingTeamTotal.ToString() + " / " + totalWickets.ToString() + " in " + totalOversBowled.ToString() + "." + deliveriesThisOver.ToString() + " overs";
                    InningsBreakManager.firstInningSummary = "Team North: " + battingTeamTotal.ToString() + " / " + totalWickets.ToString() + " in " + totalOversBowled.ToString() + "." + deliveriesThisOver.ToString() + " overs";
                    int total = battingTeamTotal + 1;
                    int deliveriesTotal = maxOvers * 6;
                    InningsBreakManager.chasePreview = "Team South needs " + total.ToString() + " runs in " + deliveriesTotal.ToString() + " balls to win.";
                    InningsBreakManager.nextSceneName = "TeamAChasingTeamAChosen";
                    SceneManager.LoadScene("InningsBreakScene");
                } 
            }
    }

    IEnumerator BowlOverRoutine() {
        
        yield return new WaitForSeconds(.5f);
        if(deliveriesThisOver < 6 && !inningsComplete) {
            BowlDelivery();
        }
        yield return new WaitForSeconds(.5f);
        if(deliveriesThisOver < 6 && !inningsComplete) {
            BowlDelivery();
        }
        yield return new WaitForSeconds(.5f);
        if(deliveriesThisOver < 6 && !inningsComplete) {
            BowlDelivery();
        }
        yield return new WaitForSeconds(.5f);
        if(deliveriesThisOver < 6 && !inningsComplete) {
            BowlDelivery();
        }
        yield return new WaitForSeconds(.5f);
        if(deliveriesThisOver < 6 && !inningsComplete) {
            BowlDelivery();
        }
        yield return new WaitForSeconds(.5f);
        if(deliveriesThisOver < 6 && !inningsComplete) {
            BowlDelivery();
            clickAllowed = true;
            //Debug.Log("CLICKALLOWED IS " + clickAllowed);
        }
    }

    void BowlDelivery() {
        skipNotOut = false;
        //batter shot
        if(currentBatter == batter1) {
            batter1Tier = battingTeamTiers[batter1Position];
            switch(batter1Tier) {
                case 1:
                    int rand1 = Random.Range(0,tier1BatterOptions.Count);
                    currentBatterShot = tier1BatterOptions[rand1];
                    break;
                case 2:
                    int rand2 = Random.Range(0,tier2BatterOptions.Count);
                    currentBatterShot = tier2BatterOptions[rand2];
                    break;
                case 3:
                    int rand3 = Random.Range(0,tier3BatterOptions.Count);
                    currentBatterShot = tier3BatterOptions[rand3];
                    break;
                case 4:
                    int rand4 = Random.Range(0,tier4BatterOptions.Count);
                    currentBatterShot = tier4BatterOptions[rand4];
                    break;
                case 5:
                    int rand5 = Random.Range(0,tier5BatterOptions.Count);
                    currentBatterShot = tier5BatterOptions[rand5];
                    break;
            }
        }
        if(currentBatter == batter2) {
            batter2Tier = battingTeamTiers[batter2Position];
            switch(batter2Tier) {
                case 1:
                    int rand1 = Random.Range(0,tier1BatterOptions.Count);
                    currentBatterShot = tier1BatterOptions[rand1];
                    break;
                case 2:
                    int rand2 = Random.Range(0,tier2BatterOptions.Count);
                    currentBatterShot = tier2BatterOptions[rand2];
                    break;
                case 3:
                    int rand3 = Random.Range(0,tier3BatterOptions.Count);
                    currentBatterShot = tier3BatterOptions[rand3];
                    break;
                case 4:
                    int rand4 = Random.Range(0,tier4BatterOptions.Count);
                    currentBatterShot = tier4BatterOptions[rand4];
                    break;
                case 5:
                    int rand5 = Random.Range(0,tier5BatterOptions.Count);
                    currentBatterShot = tier5BatterOptions[rand5];
                    break;
            }
        }
        
        //bowler delivery
        switch(currentBowlerTier) {
            case 1:
                currentDelivery = Random.Range(0,tier1BowlerCap);
                break;
            case 2:
                currentDelivery = Random.Range(0,tier2BowlerCap);
                break;
            case 3:
                currentDelivery = Random.Range(0,tier3BowlerCap);
                break;
            case 4:
                currentDelivery = Random.Range(0,tier4BowlerCap);
                break;
            case 5:
                currentDelivery = Random.Range(0,tier5BowlerCap);
                break;
        }

        //see if bowler delivery == batter shot
        if(currentDelivery == currentBatterShot) {
            currentOverProgression[deliveriesThisOver] = "W";
            deliveriesThisOver++;
            if(currentBatter == batter1) {
                //Debug.Log("BATTER 1 OUT!");
                Debug.Log(totalOversBowled + "." + deliveriesThisOver + " : " + currentBowler + " to " + currentBatter + " - OUT!");
                //add a wicket
                totalWickets++;
                //wrap up info for batter who just got out
                battingTeamDeliveriesFacedInt[batter1Position]++;
                //ensure this batter can't come again
                battersAvailable[batter1Position] = false;
                //pick next batter in this position
                bool foundNextBatter = false;
                int rand2 = 0;
                while(!foundNextBatter && totalWickets < 10) {
                    if(battersAvailable[rand2] == true) {
                        battersAvailable[rand2] = false; //ensure this batter can't be picked again
                        batter1Position = rand2;
                        batter1 = teamBPlayerNames[rand2];
                        currentBatter = batter1;
                        foundNextBatter = true;
                    }
                    else {
                        rand2++;
                    }
                }
            }
            else if(currentBatter == batter2) {
                //Debug.Log("BATTER 2 OUT!");
                Debug.Log(totalOversBowled + "." + deliveriesThisOver + " : " + currentBowler + " to " + currentBatter + " - OUT!");
                //add a wicket
                totalWickets++;
                //wrap up info for batter who just got out
                battingTeamDeliveriesFacedInt[batter2Position]++;
                //pick next batter in this position
                bool foundNextBatter = false;
                int rand2 = 0;
                while(!foundNextBatter && totalWickets < 10) {
                    if(battersAvailable[rand2] == true) {
                        battersAvailable[rand2] = false; //ensure this batter can't be picked again
                        batter2Position = rand2;
                        batter2 = teamBPlayerNames[rand2];
                        currentBatter = batter2;
                        foundNextBatter = true;
                    }
                    else {
                        rand2++;
                    }
                }
            }
            //update bowler stats
            teamAWicketsTakenInt[currentBowlerPosition]++;
        }
         
        else {
            if(currentBatterShot != 0) {
                currentOverProgression[deliveriesThisOver] = currentBatterShot.ToString();
            }
            else if(currentBatterShot == 0) {
                currentOverProgression[deliveriesThisOver] = ".";
            }
            deliveriesThisOver++;
            if(currentBatter == batter1 && !skipNotOut) {
                Debug.Log(totalOversBowled + "." + deliveriesThisOver + " : " + currentBowler + " to " + currentBatter + " - " + currentBatterShot);
                //add to batter score
                battingTeamRunsInt[batter1Position] += currentBatterShot;
                //add to batter's deliveries faced
                battingTeamDeliveriesFacedInt[batter1Position]++;
                //add to team total
                battingTeamTotal += currentBatterShot;
                //if runs = 1 or 3, make sure batter2 is on strike
                if(currentBatterShot % 2 != 0) {
                    //rotate strike
                    currentBatter = batter2;
                    skipNotOut = true;
                }
            }
            if(currentBatter == batter2 && !skipNotOut) {
                Debug.Log(totalOversBowled + "." + deliveriesThisOver + " : " + currentBowler + " to " + currentBatter + " - " + currentBatterShot);
                //add to batter score
                battingTeamRunsInt[batter2Position] += currentBatterShot;
                //add to batter's deliveries faced
                battingTeamDeliveriesFacedInt[batter2Position]++;
                //add to team total
                battingTeamTotal += currentBatterShot;
                //if runs = 1 or 3, make sure batter1 is on strike
                if(currentBatterShot % 2 != 0) {
                    //rotate strike
                    currentBatter = batter1;
                    skipNotOut = true;
                }
            }
            //update bowler stats
            teamARunsGivenInt[currentBowlerPosition] += currentBatterShot;
        }
        
        //update all textboxes accordingly
        //if over complete, make that clear then switch batter on strike
        if(deliveriesThisOver == 6) {
            totalOversBowled++;
            overComplete = true;
            if(currentBatter == batter1) {
                currentBatter = batter2;
            }
            else if(currentBatter == batter2) {
                currentBatter = batter1;
            }
            //add an over for the bowler who just finished
            teamAOversBowledInt[currentBowlerPosition]++;
            if(teamAOversBowledInt[currentBowlerPosition] == maxOversPerBowler) {
                teamABowlerBowledOut[currentBowlerPosition] = true;
            }
            //reset bowler to available (not selected)
            teamABowlerPicked[currentBowlerPosition] = false;
            //reset other bowler to 'not just bowled'(lazy way of resetting!)
            teamABowlerJustBowled = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
            teamABowlerJustBowled[currentBowlerPosition] = true;
        }

        if(totalOversBowled == maxOvers || totalWickets == 10) {
            inningsComplete = true;
        }
        
        //update battingTeamTotal, wicketsLost, oversCompleted
        if(deliveriesThisOver < 6) {
            battingTeamTotalBox.GetComponent<Text>().text = battingTeamTotal.ToString() + " / " + totalWickets.ToString() + " in " + totalOversBowled.ToString() + "." + deliveriesThisOver.ToString() + " overs";
        }
        else if(deliveriesThisOver == 6) {
            battingTeamTotalBox.GetComponent<Text>().text = battingTeamTotal.ToString() + " / " + totalWickets.ToString() + " in " + totalOversBowled.ToString() + " overs";
        }
        
        //fill out all batting related info
        for(int i = 0; i < 11; i++) {
            if(teamBPlayerNames[i] == currentBatter) {
                teamBPlayers[i].GetComponent<Text>().text = "<b>" + teamBPlayerNames[i] + "</b>" + " *";
            }
            else if(teamBPlayerNames[i] == batter1) {
                teamBPlayers[i].GetComponent<Text>().text = "<b>" + teamBPlayerNames[i] + "</b>";
            }
            else if(teamBPlayerNames[i] == currentBatter) {
                teamBPlayers[i].GetComponent<Text>().text = "<b>" + teamBPlayerNames[i] + "</b>" + " *";
            }
            else if(teamBPlayerNames[i] == batter2) {
                teamBPlayers[i].GetComponent<Text>().text = "<b>" + teamBPlayerNames[i] + "</b>";
            }
            else {
                teamBPlayers[i].GetComponent<Text>().text = teamBPlayerNames[i];
            }
        }
        
        for(int i = 0; i < 11; i++) {
            if(teamBPlayerNames[i] == batter1 || teamBPlayerNames[i] == batter2) {
                teamBRuns[i].GetComponent<Text>().text = "<b>" + battingTeamRunsInt[i].ToString() + "</b>";
                teamBBalls[i].GetComponent<Text>().text = "<b>" + battingTeamDeliveriesFacedInt[i].ToString() + "</b>";
            }
            else {
                teamBRuns[i].GetComponent<Text>().text = battingTeamRunsInt[i].ToString();
                teamBBalls[i].GetComponent<Text>().text = battingTeamDeliveriesFacedInt[i].ToString();
            }
        }
        
        //fill out all bowling related info
        for(int i = 0; i < 11; i++) {
            //update runs given
            teamARunsGiven[10 - i].GetComponent<Text>().text = teamARunsGivenInt[i].ToString();
            //update wickets taken
            teamAWicketsTaken[10 - i].GetComponent<Text>().text = teamAWicketsTakenInt[i].ToString();
            //update overs bowled
            if(deliveriesThisOver < 6 && i == currentBowlerPosition) {
                teamAOversBowled[10 - i].GetComponent<Text>().text = teamAOversBowledInt[i].ToString() + "." + deliveriesThisOver.ToString();
            }
            else if(deliveriesThisOver == 6 && i == currentBowlerPosition) {
                teamAOversBowled[10 - i].GetComponent<Text>().text = teamAOversBowledInt[i].ToString() + ".0";
            }
        }
        
        if(deliveriesThisOver == 1) {
            overProgressionBox.GetComponent<Text>().text = currentOverProgression[0];
        }
        if(deliveriesThisOver == 2) {
            overProgressionBox.GetComponent<Text>().text = currentOverProgression[0] + " " + currentOverProgression[1];
        }
        if(deliveriesThisOver == 3) {
            overProgressionBox.GetComponent<Text>().text = currentOverProgression[0] + " " + currentOverProgression[1] + " " + currentOverProgression[2];
        }
        if(deliveriesThisOver == 4) {
            overProgressionBox.GetComponent<Text>().text = currentOverProgression[0] + " " + currentOverProgression[1] + " " + currentOverProgression[2] + " " + currentOverProgression[3];
        }
        if(deliveriesThisOver == 5) {
            overProgressionBox.GetComponent<Text>().text = currentOverProgression[0] + " " + currentOverProgression[1] + " " + currentOverProgression[2] + " " + currentOverProgression[3] + " " + currentOverProgression[4];
        }
        if(deliveriesThisOver == 6) {
            overProgressionBox.GetComponent<Text>().text = currentOverProgression[0] + " " + currentOverProgression[1] + " " + currentOverProgression[2] + " " + currentOverProgression[3] + " " + currentOverProgression[4] + " " + currentOverProgression[5];
        }
    }
}
