using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string[] listOfScenes;
    public GameObject[] levelPositions;
    public int sceneToLoad = 0;
    [SerializeField] GameObject playerAvatar;
    private bool canLoadNext;
    private float fraction = 0;
    [SerializeField] private float moveSpeed = 3f;
    

    void Start()
    {
        sceneToLoad = GameManager.instance.nextSceneToLoad;
        MovePlayerAvatar();
    }
    private void Update()
    {
        if (canLoadNext)
        {
            fraction += moveSpeed * Time.deltaTime;
            playerAvatar.transform.position = Vector3.Lerp(levelPositions[sceneToLoad - 1].transform.position, levelPositions[sceneToLoad].transform.position, fraction);
            if (fraction > 1)
            {
                SceneManager.LoadScene(listOfScenes[sceneToLoad]);
            }

        }
    }

    void MovePlayerAvatar()
    {
        if (sceneToLoad == 0)
        {
            SceneManager.LoadScene(listOfScenes[sceneToLoad]);
        }
        else if (sceneToLoad > 0 && sceneToLoad <= listOfScenes.Length)
        {
            canLoadNext = true;
        }
        
    }
}
