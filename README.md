# 🖐️ AR Hand Tracking - MediaPipe Unity Plugin (Android)

Este proyecto implementa **detección de manos en tiempo real (Hand Landmark Detection)** usando **MediaPipe** en **Unity 2022.3.62f2 LTS**, dirigido a **dispositivos Android compatibles con ARCore**.

---

## ⚙️ Requisitos del sistema

| Componente | Versión recomendada |
|-------------|--------------------|
| **Unity Editor** | 2022.3.62f2 LTS |
| **Sistema operativo** | Windows 10/11 (64-bit) |
| **Dispositivo Android** | Android 8.0 (API 26) o superior |
| **Procesador móvil** | ARM64 compatible con ARCore |
| **Conectividad** | Cable USB y Modo Desarrollador activo |

---

## 🧩 Dependencias principales (Unity Package Manager)

Instala desde **Window → Package Manager** los siguientes paquetes:

| Paquete | Función |
|----------|----------|
| **AR Foundation (>= 5.2.0)** | Marco principal de realidad aumentada. |
| **ARCore XR Plugin (>= 5.2.0)** | Soporte AR para Android. |
| **XR Interaction Toolkit (opcional)** | Interacciones táctiles o con gestos. |
| **Input System (1.7.0 o superior)** | Lectura avanzada de gestos y entradas. |

> ⚠️ Si usas `Input System`, desactiva `Both` en *Project Settings → Player → Active Input Handling* y selecciona solo **Input System Package**.

---

## 📦 Plugin principal

### 🧠 MediaPipe Unity Plugin
Descarga el paquete desde:
👉 [https://github.com/homuler/MediaPipeUnityPlugin/releases](https://github.com/homuler/MediaPipeUnityPlugin/releases)

Archivos recomendados:
- `MediaPipeUnityPlugin-all.zip` → Incluye todos los modelos y bibliotecas necesarias.
- o bien  
  `MediaPipeUnityPlugin-all-stripped.zip` → Versión más ligera (sin símbolos).

Descomprime y copia la carpeta `MediaPipeUnityPlugin` dentro de `Assets/`.

---

## 🧰 Configuración del entorno Android

1. **Instalar SDK, NDK y JDK** (Unity Hub → Installs → Add Modules → Android Build Support)  
   Incluye:
   - Android SDK & NDK
   - OpenJDK

2. **Configurar Build Settings**
   - `File → Build Settings → Android → Switch Platform`

3. **Player Settings → Other Settings**
   - **Scripting Backend:** `IL2CPP`
   - **Target Architectures:** `ARM64`
   - **Graphics APIs:** Solo `OpenGLES3` (❌ desactiva Vulkan)
   - **Minimum API Level:** Android 8.0 (API 26)
   - **Camera Usage Description:**  
     > “Se requiere acceso a la cámara para detección de manos en realidad aumentada.”

---

## 📸 Permisos

Asegúrate de incluir permisos de cámara para Android.  
Si el permiso no se solicita automáticamente, agrega este script a un `GameObject` vacío:

```csharp
using UnityEngine;
using UnityEngine.Android;

public class CameraPermission : MonoBehaviour
{
    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            Permission.RequestUserPermission(Permission.Camera);
    }
}
