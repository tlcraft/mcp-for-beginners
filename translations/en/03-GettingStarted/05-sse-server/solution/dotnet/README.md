<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-07-13T20:07:30+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "en"
}
-->
# Running this sample

## -1- Install the dependencies

```bash
dotnet restore
```

## -2- Run the sample

```bash
dotnet run
```

## -3- Test the sample

Open a separate terminal before running the command below (make sure the server is still running).

With the server running in one terminal, open another terminal and run the following command:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

This will start a web server with a visual interface that lets you test the sample.

> Make sure **SSE** is selected as the transport type, and the URL is `http://localhost:3001/sse`.

Once the server is connected:

- try listing tools and run `add` with arguments 2 and 4; you should see 6 as the result.
- go to resources and resource template, call "greeting", enter a name, and you should see a greeting with the name you provided.

### Testing in CLI mode

You can launch it directly in CLI mode by running the following command:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

This will list all the tools available on the server. You should see the following output:

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

To invoke a tool, type:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

You should see the following output:

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
> Running the inspector in CLI mode is usually much faster than in the browser.
> Read more about the inspector [here](https://github.com/modelcontextprotocol/inspector).

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.