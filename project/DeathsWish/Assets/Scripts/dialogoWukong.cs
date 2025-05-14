using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement;


public class dialogoWukong : MonoBehaviour
{
    public GameObject interactionUI;       
    public GameObject dialogUI;            
    public TextMeshProUGUI dialogText;   

    private bool isPlayerNear = false;
    private bool isDialogActive = false;
    private int dialogIndex = 0;
    private string scene;
    private string[] dialogLines = {
        "O que trouxe contigo?",
        "Hmm! um saco de bananas!",
        "Sei que precisa do meu bastão...",
        "Então acho que não precisamos batalhar...", 
        "Vamos fazer uma troca!",
        "Leve o bastão e me deixe com as bananas!",
        "Boa sorte, você vai precisar!"
    };


    void Start(){
        Scene currentScene = SceneManager.GetActiveScene();
        scene = currentScene.name;
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
            SceneManager.LoadScene("TransicaoChinaMedieval");
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