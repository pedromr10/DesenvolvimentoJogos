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
    /*
    private string[] dialogLines = {
        "Fala a� meu mano!",
        "Voc� tem que tomar",
        "cuidado com esses", 
        "caras, eles s�o",
        "barra pesada!", 
        "Mas fica de boa",
        "que n�o sou igual eles",
        "n�o! Eles atiram",
        "espinhos envenenados",
        "que te matam na hora!"
    };
    */
    private string[] dialogLines = {
        "Fala a� meu mano!",
        "Voc� tem que tomar cuidado com esses caras!",
        "Eles s�o barra pesada!",
        "Mas fica de boa que n�o sou igual eles!",
        "Ai vai uma dica...",
        "Eles atiram espinhos ENVENENADOS que te matam na hora!"
    };

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
