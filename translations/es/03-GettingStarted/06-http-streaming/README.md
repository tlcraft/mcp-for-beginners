<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-13T20:24:02+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "es"
}
-->
# Transmisión HTTPS con el Protocolo de Contexto de Modelo (MCP)

Este capítulo ofrece una guía completa para implementar transmisión segura, escalable y en tiempo real con el Protocolo de Contexto de Modelo (MCP) usando HTTPS. Cubre la motivación para la transmisión, los mecanismos de transporte disponibles, cómo implementar HTTP transmisible en MCP, las mejores prácticas de seguridad, la migración desde SSE y orientación práctica para construir tus propias aplicaciones MCP con transmisión.

## Mecanismos de Transporte y Transmisión en MCP

Esta sección explora los diferentes mecanismos de transporte disponibles en MCP y su papel en habilitar capacidades de transmisión para comunicación en tiempo real entre clientes y servidores.

### ¿Qué es un Mecanismo de Transporte?

Un mecanismo de transporte define cómo se intercambian los datos entre el cliente y el servidor. MCP soporta múltiples tipos de transporte para adaptarse a diferentes entornos y requerimientos:

- **stdio**: Entrada/salida estándar, adecuado para herramientas locales y basadas en CLI. Simple pero no apto para web o nube.
- **SSE (Server-Sent Events)**: Permite a los servidores enviar actualizaciones en tiempo real a los clientes sobre HTTP. Bueno para interfaces web, pero limitado en escalabilidad y flexibilidad.
- **Streamable HTTP**: Transporte moderno basado en HTTP para transmisión, que soporta notificaciones y mejor escalabilidad. Recomendado para la mayoría de escenarios de producción y nube.

### Tabla Comparativa

Consulta la tabla comparativa a continuación para entender las diferencias entre estos mecanismos de transporte:

| Transporte        | Actualizaciones en Tiempo Real | Transmisión | Escalabilidad | Caso de Uso               |
|-------------------|-------------------------------|-------------|---------------|--------------------------|
| stdio             | No                            | No          | Baja          | Herramientas CLI locales |
| SSE               | Sí                            | Sí          | Media         | Web, actualizaciones en tiempo real |
| Streamable HTTP   | Sí                            | Sí          | Alta          | Nube, multi-cliente      |

> **Tip:** Elegir el transporte adecuado impacta en el rendimiento, escalabilidad y experiencia de usuario. **Streamable HTTP** es recomendado para aplicaciones modernas, escalables y listas para la nube.

Ten en cuenta los transportes stdio y SSE que se mostraron en capítulos anteriores y cómo el transporte streamable HTTP es el que se cubre en este capítulo.

## Transmisión: Conceptos y Motivación

Entender los conceptos fundamentales y la motivación detrás de la transmisión es esencial para implementar sistemas efectivos de comunicación en tiempo real.

**Transmisión** es una técnica en programación de redes que permite enviar y recibir datos en pequeños fragmentos manejables o como una secuencia de eventos, en lugar de esperar a que toda la respuesta esté lista. Esto es especialmente útil para:

- Archivos o conjuntos de datos grandes.
- Actualizaciones en tiempo real (por ejemplo, chat, barras de progreso).
- Cálculos de larga duración donde se quiere mantener informado al usuario.

Esto es lo que debes saber sobre la transmisión a alto nivel:

- Los datos se entregan progresivamente, no todos de una vez.
- El cliente puede procesar los datos a medida que llegan.
- Reduce la latencia percibida y mejora la experiencia del usuario.

### ¿Por qué usar transmisión?

Las razones para usar transmisión son las siguientes:

- Los usuarios reciben retroalimentación inmediata, no solo al final.
- Permite aplicaciones en tiempo real e interfaces responsivas.
- Uso más eficiente de recursos de red y cómputo.

### Ejemplo Simple: Servidor y Cliente HTTP con Transmisión

Aquí tienes un ejemplo simple de cómo se puede implementar la transmisión:

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

Este ejemplo demuestra un servidor que envía una serie de mensajes al cliente a medida que están disponibles, en lugar de esperar a que todos los mensajes estén listos.

**Cómo funciona:**
- El servidor envía cada mensaje tan pronto como está listo.
- El cliente recibe e imprime cada fragmento a medida que llega.

