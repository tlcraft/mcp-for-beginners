<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:39:24+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "en"
}
-->
Now that we know a bit more about SSE, let's move on to building an SSE server.

## Exercise: Creating an SSE Server

When creating our server, we need to keep two things in mind:

- We need to use a web server to expose endpoints for connections and messages.
- Build our server the usual way with tools, resources, and prompts, just like we did with stdio.

### -1- Create a server instance

To create our server, we use the same types as with stdio. However, for the transport, we need to select SSE.

Let's add the necessary routes next.

### -2- Add routes

Now, let's add routes that handle the connection and incoming messages:

Let's add capabilities to the server next.

### -3- Adding server capabilities

With all SSE-specific parts defined, let's add server capabilities such as tools, prompts, and resources.

Your complete code should look like this:

Great, we have a server using SSE. Let’s test it out next.

## Exercise: Debugging an SSE Server with Inspector

Inspector is a fantastic tool we saw in an earlier lesson [Creating your first server](/03-GettingStarted/01-first-server/README.md). Let's check if we can use Inspector here as well:

### -1- Running the inspector

To run Inspector, you first need to have an SSE server running, so let's start it:

1. Run the server

1. Run the inspector

    > ![NOTE]
    > Run this in a separate terminal window from where the server is running. Also, be sure to adjust the command below to match the URL where your server is running.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Running Inspector works the same across all runtimes. Notice that instead of passing a path to your server and a command to start it, you provide the URL where the server is running, specifying the `/sse` route.

### -2- Trying out the tool

Connect to the server by selecting SSE from the dropdown and entering the URL where your server runs, for example http://localhost:4321/sse. Then click the "Connect" button. As before, choose to list tools, select a tool, and provide input values. You should see a result like this:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.en.png)

Awesome, you’re able to use Inspector! Next, let’s see how to work with Visual Studio Code.

## Assignment

Try expanding your server with additional capabilities. Check out [this page](https://api.chucknorris.io/) to, for example, add a tool that calls an API. You decide how your server should look. Have fun :)

## Solution

[Solution](./solution/README.md) Here’s one possible solution with working code.

## Key Takeaways

Here are the main points from this chapter:

- SSE is the second supported transport type alongside stdio.
- Supporting SSE requires managing incoming connections and messages using a web framework.
- You can use both Inspector and Visual Studio Code to consume an SSE server, just like with stdio servers. Note that there are some differences between stdio and SSE: with SSE, you start the server separately and then run your inspector tool. Also, for the inspector tool, you need to specify the URL.

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