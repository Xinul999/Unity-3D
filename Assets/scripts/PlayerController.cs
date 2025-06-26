using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    public float speed = 5.0f;
    private CharacterController controller;
    
    // Référence à la caméra principale
    private Transform cameraTransform;

    void Start() {
        controller = GetComponent<CharacterController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        // Obtenir la référence à la caméra principale
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (!gameManager.GetGameOver()) {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Calculer la direction de déplacement relative à la caméra
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;
            
            // Ignorer la composante Y pour éviter que le joueur ne "vole" quand la caméra regarde vers le haut/bas
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            // Créer le vecteur de mouvement basé sur les entrées et la direction de la caméra
            Vector3 move = right * horizontal + forward * vertical;
            move.Normalize();
            
            controller.SimpleMove(move * speed);
            
            // Optionnel: Faire pivoter le joueur dans la direction du mouvement
            if (move != Vector3.zero) {
                transform.forward = move;
            }
        }
    }
}