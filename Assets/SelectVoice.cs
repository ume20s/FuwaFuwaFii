using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectVoice : MonoBehaviour
{
    // ��񂲂�����I��
    public void SelectRingo()
    {
        fuwafuwa.vo = 0;
        SceneManager.LoadScene("GameScene");
    }

    // ���[����������I��
    public void SelectAi()
    {
        fuwafuwa.vo = 7;
        SceneManager.LoadScene("GameScene");
    }
}
