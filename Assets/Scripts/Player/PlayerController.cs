using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    [Header("Movement Settings")]
    public float walkSpeed = 5.0f;
    public float runSpeed = 7.0f;
    public float jumpPower = 7.0f;
    public float gravity = 11.0f;
    public bool canMove = true;


    [Header("Look Settings")]
    public float lookSpeed = 2.0f;
    public float lookYLimit = 60.0f;

    [Header("References")]
    public Camera playerCamera;

    #region Initializations
    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;
    float movementDirectionY;
    float rotationX = 0;
    float rotationY = 0;
    #endregion


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (canMove)
        {
            HandleMovement();
            HandleJump();
            HandleRotation();
        }

        ApplyMovement();
    }

    public void EnablePlayerMovement()
    {
        canMove = true;
    }

    public void DisablePlayerMovement()
    {
        canMove = false;
    }

    /// <summary>
    /// Contrôle toute la partie du mouvement sur le plan horizontal
    /// </summary>
    private void HandleMovement()
    {
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

        // On applique le mouvement du plan horizontal au vecteur moveDirection
        moveDirection.x = (forward.x * curSpeedX) + (right.x * curSpeedY);
        moveDirection.z = (forward.z * curSpeedX) + (right.z * curSpeedY);
    }

    /// <summary>
    /// Contrôle toute la partie du mouvement sur le plan horizontal (saut et chute)
    /// </summary>
    private void HandleJump()
    {
        // Si les conditions sont réunies on saute
        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        // On applique la gravité
        else if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        // Sinon on maintient la vélocité précédente sur l'axe y (pour faire décoller ou bien retomber le joueur)
        else
        {
            moveDirection.y = 0;
        }
    }

    /// <summary>
    /// Contrôle la rotation de la caméra et du joueur à l'aide de la souris
    /// </summary>
    private void HandleRotation()
    {
        if (canMove)
        {
            // En rotation, l'axe X représente les mouvements verticaux
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationY = Input.GetAxis("Mouse X") * lookSpeed;

            // On limite les vues vers le bas et le haut
            rotationX = Mathf.Clamp(rotationX, -lookYLimit, lookYLimit);

            // On applique la rotation sur l'axe vertical
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

            // On applique la rotation sur l'axe vertical
            transform.rotation *= Quaternion.Euler(0, rotationY, 0);
        }
    }

    /// <summary>
    /// Applique au Character Controller le vecteur de déplacement moveDirection qui contient toutes les forces à appliquer lors de cette frame
    /// </summary>
    private void ApplyMovement()
    {
        // On applique toutes les forces au character controller en fonction du temps écoulé par frame
        controller.Move(moveDirection * Time.deltaTime);
    }
}