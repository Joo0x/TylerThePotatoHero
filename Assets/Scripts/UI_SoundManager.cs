
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_SoundManager : MonoBehaviour
{
    public AudioSource instance;
    public AudioClip jumpSound,shoootSound,ew;
    public TextMeshProUGUI killText;
    public float killcount;
    

    private void Awake()
    {
        instance = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        TylerControl.JumpHappend += JumpSound;
        Cannon.ShootHappend += ShootSound;
        Bullet.hit += OnHit;
    }

    private void OnHit()
    {
        instance.PlayOneShot(ew);
        killcount++;
        //Debug.Log(killcount);
        killText.text = $"{killcount}";
        // if (killcount >= 4)
        // {
        //     Invoke("Victory",1.5f);
        // }
    }

    // private void Victory()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }

    private void ShootSound()
    {
        instance.PlayOneShot(shoootSound);
      
    }

    private void JumpSound()
    {
        instance.PlayOneShot(jumpSound);

    }

    private void OnDisable()
    {
        TylerControl.JumpHappend -= JumpSound;
        Cannon.ShootHappend -= ShootSound;
        Bullet.hit -= OnHit;
    }
    
    
}
