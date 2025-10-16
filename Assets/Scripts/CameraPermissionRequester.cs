using UnityEngine;
using UnityEngine.Android;

public class CameraPermissionRequester : MonoBehaviour
{
    private const string CameraPermission = "android.permission.CAMERA";

    // Cambia el tipo al que acabas de modificar
    private Mediapipe.Unity.Sample.FaceDetection.FaceDetectorRunner faceDetectorRunner; 

    void Awake()
    {
        // Obtener el componente al inicio
        faceDetectorRunner = GetComponent<Mediapipe.Unity.Sample.FaceDetection.FaceDetectorRunner>(); 
        if (faceDetectorRunner == null)
        {
            Debug.LogError("No se encontró el FaceDetectorRunner en este objeto. ¿Están ambos scripts en 'Solution'?");
            enabled = false; // Desactiva el script si no encuentra el controlador
            return;
        }

        CheckAndRequestPermission();
    }

    private void CheckAndRequestPermission()
    {
        if (Permission.HasUserAuthorizedPermission(CameraPermission))
        {
            Debug.Log("Permiso de cámara concedido previamente. Iniciando MediaPipe.");
            InitializeWebcam();
        }
        else
        {
            Debug.Log("Solicitando permiso de cámara...");
            
            // Suscripción corregida del error CS0079
            var callbacks = new PermissionCallbacks();
            callbacks.PermissionGranted += OnPermissionGranted;
            callbacks.PermissionDenied += OnPermissionDenied;
            callbacks.PermissionDeniedAndDontAskAgain += OnPermissionDeniedAndDontAskAgain;

            Permission.RequestUserPermission(CameraPermission, callbacks);
        }
    }

    private void OnPermissionGranted(string permissionName)
    {
        if (permissionName == CameraPermission)
        {
            Debug.Log("✅ Permiso de cámara concedido por el usuario.");
            InitializeWebcam();
        }
    }

    private void OnPermissionDenied(string permissionName)
    {
        if (permissionName == CameraPermission)
        {
            Debug.LogError("❌ Permiso de cámara denegado. No se podrá iniciar MediaPipe.");
        }
    }
    
    private void OnPermissionDeniedAndDontAskAgain(string permissionName)
    {
        if (permissionName == CameraPermission)
        {
            Debug.LogError("❌ Permiso denegado permanentemente. Habilitar manualmente.");
        }
    }

    private void InitializeWebcam()
    {
        if (faceDetectorRunner != null)
        {
            // Llama al método que inicia el coroutine Run() y, por ende, la cámara.
            faceDetectorRunner.StartFaceDetectionProcess();
        }
    }
}