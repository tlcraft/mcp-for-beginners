<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-10T16:08:00+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "br"
}
-->
# Streaming HTTPS com Model Context Protocol (MCP)

Este capítulo oferece um guia completo para implementar streaming seguro, escalável e em tempo real com o Model Context Protocol (MCP) usando HTTPS. Ele aborda a motivação para streaming, os mecanismos de transporte disponíveis, como implementar HTTP streamable no MCP, melhores práticas de segurança, migração do SSE e orientações práticas para construir suas próprias aplicações MCP com streaming.

## Mecanismos de Transporte e Streaming no MCP

Esta seção explora os diferentes mecanismos de transporte disponíveis no MCP e seu papel em viabilizar capacidades de streaming para comunicação em tempo real entre clientes e servidores.

### O que é um Mecanismo de Transporte?

Um mecanismo de transporte define como os dados são trocados entre cliente e servidor. O MCP suporta múltiplos tipos de transporte para atender a diferentes ambientes e necessidades:

- **stdio**: Entrada/saída padrão, adequado para ferramentas locais e baseadas em CLI. Simples, mas não indicado para web ou nuvem.
- **SSE (Server-Sent Events)**: Permite que servidores enviem atualizações em tempo real para clientes via HTTP. Bom para interfaces web, mas limitado em escalabilidade e flexibilidade.
- **Streamable HTTP**: Transporte moderno baseado em HTTP para streaming, suportando notificações e melhor escalabilidade. Recomendado para a maioria dos cenários de produção e nuvem.

### Tabela de Comparação

Confira a tabela abaixo para entender as diferenças entre esses mecanismos de transporte:

| Transporte        | Atualizações em Tempo Real | Streaming | Escalabilidade | Caso de Uso               |
|-------------------|----------------------------|-----------|----------------|--------------------------|
| stdio             | Não                        | Não       | Baixa          | Ferramentas CLI locais    |
| SSE               | Sim                        | Sim       | Média          | Web, atualizações em tempo real |
| Streamable HTTP   | Sim                        | Sim       | Alta           | Nuvem, múltiplos clientes |

> **Dica:** Escolher o transporte correto impacta desempenho, escalabilidade e experiência do usuário. **Streamable HTTP** é recomendado para aplicações modernas, escaláveis e preparadas para nuvem.

Note os transportes stdio e SSE que foram apresentados nos capítulos anteriores e como o streamable HTTP é o transporte abordado neste capítulo.

## Streaming: Conceitos e Motivação

Compreender os conceitos fundamentais e as motivações por trás do streaming é essencial para implementar sistemas eficazes de comunicação em tempo real.

**Streaming** é uma técnica em programação de redes que permite enviar e receber dados em pequenos pedaços gerenciáveis ou como uma sequência de eventos, em vez de esperar que toda a resposta esteja pronta. Isso é especialmente útil para:

- Arquivos ou conjuntos de dados grandes.
- Atualizações em tempo real (ex: chat, barras de progresso).
- Cálculos longos onde se deseja manter o usuário informado.

Aqui está o que você precisa saber sobre streaming em alto nível:

- Os dados são entregues progressivamente, não todos de uma vez.
- O cliente pode processar os dados conforme eles chegam.
- Reduz a latência percebida e melhora a experiência do usuário.

### Por que usar streaming?

As razões para usar streaming são as seguintes:

- Os usuários recebem feedback imediatamente, não apenas no final.
- Permite aplicações em tempo real e interfaces responsivas.
- Uso mais eficiente dos recursos de rede e computação.

### Exemplo Simples: Servidor e Cliente HTTP com Streaming

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

Este exemplo demonstra um servidor enviando uma série de mensagens para o cliente conforme elas ficam disponíveis, em vez de esperar que todas as mensagens estejam prontas.

**Como funciona:**
- O servidor envia cada mensagem assim que está pronta.
- O cliente recebe e imprime cada pedaço conforme chega.

**Requisitos:**
- O servidor deve usar uma resposta de streaming (ex: `StreamingResponse` no FastAPI).
- O cliente deve processar a resposta como um stream (`stream=True` no requests).
- O Content-Type geralmente é `text/event-stream` ou `application/octet-stream`.

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

**Notas sobre a implementação em Java:**
- Usa a stack reativa do Spring Boot com `Flux` para streaming
- `ServerSentEvent` fornece streaming estruturado com tipos de eventos
- `WebClient` com `bodyToFlux()` permite consumo reativo do streaming
- `delayElements()` simula tempo de processamento entre eventos
- Eventos podem ter tipos (`info`, `result`) para melhor tratamento no cliente

