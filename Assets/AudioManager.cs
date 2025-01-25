using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> popSounds;
    private AudioSource audioSource;
    
    private static AudioManager instance;
    
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AudioManager();
            }

            return instance;
        }
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ActionManager.OnBubbleBlownUp += PlayPopSound;
    }
    
    private void PlayPopSound()
    {
        int randomIndex = Random.Range(0, popSounds.Count);
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(popSounds[randomIndex]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
