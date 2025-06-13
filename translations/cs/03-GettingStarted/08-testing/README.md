<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:11:44+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "cs"
}
-->
## Testing and Debugging

Antes de comenzar a probar tu servidor MCP, es importante entender las herramientas disponibles y las mejores prácticas para depurar. Las pruebas efectivas aseguran que tu servidor se comporte como se espera y te ayudan a identificar y resolver problemas rápidamente. La siguiente sección describe los enfoques recomendados para validar tu implementación MCP.

## Overview

Esta lección cubre cómo seleccionar el enfoque de prueba adecuado y la herramienta de prueba más efectiva.

## Learning Objectives

Al final de esta lección, podrás:

- Describir varios enfoques para las pruebas.
- Usar diferentes herramientas para probar tu código de manera efectiva.

## Testing MCP Servers

MCP proporciona herramientas para ayudarte a probar y depurar tus servidores:

- **MCP Inspector**: Una herramienta de línea de comandos que se puede ejecutar tanto como herramienta CLI como visual.
- **Pruebas manuales**: Puedes usar una herramienta como curl para ejecutar solicitudes web, aunque cualquier herramienta capaz de ejecutar HTTP servirá.
- **Pruebas unitarias**: Es posible usar tu framework de pruebas preferido para testear las funcionalidades tanto del servidor como del cliente.

### Using MCP Inspector

Ya describimos el uso de esta herramienta en lecciones anteriores, pero hablemos un poco a nivel general. Es una herramienta construida en Node.js y puedes usarla ejecutando el ejecutable `npx`, que descargará e instalará la herramienta temporalmente y se limpiará automáticamente una vez que termine de ejecutar tu solicitud.

El [MCP Inspector](https://github.com/modelcontextprotocol/inspector) te ayuda a:

- **Descubrir capacidades del servidor**: Detecta automáticamente recursos, herramientas y prompts disponibles
- **Probar la ejecución de herramientas**: Prueba diferentes parámetros y observa las respuestas en tiempo real
- **Ver metadatos del servidor**: Examina información, esquemas y configuraciones del servidor

Una ejecución típica de la herramienta se ve así:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

El comando anterior inicia un MCP y su interfaz visual, además de abrir una interfaz web local en tu navegador. Puedes esperar ver un panel que muestra tus servidores MCP registrados, sus herramientas, recursos y prompts disponibles. La interfaz te permite probar la ejecución de herramientas de forma interactiva, inspeccionar metadatos del servidor y ver respuestas en tiempo real, facilitando la validación y depuración de tus implementaciones MCP.

Así es como puede verse: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.cs.png)

También puedes ejecutar esta herramienta en modo CLI, para lo cual agregas el atributo `--cli`. Aquí tienes un ejemplo de cómo ejecutar la herramienta en modo "CLI", que lista todas las herramientas del servidor:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manual Testing

Además de usar la herramienta inspector para probar las capacidades del servidor, otro enfoque similar es ejecutar un cliente capaz de usar HTTP, como por ejemplo curl.

Con curl, puedes probar servidores MCP directamente usando solicitudes HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Como puedes ver en el ejemplo anterior con curl, usas una solicitud POST para invocar una herramienta con un payload que contiene el nombre de la herramienta y sus parámetros. Usa el enfoque que mejor se adapte a ti. Las herramientas CLI en general suelen ser más rápidas y permiten ser automatizadas, lo cual puede ser útil en un entorno CI/CD.

### Unit Testing

Crea pruebas unitarias para tus herramientas y recursos para asegurarte de que funcionan como se espera. Aquí tienes un ejemplo de código de prueba.

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

El código anterior hace lo siguiente:

- Usa el framework pytest, que te permite crear pruebas como funciones y usar sentencias assert.
- Crea un MCP Server con dos herramientas diferentes.
- Usa la sentencia `assert` para verificar que se cumplen ciertas condiciones.

Consulta el [archivo completo aquí](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Con el archivo anterior, puedes probar tu propio servidor para asegurarte de que las capacidades se crean como deberían.

Todos los SDK principales tienen secciones similares de pruebas, por lo que puedes adaptarte a tu entorno de ejecución elegido.

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Additional Resources

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## What's Next

- Next: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.