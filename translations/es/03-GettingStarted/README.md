<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T08:59:01+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "es"
}
-->
## Comenzando  

Esta sección consta de varias lecciones:

- **1 Tu primer servidor**, en esta primera lección aprenderás a crear tu primer servidor y a inspeccionarlo con la herramienta inspector, una forma valiosa de probar y depurar tu servidor, [a la lección](/03-GettingStarted/01-first-server/README.md)

- **2 Cliente**, en esta lección aprenderás a escribir un cliente que pueda conectarse a tu servidor, [a la lección](/03-GettingStarted/02-client/README.md)

- **3 Cliente con LLM**, una forma aún mejor de escribir un cliente es añadiendo un LLM para que pueda "negociar" con tu servidor sobre qué hacer, [a la lección](/03-GettingStarted/03-llm-client/README.md)

- **4 Consumiendo un servidor en modo GitHub Copilot Agent en Visual Studio Code**. Aquí, veremos cómo ejecutar nuestro MCP Server desde Visual Studio Code, [a la lección](/03-GettingStarted/04-vscode/README.md)

- **5 Consumiendo desde SSE (Server Sent Events)** SSE es un estándar para streaming de servidor a cliente, que permite a los servidores enviar actualizaciones en tiempo real a los clientes a través de HTTP [a la lección](/03-GettingStarted/05-sse-server/README.md)

- **6 Utilizando AI Toolkit para VSCode** para consumir y probar tus MCP Clients y Servers [a la lección](/03-GettingStarted/06-aitk/README.md)

- **7 Pruebas**. Aquí nos enfocaremos especialmente en cómo probar nuestro servidor y cliente de diferentes maneras, [a la lección](/03-GettingStarted/07-testing/README.md)

- **8 Despliegue**. Este capítulo revisará diferentes formas de desplegar tus soluciones MCP, [a la lección](/03-GettingStarted/08-deployment/README.md)


El Model Context Protocol (MCP) es un protocolo abierto que estandariza cómo las aplicaciones proporcionan contexto a los LLMs. Piensa en MCP como un puerto USB-C para aplicaciones de IA: ofrece una forma estandarizada de conectar modelos de IA a diferentes fuentes de datos y herramientas.

## Objetivos de Aprendizaje

Al final de esta lección, podrás:

- Configurar entornos de desarrollo para MCP en C#, Java, Python, TypeScript y JavaScript
- Construir y desplegar servidores MCP básicos con funciones personalizadas (recursos, prompts y herramientas)
- Crear aplicaciones host que se conecten a servidores MCP
- Probar y depurar implementaciones MCP
- Entender los desafíos comunes de configuración y sus soluciones
- Conectar tus implementaciones MCP a servicios LLM populares

## Configurando tu entorno MCP

Antes de comenzar a trabajar con MCP, es importante preparar tu entorno de desarrollo y entender el flujo básico de trabajo. Esta sección te guiará a través de los pasos iniciales para asegurar un comienzo sin problemas con MCP.

### Requisitos Previos

Antes de sumergirte en el desarrollo MCP, asegúrate de contar con:

- **Entorno de Desarrollo**: Para el lenguaje que elijas (C#, Java, Python, TypeScript o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm o cualquier editor de código moderno
- **Gestores de Paquetes**: NuGet, Maven/Gradle, pip o npm/yarn
- **Claves API**: Para cualquier servicio de IA que planees usar en tus aplicaciones host


### SDKs Oficiales

En los próximos capítulos verás soluciones construidas usando Python, TypeScript, Java y .NET. Aquí están todos los SDKs oficialmente soportados.

MCP ofrece SDKs oficiales para varios lenguajes:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantenido en colaboración con Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantenido en colaboración con Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - La implementación oficial en TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - La implementación oficial en Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - La implementación oficial en Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantenido en colaboración con Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - La implementación oficial en Rust

## Puntos Clave

- Configurar un entorno de desarrollo MCP es sencillo con SDKs específicos para cada lenguaje
- Construir servidores MCP implica crear y registrar herramientas con esquemas claros
- Los clientes MCP se conectan a servidores y modelos para aprovechar capacidades extendidas
- Probar y depurar es esencial para implementaciones MCP confiables
- Las opciones de despliegue van desde desarrollo local hasta soluciones en la nube

## Práctica

Contamos con un conjunto de ejemplos que complementan los ejercicios que verás en todos los capítulos de esta sección. Además, cada capítulo también tiene sus propios ejercicios y tareas.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Recursos Adicionales

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Qué sigue

Siguiente: [Creando tu primer MCP Server](/03-GettingStarted/01-first-server/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por lograr precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables por malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.