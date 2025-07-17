<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T21:59:53+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "pt"
}
-->
# Servidor SSE

SSE (Server Sent Events) é um padrão para streaming do servidor para o cliente, permitindo que os servidores enviem atualizações em tempo real para os clientes através do HTTP. Isto é particularmente útil para aplicações que necessitam de atualizações ao vivo, como aplicações de chat, notificações ou feeds de dados em tempo real. Além disso, o seu servidor pode ser usado por vários clientes ao mesmo tempo, pois está alojado num servidor que pode estar, por exemplo, na cloud.

## Visão Geral

Esta lição aborda como construir e consumir Servidores SSE.

## Objetivos de Aprendizagem

No final desta lição, será capaz de:

- Construir um Servidor SSE.
- Depurar um Servidor SSE usando o Inspector.
- Consumir um Servidor SSE usando o Visual Studio Code.

## SSE, como funciona

SSE é um dos dois tipos de transporte suportados. Já viu o primeiro, stdio, a ser usado em lições anteriores. A diferença é a seguinte:

- SSE exige que trate de duas coisas: conexão e mensagens.
- Como este é um servidor que pode estar em qualquer lugar, precisa que isso se reflita na forma como trabalha com ferramentas como o Inspector e o Visual Studio Code. Isto significa que, em vez de indicar como iniciar o servidor, aponta para o endpoint onde pode estabelecer uma conexão. Veja o exemplo de código abaixo:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

No código anterior:

- `/sse` está configurado como uma rota. Quando é feita uma requisição para esta rota, é criada uma nova instância de transporte e o servidor *conecta-se* usando este transporte.
- `/messages` é a rota que trata das mensagens recebidas.

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

No código anterior:

- Criamos uma instância de um servidor ASGI (usando especificamente o Starlette) e montamos a rota padrão `/`.

  O que acontece nos bastidores é que as rotas `/sse` e `/messages` são configuradas para tratar conexões e mensagens, respetivamente. O resto da aplicação, como adicionar funcionalidades como ferramentas, acontece como nos servidores stdio.

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    Existem dois métodos que nos ajudam a passar de um servidor web para um servidor web que suporta SSE, que são:

    - `AddMcpServer`, este método adiciona capacidades.
    - `MapMcp`, este adiciona rotas como `/SSE` e `/messages`.

Agora que sabemos um pouco mais sobre SSE, vamos construir um servidor SSE.

## Exercício: Criar um Servidor SSE

Para criar o nosso servidor, precisamos ter em mente duas coisas:

- Precisamos usar um servidor web para expor endpoints para conexão e mensagens.
- Construir o nosso servidor como normalmente fazemos com ferramentas, recursos e prompts quando usávamos stdio.

### -1- Criar uma instância do servidor

Para criar o nosso servidor, usamos os mesmos tipos que com stdio. No entanto, para o transporte, precisamos escolher SSE.

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

No código anterior:

- Criámos uma instância do servidor.
- Definimos uma app usando o framework web express.
- Criámos uma variável transports que usaremos para armazenar as conexões recebidas.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

No código anterior:

- Importámos as bibliotecas que vamos precisar, incluindo o Starlette (um framework ASGI).
- Criámos uma instância do servidor MCP chamada `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Neste ponto, já:

- Criámos uma aplicação web.
- Adicionámos suporte para funcionalidades MCP através do `AddMcpServer`.

Vamos adicionar as rotas necessárias a seguir.

### -2- Adicionar rotas

Vamos adicionar as rotas que tratam da conexão e das mensagens recebidas:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No transport found for sessionId');
  }
});

app.listen(3001);
```

No código anterior definimos:

- Uma rota `/sse` que instancia um transporte do tipo SSE e acaba por chamar `connect` no servidor MCP.
- Uma rota `/messages` que trata das mensagens recebidas.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

No código anterior:

- Criámos uma instância da app ASGI usando o framework Starlette. Como parte disso, passámos `mcp.sse_app()` para a lista de rotas. Isso acaba por montar as rotas `/sse` e `/messages` na instância da app.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Adicionámos uma linha de código no final `add.MapMcp()`, o que significa que agora temos as rotas `/SSE` e `/messages`.

