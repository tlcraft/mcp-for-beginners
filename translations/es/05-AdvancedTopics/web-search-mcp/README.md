<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:17:37+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "es"
}
-->
# Lección: Construyendo un Servidor MCP de Búsqueda Web

Este capítulo muestra cómo construir un agente de IA real que se integra con APIs externas, maneja diversos tipos de datos, gestiona errores y coordina múltiples herramientas, todo en un formato listo para producción. Verás:

- **Integración con APIs externas que requieren autenticación**
- **Manejo de diversos tipos de datos desde múltiples endpoints**
- **Estrategias robustas de manejo de errores y registro**
- **Orquestación de múltiples herramientas en un solo servidor**

Al final, tendrás experiencia práctica con patrones y mejores prácticas esenciales para aplicaciones avanzadas impulsadas por IA y LLM.

## Introducción

En esta lección aprenderás a construir un servidor y cliente MCP avanzado que extiende las capacidades de LLM con datos web en tiempo real usando SerpAPI. Esta es una habilidad clave para desarrollar agentes de IA dinámicos que puedan acceder a información actualizada de la web.

## Objetivos de Aprendizaje

Al final de esta lección, podrás:

- Integrar APIs externas (como SerpAPI) de forma segura en un servidor MCP
- Implementar múltiples herramientas para búsqueda web, noticias, productos y preguntas y respuestas
- Analizar y formatear datos estructurados para consumo de LLM
- Manejar errores y gestionar límites de tasa de API de manera efectiva
- Construir y probar clientes MCP tanto automatizados como interactivos

## Servidor MCP de Búsqueda Web

Esta sección presenta la arquitectura y características del Servidor MCP de Búsqueda Web. Verás cómo FastMCP y SerpAPI se usan juntos para extender las capacidades de LLM con datos web en tiempo real.

### Visión General

Esta implementación cuenta con cuatro herramientas que muestran la capacidad de MCP para manejar tareas diversas impulsadas por APIs externas de forma segura y eficiente:

- **general_search**: Para resultados generales en la web
- **news_search**: Para titulares recientes
- **product_search**: Para datos de comercio electrónico
- **qna**: Para fragmentos de preguntas y respuestas

### Características
- **Ejemplos de Código**: Incluye bloques de código específicos para Python (y fácilmente extensibles a otros lenguajes) usando secciones plegables para mayor claridad

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

