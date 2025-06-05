using QFSW.QC.Suggestors;
using Unity.VisualScripting;
using UnityEngine;

public class CreatedCubes : MonoBehaviour
{
    public AudioSource audioSource;
    private RandomCube _randomCube;
    private GameObject player;
    
    void Start()
    {
        _randomCube = GameObject.Find("GenerateRandomCube").GetComponent<RandomCube>();
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {

            for (int i = 0; i < 10; i++)
            {
                _randomCube.CreateRandomCube();
            }
            audioSource.Play();
            Destroy(gameObject);
        }
    }
}
