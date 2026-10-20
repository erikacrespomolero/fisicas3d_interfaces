using UnityEngine;
public class NotifierCube : MonoBehaviour {
  public delegate void AlColisionarHumanoide(int tipoHumanoide);
  public static event AlColisionarHumanoide OnColisionHumanoide;
  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("HumanoideTipo1"))
      OnColisionHumanoide?.Invoke(1);
    else if (collision.gameObject.CompareTag("HumanoideTipo2"))
      OnColisionHumanoide?.Invoke(2);
  }
}