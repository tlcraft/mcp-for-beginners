<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-10T16:07:22+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "pt"
}
-->
# Streaming HTTPS com Model Context Protocol (MCP)

Este capítulo oferece um guia completo para implementar streaming seguro, escalável e em tempo real com o Model Context Protocol (MCP) usando HTTPS. Abrange a motivação para streaming, os mecanismos de transporte disponíveis, como implementar HTTP streamable no MCP, melhores práticas de segurança, migração a partir de SSE e orientações práticas para construir as suas próprias aplicações MCP com streaming.

## Mecanismos de Transporte e Streaming no MCP

Esta secção explora os diferentes mecanismos de transporte disponíveis no MCP e o seu papel na habilitação de capacidades de streaming para comunicação em tempo real entre clientes e servidores.

### O que é um Mecanismo de Transporte?

Um mecanismo de transporte define como os dados são trocados entre o cliente e o servidor. O MCP suporta múltiplos tipos de transporte para se adequar a diferentes ambientes e requisitos:

- **stdio**: Entrada/saída padrão, adequado para ferramentas locais e baseadas em CLI. Simples, mas não adequado para web ou cloud.
- **SSE (Server-Sent Events)**: Permite que os servidores enviem atualizações em tempo real para os clientes via HTTP. Bom para interfaces web, mas limitado em escalabilidade e flexibilidade.
- **Streamable HTTP**: Transporte de streaming moderno baseado em HTTP, suportando notificações e melhor escalabilidade. Recomendado para a maioria dos cenários de produção e cloud.

### Tabela Comparativa

Veja a tabela comparativa abaixo para entender as diferenças entre estes mecanismos de transporte:

| Transporte        | Atualizações em Tempo Real | Streaming | Escalabilidade | Caso de Uso               |
|-------------------|----------------------------|-----------|----------------|--------------------------|
| stdio             | Não                        | Não       | Baixa          | Ferramentas CLI locais    |
| SSE               | Sim                        | Sim       | Média          | Web, atualizações em tempo real |
| Streamable HTTP   | Sim                        | Sim       | Alta           | Cloud, multi-cliente      |

> **Tip:** A escolha do transporte certo impacta o desempenho, escalabilidade e experiência do utilizador. **Streamable HTTP** é recomendado para aplicações modernas, escaláveis e preparadas para cloud.

Note os transportes stdio e SSE que foram apresentados nos capítulos anteriores e como o streamable HTTP é o transporte abordado neste capítulo.

## Streaming: Conceitos e Motivação

Compreender os conceitos fundamentais e as motivações por trás do streaming é essencial para implementar sistemas eficazes de comunicação em tempo real.

**Streaming** é uma técnica em programação de redes que permite enviar e receber dados em pequenos pedaços geríveis ou como uma sequência de eventos, em vez de esperar que toda a resposta esteja pronta. Isto é especialmente útil para:

- Ficheiros ou conjuntos de dados grandes.
- Atualizações em tempo real (ex.: chat, barras de progresso).
- Cálculos de longa duração onde se quer manter o utilizador informado.

Aqui está o que precisa de saber sobre streaming a um nível elevado:

- Os dados são entregues progressivamente, não todos de uma vez.
- O cliente pode processar os dados à medida que chegam.
- Reduz a latência percebida e melhora a experiência do utilizador.

### Porque usar streaming?

As razões para usar streaming são as seguintes:

- Os utilizadores recebem feedback imediato, não apenas no final
- Permite aplicações em tempo real e interfaces responsivas
- Uso mais eficiente dos recursos de rede e computação

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

Este exemplo demonstra um servidor a enviar uma série de mensagens para o cliente à medida que ficam disponíveis, em vez de esperar que todas as mensagens estejam prontas.

**Como funciona:**
- O servidor envia cada mensagem assim que está pronta.
- O cliente recebe e imprime cada pedaço à medida que chega.

**Requisitos:**
- O servidor deve usar uma resposta de streaming (ex.: `StreamingResponse` no FastAPI).
- O cliente deve processar a resposta como um stream (`stream=True` em requests).
- O Content-Type é geralmente `text/event-stream` ou `application/octet-stream`.

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

**Notas sobre a Implementação em Java:**
- Usa a stack reativa do Spring Boot com `Flux` para streaming
- `ServerSentEvent` fornece streaming estruturado de eventos com tipos de evento
- `WebClient` com `bodyToFlux()` permite consumo reativo de streaming
- `delayElements()` simula tempo de processamento entre eventos
- Eventos podem ter tipos (`info`, `result`) para melhor tratamento no cliente

</details>

### Comparação: Streaming Clássico vs Streaming MCP

