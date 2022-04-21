using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControls : MonoBehaviour
{
    public static int Player1Lives = 3;
    public static int Player2Lives = 3;
    public GUISkin layout;
    public GameObject blueBall;
    public GameObject redBall;
    public GameObject bluePlayer;
    public GameObject redPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI() {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width /2 - 150 - 12, 20 , 100 ,100), "" + Player1Lives);
        GUI.Label(new Rect(Screen.width /2 + 150 + 12, 20 , 100 ,100), "" + Player2Lives);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            Player1Lives = 3;
            Player2Lives = 3;
            blueBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            redBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (Player1Lives == 0) {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200,2000, 1000), "PLAYER TWO WIN!");
            blueBall.SendMessage("ResetBall",null,SendMessageOptions.RequireReceiver);
            redBall.SendMessage("ResetBall",null,SendMessageOptions.RequireReceiver);
            
        } else if (Player2Lives == 0) {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200,2000, 1000), "PLAYER ONE WIN!");
            blueBall.SendMessage("ResetBall",null,SendMessageOptions.RequireReceiver);
            redBall.SendMessage("ResetBall",null,SendMessageOptions.RequireReceiver);
            
        } 
    }

    public static void Score(string playerID) {
        if (playerID == "Player_blue") {
            Player1Lives--;
        } else if (playerID == "Player_red") {
            Player2Lives--;
        } 
    }

    public void Restart() {
        blueBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        redBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
    }

    public void RespawnPlayer(string playerID) {
         if (playerID == "Player_blue") {
            bluePlayer.SetActive(false);
            Invoke("showBluePlayer", 2);
        } else if (playerID == "Player_red") {
            redPlayer.SetActive(false);
            Invoke("showRedPlayer", 2);
        } 
    }

    void showBluePlayer() {
        bluePlayer.SetActive(true);
    }

    void showRedPlayer() {
        redPlayer.SetActive(true);
    }

}
