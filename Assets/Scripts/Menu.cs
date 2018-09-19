using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    Button btn_loadGame;

    [SerializeField]
    int sceneIndex;

    private void Awake()
    {
        btn_loadGame.onClick.AddListener(delegate{OnClickLoadGame(sceneIndex);});
        //btn_loadGame.onClick.AddListener(OnClickLoadGame);
    }

    void OnClickLoadGame()
    {

    }

    void OnClickLoadGame(int index)
    {
        SceneManager.LoadScene(index);
    }

}
