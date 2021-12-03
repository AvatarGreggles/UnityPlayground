using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2DTopDown : MonoBehaviour
{

    Rigidbody2D rbody;
    [SerializeField] float speed = 1f;

    private Vector2 movement;

    bool isFacingRight = true;

    Animator animator;

    SpriteRenderer playerSprite;

    CharacterAnimator characterAnimator;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnInteract()
    {
        if (GameController.Instance.state == GameState.FreeRoam)
        {
            Debug.Log("Interacting");
            var facingDir = new Vector3(characterAnimator.MoveX, characterAnimator.MoveY);
            var interactPos = transform.position + facingDir;

            // Debug.DrawLine(transform.position, interactPos, Color.green, 0.5f);

            var collider = Physics2D.OverlapCircle(interactPos, 3f, GameLayers.i.InteractablesLayer);
            if (collider != null)
            {
                Debug.Log("something there");
                collider.GetComponent<Interactable>()?.Interact(transform);
            }
        }

        if (GameController.Instance.state == GameState.Dialog)
        {
            DialogManager.Instance.HandleNextLine();
        }
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x < 0f)
        {
            // dustTrail.transform.eulerAngles = new Vector3(newTrailRotation.x, 90, newTrailRotation.z);
            playerSprite.flipX = true;
        }
        else if (movement.x > 0f)
        {
            // dustTrail.transform.eulerAngles = new Vector3(newTrailRotation.x, -90, newTrailRotation.z);
            playerSprite.flipX = false;
        }

        // dustTrail.GetComponent<ParticleSystem>().Play();

    }


    void Movement()
    {
        Vector2 currentPos = rbody.position;
        Vector2 adjustedMovement = movement * speed;
        Vector2 newPos = currentPos + adjustedMovement * Time.fixedDeltaTime;

        if (adjustedMovement == Vector2.zero)
        {
            animator.SetBool("IsMoving", false);
            OnMoveOver();
            // dustTrail.GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }


        rbody.MovePosition(newPos);

    }

    private void FixedUpdate()
    {

    }

    public void HandleUpdate()
    {
        Movement();

        var colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f, GameLayers.i.TriggerableLayers);

        foreach (var collider in colliders)
        {
            var triggerable = collider.GetComponent<IPlayerTriggerable>();
            if (triggerable != null)
            {
                triggerable.OnPlayerTriggered(this);
                break;
            }
        }
    }

    public void OnMoveOver()
    {
        // var colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f, GameLayers.i.TriggerableLayers);

        // foreach (var collider in colliders)
        // {
        //     var triggerable = collider.GetComponent<IPlayerTriggerable>();
        //     if (triggerable != null)
        //     {
        //         triggerable.OnPlayerTriggered(this);
        //         break;
        //     }
        // }
    }


}
