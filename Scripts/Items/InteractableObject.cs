using UnityEngine;

public class InteractableObject: MonoBehaviour {
  public float radius = 3f;
  bool isFocus = false;
  bool hasInteracted = false;
  public Transform interactionTransform;
  public Transform player;

  public virtual void Interact() {
    Debug.Log("Interact with " + transform.name);
  }
  void Update() {
    if (isFocus && hasInteracted == true) {
      float distance = Vector3.Distance(player.position, interactionTransform.position);
      if (distance <= radius) {
        Interact();
        hasInteracted = true;
      }
    }
  }
  public void OnFocused(Transform playerTransform) {
    isFocus = true;
    player = playerTransform;
    hasInteracted = true;
  }
  public void OnDefocused() {
    isFocus = false;
    player = null;
    hasInteracted = false;
  }
  void OnDrawGizmosSelected() {
    if (interactionTransform == null)
      interactionTransform = transform;
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(interactionTransform.position, radius);
  }
}