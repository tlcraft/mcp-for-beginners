<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:01:14+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "br"
}
-->
# HTTPS Streaming com Model Context Protocol (MCP)

Este capítulo oferece um guia completo para implementar streaming seguro, escalável e em tempo real com o Model Context Protocol (MCP) usando HTTPS. Ele aborda a motivação para streaming, os mecanismos de transporte disponíveis, como implementar HTTP streaming no MCP, melhores práticas de segurança, migração do SSE e orientações práticas para construir suas próprias aplicações MCP com streaming.

## Mecanismos de Transporte e Streaming no MCP

Esta seção explora os diferentes mecanismos de transporte disponíveis no MCP e seu papel em habilitar capacidades de streaming para comunicação em tempo real entre clientes e servidores.

### O que é um Mecanismo de Transporte?

Um mecanismo de transporte define como os dados são trocados entre o cliente e o servidor. O MCP suporta múltiplos tipos de transporte para se adequar a diferentes ambientes e necessidades:

- **stdio**: Entrada/saída padrão, adequado para ferramentas locais e baseadas em CLI. Simples, mas não adequado para web ou nuvem.
- **SSE (Server-Sent Events)**: Permite que servidores enviem atualizações em tempo real para clientes via HTTP. Bom para interfaces web, mas limitado em escalabilidade e flexibilidade.
- **Streamable HTTP**: Transporte moderno baseado em HTTP para streaming, suportando notificações e melhor escalabilidade. Recomendado para a maioria dos cenários de produção e nuvem.

### Tabela de Comparação

Confira a tabela abaixo para entender as diferenças entre esses mecanismos de transporte:

| Transporte        | Atualizações em Tempo Real | Streaming | Escalabilidade | Caso de Uso              |
|-------------------|----------------------------|-----------|----------------|-------------------------|
| stdio             | Não                        | Não       | Baixa          | Ferramentas CLI locais   |
| SSE               | Sim                        | Sim       | Média          | Web, atualizações em tempo real |
| Streamable HTTP   | Sim                        | Sim       | Alta           | Nuvem, múltiplos clientes |

> **Dica:** A escolha do transporte correto impacta o desempenho, escalabilidade e experiência do usuário. **Streamable HTTP** é recomendado para aplicações modernas, escaláveis e prontas para nuvem.

Observe os transportes stdio e SSE apresentados nos capítulos anteriores e como o streamable HTTP é o transporte abordado neste capítulo.

## Streaming: Conceitos e Motivação

Compreender os conceitos fundamentais e a motivação por trás do streaming é essencial para implementar sistemas eficazes de comunicação em tempo real.

**Streaming** é uma técnica em programação de redes que permite enviar e receber dados em pequenos pedaços gerenciáveis ou como uma sequência de eventos, ao invés de esperar que uma resposta inteira esteja pronta. Isso é especialmente útil para:

- Arquivos ou conjuntos de dados grandes.
- Atualizações em tempo real (ex.: chat, barras de progresso).
- Cálculos de longa duração onde se deseja manter o usuário informado.

Aqui está o que você precisa saber sobre streaming em alto nível:

- Os dados são entregues progressivamente, não de uma vez só.
- O cliente pode processar os dados conforme eles chegam.
- Reduz a latência percebida e melhora a experiência do usuário.

### Por que usar streaming?

As razões para usar streaming são as seguintes:

- Os usuários recebem feedback imediatamente, não apenas no final.
- Permite aplicações em tempo real e interfaces responsivas.
- Uso mais eficiente dos recursos de rede e computação.

### Exemplo Simples: Servidor e Cliente HTTP Streaming

Aqui está um exemplo simples de como o streaming pode ser implementado:

<details>
<summary>Python</summary>

**Servidor (Python, usando FastAPI e StreamingResponse):**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**Cliente (Python, usando requests):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

Este exemplo demonstra um servidor enviando uma série de mensagens para o cliente conforme elas ficam disponíveis, ao invés de esperar todas estarem prontas.

**Como funciona:**
- O servidor envia cada mensagem assim que ela está pronta.
- O cliente recebe e imprime cada pedaço conforme chega.

