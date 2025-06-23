using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //[SerializeField]private CharacterController character;
    private GameManager gameManager;
    public float speed = 5.0f;
    private CharacterController controller;

    void Start() {
        controller = GetComponent<CharacterController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (!gameManager.GetGameOver()) {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            move.Normalize(); // A^2 + b^2 = 1
            controller.SimpleMove(move * speed);
        }
    }
  
}