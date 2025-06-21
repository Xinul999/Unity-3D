using UnityEngine; // ← Important pour avoir accès à Collision et MonoBehaviour

public class AnswerDetector : MonoBehaviour
{
    public int rightAnswer;
    [SerializeField] private Renderer rend;
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        BoxIdentifier box = collision.gameObject.GetComponent<BoxIdentifier>();
        Debug.Log("AnswerDetector : " + gameObject.name);
        if (box != null)
        {
            Debug.Log("Boîte ID " + box.boxID + " détectée.");
        }
        if (box.boxID == rightAnswer)
        {
            Debug.Log("C'est la bonne réponse !");
            rend.material.color = Color.green;
        }
        else
        {
            Debug.Log("bzzzzzt, mauvaise réponse !");
            rend.material.color = Color.red;
        }

    }
}