<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-12T22:17:08+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "es"
}
-->
# HTTPS Streaming con Model Context Protocol (MCP)

Este capítulo ofrece una guía completa para implementar streaming seguro, escalable y en tiempo real con el Model Context Protocol (MCP) usando HTTPS. Cubre la motivación para el streaming, los mecanismos de transporte disponibles, cómo implementar HTTP con capacidad de streaming en MCP, las mejores prácticas de seguridad, la migración desde SSE y orientación práctica para construir tus propias aplicaciones MCP con streaming.

## Mecanismos de Transporte y Streaming en MCP

Esta sección explora los diferentes mecanismos de transporte disponibles en MCP y su papel para habilitar capacidades de streaming para la comunicación en tiempo real entre clientes y servidores.

### ¿Qué es un Mecanismo de Transporte?

Un mecanismo de transporte define cómo se intercambian datos entre el cliente y el servidor. MCP soporta varios tipos de transporte para adaptarse a diferentes entornos y necesidades:

- **stdio**: Entrada/salida estándar, adecuado para herramientas locales y basadas en CLI. Simple pero no apto para web o nube.
- **SSE (Server-Sent Events)**: Permite que los servidores envíen actualizaciones en tiempo real a los clientes sobre HTTP. Bueno para interfaces web, pero limitado en escalabilidad y flexibilidad.
- **Streamable HTTP**: Transporte de streaming moderno basado en HTTP, que soporta notificaciones y mejor escalabilidad. Recomendado para la mayoría de escenarios en producción y nube.

### Tabla Comparativa

Consulta la tabla comparativa a continuación para entender las diferencias entre estos mecanismos de transporte:

| Transporte        | Actualizaciones en Tiempo Real | Streaming | Escalabilidad | Caso de Uso             |
|-------------------|-------------------------------|-----------|---------------|------------------------|
| stdio             | No                            | No        | Baja          | Herramientas CLI locales|
| SSE               | Sí                            | Sí        | Media         | Web, actualizaciones en tiempo real |
| Streamable HTTP   | Sí                            | Sí        | Alta          | Nube, múltiples clientes|

> **Tip:** Elegir el transporte adecuado impacta en el rendimiento, la escalabilidad y la experiencia de usuario. **Streamable HTTP** es recomendado para aplicaciones modernas, escalables y listas para la nube.

Toma en cuenta los transportes stdio y SSE que viste en capítulos anteriores y cómo Streamable HTTP es el transporte que se cubre en este capítulo.

## Streaming: Conceptos y Motivación

Entender los conceptos fundamentales y la motivación detrás del streaming es esencial para implementar sistemas de comunicación en tiempo real efectivos.

**Streaming** es una técnica en programación de redes que permite enviar y recibir datos en pequeños fragmentos manejables o como una secuencia de eventos, en lugar de esperar a que toda la respuesta esté lista. Esto es especialmente útil para:

- Archivos o conjuntos de datos grandes.
- Actualizaciones en tiempo real (por ejemplo, chat, barras de progreso).
- Cálculos de larga duración donde quieres mantener informado al usuario.

Esto es lo que debes saber sobre streaming a alto nivel:

- Los datos se entregan progresivamente, no todos de una vez.
- El cliente puede procesar los datos a medida que llegan.
- Reduce la latencia percibida y mejora la experiencia del usuario.

### ¿Por qué usar streaming?

Las razones para usar streaming son las siguientes:

- Los usuarios reciben retroalimentación inmediata, no solo al final.
- Permite aplicaciones en tiempo real e interfaces responsivas.
- Uso más eficiente de recursos de red y cómputo.

### Ejemplo Simple: Servidor y Cliente HTTP con Streaming

Aquí tienes un ejemplo sencillo de cómo se puede implementar streaming:

<details>
<summary>Python</summary>

**Servidor (Python, usando FastAPI y StreamingResponse):**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**Cliente (Python, usando requests):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

Este ejemplo demuestra un servidor enviando una serie de mensajes al cliente conforme están disponibles, en lugar de esperar a que todos los mensajes estén listos.

**Cómo funciona:**
- El servidor envía cada mensaje a medida que está listo.
- El cliente recibe e imprime cada fragmento a medida que llega.

