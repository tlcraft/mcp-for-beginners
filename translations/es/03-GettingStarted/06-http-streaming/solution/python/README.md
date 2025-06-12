<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-12T22:21:43+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "es"
}
-->
# Ejecutando este ejemplo

Aquí se explica cómo ejecutar el servidor y cliente de streaming HTTP clásico, así como el servidor y cliente de streaming MCP usando Python.

### Resumen

- Configurarás un servidor MCP que transmite notificaciones de progreso al cliente mientras procesa elementos.
- El cliente mostrará cada notificación en tiempo real.
- Esta guía cubre los requisitos previos, la configuración, la ejecución y la solución de problemas.

### Requisitos previos

- Python 3.9 o superior
- El paquete de Python `mcp` (instalar con `pip install mcp`)

### Instalación y configuración

1. Clona el repositorio o descarga los archivos de la solución.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Crea y activa un entorno virtual (recomendado):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Instala las dependencias necesarias:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Archivos

- **Servidor:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Cliente:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Ejecutando el servidor de streaming HTTP clásico

1. Navega al directorio de la solución:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Inicia el servidor de streaming HTTP clásico:

   ```pwsh
   python server.py
   ```

3. El servidor se iniciará y mostrará:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Ejecutando el cliente de streaming HTTP clásico

1. Abre una nueva terminal (activa el mismo entorno virtual y directorio):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Deberías ver los mensajes transmitidos impresos de forma secuencial:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### Ejecutando el servidor de streaming MCP

1. Navega al directorio de la solución:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Inicia el servidor MCP con el transporte streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. El servidor se iniciará y mostrará:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Ejecutando el cliente de streaming MCP

1. Abre una nueva terminal (activa el mismo entorno virtual y directorio):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Deberías ver las notificaciones impresas en tiempo real mientras el servidor procesa cada elemento:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### Pasos clave de implementación

1. **Crea el servidor MCP usando FastMCP.**
2. **Define una herramienta que procese una lista y envíe notificaciones usando `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` para operaciones no bloqueantes.**
- Siempre maneja las excepciones tanto en el servidor como en el cliente para mayor robustez.
- Prueba con múltiples clientes para observar las actualizaciones en tiempo real.
- Si encuentras errores, verifica tu versión de Python y asegúrate de que todas las dependencias estén instaladas.

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables por malentendidos o interpretaciones erróneas que puedan derivarse del uso de esta traducción.