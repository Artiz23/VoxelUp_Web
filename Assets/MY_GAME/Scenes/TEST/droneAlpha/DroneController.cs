using UnityEngine;
using UnityEngine.InputSystem;

public class DroneController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 50f;
    public float ascentSpeed = 3f;

    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction ascendAction;

    private void OnEnable()
    {
        moveAction = new InputAction("Move", binding: "<Gamepad>/rightStick");
        moveAction.Enable();

        rotateAction = new InputAction("Rotate", binding: "<Gamepad>/leftStick");
        rotateAction.Enable();

        ascendAction = new InputAction("Ascend", binding: "<Gamepad>/leftStick");
        ascendAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
        ascendAction.Disable();
    }

    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector2 rotateInput = rotateAction.ReadValue<Vector2>();
        Vector2 ascendInput = ascendAction.ReadValue<Vector2>();

        float moveForwardBackward = moveInput.y * moveSpeed * Time.deltaTime;
        float moveLeftRight = moveInput.x * moveSpeed * Time.deltaTime;
        float moveUpDown = ascendInput.y * ascentSpeed * Time.deltaTime;
        float rotateY = rotateInput.x * rotateSpeed * Time.deltaTime;

        transform.Translate(moveLeftRight, moveUpDown, moveForwardBackward);
        transform.Rotate(0, rotateY, 0);
    }
}
