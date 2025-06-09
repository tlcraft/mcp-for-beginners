<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T17:54:15+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "es"
}
-->
Genial, para nuestro siguiente paso, vamos a listar las capacidades en el servidor.

### -2 Listar capacidades del servidor

Ahora nos conectaremos al servidor y solicitaremos sus capacidades:

### -3- Convertir las capacidades del servidor en herramientas para el LLM

El siguiente paso después de listar las capacidades del servidor es convertirlas en un formato que el LLM entienda. Una vez hecho esto, podemos proporcionar estas capacidades como herramientas para nuestro LLM.

Genial, ahora estamos listos para manejar cualquier solicitud del usuario, así que abordemos eso a continuación.

### -4- Manejar solicitudes de usuario

En esta parte del código, manejaremos las solicitudes de los usuarios.

¡Excelente, lo lograste!

## Tarea

Toma el código del ejercicio y amplía el servidor con más herramientas. Luego crea un cliente con un LLM, como en el ejercicio, y pruébalo con diferentes prompts para asegurarte de que todas las herramientas del servidor se llamen dinámicamente. Esta forma de construir un cliente garantiza que el usuario final tenga una excelente experiencia, ya que puede usar prompts en lugar de comandos exactos del cliente y no necesita saber que se está llamando a un servidor MCP.

## Solución

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Puntos clave

- Agregar un LLM a tu cliente ofrece una mejor manera para que los usuarios interactúen con servidores MCP.
- Necesitas convertir la respuesta del servidor MCP a algo que el LLM pueda entender.

## Ejemplos

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Recursos adicionales

## Qué sigue

- Siguiente: [Consumir un servidor usando Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Aviso Legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos responsabilizamos por malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.