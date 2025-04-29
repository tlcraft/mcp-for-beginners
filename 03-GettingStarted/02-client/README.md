# Creating a client

Clients are custom applications or scripts that communicate directly with an MCP Server to request resources, tools, and prompts. Unlike using the inspector tool, which provides a graphical interface for interacting with the server, writing your own client allows for programmatic and automated interactions. This enables developers to integrate MCP capabilities into their own workflows, automate tasks, and build custom solutions tailored to specific needs.

## Overview

This lesson introduces the concept of clients within the Model Context Protocol (MCP) ecosystem. You'll learn how to write your own client and have it connect to an MCP Server.
 
## Learning Objectives

By the end of this lesson, you will be able to:

- Understand what a client can do.
- Write your own client.
- Connect and test the client with an MCP server to ensure the latter works as expected.

## What goes into writing a client?

To write a client, you'll need to do the following:

- **Import the correct libraries**. You'll be using the same library as before, just different constructs.
- **Instantiate a client**. This will involve creating a client instance and connect it to the chosen transport method.
- **Decide on what resources to list**. Your MCP server comes with resources, tools and prompts, you need to decide which one to list.
- **Integrate the client to a host application**. Once you know the capabilities of the server you need to integrate this your host application so that if a user types a prompt or other command the corresponding server feature is invoked.

Now that we understand at high level what we're about to do, let's look at an example next.

### An example client

Let's have a look at this example client:

<details>
<summary>TypeScript</summary>

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

</details>

In the preceding code we:

- Import the libraries
- Create an instance of a client and connect it using stdio for transport.
- List prompts, resources and tools and invoke them all.

There you have it, a client that can talk to an MCP Server.

Let's take our time in the next exercise section and break down each code snippet and explain what's going on.

## Exercise: Writing a client

As said above, let's take our time explaining the code, and by all means code along if you want.

### -1- Import the libraries

Let's import the libraries we need, we will need references to a client and to our chosen transport protocol, stdio. stdio is a protcol for things meant to run on your local machine. SSE is another transport protocol we will show in future chapters but that's your other option. For now though, let's continue with stdio. 

<details>
<summary>TypeScript</summary>

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

</details>

Let's move on to instantiation.

### -2- Instantiating client and transport

We will need to create an instance of the transport and that of our client:

<details>
<summary>TypeScript</summary>

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

In the preceding code we've:

- Created an stdio transport instance. Note how it specifices command and args for how to find and start up the server as that's something we will need to do as we create the client.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instantiated a client by giving it a name and version.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Connected the client to the chosen transport.

    ```typescript
    await client.connect(transport);
    ```

</details>

### -3- Listing the server features

Now, we have a client that can connect to should the program be run. However, it doesn't actually list its features so let's do that next:

<details>
<summary>TypeScript</summary>

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

</details>

Great, now we've captures all the features. Now the question is when do we use them? Well, this client is pretty simple, simple in the sense that we will need to explicitly call the features when we want them. In the next chapter, we will create a more advanced client that has access to it's own large language model, LLM. For now though, let's see how we can invoke the features on the server:

### -4- Invoke features

To invoke the features we need to ensure we specify the correct arguments and in some cases the name of what we're trying to invoke.

<details>
<summary>TypeScript</summary>

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

In the preceding code we:

- Read a resource, we call the resource by calling `readResource()` specifying `uri`. Here's what it most likely look like on the server side:

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    Our `uri` value `file://example.txt` matches `file://{name}` on the server. `example.txt` will be mapped to `name`.

- Call a tool, we call it by specifying its `name` and its `arguments` like so:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Get prompt, to get a prompt, you call `getPrompt()` with `name` and `arguments`. The server code looks like so:

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    and your resulting client code therefore looks like so to match what's declared on the server:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

</details>

### -5- Run the client

To run the client, type the following command in the terminal:

<details>
<summary>TypeScript</summary>

Add the following entry to your "scripts" section in *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

</details>

## Assignment

In this assignment, you'll use what you've learned in creating a client but create a client of your own.

Here's a server you can use that you need to call via your client code:

<details>
<summary>TypeScript</summary>

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

</details>


## Solution

[Solution](./solution/README.md)

## Key Takeaways

The key takeaways for this chapter is the following about clients:

- Can be used to both discover and invoke features on the server.
- Can start a server while it starts itself (like in this chapter) but clients can connect to running servers as well.
- Is a great way to test out server capabilities next to alternatives like the Inspector as was described in the previous chapter.

## Additional Resources

- TODO

## What's Next

- Next: [Creating a client with an LLM](/03-GettingStarted/03-llm-client/README.md)

