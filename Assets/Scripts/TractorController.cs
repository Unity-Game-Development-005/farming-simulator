
using System.Security.Cryptography;
using UnityEngine;

using UnityEngine.AI;


public class TractorController : MonoBehaviour
{
    // reference to the main camera
    [SerializeField] private Camera mainCamera;

    // reference to the tractor's nav mesh agent
    private NavMeshAgent tractorNavMeshAgent;

    // reference to crop object
    public GameObject cropObject;

    // number of left mouse clicks
    private int leftMouseClicks = 0;

    // if the player has moved to a new position
    private int hasMoved = 1;

    // planting distance of the selected location
    private int withinPlantingDistance = 1;

    // whether the player can plant crops
    public bool canPlantCrop;




    void Start()
    {
        // set the reference to the nav mesh agent
        tractorNavMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // get player input
        GetPlayerInput();

        // plant some crops
        PlantCrop();
    }


    private void GetPlayerInput()
    {
        // if the game is in play
        if (GameController.gameController.gameIsActive)
        {
            // and the player press the left mouse button {tractor)
            if (Input.GetMouseButtonDown(0))
            {
                // increment the left mouse click count
                leftMouseClicks++;

                // if the player has moved
                if (leftMouseClicks >= hasMoved)
                {
                    // set the 'can plant crop' flag
                    canPlantCrop = true;
                }

                // get the screen position of where the button is pressed
                Ray rayCast = mainCamera.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayCastHit;

                // get the tractor's destination
                if (Physics.Raycast(rayCast, out rayCastHit))
                {
                    // and move tractor
                    MoveTractor(rayCastHit.point);
                }
            }
        }
    }


    private void MoveTractor(Vector3 newDestination)
    {
        // move the tractor to the selected planting location
        tractorNavMeshAgent.SetDestination(newDestination);
    }


    private void PlantCrop()
    {
        // if the player has moved
        if (leftMouseClicks >= hasMoved)
        {
            // and the player can plant crops
            if (canPlantCrop)
            {
                // and if the player is within planting distance of the selected location
                if (!tractorNavMeshAgent.pathPending && tractorNavMeshAgent.remainingDistance <= withinPlantingDistance)
                {
                    // then plant a crop
                    Instantiate(cropObject, transform.position, transform.rotation);

                    // crop planted, so set flag false
                    canPlantCrop = false;
                }
            }
        }
    }


} // end of class
