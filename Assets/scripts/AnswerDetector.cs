using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerDetector : MonoBehaviour
{
    public int rightAnswer;
    public string nextScene;
    [SerializeField] private Renderer rend;

    private void OnCollisionEnter(Collision collision)
    {
        BoxIdentifier box = collision.gameObject.GetComponent<BoxIdentifier>();
        if (box != null)
        {
            Debug.Log("Boîte ID " + box.boxID + " détectée.");

            if (box.boxID == rightAnswer)
            {
                Debug.Log("C'est la bonne réponse !");
                rend.material.color = Color.green;

                SceneManager.LoadScene(nextScene);
            }
            else
            {
                Debug.Log("bzzzzzt, mauvaise réponse !");
                rend.material.color = Color.red;
            }
        }
    }
}