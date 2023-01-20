using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectVoice : MonoBehaviour
{
    // ‚è‚ñ‚²‚¿‚á‚ñ‚ğ‘I‚ñ‚¾
    public void SelectRingo()
    {
        fuwafuwa.vo = 0;
        SceneManager.LoadScene("GameScene");
    }

    // ‚¦[‚ ‚¢‚¿‚á‚ñ‚ğ‘I‚ñ‚¾
    public void SelectAi()
    {
        fuwafuwa.vo = 7;
        SceneManager.LoadScene("GameScene");
    }
}