As diferenças entre como o streaming funciona de forma "clássica" versus como funciona no MCP podem ser representadas assim:

| Característica         | Streaming HTTP Clássico       | Streaming MCP (Notificações)       |
|-----------------------|-------------------------------|-----------------------------------|
| Resposta principal    | Em pedaços (chunked)           | Única, no final                   |
| Atualizações de progresso | Enviadas como pedaços de dados | Enviadas como notificações        |
| Requisitos do cliente | Deve processar o stream         | Deve implementar um handler de mensagens |
| Caso de uso           | Ficheiros grandes, streams de tokens AI | Progresso, logs, feedback em tempo real |

### Diferenças Principais Observadas

Além disso, aqui estão algumas diferenças chave:

- **Padrão de Comunicação:**
   - Streaming HTTP clássico: Usa codificação chunked simples para enviar dados em pedaços
   - Streaming MCP: Usa um sistema estruturado de notificações com protocolo JSON-RPC

- **Formato da Mensagem:**
   - HTTP clássico: Pedaços de texto simples com novas linhas
   - MCP: Objetos estruturados LoggingMessageNotification com metadados

- **Implementação do Cliente:**
   - HTTP clássico: Cliente simples que processa respostas de streaming
   - MCP: Cliente mais sofisticado com um handler de mensagens para processar diferentes tipos de mensagens

- **Atualizações de Progresso:**
   - HTTP clássico: O progresso faz parte do stream principal da resposta
   - MCP: O progresso é enviado via mensagens de notificação separadas enquanto a resposta principal chega no final

### Recomendações

Há algumas recomendações quando se trata de escolher entre implementar streaming clássico (como o endpoint que mostramos acima usando `/stream`) versus streaming via MCP.

- **Para necessidades simples de streaming:** O streaming HTTP clássico é mais simples de implementar e suficiente para necessidades básicas.

- **Para aplicações complexas e interativas:** O streaming MCP oferece uma abordagem mais estruturada com metadados ricos e separação entre notificações e resultados finais.

- **Para aplicações de IA:** O sistema de notificações do MCP é particularmente útil para tarefas de IA de longa duração onde se quer manter os utilizadores informados do progresso.

## Streaming no MCP

Ok, já viu algumas recomendações e comparações até agora sobre a diferença entre streaming clássico e streaming no MCP. Vamos entrar em detalhe exatamente como pode tirar partido do streaming no MCP.

Compreender como o streaming funciona dentro do framework MCP é essencial para construir aplicações responsivas que fornecem feedback em tempo real aos utilizadores durante operações de longa duração.

No MCP, streaming não é sobre enviar a resposta principal em pedaços, mas sim sobre enviar **notificações** para o cliente enquanto uma ferramenta está a processar um pedido. Estas notificações podem incluir atualizações de progresso, logs ou outros eventos.

### Como funciona

O resultado principal é ainda enviado como uma única resposta. No entanto, notificações podem ser enviadas como mensagens separadas durante o processamento e assim atualizar o cliente em tempo real. O cliente deve ser capaz de tratar e mostrar estas notificações.

## O que é uma Notificação?

Dissemos "Notificação", o que significa isso no contexto do MCP?

Uma notificação é uma mensagem enviada do servidor para o cliente para informar sobre progresso, estado ou outros eventos durante uma operação de longa duração. As notificações melhoram a transparência e a experiência do utilizador.

Por exemplo, um cliente deve enviar uma notificação assim que o handshake inicial com o servidor for feito.

Uma notificação tem este aspeto como mensagem JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

As notificações pertencem a um tópico no MCP referido como ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Para que o logging funcione, o servidor precisa de o ativar como funcionalidade/capacidade assim:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Dependendo do SDK usado, o logging pode estar ativado por defeito, ou pode ser necessário ativá-lo explicitamente na configuração do servidor.

Existem diferentes tipos de notificações:

| Nível      | Descrição                     | Exemplo de Uso                |
|------------|-------------------------------|------------------------------|
| debug      | Informação detalhada para debugging | Pontos de entrada/saída de funções |
| info       | Mensagens informativas gerais | Atualizações de progresso da operação |
| notice     | Eventos normais mas significativos | Alterações de configuração    |
| warning    | Condições de aviso             | Uso de funcionalidades obsoletas |
| error      | Condições de erro             | Falhas na operação            |
| critical   | Condições críticas            | Falhas em componentes do sistema |
| alert      | Ação deve ser tomada imediatamente | Detecção de corrupção de dados |
| emergency  | Sistema inutilizável          | Falha completa do sistema     |

## Implementação de Notificações no MCP

