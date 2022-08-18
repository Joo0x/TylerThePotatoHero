using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timer;

    [SerializeField]private int count;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("countDown",1,1);
    }

    // Update is called once per frame
    void Update()
    {
     
        if (count <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    void countDown()
    {

        count--;

        timer.text = $"{count}";
    }
}
