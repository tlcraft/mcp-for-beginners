<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:43:42+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "es"
}
-->
# Implementación Práctica

La implementación práctica es donde el poder del Model Context Protocol (MCP) se vuelve tangible. Aunque entender la teoría y la arquitectura detrás de MCP es importante, el verdadero valor surge cuando aplicas estos conceptos para construir, probar y desplegar soluciones que resuelven problemas del mundo real. Este capítulo cierra la brecha entre el conocimiento conceptual y el desarrollo práctico, guiándote en el proceso de dar vida a aplicaciones basadas en MCP.

Ya sea que estés desarrollando asistentes inteligentes, integrando IA en flujos de trabajo empresariales o creando herramientas personalizadas para el procesamiento de datos, MCP ofrece una base flexible. Su diseño independiente del lenguaje y los SDK oficiales para lenguajes de programación populares lo hacen accesible para una amplia variedad de desarrolladores. Aprovechando estos SDK, puedes prototipar, iterar y escalar tus soluciones rápidamente en diferentes plataformas y entornos.

En las siguientes secciones encontrarás ejemplos prácticos, código de muestra y estrategias de despliegue que demuestran cómo implementar MCP en C#, Java, TypeScript, JavaScript y Python. También aprenderás a depurar y probar tus servidores MCP, gestionar APIs y desplegar soluciones en la nube usando Azure. Estos recursos prácticos están diseñados para acelerar tu aprendizaje y ayudarte a construir con confianza aplicaciones MCP robustas y listas para producción.

## Resumen

Esta lección se centra en los aspectos prácticos de la implementación de MCP en varios lenguajes de programación. Exploraremos cómo usar los SDK de MCP en C#, Java, TypeScript, JavaScript y Python para construir aplicaciones robustas, depurar y probar servidores MCP, y crear recursos, prompts y herramientas reutilizables.

## Objetivos de Aprendizaje

Al finalizar esta lección, serás capaz de:
- Implementar soluciones MCP usando los SDK oficiales en varios lenguajes de programación
- Depurar y probar servidores MCP de manera sistemática
- Crear y usar características del servidor (Recursos, Prompts y Herramientas)
- Diseñar flujos de trabajo MCP efectivos para tareas complejas
- Optimizar implementaciones MCP para rendimiento y fiabilidad

## Recursos Oficiales de SDK

El Model Context Protocol ofrece SDK oficiales para múltiples lenguajes:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Trabajando con los SDK de MCP

Esta sección ofrece ejemplos prácticos de implementación de MCP en varios lenguajes de programación. Puedes encontrar código de muestra en el directorio `samples` organizado por lenguaje.

### Muestras Disponibles

El repositorio incluye [implementaciones de ejemplo](../../../04-PracticalImplementation/samples) en los siguientes lenguajes:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Cada ejemplo demuestra conceptos clave de MCP y patrones de implementación para ese lenguaje y ecosistema específico.

## Características Principales del Servidor

Los servidores MCP pueden implementar cualquier combinación de estas características:

### Recursos
Los recursos proporcionan contexto y datos para que el usuario o el modelo de IA los utilicen:
- Repositorios de documentos
- Bases de conocimiento
- Fuentes de datos estructurados
- Sistemas de archivos

### Prompts
Los prompts son mensajes y flujos de trabajo plantillados para los usuarios:
- Plantillas de conversación predefinidas
- Patrones de interacción guiada
- Estructuras de diálogo especializadas

### Herramientas
Las herramientas son funciones que el modelo de IA puede ejecutar:
- Utilidades de procesamiento de datos
- Integraciones con APIs externas
- Capacidades computacionales
- Funcionalidad de búsqueda

## Implementaciones de Ejemplo: C#

El repositorio oficial del SDK de C# contiene varias implementaciones de ejemplo que demuestran diferentes aspectos de MCP:

- **Cliente MCP Básico**: Ejemplo simple que muestra cómo crear un cliente MCP y llamar a herramientas
- **Servidor MCP Básico**: Implementación mínima de servidor con registro básico de herramientas
- **Servidor MCP Avanzado**: Servidor completo con registro de herramientas, autenticación y manejo de errores
- **Integración con ASP.NET**: Ejemplos que demuestran integración con ASP.NET Core
- **Patrones de Implementación de Herramientas**: Varios patrones para implementar herramientas con diferentes niveles de complejidad

El SDK MCP para C# está en vista previa y las APIs pueden cambiar. Actualizaremos continuamente este blog a medida que el SDK evolucione.

