using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SoundManager : MonoBehaviour
{
    public static UI_SoundManager UI_SoundInstance;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip jumpSound,shoootSound,dyingSound,damageSound,buttonClickSound;
    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private Image HPImage;
    public float killcount;
    

    private void Awake()
    {
        Debug.Log("awake");
        if (UI_SoundInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            UI_SoundInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        TylerControl.JumpHappend += JumpSound;
        Cannon.ShootHappend += ShootSound;
        ChassingTyler.TakeDamage += DamageSound;
        Bullet.hit += OnHit;
        SceneSwitcher.buttonClicked += ButtonSound;
    }

    
    private void ButtonSound()
    {
        _audioSource.PlayOneShot(buttonClickSound);
    }

    private void DamageSound(float currentHealth)
    {
        if (HPImage == null)
        {
            HPImage = GameObject.Find("HitPointFG").GetComponent<Image>();
        }
            
        HPImage.fillAmount = currentHealth / 10;
        _audioSource.PlayOneShot(damageSound);
    }

    private void OnHit()
    {
        if (killText == null)
        {
            killText = GameObject.Find("KillCount").GetComponent<TextMeshProUGUI>();
        }
        _audioSource.PlayOneShot(dyingSound);
        killcount++;
        killText.text = $"{killcount}";
    }

    private void ShootSound()
    {
        _audioSource.PlayOneShot(shoootSound);
    }

    private void JumpSound()
    {
        _audioSource.PlayOneShot(jumpSound);
    }

    private void OnDisable()
    {
        TylerControl.JumpHappend -= JumpSound;
        Cannon.ShootHappend -= ShootSound;
        Bullet.hit -= OnHit;
        ChassingTyler.TakeDamage -= DamageSound;
    }
    
    
}
