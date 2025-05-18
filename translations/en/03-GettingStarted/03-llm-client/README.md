<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:13:05+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "en"
}
-->
# Creating a client with LLM

So far, you've seen how to create a server and a client. The client has been able to call the server explicitly to list its tools, resources, and prompts. However, this isn't a very practical approach. Your user lives in the agentic era and expects to use prompts and communicate with an LLM to do so. For your user, it doesn't matter if you use MCP or not to store your capabilities, but they do expect to use natural language to interact. So how do we solve this? The solution is about adding an LLM to the client.

## Overview

In this lesson, we focus on adding an LLM to your client and show how this provides a much better experience for your user.

## Learning Objectives

By the end of this lesson, you will be able to:

- Create a client with an LLM.
- Seamlessly interact with an MCP server using an LLM.
- Provide a better end-user experience on the client side.

## Approach

Let's try to understand the approach we need to take. Adding an LLM sounds simple, but how will we actually do this?

Here's how the client will interact with the server:

1. Establish a connection with the server.

1. List capabilities, prompts, resources, and tools, and save down their schema.

1. Add an LLM and pass the saved capabilities and their schema in a format the LLM understands.

1. Handle a user prompt by passing it to the LLM together with the tools listed by the client.

Great, now we understand how we can do this at a high level, let's try this out in the exercise below.

## Exercise: Creating a client with an LLM

In this exercise, we will learn to add an LLM to our client.

### -1- Connect to server

Let's create our client first:
You are trained on data up to October 2023.

Great, for our next step, let's list the capabilities on the server.

### -2 List server capabilities

Now we will connect to the server and ask for its capabilities:

### -3- Convert server capabilities to LLM tools

The next step after listing server capabilities is to convert them into a format that the LLM understands. Once we do that, we can provide these capabilities as tools to our LLM.

Great, we're now set up to handle any user requests, so let's tackle that next.

### -4- Handle user prompt request

In this part of the code, we will handle user requests.

Great, you did it!

## Assignment

Take the code from the exercise and build out the server with some more tools. Then create a client with an LLM, like in the exercise, and test it out with different prompts to make sure all your server tools get called dynamically. This way of building a client means the end user will have a great user experience as they're able to use prompts, instead of exact client commands, and be oblivious to any MCP server being called.

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

- Next: [Consuming a server using Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

Sure, please provide the text you would like translated into English.