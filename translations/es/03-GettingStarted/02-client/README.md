<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:08:51+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "es"
}
-->
En el código anterior nosotros:

- Importamos las librerías
- Creamos una instancia de un cliente y lo conectamos usando stdio como transporte.
- Listamos prompts, recursos y herramientas y los invocamos todos.

Ahí lo tienes, un cliente que puede comunicarse con un servidor MCP.

Tomémonos nuestro tiempo en la siguiente sección de ejercicios para desglosar cada fragmento de código y explicar qué está pasando.

## Ejercicio: Escribiendo un cliente

Como se dijo antes, tomémonos nuestro tiempo explicando el código, y por supuesto, si quieres, puedes programar junto con nosotros.

### -1- Importar las librerías

Importemos las librerías que necesitamos, necesitaremos referencias a un cliente y a nuestro protocolo de transporte elegido, stdio. stdio es un protocolo para cosas que se ejecutan en tu máquina local. SSE es otro protocolo de transporte que mostraremos en capítulos futuros, pero esa es tu otra opción. Por ahora, continuemos con stdio.

Pasemos a la instanciación.

### -2- Instanciando cliente y transporte

Necesitaremos crear una instancia del transporte y otra de nuestro cliente:

### -3- Listando las características del servidor

Ahora, tenemos un cliente que puede conectarse cuando se ejecute el programa. Sin embargo, en realidad no lista sus características, así que hagámoslo a continuación:

Genial, ahora hemos capturado todas las características. Ahora la pregunta es, ¿cuándo las usamos? Bueno, este cliente es bastante simple, simple en el sentido de que necesitaremos llamar explícitamente a las características cuando las queramos. En el próximo capítulo, crearemos un cliente más avanzado que tendrá acceso a su propio modelo de lenguaje grande, LLM. Por ahora, veamos cómo podemos invocar las características en el servidor:

### -4- Invocar características

Para invocar las características necesitamos asegurarnos de especificar los argumentos correctos y en algunos casos el nombre de lo que estamos tratando de invocar.

### -5- Ejecutar el cliente

Para ejecutar el cliente, escribe el siguiente comando en la terminal:

## Tarea

En esta tarea, usarás lo que has aprendido para crear un cliente, pero crearás un cliente propio.

Aquí tienes un servidor que puedes usar y al que necesitas llamar mediante tu código cliente, intenta agregar más características al servidor para hacerlo más interesante.

## Solución

[Solución](./solution/README.md)

## Puntos clave

Los puntos clave de este capítulo sobre los clientes son los siguientes:

- Pueden usarse tanto para descubrir como para invocar características en el servidor.
- Pueden iniciar un servidor mientras se inician a sí mismos (como en este capítulo), pero los clientes también pueden conectarse a servidores ya en ejecución.
- Son una excelente manera de probar las capacidades del servidor junto a alternativas como el Inspector, como se describió en el capítulo anterior.

## Recursos adicionales

- [Construyendo clientes en MCP](https://modelcontextprotocol.io/quickstart/client)

## Ejemplos

- [Calculadora en Java](../samples/java/calculator/README.md)
- [Calculadora en .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora en JavaScript](../samples/javascript/README.md)
- [Calculadora en TypeScript](../samples/typescript/README.md)
- [Calculadora en Python](../../../../03-GettingStarted/samples/python)

## Qué sigue

- Siguiente: [Creando un cliente con un LLM](../03-llm-client/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.