<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:15:29+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "es"
}
-->
# Ejecutando este ejemplo

## -1- Instalar las dependencias

```bash
dotnet restore
```

## -2- Ejecutar el ejemplo

```bash
dotnet run
```

## -3- Probar el ejemplo

Abre una terminal aparte antes de ejecutar lo siguiente (asegúrate de que el servidor siga en ejecución).

Con el servidor corriendo en una terminal, abre otra terminal y ejecuta el siguiente comando:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Esto debería iniciar un servidor web con una interfaz visual que te permitirá probar el ejemplo.

> Asegúrate de que **Streamable HTTP** esté seleccionado como tipo de transporte, y que la URL sea `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, con los argumentos 2 y 4; deberías ver 6 en el resultado.
- ve a resources y resource template y llama a "greeting", escribe un nombre y deberías ver un saludo con el nombre que proporcionaste.

### Pruebas en modo CLI

Puedes lanzarlo directamente en modo CLI ejecutando el siguiente comando:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Esto listará todas las herramientas disponibles en el servidor. Deberías ver la siguiente salida:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Para invocar una herramienta escribe:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Deberías ver la siguiente salida:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Usualmente es mucho más rápido ejecutar el inspector en modo CLI que en el navegador.
> Lee más sobre el inspector [aquí](https://github.com/modelcontextprotocol/inspector).

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos responsabilizamos por malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.