</details>

### Comparação: Streaming Clássico vs Streaming MCP

As diferenças entre como o streaming funciona de forma "clássica" versus como funciona no MCP podem ser representadas assim:

| Recurso               | Streaming HTTP Clássico       | Streaming MCP (Notificações)       |
|-----------------------|------------------------------|-----------------------------------|
| Resposta principal    | Em pedaços (chunked)          | Única, no final                   |
| Atualizações de progresso | Enviadas como pedaços de dados | Enviadas como notificações        |
| Requisitos do cliente | Deve processar o stream       | Deve implementar um handler de mensagens |
| Caso de uso           | Arquivos grandes, streams de tokens AI | Progresso, logs, feedback em tempo real |

### Diferenças Principais Observadas

Além disso, aqui estão algumas diferenças chave:

- **Padrão de Comunicação:**
   - Streaming HTTP clássico: Usa codificação chunked simples para enviar dados em pedaços
   - Streaming MCP: Usa sistema estruturado de notificações com protocolo JSON-RPC

- **Formato da Mensagem:**
   - HTTP clássico: Pedaços de texto simples com quebras de linha
   - MCP: Objetos estruturados LoggingMessageNotification com metadados

- **Implementação do Cliente:**
   - HTTP clássico: Cliente simples que processa respostas em streaming
   - MCP: Cliente mais sofisticado com handler de mensagens para processar diferentes tipos de mensagens

- **Atualizações de Progresso:**
   - HTTP clássico: Progresso faz parte do stream principal da resposta
   - MCP: Progresso é enviado via mensagens de notificação separadas enquanto a resposta principal vem no final

### Recomendações

Algumas recomendações para escolher entre implementar streaming clássico (como o endpoint mostrado acima usando `/stream`) versus streaming via MCP:

- **Para necessidades simples de streaming:** Streaming HTTP clássico é mais simples de implementar e suficiente para necessidades básicas.

- **Para aplicações complexas e interativas:** Streaming MCP oferece uma abordagem mais estruturada com metadados ricos e separação entre notificações e resultados finais.

- **Para aplicações de IA:** O sistema de notificações do MCP é especialmente útil para tarefas de IA longas onde se deseja manter os usuários informados sobre o progresso.

## Streaming no MCP

Ok, você já viu algumas recomendações e comparações até aqui sobre a diferença entre streaming clássico e streaming no MCP. Vamos detalhar exatamente como você pode aproveitar o streaming no MCP.

Entender como o streaming funciona dentro do framework MCP é essencial para construir aplicações responsivas que fornecem feedback em tempo real aos usuários durante operações longas.

No MCP, streaming não é sobre enviar a resposta principal em pedaços, mas sim sobre enviar **notificações** para o cliente enquanto uma ferramenta está processando uma requisição. Essas notificações podem incluir atualizações de progresso, logs ou outros eventos.

### Como funciona

O resultado principal ainda é enviado como uma única resposta. No entanto, notificações podem ser enviadas como mensagens separadas durante o processamento, atualizando o cliente em tempo real. O cliente deve ser capaz de lidar e exibir essas notificações.

## O que é uma Notificação?

Dissemos "Notificação", o que isso significa no contexto do MCP?

Uma notificação é uma mensagem enviada do servidor para o cliente para informar sobre progresso, status ou outros eventos durante uma operação longa. Notificações melhoram a transparência e a experiência do usuário.

Por exemplo, um cliente deve enviar uma notificação assim que o handshake inicial com o servidor for realizado.

Uma notificação tem a seguinte aparência como mensagem JSON:

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

Para que o logging funcione, o servidor precisa habilitá-lo como recurso/capacidade assim:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Dependendo do SDK usado, o logging pode estar habilitado por padrão, ou você pode precisar ativá-lo explicitamente na configuração do servidor.

Existem diferentes tipos de notificações:

| Nível     | Descrição                     | Exemplo de Uso                |
|-----------|-------------------------------|------------------------------|
| debug     | Informações detalhadas para depuração | Pontos de entrada/saída de funções |
| info      | Mensagens informativas gerais | Atualizações de progresso da operação |
| notice    | Eventos normais, mas significativos | Alterações de configuração    |
| warning   | Condições de aviso            | Uso de recurso depreciado     |
| error     | Condições de erro             | Falhas na operação            |
| critical  | Condições críticas            | Falhas em componentes do sistema |
| alert     | Ação deve ser tomada imediatamente | Detecção de corrupção de dados |
| emergency | Sistema está inutilizável     | Falha completa do sistema     |

