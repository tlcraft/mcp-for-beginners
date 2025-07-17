<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-17T01:07:49+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "br"
}
-->
# Criando um cliente

Clientes são aplicações personalizadas ou scripts que se comunicam diretamente com um MCP Server para solicitar recursos, ferramentas e prompts. Diferente de usar a ferramenta inspector, que oferece uma interface gráfica para interagir com o servidor, criar seu próprio cliente permite interações programáticas e automatizadas. Isso possibilita que desenvolvedores integrem as funcionalidades do MCP em seus próprios fluxos de trabalho, automatizem tarefas e construam soluções personalizadas para necessidades específicas.

## Visão geral

Esta lição apresenta o conceito de clientes dentro do ecossistema do Model Context Protocol (MCP). Você aprenderá como escrever seu próprio cliente e conectá-lo a um MCP Server.

## Objetivos de aprendizagem

Ao final desta lição, você será capaz de:

- Entender o que um cliente pode fazer.
- Escrever seu próprio cliente.
- Conectar e testar o cliente com um servidor MCP para garantir que ele funcione conforme esperado.

## O que envolve escrever um cliente?

Para escrever um cliente, você precisará fazer o seguinte:

- **Importar as bibliotecas corretas**. Você usará a mesma biblioteca de antes, apenas com construções diferentes.
- **Instanciar um cliente**. Isso envolve criar uma instância do cliente e conectá-lo ao método de transporte escolhido.
- **Decidir quais recursos listar**. Seu servidor MCP oferece recursos, ferramentas e prompts; você precisa decidir quais listar.
- **Integrar o cliente a uma aplicação host**. Depois de conhecer as capacidades do servidor, você precisa integrar isso à sua aplicação host para que, quando um usuário digitar um prompt ou outro comando, a funcionalidade correspondente do servidor seja acionada.

Agora que entendemos, em alto nível, o que faremos, vamos ver um exemplo a seguir.

### Um cliente de exemplo

Vamos dar uma olhada neste cliente de exemplo:

### TypeScript

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

No código acima nós:

- Importamos as bibliotecas
- Criamos uma instância do cliente e conectamos usando stdio como transporte.
- Listamos prompts, recursos e ferramentas e os invocamos todos.

Pronto, um cliente que pode se comunicar com um MCP Server.

Vamos dedicar um tempo na próxima seção de exercícios para analisar cada trecho de código e explicar o que está acontecendo.

## Exercício: Escrevendo um cliente

Como dito acima, vamos com calma explicando o código, e sinta-se à vontade para codificar junto se quiser.

### -1- Importando as bibliotecas

Vamos importar as bibliotecas que precisamos, precisaremos de referências a um cliente e ao protocolo de transporte escolhido, stdio. stdio é um protocolo para coisas que rodam na sua máquina local. SSE é outro protocolo de transporte que mostraremos em capítulos futuros, mas essa é sua outra opção. Por enquanto, vamos continuar com stdio.

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

Para Java, você criará um cliente que se conecta ao MCP server do exercício anterior. Usando a mesma estrutura do projeto Java Spring Boot de [Introdução ao MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), crie uma nova classe Java chamada `SDKClient` na pasta `src/main/java/com/microsoft/mcp/sample/client/` e adicione os seguintes imports:

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

Vamos seguir para a instanciação.

### -2- Instanciando cliente e transporte

Precisamos criar uma instância do transporte e outra do cliente:

### TypeScript

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

No código acima nós:

- Criamos uma instância do transporte stdio. Note como ele especifica o comando e os argumentos para localizar e iniciar o servidor, pois isso será necessário ao criar o cliente.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instanciamos um cliente dando um nome e versão.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Conectamos o cliente ao transporte escolhido.

    ```typescript
    await client.connect(transport);
    ```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client

# Create server parameters for stdio connection
server_params = StdioServerParameters(
    command="mcp",  # Executable
    args=["run", "server.py"],  # Optional command line arguments
    env=None,  # Optional environment variables
)

async def run():
    async with stdio_client(server_params) as (read, write):
        async with ClientSession(
            read, write
        ) as session:
            # Initialize the connection
            await session.initialize()

          

if __name__ == "__main__":
    import asyncio

    asyncio.run(run())
```

No código acima nós:

- Importamos as bibliotecas necessárias
- Instanciamos um objeto de parâmetros do servidor, pois usaremos isso para rodar o servidor e assim conectar o cliente a ele.
- Definimos um método `run` que chama `stdio_client`, que inicia uma sessão do cliente.
- Criamos um ponto de entrada onde passamos o método `run` para `asyncio.run`.

### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

No código acima nós:

- Importamos as bibliotecas necessárias.
- Criamos um transporte stdio e um cliente `mcpClient`. Este último será usado para listar e invocar funcionalidades no MCP Server.

Note que, em "Arguments", você pode apontar tanto para o *.csproj* quanto para o executável.

### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

No código acima nós:

- Criamos um método main que configura um transporte SSE apontando para `http://localhost:8080`, onde nosso MCP server estará rodando.
- Criamos uma classe cliente que recebe o transporte como parâmetro no construtor.
- No método `run`, criamos um cliente MCP síncrono usando o transporte e inicializamos a conexão.
- Usamos o transporte SSE (Server-Sent Events), adequado para comunicação HTTP com servidores MCP Java Spring Boot.