Vamos adicionar capacidades ao servidor a seguir.

### -3- Adicionar capacidades ao servidor

Agora que temos tudo o que é específico do SSE definido, vamos adicionar capacidades ao servidor como ferramentas, prompts e recursos.

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

Aqui está como pode adicionar uma ferramenta, por exemplo. Esta ferramenta específica cria uma ferramenta chamada "random-joke" que chama uma API do Chuck Norris e retorna uma resposta JSON.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Agora o seu servidor tem uma ferramenta.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Create an MCP server
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Vamos criar algumas ferramentas primeiro, para isso vamos criar um ficheiro *Tools.cs* com o seguinte conteúdo:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  Aqui adicionámos o seguinte:

  - Criámos uma classe `Tools` com o decorador `McpServerToolType`.
  - Definimos uma ferramenta `AddNumbers` decorando o método com `McpServerTool`. Também fornecemos parâmetros e uma implementação.

1. Vamos usar a classe `Tools` que acabámos de criar:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Adicionámos uma chamada a `WithTools` que especifica `Tools` como a classe que contém as ferramentas. É tudo, estamos prontos.

Ótimo, temos um servidor a usar SSE, vamos testá-lo a seguir.

## Exercício: Depurar um Servidor SSE com o Inspector

O Inspector é uma ótima ferramenta que vimos numa lição anterior [Criar o seu primeiro servidor](/03-GettingStarted/01-first-server/README.md). Vamos ver se conseguimos usar o Inspector aqui também:

### -1- Executar o inspector

Para executar o inspector, primeiro deve ter um servidor SSE a correr, por isso vamos fazer isso a seguir:

1. Execute o servidor 

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Note como usamos o executável `uvicorn` que é instalado quando digitamos `pip install "mcp[cli]"`. Digitar `server:app` significa que estamos a tentar executar um ficheiro `server.py` e que este tem uma instância Starlette chamada `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Isto deve iniciar o servidor. Para interagir com ele precisa de um novo terminal.

1. Execute o inspector

    > ![NOTE]
    > Execute isto numa janela de terminal separada daquela onde o servidor está a correr. Note também que precisa de ajustar o comando abaixo para corresponder ao URL onde o seu servidor está a correr.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Executar o inspector é igual em todos os runtimes. Note como, em vez de passar um caminho para o nosso servidor e um comando para iniciar o servidor, passamos o URL onde o servidor está a correr e especificamos também a rota `/sse`.

### -2- Experimentar a ferramenta

Conecte o servidor selecionando SSE na lista suspensa e preencha o campo url onde o seu servidor está a correr, por exemplo http:localhost:4321/sse. Agora clique no botão "Connect". Como antes, selecione listar ferramentas, escolha uma ferramenta e forneça valores de entrada. Deve ver um resultado como o abaixo:

![Servidor SSE a correr no inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.pt.png)

Ótimo, consegue trabalhar com o inspector, vamos ver como trabalhar com o Visual Studio Code a seguir.

## Tarefa

Tente expandir o seu servidor com mais capacidades. Veja [esta página](https://api.chucknorris.io/) para, por exemplo, adicionar uma ferramenta que chama uma API. Você decide como o servidor deve ser. Divirta-se :)

## Solução

[Solução](./solution/README.md) Aqui está uma possível solução com código funcional.

## Principais Conclusões

As principais conclusões deste capítulo são as seguintes:

- SSE é o segundo transporte suportado, ao lado do stdio.
- Para suportar SSE, precisa de gerir conexões e mensagens recebidas usando um framework web.
- Pode usar tanto o Inspector como o Visual Studio Code para consumir um servidor SSE, tal como nos servidores stdio. Note que há algumas diferenças entre stdio e SSE. Para SSE, precisa iniciar o servidor separadamente e depois executar a ferramenta inspector. Para o inspector, também há diferenças, pois precisa especificar o URL.

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Recursos Adicionais

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## O que vem a seguir

- Seguinte: [HTTP Streaming com MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.