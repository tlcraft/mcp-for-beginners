<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:24:13+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "es"
}
-->
# Consumir un servidor desde la extensión AI Toolkit para Visual Studio Code

Cuando construyes un agente de IA, no se trata solo de generar respuestas inteligentes; también es darle a tu agente la capacidad de actuar. Ahí es donde entra el Model Context Protocol (MCP). MCP facilita que los agentes accedan a herramientas y servicios externos de manera consistente. Piensa en ello como conectar tu agente a una caja de herramientas que realmente puede usar.

Supongamos que conectas un agente a tu servidor MCP de calculadora. De repente, tu agente puede realizar operaciones matemáticas simplemente recibiendo un mensaje como “¿Cuánto es 47 por 89?”—sin necesidad de codificar la lógica o crear APIs personalizadas.

## Resumen

Esta lección explica cómo conectar un servidor MCP de calculadora a un agente con la extensión [AI Toolkit](https://aka.ms/AIToolkit) en Visual Studio Code, permitiendo que tu agente realice operaciones matemáticas como suma, resta, multiplicación y división mediante lenguaje natural.

AI Toolkit es una extensión potente para Visual Studio Code que simplifica el desarrollo de agentes. Los ingenieros de IA pueden construir fácilmente aplicaciones de IA desarrollando y probando modelos generativos, ya sea localmente o en la nube. La extensión soporta la mayoría de los modelos generativos principales disponibles hoy en día.

*Nota*: Actualmente, AI Toolkit soporta Python y TypeScript.

## Objetivos de aprendizaje

Al finalizar esta lección, podrás:

- Consumir un servidor MCP a través de AI Toolkit.
- Configurar la configuración de un agente para que pueda descubrir y utilizar las herramientas proporcionadas por el servidor MCP.
- Utilizar las herramientas MCP mediante lenguaje natural.

## Enfoque

Así es como debemos abordar esto a alto nivel:

- Crear un agente y definir su prompt del sistema.
- Crear un servidor MCP con herramientas de calculadora.
- Conectar el Agent Builder al servidor MCP.
- Probar la invocación de herramientas del agente mediante lenguaje natural.

¡Perfecto, ahora que entendemos el flujo, configuremos un agente de IA para aprovechar herramientas externas a través de MCP, mejorando sus capacidades!

## Requisitos previos

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit para Visual Studio Code](https://aka.ms/AIToolkit)

## Ejercicio: Consumir un servidor

En este ejercicio, construirás, ejecutarás y mejorarás un agente de IA con herramientas de un servidor MCP dentro de Visual Studio Code usando AI Toolkit.

### -0- Paso previo, agrega el modelo OpenAI GPT-4o a Mis Modelos

El ejercicio utiliza el modelo **GPT-4o**. Debes agregar este modelo a **Mis Modelos** antes de crear el agente.

![Captura de pantalla de la interfaz de selección de modelos en la extensión AI Toolkit de Visual Studio Code. El encabezado dice "Encuentra el modelo adecuado para tu solución de IA" con un subtítulo que invita a descubrir, probar y desplegar modelos de IA. Debajo, en “Modelos populares,” se muestran seis tarjetas de modelos: DeepSeek-R1 (alojado en GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Pequeño, Rápido) y DeepSeek-R1 (alojado en Ollama). Cada tarjeta incluye opciones para “Agregar” el modelo o “Probar en Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.es.png)

1. Abre la extensión **AI Toolkit** desde la **Barra de Actividades**.
1. En la sección **Catálogo**, selecciona **Modelos** para abrir el **Catálogo de Modelos**. Al seleccionar **Modelos** se abre el **Catálogo de Modelos** en una nueva pestaña del editor.
1. En la barra de búsqueda del **Catálogo de Modelos**, escribe **OpenAI GPT-4o**.
1. Haz clic en **+ Agregar** para añadir el modelo a tu lista de **Mis Modelos**. Asegúrate de seleccionar el modelo que está **Alojado por GitHub**.
1. En la **Barra de Actividades**, confirma que el modelo **OpenAI GPT-4o** aparece en la lista.

### -1- Crear un agente

El **Agent (Prompt) Builder** te permite crear y personalizar tus propios agentes impulsados por IA. En esta sección, crearás un nuevo agente y asignarás un modelo para que impulse la conversación.

![Captura de pantalla de la interfaz del constructor "Calculator Agent" en la extensión AI Toolkit para Visual Studio Code. En el panel izquierdo, el modelo seleccionado es "OpenAI GPT-4o (vía GitHub)." Un prompt del sistema dice "Eres un profesor universitario que enseña matemáticas," y el prompt del usuario dice, "Explícame la ecuación de Fourier en términos simples." Opciones adicionales incluyen botones para agregar herramientas, habilitar MCP Server y seleccionar salida estructurada. Un botón azul “Ejecutar” está en la parte inferior. En el panel derecho, bajo "Comienza con ejemplos," se listan tres agentes de ejemplo: Desarrollador Web (con MCP Server, Simplificador de Segundo Grado e Intérprete de Sueños, cada uno con breves descripciones de sus funciones).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.es.png)

1. Abre la extensión **AI Toolkit** desde la **Barra de Actividades**.
1. En la sección **Herramientas**, selecciona **Agent (Prompt) Builder**. Al seleccionar **Agent (Prompt) Builder** se abre en una nueva pestaña del editor.
1. Haz clic en el botón **+ Nuevo Agente**. La extensión lanzará un asistente de configuración a través de la **Paleta de Comandos**.
1. Ingresa el nombre **Calculator Agent** y presiona **Enter**.
1. En el **Agent (Prompt) Builder**, en el campo **Modelo**, selecciona el modelo **OpenAI GPT-4o (vía GitHub)**.

### -2- Crear un prompt del sistema para el agente

Con el agente creado, es momento de definir su personalidad y propósito. En esta sección, usarás la función **Generar prompt del sistema** para describir el comportamiento esperado del agente—en este caso, un agente calculadora—y que el modelo escriba el prompt del sistema por ti.

![Captura de pantalla de la interfaz "Calculator Agent" en AI Toolkit para Visual Studio Code con una ventana modal abierta titulada "Generar un prompt." La ventana explica que se puede generar una plantilla de prompt compartiendo detalles básicos e incluye un cuadro de texto con el prompt de sistema de ejemplo: "Eres un asistente de matemáticas útil y eficiente. Cuando se te da un problema que involucra aritmética básica, respondes con el resultado correcto." Debajo del cuadro de texto hay botones "Cerrar" y "Generar." En el fondo, parte de la configuración del agente es visible, incluyendo el modelo seleccionado "OpenAI GPT-4o (vía GitHub)" y campos para prompts del sistema y del usuario.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.es.png)

1. En la sección **Prompts**, haz clic en el botón **Generar prompt del sistema**. Este botón abre el generador de prompts que utiliza IA para crear un prompt del sistema para el agente.
1. En la ventana **Generar un prompt**, ingresa lo siguiente: `Eres un asistente de matemáticas útil y eficiente. Cuando se te da un problema que involucra aritmética básica, respondes con el resultado correcto.`
1. Haz clic en el botón **Generar**. Aparecerá una notificación en la esquina inferior derecha confirmando que se está generando el prompt del sistema. Una vez completada la generación, el prompt aparecerá en el campo **Prompt del sistema** del **Agent (Prompt) Builder**.
1. Revisa el **Prompt del sistema** y modifícalo si es necesario.

### -3- Crear un servidor MCP

Ahora que has definido el prompt del sistema de tu agente—que guía su comportamiento y respuestas—es momento de equipar al agente con capacidades prácticas. En esta sección, crearás un servidor MCP de calculadora con herramientas para realizar sumas, restas, multiplicaciones y divisiones. Este servidor permitirá que tu agente realice operaciones matemáticas en tiempo real en respuesta a prompts en lenguaje natural.

![Captura de pantalla de la sección inferior de la interfaz Calculator Agent en la extensión AI Toolkit para Visual Studio Code. Muestra menús desplegables para “Herramientas” y “Salida estructurada,” junto con un menú desplegable etiquetado “Elegir formato de salida” configurado en “texto.” A la derecha, hay un botón etiquetado “+ MCP Server” para agregar un servidor Model Context Protocol. Se muestra un ícono de imagen como marcador de posición sobre la sección de Herramientas.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.es.png)

AI Toolkit cuenta con plantillas para facilitar la creación de tu propio servidor MCP. Usaremos la plantilla de Python para crear el servidor MCP de calculadora.

*Nota*: Actualmente, AI Toolkit soporta Python y TypeScript.

1. En la sección **Herramientas** del **Agent (Prompt) Builder**, haz clic en el botón **+ MCP Server**. La extensión lanzará un asistente de configuración a través de la **Paleta de Comandos**.
1. Selecciona **+ Agregar Servidor**.
1. Selecciona **Crear un nuevo servidor MCP**.
1. Selecciona la plantilla **python-weather**.
1. Selecciona la **Carpeta predeterminada** para guardar la plantilla del servidor MCP.
1. Ingresa el siguiente nombre para el servidor: **Calculator**
1. Se abrirá una nueva ventana de Visual Studio Code. Selecciona **Sí, confío en los autores**.
1. Usando la terminal (**Terminal** > **Nueva Terminal**), crea un entorno virtual: `python -m venv .venv`
1. En la terminal, activa el entorno virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. En la terminal, instala las dependencias: `pip install -e .[dev]`
1. En la vista **Explorador** de la **Barra de Actividades**, expande el directorio **src** y selecciona **server.py** para abrir el archivo en el editor.
1. Reemplaza el código en el archivo **server.py** con el siguiente y guarda:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- Ejecutar el agente con el servidor MCP de calculadora

Ahora que tu agente tiene herramientas, ¡es momento de usarlas! En esta sección, enviarás prompts al agente para probar y validar si el agente utiliza la herramienta adecuada del servidor MCP de calculadora.

![Captura de pantalla de la interfaz Calculator Agent en la extensión AI Toolkit para Visual Studio Code. En el panel izquierdo, bajo “Herramientas,” se ha agregado un servidor MCP llamado local-server-calculator_server, mostrando cuatro herramientas disponibles: add, subtract, multiply y divide. Un distintivo indica que cuatro herramientas están activas. Debajo hay una sección “Salida estructurada” colapsada y un botón azul “Ejecutar.” En el panel derecho, bajo “Respuesta del modelo,” el agente invoca las herramientas multiply y subtract con entradas {"a": 3, "b": 25} y {"a": 75, "b": 20} respectivamente. La “Respuesta de la herramienta” final se muestra como 75.0. Aparece un botón “Ver código” en la parte inferior.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.es.png)

Ejecutarás el servidor MCP de calculadora en tu máquina local de desarrollo a través del **Agent Builder** como cliente MCP.

1. Presiona `F5` para iniciar la depuración del servidor MCP. El **Agent (Prompt) Builder** se abrirá en una nueva pestaña del editor. El estado del servidor es visible en la terminal.
1. En el campo **Prompt del usuario** del **Agent (Prompt) Builder**, ingresa el siguiente prompt: `Compré 3 artículos a $25 cada uno, y luego usé un descuento de $20. ¿Cuánto pagué?`
1. Haz clic en el botón **Ejecutar** para generar la respuesta del agente.
1. Revisa la salida del agente. El modelo debería concluir que pagaste **$55**.
1. Aquí tienes un desglose de lo que debería ocurrir:
    - El agente selecciona las herramientas **multiply** y **subtract** para ayudar en el cálculo.
    - Se asignan los valores `a` y `b` correspondientes para la herramienta **multiply**.
    - Se asignan los valores `a` y `b` correspondientes para la herramienta **subtract**.
    - La respuesta de cada herramienta se muestra en la respectiva **Respuesta de la herramienta**.
    - La salida final del modelo se muestra en la **Respuesta del modelo**.
1. Envía prompts adicionales para seguir probando el agente. Puedes modificar el prompt existente en el campo **Prompt del usuario** haciendo clic y reemplazando el texto.
1. Cuando termines de probar el agente, puedes detener el servidor desde la **terminal** presionando **CTRL/CMD+C** para salir.

## Tarea

Intenta agregar una entrada de herramienta adicional a tu archivo **server.py** (por ejemplo: devolver la raíz cuadrada de un número). Envía prompts adicionales que requieran que el agente utilice tu nueva herramienta (o las herramientas existentes). Asegúrate de reiniciar el servidor para cargar las herramientas recién agregadas.

## Solución

[Solución](./solution/README.md)

## Puntos clave

Los puntos clave de este capítulo son los siguientes:

- La extensión AI Toolkit es un excelente cliente que te permite consumir servidores MCP y sus herramientas.
- Puedes agregar nuevas herramientas a los servidores MCP, ampliando las capacidades del agente para satisfacer requisitos en evolución.
- AI Toolkit incluye plantillas (por ejemplo, plantillas de servidor MCP en Python) para simplificar la creación de herramientas personalizadas.

## Recursos adicionales

- [Documentación de AI Toolkit](https://aka.ms/AIToolkit/doc)

## Qué sigue
- Siguiente: [Pruebas y depuración](../08-testing/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.