**Requisitos:**
- O servidor deve usar uma resposta de streaming (ex.: `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Servidor (Java, usando Spring Boot e Server-Sent Events):**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**Cliente (Java, usando Spring WebFlux WebClient):**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**Notas sobre Implementação Java:**
- Utiliza a stack reativa do Spring Boot com `Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) em vez de escolher streaming via MCP.

- **Para necessidades simples de streaming:** O streaming HTTP clássico é mais fácil de implementar e suficiente para necessidades básicas.

- **Para aplicações complexas e interativas:** O streaming MCP oferece uma abordagem mais estruturada com metadados ricos e separação entre notificações e resultados finais.

- **Para aplicações de IA:** O sistema de notificações do MCP é especialmente útil para tarefas de IA de longa duração onde se deseja manter o usuário informado sobre o progresso.

## Streaming no MCP

Ok, você já viu algumas recomendações e comparações até aqui sobre a diferença entre streaming clássico e streaming no MCP. Vamos detalhar exatamente como você pode aproveitar o streaming no MCP.

Entender como o streaming funciona dentro do framework MCP é essencial para construir aplicações responsivas que fornecem feedback em tempo real aos usuários durante operações longas.

No MCP, streaming não significa enviar a resposta principal em pedaços, mas sim enviar **notificações** ao cliente enquanto uma ferramenta processa uma requisição. Essas notificações podem incluir atualizações de progresso, logs ou outros eventos.

### Como funciona

O resultado principal ainda é enviado como uma única resposta. Porém, notificações podem ser enviadas como mensagens separadas durante o processamento, atualizando o cliente em tempo real. O cliente deve ser capaz de lidar e exibir essas notificações.

## O que é uma Notificação?

Falamos em "Notificação", o que isso significa no contexto do MCP?

Uma notificação é uma mensagem enviada do servidor para o cliente para informar sobre progresso, status ou outros eventos durante uma operação de longa duração. As notificações melhoram a transparência e a experiência do usuário.

Por exemplo, espera-se que o cliente envie uma notificação assim que o handshake inicial com o servidor for feito.

Uma notificação tem o seguinte formato em JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notificações pertencem a um tópico no MCP chamado ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Para fazer o logging funcionar, o servidor precisa habilitar essa funcionalidade como um recurso/capacidade, assim:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Dependendo do SDK utilizado, o logging pode estar habilitado por padrão, ou pode ser necessário ativá-lo explicitamente na configuração do servidor.

Existem diferentes tipos de notificações:

| Nível      | Descrição                      | Exemplo de Uso               |
|------------|--------------------------------|-----------------------------|
| debug      | Informações detalhadas de depuração | Pontos de entrada/saída de funções |
| info       | Mensagens informativas gerais   | Atualizações de progresso    |
| notice     | Eventos normais mas significativos | Alterações de configuração  |
| warning    | Condições de aviso              | Uso de recurso depreciado    |
| error      | Condições de erro               | Falhas na operação           |
| critical   | Condições críticas              | Falhas em componentes do sistema |
| alert      | Ação deve ser tomada imediatamente | Detecção de corrupção de dados |
| emergency  | Sistema inutilizável            | Falha completa do sistema    |

## Implementando Notificações no MCP

Para implementar notificações no MCP, você precisa configurar tanto o servidor quanto o cliente para lidar com atualizações em tempo real. Isso permite que sua aplicação forneça feedback imediato aos usuários durante operações longas.

### Lado do Servidor: Enviando Notificações

Vamos começar pelo lado do servidor. No MCP, você define ferramentas que podem enviar notificações enquanto processam requisições. O servidor usa o objeto de contexto (geralmente `ctx`) para enviar mensagens ao cliente.

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

No exemplo acima, o transporte `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

Neste exemplo .NET, o método `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` é usado para enviar mensagens informativas.

Para habilitar notificações no seu servidor MCP .NET, certifique-se de usar um transporte de streaming:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Lado do Cliente: Recebendo Notificações

O cliente deve implementar um manipulador de mensagens para processar e exibir notificações conforme elas chegam.

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

No código acima, o `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` lida com as notificações recebidas.

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

Neste exemplo .NET, o `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) e seu cliente implementa um manipulador de mensagens para processar notificações.

## Notificações de Progresso & Cenários

