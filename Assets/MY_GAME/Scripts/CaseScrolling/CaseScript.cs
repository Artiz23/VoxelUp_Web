using UnityEngine;
using UnityEngine.UI;


public class CaseScript : MonoBehaviour
{
    public bool openCase = false;
    public GameObject[] prefabs;
    public GameObject sp;
    public float scrollSpeed = -2000f;
    [SerializeField] private float velocity = 3f;
    public WSprites[] ws;
    public Image[] prefabsImages;
    public Image finalDrop;
    public Text moneyText;
    public GameObject imageCoin;
    public GameObject dropPan;
    private int currentCase;
    private AudioSource _as;
    public AudioClip[] ac;
    private bool wasPlayed = false;
    private bool wasPlayedDrop = false;
    private string Index;
    public GameObject line;
    public GameObject scroll;
    public GameObject scrollPanel;

    [SerializeField] private int priceLowCase = 0;
    [SerializeField] private int priceMiddleCase = 5;
    [SerializeField] private int priceBigCase = 10;

    public GameObject[] inventoryObjects;

    private PersonSelection carSelection;
    private SaveManager saveManager;

    private bool isOpen = false;


    void Start()
    {
        carSelection = GameObject.FindWithTag("CarSelection").GetComponent<PersonSelection>();
        saveManager = GameObject.FindWithTag("SaveManager").GetComponent<SaveManager>();

        _as = gameObject.GetComponent<AudioSource>();

        gameObject.SetActive(false);
    }



