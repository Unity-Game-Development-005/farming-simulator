
using UnityEngine;
using UnityEngine.UI;


public class PlayButton : MonoBehaviour
{
    // reference to play button
    private Button playButton;



    private void Start()
    {
        // set reference to the play button
        playButton = GetComponent<Button>();

        // listen for a button click
        playButton.onClick.AddListener(StartGame);
    }


    private void StartGame()
    {
        // start the game
        GameController.gameController.StartGame();
    }



} // end of class
