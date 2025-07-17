<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T01:09:19+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "br"
}
-->
# Servidor SSE

SSE (Server Sent Events) é um padrão para streaming do servidor para o cliente, permitindo que servidores enviem atualizações em tempo real para os clientes via HTTP. Isso é especialmente útil para aplicações que precisam de atualizações ao vivo, como aplicativos de chat, notificações ou feeds de dados em tempo real. Além disso, seu servidor pode ser usado por vários clientes ao mesmo tempo, pois ele roda em um servidor que pode estar hospedado, por exemplo, na nuvem.

## Visão Geral

Esta lição aborda como construir e consumir Servidores SSE.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Construir um Servidor SSE.
- Depurar um Servidor SSE usando o Inspector.
- Consumir um Servidor SSE usando o Visual Studio Code.

## SSE, como funciona

SSE é um dos dois tipos de transporte suportados. Você já viu o primeiro, stdio, sendo usado em lições anteriores. A diferença é a seguinte:

- SSE exige que você gerencie duas coisas: conexão e mensagens.
- Como este é um servidor que pode estar em qualquer lugar, isso precisa refletir na forma como você trabalha com ferramentas como o Inspector e o Visual Studio Code. Isso significa que, em vez de indicar como iniciar o servidor, você aponta para o endpoint onde a conexão pode ser estabelecida. Veja o exemplo de código abaixo:

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

No código acima:

- `/sse` é configurado como uma rota. Quando uma requisição é feita para essa rota, uma nova instância de transporte é criada e o servidor *conecta* usando esse transporte.
- `/messages` é a rota que lida com as mensagens recebidas.

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

No código acima:

- Criamos uma instância de um servidor ASGI (usando especificamente o Starlette) e montamos a rota padrão `/`.

  O que acontece nos bastidores é que as rotas `/sse` e `/messages` são configuradas para lidar com conexões e mensagens, respectivamente. O restante da aplicação, como adicionar funcionalidades como ferramentas, acontece da mesma forma que nos servidores stdio.

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

    Existem dois métodos que nos ajudam a transformar um servidor web em um servidor web que suporta SSE:

    - `AddMcpServer`, este método adiciona as capacidades.
    - `MapMcp`, este adiciona rotas como `/SSE` e `/messages`.

Agora que sabemos um pouco mais sobre SSE, vamos construir um servidor SSE a seguir.

## Exercício: Criando um Servidor SSE

Para criar nosso servidor, precisamos ter em mente duas coisas:

- Precisamos usar um servidor web para expor endpoints para conexão e mensagens.
- Construir nosso servidor como normalmente fazemos, com ferramentas, recursos e prompts, como fazíamos com stdio.

### -1- Criar uma instância do servidor

Para criar nosso servidor, usamos os mesmos tipos que com stdio. Porém, para o transporte, precisamos escolher SSE.

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

No código acima, nós:

- Criamos uma instância do servidor.
- Definimos um app usando o framework web express.
- Criamos uma variável transports que usaremos para armazenar as conexões recebidas.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

No código acima, nós:

