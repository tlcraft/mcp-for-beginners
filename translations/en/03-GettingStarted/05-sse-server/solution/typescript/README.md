<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:17:55+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "en"
}
-->
# Running this sample

## -1- Install the dependencies

```bash
npm install
```

## -3- Run the sample

```bash
npm run build
```

## -4- Test the sample

With the server running in one terminal, open another terminal and run the following command:

```bash
npm run inspector
```

This should start a web server with a visual interface that lets you test the sample.

Once the server is connected:

- try listing tools and run `add` with arguments 2 and 4; you should see 6 as the result.
- go to resources and resource template, call "greeting," enter a name, and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app, and `mcp dev` is a wrapper around it.

- Start the server with the command `npm run build`.

- In a separate terminal, run the following command:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    This will list all the tools available on the server. You should see the following output:

    ```text
    {
    "tools": [
        {
        "name": "add",
        "description": "Add two numbers",
        "inputSchema": {
            "type": "object",
            "properties": {
            "a": {
                "title": "A",
                "type": "integer"
            },
            "b": {
                "title": "B",
                "type": "integer"
            }
            },
            "required": [
            "a",
            "b"
            ],
            "title": "addArguments"
        }
        }
    ]
    }
    ```

- Invoke a tool type by typing the following command:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

You should see the following output:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Running the inspector in CLI mode is usually much faster than using the browser.
> Read more about the inspector [here](https://github.com/modelcontextprotocol/inspector).

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.