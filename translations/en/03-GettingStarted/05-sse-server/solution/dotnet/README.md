<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:52:41+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "en"
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

Start a separate terminal before you run the below (ensure the server is still running).

With the server running in one terminal, open another terminal and run the following command:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

This should start a web server with a visual interface allowing you to test the sample.

Once the server is connected: 

- try listing tools and run `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

You can launch it directly in CLI mode by running the following command:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

This will list all the tools available in the server. You should see the following output:

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

To invoke a tool type:

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
> It's usually a lot faster to run the inspector in CLI mode than in the browser.
> Read more about the inspector [here](https://github.com/modelcontextprotocol/inspector).

Sure, please provide the text you would like to have translated into English.