**Requisitos:**
- El servidor debe usar una respuesta de transmisión (por ejemplo, `StreamingResponse` en FastAPI).
- El cliente debe procesar la respuesta como un flujo (`stream=True` en requests).
- El Content-Type suele ser `text/event-stream` o `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Servidor (Java, usando Spring Boot y Server-Sent Events):**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**Cliente (Java, usando Spring WebFlux WebClient):**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**Notas sobre la implementación en Java:**
- Usa la pila reactiva de Spring Boot con `Flux` para transmisión.
- `ServerSentEvent` provee transmisión estructurada de eventos con tipos de evento.
- `WebClient` con `bodyToFlux()` permite consumo reactivo de transmisión.
- `delayElements()` simula tiempo de procesamiento entre eventos.
- Los eventos pueden tener tipos (`info`, `result`) para mejor manejo en el cliente.

</details>

### Comparación: Transmisión Clásica vs Transmisión MCP

Las diferencias entre cómo funciona la transmisión de manera "clásica" versus cómo funciona en MCP pueden representarse así:

| Característica         | Transmisión HTTP Clásica       | Transmisión MCP (Notificaciones)  |
|-----------------------|-------------------------------|-----------------------------------|
| Respuesta principal   | Fragmentada                   | Única, al final                   |
| Actualizaciones de progreso | Enviadas como fragmentos de datos | Enviadas como notificaciones      |
| Requisitos del cliente | Debe procesar el flujo        | Debe implementar un manejador de mensajes |
| Caso de uso           | Archivos grandes, flujos de tokens AI | Progreso, logs, retroalimentación en tiempo real |

### Diferencias Clave Observadas

Además, aquí algunas diferencias clave:

- **Patrón de Comunicación:**
   - Transmisión HTTP clásica: Usa codificación de transferencia fragmentada para enviar datos en fragmentos.
   - Transmisión MCP: Usa un sistema estructurado de notificaciones con protocolo JSON-RPC.

- **Formato de Mensaje:**
   - HTTP clásico: Fragmentos de texto plano con saltos de línea.
   - MCP: Objetos estructurados LoggingMessageNotification con metadatos.

- **Implementación del Cliente:**
   - HTTP clásico: Cliente simple que procesa respuestas de transmisión.
   - MCP: Cliente más sofisticado con un manejador de mensajes para procesar diferentes tipos de mensajes.

- **Actualizaciones de Progreso:**
   - HTTP clásico: El progreso es parte del flujo principal de respuesta.
   - MCP: El progreso se envía mediante mensajes de notificación separados mientras la respuesta principal llega al final.

### Recomendaciones

Hay algunas recomendaciones al elegir entre implementar transmisión clásica (como el endpoint que mostramos arriba usando `/stream`) versus elegir transmisión vía MCP.

- **Para necesidades simples de transmisión:** La transmisión HTTP clásica es más sencilla de implementar y suficiente para necesidades básicas.

- **Para aplicaciones complejas e interactivas:** La transmisión MCP ofrece un enfoque más estructurado con metadatos enriquecidos y separación entre notificaciones y resultados finales.

- **Para aplicaciones de IA:** El sistema de notificaciones de MCP es especialmente útil para tareas de IA de larga duración donde se quiere mantener informado al usuario sobre el progreso.

## Transmisión en MCP

Bien, ya viste algunas recomendaciones y comparaciones sobre la diferencia entre transmisión clásica y transmisión en MCP. Ahora entremos en detalle sobre cómo puedes aprovechar la transmisión en MCP.

Entender cómo funciona la transmisión dentro del marco MCP es esencial para construir aplicaciones responsivas que proporcionen retroalimentación en tiempo real a los usuarios durante operaciones de larga duración.

En MCP, la transmisión no consiste en enviar la respuesta principal en fragmentos, sino en enviar **notificaciones** al cliente mientras una herramienta procesa una solicitud. Estas notificaciones pueden incluir actualizaciones de progreso, logs u otros eventos.

### Cómo funciona

El resultado principal se envía aún como una única respuesta. Sin embargo, las notificaciones pueden enviarse como mensajes separados durante el procesamiento y así actualizar al cliente en tiempo real. El cliente debe ser capaz de manejar y mostrar estas notificaciones.

## ¿Qué es una Notificación?

Dijimos "Notificación", ¿qué significa eso en el contexto de MCP?

Una notificación es un mensaje enviado del servidor al cliente para informar sobre progreso, estado u otros eventos durante una operación de larga duración. Las notificaciones mejoran la transparencia y la experiencia del usuario.

Por ejemplo, se espera que un cliente envíe una notificación una vez que se haya realizado el handshake inicial con el servidor.

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

Para que el logging funcione, el servidor debe habilitarlo como característica/capacidad así:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Dependiendo del SDK usado, el logging podría estar habilitado por defecto, o puede que necesites activarlo explícitamente en la configuración del servidor.

Existen diferentes tipos de notificaciones:

| Nivel      | Descripción                    | Ejemplo de Uso                |
|------------|-------------------------------|------------------------------|
| debug      | Información detallada para depuración | Puntos de entrada/salida de funciones |
| info       | Mensajes informativos generales | Actualizaciones de progreso de operación |
| notice     | Eventos normales pero significativos | Cambios de configuración      |
| warning    | Condiciones de advertencia     | Uso de características obsoletas |
| error      | Condiciones de error           | Fallos en la operación        |
| critical   | Condiciones críticas           | Fallos en componentes del sistema |
| alert      | Acción inmediata requerida     | Detección de corrupción de datos |
| emergency  | Sistema inutilizable           | Fallo completo del sistema    |

## Implementación de Notificaciones en MCP

Para implementar notificaciones en MCP, necesitas configurar tanto el servidor como el cliente para manejar actualizaciones en tiempo real. Esto permite que tu aplicación proporcione retroalimentación inmediata a los usuarios durante operaciones de larga duración.

### Lado servidor: Envío de Notificaciones

Comencemos con el lado servidor. En MCP, defines herramientas que pueden enviar notificaciones mientras procesan solicitudes. El servidor usa el objeto de contexto (usualmente `ctx`) para enviar mensajes al cliente.

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

En el ejemplo anterior, la herramienta `process_files` envía tres notificaciones al cliente mientras procesa cada archivo. El método `ctx.info()` se usa para enviar mensajes informativos.

</details>

Además, para habilitar notificaciones, asegúrate de que tu servidor use un transporte de transmisión (como `streamable-http`) y que tu cliente implemente un manejador de mensajes para procesar notificaciones. Así puedes configurar el servidor para usar el transporte `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

