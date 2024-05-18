using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6.0f;
    public float runSpeed = 12.0f;
    public float jumpPower = 7.0f;
    public float gravity = 10.0f;


    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        #region Mouvement
        // On prend les valeurs x et z de l'orientation actuelle locale du joueur pour les convertir en valeurs globales
        // Donc maintenant forward et right remplacent Vector3.forward et Vector3.right
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Prend la valeur des inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Shift pour courir
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Si le joueur peut bouger, on utilise la vitesse de run s'il appuie sur shift sinon la vitesse de walk
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        controller.Move(moveDirection * Time.deltaTime);
        #endregion
    }
}