using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField playerName;

    // Start is called before the first frame update
    void Start()
    {
        PersistenceData.Instance.LoadData();
        playerName.text=PersistenceData.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        PersistenceData.Instance.playerName=playerName.text;
        PersistenceData.Instance.SaveData();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }


}