Para implementar notificações no MCP, precisa configurar tanto o lado do servidor como do cliente para tratar atualizações em tempo real. Isto permite que a sua aplicação forneça feedback imediato aos utilizadores durante operações de longa duração.

### Lado do Servidor: Envio de Notificações

Comecemos pelo lado do servidor. No MCP, define ferramentas que podem enviar notificações enquanto processam pedidos. O servidor usa o objeto de contexto (normalmente `ctx`) para enviar mensagens ao cliente.

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

No exemplo anterior, a ferramenta `process_files` envia três notificações ao cliente enquanto processa cada ficheiro. O método `ctx.info()` é usado para enviar mensagens informativas.

</details>

Além disso, para ativar notificações, assegure que o seu servidor usa um transporte de streaming (como `streamable-http`) e que o cliente implementa um handler de mensagens para processar notificações. Aqui está como pode configurar o servidor para usar o transporte `streamable-http`:

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

Neste exemplo .NET, a ferramenta `ProcessFiles` está decorada com o atributo `Tool` e envia três notificações ao cliente enquanto processa cada ficheiro. O método `ctx.Info()` é usado para enviar mensagens informativas.

Para ativar notificações no seu servidor MCP .NET, assegure que está a usar um transporte de streaming:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Lado do Cliente: Receção de Notificações

O cliente deve implementar um handler de mensagens para processar e mostrar notificações à medida que chegam.

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

No código anterior, a função `message_handler` verifica se a mensagem recebida é uma notificação. Se for, imprime a notificação; caso contrário, processa-a como uma mensagem normal do servidor. Note também como a `ClientSession` é inicializada com o `message_handler` para tratar notificações recebidas.

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

Neste exemplo .NET, a função `MessageHandler` verifica se a mensagem recebida é uma notificação. Se for, imprime a notificação; caso contrário, processa-a como uma mensagem normal do servidor. A `ClientSession` é inicializada com o handler de mensagens via `ClientSessionOptions`.

</details>

Para ativar notificações, assegure que o seu servidor usa um transporte de streaming (como `streamable-http`) e que o cliente implementa um handler de mensagens para processar notificações.

## Notificações de Progresso & Cenários

Esta secção explica o conceito de notificações de progresso no MCP, porque são importantes e como implementá-las usando Streamable HTTP. Também encontrará um exercício prático para reforçar a sua compreensão.

Notificações de progresso são mensagens em tempo real enviadas do servidor para o cliente durante operações de longa duração. Em vez de esperar que todo o processo termine, o servidor mantém o cliente atualizado sobre o estado atual. Isto melhora a transparência, a experiência do utilizador e facilita a depuração.

**Exemplo:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Porque Usar Notificações de Progresso?

As notificações de progresso são essenciais por várias razões:

- **Melhor experiência do utilizador:** Os utilizadores veem atualizações à medida que o trabalho avança, não apenas no final.
- **Feedback em tempo real:** Os clientes podem mostrar barras de progresso ou logs, tornando a aplicação mais responsiva.
- **Depuração e monitorização facilitadas:** Desenvolvedores e utilizadores podem ver onde um processo pode estar lento ou bloqueado.

### Como Implementar Notificações de Progresso

Aqui está como pode implementar notificações de progresso no MCP:

- **No servidor:** Use `ctx.info()` ou `ctx.log()` para enviar notificações à medida que cada item é processado. Isto envia uma mensagem ao cliente antes do resultado principal estar pronto.
- **No cliente:** Implemente um handler de mensagens que escute e mostre notificações à medida que chegam. Este handler distingue entre notificações e o resultado final.

**Exemplo de Servidor:**

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

**Exemplo de Cliente:**

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

Ao implementar servidores MCP com transportes baseados em HTTP, a segurança torna-se uma preocupação fundamental que exige atenção cuidadosa a múltiplos vetores de ataque e mecanismos de proteção.

### Visão Geral

A segurança é crucial ao expor servidores MCP via HTTP. O Streamable HTTP introduz novas superfícies de ataque e requer uma configuração cuidadosa.

### Pontos-Chave
- **Validação do Header Origin**: Valide sempre o header `Origin` para evitar ataques de DNS rebinding.
- **Ligação ao Localhost**: Para desenvolvimento local, ligue os servidores ao `localhost` para evitar exposição à internet pública.
- **Autenticação**: Implemente autenticação (ex.: chaves API, OAuth) para ambientes de produção.
- **CORS**: Configure políticas de Cross-Origin Resource Sharing (CORS) para restringir o acesso.
- **HTTPS**: Utilize HTTPS em produção para encriptar o tráfego.

### Boas Práticas
- Nunca confie em pedidos recebidos sem validação.
- Registe e monitorize todos os acessos e erros.
- Atualize regularmente as dependências para corrigir vulnerabilidades de segurança.

