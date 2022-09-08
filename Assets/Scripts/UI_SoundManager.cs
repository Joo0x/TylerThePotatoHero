using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SoundManager : MonoBehaviour
{
    public static UI_SoundManager UI_SoundInstance;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip jumpSound,platformSound,shoootSound,dyingSound,damageSound,buttonClickSound,levelMusic,victoryMusic;
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
        LetsGoUp.platMoved += PlayPlatSound;
        Win.TylerWon += winSound;
        TylerControl.JumpHappend += JumpSound;
        BulletPool.ShootHappend += ShootSound;
        ChassingTyler.TakeDamage += DamageSound;
        Bullet.hit += OnHit;
        SceneSwitcher.buttonClicked += ButtonSound;
    }

    private void winSound()
    {
        killcount = 0;
        _audioSource.clip = null;
        _audioSource.PlayOneShot(victoryMusic);
        
    }
    
    private void PlayPlatSound()
    {
        _audioSource.PlayOneShot(platformSound);

    }


    private void ButtonSound()
    {
        _audioSource.PlayOneShot(buttonClickSound);
        _audioSource.clip = levelMusic;
        _audioSource.Play();
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
        LetsGoUp.platMoved -= PlayPlatSound;
        TylerControl.JumpHappend -= JumpSound;
        BulletPool.ShootHappend -= ShootSound;
        Bullet.hit -= OnHit;
        ChassingTyler.TakeDamage -= DamageSound;
        SceneSwitcher.buttonClicked -= ButtonSound;

    }


}
