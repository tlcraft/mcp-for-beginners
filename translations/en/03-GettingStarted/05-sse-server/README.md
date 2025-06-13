<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-12T22:55:16+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "en"
}
-->
Now that we know a bit more about SSE, let's move on to building an SSE server.

## Exercise: Creating an SSE Server

When creating our server, keep two key points in mind:

- Use a web server to expose endpoints for connection and message handling.
- Build the server using the same approach as before with tools, resources, and prompts, similar to when we used stdio.

### -1- Create a server instance

To create our server, we use the same types as with stdio. However, for the transport, we need to select SSE.

Let's add the necessary routes next.

### -2- Add routes

Next, add routes to handle the connection and incoming messages:

Let's add capabilities to the server now.

### -3- Adding server capabilities

With all SSE-specific parts defined, let's add server features like tools, prompts, and resources.

Your complete code should look like this:

Great, we have an SSE server set up. Let's test it out next.

## Exercise: Debugging an SSE Server with Inspector

Inspector is a powerful tool we saw earlier in the lesson [Creating your first server](/03-GettingStarted/01-first-server/README.md). Let's try using Inspector here as well:

### -1- Running the inspector

To run Inspector, you first need to have the SSE server running. So, let's start with that:

1. Run the server

1. Run the inspector

    > ![NOTE]
    > Run this in a separate terminal window from where the server is running. Also, make sure to adjust the command below to match the URL where your server is hosted.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Running Inspector is consistent across all runtimes. Notice that instead of providing a path to start the server, you specify the URL where the server is running, including the `/sse` route.

### -2- Trying out the tool

Connect to the server by selecting SSE from the dropdown and entering the URL where your server is running, for example, http://localhost:4321/sse. Then click the "Connect" button. As before, list the tools, select one, and provide input values. You should see an output like this:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.en.png)

Great, you can work with Inspector! Now, let's see how to work with Visual Studio Code.

## Assignment

Try expanding your server with more features. For example, check out [this page](https://api.chucknorris.io/) to add a tool that calls an API. You decide how your server should function. Have fun :)

## Solution

[Solution](./solution/README.md) Here's a possible solution with working code.

## Key Takeaways

The main points from this chapter are:

- SSE is the second supported transport after stdio.
- To support SSE, you need to handle incoming connections and messages using a web framework.
- You can use both Inspector and Visual Studio Code to interact with an SSE server, similar to stdio servers. Note the differences: for SSE, you start the server separately and then run the inspector tool. Also, when using Inspector, you need to specify the server's URL.

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Additional Resources

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## What's Next

- Next: [HTTP Streaming with MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.