Antes de ejecutar el cliente, es útil entender qué hace el servidor. El archivo [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Aquí hay un ejemplo breve de cómo el servidor define y registra una herramienta:

<details>  
<summary>Servidor Python</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **Integración con API Externa**: Demuestra manejo seguro de claves API y solicitudes externas
- **Análisis de Datos Estructurados**: Muestra cómo transformar respuestas de API en formatos amigables para LLM
- **Manejo de Errores**: Manejo robusto de errores con registro adecuado
- **Cliente Interactivo**: Incluye pruebas automatizadas y un modo interactivo para pruebas
- **Gestión de Contexto**: Aprovecha MCP Context para registro y seguimiento de solicitudes

## Requisitos Previos

Antes de comenzar, asegúrate de que tu entorno esté configurado correctamente siguiendo estos pasos. Esto garantizará que todas las dependencias estén instaladas y tus claves API configuradas correctamente para un desarrollo y pruebas sin problemas.

- Python 3.8 o superior
- Clave API de SerpAPI (Regístrate en [SerpAPI](https://serpapi.com/) - disponible plan gratuito)

## Instalación

Para comenzar, sigue estos pasos para configurar tu entorno:

1. Instala las dependencias usando uv (recomendado) o pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Crea un archivo `.env` en la raíz del proyecto con tu clave SerpAPI:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Uso

El Servidor MCP de Búsqueda Web es el componente central que expone herramientas para búsqueda web, noticias, productos y preguntas y respuestas integrándose con SerpAPI. Maneja solicitudes entrantes, gestiona llamadas a la API, analiza respuestas y devuelve resultados estructurados al cliente.

Puedes revisar la implementación completa en [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Ejecutando el Servidor

Para iniciar el servidor MCP, usa el siguiente comando:

```bash
python server.py
```

El servidor funcionará como un servidor MCP basado en stdio al que el cliente puede conectarse directamente.

### Modos del Cliente

El cliente (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Ejecutando el Cliente

Para correr las pruebas automatizadas (esto iniciará el servidor automáticamente):

```bash
python client.py
```

O para ejecutar en modo interactivo:

```bash
python client.py --interactive
```

### Probando con Diferentes Métodos

Hay varias formas de probar e interactuar con las herramientas que ofrece el servidor, según tus necesidades y flujo de trabajo.

#### Escribiendo Scripts de Prueba Personalizados con el SDK MCP para Python
También puedes crear tus propios scripts de prueba usando el SDK MCP para Python:

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

En este contexto, un "script de prueba" es un programa Python personalizado que escribes para actuar como cliente del servidor MCP. En lugar de ser una prueba unitaria formal, este script te permite conectarte programáticamente al servidor, llamar a cualquiera de sus herramientas con los parámetros que elijas e inspeccionar los resultados. Este enfoque es útil para:
- Prototipar y experimentar con llamadas a herramientas
- Validar cómo responde el servidor a diferentes entradas
- Automatizar invocaciones repetidas de herramientas
- Construir tus propios flujos de trabajo o integraciones sobre el servidor MCP

Puedes usar scripts de prueba para probar rápidamente nuevas consultas, depurar el comportamiento de las herramientas o incluso como punto de partida para automatizaciones más avanzadas. A continuación un ejemplo de cómo usar el SDK MCP para Python para crear dicho script:

## Descripciones de Herramientas

Puedes usar las siguientes herramientas que ofrece el servidor para realizar diferentes tipos de búsquedas y consultas. Cada herramienta se describe a continuación con sus parámetros y un ejemplo de uso.

Esta sección proporciona detalles sobre cada herramienta disponible y sus parámetros.

### general_search

Realiza una búsqueda general en la web y devuelve resultados formateados.

**Cómo llamar a esta herramienta:**

Puedes llamar a `general_search` desde tu propio script usando el SDK MCP para Python, o de forma interactiva usando el Inspector o el modo cliente interactivo. Aquí un ejemplo de código usando el SDK:

<details>
<summary>Ejemplo en Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

Alternativamente, en modo interactivo, selecciona `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): La consulta de búsqueda

**Ejemplo de Solicitud:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Busca artículos de noticias recientes relacionados con una consulta.

**Cómo llamar a esta herramienta:**

Puedes llamar a `news_search` desde tu propio script usando el SDK MCP para Python, o de forma interactiva usando el Inspector o el modo cliente interactivo. Aquí un ejemplo de código usando el SDK:

<details>
<summary>Ejemplo en Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

Alternativamente, en modo interactivo, selecciona `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): La consulta de búsqueda

**Ejemplo de Solicitud:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Busca productos que coincidan con una consulta.

**Cómo llamar a esta herramienta:**

Puedes llamar a `product_search` desde tu propio script usando el SDK MCP para Python, o de forma interactiva usando el Inspector o el modo cliente interactivo. Aquí un ejemplo de código usando el SDK:

<details>
<summary>Ejemplo en Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

Alternativamente, en modo interactivo, selecciona `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): La consulta de búsqueda de productos

**Ejemplo de Solicitud:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Obtiene respuestas directas a preguntas desde motores de búsqueda.

**Cómo llamar a esta herramienta:**

Puedes llamar a `qna` desde tu propio script usando el SDK MCP para Python, o de forma interactiva usando el Inspector o el modo cliente interactivo. Aquí un ejemplo de código usando el SDK:

<details>
<summary>Ejemplo en Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

Alternativamente, en modo interactivo, selecciona `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): La pregunta para encontrar una respuesta

**Ejemplo de Solicitud:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Detalles del Código

Esta sección proporciona fragmentos de código y referencias para las implementaciones del servidor y cliente.

<details>
<summary>Python</summary>

Consulta [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) para detalles completos de la implementación.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Conceptos Avanzados en Esta Lección

Antes de empezar a construir, aquí tienes algunos conceptos avanzados importantes que aparecerán a lo largo de este capítulo. Entenderlos te ayudará a seguir el contenido, incluso si son nuevos para ti:

- **Orquestación Multi-herramienta**: Esto significa ejecutar varias herramientas diferentes (como búsqueda web, búsqueda de noticias, búsqueda de productos y Q&A) dentro de un solo servidor MCP. Permite que tu servidor maneje una variedad de tareas, no solo una.
- **Manejo de Límites de Tasa de API**: Muchas APIs externas (como SerpAPI) limitan cuántas solicitudes puedes hacer en cierto tiempo. Un buen código verifica estos límites y los maneja con gracia, para que tu aplicación no falle si alcanzas un límite.
- **Análisis de Datos Estructurados**: Las respuestas de API suelen ser complejas y anidadas. Este concepto trata de convertir esas respuestas en formatos limpios y fáciles de usar, amigables para LLMs u otros programas.
- **Recuperación de Errores**: A veces algo falla—quizás la red falla, o la API no devuelve lo esperado. La recuperación de errores significa que tu código puede manejar estos problemas y aún así dar retroalimentación útil, en lugar de colapsar.
- **Validación de Parámetros**: Esto consiste en verificar que todas las entradas a tus herramientas sean correctas y seguras de usar. Incluye establecer valores por defecto y asegurarse de que los tipos sean correctos, lo que ayuda a prevenir errores y confusión.

Esta sección te ayudará a diagnosticar y resolver problemas comunes que puedas encontrar mientras trabajas con el Servidor MCP de Búsqueda Web. Si te encuentras con errores o comportamientos inesperados, esta sección de solución de problemas ofrece soluciones a los problemas más comunes. Revisa estos consejos antes de buscar ayuda adicional—con frecuencia resuelven problemas rápidamente.

## Solución de Problemas

Al trabajar con el Servidor MCP de Búsqueda Web, es normal encontrarse ocasionalmente con problemas—esto es común cuando se desarrolla con APIs externas y nuevas herramientas. Esta sección ofrece soluciones prácticas a los problemas más comunes, para que puedas volver a la normalidad rápidamente. Si encuentras un error, empieza aquí: los consejos a continuación abordan los problemas que enfrentan la mayoría de los usuarios y a menudo pueden resolver tu problema sin ayuda extra.

### Problemas Comunes

A continuación, algunos de los problemas más frecuentes que enfrentan los usuarios, junto con explicaciones claras y pasos para resolverlos:

1. **Falta SERPAPI_KEY en el archivo .env**
   - Si ves el error `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `, crea o revisa el archivo `.env` si es necesario. Si tu clave es correcta pero aún ves este error, verifica si tu plan gratuito ha agotado la cuota.

### Modo Debug

Por defecto, la aplicación registra solo información importante. Si quieres ver más detalles sobre lo que está ocurriendo (por ejemplo, para diagnosticar problemas difíciles), puedes activar el modo DEBUG. Esto te mostrará mucho más sobre cada paso que toma la aplicación.

**Ejemplo: Salida Normal**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Ejemplo: Salida DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Fíjate cómo el modo DEBUG incluye líneas extra sobre solicitudes HTTP, respuestas y otros detalles internos. Esto puede ser muy útil para solucionar problemas.

Para activar el modo DEBUG, configura el nivel de logging a DEBUG al inicio de tu `client.py` or `server.py`:

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## Qué sigue

- [6. Contribuciones de la Comunidad](../../06-CommunityContributions/README.md)

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de ningún malentendido o interpretación errónea derivada del uso de esta traducción.