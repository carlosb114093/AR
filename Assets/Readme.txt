https://github.com/homuler/MediapipeUnityPlugin?tab=readme-ov-file

https://www.youtube.com/watch?v=URzYU5GthS8

Cómo Utilizar el Plugin MediaPipeUnityPlugin

Aquí te guío sobre cómo integrar y usar este plugin en tu proyecto de Unity:

1. Instalación del Plugin

La forma más sencilla de instalar este plugin es a través del Unity Package Manager usando su enlace Git.

    Abre tu Proyecto Unity: Asegúrate de tener tu proyecto abierto.

    Abre el Package Manager: Ve a Window > Package Manager.

    Añade el Paquete Git: Haz clic en el botón + (más) en la esquina superior izquierda del Package Manager y selecciona Add package from git URL....

    Pega la URL: Introduce la siguiente URL del repositorio de GitHub y presiona Add:

    https://github.com/homuler/MediaPipeUnityPlugin.git?path=Assets/MediaPipe.Unity/Tutorial

    (A veces, simplemente https://github.com/homuler/MediaPipeUnityPlugin.git también funciona, pero la ruta específica puede ser útil para asegurar que se importe la parte correcta del proyecto, aunque lo más común es apuntar a la raíz del repositorio y luego buscar los ejemplos).

    Espera la Importación: Unity descargará e importará el paquete y sus dependencias. Esto puede tardar un poco.

2. Configuración para Detección de Pose (Body Tracking)

El plugin viene con varios ejemplos y prefabricados (prefabs) que te mostrarán cómo usarlo. Para tu caso, el de detección de pose es el más relevante.

    Explora los Ejemplos: Una vez instalado, busca en la carpeta Assets/MediaPipe.Unity/Examples o Assets/MediaPipe.Unity/Tutorial (dependiendo de la versión y cómo se haya estructurado). Deberías encontrar escenas o prefabs relacionados con la detección de poses (por ejemplo, "Pose Tracking" o "Holistic Tracking").

    Configura una Escena de Ejemplo: Abre una de las escenas de ejemplo de detección de pose. Estas escenas suelen tener configurado un WebCamSource o un ImageSource y un componente de PoseTrackingGraph o similar.

        Adaptación a AR Foundation: Los ejemplos probablemente usan una cámara web estándar. Para usar la cámara de AR Foundation, necesitarás integrar la salida de la AR Camera con la entrada de MediaPipe. Esto generalmente implica capturar el RenderTexture de la AR Camera y pasárselo al componente de entrada de MediaPipe. Algunos ejemplos avanzados del plugin ya podrían tener integraciones con AR Foundation, así que busca en la documentación del plugin si hay alguna guía específica.

    Entiende los Puntos Clave: El script principal de pose tracking (por ejemplo, PoseTrackingGraph.cs o un script similar) te dará acceso a una lista de puntos clave (landmarks). Estos puntos representan las articulaciones y otras partes importantes del cuerpo (hombros, codos, muñecas, caderas, rodillas, tobillos, etc.).

3. Integración con tu Lógica de Tatuajes

Una vez que el plugin te proporciona las coordenadas 2D o 3D de los puntos clave del cuerpo, puedes aplicar tu lógica para el tatuaje:

    Accede a los Resultados: En tu propio script de C#, haz referencia al componente de MediaPipe que está realizando la detección de pose. Este componente expondrá los resultados de los landmarks que puedes leer en el método Update().

    Selección de Parte del Cuerpo:

        Identificación Automática: Puedes escribir lógica que, basándose en un conjunto de landmarks visibles y su disposición, determine qué parte del cuerpo está siendo escaneada (por ejemplo, "si veo los puntos de la muñeca, codo y hombro, entonces es un brazo").

        Selección Manual: También puedes ofrecer al usuario la opción de seleccionar manualmente la parte del cuerpo que desea "tatuar", y tu lógica entonces solo buscará los landmarks correspondientes a esa área.

    Cálculo de Posición y Orientación del Tatuaje:

        Para un tatuaje en el brazo, puedes tomar los landmarks de la muñeca y el codo. Calcula el punto medio entre ellos para la posición del tatuaje. La línea formada por estos dos puntos te dará la dirección para orientar el tatuaje.

        Para otras partes del cuerpo, usa los landmarks relevantes (por ejemplo, cadera y rodilla para el muslo, o puntos del cuello y hombros para la espalda).

    Renderizado del Tatuaje (Decal Projection):

        Crea un Objeto 3D (como un Quad o un Plane) en tu escena Unity para cada diseño de tatuaje. Asegúrate de que su Material use un shader que permita la transparencia (por ejemplo, Universal Render Pipeline/2D/Sprite-Lit-Default o Standard con Rendering Mode en Fade o Transparent).

        Ajusta la Posición y Rotación: En cada frame, actualiza la posición y la rotación de tu objeto de tatuaje para que siga la parte del cuerpo detectada.

        Efecto Decal: Para que el tatuaje se "pegue" a la forma del cuerpo, puedes investigar el uso de Decals en Unity, especialmente si estás usando el Universal Render Pipeline (URP) o High Definition Render Pipeline (HDRP). Los sistemas de Decals permiten proyectar una textura (tu tatuaje) sobre otras geometrías de la escena de forma que se envuelve y se deforma con la superficie.

Consideraciones Finales

    Rendimiento: La detección de pose en tiempo real es intensiva. Asegúrate de probar tu aplicación en dispositivos móviles para verificar el rendimiento. Podrías necesitar ajustar la calidad de los modelos de MediaPipe o la resolución de la cámara si el rendimiento no es el óptimo.

    Precisión: La precisión del seguimiento puede variar según las condiciones de iluminación y la visibilidad de las articulaciones. Ten esto en cuenta para la experiencia del usuario.

Este plugin es una herramienta fantástica. ¡Te deseo mucho éxito en tu proyecto de juego de realidad aumentada! Si tienes más dudas al momento de implementarlo, no dudes en preguntar.