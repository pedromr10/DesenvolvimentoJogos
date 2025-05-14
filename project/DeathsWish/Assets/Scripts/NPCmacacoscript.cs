using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class NPCmacacoscript : MonoBehaviour
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
            dialogLines.Add("Oi! Bem vindo há floresta chinesa...");
            dialogLines.Add("Vou te auxiliar contra seus inimigos!");
            dialogLines.Add("Você encontrará demônios vagando pelo ar...");
            dialogLines.Add("Tome cuidado com suas bolas de fogo!");
            dialogLines.Add("Mais uma dica, eles não morrem tão fácil...");
            dialogLines.Add("Boa jornada!");
        }
        else
        {
            dialogLines.Add("Parece que não foi tão difícil pra você...");
            dialogLines.Add("Agora você irá enfrentar o Sun Wukong!");
            dialogLines.Add("Não vá esperando uma simples batalha, ele não é igual aos outros!");
            dialogLines.Add("Boa sorte!");
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