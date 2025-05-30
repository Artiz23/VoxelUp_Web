using DG.Tweening;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Transform childToRotate;
    public float rotationSpeed = 1.0f;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private Vector3 rotationAxis;
    private float rotationAmount;
    public float rotationProgress = 0f;

    void Start()
    {
        targetRotation = childToRotate.rotation;
    }

    void Update()
{
    // Проверяем нажатие клавиши для начала вращения
    if (Input.GetKeyDown(KeyCode.W))
    {
        rotationAxis = Vector3.right; // Вращение вокруг оси X
        rotationAmount = -180f;
        SetNewTargetRotation();
    }
    else if (Input.GetKeyDown(KeyCode.A))
    {
        rotationAxis = Vector3.forward; // Вращение вокруг оси Z
        rotationAmount = -180f;
        SetNewTargetRotation();
    }
    else if (Input.GetKeyDown(KeyCode.D))
    {
        rotationAxis = Vector3.forward; // Вращение вокруг оси Z
        rotationAmount = 180f;
        SetNewTargetRotation();
    }
    else if (Input.GetKeyDown(KeyCode.S))
    {
        rotationAxis = Vector3.right; // Вращение вокруг оси X
        rotationAmount = 180f;
        SetNewTargetRotation();
    }

    if (isRotating)
    {
        // Прогресс анимации вращения
        rotationProgress += Time.deltaTime * rotationSpeed;

        if (rotationProgress >= 1f)
        {
            rotationProgress = 1f;
            isRotating = false;
        }

        // Плавно вращаем объект
        childToRotate.rotation = Quaternion.Slerp(childToRotate.rotation, targetRotation, rotationProgress);
    }
}


    void SetNewTargetRotation()
    {
        if (isRotating)
        {
            // Обновляем текущий поворот перед изменением цели
            childToRotate.rotation = Quaternion.Slerp(childToRotate.rotation, targetRotation, rotationProgress);

            // if(childToRotate.rotation.x != 180f || childToRotate.rotation.x != -180f || childToRotate.rotation.x != 0f)
            // {
                childToRotate.rotation = Quaternion.Euler(180f, 0f, 0f);
           // }
        }

        rotationProgress = 0f;
        targetRotation = Quaternion.AngleAxis(rotationAmount, rotationAxis) * childToRotate.rotation;
        isRotating = true;
    }
}
