<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:16:32+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "es"
}
-->
# Ejecutando este ejemplo

Aquí se explica cómo ejecutar el servidor y cliente clásico de streaming HTTP, así como el servidor y cliente de streaming MCP usando Python.

### Resumen

- Configurarás un servidor MCP que envía notificaciones de progreso al cliente mientras procesa elementos.
- El cliente mostrará cada notificación en tiempo real.
- Esta guía cubre los requisitos previos, la configuración, la ejecución y la solución de problemas.

### Requisitos previos

- Python 3.9 o superior
- El paquete de Python `mcp` (instálalo con `pip install mcp`)

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

### Ejecutando el servidor clásico de streaming HTTP

1. Navega al directorio de la solución:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Inicia el servidor clásico de streaming HTTP:

   ```pwsh
   python server.py
   ```

3. El servidor arrancará y mostrará:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Ejecutando el cliente clásico de streaming HTTP

1. Abre una nueva terminal (activa el mismo entorno virtual y directorio):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Deberías ver los mensajes transmitidos impresos secuencialmente:

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
3. El servidor arrancará y mostrará:  
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

### Pasos clave de la implementación

1. **Crear el servidor MCP usando FastMCP.**  
2. **Definir una herramienta que procese una lista y envíe notificaciones usando `ctx.info()` o `ctx.log()`.**  
3. **Ejecutar el servidor con `transport="streamable-http"`.**  
4. **Implementar un cliente con un manejador de mensajes para mostrar las notificaciones a medida que llegan.**

### Revisión del código
- El servidor usa funciones async y el contexto MCP para enviar actualizaciones de progreso.  
- El cliente implementa un manejador de mensajes async para imprimir notificaciones y el resultado final.

### Consejos y solución de problemas

- Usa `async/await` para operaciones no bloqueantes.  
- Siempre maneja excepciones tanto en el servidor como en el cliente para mayor robustez.  
- Prueba con varios clientes para observar las actualizaciones en tiempo real.  
- Si encuentras errores, verifica tu versión de Python y asegúrate de que todas las dependencias estén instaladas.

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.