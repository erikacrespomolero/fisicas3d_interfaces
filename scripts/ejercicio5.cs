using UnityEngine;
public class CubeCollector : MonoBehaviour {
  public int puntuacion = 0;
  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("EscudoTipo1")) {
      puntuacion += 5;
      Debug.Log($"Escudo Tipo 1 recogido (+5). Puntuación total: {puntuacion}");
      Destroy(other.gameObject);
    } else if (other.CompareTag("EscudoTipo2")) {
      puntuacion += 10;
      Debug.Log($"Escudo Tipo 2 recogido (+10). Puntuación total: {puntuacion}");
      Destroy(other.gameObject);
    }
  }
}