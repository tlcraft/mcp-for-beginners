<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:45:48+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "en"
}
-->
# Sample

The previous example shows how to use a local .NET project with the `stdio` type and how to run the server locally in a container. This is a good solution in many situations. However, it can be useful to have the server running remotely, such as in a cloud environment. This is where the `http` type comes into play.

Looking at the solution in the `04-PracticalImplementation` folder, it might seem much more complex than the previous one. But in reality, it isn’t. If you take a closer look at the `src/Calculator` project, you’ll see that it mostly contains the same code as the previous example. The only difference is that we are using a different library, `ModelContextProtocol.AspNetCore`, to handle the HTTP requests. We also change the `IsPrime` method to make it private, just to show that you can have private methods in your code. The rest of the code remains the same as before.

The other projects come from [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview). Having .NET Aspire in the solution enhances the developer experience during development and testing and helps with observability. It’s not required to run the server, but it’s a good practice to include it in your solution.

## Start the server locally

1. From VS Code (with the C# DevKit extension), navigate to the `04-PracticalImplementation/samples/csharp` directory.
1. Run the following command to start the server:

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. When a web browser opens the .NET Aspire dashboard, note the `http` URL. It should look something like `http://localhost:5058/`.

   ![.NET Aspire Dashboard](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.en.png)

## Test Streamable HTTP with the MCP Inspector

If you have Node.js 22.7.5 or later, you can use the MCP Inspector to test your server.

Start the server and run the following command in a terminal:

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.en.png)

- Select the `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp`. It should be `http` (not `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp` server created previously) to look like this:

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

Try some tests:

- Ask for "3 prime numbers after 6780". Notice how Copilot uses the new tools `NextFivePrimeNumbers` and only returns the first 3 prime numbers.
- Ask for "7 prime numbers after 111" to see what happens.
- Ask "John has 24 lollies and wants to distribute them all to his 3 kids. How many lollies does each kid get?" to see the result.

## Deploy the server to Azure

Let’s deploy the server to Azure so more people can use it.

From a terminal, navigate to the `04-PracticalImplementation/samples/csharp` folder and run the following command:

```bash
azd up
```

Once deployment finishes, you should see a message like this:

![Azd deployment success](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.en.png)

Copy the URL and use it in the MCP Inspector and in GitHub Copilot Chat.

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## What’s next?

We’ve tried different transport types and testing tools, and deployed your MCP server to Azure. But what if our server needs access to private resources? For example, a database or a private API? In the next chapter, we’ll explore how to improve the security of our server.

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.