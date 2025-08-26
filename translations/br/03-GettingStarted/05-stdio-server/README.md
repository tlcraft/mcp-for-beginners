<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:30:50+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "br"
}
-->
# Servidor MCP com Transporte stdio

> **⚠️ Atualização Importante**: A partir da Especificação MCP 2025-06-18, o transporte SSE (Server-Sent Events) independente foi **descontinuado** e substituído pelo transporte "HTTP Streamable". A especificação atual do MCP define dois mecanismos principais de transporte:
> 1. **stdio** - Entrada/saída padrão (recomendado para servidores locais)
> 2. **HTTP Streamable** - Para servidores remotos que podem usar SSE internamente
>
> Esta lição foi atualizada para focar no **transporte stdio**, que é a abordagem recomendada para a maioria das implementações de servidores MCP.

O transporte stdio permite que servidores MCP se comuniquem com clientes por meio de fluxos de entrada e saída padrão. Este é o mecanismo de transporte mais utilizado e recomendado na especificação atual do MCP, proporcionando uma maneira simples e eficiente de construir servidores MCP que podem ser facilmente integrados a várias aplicações cliente.

## Visão Geral

Esta lição aborda como construir e consumir servidores MCP usando o transporte stdio.

## Objetivos de Aprendizado

Ao final desta lição, você será capaz de:

- Construir um servidor MCP usando o transporte stdio.
- Depurar um servidor MCP usando o Inspector.
- Consumir um servidor MCP usando o Visual Studio Code.
- Compreender os mecanismos de transporte atuais do MCP e por que o stdio é recomendado.

## Transporte stdio - Como Funciona

O transporte stdio é um dos dois tipos de transporte suportados na especificação atual do MCP (2025-06-18). Veja como ele funciona:

- **Comunicação Simples**: O servidor lê mensagens JSON-RPC da entrada padrão (`stdin`) e envia mensagens para a saída padrão (`stdout`).
- **Baseado em Processo**: O cliente inicia o servidor MCP como um subprocesso.
- **Formato de Mensagem**: As mensagens são solicitações, notificações ou respostas JSON-RPC individuais, delimitadas por quebras de linha.
- **Registro de Logs**: O servidor PODE escrever strings UTF-8 na saída de erro padrão (`stderr`) para fins de log.

### Requisitos Principais:
- As mensagens DEVEM ser delimitadas por quebras de linha e NÃO DEVEM conter quebras de linha embutidas.
- O servidor NÃO DEVE escrever nada em `stdout` que não seja uma mensagem MCP válida.
- O cliente NÃO DEVE escrever nada na `stdin` do servidor que não seja uma mensagem MCP válida.

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

No código acima:

- Importamos a classe `Server` e o `StdioServerTransport` do SDK MCP.
- Criamos uma instância do servidor com configuração básica e capacidades.

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

No código acima:

- Criamos uma instância do servidor usando o SDK MCP.
- Definimos ferramentas usando decoradores.
- Utilizamos o gerenciador de contexto stdio_server para lidar com o transporte.

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

A principal diferença em relação ao SSE é que servidores stdio:

- Não requerem configuração de servidor web ou endpoints HTTP.
- São iniciados como subprocessos pelo cliente.
- Se comunicam por meio de fluxos stdin/stdout.
- São mais simples de implementar e depurar.

## Exercício: Criando um Servidor stdio

Para criar nosso servidor, precisamos ter em mente dois pontos:

- Precisamos usar um servidor web para expor endpoints para conexão e mensagens.

## Laboratório: Criando um servidor MCP stdio simples

Neste laboratório, criaremos um servidor MCP simples usando o transporte stdio recomendado. Este servidor exporá ferramentas que os clientes podem chamar usando o protocolo Model Context Protocol.

### Pré-requisitos

- Python 3.8 ou superior
- SDK MCP para Python: `pip install mcp`
- Conhecimento básico de programação assíncrona

Vamos começar criando nosso primeiro servidor MCP stdio:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## Principais diferenças em relação à abordagem SSE descontinuada

**Transporte Stdio (Padrão Atual):**
- Modelo simples de subprocesso - o cliente inicia o servidor como processo filho.
- Comunicação via stdin/stdout usando mensagens JSON-RPC.
- Não requer configuração de servidor HTTP.
- Melhor desempenho e segurança.
- Depuração e desenvolvimento mais fáceis.

**Transporte SSE (Descontinuado a partir de MCP 2025-06-18):**
- Requeria servidor HTTP com endpoints SSE.
- Configuração mais complexa com infraestrutura de servidor web.
- Considerações adicionais de segurança para endpoints HTTP.
- Agora substituído pelo HTTP Streamable para cenários baseados na web.

### Criando um servidor com transporte stdio

Para criar nosso servidor stdio, precisamos:

1. **Importar as bibliotecas necessárias** - Precisamos dos componentes do servidor MCP e do transporte stdio.
2. **Criar uma instância do servidor** - Definir o servidor com suas capacidades.
3. **Definir ferramentas** - Adicionar as funcionalidades que queremos expor.
4. **Configurar o transporte** - Configurar a comunicação stdio.
5. **Executar o servidor** - Iniciar o servidor e lidar com mensagens.

