using UnityEngine;
public class NotifierReference : MonoBehaviour {
  public delegate void AlAproximarseHandler();
  public static event AlAproximarseHandler OnCuboAproximado;
  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("cubo"))
      OnCuboAproximado?.Invoke();
  }
}