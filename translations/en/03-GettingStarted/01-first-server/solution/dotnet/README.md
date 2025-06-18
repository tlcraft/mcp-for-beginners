<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:45:25+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "en"
}
-->
# Running this sample

## -1- Install the dependencies

```bash
dotnet restore
```

## -3- Run the sample

```bash
dotnet run
```

## -4- Test the sample

With the server running in one terminal, open another terminal and run the following command:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

This should start a web server with a visual interface that lets you test the sample.

Once the server is connected:

- try listing tools and run `add` with arguments 2 and 4; you should see 6 as the result.
- go to resources and resource template, call "greeting", enter a name, and you should see a greeting with the name you provided.

### Testing in CLI mode

You can launch it directly in CLI mode by running the following command:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

This will list all the tools available on the server. You should see the following output:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

To invoke a tool, type:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

You should see the following output:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Running the inspector in CLI mode is usually much faster than using the browser.
> Read more about the inspector [here](https://github.com/modelcontextprotocol/inspector).

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.