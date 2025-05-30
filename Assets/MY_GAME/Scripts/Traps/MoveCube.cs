using System.Collections;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    private bool right = false;
    private int countSide = 2;
    private int randomNum;
    public Animator animator;
    private float moveCubeRate = 0.8f;
    private float moveCubeWaitRate = 1.3f;

    void Start()
    {
        randomNum = Random.Range(0, 50);

        if (ScoreManager.score > 100)
        {
            moveCubeRate = 0.5f;
            moveCubeWaitRate = 1.0f;
        }

        StartCoroutine(MoveCubeLoop());
    }

    private void MethodTrig()
    {
        animator.SetBool("trig", true);
    }

    private IEnumerator MoveCubeLoop()
    {
        while (true)
        {
            Invoke("MethodTrig", moveCubeRate);

            yield return new WaitForSeconds(moveCubeWaitRate);
            animator.SetBool("trig", false);

            if (right == false && countSide == 2 || countSide == 0)
            {
                if (randomNum > 0)
                {
                    transform.Translate(Vector3.right * 5f, Space.World);
                    right = true;

                    if (countSide == 0)
                    {
                        countSide = 2;
                        right = false;
                    }
                }
            }
            else
            {
                if (randomNum > 0)
                {
                    transform.Translate(Vector3.right * -5f, Space.World);
                    right = false;
                    countSide -= 1;
                }
            }

            yield return new WaitForSeconds(moveCubeWaitRate);
        }
    }
}