### Características Clave
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construye tu [primer Servidor MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Para muestras completas de implementación en C#, visita el [repositorio oficial de muestras del SDK C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Implementación de Ejemplo: Java

El SDK de Java ofrece opciones robustas para la implementación de MCP con características de nivel empresarial.

### Características Clave

- Integración con Spring Framework
- Fuerte tipado
- Soporte para programación reactiva
- Manejo completo de errores

Para un ejemplo completo de implementación en Java, consulta el [ejemplo de Java](samples/java/containerapp/README.md) en el directorio de muestras.

## Implementación de Ejemplo: JavaScript

El SDK de JavaScript ofrece un enfoque ligero y flexible para la implementación de MCP.

### Características Clave

- Soporte para Node.js y navegadores
- API basada en Promesas
- Integración sencilla con Express y otros frameworks
- Soporte WebSocket para streaming

Para un ejemplo completo de implementación en JavaScript, consulta el [ejemplo de JavaScript](samples/javascript/README.md) en el directorio de muestras.

## Implementación de Ejemplo: Python

El SDK de Python ofrece un enfoque pythonico para la implementación de MCP con excelentes integraciones para frameworks de ML.

### Características Clave

- Soporte async/await con asyncio
- Integración con Flask y FastAPI
- Registro simple de herramientas
- Integración nativa con librerías populares de ML

Para un ejemplo completo de implementación en Python, consulta el [ejemplo de Python](samples/python/README.md) en el directorio de muestras.

## Gestión de API

Azure API Management es una excelente solución para asegurar servidores MCP. La idea es colocar una instancia de Azure API Management frente a tu servidor MCP y dejar que maneje características que probablemente necesites como:

- limitación de tasa
- gestión de tokens
- monitoreo
- balanceo de carga
- seguridad

### Ejemplo en Azure

Aquí tienes un ejemplo en Azure que hace exactamente eso, es decir, [crear un servidor MCP y asegurarla con Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Observa cómo ocurre el flujo de autorización en la imagen a continuación:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

En la imagen anterior, sucede lo siguiente:

- La autenticación/autorización se realiza usando Microsoft Entra.
- Azure API Management actúa como puerta de enlace y usa políticas para dirigir y gestionar el tráfico.
- Azure Monitor registra todas las solicitudes para análisis posteriores.

#### Flujo de autorización

Veamos el flujo de autorización con más detalle:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Especificación de autorización MCP

Aprende más sobre la [especificación de autorización MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Desplegar Servidor MCP Remoto en Azure

Veamos si podemos desplegar el ejemplo que mencionamos antes:

1. Clona el repositorio

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registra el proveedor de recursos `Microsoft.App`.
    * Si usas Azure CLI, ejecuta `az provider register --namespace Microsoft.App --wait`.
    * Si usas Azure PowerShell, ejecuta `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Luego ejecuta `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` después de un tiempo para verificar si el registro está completo.

2. Ejecuta este comando [azd](https://aka.ms/azd) para aprovisionar el servicio de gestión de API, la función app (con código) y todos los demás recursos de Azure necesarios

    ```shell
    azd up
    ```

    Este comando debería desplegar todos los recursos en la nube en Azure

### Probar tu servidor con MCP Inspector

1. En una **nueva ventana de terminal**, instala y ejecuta MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Deberías ver una interfaz similar a:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.es.png) 

1. Haz CTRL clic para cargar la aplicación web MCP Inspector desde la URL que muestra la app (por ejemplo, http://127.0.0.1:6274/#resources)
1. Configura el tipo de transporte a `SSE`
1. Establece la URL a tu endpoint SSE de API Management en ejecución que se muestra después de `azd up` y **Conéctate**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lista de Herramientas**. Haz clic en una herramienta y **Ejecuta la Herramienta**.  

Si todos los pasos funcionaron, ahora deberías estar conectado al servidor MCP y haber podido llamar a una herramienta.

## Servidores MCP para Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Este conjunto de repositorios es una plantilla de inicio rápido para construir y desplegar servidores MCP remotos personalizados usando Azure Functions con Python, C# .NET o Node/TypeScript.

Las muestras proporcionan una solución completa que permite a los desarrolladores:

- Construir y ejecutar localmente: Desarrollar y depurar un servidor MCP en una máquina local
- Desplegar en Azure: Desplegar fácilmente en la nube con un simple comando azd up
- Conectar desde clientes: Conectarse al servidor MCP desde varios clientes, incluyendo el modo agente Copilot de VS Code y la herramienta MCP Inspector

### Características Clave:

- Seguridad desde el diseño: El servidor MCP está asegurado usando claves y HTTPS
- Opciones de autenticación: Soporta OAuth usando autenticación integrada y/o API Management
- Aislamiento de red: Permite aislamiento de red usando Azure Virtual Networks (VNET)
- Arquitectura serverless: Aprovecha Azure Functions para ejecución escalable y basada en eventos
- Desarrollo local: Soporte completo para desarrollo y depuración local
- Despliegue sencillo: Proceso de despliegue simplificado a Azure

El repositorio incluye todos los archivos de configuración necesarios, código fuente y definiciones de infraestructura para comenzar rápidamente con una implementación de servidor MCP lista para producción.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementación de ejemplo de MCP usando Azure Functions con Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementación de ejemplo de MCP usando Azure Functions con C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementación de ejemplo de MCP usando Azure Functions con Node/TypeScript.

## Puntos Clave

- Los SDK de MCP proporcionan herramientas específicas por lenguaje para implementar soluciones MCP robustas
- El proceso de depuración y prueba es crítico para aplicaciones MCP confiables
- Las plantillas de prompts reutilizables permiten interacciones consistentes con la IA
- Los flujos de trabajo bien diseñados pueden orquestar tareas complejas usando múltiples herramientas
- Implementar soluciones MCP requiere considerar seguridad, rendimiento y manejo de errores

## Ejercicio

Diseña un flujo de trabajo MCP práctico que aborde un problema real en tu área:

1. Identifica 3-4 herramientas que serían útiles para resolver este problema
2. Crea un diagrama de flujo que muestre cómo interactúan estas herramientas
3. Implementa una versión básica de una de las herramientas usando tu lenguaje preferido
4. Crea una plantilla de prompt que ayude al modelo a usar efectivamente tu herramienta

## Recursos Adicionales


---

Siguiente: [Temas Avanzados](../05-AdvancedTopics/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.