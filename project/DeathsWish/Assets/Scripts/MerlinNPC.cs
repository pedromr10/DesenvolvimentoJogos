using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MerlinNPCScript : MonoBehaviour
{
    public GameObject interactionUI;
    public GameObject dialogUI;
    public TextMeshProUGUI dialogText;

    private bool isPlayerNear = false;
    private bool isDialogActive = false;
    private int dialogIndex = 0;

    private List<string> dialogLines = new List<string>();

    void Start()
    {
        string scene = SceneManager.GetActiveScene().name;

        if (scene.EndsWith("1"))
        {
            dialogLines.Add("Olá! Seja bem vindo ao mundo medieval");
            dialogLines.Add("Eu sou o Merlin, e estou aqui para ajudar");
            dialogLines.Add("Mais a frente, você encontrará perigosos cavaleiros e espinhos");
            dialogLines.Add("Os cavaleiros usam fortes armaduras, então muito cuidado...");
            dialogLines.Add("E não toque nos espinhos!");
            dialogLines.Add("Boa sorte...");
        }
        else if (scene.EndsWith("2"))
        {
            dialogLines.Add("Muito bem...");
            dialogLines.Add("Agora, deve tomar cuidado com os arqueiros!");
            dialogLines.Add("Eles podem não ter a mesma armadura dos cavaleiros...");
            dialogLines.Add("Mas atiram de longe e podem te acertar!");
            dialogLines.Add("Muito cuidado...");
        }
        else
        {
            dialogLines.Add("Você concluiu mais um desafio...");
            dialogLines.Add("Prepare-se para enfrentar o poderoso Rei Arthur!");
            dialogLines.Add("Derrote-o e você conseguirá o item que tanto almeja...");
        }
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
        if (dialogIndex < dialogLines.Count)
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
