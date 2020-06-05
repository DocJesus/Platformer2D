using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkBox : MonoBehaviour
{

    [SerializeField]
    private Text textBox;
    [SerializeField]
    private Image border;
    [SerializeField]
    private Image inside;

    public static TalkBox instance;

    private void Awake()
    {
        textBox.text = "";
        border.enabled = false;
        inside.enabled = false;
        textBox.enabled = false;

        if (instance != null)
        {
            Debug.LogError("double instance TalkBox");
            return;
        }
        instance = this;
    }

    public void WriteText(string _text)
    {
        //afficher les différents trucs
        border.enabled = true;
        inside.enabled = true;
        textBox.enabled = true;
        //écrire le text de manière sympa avec une coroutine
        StartCoroutine(affText(_text));
        //arréter le joueur
        MovePlayer.instance.DesactivatePlayer();
    }

    public void WipeText()
    {
        textBox.text = "";
        border.enabled = false;
        inside.enabled = false;
        textBox.enabled = false;
        MovePlayer.instance.ActivatePlayer();
    }

    IEnumerator affText(string _text)
    {
        char[] letters = _text.ToCharArray();

        for (int i = 0; i < letters.Length; i++)
        {
            textBox.text = textBox.text + letters[i];
            yield return new WaitForSeconds(0.01f);
        }
    }
}