### Desafios
- Equilibrar segurança com facilidade de desenvolvimento
- Garantir compatibilidade com vários ambientes de cliente


## Atualização de SSE para Streamable HTTP

Para aplicações que atualmente usam Server-Sent Events (SSE), migrar para Streamable HTTP oferece capacidades melhoradas e maior sustentabilidade a longo prazo para as suas implementações MCP.

### Porquê Atualizar?

Existem duas razões principais para atualizar de SSE para Streamable HTTP:

- O Streamable HTTP oferece melhor escalabilidade, compatibilidade e suporte a notificações mais ricas do que o SSE.
- É o transporte recomendado para novas aplicações MCP.

### Passos para a Migração

Aqui está como pode migrar de SSE para Streamable HTTP nas suas aplicações MCP:

- **Atualize o código do servidor** para usar `transport="streamable-http"` em `mcp.run()`.
- **Atualize o código do cliente** para usar `streamablehttp_client` em vez do cliente SSE.
- **Implemente um handler de mensagens** no cliente para processar notificações.
- **Teste a compatibilidade** com as ferramentas e fluxos de trabalho existentes.

### Manutenção da Compatibilidade

Recomenda-se manter a compatibilidade com clientes SSE existentes durante o processo de migração. Aqui ficam algumas estratégias:

- Pode suportar ambos, SSE e Streamable HTTP, executando os dois transportes em endpoints diferentes.
- Migre os clientes gradualmente para o novo transporte.

### Desafios

Certifique-se de abordar os seguintes desafios durante a migração:

- Garantir que todos os clientes são atualizados
- Lidar com diferenças na entrega das notificações

## Considerações de Segurança

A segurança deve ser uma prioridade máxima ao implementar qualquer servidor, especialmente quando se utilizam transportes baseados em HTTP como o Streamable HTTP no MCP.

Ao implementar servidores MCP com transportes baseados em HTTP, a segurança torna-se uma preocupação fundamental que exige atenção cuidadosa a múltiplos vetores de ataque e mecanismos de proteção.

### Visão Geral

A segurança é crucial ao expor servidores MCP via HTTP. O Streamable HTTP introduz novas superfícies de ataque e requer uma configuração cuidadosa.

Aqui ficam algumas considerações chave de segurança:

- **Validação do Header Origin**: Valide sempre o header `Origin` para evitar ataques de DNS rebinding.
- **Ligação ao Localhost**: Para desenvolvimento local, ligue os servidores ao `localhost` para evitar exposição à internet pública.
- **Autenticação**: Implemente autenticação (ex.: chaves API, OAuth) para ambientes de produção.
- **CORS**: Configure políticas de Cross-Origin Resource Sharing (CORS) para restringir o acesso.
- **HTTPS**: Utilize HTTPS em produção para encriptar o tráfego.

### Boas Práticas

Além disso, aqui ficam algumas boas práticas a seguir ao implementar segurança no seu servidor de streaming MCP:

- Nunca confie em pedidos recebidos sem validação.
- Registe e monitorize todos os acessos e erros.
- Atualize regularmente as dependências para corrigir vulnerabilidades de segurança.

### Desafios

Vai enfrentar alguns desafios ao implementar segurança em servidores de streaming MCP:

- Equilibrar segurança com facilidade de desenvolvimento
- Garantir compatibilidade com vários ambientes de cliente

### Exercício: Construa a Sua Própria App MCP de Streaming

**Cenário:**
Construa um servidor e cliente MCP onde o servidor processa uma lista de itens (ex.: ficheiros ou documentos) e envia uma notificação para cada item processado. O cliente deve mostrar cada notificação assim que esta chegar.

**Passos:**

1. Implemente uma ferramenta servidor que processe uma lista e envie notificações para cada item.
2. Implemente um cliente com um handler de mensagens para mostrar notificações em tempo real.
3. Teste a sua implementação executando servidor e cliente, e observe as notificações.

[Solution](./solution/README.md)

## Leitura Adicional & Próximos Passos

Para continuar a sua jornada com streaming MCP e expandir o seu conhecimento, esta secção fornece recursos adicionais e sugestões para construir aplicações mais avançadas.

### Leitura Adicional

- [Microsoft: Introdução ao HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS em ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Próximos Passos

- Experimente construir ferramentas MCP mais avançadas que usem streaming para análises em tempo real, chat ou edição colaborativa.
- Explore a integração do streaming MCP com frameworks frontend (React, Vue, etc.) para atualizações de UI em direto.
- A seguir: [Utilização do AI Toolkit para VSCode](../07-aitk/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em atenção que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações erradas decorrentes da utilização desta tradução.