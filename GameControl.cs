// Roan Silver      Created: ~September        Last Edits: December 19, 2023
// Major Collaborator: Alexander Zotov on YouTube
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private static GameObject WhoWinsText, Player1MoveText, Player2MoveText, Player1WinsText, Player2WinsText;

	//Added public instead of private
    public static GameObject player1, player2;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
		Player1WinsText = GameObject.Find("Player1WinsText"); //here
		Player2WinsText = GameObject.Find("Player2WinsText"); //here
        WhoWinsText = GameObject.Find("WhoWinsText");
        Player1MoveText = GameObject.Find("Player1MoveText");
        Player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

		Player1WinsText.gameObject.SetActive(false); //here
		Player2WinsText.gameObject.SetActive(false); //here
        WhoWinsText.gameObject.SetActive(false);
        Player1MoveText.gameObject.SetActive(true);
        Player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex > player1StartWaypoint + diceSideThrown)
			{
				player1.GetComponent<FollowThePath>().moveAllowed = false;
				Player1MoveText.gameObject.SetActive(false);
				Player2MoveText.gameObject.SetActive(true);

				if (Dice.wpIndex == 11){
					SceneController.instance.nextBoss();
				}

				player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
			}

		if ((player2.GetComponent<FollowThePath>().waypointIndex) > (player2StartWaypoint + diceSideThrown))
		{
			player2.GetComponent<FollowThePath>().moveAllowed = false;
			Player2MoveText.gameObject.SetActive(false);
			Player1MoveText.gameObject.SetActive(true);
			player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
		}

		if (player1.GetComponent<FollowThePath>().waypointIndex == player1.GetComponent<FollowThePath>().waypoints.Length)
			{
				WhoWinsText.gameObject.SetActive(true);
				Player1MoveText.gameObject.SetActive(false);
				Player2MoveText.gameObject.SetActive(false);
				Player1WinsText.gameObject.SetActive(true); //here
				WhoWinsText.GetComponent<Text>().text = "Player 1 Wins";
				gameOver = true; //here
			}
		if (player2.GetComponent<FollowThePath>().waypointIndex == player2.GetComponent<FollowThePath>().waypoints.Length)
			{
				WhoWinsText.gameObject.SetActive(true);
				Player1MoveText.gameObject.SetActive(false);
				Player2MoveText.gameObject.SetActive(false);
				Player2WinsText.gameObject.SetActive(true); //here
				WhoWinsText.GetComponent<Text>().text = "Player 2 Wins";
				gameOver = true;
			}
    }

	public static void MovePlayer(int playerToMove)
	{
		switch(playerToMove) {
			case 1:
				player1.GetComponent<FollowThePath>().moveAllowed = true;
				break;


			case 2:
				player2.GetComponent<FollowThePath>().moveAllowed = true;
				break;
		}
	}
}
