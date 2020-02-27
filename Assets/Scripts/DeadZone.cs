using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] GameObject respawn;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            CharacterController characterController = other.GetComponent<CharacterController>();
            if(characterController != null)
            {
                characterController.enabled = false;
            }
            other.transform.position = respawn.transform.position;
            StartCoroutine(CCEnable(characterController));
        }
    }
    IEnumerator CCEnable(CharacterController controller)
    {
        yield return new WaitForSeconds(0.1f);
        controller.enabled = true;
    }
}