Esta seção explica o conceito de notificações de progresso no MCP, por que são importantes e como implementá-las usando Streamable HTTP. Também há um exercício prático para reforçar seu aprendizado.

Notificações de progresso são mensagens em tempo real enviadas do servidor para o cliente durante operações longas. Ao invés de esperar todo o processo terminar, o servidor mantém o cliente atualizado sobre o status atual. Isso melhora a transparência, a experiência do usuário e facilita a depuração.

**Exemplo:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Por que Usar Notificações de Progresso?

Notificações de progresso são essenciais por vários motivos:

- **Melhor experiência do usuário:** Usuários veem atualizações conforme o trabalho avança, não apenas no final.
- **Feedback em tempo real:** Clientes podem exibir barras de progresso ou logs, tornando o app mais responsivo.
- **Depuração e monitoramento facilitados:** Desenvolvedores e usuários podem identificar onde um processo está lento ou travado.

### Como Implementar Notificações de Progresso

Veja como implementar notificações de progresso no MCP:

- **No servidor:** Use `ctx.info()` or `ctx.log()` para enviar notificações à medida que cada item é processado. Isso envia uma mensagem ao cliente antes do resultado principal estar pronto.
- **No cliente:** Implemente um manipulador de mensagens que escute e exiba notificações conforme chegam. Esse manipulador distingue entre notificações e o resultado final.

**Exemplo no Servidor:**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**Exemplo no Cliente:**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## Considerações de Segurança

Ao implementar servidores MCP com transportes baseados em HTTP, a segurança se torna uma preocupação fundamental que exige atenção cuidadosa a múltiplos vetores de ataque e mecanismos de proteção.

### Visão Geral

Segurança é crítica ao expor servidores MCP via HTTP. O Streamable HTTP introduz novas superfícies de ataque e requer configuração cuidadosa.

### Pontos-chave
- **Validação do cabeçalho Origin**: Sempre valide o `Origin` para garantir que apenas origens confiáveis possam acessar o serviço.
- **Uso de HTTPS obrigatório**: Para proteger os dados em trânsito e evitar ataques man-in-the-middle.
- **Autenticação e autorização**: Implemente controles para garantir que apenas usuários autorizados acessem as funcionalidades.
- **Limitação de taxa e proteção contra DoS**: Para evitar abusos e ataques de negação de serviço.
- **Validação de payload**: Para evitar injeção de código e outros ataques baseados em dados maliciosos.
- **Monitoramento e logging**: Para detectar e responder rapidamente a atividades suspeitas.

### Manutenção da Compatibilidade

Recomenda-se manter compatibilidade com clientes SSE existentes durante o processo de migração. Algumas estratégias:

- Suportar ambos SSE e Streamable HTTP executando os dois transportes em endpoints diferentes.
- Migrar clientes gradualmente para o novo transporte.

### Desafios

Garanta que você lide com os seguintes desafios durante a migração:

- Garantir que todos os clientes sejam atualizados.
- Lidar com diferenças na entrega das notificações.

### Exercício: Crie sua Própria Aplicação MCP com Streaming

**Cenário:**
Construa um servidor e cliente MCP onde o servidor processa uma lista de itens (ex.: arquivos ou documentos) e envia uma notificação para cada item processado. O cliente deve exibir cada notificação conforme ela chega.

**Passos:**

1. Implemente uma ferramenta no servidor que processe uma lista e envie notificações para cada item.
2. Implemente um cliente com um manipulador de mensagens para exibir notificações em tempo real.
3. Teste sua implementação executando servidor e cliente, e observe as notificações.

[Solução](./solution/README.md)

## Leituras Complementares & Próximos Passos

Para continuar sua jornada com streaming MCP e expandir seu conhecimento, esta seção fornece recursos adicionais e sugestões de próximos passos para construir aplicações mais avançadas.

### Leituras Complementares

- [Microsoft: Introdução ao HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS no ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Próximos Passos

- Experimente construir ferramentas MCP mais avançadas que usem streaming para análises em tempo real, chat ou edição colaborativa.
- Explore integrar o streaming MCP com frameworks frontend (React, Vue, etc.) para atualizações ao vivo na interface.
- Próximo: [Utilizando AI Toolkit para VSCode](../07-aitk/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.