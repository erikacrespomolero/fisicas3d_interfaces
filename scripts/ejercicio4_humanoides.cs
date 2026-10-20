using UnityEngine;
public class HumanoideObserverLook : MonoBehaviour {
  public Transform escudoObjetivo;   
  public Transform objetoOrientacion; 
  private Rigidbody rb;
  void Awake() {
    rb = GetComponent<Rigidbody>();
  }
  void OnEnable() {
    NotifierReference.OnCuboAproximado += Reaccionar;
  }
  void OnDisable() {
    NotifierReference.OnCuboAproximado -= Reaccionar;
  }
  private void Reaccionar() {
    if (CompareTag("HumanoideTipo1")) {
      rb.position = escudoObjetivo.position;
    } else if (CompareTag("HumanoideTipo2") && objetoOrientacion != null) {
      Vector3 direccion = objetoOrientacion.position - rb.position;
      direccion.y = 0f;
      if (direccion.sqrMagnitude > 0.001f)
        rb.rotation = Quaternion.LookRotation(direccion);
    }
  }
}