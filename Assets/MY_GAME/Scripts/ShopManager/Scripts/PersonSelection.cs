using UnityEngine;
using UnityEngine.UI;

public class PersonSelection : MonoBehaviour
{
    [Header("Play/Buy Buttons")]
    [SerializeField] private Button play;
    [SerializeField] private Button buy;
    [SerializeField] private Text priceText;

    [Header("Skin Prefabs")]
    [SerializeField] private GameObject[] skinObjects;

    private int currentCar;

    [Header("Sound")]
    [SerializeField] private AudioClip purchase;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        currentCar = SaveManager.instance.currentCar;
        SelectCar(currentCar);
    }

    private void SelectCar(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }

        for (int i = 0; i < skinObjects.Length; i++)
        {
            bool isUnlocked = SaveManager.instance.carsUnlocked[i];


            if (isUnlocked)
            {
                Image icon = skinObjects[i].GetComponent<Image>();
                if (icon != null)
                {
                    icon.color = Color.white;
                }
            }
        }

        Canvas.ForceUpdateCanvases();
        UpdateUI();
    }



    private void UpdateUI()
    {
        play.gameObject.SetActive(false);
        buy.gameObject.SetActive(false);


        for (int i = 0; i < skinObjects.Length; i++)
        {
            bool isUnlocked = SaveManager.instance.carsUnlocked[i];

            // Изменяем цвет иконки (объекта)
            Image icon = skinObjects[i].GetComponent<Image>();
            if (icon != null)
            {
                if (isUnlocked)
                {
                    icon.color = Color.white; // Установите нужный цвет
                }
                else
                {
                    icon.color = Color.black; // Цвет для заблокированных объектов
                }
                icon.SetVerticesDirty(); // Обновляем графику компонента
            }
        }






        if (SaveManager.instance.carsUnlocked[currentCar])
        {
            play.gameObject.SetActive(true);
        }
        else
        {
            buy.gameObject.SetActive(true);
        }
    }

    public void ChangeCarIcon(int _change)
    {
        currentCar = _change;
        SaveManager.instance.currentCar = currentCar;
        SaveManager.instance.Save();
        SelectCar(currentCar);
    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;

        // Проверяем выход за пределы массива
        if (currentCar >= skinObjects.Length)
        {
            currentCar = 0; // Если больше последнего, переходим к первому
        }
        else if (currentCar < 0)
        {
            currentCar = skinObjects.Length - 1; // Если меньше первого, переходим к последнему
        }

        SaveManager.instance.currentCar = currentCar;
        SaveManager.instance.Save();
        SelectCar(currentCar);
    }

    public void OpenSkin(int indexPerson)
    {
        SaveManager.instance.carsUnlocked[indexPerson] = true;
        SaveManager.instance.Save();
        source.PlayOneShot(purchase);
        UpdateUI();
    }
}
