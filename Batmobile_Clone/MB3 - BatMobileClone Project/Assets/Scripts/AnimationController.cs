using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public Vector2 BlenderVector;
    public bool BattleMode;

    public Vector3 AnglularV;

    private CharMove cm;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponentInParent<CharMove>();
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BattleMode = cm.BattleMode;
        BlenderVector = cm.InVector;

        anim.SetFloat("x", BlenderVector.x);
        anim.SetFloat("y", BlenderVector.y);

        anim.SetBool("Battle", BattleMode);

        AnglularV = rb.angularVelocity;
    }
}