**Requisitos:**
- El servidor debe usar una respuesta de streaming (por ejemplo, `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) en lugar de elegir streaming vía MCP.

- **Para necesidades simples de streaming:** El streaming HTTP clásico es más sencillo de implementar y suficiente para necesidades básicas.

- **Para aplicaciones complejas e interactivas:** El streaming MCP ofrece un enfoque más estructurado con metadatos enriquecidos y separación entre notificaciones y resultados finales.

- **Para aplicaciones de IA:** El sistema de notificaciones de MCP es particularmente útil para tareas de IA de larga duración donde quieres mantener informados a los usuarios sobre el progreso.

## Streaming en MCP

Bien, hasta ahora has visto algunas recomendaciones y comparaciones sobre la diferencia entre el streaming clásico y el streaming en MCP. Ahora vamos a entrar en detalle sobre cómo puedes aprovechar el streaming en MCP.

Entender cómo funciona el streaming dentro del marco MCP es esencial para construir aplicaciones responsivas que ofrezcan retroalimentación en tiempo real a los usuarios durante operaciones prolongadas.

En MCP, el streaming no consiste en enviar la respuesta principal en fragmentos, sino en enviar **notificaciones** al cliente mientras una herramienta está procesando una solicitud. Estas notificaciones pueden incluir actualizaciones de progreso, registros u otros eventos.

### Cómo funciona

El resultado principal aún se envía como una única respuesta. Sin embargo, las notificaciones pueden enviarse como mensajes separados durante el procesamiento y así actualizar al cliente en tiempo real. El cliente debe ser capaz de manejar y mostrar estas notificaciones.

## ¿Qué es una Notificación?

Dijimos "Notificación", ¿qué significa eso en el contexto de MCP?

Una notificación es un mensaje enviado desde el servidor al cliente para informar sobre progreso, estado u otros eventos durante una operación de larga duración. Las notificaciones mejoran la transparencia y la experiencia del usuario.

Por ejemplo, se espera que un cliente envíe una notificación una vez que se haya completado el handshake inicial con el servidor.

Una notificación se ve así como un mensaje JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Las notificaciones pertenecen a un tema en MCP referido como ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Para que el logging funcione, el servidor necesita habilitarlo como característica/capacidad de esta forma:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Dependiendo del SDK utilizado, el logging podría estar habilitado por defecto o podrías necesitar activarlo explícitamente en la configuración del servidor.

Existen diferentes tipos de notificaciones:

| Nivel     | Descripción                    | Ejemplo de Uso               |
|-----------|-------------------------------|-----------------------------|
| debug     | Información detallada para depuración | Puntos de entrada/salida de funciones |
| info      | Mensajes informativos generales | Actualizaciones de progreso  |
| notice    | Eventos normales pero significativos | Cambios en configuración    |
| warning   | Condiciones de advertencia     | Uso de funciones obsoletas   |
| error     | Condiciones de error           | Fallos en operaciones        |
| critical  | Condiciones críticas           | Fallos en componentes del sistema |
| alert     | Acción inmediata requerida     | Detección de corrupción de datos |
| emergency | Sistema inutilizable           | Fallo total del sistema      |

## Implementando Notificaciones en MCP

Para implementar notificaciones en MCP, necesitas configurar tanto el servidor como el cliente para manejar actualizaciones en tiempo real. Esto permite que tu aplicación brinde retroalimentación inmediata a los usuarios durante operaciones de larga duración.

### Lado servidor: Envío de Notificaciones

Comencemos con el lado servidor. En MCP defines herramientas que pueden enviar notificaciones mientras procesan solicitudes. El servidor usa el objeto context (usualmente `ctx`) para enviar mensajes al cliente.

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

En el ejemplo anterior, el transporte `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

</details>

### Lado cliente: Recepción de Notificaciones

El cliente debe implementar un manejador de mensajes para procesar y mostrar las notificaciones a medida que llegan.

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

En el código anterior, el `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) y tu cliente implementa un manejador de mensajes para procesar notificaciones.

## Notificaciones de Progreso y Escenarios

Esta sección explica el concepto de notificaciones de progreso en MCP, por qué son importantes y cómo implementarlas usando Streamable HTTP. También encontrarás un ejercicio práctico para reforzar tu comprensión.

Las notificaciones de progreso son mensajes en tiempo real enviados del servidor al cliente durante operaciones de larga duración. En lugar de esperar a que todo el proceso termine, el servidor mantiene al cliente actualizado sobre el estado actual. Esto mejora la transparencia, la experiencia del usuario y facilita la depuración.

**Ejemplo:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### ¿Por qué usar notificaciones de progreso?

Las notificaciones de progreso son esenciales por varias razones:

- **Mejor experiencia de usuario:** Los usuarios ven actualizaciones conforme avanza el trabajo, no solo al final.
- **Retroalimentación en tiempo real:** Los clientes pueden mostrar barras de progreso o registros, haciendo que la aplicación se sienta más responsiva.
- **Depuración y monitoreo más sencillos:** Desarrolladores y usuarios pueden identificar dónde un proceso puede estar lento o detenido.

### Cómo implementar notificaciones de progreso

Así es como puedes implementar notificaciones de progreso en MCP:

- **En el servidor:** Usa `ctx.info()` or `ctx.log()` para enviar notificaciones a medida que se procesa cada ítem. Esto envía un mensaje al cliente antes de que el resultado principal esté listo.
- **En el cliente:** Implementa un manejador de mensajes que escuche y muestre las notificaciones conforme llegan. Este manejador distingue entre notificaciones y el resultado final.

**Ejemplo Servidor:**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**Ejemplo Cliente:**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## Consideraciones de Seguridad

Al implementar servidores MCP con transportes basados en HTTP, la seguridad se vuelve una preocupación fundamental que requiere atención cuidadosa a múltiples vectores de ataque y mecanismos de protección.

### Resumen

La seguridad es crítica al exponer servidores MCP sobre HTTP. Streamable HTTP introduce nuevas superficies de ataque y requiere configuración cuidadosa.

### Puntos Clave
- **Validación del Header Origin**: Siempre valida el header `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` en lugar del cliente SSE.
3. **Implementar un manejador de mensajes** en el cliente para procesar notificaciones.
4. **Probar compatibilidad** con herramientas y flujos de trabajo existentes.

### Mantener la Compatibilidad

Se recomienda mantener compatibilidad con clientes SSE existentes durante el proceso de migración. Aquí algunas estrategias:

- Puedes soportar ambos, SSE y Streamable HTTP, ejecutando ambos transportes en diferentes endpoints.
- Migrar gradualmente a los clientes al nuevo transporte.

### Desafíos

Asegúrate de abordar los siguientes desafíos durante la migración:

- Asegurar que todos los clientes estén actualizados.
- Manejar diferencias en la entrega de notificaciones.

### Ejercicio: Construye tu propia aplicación MCP con Streaming

**Escenario:**
Construye un servidor y cliente MCP donde el servidor procesa una lista de ítems (por ejemplo, archivos o documentos) y envía una notificación por cada ítem procesado. El cliente debe mostrar cada notificación conforme llega.

**Pasos:**

1. Implementa una herramienta en el servidor que procese una lista y envíe notificaciones por cada ítem.
2. Implementa un cliente con un manejador de mensajes para mostrar las notificaciones en tiempo real.
3. Prueba tu implementación ejecutando servidor y cliente, y observa las notificaciones.

[Solution](./solution/README.md)

## Lecturas Adicionales y Qué Sigue

Para continuar tu aprendizaje con el streaming MCP y ampliar tus conocimientos, esta sección ofrece recursos adicionales y pasos sugeridos para construir aplicaciones más avanzadas.

### Lecturas Adicionales

- [Microsoft: Introducción a HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS en ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Qué Sigue

- Intenta construir herramientas MCP más avanzadas que usen streaming para analíticas en tiempo real, chat o edición colaborativa.
- Explora integrar el streaming MCP con frameworks frontend (React, Vue, etc.) para actualizaciones en vivo de la interfaz.
- Próximo: [Utilizando AI Toolkit para VSCode](../07-aitk/README.md)

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.