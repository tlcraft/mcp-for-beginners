<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:56:49+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "pt"
}
-->
# Criar um cliente

Clientes são aplicações personalizadas ou scripts que comunicam diretamente com um Servidor MCP para solicitar recursos, ferramentas e prompts. Ao contrário de usar a ferramenta inspector, que oferece uma interface gráfica para interagir com o servidor, escrever o seu próprio cliente permite interações programáticas e automatizadas. Isto possibilita aos desenvolvedores integrar as capacidades do MCP nos seus próprios fluxos de trabalho, automatizar tarefas e construir soluções personalizadas adaptadas a necessidades específicas.

## Visão geral

Esta lição introduz o conceito de clientes dentro do ecossistema do Model Context Protocol (MCP). Vai aprender como escrever o seu próprio cliente e fazê-lo conectar a um Servidor MCP.

## Objetivos de aprendizagem

No final desta lição, será capaz de:

- Compreender o que um cliente pode fazer.
- Escrever o seu próprio cliente.
- Conectar e testar o cliente com um servidor MCP para garantir que este funciona como esperado.

## O que é necessário para escrever um cliente?

Para escrever um cliente, precisará de fazer o seguinte:

- **Importar as bibliotecas corretas**. Vai usar a mesma biblioteca de antes, apenas com construções diferentes.
- **Instanciar um cliente**. Isto envolve criar uma instância de cliente e conectá-la ao método de transporte escolhido.
- **Decidir quais recursos listar**. O seu servidor MCP vem com recursos, ferramentas e prompts; precisa decidir quais listar.
- **Integrar o cliente numa aplicação anfitriã**. Depois de conhecer as capacidades do servidor, precisa integrar isto na sua aplicação anfitriã para que, se um utilizador digitar um prompt ou outro comando, a funcionalidade correspondente do servidor seja invocada.

Agora que entendemos, a um nível geral, o que vamos fazer, vejamos um exemplo a seguir.

### Um cliente de exemplo

Vamos analisar este cliente de exemplo:

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

No código anterior nós:

- Importamos as bibliotecas
- Criámos uma instância de cliente e conectámo-la usando stdio como transporte.
- Listámos prompts, recursos e ferramentas e invocámo-los todos.

Aqui está, um cliente que pode comunicar com um Servidor MCP.

Vamos dedicar algum tempo na próxima secção de exercícios para analisar cada trecho de código e explicar o que está a acontecer.

## Exercício: Escrever um cliente

Como referido acima, vamos explicar o código com calma, e sinta-se à vontade para programar juntamente connosco se quiser.

### -1- Importar as bibliotecas

Vamos importar as bibliotecas necessárias, precisaremos de referências a um cliente e ao protocolo de transporte escolhido, stdio. stdio é um protocolo para coisas que se destinam a correr na sua máquina local. SSE é outro protocolo de transporte que mostraremos em capítulos futuros, mas essa é a sua outra opção. Por agora, vamos continuar com stdio.

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

Para Java, vai criar um cliente que se conecta ao servidor MCP do exercício anterior. Usando a mesma estrutura do projeto Java Spring Boot de [Introdução ao Servidor MCP](../../../../03-GettingStarted/01-first-server/solution/java), crie uma nova classe Java chamada `SDKClient` na pasta `src/main/java/com/microsoft/mcp/sample/client/` e adicione as seguintes importações:

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

Vamos avançar para a instanciação.

### -2- Instanciar cliente e transporte

Precisamos criar uma instância do transporte e outra do nosso cliente:

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

No código anterior nós:

- Criámos uma instância do transporte stdio. Note como especifica o comando e os argumentos para encontrar e iniciar o servidor, pois isso é algo que precisaremos fazer ao criar o cliente.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instanciámos um cliente dando-lhe um nome e versão.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Conectámos o cliente ao transporte escolhido.

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

No código anterior nós:

- Importámos as bibliotecas necessárias
- Instanciámos um objeto de parâmetros do servidor, pois vamos usá-lo para executar o servidor e assim podermos conectar-nos a ele com o nosso cliente.
- Definimos um método `run` que por sua vez chama `stdio_client`, que inicia uma sessão de cliente.
- Criámos um ponto de entrada onde fornecemos o método `run` para `asyncio.run`.

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

