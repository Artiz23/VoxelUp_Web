using UnityEngine;

public class PayCoins : MonoBehaviour
{
  private SaveManager saveManager;

  private void Start()
  {
    saveManager = GameObject.FindWithTag("SaveManager").GetComponent<SaveManager>();
  }

  public void SuccessPurchased(string id)
  {
    if (id == "coin")
    {
      SaveManager.instance.money += 150;
    }

    if (id == "coin2")
    {
      SaveManager.instance.money += 400;
    }

    if (id == "coin3")
    {
      SaveManager.instance.money += 900;
    }

    if (id == "coin4")
    {
      SaveManager.instance.money += 2000;
    }

    SaveManager.instance.Save();
  }
}
