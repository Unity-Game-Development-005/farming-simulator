
using UnityEngine;
using TMPro;


public class UIController : MonoBehaviour
{
    // enable script to be accessible from other scripts
    public static UIController uiController;


    // ui text
    public TMP_Text timerText;

    public TMP_Text timerValueText;

    public TMP_Text scoreText;

    public TMP_Text scoreValueText;

    public TMP_Text gameOverText;

    public TMP_Text noCropsText;



    private void Awake()
    {
        uiController = this;
    }


} // end of class
