<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-27T16:23:14+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "cs"
}
-->
# Running this sample

## -1- Install the dependencies

```bash
dotnet run
```

## -2- Run the sample

```bash
dotnet run
```

## -3- Test the sample

Abra una terminal separada antes de ejecutar lo siguiente (asegúrese de que el servidor siga en ejecución).

Con el servidor corriendo en una terminal, abra otra terminal y ejecute el siguiente comando:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Esto debería iniciar un servidor web con una interfaz visual que le permitirá probar el ejemplo.

Una vez que el servidor esté conectado: 

- intente listar las herramientas y ejecute `add`, con los argumentos 2 y 4, debería ver 6 en el resultado.
- vaya a recursos y plantilla de recursos y llame a "greeting", escriba un nombre y debería ver un saludo con el nombre que proporcionó.

### Pruebas en modo CLI

Puede iniciarlo directamente en modo CLI ejecutando el siguiente comando:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Esto listará todas las herramientas disponibles en el servidor. Debería ver la siguiente salida:

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

Para invocar una herramienta, escriba:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Debería ver la siguiente salida:

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
> Lea más sobre el inspector [aquí](https://github.com/modelcontextprotocol/inspector).

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vzniklé použitím tohoto překladu.