En este ejemplo en .NET, la herramienta `ProcessFiles` está decorada con el atributo `Tool` y envía tres notificaciones al cliente mientras procesa cada archivo. El método `ctx.Info()` se usa para enviar mensajes informativos.

Para habilitar notificaciones en tu servidor MCP .NET, asegúrate de usar un transporte de transmisión:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
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

En el código anterior, la función `message_handler` verifica si el mensaje entrante es una notificación. Si lo es, imprime la notificación; de lo contrario, la procesa como un mensaje normal del servidor. También observa cómo `ClientSession` se inicializa con el `message_handler` para manejar notificaciones entrantes.

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

En este ejemplo en .NET, la función `MessageHandler` verifica si el mensaje entrante es una notificación. Si lo es, imprime la notificación; de lo contrario, la procesa como un mensaje normal del servidor. `ClientSession` se inicializa con el manejador de mensajes a través de `ClientSessionOptions`.

</details>

Para habilitar notificaciones, asegúrate de que tu servidor use un transporte de transmisión (como `streamable-http`) y que tu cliente implemente un manejador de mensajes para procesar notificaciones.

## Notificaciones de Progreso y Escenarios

Esta sección explica el concepto de notificaciones de progreso en MCP, por qué son importantes y cómo implementarlas usando Streamable HTTP. También encontrarás una tarea práctica para reforzar tu comprensión.

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

- **Mejor experiencia de usuario:** Los usuarios ven actualizaciones a medida que avanza el trabajo, no solo al final.
- **Retroalimentación en tiempo real:** Los clientes pueden mostrar barras de progreso o logs, haciendo que la aplicación se sienta más responsiva.
- **Depuración y monitoreo más fáciles:** Desarrolladores y usuarios pueden ver dónde un proceso puede estar lento o detenido.

### Cómo implementar notificaciones de progreso

Así es como puedes implementar notificaciones de progreso en MCP:

- **En el servidor:** Usa `ctx.info()` o `ctx.log()` para enviar notificaciones a medida que se procesa cada ítem. Esto envía un mensaje al cliente antes de que el resultado principal esté listo.
- **En el cliente:** Implementa un manejador de mensajes que escuche y muestre las notificaciones a medida que llegan. Este manejador distingue entre notificaciones y el resultado final.

**Ejemplo de servidor:**

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

**Ejemplo de Cliente:**

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

La seguridad es crucial al exponer servidores MCP a través de HTTP. Streamable HTTP introduce nuevas superficies de ataque y requiere una configuración cuidadosa.

### Puntos Clave
- **Validación del encabezado Origin**: Siempre valida el encabezado `Origin` para evitar ataques de DNS rebinding.
- **Vinculación a localhost**: Para desarrollo local, vincula los servidores a `localhost` para evitar exponerlos a internet público.
- **Autenticación**: Implementa autenticación (por ejemplo, claves API, OAuth) para despliegues en producción.
- **CORS**: Configura políticas de Cross-Origin Resource Sharing (CORS) para restringir el acceso.
- **HTTPS**: Usa HTTPS en producción para cifrar el tráfico.

### Buenas Prácticas
- Nunca confíes en solicitudes entrantes sin validación.
- Registra y monitorea todos los accesos y errores.
- Actualiza regularmente las dependencias para corregir vulnerabilidades de seguridad.