Vamos construir isso passo a passo:

### Passo 1: Criar um servidor stdio básico

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### Passo 2: Adicionar mais ferramentas

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### Passo 3: Executar o servidor

Salve o código como `server.py` e execute-o na linha de comando:

```bash
python server.py
```

O servidor será iniciado e aguardará entrada via stdin. Ele se comunica usando mensagens JSON-RPC sobre o transporte stdio.

### Passo 4: Testar com o Inspector

Você pode testar seu servidor usando o MCP Inspector:

1. Instale o Inspector: `npx @modelcontextprotocol/inspector`
2. Execute o Inspector e aponte para o seu servidor.
3. Teste as ferramentas que você criou.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Debug MCP Server",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// Adicionar ferramentas
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Obter uma saudação personalizada",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Nome da pessoa a ser saudada",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `Olá, ${request.params.arguments?.name}! Bem-vindo ao servidor MCP stdio.`,
        },
      ],
    };
  } else {
    throw new Error(`Ferramenta desconhecida: ${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("Obter uma saudação personalizada")]
    public string GetGreeting(string name)
    {
        return $"Olá, {name}! Bem-vindo ao servidor MCP stdio.";
    }

    [Description("Calcular a soma de dois números")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. Vamos criar algumas ferramentas primeiro. Para isso, criaremos um arquivo *Tools.cs* com o seguinte conteúdo:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **Abra a interface web**: O Inspector abrirá uma janela do navegador mostrando as capacidades do seu servidor.

3. **Teste as ferramentas**: 
   - Experimente a ferramenta `get_greeting` com diferentes nomes.
   - Teste a ferramenta `calculate_sum` com vários números.
   - Chame a ferramenta `get_server_info` para ver os metadados do servidor.

4. **Monitore a comunicação**: O Inspector mostra as mensagens JSON-RPC sendo trocadas entre cliente e servidor.

### O que você deve ver

Quando seu servidor for iniciado corretamente, você deverá ver:
- Capacidades do servidor listadas no Inspector.
- Ferramentas disponíveis para teste.
- Trocas de mensagens JSON-RPC bem-sucedidas.
- Respostas das ferramentas exibidas na interface.

### Problemas comuns e soluções

**Servidor não inicia:**
- Verifique se todas as dependências estão instaladas: `pip install mcp`.
- Confirme a sintaxe e a indentação do Python.
- Procure mensagens de erro no console.

**Ferramentas não aparecem:**
- Certifique-se de que os decoradores `@server.tool()` estão presentes.
- Verifique se as funções das ferramentas estão definidas antes do `main()`.
- Confirme se o servidor está configurado corretamente.

**Problemas de conexão:**
- Certifique-se de que o servidor está usando o transporte stdio corretamente.
- Verifique se nenhum outro processo está interferindo.
- Confirme a sintaxe do comando do Inspector.

## Tarefa

Tente expandir seu servidor com mais capacidades. Veja [esta página](https://api.chucknorris.io/) para, por exemplo, adicionar uma ferramenta que chama uma API. Você decide como o servidor deve ser. Divirta-se :)

## Solução

[Solution](./solution/README.md) Aqui está uma solução possível com código funcional.

## Principais Conclusões

Os principais aprendizados deste capítulo são os seguintes:

- O transporte stdio é o mecanismo recomendado para servidores MCP locais.
- O transporte stdio permite comunicação perfeita entre servidores MCP e clientes usando fluxos de entrada e saída padrão.
- Você pode usar tanto o Inspector quanto o Visual Studio Code para consumir servidores stdio diretamente, tornando a depuração e a integração simples.

## Exemplos 

- [Calculadora em Java](../samples/java/calculator/README.md)
- [Calculadora em .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora em JavaScript](../samples/javascript/README.md)
- [Calculadora em TypeScript](../samples/typescript/README.md)
- [Calculadora em Python](../../../../03-GettingStarted/samples/python) 

## Recursos Adicionais

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## O Que Vem a Seguir

## Próximos Passos

Agora que você aprendeu a construir servidores MCP com o transporte stdio, pode explorar tópicos mais avançados:

- **Próximo**: [HTTP Streaming com MCP (HTTP Streamable)](../06-http-streaming/README.md) - Aprenda sobre o outro mecanismo de transporte suportado para servidores remotos.
- **Avançado**: [Melhores Práticas de Segurança do MCP](../../02-Security/README.md) - Implemente segurança em seus servidores MCP.
- **Produção**: [Estratégias de Implantação](../09-deployment/README.md) - Implante seus servidores para uso em produção.

## Recursos Adicionais

- [Especificação MCP 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Especificação oficial.
- [Documentação do SDK MCP](https://github.com/modelcontextprotocol/sdk) - Referências do SDK para todas as linguagens.
- [Exemplos da Comunidade](../../06-CommunityContributions/README.md) - Mais exemplos de servidores da comunidade.

---

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automatizadas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.