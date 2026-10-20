using UnityEngine;
public class ObjectSpawner : MonoBehaviour {
  public GameObject prefabCaida;   
  public int cantidad = 25;       
  public float alturaInicio = 12f; 
  public float radio = 6f;        

  public void Llover() {
    if (prefabCaida == null) {
      Debug.LogWarning("ObjectSpawner: falta asignar prefabCaida");
      return;
    }
    for (int i = 0; i < cantidad; i++) {
      Vector3 pos =
        transform.position + new Vector3(Random.Range(-radio, radio), alturaInicio, Random.Range(-radio, radio));
      Instantiate(prefabCaida, pos, Random.rotation);
    }
  }
}