### -3- Listando as funcionalidades do servidor

Agora temos um cliente que pode se conectar caso o programa seja executado. Porém, ele ainda não lista as funcionalidades, então vamos fazer isso a seguir:

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

### Python

```python
# List available resources
resources = await session.list_resources()
print("LISTING RESOURCES")
for resource in resources:
    print("Resource: ", resource)

# List available tools
tools = await session.list_tools()
print("LISTING TOOLS")
for tool in tools.tools:
    print("Tool: ", tool.name)
```

Aqui listamos os recursos disponíveis, `list_resources()` e ferramentas, `list_tools`, e os imprimimos.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Acima está um exemplo de como listar as ferramentas no servidor. Para cada ferramenta, imprimimos seu nome.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

No código acima nós:

- Chamamos `listTools()` para obter todas as ferramentas disponíveis no MCP server.
- Usamos `ping()` para verificar se a conexão com o servidor está funcionando.
- O `ListToolsResult` contém informações sobre todas as ferramentas, incluindo nomes, descrições e esquemas de entrada.

Ótimo, agora capturamos todas as funcionalidades. A pergunta é: quando usá-las? Bem, este cliente é bem simples, no sentido de que precisamos chamar explicitamente as funcionalidades quando quisermos. No próximo capítulo, criaremos um cliente mais avançado que terá acesso ao seu próprio modelo de linguagem grande, LLM. Por enquanto, vamos ver como invocar as funcionalidades no servidor:

### -4- Invocando funcionalidades

Para invocar as funcionalidades, precisamos garantir que especificamos os argumentos corretos e, em alguns casos, o nome do que estamos tentando invocar.

### TypeScript

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

No código acima nós:

- Lemos um recurso, chamamos o recurso usando `readResource()` especificando o `uri`. Veja como provavelmente é no lado do servidor:

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

    Nosso valor `uri` `file://example.txt` corresponde a `file://{name}` no servidor. `example.txt` será mapeado para `name`.

- Chamamos uma ferramenta, especificando seu `name` e seus `arguments` assim:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Obtemos um prompt, para isso chamamos `getPrompt()` com `name` e `arguments`. O código do servidor é assim:

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

    e o código resultante no cliente fica assim para corresponder ao que foi declarado no servidor:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

No código acima nós:

- Chamamos um recurso chamado `greeting` usando `read_resource`.
- Invocamos uma ferramenta chamada `add` usando `call_tool`.

### C#

1. Vamos adicionar um código para chamar uma ferramenta:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Para imprimir o resultado, aqui está um código para isso:

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

No código acima nós:

- Chamamos várias ferramentas de calculadora usando o método `callTool()` com objetos `CallToolRequest`.
- Cada chamada especifica o nome da ferramenta e um `Map` de argumentos necessários.
- As ferramentas do servidor esperam nomes específicos de parâmetros (como "a", "b" para operações matemáticas).
- Os resultados são retornados como objetos `CallToolResult` contendo a resposta do servidor.

### -5- Executando o cliente

Para executar o cliente, digite o seguinte comando no terminal:

### TypeScript

Adicione a seguinte entrada na seção "scripts" do seu *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Execute o cliente com o seguinte comando:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Primeiro, certifique-se de que seu MCP server está rodando em `http://localhost:8080`. Depois execute o cliente:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternativamente, você pode executar o projeto completo do cliente fornecido na pasta de solução `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Tarefa

Nesta tarefa, você usará o que aprendeu para criar um cliente, mas crie um cliente próprio.

Aqui está um servidor que você pode usar e que precisa chamar via seu código cliente. Veja se consegue adicionar mais funcionalidades ao servidor para torná-lo mais interessante.

### TypeScript

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

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

Veja este projeto para entender como [adicionar prompts e recursos](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Também confira este link para saber como invocar [prompts e recursos](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Solução

[Solution](./solution/README.md)

## Principais aprendizados

Os principais aprendizados deste capítulo sobre clientes são:

- Podem ser usados tanto para descobrir quanto para invocar funcionalidades no servidor.
- Podem iniciar um servidor enquanto se iniciam (como neste capítulo), mas clientes também podem se conectar a servidores já em execução.
- São uma ótima forma de testar as capacidades do servidor, ao lado de alternativas como o Inspector, conforme descrito no capítulo anterior.

## Recursos adicionais

- [Construindo clientes no MCP](https://modelcontextprotocol.io/quickstart/client)

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## O que vem a seguir

- Próximo: [Criando um cliente com um LLM](../03-llm-client/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.