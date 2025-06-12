<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T21:49:09+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "es"
}
-->
## Comenzando  

Esta sección consta de varias lecciones:

- **1 Tu primer servidor**, en esta primera lección, aprenderás a crear tu primer servidor y a inspeccionarlo con la herramienta inspector, una forma valiosa de probar y depurar tu servidor, [a la lección](/03-GettingStarted/01-first-server/README.md)

- **2 Cliente**, en esta lección, aprenderás a escribir un cliente que pueda conectarse a tu servidor, [a la lección](/03-GettingStarted/02-client/README.md)

- **3 Cliente con LLM**, una forma aún mejor de escribir un cliente es añadiendo un LLM para que pueda "negociar" con tu servidor qué hacer, [a la lección](/03-GettingStarted/03-llm-client/README.md)

- **4 Consumiendo un servidor en modo GitHub Copilot Agent en Visual Studio Code**. Aquí, veremos cómo ejecutar nuestro MCP Server desde Visual Studio Code, [a la lección](/03-GettingStarted/04-vscode/README.md)

- **5 Consumiendo desde un SSE (Server Sent Events)** SSE es un estándar para streaming de servidor a cliente, que permite a los servidores enviar actualizaciones en tiempo real a los clientes vía HTTP [a la lección](/03-GettingStarted/05-sse-server/README.md)

- **6 Streaming HTTP con MCP (Streamable HTTP)**. Aprende sobre el streaming HTTP moderno, notificaciones de progreso y cómo implementar servidores y clientes MCP escalables y en tiempo real usando Streamable HTTP. [a la lección](/03-GettingStarted/06-http-streaming/README.md)

- **7 Utilizando AI Toolkit para VSCode** para consumir y probar tus clientes y servidores MCP [a la lección](/03-GettingStarted/07-aitk/README.md)

- **8 Pruebas**. Aquí nos centraremos especialmente en cómo podemos probar nuestro servidor y cliente de diferentes maneras, [a la lección](/03-GettingStarted/08-testing/README.md)

- **9 Despliegue**. Este capítulo abordará diferentes formas de desplegar tus soluciones MCP, [a la lección](/03-GettingStarted/09-deployment/README.md)


El Model Context Protocol (MCP) es un protocolo abierto que estandariza cómo las aplicaciones proporcionan contexto a los LLM. Piensa en MCP como un puerto USB-C para aplicaciones de IA: ofrece una forma estándar de conectar modelos de IA a diferentes fuentes de datos y herramientas.

## Objetivos de aprendizaje

Al final de esta lección, serás capaz de:

- Configurar entornos de desarrollo para MCP en C#, Java, Python, TypeScript y JavaScript
- Construir y desplegar servidores MCP básicos con características personalizadas (recursos, prompts y herramientas)
- Crear aplicaciones host que se conecten a servidores MCP
- Probar y depurar implementaciones MCP
- Entender los desafíos comunes de configuración y sus soluciones
- Conectar tus implementaciones MCP a servicios populares de LLM

## Configurando tu entorno MCP

Antes de comenzar a trabajar con MCP, es importante preparar tu entorno de desarrollo y entender el flujo básico de trabajo. Esta sección te guiará a través de los pasos iniciales para asegurar un comienzo fluido con MCP.

### Requisitos previos

Antes de sumergirte en el desarrollo MCP, asegúrate de tener:

- **Entorno de desarrollo**: Para el lenguaje que elijas (C#, Java, Python, TypeScript o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm o cualquier editor de código moderno
- **Gestores de paquetes**: NuGet, Maven/Gradle, pip o npm/yarn
- **Claves API**: Para cualquier servicio de IA que planees usar en tus aplicaciones host


### SDKs oficiales

En los próximos capítulos verás soluciones construidas usando Python, TypeScript, Java y .NET. Aquí están todos los SDKs oficialmente soportados.

MCP ofrece SDKs oficiales para varios lenguajes:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantenido en colaboración con Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantenido en colaboración con Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - La implementación oficial en TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - La implementación oficial en Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - La implementación oficial en Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantenido en colaboración con Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - La implementación oficial en Rust

## Puntos clave

- Configurar un entorno de desarrollo MCP es sencillo con SDKs específicos para cada lenguaje
- Construir servidores MCP implica crear y registrar herramientas con esquemas claros
- Los clientes MCP se conectan a servidores y modelos para aprovechar capacidades extendidas
- Las pruebas y depuración son esenciales para implementaciones MCP confiables
- Las opciones de despliegue van desde desarrollo local hasta soluciones basadas en la nube

## Práctica

Contamos con un conjunto de ejemplos que complementan los ejercicios que verás en todos los capítulos de esta sección. Además, cada capítulo también tiene sus propios ejercicios y tareas

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Recursos adicionales

- [Construir agentes usando Model Context Protocol en Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP remoto con Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Qué sigue

Siguiente: [Creando tu primer MCP Server](/03-GettingStarted/01-first-server/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de ningún malentendido o interpretación errónea derivada del uso de esta traducción.