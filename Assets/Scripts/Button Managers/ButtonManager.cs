using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    //Team A Chosen
    //teamB chasing; teamA chosen
    public void Bowler0Picked() {
        if(SecondInningsManager.clickAllowed) {
            SecondInningsManager.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        SecondInningsManager.teamABowlerPicked[10] = true;
        SecondInningsManager.bowlerPicked = true;
        }
    }

    public void Bowler1Picked() {
        if(SecondInningsManager.clickAllowed) {
            SecondInningsManager.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        SecondInningsManager.teamABowlerPicked[9] = true;
        SecondInningsManager.bowlerPicked = true;
        }
    }

    public void Bowler2Picked() {
        if(SecondInningsManager.clickAllowed) {

        
        SecondInningsManager.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        SecondInningsManager.teamABowlerPicked[8] = true;
        SecondInningsManager.bowlerPicked = true;
        }
    }

    public void Bowler3Picked() {
        if(SecondInningsManager.clickAllowed) {

        
        SecondInningsManager.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        SecondInningsManager.teamABowlerPicked[7] = true;
        SecondInningsManager.bowlerPicked = true;
        }
    }

    public void Bowler4Picked() {
        if(SecondInningsManager.clickAllowed) {

        
        SecondInningsManager.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        SecondInningsManager.teamABowlerPicked[6] = true;
        SecondInningsManager.bowlerPicked = true;
        }
    }

    public void Bowler5Picked() {
        if(SecondInningsManager.clickAllowed) {

        
        SecondInningsManager.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        SecondInningsManager.teamABowlerPicked[5] = true;
        SecondInningsManager.bowlerPicked = true;
        }
    }

    public void Bowler6Picked() {
        if(SecondInningsManager.clickAllowed) {

        
        SecondInningsManager.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        SecondInningsManager.teamABowlerPicked[4] = true;
        SecondInningsManager.bowlerPicked = true;
        }
    }

    public void Bowler7Picked() {
        if(SecondInningsManager.clickAllowed) {

       
        SecondInningsManager.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        SecondInningsManager.teamABowlerPicked[3] = true;
        SecondInningsManager.bowlerPicked = true;
         }
    }

    public void Bowler8Picked() {
        if(SecondInningsManager.clickAllowed) {

        
        SecondInningsManager.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        SecondInningsManager.teamABowlerPicked[2] = true;
        SecondInningsManager.bowlerPicked = true;
        }
    }

    public void Bowler9Picked() {
        if(SecondInningsManager.clickAllowed) {

        
        SecondInningsManager.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        SecondInningsManager.teamABowlerPicked[1] = true;
        SecondInningsManager.bowlerPicked = true;
        }
    }

    public void Bowler10Picked() {
        if(SecondInningsManager.clickAllowed) {

        
        SecondInningsManager.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        SecondInningsManager.teamABowlerPicked[0] = true;
        SecondInningsManager.bowlerPicked = true;
        }
    }

    //teamB batting first; teamA chosen

    public void Bowler0PickedB() {
        //Debug.Log("PRESSED?!");
        if(FirstInningsManagerB.clickAllowed == true) {
            //Debug.Log("PRESSED?! AGAIN");
            FirstInningsManagerB.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
            FirstInningsManagerB.teamABowlerPicked[10] = true;
            FirstInningsManagerB.bowlerPicked = true;
        }
    }

    public void Bowler1PickedB() {
        if(FirstInningsManagerB.clickAllowed) {

        
        FirstInningsManagerB.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        FirstInningsManagerB.teamABowlerPicked[9] = true;
        FirstInningsManagerB.bowlerPicked = true;
        }
    }

    public void Bowler2PickedB() {
        if(FirstInningsManagerB.clickAllowed) {

        
        FirstInningsManagerB.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        FirstInningsManagerB.teamABowlerPicked[8] = true;
        FirstInningsManagerB.bowlerPicked = true;
        }
    }

    public void Bowler3PickedB() {
        if(FirstInningsManagerB.clickAllowed) {

        
        FirstInningsManagerB.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        FirstInningsManagerB.teamABowlerPicked[7] = true;
        FirstInningsManagerB.bowlerPicked = true;
        }
    }

    public void Bowler4PickedB() {
        if(FirstInningsManagerB.clickAllowed) {

        
        FirstInningsManagerB.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        FirstInningsManagerB.teamABowlerPicked[6] = true;
        FirstInningsManagerB.bowlerPicked = true;
        }
    }

    public void Bowler5PickedB() {
        if(FirstInningsManagerB.clickAllowed) {

        
        FirstInningsManagerB.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        FirstInningsManagerB.teamABowlerPicked[5] = true;
        FirstInningsManagerB.bowlerPicked = true;
        }
    }

    public void Bowler6PickedB() {
        if(FirstInningsManagerB.clickAllowed) {

        
        FirstInningsManagerB.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        FirstInningsManagerB.teamABowlerPicked[4] = true;
        FirstInningsManagerB.bowlerPicked = true;
        }
    }

    public void Bowler7PickedB() {
        if(FirstInningsManagerB.clickAllowed) {

        
        FirstInningsManagerB.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        FirstInningsManagerB.teamABowlerPicked[3] = true;
        FirstInningsManagerB.bowlerPicked = true;
        }
    }

    public void Bowler8PickedB() {
        if(FirstInningsManagerB.clickAllowed) {

        
        FirstInningsManagerB.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        FirstInningsManagerB.teamABowlerPicked[2] = true;
        FirstInningsManagerB.bowlerPicked = true;
        }
    }

    public void Bowler9PickedB() {
        if(FirstInningsManagerB.clickAllowed) {

        
        FirstInningsManagerB.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        FirstInningsManagerB.teamABowlerPicked[1] = true;
        FirstInningsManagerB.bowlerPicked = true;
        }
    }

    public void Bowler10PickedB() {
        if(FirstInningsManagerB.clickAllowed) {

        
        FirstInningsManagerB.teamABowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        FirstInningsManagerB.teamABowlerPicked[0] = true;
        FirstInningsManagerB.bowlerPicked = true;
        }
    }

    //Team B Chosen
    //teamA chasing; teamB chosen
    public void Bowler0PickedTeamBBattingFirstTeamBChosen() {
        //Debug.Log("PRESSED?!");
        if(TeamAChasingTeamBChosen.clickAllowed == true) {
            //Debug.Log("PRESSED?! AGAIN");
            TeamAChasingTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
            TeamAChasingTeamBChosen.bowlingTeamBowlerPicked[10] = true;
            TeamAChasingTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler1PickedTeamBBattingFirstTeamBChosen() {
        if(TeamAChasingTeamBChosen.clickAllowed) {

        
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked[9] = true;
        TeamAChasingTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler2PickedTeamBBattingFirstTeamBChosen() {
        if(TeamAChasingTeamBChosen.clickAllowed) {

        
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked[8] = true;
        TeamAChasingTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler3PickedTeamBBattingFirstTeamBChosen() {
        if(TeamAChasingTeamBChosen.clickAllowed) {

        
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked[7] = true;
        TeamAChasingTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler4PickedTeamBBattingFirstTeamBChosen() {
        if(TeamAChasingTeamBChosen.clickAllowed) {

        
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked[6] = true;
        TeamAChasingTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler5PickedTeamBBattingFirstTeamBChosen() {
        if(TeamAChasingTeamBChosen.clickAllowed) {

        
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked[5] = true;
        TeamAChasingTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler6PickedTeamBBattingFirstTeamBChosen() {
        if(TeamAChasingTeamBChosen.clickAllowed) {

        
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked[4] = true;
        TeamAChasingTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler7PickedTeamBBattingFirstTeamBChosen() {
        if(TeamAChasingTeamBChosen.clickAllowed) {

        
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked[3] = true;
        TeamAChasingTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler8PickedTeamBBattingFirstTeamBChosen() {
        if(TeamAChasingTeamBChosen.clickAllowed) {

        
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked[2] = true;
        TeamAChasingTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler9PickedTeamBBattingFirstTeamBChosen() {
        if(TeamAChasingTeamBChosen.clickAllowed) {

        
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked[1] = true;
        TeamAChasingTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler10PickedTeamBBattingFirstTeamBChosen() {
        if(TeamAChasingTeamBChosen.clickAllowed) {

        
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamAChasingTeamBChosen.bowlingTeamBowlerPicked[0] = true;
        TeamAChasingTeamBChosen.bowlerPicked = true;
        }
    }

    //teamA batting first; teamB chosen
    public void Bowler0PickedTeamABattingFirstTeamBChosen() {
        //Debug.Log("PRESSED?!");
        if(TeamABatsFirstTeamBChosen.clickAllowed == true) {
            //Debug.Log("PRESSED?! AGAIN");
            TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
            TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked[10] = true;
            TeamABatsFirstTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler1PickedTeamABattingFirstTeamBChosen() {
        if(TeamABatsFirstTeamBChosen.clickAllowed) {

        
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked[9] = true;
        TeamABatsFirstTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler2PickedTeamABattingFirstTeamBChosen() {
        if(TeamABatsFirstTeamBChosen.clickAllowed) {

        
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked[8] = true;
        TeamABatsFirstTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler3PickedTeamABattingFirstTeamBChosen() {
        if(TeamABatsFirstTeamBChosen.clickAllowed) {

        
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked[7] = true;
        TeamABatsFirstTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler4PickedTeamABattingFirstTeamBChosen() {
        if(TeamABatsFirstTeamBChosen.clickAllowed) {

        
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked[6] = true;
        TeamABatsFirstTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler5PickedTeamABattingFirstTeamBChosen() {
        if(TeamABatsFirstTeamBChosen.clickAllowed) {

        
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked[5] = true;
        TeamABatsFirstTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler6PickedTeamABattingFirstTeamBChosen() {
        if(TeamABatsFirstTeamBChosen.clickAllowed) {

        
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked[4] = true;
        TeamABatsFirstTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler7PickedTeamABattingFirstTeamBChosen() {
        if(TeamABatsFirstTeamBChosen.clickAllowed) {

        
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked[3] = true;
        TeamABatsFirstTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler8PickedTeamABattingFirstTeamBChosen() {
        if(TeamABatsFirstTeamBChosen.clickAllowed) {

        
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked[2] = true;
        TeamABatsFirstTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler9PickedTeamABattingFirstTeamBChosen() {
        if(TeamABatsFirstTeamBChosen.clickAllowed) {

        
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked[1] = true;
        TeamABatsFirstTeamBChosen.bowlerPicked = true;
        }
    }

    public void Bowler10PickedTeamABattingFirstTeamBChosen() {
        if(TeamABatsFirstTeamBChosen.clickAllowed) {

        
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked = new List<bool>() {false,false,false,false,false,false,false,false,false,false,false};
        TeamABatsFirstTeamBChosen.bowlingTeamBowlerPicked[0] = true;
        TeamABatsFirstTeamBChosen.bowlerPicked = true;
        }
    }

}