## Implementando Notificações no MCP

Para implementar notificações no MCP, você precisa configurar tanto o lado do servidor quanto o do cliente para lidar com atualizações em tempo real. Isso permite que sua aplicação forneça feedback imediato aos usuários durante operações longas.

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

No exemplo acima, a ferramenta `process_files` envia três notificações para o cliente enquanto processa cada arquivo. O método `ctx.info()` é usado para enviar mensagens informativas.

</details>

Além disso, para habilitar notificações, certifique-se de que seu servidor usa um transporte de streaming (como `streamable-http`) e que seu cliente implemente um handler de mensagens para processar notificações. Veja como configurar o servidor para usar o transporte `streamable-http`:

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

Neste exemplo em .NET, a ferramenta `ProcessFiles` é decorada com o atributo `Tool` e envia três notificações para o cliente enquanto processa cada arquivo. O método `ctx.Info()` é usado para enviar mensagens informativas.

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

O cliente deve implementar um handler de mensagens para processar e exibir notificações conforme elas chegam.

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

No código acima, a função `message_handler` verifica se a mensagem recebida é uma notificação. Se for, imprime a notificação; caso contrário, processa como uma mensagem normal do servidor. Note também como o `ClientSession` é inicializado com o `message_handler` para lidar com notificações recebidas.

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

Neste exemplo em .NET, a função `MessageHandler` verifica se a mensagem recebida é uma notificação. Se for, imprime a notificação; caso contrário, processa como uma mensagem normal do servidor. O `ClientSession` é inicializado com o handler de mensagens via `ClientSessionOptions`.

</details>

Para habilitar notificações, certifique-se de que seu servidor usa um transporte de streaming (como `streamable-http`) e que seu cliente implemente um handler de mensagens para processar notificações.

## Notificações de Progresso & Cenários

Esta seção explica o conceito de notificações de progresso no MCP, por que elas são importantes e como implementá-las usando Streamable HTTP. Você também encontrará um exercício prático para reforçar seu entendimento.

Notificações de progresso são mensagens em tempo real enviadas do servidor para o cliente durante operações longas. Em vez de esperar o processo inteiro terminar, o servidor mantém o cliente atualizado sobre o status atual. Isso melhora a transparência, a experiência do usuário e facilita a depuração.

**Exemplo:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Por que usar notificações de progresso?

Notificações de progresso são essenciais por vários motivos:

- **Melhor experiência do usuário:** Usuários veem atualizações conforme o trabalho avança, não apenas no final.
- **Feedback em tempo real:** Clientes podem exibir barras de progresso ou logs, tornando o app mais responsivo.
- **Depuração e monitoramento facilitados:** Desenvolvedores e usuários podem identificar onde um processo está lento ou travado.

### Como implementar notificações de progresso

Veja como implementar notificações de progresso no MCP:

- **No servidor:** Use `ctx.info()` ou `ctx.log()` para enviar notificações conforme cada item é processado. Isso envia uma mensagem ao cliente antes do resultado principal estar pronto.
- **No cliente:** Implemente um handler de mensagens que escute e exiba notificações conforme elas chegam. Esse handler diferencia notificações do resultado final.

**Exemplo de servidor:**

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

**Exemplo do Cliente:**

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

A segurança é crítica ao expor servidores MCP via HTTP. O Streamable HTTP introduz novas superfícies de ataque e requer configuração cuidadosa.

### Pontos Principais
- **Validação do Header Origin**: Sempre valide o header `Origin` para evitar ataques de DNS rebinding.
- **Vinculação ao Localhost**: Para desenvolvimento local, vincule os servidores ao `localhost` para evitar exposição à internet pública.
- **Autenticação**: Implemente autenticação (ex.: chaves de API, OAuth) para implantações em produção.
- **CORS**: Configure políticas de Cross-Origin Resource Sharing (CORS) para restringir o acesso.
- **HTTPS**: Use HTTPS em produção para criptografar o tráfego.

### Melhores Práticas
- Nunca confie em requisições recebidas sem validação.
- Registre e monitore todos os acessos e erros.
- Atualize regularmente as dependências para corrigir vulnerabilidades de segurança.

### Desafios
- Equilibrar segurança com facilidade de desenvolvimento
- Garantir compatibilidade com diversos ambientes de cliente


