using UnityEngine;

public class SkinSwitcher : MonoBehaviour
{
   public GameObject[] skins;
    private int currentSkinIndex = 0;

    void Start()
    {
        LoadSkinStates();
    }

    public void LeftArrowButton()
    {
        SwitchSkin(-1);
    }

    public void RightArrowButton()
    {
        SwitchSkin(1);
    }

    private void SwitchSkin(int direction)
    {
        DeactivateCurrentSkin();

        currentSkinIndex = (currentSkinIndex + direction) % skins.Length;
        if (currentSkinIndex < 0)
        {
            currentSkinIndex += skins.Length;
        }

        SetActiveSkin(currentSkinIndex);
    }

    private void DeactivateCurrentSkin()
    {
        skins[currentSkinIndex].SetActive(false);
        SaveSkinState(currentSkinIndex, false);
    }

    public void SetActiveSkin(int index)
    {
        skins[index].SetActive(true);
        SaveSkinState(index, true);
    }

    private void SaveSkinState(int index, bool isActive)
    {
        PlayerPrefs.SetInt("Skin_" + index, isActive ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("Сохранено состояние скина " + index + ": " + (isActive ? "Активен" : "Неактивен"));
    }

    private void LoadSkinStates()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            bool isActive = PlayerPrefs.GetInt("Skin_" + i, 1) == 1;
            skins[i].SetActive(isActive);
        }
    }
}
