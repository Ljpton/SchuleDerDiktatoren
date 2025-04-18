using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    Animator animator;
    
    private AudioManager audioManager;
    
    [SerializeField] private GameObject[] checkpoints;
    [SerializeField] private TMP_Text[] texts;
    [SerializeField] private Image[] images;

    [SerializeField] private Sprite civilRightsMedal;
    [SerializeField] private Sprite freedomOfSpeechMedal;
    [SerializeField] private Sprite participationMedal;
    [SerializeField] private Sprite separationOfPowerMedal;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.keepAnimatorStateOnDisable = true;
    }

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void StartCheckpointAnimation(int checkpointNumber)
    {
        for (int i = 0; i < checkpointNumber; i++)
        {
            checkpoints[i].SetActive(true);
        }

        animator.SetInteger("Progress", checkpointNumber);
        
        Invoke(nameof(PlayMedalSound), 1.7f);
    }

    private void PlayMedalSound()
    {
        audioManager.PlayMedalSound();
    }

    public void SetProgressText(ArrayList categoriesEnshrined)
    {
        for (int i = 0; i < categoriesEnshrined.Count; i++)
        {
            texts[i].SetText( ((Categories) categoriesEnshrined[i]).GetDescription() );

            switch (categoriesEnshrined[i])
            {
                case Categories.CivilRights:
                    images[i].sprite = civilRightsMedal;
                    break;
                case Categories.SeparationOfPower:
                    images[i].sprite = separationOfPowerMedal;
                    break;
                case Categories.FreedomOfSpeech:
                    images[i].sprite = freedomOfSpeechMedal;
                    break;
                case Categories.Participation:
                    images[i].sprite = participationMedal;
                    break;
            }
        }
    }
}