No código anterior nós:

- Importámos as bibliotecas necessárias.
- Criámos um transporte stdio e um cliente `mcpClient`. Este último será usado para listar e invocar funcionalidades no Servidor MCP.

Nota, em "Arguments", pode apontar para o *.csproj* ou para o executável.

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

No código anterior nós:

- Criámos um método main que configura um transporte SSE apontando para `http://localhost:8080`, onde o nosso servidor MCP estará a correr.
- Criámos uma classe cliente que recebe o transporte como parâmetro do construtor.
- No método `run`, criamos um cliente MCP síncrono usando o transporte e inicializamos a conexão.
- Usámos o transporte SSE (Server-Sent Events), adequado para comunicação HTTP com servidores MCP Java Spring Boot.

### -3- Listar as funcionalidades do servidor

Agora temos um cliente que pode conectar-se caso o programa seja executado. No entanto, ele não lista as suas funcionalidades, por isso vamos fazer isso a seguir:

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

Aqui listamos os recursos disponíveis, `list_resources()` e ferramentas, `list_tools` e imprimimo-los.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Acima está um exemplo de como podemos listar as ferramentas no servidor. Para cada ferramenta, imprimimos o seu nome.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

No código anterior nós:

- Chamámos `listTools()` para obter todas as ferramentas disponíveis do servidor MCP.
- Usámos `ping()` para verificar se a conexão com o servidor está a funcionar.
- O `ListToolsResult` contém informações sobre todas as ferramentas, incluindo nomes, descrições e esquemas de entrada.

Ótimo, agora capturámos todas as funcionalidades. Agora a questão é: quando as usamos? Bem, este cliente é bastante simples, simples no sentido de que precisaremos chamar explicitamente as funcionalidades quando as quisermos. No próximo capítulo, criaremos um cliente mais avançado que tem acesso ao seu próprio modelo de linguagem grande, LLM. Por agora, vamos ver como invocar as funcionalidades no servidor:

### -4- Invocar funcionalidades

Para invocar as funcionalidades, precisamos garantir que especificamos os argumentos corretos e, em alguns casos, o nome do que estamos a tentar invocar.

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

No código anterior nós:

- Lemos um recurso, chamamos o recurso usando `readResource()` especificando `uri`. Isto é o que provavelmente acontece no lado do servidor:

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

    O nosso valor `uri` `file://example.txt` corresponde a `file://{name}` no servidor. `example.txt` será mapeado para `name`.

- Chamamos uma ferramenta, especificando o seu `name` e os seus `arguments` assim:

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

    e o código resultante do cliente fica assim para corresponder ao que está declarado no servidor:

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

No código anterior nós:

- Chamámos um recurso chamado `greeting` usando `read_resource`.
- Invocámos uma ferramenta chamada `add` usando `call_tool`.

### .NET

1. Vamos adicionar algum código para chamar uma ferramenta:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Para imprimir o resultado, aqui está algum código para tratar disso:

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

No código anterior nós:

- Chamámos várias ferramentas de calculadora usando o método `callTool()` com objetos `CallToolRequest`.
- Cada chamada de ferramenta especifica o nome da ferramenta e um `Map` de argumentos necessários por essa ferramenta.
- As ferramentas do servidor esperam nomes específicos de parâmetros (como "a", "b" para operações matemáticas).
- Os resultados são retornados como objetos `CallToolResult` contendo a resposta do servidor.

### -5- Executar o cliente

Para executar o cliente, digite o seguinte comando no terminal:

### TypeScript

Adicione a seguinte entrada à sua secção "scripts" no *package.json*:

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

