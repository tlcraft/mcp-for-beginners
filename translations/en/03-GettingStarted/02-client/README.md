<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:08:18+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "en"
}
-->
In the preceding code we:

- Import the libraries
- Create an instance of a client and connect it using stdio for transport.
- List prompts, resources, and tools and invoke them all.

There you have it, a client that can communicate with an MCP Server.

Let's take our time in the next exercise section to break down each code snippet and explain what's happening.

## Exercise: Writing a client

As mentioned above, let's take our time explaining the code, and by all means, code along if you want.

### -1- Import the libraries

Let's import the libraries we need. We will need references to a client and to our chosen transport protocol, stdio. stdio is a protocol for things meant to run on your local machine. SSE is another transport protocol we will show in future chapters, but that's your other option. For now though, let's continue with stdio.

Let's move on to instantiation.

### -2- Instantiating client and transport

We will need to create an instance of the transport and that of our client:

### -3- Listing the server features

Now, we have a client that can connect when the program is run. However, it doesn't actually list its features, so let's do that next:

Great, now we've captured all the features. Now the question is, when do we use them? Well, this client is pretty simple—simple in the sense that we will need to explicitly call the features when we want them. In the next chapter, we will create a more advanced client that has access to its own large language model, LLM. For now though, let's see how we can invoke the features on the server:

### -4- Invoke features

To invoke the features, we need to ensure we specify the correct arguments and, in some cases, the name of what we're trying to invoke.

### -5- Run the client

To run the client, type the following command in the terminal:

## Assignment

In this assignment, you'll use what you've learned in creating a client but create a client of your own.

Here's a server you can use that you need to call via your client code. See if you can add more features to the server to make it more interesting.

## Solution

[Solution](./solution/README.md)

## Key Takeaways

The key takeaways for this chapter about clients are:

- They can be used to both discover and invoke features on the server.
- They can start a server while starting themselves (like in this chapter), but clients can also connect to running servers.
- They are a great way to test out server capabilities alongside alternatives like the Inspector, as described in the previous chapter.

## Additional Resources

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## What's Next

- Next: [Creating a client with an LLM](../03-llm-client/README.md)

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.