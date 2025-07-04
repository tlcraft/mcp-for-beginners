<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-04T15:16:51+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "en"
}
-->
Great, for our next step, let's list the capabilities on the server.

### -2 List server capabilities

Now we will connect to the server and ask for its capabilities:

### -3- Convert server capabilities to LLM tools

The next step after listing server capabilities is to convert them into a format that the LLM understands. Once we do that, we can provide these capabilities as tools to our LLM.

Great, we're now set up to handle user requests, so let's tackle that next.

### -4- Handle user prompt request

In this part of the code, we will handle user requests.

Great, you did it!

## Assignment

Take the code from the exercise and build out the server with some more tools. Then create a client with an LLM, like in the exercise, and test it out with different prompts to make sure all your server tools get called dynamically. This way of building a client means the end user will have a great user experience as they're able to use prompts, instead of exact client commands, and be unaware of any MCP server being called.

## Solution 

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Key Takeaways

- Adding an LLM to your client provides a better way for users to interact with MCP Servers.
- You need to convert the MCP Server response to something the LLM can understand.

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Additional Resources

## What's Next

- Next: [Consuming a server using Visual Studio Code](../04-vscode/README.md)

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.