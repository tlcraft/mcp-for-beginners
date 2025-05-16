<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-16T14:55:49+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "es"
}
-->
Genial, para nuestro siguiente paso, vamos a listar las capacidades en el servidor.

### -2 Listar capacidades del servidor

Ahora nos conectaremos al servidor y solicitaremos sus capacidades:

### -3- Convertir las capacidades del servidor en herramientas para el LLM

El siguiente paso después de listar las capacidades del servidor es convertirlas en un formato que el LLM pueda entender. Una vez hecho esto, podemos proporcionar estas capacidades como herramientas para nuestro LLM.

Genial, ahora estamos listos para manejar cualquier solicitud de usuario, así que abordemos eso a continuación.

### -4- Manejar la solicitud del usuario

En esta parte del código, manejaremos las solicitudes de los usuarios.

¡Excelente, lo lograste!

## Tarea

Toma el código del ejercicio y amplía el servidor con algunas herramientas adicionales. Luego crea un cliente con un LLM, como en el ejercicio, y pruébalo con diferentes prompts para asegurarte de que todas las herramientas del servidor se llamen dinámicamente. Esta forma de construir un cliente significa que el usuario final tendrá una excelente experiencia, ya que podrá usar prompts en lugar de comandos exactos del cliente y no tendrá que preocuparse por si se está llamando a un servidor MCP.

## Solución

[Solución](/03-GettingStarted/03-llm-client/solution/README.md)

## Puntos clave

- Agregar un LLM a tu cliente ofrece una mejor forma para que los usuarios interactúen con los servidores MCP.
- Necesitas convertir la respuesta del servidor MCP en algo que el LLM pueda entender.

## Ejemplos

- [Calculadora en Java](../samples/java/calculator/README.md)
- [Calculadora en .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora en JavaScript](../samples/javascript/README.md)
- [Calculadora en TypeScript](../samples/typescript/README.md)
- [Calculadora en Python](../../../../03-GettingStarted/samples/python)

## Recursos adicionales

## Qué sigue

- Siguiente: [Consumir un servidor usando Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Aviso Legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables por malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.