<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:20:36+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "es"
}
-->
# Consumiendo un servidor desde la extensión AI Toolkit para Visual Studio Code

Cuando construyes un agente de IA, no se trata solo de generar respuestas inteligentes; también se trata de darle a tu agente la capacidad de actuar. Ahí es donde entra el Model Context Protocol (MCP). MCP facilita que los agentes accedan a herramientas y servicios externos de manera consistente. Piensa en ello como conectar tu agente a una caja de herramientas que realmente puede usar.

Supongamos que conectas un agente a tu servidor MCP de calculadora. De repente, tu agente puede realizar operaciones matemáticas simplemente recibiendo un mensaje como “¿Cuánto es 47 por 89?”—sin necesidad de codificar la lógica o crear APIs personalizadas.

## Resumen

Esta lección explica cómo conectar un servidor MCP de calculadora a un agente con la extensión [AI Toolkit](https://aka.ms/AIToolkit) en Visual Studio Code, permitiendo que tu agente realice operaciones matemáticas como suma, resta, multiplicación y división mediante lenguaje natural.

AI Toolkit es una extensión poderosa para Visual Studio Code que facilita el desarrollo de agentes. Los ingenieros de IA pueden crear aplicaciones de IA fácilmente desarrollando y probando modelos generativos de IA, ya sea localmente o en la nube. La extensión soporta la mayoría de los modelos generativos principales disponibles hoy en día.

*Nota*: AI Toolkit actualmente soporta Python y TypeScript.

## Objetivos de aprendizaje

Al finalizar esta lección, podrás:

- Consumir un servidor MCP a través de AI Toolkit.
- Configurar la configuración de un agente para habilitar que descubra y utilice herramientas proporcionadas por el servidor MCP.
- Utilizar herramientas MCP mediante lenguaje natural.

## Enfoque

Así es como debemos abordar esto a un nivel general:

- Crear un agente y definir su prompt del sistema.
- Crear un servidor MCP con herramientas de calculadora.
- Conectar el Agent Builder al servidor MCP.
- Probar la invocación de herramientas del agente mediante lenguaje natural.

¡Perfecto, ahora que entendemos el flujo, configuremos un agente de IA para aprovechar herramientas externas a través de MCP, ampliando sus capacidades!

## Requisitos previos

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit para Visual Studio Code](https://aka.ms/AIToolkit)

## Ejercicio: Consumiendo un servidor

En este ejercicio, construirás, ejecutarás y mejorarás un agente de IA con herramientas de un servidor MCP dentro de Visual Studio Code usando AI Toolkit.

### -0- Paso previo, añade el modelo OpenAI GPT-4o a Mis Modelos

El ejercicio utiliza el modelo **GPT-4o**. Debes añadir el modelo a **Mis Modelos** antes de crear el agente.

![Captura de pantalla de la interfaz de selección de modelos en la extensión AI Toolkit de Visual Studio Code. El título dice "Encuentra el modelo adecuado para tu solución de IA" con un subtítulo que anima a descubrir, probar y desplegar modelos de IA. Debajo, bajo “Modelos Populares,” se muestran seis tarjetas de modelos: DeepSeek-R1 (alojado en GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Pequeño, Rápido), y DeepSeek-R1 (alojado en Ollama). Cada tarjeta incluye opciones para “Añadir” el modelo o “Probar en Playground](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.es.png)

1. Abre la extensión **AI Toolkit** desde la **Barra de Actividades**.
1. En la sección **Catálogo**, selecciona **Modelos** para abrir el **Catálogo de Modelos**. Al seleccionar **Modelos** se abre el **Catálogo de Modelos** en una nueva pestaña del editor.
1. En la barra de búsqueda del **Catálogo de Modelos**, escribe **OpenAI GPT-4o**.
1. Haz clic en **+ Añadir** para agregar el modelo a tu lista de **Mis Modelos**. Asegúrate de seleccionar el modelo que está **Alojado en GitHub**.
1. En la **Barra de Actividades**, confirma que el modelo **OpenAI GPT-4o** aparece en la lista.

### -1- Crear un agente

El **Agent (Prompt) Builder** te permite crear y personalizar tus propios agentes impulsados por IA. En esta sección, crearás un nuevo agente y asignarás un modelo para potenciar la conversación.

![Captura de pantalla de la interfaz del constructor "Calculator Agent" en la extensión AI Toolkit para Visual Studio Code. En el panel izquierdo, el modelo seleccionado es "OpenAI GPT-4o (vía GitHub)." Un prompt del sistema dice "Eres un profesor universitario que enseña matemáticas," y el prompt de usuario dice, "Explícame la ecuación de Fourier en términos simples." Opciones adicionales incluyen botones para añadir herramientas, habilitar MCP Server y seleccionar salida estructurada. Un botón azul “Ejecutar” está en la parte inferior. En el panel derecho, bajo "Comienza con ejemplos," se listan tres agentes de muestra: Desarrollador Web (con MCP Server, Simplificador de Segundo Grado e Intérprete de Sueños, cada uno con breves descripciones de sus funciones.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.es.png)

1. Abre la extensión **AI Toolkit** desde la **Barra de Actividades**.
1. En la sección **Herramientas**, selecciona **Agent (Prompt) Builder**. Al seleccionar **Agent (Prompt) Builder** se abre en una nueva pestaña del editor.
1. Haz clic en el botón **+ Nuevo Agente**. La extensión lanzará un asistente de configuración mediante la **Paleta de Comandos**.
1. Ingresa el nombre **Calculator Agent** y presiona **Enter**.
1. En el **Agent (Prompt) Builder**, para el campo **Modelo**, selecciona el modelo **OpenAI GPT-4o (vía GitHub)**.

### -2- Crear un prompt del sistema para el agente

Con el agente creado, es hora de definir su personalidad y propósito. En esta sección, usarás la función **Generar prompt del sistema** para describir el comportamiento esperado del agente—en este caso, un agente calculadora—y que el modelo genere el prompt del sistema por ti.

![Captura de pantalla de la interfaz "Calculator Agent" en AI Toolkit para Visual Studio Code con una ventana modal abierta titulada "Generar un prompt." La ventana explica que se puede generar una plantilla de prompt compartiendo detalles básicos e incluye un cuadro de texto con el prompt de sistema de ejemplo: "Eres un asistente de matemáticas útil y eficiente. Cuando se te presenta un problema que involucra aritmética básica, respondes con el resultado correcto." Debajo del cuadro están los botones "Cerrar" y "Generar". En el fondo, se ve parte de la configuración del agente, incluyendo el modelo seleccionado "OpenAI GPT-4o (vía GitHub)" y campos para prompts del sistema y usuario.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.es.png)

1. En la sección **Prompts**, haz clic en el botón **Generar prompt del sistema**. Este botón abre el generador de prompts que usa IA para crear un prompt del sistema para el agente.
1. En la ventana **Generar un prompt**, ingresa lo siguiente: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Haz clic en el botón **Generar**. Aparecerá una notificación en la esquina inferior derecha confirmando que se está generando el prompt del sistema. Una vez finalizada la generación, el prompt aparecerá en el campo **Prompt del sistema** del **Agent (Prompt) Builder**.
1. Revisa el **Prompt del sistema** y modifícalo si es necesario.

### -3- Crear un servidor MCP

Ahora que definiste el prompt del sistema de tu agente—que guía su comportamiento y respuestas—es momento de dotar al agente con capacidades prácticas. En esta sección, crearás un servidor MCP de calculadora con herramientas para realizar sumas, restas, multiplicaciones y divisiones. Este servidor permitirá que tu agente realice operaciones matemáticas en tiempo real en respuesta a prompts en lenguaje natural.

!["Captura de pantalla de la sección inferior de la interfaz Calculator Agent en la extensión AI Toolkit para Visual Studio Code. Muestra menús desplegables para “Herramientas” y “Salida estructurada,” junto con un menú desplegable etiquetado “Elegir formato de salida” configurado en “texto.” A la derecha, hay un botón llamado “+ MCP Server” para añadir un servidor Model Context Protocol. Se muestra un icono de imagen como marcador de posición sobre la sección Herramientas.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.es.png)

AI Toolkit incluye plantillas para facilitar la creación de tu propio servidor MCP. Usaremos la plantilla de Python para crear el servidor MCP de calculadora.

*Nota*: AI Toolkit actualmente soporta Python y TypeScript.

1. En la sección **Herramientas** del **Agent (Prompt) Builder**, haz clic en el botón **+ MCP Server**. La extensión lanzará un asistente de configuración mediante la **Paleta de Comandos**.
1. Selecciona **+ Añadir Servidor**.
1. Selecciona **Crear un nuevo servidor MCP**.
1. Selecciona **python-weather** como plantilla.
1. Selecciona **Carpeta por defecto** para guardar la plantilla del servidor MCP.
1. Ingresa el siguiente nombre para el servidor: **Calculator**
1. Se abrirá una nueva ventana de Visual Studio Code. Selecciona **Sí, confío en los autores**.
1. Usando la terminal (**Terminal** > **Nueva Terminal**), crea un entorno virtual: `python -m venv .venv`
1. En la terminal, activa el entorno virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. En la terminal, instala las dependencias: `pip install -e .[dev]`
1. En la vista **Explorador** de la **Barra de Actividades**, expande el directorio **src** y selecciona **server.py** para abrir el archivo en el editor.
1. Reemplaza el código en el archivo **server.py** con lo siguiente y guarda:

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

Ahora que tu agente tiene herramientas, ¡es hora de usarlas! En esta sección, enviarás prompts al agente para probar y validar si el agente usa la herramienta adecuada del servidor MCP de calculadora.

![Captura de pantalla de la interfaz Calculator Agent en la extensión AI Toolkit para Visual Studio Code. En el panel izquierdo, bajo “Herramientas,” se añadió un servidor MCP llamado local-server-calculator_server, mostrando cuatro herramientas disponibles: add, subtract, multiply y divide. Un distintivo indica que cuatro herramientas están activas. Debajo hay una sección “Salida estructurada” colapsada y un botón azul “Ejecutar.” En el panel derecho, bajo “Respuesta del modelo,” el agente invoca las herramientas multiply y subtract con entradas {"a": 3, "b": 25} y {"a": 75, "b": 20} respectivamente. La “Respuesta de la herramienta” final se muestra como 75.0. Aparece un botón “Ver Código” en la parte inferior.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.es.png)

Ejecutarás el servidor MCP de calculadora en tu máquina local de desarrollo a través del **Agent Builder** como cliente MCP.

1. Presiona `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Compré 3 artículos a $25 cada uno, y luego usé un descuento de $20. ¿Cuánto pagué?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` se asignan valores para la herramienta **subtract**.
    - La respuesta de cada herramienta se muestra en la respectiva **Respuesta de la herramienta**.
    - La salida final del modelo aparece en la **Respuesta del modelo**.
1. Envía prompts adicionales para seguir probando el agente. Puedes modificar el prompt existente en el campo **Prompt de usuario** haciendo clic y reemplazando el texto.
1. Cuando termines de probar el agente, puedes detener el servidor desde la **terminal** con **CTRL/CMD+C** para salir.

## Tarea

Intenta añadir una herramienta adicional en tu archivo **server.py** (por ejemplo: devolver la raíz cuadrada de un número). Envía prompts adicionales que requieran que el agente use tu nueva herramienta (o herramientas existentes). Asegúrate de reiniciar el servidor para cargar las herramientas recién añadidas.

## Solución

[Solution](./solution/README.md)

## Puntos clave

Los puntos clave de este capítulo son los siguientes:

- La extensión AI Toolkit es un excelente cliente que te permite consumir servidores MCP y sus herramientas.
- Puedes añadir nuevas herramientas a los servidores MCP, ampliando las capacidades del agente para adaptarse a requisitos en evolución.
- AI Toolkit incluye plantillas (por ejemplo, plantillas de servidores MCP en Python) para simplificar la creación de herramientas personalizadas.

## Recursos adicionales

- [Documentación de AI Toolkit](https://aka.ms/AIToolkit/doc)

## Qué sigue

Siguiente: [Lección 4 Implementación práctica](/04-PracticalImplementation/README.md)

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por un humano. No nos hacemos responsables por malentendidos o interpretaciones erróneas que puedan derivarse del uso de esta traducción.