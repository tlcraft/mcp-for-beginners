# Creating a client with LLM

So far, you've seen how to create a server and a client. The client have been able to call the server explicitly to list its tools, resources and prompts. However, it's not very practical approach. Your user lives in the agentic era and expects to use prompts and communicate with an LLM to do so. For your user, it doesn't care if you use MCP or not to store your capabilities but they do expect to use natural language to interact. So how do we solve this? The solution is about adding an LLM to the client.

## Overview

In this lesson we focus on adding an LLM to do your client and show how this provides a much better experience for your user.

## Learning Objectives

By the end of this lesson, you will be able to:

- Create a client with an LLM.
- Seamlessly interact with an MCP server using an LLM.
- Provide a better end user experience on the client side.

## Approach

Let's try to understand the approach we need to take. Adding an LLM sounds simple, but will we actually do this?

Here's how the client will interact with the server:

1. Establish connection with server.

1. List capabilities, prompts, resources and tools, and save down their schema.

1. Add an LLM and pass the saved capabilities and their schema in a format the LLM understands.

1. Handle a user prompt by passing it to the LLM together with the tools listed by the client.

Great, now we understand how we can do this at high level, let's try this out in below exercise.

## Exercise: Creating a client with an LLM

In this exercise, we will learn to add an LLM to our client.

### -1- Connect to server

Let's create our client first:

<details>
<summary>Typescript</summary>

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MCPClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", 
            apiKey: process.env.GITHUB_TOKEN,
        });

        this.client = new Client(
            {
                name: "example-client",
                version: "1.0.0"
            },
            {
                capabilities: {
                prompts: {},
                resources: {},
                tools: {}
                }
            }
            );    
    }
}
```

In the preceding code we've:

- Imported the needed libraries
- Create a class with two members, `client` and `openai` that will help us manage a client and interact with an LLM respectively.
- Configured our LLM instance to use GitHub Models by setting `baseUrl` to point to the inference API.

</details>

Great, for our next step, let's list the capbilities on the server.

### -2 List server capabilities

Now we will connect to the server and ask for its capabilities:

<details>
<summary>Typescript</summary>

In the same class, add the following methods:

```typescript
async connectToServer(transport: Transport) {
     await this.client.connect(transport);
     this.run();
     console.error("MCPClient started on stdin/stdout");
}

async run() {
    console.log("Asking server for available tools");

    // listing tools
    const toolsResult = await this.client.listTools();
}
```

In the preceding code we've:

- Added code for connecting to the server, `connectToServer`.
- Created a `run` method responsible for handling our app flow. So far it only lists the tools but we will add more to it shortly.

</details>

### -3- Convert server capabilities to LLM tools

Next step after listing server capabilities is to convert them into a format that the LLM understands. Once we do that, we can provide these capabilities as tools to our LLM.

<details>
<summary>Typescript</summary>

1. Add the following code to convert response from MCP Server to a tool format the LLM can use:

    ```typescript
    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
        }) {
        // Create a zod schema based on the input_schema
        const schema = z.object(tool.input_schema);
    
        return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
            name: tool.name,
            description: tool.description,
            parameters: {
            type: "object",
            properties: tool.input_schema.properties,
            required: tool.input_schema.required,
            },
            },
        };
    }

    ```

    The above code takes a response from the MCP Server and converts that to a tool definition format the LLM can understand.

1. Let's update the `run` method next to list server capabilities:

    ```typescript
    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
            name: tool.name,
            description: tool.description,
            input_schema: tool.inputSchema,
            });
        });
    }
    ```

    In the preceding code, we've update the `run` method to map through the result and for each entry call `openAiToolAdapter`.

</details>

Great, we're not set up to handle any user requests, so let's tackle that next.

### -4- Handle user prompt request

In this part of the code, we will handle user requests.

<details>
<summary>Typescript</summary>

1. Add a method that will be used to call our LLM:

    ```typescript
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
    ) {
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);


        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  

        }
    }
    ```

    In the preceding code we:

    - Added a method `callTools`.
    - The method takes an LLM response and checks to see what tools have been called, if any:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Calls a tool, if LLM indicates it should be called:

        ```typescript
        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  
        ```

1. Update the `run` method to include calls to the LLM and calling `callTools`:

    ```typescript

    // 1. Create messages that's input for the LLM
    const prompt = "What is the sum of 2 and 3?"

    const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: prompt,
            },
        ];

    console.log("Querying LLM: ", messages[0].content);

    // 2. Calling the LLM
    let response = this.openai.chat.completions.create({
        model: "gpt-4o-mini",
        max_tokens: 1000,
        messages,
        tools: tools,
    });    

    let results: any[] = [];

    // 3. Go through the LLM response,for each choice, check if it has tool calls 
    (await response).choices.map(async (choice: { message: any; }) => {
        const message = choice.message;
        if (message.tool_calls) {
            console.log("Making tool call")
            await this.callTools(message.tool_calls, results);
        }
    });
    ```

Great, let's list the code in full:

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MyClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", // might need to change to this url in the future: https://models.github.ai/inference
            apiKey: process.env.GITHUB_TOKEN,
        });

       
        
        this.client = new Client(
            {
                name: "example-client",
                version: "1.0.0"
            },
            {
                capabilities: {
                prompts: {},
                resources: {},
                tools: {}
                }
            }
            );    
    }

    async connectToServer(transport: Transport) {
        await this.client.connect(transport);
        this.run();
        console.error("MCPClient started on stdin/stdout");
    }

    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
          }) {
          // Create a zod schema based on the input_schema
          const schema = z.object(tool.input_schema);
      
          return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
              name: tool.name,
              description: tool.description,
              parameters: {
              type: "object",
              properties: tool.input_schema.properties,
              required: tool.input_schema.required,
              },
            },
          };
    }
    
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
      ) {
        for (const tool_call of tool_calls) {
          const toolName = tool_call.function.name;
          const args = tool_call.function.arguments;
    
          console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);
    
    
          // 2. Call the server's tool 
          const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
          });
    
          console.log("Tool result: ", toolResult);
    
          // 3. Do something with the result
          // TODO  
    
         }
    }

    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
              name: tool.name,
              description: tool.description,
              input_schema: tool.inputSchema,
            });
        });
    
        const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: "What is the sum of 2 and 3?",
            },
        ];

        console.log("Querying LLM: ", messages[0].content);
        let response = this.openai.chat.completions.create({
            model: "gpt-4o-mini",
            max_tokens: 1000,
            messages,
            tools: tools,
        });    

        let results: any[] = [];
    
        // 1. Go through the LLM response,for each choice, check if it has tool calls 
        (await response).choices.map(async (choice: { message: any; }) => {
          const message = choice.message;
          if (message.tool_calls) {
              console.log("Making tool call")
              await this.callTools(message.tool_calls, results);
          }
        });
    }
    
}

let client = new MyClient();
 const transport = new StdioClientTransport({
            command: "node",
            args: ["./build/index.js"]
        });

client.connectToServer(transport);
```

</details>

## Assignment

Update the client you've created in previous chapter and ensure you can now talk to the server via prompts. Note the `prompt` variable, that's something you can set via a web browser or if you want to ask for user input from a command line program, up to you.

## Solution

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Key Takeaways

- Adding an LLM to your client provides a better way for users to interact with MCP Servers.
- You need to convert the MCP Server response to something the LLM can understand.

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../samples/csharp/)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../samples/python/) 

## Additional Resources

## What's Next

- Next: [Consuming a server using Visual Studio Code](/03-GettingStarted/04-vscode/README.md)