- Importamos as bibliotecas que vamos precisar, incluindo o Starlette (um framework ASGI).
- Criamos uma instância do servidor MCP chamada `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

Neste ponto, nós:

- Criamos um app web.
- Adicionamos suporte para recursos MCP através do `AddMcpServer`.

Vamos adicionar as rotas necessárias a seguir.

### -2- Adicionar rotas

Agora vamos adicionar as rotas que lidam com a conexão e as mensagens recebidas:

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

No código acima, definimos:

- Uma rota `/sse` que instancia um transporte do tipo SSE e acaba chamando `connect` no servidor MCP.
- Uma rota `/messages` que cuida das mensagens recebidas.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

No código acima, nós:

- Criamos uma instância do app ASGI usando o framework Starlette. Como parte disso, passamos `mcp.sse_app()` para a lista de rotas. Isso monta as rotas `/sse` e `/messages` na instância do app.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Adicionamos uma linha de código no final `add.MapMcp()`, isso significa que agora temos as rotas `/SSE` e `/messages`.

Vamos adicionar capacidades ao servidor a seguir.

### -3- Adicionando capacidades ao servidor

Agora que definimos tudo que é específico do SSE, vamos adicionar capacidades ao servidor como ferramentas, prompts e recursos.

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

Aqui está como você pode adicionar uma ferramenta, por exemplo. Esta ferramenta específica cria uma ferramenta chamada "random-joke" que chama uma API do Chuck Norris e retorna uma resposta JSON.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Agora seu servidor tem uma ferramenta.

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

1. Vamos criar algumas ferramentas primeiro, para isso criaremos um arquivo *Tools.cs* com o seguinte conteúdo:

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

  Aqui adicionamos o seguinte:

  - Criamos uma classe `Tools` com o decorador `McpServerToolType`.
  - Definimos uma ferramenta `AddNumbers` decorando o método com `McpServerTool`. Também fornecemos parâmetros e uma implementação.

1. Vamos usar a classe `Tools` que acabamos de criar:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Adicionamos uma chamada para `WithTools` que especifica `Tools` como a classe que contém as ferramentas. Pronto, estamos prontos.

Ótimo, temos um servidor usando SSE, vamos testá-lo a seguir.

## Exercício: Depurando um Servidor SSE com o Inspector

O Inspector é uma ótima ferramenta que vimos em uma lição anterior [Criando seu primeiro servidor](/03-GettingStarted/01-first-server/README.md). Vamos ver se conseguimos usar o Inspector aqui também:

### -1- Executando o inspector

Para rodar o inspector, você primeiro precisa ter um servidor SSE rodando, então vamos fazer isso a seguir:

1. Execute o servidor

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Note como usamos o executável `uvicorn` que é instalado quando digitamos `pip install "mcp[cli]"`. Digitar `server:app` significa que estamos tentando rodar um arquivo `server.py` que tenha uma instância Starlette chamada `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Isso deve iniciar o servidor. Para interagir com ele, você precisa de um novo terminal.

1. Execute o inspector

    > ![NOTE]
    > Execute isso em uma janela de terminal separada daquela onde o servidor está rodando. Também note que você precisa ajustar o comando abaixo para o URL onde seu servidor está rodando.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Rodar o inspector é igual em todos os runtimes. Note como, em vez de passar um caminho para o servidor e um comando para iniciar o servidor, passamos o URL onde o servidor está rodando e também especificamos a rota `/sse`.

### -2- Testando a ferramenta

Conecte ao servidor selecionando SSE na lista suspensa e preencha o campo de URL onde seu servidor está rodando, por exemplo http:localhost:4321/sse. Agora clique no botão "Connect". Como antes, selecione listar ferramentas, escolha uma ferramenta e forneça os valores de entrada. Você deve ver um resultado como o abaixo:

![Servidor SSE rodando no inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.br.png)

Ótimo, você consegue trabalhar com o inspector, agora vamos ver como trabalhar com o Visual Studio Code.

## Tarefa

Tente expandir seu servidor com mais capacidades. Veja [esta página](https://api.chucknorris.io/) para, por exemplo, adicionar uma ferramenta que chama uma API. Você decide como o servidor deve ser. Divirta-se :)

## Solução

[Solution](./solution/README.md) Aqui está uma possível solução com código funcionando.

## Principais Lições

As principais lições deste capítulo são:

- SSE é o segundo transporte suportado, ao lado do stdio.
- Para suportar SSE, você precisa gerenciar conexões e mensagens recebidas usando um framework web.
- Você pode usar tanto o Inspector quanto o Visual Studio Code para consumir um servidor SSE, assim como nos servidores stdio. Note que há algumas diferenças entre stdio e SSE. Para SSE, você precisa iniciar o servidor separadamente e depois rodar sua ferramenta inspector. Para o inspector, também há diferenças, pois você precisa especificar o URL.

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Recursos Adicionais

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## O que vem a seguir

- Próximo: [HTTP Streaming com MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.