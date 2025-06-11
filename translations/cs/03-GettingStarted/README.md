<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:15:43+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "cs"
}
-->
## Getting Started  

Esta sección consta de varias lecciones:

- **1 Tu primer servidor**, en esta primera lección, aprenderás a crear tu primer servidor y a inspeccionarlo con la herramienta inspector, una forma valiosa de probar y depurar tu servidor, [a la lección](/03-GettingStarted/01-first-server/README.md)

- **2 Cliente**, en esta lección, aprenderás a escribir un cliente que pueda conectarse a tu servidor, [a la lección](/03-GettingStarted/02-client/README.md)

- **3 Cliente con LLM**, una forma aún mejor de escribir un cliente es añadiendo un LLM para que pueda "negociar" con tu servidor qué hacer, [a la lección](/03-GettingStarted/03-llm-client/README.md)

- **4 Consumiendo un servidor en modo GitHub Copilot Agent en Visual Studio Code**. Aquí, veremos cómo ejecutar nuestro MCP Server desde Visual Studio Code, [a la lección](/03-GettingStarted/04-vscode/README.md)

- **5 Consumiendo desde un SSE (Server Sent Events)** SSE es un estándar para streaming de servidor a cliente, que permite a los servidores enviar actualizaciones en tiempo real a los clientes mediante HTTP [a la lección](/03-GettingStarted/05-sse-server/README.md)

- **6 Utilizando AI Toolkit para VSCode** para consumir y probar tus MCP Clients y Servers [a la lección](/03-GettingStarted/06-aitk/README.md)

- **7 Testing**. Aquí nos enfocaremos especialmente en cómo probar nuestro servidor y cliente de diferentes maneras, [a la lección](/03-GettingStarted/07-testing/README.md)

- **8 Deployment**. Este capítulo analizará diferentes formas de desplegar tus soluciones MCP, [a la lección](/03-GettingStarted/08-deployment/README.md)


El Model Context Protocol (MCP) es un protocolo abierto que estandariza cómo las aplicaciones proporcionan contexto a los LLMs. Piensa en MCP como un puerto USB-C para aplicaciones de IA: ofrece una forma estandarizada de conectar modelos de IA con diferentes fuentes de datos y herramientas.

## Learning Objectives

Al final de esta lección, podrás:

- Configurar entornos de desarrollo para MCP en C#, Java, Python, TypeScript y JavaScript
- Construir y desplegar servidores MCP básicos con características personalizadas (recursos, prompts y herramientas)
- Crear aplicaciones host que se conecten a servidores MCP
- Probar y depurar implementaciones MCP
- Entender desafíos comunes de configuración y sus soluciones
- Conectar tus implementaciones MCP con servicios populares de LLM

## Setting Up Your MCP Environment

Antes de comenzar a trabajar con MCP, es importante preparar tu entorno de desarrollo y entender el flujo básico de trabajo. Esta sección te guiará en los pasos iniciales para asegurar un buen comienzo con MCP.

### Prerequisites

Antes de sumergirte en el desarrollo con MCP, asegúrate de tener:

- **Entorno de desarrollo**: Para tu lenguaje elegido (C#, Java, Python, TypeScript o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm o cualquier editor moderno
- **Gestores de paquetes**: NuGet, Maven/Gradle, pip o npm/yarn
- **Claves API**: Para cualquier servicio de IA que planees usar en tus aplicaciones host


### Official SDKs

En los próximos capítulos verás soluciones construidas con Python, TypeScript, Java y .NET. Aquí están todos los SDKs oficiales soportados.

MCP ofrece SDKs oficiales para múltiples lenguajes:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantenido en colaboración con Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantenido en colaboración con Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementación oficial en TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementación oficial en Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementación oficial en Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantenido en colaboración con Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementación oficial en Rust

## Key Takeaways

- Configurar un entorno de desarrollo MCP es sencillo con SDKs específicos por lenguaje
- Construir servidores MCP implica crear y registrar herramientas con esquemas claros
- Los clientes MCP se conectan a servidores y modelos para aprovechar capacidades extendidas
- Probar y depurar es esencial para implementaciones MCP confiables
- Las opciones de despliegue van desde desarrollo local hasta soluciones en la nube

## Practicing

Contamos con un conjunto de ejemplos que complementan los ejercicios que verás en todos los capítulos de esta sección. Además, cada capítulo tiene sus propios ejercicios y asignaciones

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

Siguiente: [Creando tu primer MCP Server](/03-GettingStarted/01-first-server/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vyplývající z použití tohoto překladu.