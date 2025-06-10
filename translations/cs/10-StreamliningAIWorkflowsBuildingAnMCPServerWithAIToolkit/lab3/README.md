<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd8da3f75addcef453fe11f02a270217",
  "translation_date": "2025-06-10T06:18:01+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/README.md",
  "language_code": "cs"
}
-->
# 🔧 Module 3: Desarrollo Avanzado de MCP con AI Toolkit

![Duration](https://img.shields.io/badge/Duration-20_minutes-blue?style=flat-square)
![AI Toolkit](https://img.shields.io/badge/AI_Toolkit-Required-orange?style=flat-square)
![Python](https://img.shields.io/badge/Python-3.10+-green?style=flat-square)
![MCP SDK](https://img.shields.io/badge/MCP_SDK-1.9.3-purple?style=flat-square)
![Inspector](https://img.shields.io/badge/MCP_Inspector-0.14.0-blue?style=flat-square)

## 🎯 Objetivos de Aprendizaje

Al finalizar este laboratorio, podrás:

- ✅ Crear servidores MCP personalizados usando AI Toolkit  
- ✅ Configurar y utilizar la última versión del MCP Python SDK (v1.9.3)  
- ✅ Configurar y usar MCP Inspector para depuración  
- ✅ Depurar servidores MCP tanto en Agent Builder como en Inspector  
- ✅ Comprender flujos de trabajo avanzados para desarrollo de servidores MCP  

## 📋 Requisitos Previos

- Haber completado el Laboratorio 2 (Fundamentos de MCP)  
- VS Code con la extensión AI Toolkit instalada  
- Entorno Python 3.10+  
- Node.js y npm para configurar Inspector  

## 🏗️ Lo Que Vas a Construir

En este laboratorio crearás un **Servidor MCP de Clima** que demostrará:  
- Implementación personalizada de un servidor MCP  
- Integración con AI Toolkit Agent Builder  
- Flujos de trabajo profesionales de depuración  
- Uso moderno del SDK MCP  

---

## 🔧 Resumen de Componentes Clave

### 🐍 MCP Python SDK  
El SDK Python del Protocolo de Contexto de Modelo proporciona la base para construir servidores MCP personalizados. Usarás la versión 1.9.3 con capacidades mejoradas de depuración.

### 🔍 MCP Inspector  
Una herramienta potente para depuración que ofrece:  
- Monitoreo en tiempo real del servidor  
- Visualización de la ejecución de herramientas  
- Inspección de solicitudes y respuestas de red  
- Entorno interactivo de pruebas  

---

## 📖 Implementación Paso a Paso

### Paso 1: Crear un WeatherAgent en Agent Builder

1. **Lanza Agent Builder** en VS Code a través de la extensión AI Toolkit  
2. **Crea un nuevo agente** con la siguiente configuración:  
   - Nombre del agente: `WeatherAgent`  

![Agent Creation](../../../../translated_images/Agent.c9c33f6a412b4cdedfb973fe5448bdb33de3f400055603111b875610e9b917ab.cs.png)

### Paso 2: Inicializar el Proyecto del Servidor MCP

1. **Navega a Tools** → **Add Tool** en Agent Builder  
2. **Selecciona "MCP Server"** de las opciones disponibles  
3. **Elige "Create A new MCP Server"**  
4. **Selecciona la plantilla `python-weather`**  
5. **Nombra tu servidor:** `weather_mcp`  

![Python Template Selection](../../../../translated_images/Pythontemplate.9d0a2913c6491500bd673430f024dc44676af2808a27b5da9dcc0eb7063adc28.cs.png)

### Paso 3: Abrir y Examinar el Proyecto

1. **Abre el proyecto generado** en VS Code  
2. **Revisa la estructura del proyecto:**  
   ```
   weather_mcp/
   ├── src/
   │   ├── __init__.py
   │   └── server.py
   ├── inspector/
   │   ├── package.json
   │   └── package-lock.json
   ├── .vscode/
   │   ├── launch.json
   │   └── tasks.json
   ├── pyproject.toml
   └── README.md
   ```

### Paso 4: Actualizar al Último MCP SDK

> **🔍 ¿Por qué actualizar?** Queremos usar el último MCP SDK (v1.9.3) y el servicio Inspector (0.14.0) para aprovechar nuevas funcionalidades y mejorar la depuración.

#### 4a. Actualizar Dependencias de Python

**Edita `pyproject.toml`:** update [./code/weather_mcp/pyproject.toml](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/pyproject.toml)


#### 4b. Update Inspector Configuration

**Edit `inspector/package.json`:** update [./code/weather_mcp/inspector/package.json](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/inspector/package.json)

#### 4c. Update Inspector Dependencies

**Edit `inspector/package-lock.json`:** update [./code/weather_mcp/inspector/package-lock.json](../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/inspector/package-lock.json)

> **📝 Note:** This file contains extensive dependency definitions. Below is the essential structure - the full content ensures proper dependency resolution.


> **⚡ Full Package Lock:** The complete package-lock.json contains ~3000 lines of dependency definitions. The above shows the key structure - use the provided file for complete dependency resolution.

### Step 5: Configure VS Code Debugging

*Note: Please copy the file in the specified path to replace the corresponding local file*

#### 5a. Update Launch Configuration

**Edit `.vscode/launch.json`:**

```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": "Attach to Local MCP",
      "type": "debugpy",
      "request": "attach",
      "connect": {
        "host": "localhost",
        "port": 5678
      },
      "presentation": {
        "hidden": true
      },
      "internalConsoleOptions": "neverOpen",
      "postDebugTask": "Terminate All Tasks"
    },
    {
      "name": "Launch Inspector (Edge)",
      "type": "msedge",
      "request": "launch",
      "url": "http://localhost:6274?timeout=60000&serverUrl=http://localhost:3001/sse#tools",
      "cascadeTerminateToConfigurations": [
        "Attach to Local MCP"
      ],
      "presentation": {
        "hidden": true
      },
      "internalConsoleOptions": "neverOpen"
    },
    {
      "name": "Launch Inspector (Chrome)",
      "type": "chrome",
      "request": "launch",
      "url": "http://localhost:6274?timeout=60000&serverUrl=http://localhost:3001/sse#tools",
      "cascadeTerminateToConfigurations": [
        "Attach to Local MCP"
      ],
      "presentation": {
        "hidden": true
      },
      "internalConsoleOptions": "neverOpen"
    }
  ],
  "compounds": [
    {
      "name": "Debug in Agent Builder",
      "configurations": [
        "Attach to Local MCP"
      ],
      "preLaunchTask": "Open Agent Builder",
    },
    {
      "name": "Debug in Inspector (Edge)",
      "configurations": [
        "Launch Inspector (Edge)",
        "Attach to Local MCP"
      ],
      "preLaunchTask": "Start MCP Inspector",
      "stopAll": true
    },
    {
      "name": "Debug in Inspector (Chrome)",
      "configurations": [
        "Launch Inspector (Chrome)",
        "Attach to Local MCP"
      ],
      "preLaunchTask": "Start MCP Inspector",
      "stopAll": true
    }
  ]
}
```

**Edita `.vscode/tasks.json`:**

```
{
  "version": "2.0.0",
  "tasks": [
    {
      "label": "Start MCP Server",
      "type": "shell",
      "command": "python -m debugpy --listen 127.0.0.1:5678 src/__init__.py sse",
      "isBackground": true,
      "options": {
        "cwd": "${workspaceFolder}",
        "env": {
          "PORT": "3001"
        }
      },
      "problemMatcher": {
        "pattern": [
          {
            "regexp": "^.*$",
            "file": 0,
            "location": 1,
            "message": 2
          }
        ],
        "background": {
          "activeOnStart": true,
          "beginsPattern": ".*",
          "endsPattern": "Application startup complete|running"
        }
      }
    },
    {
      "label": "Start MCP Inspector",
      "type": "shell",
      "command": "npm run dev:inspector",
      "isBackground": true,
      "options": {
        "cwd": "${workspaceFolder}/inspector",
        "env": {
          "CLIENT_PORT": "6274",
          "SERVER_PORT": "6277",
        }
      },
      "problemMatcher": {
        "pattern": [
          {
            "regexp": "^.*$",
            "file": 0,
            "location": 1,
            "message": 2
          }
        ],
        "background": {
          "activeOnStart": true,
          "beginsPattern": "Starting MCP inspector",
          "endsPattern": "Proxy server listening on port"
        }
      },
      "dependsOn": [
        "Start MCP Server"
      ]
    },
    {
      "label": "Open Agent Builder",
      "type": "shell",
      "command": "echo ${input:openAgentBuilder}",
      "presentation": {
        "reveal": "never"
      },
      "dependsOn": [
        "Start MCP Server"
      ],
    },
    {
      "label": "Terminate All Tasks",
      "command": "echo ${input:terminate}",
      "type": "shell",
      "problemMatcher": []
    }
  ],
  "inputs": [
    {
      "id": "openAgentBuilder",
      "type": "command",
      "command": "ai-mlstudio.agentBuilder",
      "args": {
        "initialMCPs": [ "local-server-weather_mcp" ],
        "triggeredFrom": "vsc-tasks"
      }
    },
    {
      "id": "terminate",
      "type": "command",
      "command": "workbench.action.tasks.terminate",
      "args": "terminateAll"
    }
  ]
}
```


---

## 🚀 Ejecutar y Probar tu Servidor MCP

### Paso 6: Instalar Dependencias

Después de hacer los cambios de configuración, ejecuta los siguientes comandos:

**Instalar dependencias de Python:**  
```bash
uv sync
```

**Instalar dependencias de Inspector:**  
```bash
cd inspector
npm install
```

### Paso 7: Depurar con Agent Builder

1. **Presiona F5** o usa la configuración **"Debug in Agent Builder"**  
2. **Selecciona la configuración compuesta** en el panel de depuración  
3. **Espera a que el servidor inicie** y se abra Agent Builder  
4. **Prueba tu servidor MCP de clima** con consultas en lenguaje natural  

Ejemplo de entrada:

SYSTEM_PROMPT

```
You are my weather assistant
```

USER_PROMPT

```
How's the weather like in Seattle
```

![Agent Builder Debug Result](../../../../translated_images/Result.6ac570f7d2b1d5389c561ab0566970fe0f13e75bdd976b6a7f0270bc715d07f8.cs.png)

### Paso 8: Depurar con MCP Inspector

1. **Usa la configuración "Debug in Inspector"** (Edge o Chrome)  
2. **Abre la interfaz de Inspector** en `http://localhost:6274`  
3. **Explora el entorno interactivo de pruebas:**  
   - Visualiza las herramientas disponibles  
   - Prueba la ejecución de herramientas  
   - Monitorea solicitudes de red  
   - Depura las respuestas del servidor  

![MCP Inspector Interface](../../../../translated_images/Inspector.5672415cd02fe8731774586cc0a1083e3275d2f8491602aecc8ac4d61f2c0d57.cs.png)

---

## 🎯 Resultados Clave de Aprendizaje

Al completar este laboratorio, has:

- [x] **Creado un servidor MCP personalizado** usando plantillas de AI Toolkit  
- [x] **Actualizado al último MCP SDK** (v1.9.3) para funcionalidades mejoradas  
- [x] **Configurado flujos de trabajo profesionales de depuración** para Agent Builder e Inspector  
- [x] **Configurado MCP Inspector** para pruebas interactivas del servidor  
- [x] **Dominado configuraciones de depuración en VS Code** para desarrollo MCP  

## 🔧 Funcionalidades Avanzadas Exploradas

| Funcionalidad           | Descripción                   | Caso de Uso                |
|------------------------|------------------------------|----------------------------|
| **MCP Python SDK v1.9.3**  | Última implementación del protocolo | Desarrollo moderno de servidores |
| **MCP Inspector 0.14.0**    | Herramienta interactiva de depuración | Pruebas en tiempo real del servidor |
| **Depuración en VS Code**   | Entorno integrado de desarrollo | Flujo profesional de depuración |
| **Integración con Agent Builder** | Conexión directa con AI Toolkit | Pruebas completas de agentes |

## 📚 Recursos Adicionales

- [MCP Python SDK Documentation](https://modelcontextprotocol.io/docs/sdk/python)  
- [AI Toolkit Extension Guide](https://code.visualstudio.com/docs/ai/ai-toolkit)  
- [VS Code Debugging Documentation](https://code.visualstudio.com/docs/editor/debugging)  
- [Model Context Protocol Specification](https://modelcontextprotocol.io/docs/concepts/architecture)  

---

**🎉 ¡Felicidades!** Has completado con éxito el Laboratorio 3 y ahora puedes crear, depurar y desplegar servidores MCP personalizados usando flujos de trabajo profesionales de desarrollo.

### 🔜 Continúa al Siguiente Módulo

¿Listo para aplicar tus habilidades MCP en un flujo de trabajo de desarrollo real? Continúa a **[Módulo 4: Desarrollo Práctico de MCP - Servidor Clone Personalizado de GitHub](../lab4/README.md)** donde podrás:  
- Construir un servidor MCP listo para producción que automatice operaciones de repositorios GitHub  
- Implementar funcionalidad de clonación de repositorios GitHub vía MCP  
- Integrar servidores MCP personalizados con VS Code y GitHub Copilot Agent Mode  
- Probar y desplegar servidores MCP personalizados en entornos de producción  
- Aprender automatización práctica de flujos de trabajo para desarrolladores

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo chybné výklady vyplývající z použití tohoto překladu.