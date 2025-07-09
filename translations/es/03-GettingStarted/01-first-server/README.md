<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "315ecce765d22639b60dbc41344c8533",
  "translation_date": "2025-07-09T22:54:34+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "es"
}
-->
### -2- Crear proyecto

Ahora que tienes instalado el SDK, vamos a crear un proyecto a continuación:

### -3- Crear archivos del proyecto

### -4- Crear el código del servidor

### -5- Añadir una herramienta y un recurso

Agrega una herramienta y un recurso añadiendo el siguiente código:

### -6 Código final

Vamos a añadir el último código que necesitamos para que el servidor pueda iniciarse:

### -7- Probar el servidor

Inicia el servidor con el siguiente comando:

### -8- Ejecutar usando el inspector

El inspector es una excelente herramienta que puede iniciar tu servidor y te permite interactuar con él para que puedas probar que funciona. Vamos a iniciarlo:
> [!NOTE]
> podría verse diferente en el campo "command" ya que contiene el comando para ejecutar un servidor con tu entorno de ejecución específico/
Deberías ver la siguiente interfaz de usuario:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.es.png)

1. Conéctate al servidor seleccionando el botón Connect.
  Una vez conectado al servidor, deberías ver lo siguiente:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.es.png)

1. Selecciona "Tools" y luego "listTools", deberías ver que aparece "Add", selecciona "Add" y completa los valores de los parámetros.

  Deberías ver la siguiente respuesta, es decir, un resultado de la herramienta "add":

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.es.png)

¡Felicidades, has logrado crear y ejecutar tu primer servidor!

### SDKs oficiales

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
- Probar y depurar es esencial para implementaciones MCP confiables

## Ejemplos

- [Calculadora en Java](../samples/java/calculator/README.md)
- [Calculadora en .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora en JavaScript](../samples/javascript/README.md)
- [Calculadora en TypeScript](../samples/typescript/README.md)
- [Calculadora en Python](../../../../03-GettingStarted/samples/python)

## Tarea

Crea un servidor MCP simple con una herramienta de tu elección:

1. Implementa la herramienta en tu lenguaje preferido (.NET, Java, Python o JavaScript).
2. Define los parámetros de entrada y los valores de retorno.
3. Ejecuta la herramienta inspector para asegurarte de que el servidor funcione correctamente.
4. Prueba la implementación con diferentes entradas.

## Solución

[Solución](./solution/README.md)

## Recursos adicionales

- [Construir agentes usando Model Context Protocol en Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP remoto con Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agente MCP OpenAI para .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Qué sigue

Siguiente: [Primeros pasos con clientes MCP](../02-client/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.