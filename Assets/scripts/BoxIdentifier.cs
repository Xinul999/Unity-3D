using System;
using TMPro;
using UnityEngine;

public class BoxIdentifier : MonoBehaviour
{
    public int boxID; //ce sera 1 2 ou 3, on va voir ça dans
    [SerializeField] private Rigidbody boxRigid;
    [SerializeField] private TextMeshPro boxText; // Référence au composant TextMeshPro
    [SerializeField] private string boxLabel = "Box"; // Texte de base pour l'étiquette

    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter avec " + other.gameObject.name);
        
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player)) {
            Debug.Log("BoxIdentifier " + boxID + " (trigger) détectée par " + player.name);  
            Vector3 direction = transform.position - player.transform.position;
            boxRigid.AddForce(direction.normalized * 15f, ForceMode.Impulse);
        }
    }

  
    private void Start()
    {
        if (boxText == null) {
            boxText = GetComponentInChildren<TextMeshPro>();
            
            if (boxText == null) {
                CreateTextMesh();
            }
        }
        UpdateBoxText();
    }
    
    private void CreateTextMesh()
    {
        GameObject textObj = new GameObject("BoxText");
        textObj.transform.SetParent(transform);
        textObj.transform.localPosition = new Vector3(0, 1.0f, 0); // Positionner au-dessus de la boîte
        textObj.transform.localRotation = Quaternion.identity;
        
        boxText = textObj.AddComponent<TextMeshPro>();
        boxText.alignment = TextAlignmentOptions.Center;
        boxText.fontSize = 6;
        boxText.color = Color.white;
        
        boxText.transform.rotation = Quaternion.LookRotation(boxText.transform.position - Camera.main.transform.position);
    }
    
    private void UpdateBoxText()
    {
        if (boxText != null) {
            boxText.text = boxLabel;
        }
    }
    
}
