<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:13:52+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ms"
}
-->
### -2- Create project

Now that you have your SDK installed, let's move on to creating a project:

### -3- Create project files

### -4- Create server code

### -5- Adding a tool and a resource

Add a tool and a resource by including the following code:

### -6 Final code

Let's add the final pieces of code needed to start the server:

### -7- Test the server

Start the server using the following command:

### -8- Run using the inspector

The inspector is a fantastic tool that can launch your server and let you interact with it to verify that everything works correctly. Let’s get it started:

> [!NOTE]
> The "command" field might look different because it contains the command to run a server with your specific runtime.

You should see the following user interface:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ms.png)

1. Connect to the server by clicking the Connect button.  
   Once connected, you should see this:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ms.png)

2. Select "Tools" and then "listTools". You should see the "Add" tool appear. Click "Add" and fill in the parameter values.

   You should get a response like this, showing the result from the "add" tool:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ms.png)

Congratulations, you’ve successfully created and run your first server!

### Official SDKs

MCP offers official SDKs for multiple programming languages:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Maintained in collaboration with Microsoft  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Maintained in collaboration with Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - The official TypeScript implementation  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - The official Python implementation  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - The official Kotlin implementation  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Maintained in collaboration with Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - The official Rust implementation  

## Key Takeaways

- Setting up an MCP development environment is simple using language-specific SDKs  
- Building MCP servers means creating and registering tools with clear schemas  
- Testing and debugging are crucial for building reliable MCP implementations  

## Samples

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Assignment

Create a simple MCP server with a tool of your choice:  
1. Implement the tool in your preferred language (.NET, Java, Python, or JavaScript).  
2. Define input parameters and return values.  
3. Run the inspector tool to verify the server works as expected.  
4. Test the implementation with various inputs.  

## Solution

[Solution](./solution/README.md)

## Additional Resources

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## What's next

Next: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.