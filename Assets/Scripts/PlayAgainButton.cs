
using UnityEngine;
using UnityEngine.UI;


public class PlayAgainButton : MonoBehaviour
{
    // reference to play button
    private Button playAgainButton;



    private void Start()
    {
        // set reference to the play button
        playAgainButton = GetComponent<Button>();

        // listen for a button click
        playAgainButton.onClick.AddListener(StartGame);
    }


    private void StartGame()
    {
        // start the game
        GameController.gameController.RestartGame();
    }



} // end of class
