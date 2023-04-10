using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RagdollRigidbodiesCloseCheck(true);
        RagdollCollidersCloseCheck(false);
        GetComponent<CapsuleCollider>().enabled = true;
    }

  public void RagdollRigidbodiesCloseCheck(bool isActive)
    {
        Rigidbody[] rigidboies = GetComponentsInChildren<Rigidbody>();
        foreach ( var childPhysics in rigidboies)
        {
            childPhysics.isKinematic = isActive;
        }
    }
    public void RagdollCollidersCloseCheck(bool isActive)
    {
        CapsuleCollider[] rigidbodies = GetComponentsInChildren<CapsuleCollider>();
        foreach (var colliderOfChildObjects in rigidbodies)
        {
            colliderOfChildObjects.enabled = isActive;
        }
    }
    public void ActivateOrDeactivateRagdoll(bool isRigiActive, bool isCollActive)
    {
        RagdollRigidbodiesCloseCheck(isRigiActive);
        RagdollCollidersCloseCheck(isCollActive);
    }
}
