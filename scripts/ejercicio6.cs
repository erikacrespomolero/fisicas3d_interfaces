using UnityEngine;
using TMPro; 

public class CubeCollectorCanvas : MonoBehaviour {
  public int puntuacion = 0;
  public TextMeshProUGUI textoPuntuacion; 
  private void Start() {
    ActualizarUI();
  }
  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("EscudoTipo1")) {
      puntuacion += 5;
      Debug.Log($"Escudo Tipo 1 recogido (+5). Puntuación total: {puntuacion}");
      Destroy(other.gameObject);
      ActualizarUI();
    } else if (other.CompareTag("EscudoTipo2")) {
      puntuacion += 10;
      Debug.Log($"Escudo Tipo 2 recogido (+10). Puntuación total: {puntuacion}");
      Destroy(other.gameObject);
      ActualizarUI();
    }
  }
  private void ActualizarUI() {
    if (textoPuntuacion != null)
      textoPuntuacion.text = $"Puntuación: {puntuacion}";
  }
}