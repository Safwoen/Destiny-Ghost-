using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public Dialogue dialogue; 
    public DialogueManager dm;

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            dm.StartDialogue(dialogue); 
            Destroy(gameObject); 
        }
    }
}