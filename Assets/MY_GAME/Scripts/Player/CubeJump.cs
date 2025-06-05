using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeJump : MonoBehaviour
{
    public GameObject hatObject;
    public ParticleSystem particleSystemHat;
    public ParticleSystem particleSystemSkuns;

    public GameObject[] objectsHats;
    private int currentIndex = -1;


    public Transform childToRotateBottle;
    public float rotationSpeedBottle = 1.0f;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private Vector3 rotationAxis;
    private float rotationAmount;
    public float rotationProgress = 0f;
    public bool isUp = true;
    private RandomCube _randomCube;
    private bool isFallingTriggered = false;
    private float lastYPosition;
    private int previousYPosition;
    private StartMenu startMenu;
    public bool canMove = true;
    public PlayerDeath playerDeath;
    private SoundManager soundManager;
    private Vector3 targetPosition;
    public float moveSpeed = 5.0f;
    private Animator animator;
    public Animator animatorHat;
    private float timeSinceLastCube = 0f;
    public float rotationSpeed = 5.0f;
    private bool shouldRotate = false;
    private Vector3 desiredRotation = Vector3.zero;
    public Transform childToRotate;
    public float fallSpeed = 23.0f;
    public bool isFalling;
    public bool isMove = true;

    public Transform rayPositionDown;
    public Transform rayPositionRight;
    public Transform rayPositionLeft;
    public Transform rayPositionForward;
    public Transform rayPositionBack;

    public LayerMask layerToInclude;
    private int layerMask;


    public bool canJumpMidR = false;
    public bool canJumpMidL = false;
    public bool canJumpMidF = false;
    public bool canJumpMidB = false;


    public bool gameStarted = false;
    public static bool isShop = false;
    private bool isBottleWater = false;
    private bool isHat = false;
    private bool isSkuns = false;
    private PauseMenu pauseMenu;
    public bool canPlay = true;

    void Start()
    {
        Physics.autoSimulation = false;

        Physics.Simulate(Time.fixedDeltaTime);

        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit);

        Physics.autoSimulation = true;

        targetRotation = childToRotate.rotation;

        if (gameObject.name == "Default(Clone)")
        {
            isBottleWater = true;
        }
        else
        {
            isBottleWater = false;
        }


        if (gameObject.name == "Case1_Y1(Clone)")
        {
            isHat = true;
        }
        else
        {
            isHat = false;
        }

        if (gameObject.name == "Case1_R1_(Clone)")
        {
            isSkuns = true;
        }
        else
        {
            isSkuns = false;
        }


        isShop = false;
        StartCoroutine(WaitGameStart());
        pauseMenu = GameObject.Find("PauseMenu").GetComponent<PauseMenu>();
        startMenu = GameObject.Find("StartGame").GetComponent<StartMenu>();
        _randomCube = GameObject.Find("GenerateRandomCube").GetComponent<RandomCube>();
        playerDeath = GetComponent<PlayerDeath>();

        lastYPosition = transform.position.y;
        previousYPosition = Mathf.RoundToInt(transform.position.y);


        layerMask = 1 << layerToInclude;

        layerMask = ~layerMask;


        targetPosition = transform.position;
        animator = GetComponent<Animator>();

        soundManager = GetComponent<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("thornsTrap"))
        {
            playerDeath.Die();
            StartCoroutine(DelayedPauseMenuActivation());
        }
    }

    IEnumerator DelayedPauseMenuActivation()
    {
        yield return new WaitForSeconds(1f);
        pauseMenu.ActivePauseMenu();
    }


    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public IEnumerator DelayedRestartScene()
    {
        yield return new WaitForSeconds(1.0f);
        RestartScene();
    }

    private IEnumerator EffectDead()
    {
        yield return new WaitForSeconds(0.3f);
        playerDeath.Die();
    }


    private IEnumerator WaitGameStart()
    {
        yield return new WaitForSeconds(0.6f);
        isMove = true;
    }


    void SetNewTargetRotation()
    {
        if (isRotating)
        {
            childToRotate.rotation = Quaternion.Slerp(childToRotate.rotation, targetRotation, rotationProgress);

            if (!Mathf.Approximately(childToRotate.rotation.eulerAngles.x, 180f) && isUp == true)
            {
                isUp = false;
                childToRotate.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (!Mathf.Approximately(childToRotate.rotation.eulerAngles.x, 0f) && isUp == false)
            {
                childToRotate.rotation = Quaternion.Euler(180f, 0f, 0f);
                isUp = true;
            }
        }

        rotationProgress = 0f;
        targetRotation = Quaternion.AngleAxis(rotationAmount, rotationAxis) * childToRotate.rotation;
        isRotating = true;
    }



    void Update()
    {
        if (isRotating)
        {
            rotationProgress += rotationSpeedBottle * Time.deltaTime;

            if (rotationProgress >= 1f)
            {
                rotationProgress = 1f;
                isRotating = false;
            }

            childToRotate.rotation = Quaternion.Slerp(childToRotate.rotation, targetRotation, rotationProgress);
        }


        //SCORE////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        int currentYPosition = Mathf.RoundToInt(transform.position.y);
        int deltaY = currentYPosition - previousYPosition;

        if (deltaY != 0)
        {
            ScoreManager.score += deltaY;
        }

        previousYPosition = currentYPosition;
        ///////////////////////////////////////////////


        if (isFalling && !isFallingTriggered)
        {
            isFallingTriggered = true;
            StartCoroutine(EffectDead());
            StartCoroutine(DelayedPauseMenuActivation());
        }





        bool newIsOnCube = IsOnCube();

        canJumpMidR = !Physics.Raycast(rayPositionRight.position, Vector3.right, 2.0f, ~(1 << LayerMask.NameToLayer("ignoreRayCast")));
        canJumpMidL = !Physics.Raycast(rayPositionLeft.position, Vector3.left, 2.0f, ~(1 << LayerMask.NameToLayer("ignoreRayCast")));
        canJumpMidF = !Physics.Raycast(rayPositionForward.position, Vector3.forward, 2.0f, ~(1 << LayerMask.NameToLayer("ignoreRayCast")));
        canJumpMidB = !Physics.Raycast(rayPositionBack.position, Vector3.back, 2.0f, ~(1 << LayerMask.NameToLayer("ignoreRayCast")));


        Debug.DrawRay(rayPositionDown.position, Vector3.down * 1.0f, Color.red);
        Debug.DrawRay(rayPositionRight.position, Vector3.right * 2.0f, Color.red);
        Debug.DrawRay(rayPositionLeft.position, Vector3.left * 2.0f, Color.red);
        Debug.DrawRay(rayPositionForward.position, Vector3.forward * 2.0f, Color.red);
        Debug.DrawRay(rayPositionBack.position, Vector3.back * 2.0f, Color.red);

        //AWSD/////////////////////////////
        if (isMove == true && canPlay == true)
        {

            if (newIsOnCube && canMove)
            {
                timeSinceLastCube = 0f;


                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (gameStarted == false)
                    {
                        startMenu.StartGame();
                        gameStarted = true;
                    }

                    _randomCube.CreateRandomCube();

                    if (canJumpMidL == true)
                    {
                        targetPosition += new Vector3(-2.0f, 0, 0);
                    }
                    else
                    {
                        targetPosition += new Vector3(-2.0f, 1.0f, 0);
                    }



                    shouldRotate = true;


                    if (isBottleWater == true)
                    {
                        rotationAxis = Vector3.forward;
                        rotationAmount = -180f;
                        SetNewTargetRotation();

                    }
                    else
                    {
                        desiredRotation = new Vector3(0, -90, 0);
                    }
                    if (isBottleWater == false)
                    {
                        animator.SetTrigger("Jump");
                    }


                    if (isHat == true)
                    {
                        StartCoroutine(ToggleActive());
                    }

                    if (isSkuns == true)
                    {
                        ToggleActiveSkuns();
                    }

                }

                else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (gameStarted == false)
                    {
                        startMenu.StartGame();
                        gameStarted = true;
                    }



                    _randomCube.CreateRandomCube();
                    if (canJumpMidR == true)
                    {
                        targetPosition += new Vector3(2.0f, 0, 0);
                    }
                    else
                    {
                        targetPosition += new Vector3(2.0f, 1.0f, 0);
                    }




                    shouldRotate = true;


                    if (isBottleWater == true)
                    {
                        rotationAxis = Vector3.forward;
                        rotationAmount = 180f;
                        SetNewTargetRotation();

                    }
                    else
                    {
                        desiredRotation = new Vector3(0, 90, 0);
                    }
                    if (isBottleWater == false)
                    {
                        animator.SetTrigger("Jump");
                    }



                    if (isHat == true)
                    {
                        StartCoroutine(ToggleActive());
                    }
                    if (isSkuns == true)
                    {
                        ToggleActiveSkuns();
                    }

                }

                else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    _randomCube.CreateRandomCube();
                    if (gameStarted == false)
                    {
                        startMenu.StartGame();
                        gameStarted = true;
                    }



                    if (canJumpMidB == true)
                    {
                        targetPosition += new Vector3(0, 0, -2.0f);
                    }
                    else
                    {
                        targetPosition += new Vector3(0, 1.0f, -2.0f);
                    }
                    shouldRotate = true;




                    if (isBottleWater == true)
                    {
                        rotationAxis = Vector3.right;
                        rotationAmount = 180f;
                        SetNewTargetRotation();

                    }
                    else
                    {
                        desiredRotation = new Vector3(0, 180, 0);
                    }


                    if (isBottleWater == false)
                    {
                        animator.SetTrigger("Jump");
                    }



                    if (isHat == true)
                    {
                        StartCoroutine(ToggleActive());
                    }
                    if (isSkuns == true)
                    {
                        ToggleActiveSkuns();
                    }

                }


                // Перемещение вперед
                else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {

                    _randomCube.CreateRandomCube();

                    if (gameStarted == false)
                    {
                        startMenu.StartGame();
                        gameStarted = true;
                    }



                    if (canJumpMidF == true)
                    {
                        targetPosition += new Vector3(0, 0, 2.0f);
                    }
                    else
                    {
                        targetPosition += new Vector3(0, 1.0f, 2.0f);
                    }

                    shouldRotate = true;


                    if (isBottleWater == true)
                    {
                        rotationAxis = Vector3.right;
                        rotationAmount = -180f;
                        SetNewTargetRotation();
                    }
                    else
                    {
                        desiredRotation = new Vector3(0, 0, 0);
                    }

                    if (isBottleWater == false)
                    {
                        animator.SetTrigger("Jump");
                    }

                    if (isHat == true)
                    {
                        StartCoroutine(ToggleActive());
                    }



                    if (isSkuns == true)
                    {
                        ToggleActiveSkuns();
                    }



                }

            }
        }


        if (isMove == true)
        {
            if (newIsOnCube && canMove)
            {
                timeSinceLastCube = 0f;
            }
            else
            {
                timeSinceLastCube += Time.deltaTime;


                if (timeSinceLastCube >= 0.1f && playerDeath.isDead == false)
                {
                    Fall();
                }
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }



        if (isBottleWater == false)
        {
            childToRotate.localRotation = Quaternion.Slerp(childToRotate.localRotation,
                Quaternion.Euler(desiredRotation), Time.deltaTime * rotationSpeed);
        }
    }

    public void Fall()
    {
        targetPosition += new Vector3(0, -fallSpeed * Time.deltaTime, 0);
        isFalling = true;
    }


    bool IsOnCube()
    {
        int ignoreRaycastLayer = 1 << LayerMask.NameToLayer("ignoreRayCast");

        bool hitDown = Physics.Raycast(rayPositionDown.position, Vector3.down, out RaycastHit hitDownResult, 1.0f);

        bool hitRight = Physics.Raycast(rayPositionRight.position, Vector3.right, out RaycastHit hitRightResult, 2.0f);
        bool hitLeft = Physics.Raycast(rayPositionLeft.position, Vector3.left, out RaycastHit hitLeftResult, 2.0f);
        bool hitForward = Physics.Raycast(rayPositionForward.position, Vector3.forward, out RaycastHit hitForwardResult, 2.0f, ~ignoreRaycastLayer);
        bool hitBack = Physics.Raycast(rayPositionBack.position, Vector3.back, out RaycastHit hitBackResult, 2.0f, ~ignoreRaycastLayer);

        // F
        if (hitForward && hitForwardResult.collider.CompareTag("Cube"))
        {
            canJumpMidF = true;
            // canJumpDownR = true;
            // canJumpDownL = true;
        }

        // B
        if (hitBack && hitBackResult.collider.CompareTag("Cube"))
        {
            canJumpMidB = true;
            // canJumpDownR = true;
            // canJumpDownL = false;
        }

        // D
        if (hitDown && hitDownResult.collider.CompareTag("Cube"))
        {
            canJumpMidR = false;
            canJumpMidL = false;
            return true;
        }

        // R
        if (hitRight && hitRightResult.collider.CompareTag("Cube"))
        {
            canJumpMidR = false;
        }
        else
        {
            canJumpMidR = false;
        }

        // L
        if (hitLeft && hitLeftResult.collider.CompareTag("Cube"))
        {
            canJumpMidL = false;
        }
        else
        {
            canJumpMidL = false;
        }

        // if (!hitDown && !hitRight && !hitLeft)
        // {
        //     canJumpDownR = true;
        //     canJumpDownL = true;
        // }

        return false;
    }


    private IEnumerator ToggleActive()
    {
        hatObject.SetActive(false);
        ActivateRandomObject();
        yield return new WaitForSeconds(0.3f);
        particleSystemHat.Play();
        hatObject.SetActive(true);
    }
    private void ToggleActiveSkuns()
    {
        particleSystemSkuns.Play();
    }

    void ActivateRandomObject()
    {
        foreach (GameObject obj in objectsHats)
        {
            obj.SetActive(false);
        }

        currentIndex = Random.Range(0, objectsHats.Length);
        objectsHats[currentIndex].SetActive(true);
    }
}