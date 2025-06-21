using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //[SerializeField]private CharacterController character;
    public float speed = 5.0f;
    private CharacterController controller;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!GameManager.Instance.GetGameOver()) {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            move.Normalize(); // A^2 + b^2 = 1
            controller.SimpleMove(move * speed);
        }
    }
  
}