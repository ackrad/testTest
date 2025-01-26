using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> popSounds;
    [SerializeField] AudioSource popAudioSource;
    [SerializeField] AudioSource backgroundAudioSource;
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
        ActionManager.OnBubbleBlownUp += PlayPopSound;
    }
    
    private void PlayPopSound()
    {
        int randomIndex = Random.Range(0, popSounds.Count);
        popAudioSource.pitch = Random.Range(0.8f, 1.2f);
        popAudioSource.PlayOneShot(popSounds[randomIndex]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