    void Update()
    {
        if (openCase)
        {
            scrollSpeed = Mathf.MoveTowards(scrollSpeed , 0, velocity * Time.deltaTime);

            RaycastHit2D hit = Physics2D.Raycast(line.transform.position, Vector2.down);

            if (hit.collider != null)
            {
                if (scrollSpeed == 0)
                {
                    dropPan.SetActive(true);
                    finalDrop.sprite = hit.collider.gameObject.GetComponent<Image>().sprite;


                    Sprite droppedSprite = finalDrop.sprite;

                    if (!wasPlayedDrop && hit.collider.tag == "Blue")
                    {
                        if (droppedSprite.name == "Blue_Case1_1_")
                        {
                            int carIndex = 1;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+2";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 2;
                                SaveManager.instance.Save();
                                openCase = false;

                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[0].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }

                        else if (droppedSprite.name == "Blue_Case1_2_")
                        {

                            int carIndex = 2;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+2";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 2;
                                SaveManager.instance.Save();
                                openCase = false;
                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[1].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }
                        else if (droppedSprite.name == "Blue_Case1_3_")
                        {

                            int carIndex = 3;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+2";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 2;
                                SaveManager.instance.Save();
                                openCase = false;
                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[2].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }
                        else if (droppedSprite.name == "Blue_Case1_4_")
                        {

                            int carIndex = 4;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+2";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 2;
                                SaveManager.instance.Save();
                                openCase = false;
                            }
                            else
                            {

                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[3].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }
                        else if (droppedSprite.name == "Blue_Case1_5_")
                        {

                            int carIndex = 5;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+2";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 2;
                                SaveManager.instance.Save();
                                openCase = false;
                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[4].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }


                    }

                    if (!wasPlayedDrop && hit.collider.tag == "Purple")
                    {

                        if (droppedSprite.name == "Purple_Case1_1_")
                        {
                            int carIndex = 6;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+3";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 3;
                                SaveManager.instance.Save();
                                openCase = false;
                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[5].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }
                        else if (droppedSprite.name == "Purple_Case1_2_")
                        {
                            int carIndex = 7;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+3";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 3;
                                SaveManager.instance.Save();
                                openCase = false;
                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[6].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }
                        else if (droppedSprite.name == "Purple_Case1_3_")
                        {
                            int carIndex = 8;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+3";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 3;
                                SaveManager.instance.Save();
                                openCase = false;
                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[7].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }


                    }


                    if (!wasPlayedDrop && hit.collider.tag == "Pink")
                    {

                        if (droppedSprite.name == "Pink_Case1_1_")
                        {
                            int carIndex = 9;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+5";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 5;
                                SaveManager.instance.Save();
                                openCase = false;
                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[8].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }
                        else if (droppedSprite.name == "Pink_Case1_2_")
                        {

                            int carIndex = 10;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+5";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 5;
                                SaveManager.instance.Save();
                                openCase = false;
                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;

                                inventoryObjects[9].SetActive(true);

                                saveManager.carsUnlocked[carIndex] = true;

                            }
                        }

                    }


                    if (!wasPlayedDrop && hit.collider.tag == "Red")
                    {

                        if (droppedSprite.name == "Red_Case1_1_")
                        {
                            int carIndex = 11;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+7";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 7;
                                SaveManager.instance.Save();
                                openCase = false;
                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[10].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }
                        else if (droppedSprite.name == "Red_Case1_2_")
                        {
                            int carIndex = 12;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+7";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 7;
                                SaveManager.instance.Save();
                                openCase = false;
                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[11].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }
                    }


                    if (!wasPlayedDrop && hit.collider.tag == "Yellow")
                    {
                        if (droppedSprite.name == "Yellow_Case1_1_")
                        {

                            int carIndex = 13;

                            if (saveManager.carsUnlocked[carIndex])
                            {
                                Debug.Log("Скин уже разблокирован, добавляем монету");
                                _as.PlayOneShot(ac[5]);
                                moneyText.text = "+10";
                                imageCoin.SetActive(true);
                                SaveManager.instance.money += 10;
                                SaveManager.instance.Save();
                                openCase = false;

                            }
                            else
                            {
                                Debug.Log("Разблокировка нового скина");
                                carSelection.OpenSkin(carIndex);
                                _as.PlayOneShot(ac[1]);
                                wasPlayedDrop = true;
                                inventoryObjects[12].SetActive(true);
                                saveManager.carsUnlocked[carIndex] = true;
                            }
                        }
                    }
                }
                else if (!wasPlayed)
                {
                    _as.PlayOneShot(ac[0]);
                    Index = hit.collider.gameObject.name;
                    wasPlayed = true;
                }
                if (Index != hit.collider.gameObject.name)
                {
                    wasPlayed = false;
                }
            }
            else if (scrollSpeed == 0)
            {
                scrollSpeed = Mathf.MoveTowards(scrollSpeed * Time.deltaTime, -30f, velocity);
            }
        }
    }
    public void caseBttn(int caseInt)
    {
        int price;

        switch (caseInt)
        {
            case 0:
                price = priceLowCase;
                break;
            case 1:
                price = priceMiddleCase;
                break;
            case 2:
                price = priceBigCase;
                break;
            default:
                price = priceLowCase;
                break;
        }

        if (SaveManager.instance.money >= price || price == 0)
        {
            gameObject.SetActive(true);
            scroll.SetActive(true);

            SaveManager.instance.money -= price;
            SaveManager.instance.Save();
            //YanCloud
            openCase = true;

            currentCase = caseInt;
            simulateCases();
            //velocity = Random.Range(210, 320.5f);
            _as.PlayOneShot(ac[3]);
        }
        else
        {
            gameObject.SetActive(true);
            _as.PlayOneShot(ac[4]);
        }
    }



    public void Close()
    {
        scrollSpeed = -1500f;
        // Очистка спавненных предметов
        foreach (Transform child in sp.transform)
        {
            Destroy(child.gameObject);
        }

        moneyText.text = "";
        imageCoin.SetActive(false);
        openCase = false;
        dropPan.SetActive(false);
        wasPlayed = false;
        wasPlayedDrop = false;
        Index = null;
        finalDrop.sprite = null;
        gameObject.SetActive(false);
        scroll.SetActive(false);
        scrollPanel.transform.localPosition = new Vector3(4503f, 50f, 0);
    }

    void simulateCases()
    {
        for (int a = 0; a < 90; a++)
        {
            int rand = Random.Range(0, 1000);
            int randWeapon = 0;

            if (rand <= 600)
            {
                randWeapon = 0;
                prefabsImages[randWeapon].sprite = ws[currentCase].blueW[Random.Range(0, ws[currentCase].blueW.Length)];

            }
            else if (rand > 600 && rand <= 830)
            {
                randWeapon = 1;
                prefabsImages[randWeapon].sprite = ws[currentCase].purpleW[Random.Range(0, ws[currentCase].purpleW.Length)];
            }
            else if (rand > 830 && rand <= 930)
            {
                randWeapon = 2;
                prefabsImages[randWeapon].sprite = ws[currentCase].pinkW[Random.Range(0, ws[currentCase].pinkW.Length)];
            }
            else if (rand > 930 && rand <= 990)
            {
                randWeapon = 3;
                prefabsImages[randWeapon].sprite = ws[currentCase].redW[Random.Range(0, ws[currentCase].redW.Length)];
            }
            else if (rand > 990)
            {
                randWeapon = 4;
                prefabsImages[randWeapon].sprite = ws[currentCase].knife[Random.Range(0, ws[currentCase].knife.Length)];
            }

            GameObject obj = Instantiate(prefabs[randWeapon], new Vector2(0, 0), Quaternion.identity) as GameObject;

            obj.transform.SetParent(sp.transform);
            obj.transform.localScale = new Vector2(1, 1);
            obj.name = obj.name + a.ToString();
        }
    }
}