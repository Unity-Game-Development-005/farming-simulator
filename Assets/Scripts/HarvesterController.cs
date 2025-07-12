
using TMPro;
using UnityEngine;

using UnityEngine.AI;


public class HarvesterController : MonoBehaviour
{
    // reference to the harvester's nav mesh agent
    private NavMeshAgent harvesterNavMeshAgent;

    // reference to the crop transform
    private Transform cropTransform;

    // calculates the direction to move the harvester
    private Vector3 targetDestination;




    void Start()
    {
        // set the reference to the nav mesh agent
        harvesterNavMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        SearchForCrops();
    }


    private void SearchForCrops()
    {
        // if the game is in play
        if (GameController.gameController.gameIsActive)
        {
            // if the player presses the right mouse button
            if (Input.GetMouseButtonDown(1))
            {
                // and there is a crop object to find
                if (GameObject.FindGameObjectWithTag("Crop") != null)
                {
                    // hid the no crops message
                    UIController.uiController.noCropsText.gameObject.SetActive(false);

                    // get the position of the crop object
                    Vector3 targetPosition = GameObject.FindGameObjectWithTag("Crop").transform.position;

                    // and move the harvester to the crop's position
                    harvesterNavMeshAgent.destination = targetPosition;
                }

                // otherwise
                else
                {
                    // inform the player there are no crops to harvest
                    UIController.uiController.noCropsText.gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the harvester collides with the crop object
        if (other.CompareTag("Crop"))
        {
            // destroy the crop object
            Destroy(other.gameObject);

            // and increase the player's score
            GameController.gameController.CollectCabbages(GameController.gameController.cabbagePoints);
        }
    }


} // end of class
