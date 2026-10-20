using UnityEngine;

public class NotifierCylinder : MonoBehaviour {
  public delegate void OnCollisionHandler();
  public static event OnCollisionHandler OnCollisionWithCube;
  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("cubo")) {
      OnCollisionWithCube?.Invoke();
    }
  }
}