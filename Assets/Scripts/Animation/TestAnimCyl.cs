using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimCyl : MonoBehaviour
{
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartAnim()
    {
        if (mAnimator != null)
        {
            // Si l'état actuel est l'état Idle
            if (mAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash == -1957113375)
            {
                // On déclenche l'animation de chute de la table
                mAnimator.SetTrigger("trigAnimCyl");
            }
            // Si l'état actuel est l'état au sol
            else if (mAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash == 277847948)
            {
                // On déclenche l'animation de remise sur la table
                mAnimator.SetTrigger("2trigAnimCyl");
            }
            Debug.Log(mAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash);
        }
    }
}