## Atualizando de SSE para Streamable HTTP

Para aplicações que atualmente usam Server-Sent Events (SSE), migrar para Streamable HTTP oferece capacidades aprimoradas e melhor sustentabilidade a longo prazo para suas implementações MCP.

### Por que Atualizar?

Existem duas razões importantes para migrar de SSE para Streamable HTTP:

- Streamable HTTP oferece melhor escalabilidade, compatibilidade e suporte a notificações mais completas do que SSE.
- É o transporte recomendado para novas aplicações MCP.

### Passos para Migração

Veja como migrar de SSE para Streamable HTTP em suas aplicações MCP:

- **Atualize o código do servidor** para usar `transport="streamable-http"` em `mcp.run()`.
- **Atualize o código do cliente** para usar `streamablehttp_client` em vez do cliente SSE.
- **Implemente um manipulador de mensagens** no cliente para processar notificações.
- **Teste a compatibilidade** com ferramentas e fluxos de trabalho existentes.

### Mantendo a Compatibilidade

Recomenda-se manter a compatibilidade com clientes SSE existentes durante o processo de migração. Algumas estratégias são:

- Você pode suportar ambos SSE e Streamable HTTP executando os dois transportes em endpoints diferentes.
- Migre os clientes gradualmente para o novo transporte.

### Desafios

Certifique-se de lidar com os seguintes desafios durante a migração:

- Garantir que todos os clientes sejam atualizados
- Lidar com diferenças na entrega das notificações

## Considerações de Segurança

A segurança deve ser prioridade máxima ao implementar qualquer servidor, especialmente ao usar transportes baseados em HTTP como Streamable HTTP no MCP.

Ao implementar servidores MCP com transportes baseados em HTTP, a segurança se torna uma preocupação fundamental que exige atenção cuidadosa a múltiplos vetores de ataque e mecanismos de proteção.

### Visão Geral

A segurança é crítica ao expor servidores MCP via HTTP. O Streamable HTTP introduz novas superfícies de ataque e requer configuração cuidadosa.

Aqui estão algumas considerações importantes de segurança:

- **Validação do Header Origin**: Sempre valide o header `Origin` para evitar ataques de DNS rebinding.
- **Vinculação ao Localhost**: Para desenvolvimento local, vincule os servidores ao `localhost` para evitar exposição à internet pública.
- **Autenticação**: Implemente autenticação (ex.: chaves de API, OAuth) para implantações em produção.
- **CORS**: Configure políticas de Cross-Origin Resource Sharing (CORS) para restringir o acesso.
- **HTTPS**: Use HTTPS em produção para criptografar o tráfego.

### Melhores Práticas

Além disso, aqui estão algumas melhores práticas para seguir ao implementar segurança no seu servidor de streaming MCP:

- Nunca confie em requisições recebidas sem validação.
- Registre e monitore todos os acessos e erros.
- Atualize regularmente as dependências para corrigir vulnerabilidades de segurança.

### Desafios

Você enfrentará alguns desafios ao implementar segurança em servidores de streaming MCP:

- Equilibrar segurança com facilidade de desenvolvimento
- Garantir compatibilidade com diversos ambientes de cliente

### Exercício: Construa Seu Próprio App MCP de Streaming

**Cenário:**  
Construa um servidor e cliente MCP onde o servidor processa uma lista de itens (ex.: arquivos ou documentos) e envia uma notificação para cada item processado. O cliente deve exibir cada notificação assim que ela chegar.

**Passos:**

1. Implemente uma ferramenta servidor que processe uma lista e envie notificações para cada item.
2. Implemente um cliente com um manipulador de mensagens para exibir notificações em tempo real.
3. Teste sua implementação executando servidor e cliente, e observe as notificações.

[Solução](./solution/README.md)

## Leituras Complementares & Próximos Passos

Para continuar sua jornada com streaming MCP e expandir seu conhecimento, esta seção oferece recursos adicionais e sugestões para construir aplicações mais avançadas.

### Leituras Complementares

- [Microsoft: Introdução ao HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS no ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Próximos Passos

- Experimente construir ferramentas MCP mais avançadas que usem streaming para análises em tempo real, chat ou edição colaborativa.
- Explore a integração do streaming MCP com frameworks frontend (React, Vue, etc.) para atualizações de UI ao vivo.
- Próximo: [Utilizando AI Toolkit para VSCode](../07-aitk/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.