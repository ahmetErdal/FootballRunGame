using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    [SerializeField] private GameObject mainPlayer;
    RagdollCheck ragdoll;
    private Animator mainPlayerAnimator;
    private void Start()
    {
        mainPlayerAnimator = GetComponent<Animator>();
        ragdoll = GetComponent<RagdollCheck>();
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("çarptı");
            mainPlayer.GetComponent<CapsuleCollider>().enabled = false;
            mainPlayer.GetComponent<Animator>().enabled = false;
            mainPlayer.GetComponent<ThouchInput>().enabled = false;
            GameManager.instance.Lose();
            ragdoll.ActivateOrDeactivateRagdoll(false, true);
        }

        if (collision.gameObject.CompareTag("FinishTarget"))
        {
            Debug.Log("girdi");
            int randomAnimation = Random.Range(0, 1);
            if (randomAnimation==0)
            {
                mainPlayerAnimator.SetBool("win1", true);
                mainPlayer.GetComponent<ThouchInput>().enabled = false;
                GameManager.instance.Win();

            }
            else
            {
                mainPlayerAnimator.SetBool("win2", true);
                mainPlayer.GetComponent<ThouchInput>().enabled = false;
                GameManager.instance.Win();
            }
        }

    }

   


}