Primeiro, certifique-se de que o seu servidor MCP está a correr em `http://localhost:8080`. Depois execute o cliente:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternativamente, pode executar o projeto completo do cliente fornecido na pasta de solução `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Tarefa

Nesta tarefa, vai usar o que aprendeu para criar um cliente, mas crie um cliente seu.

Aqui está um servidor que pode usar e que precisa chamar via o seu código cliente, veja se consegue adicionar mais funcionalidades ao servidor para o tornar mais interessante.

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

Veja este projeto para saber como pode [adicionar prompts e recursos](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Também consulte este link para saber como invocar [prompts e recursos](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Solução

A **pasta da solução** contém implementações completas e prontas a executar de clientes que demonstram todos os conceitos abordados neste tutorial. Cada solução inclui código de cliente e servidor organizados em projetos separados e autónomos.

### 📁 Estrutura da Solução

O diretório da solução está organizado por linguagem de programação:

```
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw            # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 O que cada solução inclui

Cada solução específica para uma linguagem fornece:

- **Implementação completa do cliente** com todas as funcionalidades do tutorial
- **Estrutura de projeto funcional** com dependências e configuração adequadas
- **Scripts de construção e execução** para fácil configuração e execução
- **README detalhado** com instruções específicas para cada linguagem
- **Exemplos de tratamento de erros** e processamento de resultados

### 📖 Como usar as soluções

1. **Navegue até à pasta da linguagem preferida**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Siga as instruções do README** em cada pasta para:
   - Instalar dependências
   - Construir o projeto
   - Executar o cliente

3. **Exemplo de saída** que deverá ver:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Para documentação completa e instruções passo a passo, veja: **[📖 Documentação da Solução](./solution/README.md)**

## 🎯 Exemplos completos

Fornecemos implementações completas e funcionais de clientes para todas as linguagens de programação abordadas neste tutorial. Estes exemplos demonstram toda a funcionalidade descrita acima e podem ser usados como implementações de referência ou pontos de partida para os seus próprios projetos.

### Exemplos completos disponíveis

| Linguagem | Ficheiro | Descrição |
|----------|----------|-----------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | Cliente Java completo usando transporte SSE com tratamento de erros abrangente |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | Cliente C# completo usando transporte stdio com arranque automático do servidor |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Cliente TypeScript completo com suporte total ao protocolo MCP |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | Cliente Python completo usando padrões async/await |

Cada exemplo completo inclui:

- ✅ **Estabelecimento de conexão** e tratamento de erros
- ✅ **Descoberta do servidor** (ferramentas, recursos, prompts onde aplicável)
- ✅ **Operações de calculadora** (adicionar, subtrair, multiplicar, dividir, ajuda)
- ✅ **Processamento de resultados** e saída formatada
- ✅ **Tratamento de erros abrangente**
- ✅ **Código limpo e documentado** com comentários passo a passo

### Começar com os exemplos completos

1. **Escolha a sua linguagem preferida** na tabela acima
2. **Revise o ficheiro do exemplo completo** para entender a implementação completa
3. **Execute o exemplo** seguindo as instruções em [`complete_examples.md`](./complete_examples.md)
4. **Modifique e expanda** o exemplo para o seu caso específico

Para documentação detalhada sobre como executar e personalizar estes exemplos, veja: **[📖 Documentação dos Exemplos Completos](./complete_examples.md)**

### 💡 Solução vs. Exemplos Completos

| **Pasta da Solução** | **Exemplos Completos** |
|---------------------|-----------------------|
| Estrutura completa do projeto com ficheiros de construção | Implementações em ficheiro único |
| Pronto a executar com dependências | Exemplos de código focados |
| Configuração semelhante a produção | Referência educativa |
| Ferramentas específicas da linguagem | Comparação entre linguagens |
Ambas as abordagens são valiosas - use a **pasta solution** para projetos completos e os **exemplos completos** para aprendizagem e referência.

## Principais Conclusões

As principais conclusões deste capítulo sobre clientes são as seguintes:

- Podem ser usados tanto para descobrir como para invocar funcionalidades no servidor.
- Podem iniciar um servidor enquanto se iniciam a si próprios (como neste capítulo), mas os clientes também podem conectar-se a servidores já em execução.
- São uma ótima forma de testar as capacidades do servidor, ao lado de alternativas como o Inspector, conforme descrito no capítulo anterior.

## Recursos Adicionais

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Exemplos

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## O que vem a seguir

- Seguinte: [Creating a client with an LLM](../03-llm-client/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.