### Desafíos
- Equilibrar la seguridad con la facilidad de desarrollo
- Asegurar compatibilidad con diversos entornos cliente


## Actualización de SSE a Streamable HTTP

Para aplicaciones que actualmente usan Server-Sent Events (SSE), migrar a Streamable HTTP ofrece capacidades mejoradas y una mejor sostenibilidad a largo plazo para tus implementaciones MCP.

### ¿Por qué actualizar?

Hay dos razones importantes para actualizar de SSE a Streamable HTTP:

- Streamable HTTP ofrece mejor escalabilidad, compatibilidad y soporte más completo para notificaciones que SSE.
- Es el transporte recomendado para nuevas aplicaciones MCP.

### Pasos para la migración

Así puedes migrar de SSE a Streamable HTTP en tus aplicaciones MCP:

- **Actualiza el código del servidor** para usar `transport="streamable-http"` en `mcp.run()`.
- **Actualiza el código del cliente** para usar `streamablehttp_client` en lugar del cliente SSE.
- **Implementa un manejador de mensajes** en el cliente para procesar las notificaciones.
- **Prueba la compatibilidad** con las herramientas y flujos de trabajo existentes.

### Mantener la compatibilidad

Se recomienda mantener la compatibilidad con los clientes SSE existentes durante el proceso de migración. Aquí algunas estrategias:

- Puedes soportar ambos, SSE y Streamable HTTP, ejecutando ambos transportes en diferentes endpoints.
- Migra gradualmente los clientes al nuevo transporte.

### Desafíos

Asegúrate de abordar los siguientes retos durante la migración:

- Garantizar que todos los clientes se actualicen
- Manejar las diferencias en la entrega de notificaciones

## Consideraciones de Seguridad

La seguridad debe ser una prioridad máxima al implementar cualquier servidor, especialmente cuando se usan transportes basados en HTTP como Streamable HTTP en MCP.

Al implementar servidores MCP con transportes HTTP, la seguridad se vuelve una preocupación fundamental que requiere atención cuidadosa a múltiples vectores de ataque y mecanismos de protección.

### Resumen

La seguridad es crítica al exponer servidores MCP sobre HTTP. Streamable HTTP introduce nuevas superficies de ataque y requiere una configuración cuidadosa.

Aquí algunas consideraciones clave de seguridad:

- **Validación del encabezado Origin**: Siempre valida el encabezado `Origin` para evitar ataques de DNS rebinding.
- **Vinculación a localhost**: Para desarrollo local, vincula los servidores a `localhost` para evitar exponerlos a internet público.
- **Autenticación**: Implementa autenticación (por ejemplo, claves API, OAuth) para despliegues en producción.
- **CORS**: Configura políticas de Cross-Origin Resource Sharing (CORS) para restringir el acceso.
- **HTTPS**: Usa HTTPS en producción para cifrar el tráfico.

### Buenas Prácticas

Además, aquí algunas buenas prácticas para implementar seguridad en tu servidor de streaming MCP:

- Nunca confíes en solicitudes entrantes sin validación.
- Registra y monitorea todos los accesos y errores.
- Actualiza regularmente las dependencias para corregir vulnerabilidades de seguridad.

### Desafíos

Enfrentarás algunos desafíos al implementar seguridad en servidores de streaming MCP:

- Equilibrar la seguridad con la facilidad de desarrollo
- Asegurar compatibilidad con diversos entornos cliente

### Ejercicio: Construye tu propia aplicación MCP de streaming

**Escenario:**  
Construye un servidor y cliente MCP donde el servidor procese una lista de elementos (por ejemplo, archivos o documentos) y envíe una notificación por cada elemento procesado. El cliente debe mostrar cada notificación a medida que llega.

**Pasos:**

1. Implementa una herramienta servidor que procese una lista y envíe notificaciones por cada elemento.
2. Implementa un cliente con un manejador de mensajes para mostrar las notificaciones en tiempo real.
3. Prueba tu implementación ejecutando ambos, servidor y cliente, y observa las notificaciones.

[Solution](./solution/README.md)

## Lecturas adicionales y ¿qué sigue?

Para continuar tu camino con el streaming MCP y ampliar tus conocimientos, esta sección ofrece recursos adicionales y pasos sugeridos para construir aplicaciones más avanzadas.

### Lecturas adicionales

- [Microsoft: Introducción al streaming HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS en ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### ¿Qué sigue?

- Intenta construir herramientas MCP más avanzadas que usen streaming para análisis en tiempo real, chat o edición colaborativa.
- Explora la integración del streaming MCP con frameworks frontend (React, Vue, etc.) para actualizaciones en vivo de la interfaz.
- Siguiente: [Utilizando AI Toolkit para VSCode](../07-aitk/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.