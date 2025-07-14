<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T08:50:22+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "es"
}
-->
# Servidor MCP de Clima

Este es un ejemplo de Servidor MCP en Python que implementa herramientas meteorológicas con respuestas simuladas. Puede usarse como base para tu propio Servidor MCP. Incluye las siguientes características:

- **Herramienta de Clima**: Una herramienta que proporciona información meteorológica simulada según la ubicación dada.
- **Herramienta de Clonación Git**: Una herramienta que clona un repositorio git en una carpeta especificada.
- **Herramienta para Abrir en VS Code**: Una herramienta que abre una carpeta en VS Code o VS Code Insiders.
- **Conexión con Agent Builder**: Una función que permite conectar el servidor MCP con Agent Builder para pruebas y depuración.
- **Depuración en [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Una función que permite depurar el Servidor MCP usando MCP Inspector.

## Comenzar con la plantilla del Servidor MCP de Clima

> **Requisitos previos**
>
> Para ejecutar el Servidor MCP en tu máquina de desarrollo local, necesitarás:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (Requerido para la herramienta git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) o [VS Code Insiders](https://code.visualstudio.com/insiders/) (Requerido para la herramienta open_in_vscode)
> - (*Opcional - si prefieres uv*) [uv](https://github.com/astral-sh/uv)
> - [Extensión de Depurador de Python](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Preparar el entorno

Hay dos formas de configurar el entorno para este proyecto. Puedes elegir la que prefieras.

> Nota: Recarga VSCode o la terminal para asegurarte de que se use el python del entorno virtual después de crearlo.

| Enfoque | Pasos |
| -------- | ----- |
| Usando `uv` | 1. Crear entorno virtual: `uv venv` <br>2. Ejecutar el comando de VSCode "***Python: Select Interpreter***" y seleccionar el python del entorno virtual creado <br>3. Instalar dependencias (incluyendo dependencias de desarrollo): `uv pip install -r pyproject.toml --extra dev` |
| Usando `pip` | 1. Crear entorno virtual: `python -m venv .venv` <br>2. Ejecutar el comando de VSCode "***Python: Select Interpreter***" y seleccionar el python del entorno virtual creado<br>3. Instalar dependencias (incluyendo dependencias de desarrollo): `pip install -e .[dev]` |

Después de configurar el entorno, puedes ejecutar el servidor en tu máquina local a través de Agent Builder como cliente MCP para comenzar:
1. Abre el panel de depuración de VS Code. Selecciona `Debug in Agent Builder` o presiona `F5` para iniciar la depuración del servidor MCP.
2. Usa AI Toolkit Agent Builder para probar el servidor con [este prompt](../../../../../../../../../../open_prompt_builder). El servidor se conectará automáticamente al Agent Builder.
3. Haz clic en `Run` para probar el servidor con el prompt.

**¡Felicidades!** Has ejecutado con éxito el Servidor MCP de Clima en tu máquina local a través de Agent Builder como cliente MCP.  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Qué incluye la plantilla

| Carpeta / Archivo | Contenido                                   |
| ----------------- | ------------------------------------------ |
| `.vscode`         | Archivos de VSCode para depuración         |
| `.aitk`           | Configuraciones para AI Toolkit             |
| `src`             | Código fuente del servidor MCP de clima    |

## Cómo depurar el Servidor MCP de Clima

> Notas:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) es una herramienta visual para desarrolladores para probar y depurar servidores MCP.
> - Todos los modos de depuración soportan puntos de interrupción, por lo que puedes añadirlos en el código de implementación de las herramientas.

## Herramientas disponibles

### Herramienta de Clima  
La herramienta `get_weather` proporciona información meteorológica simulada para una ubicación especificada.

| Parámetro | Tipo   | Descripción                                      |
| --------- | ------ | ------------------------------------------------|
| `location` | string | Ubicación para obtener el clima (ej. nombre de ciudad, estado o coordenadas) |

### Herramienta de Clonación Git  
La herramienta `git_clone_repo` clona un repositorio git en una carpeta especificada.

| Parámetro      | Tipo   | Descripción                                  |
| -------------- | ------ | --------------------------------------------|
| `repo_url`     | string | URL del repositorio git a clonar             |
| `target_folder`| string | Ruta de la carpeta donde se clonará el repositorio |

La herramienta devuelve un objeto JSON con:  
- `success`: Booleano que indica si la operación fue exitosa  
- `target_folder` o `error`: La ruta del repositorio clonado o un mensaje de error  

### Herramienta para Abrir en VS Code  
La herramienta `open_in_vscode` abre una carpeta en la aplicación VS Code o VS Code Insiders.

| Parámetro     | Tipo    | Descripción                                  |
| ------------- | ------- | --------------------------------------------|
| `folder_path` | string  | Ruta de la carpeta a abrir                    |
| `use_insiders`| boolean (opcional) | Indica si se debe usar VS Code Insiders en lugar de VS Code normal |

La herramienta devuelve un objeto JSON con:  
- `success`: Booleano que indica si la operación fue exitosa  
- `message` o `error`: Un mensaje de confirmación o un mensaje de error  

## Modo de depuración | Descripción | Pasos para depurar  
| ---------------- | ----------- | ------------------- |
| Agent Builder    | Depura el servidor MCP en Agent Builder vía AI Toolkit. | 1. Abre el panel de depuración de VS Code. Selecciona `Debug in Agent Builder` y presiona `F5` para iniciar la depuración del servidor MCP.<br>2. Usa AI Toolkit Agent Builder para probar el servidor con [este prompt](../../../../../../../../../../open_prompt_builder). El servidor se conectará automáticamente al Agent Builder.<br>3. Haz clic en `Run` para probar el servidor con el prompt. |
| MCP Inspector   | Depura el servidor MCP usando MCP Inspector. | 1. Instala [Node.js](https://nodejs.org/)<br> 2. Configura Inspector: `cd inspector` && `npm install` <br> 3. Abre el panel de depuración de VS Code. Selecciona `Debug SSE in Inspector (Edge)` o `Debug SSE in Inspector (Chrome)`. Presiona F5 para iniciar la depuración.<br> 4. Cuando MCP Inspector se abra en el navegador, haz clic en el botón `Connect` para conectar este servidor MCP.<br> 5. Luego puedes `List Tools`, seleccionar una herramienta, ingresar parámetros y `Run Tool` para depurar tu código del servidor.<br> |

## Puertos predeterminados y personalizaciones

| Modo de depuración | Puertos                  | Definiciones                  | Personalizaciones                                                                 | Nota |
| ------------------ | ------------------------ | -----------------------------| -------------------------------------------------------------------------------- | -----|
| Agent Builder      | 3001                     | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Edita [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) para cambiar los puertos mencionados. | N/A  |
| MCP Inspector      | 3001 (Servidor); 5173 y 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Edita [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) para cambiar los puertos mencionados. | N/A  |

## Comentarios

Si tienes algún comentario o sugerencia para esta plantilla, por favor abre un issue en el [repositorio AI Toolkit en GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.