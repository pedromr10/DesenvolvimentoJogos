using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class NPCCactoScript : MonoBehaviour
{
    public GameObject interactionUI;       
    public GameObject dialogUI;            
    public TextMeshProUGUI dialogText;   

    private bool isPlayerNear = false;
    private bool isDialogActive = false;
    private int dialogIndex = 0;

    private string[] dialogLines = {
        "Fala ai meu mano!",
        "Voce tem que tomar cuidado com esses caras!",
        "Eles sao barra pesada!",
        "Mas fica de boa que nao sou igual eles!",
        "Ai vai uma dica...",
        "Eles não morrem com apenas um tiro."
    };

    private AudioSource audioSource;
    public AudioClip tiroClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogActive)
            {
                StartDialog();
            }
            else
            {
                ContinueDialog();
            }
        }
    }

    void StartDialog()
    {
        audioSource.PlayOneShot(tiroClip);
        isDialogActive = true;
        dialogIndex = 0;
        dialogUI.SetActive(true);
        dialogText.text = dialogLines[dialogIndex];
    }

    void ContinueDialog()
    {
        dialogIndex++;
        if (dialogIndex < dialogLines.Length)
        {
            dialogText.text = dialogLines[dialogIndex];
        }
        else
        {
            dialogUI.SetActive(false);
            isDialogActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            interactionUI.SetActive(false);
            dialogUI.SetActive(false);
            isDialogActive = false;
        }
    }
}
