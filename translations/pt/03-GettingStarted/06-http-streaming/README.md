<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:07:21+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "pt"
}
-->
# Streaming HTTPS com Model Context Protocol (MCP)

Este capítulo oferece um guia completo para implementar streaming seguro, escalável e em tempo real com o Model Context Protocol (MCP) usando HTTPS. Aborda a motivação para streaming, os mecanismos de transporte disponíveis, como implementar HTTP com streaming no MCP, melhores práticas de segurança, migração a partir de SSE e orientações práticas para construir as suas próprias aplicações MCP com streaming.

## Mecanismos de Transporte e Streaming no MCP

Esta secção explora os diferentes mecanismos de transporte disponíveis no MCP e o seu papel em permitir capacidades de streaming para comunicação em tempo real entre clientes e servidores.

### O que é um Mecanismo de Transporte?

Um mecanismo de transporte define como os dados são trocados entre o cliente e o servidor. O MCP suporta múltiplos tipos de transporte para se adaptar a diferentes ambientes e requisitos:

- **stdio**: Entrada/saída padrão, adequado para ferramentas locais e baseadas em linha de comandos. Simples, mas não indicado para web ou cloud.
- **SSE (Server-Sent Events)**: Permite que os servidores enviem atualizações em tempo real para os clientes via HTTP. Bom para interfaces web, mas limitado em escalabilidade e flexibilidade.
- **Streamable HTTP**: Transporte moderno baseado em HTTP para streaming, suportando notificações e melhor escalabilidade. Recomendado para a maioria dos cenários de produção e cloud.

### Tabela de Comparação

Veja a tabela de comparação abaixo para compreender as diferenças entre estes mecanismos de transporte:

| Transporte        | Atualizações em Tempo Real | Streaming | Escalabilidade | Caso de Uso               |
|-------------------|----------------------------|-----------|----------------|--------------------------|
| stdio             | Não                        | Não       | Baixa          | Ferramentas CLI locais    |
| SSE               | Sim                        | Sim       | Média          | Web, atualizações em tempo real |
| Streamable HTTP   | Sim                        | Sim       | Alta           | Cloud, multi-cliente      |

> **Tip:** Escolher o transporte certo impacta o desempenho, escalabilidade e experiência do utilizador. O **Streamable HTTP** é recomendado para aplicações modernas, escaláveis e preparadas para cloud.

Note os transportes stdio e SSE apresentados nos capítulos anteriores e como o Streamable HTTP é o transporte abordado neste capítulo.

## Streaming: Conceitos e Motivação

Compreender os conceitos fundamentais e as motivações por trás do streaming é essencial para implementar sistemas eficazes de comunicação em tempo real.

**Streaming** é uma técnica em programação de redes que permite enviar e receber dados em pequenos pedaços geríveis ou como uma sequência de eventos, em vez de esperar pela resposta completa. Isto é especialmente útil para:

- Ficheiros ou conjuntos de dados grandes.
- Atualizações em tempo real (ex.: chat, barras de progresso).
- Cálculos longos onde se quer manter o utilizador informado.

Aqui está o que precisa saber sobre streaming a um nível elevado:

- Os dados são entregues progressivamente, não todos de uma vez.
- O cliente pode processar os dados à medida que chegam.
- Reduz a latência percebida e melhora a experiência do utilizador.

### Porque usar streaming?

As razões para usar streaming são as seguintes:

- Os utilizadores recebem feedback imediato, não só no final.
- Permite aplicações em tempo real e interfaces responsivas.
- Utilização mais eficiente dos recursos de rede e computação.

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

Este exemplo demonstra um servidor a enviar uma série de mensagens para o cliente à medida que ficam disponíveis, em vez de esperar que todas as mensagens estejam prontas.

**Como funciona:**
- O servidor envia cada mensagem assim que está pronta.
- O cliente recebe e imprime cada pedaço assim que chega.

**Requisitos:**
- O servidor deve usar uma resposta em streaming (ex.: `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

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

- **Para necessidades simples de streaming:** O streaming HTTP clássico é mais simples de implementar e suficiente para necessidades básicas.

- **Para aplicações complexas e interativas:** O streaming MCP oferece uma abordagem mais estruturada com metadados mais ricos e separação entre notificações e resultados finais.

- **Para aplicações de IA:** O sistema de notificações do MCP é particularmente útil para tarefas de IA longas onde se quer manter os utilizadores informados do progresso.

## Streaming no MCP

Ok, já viu algumas recomendações e comparações até agora sobre a diferença entre streaming clássico e streaming no MCP. Vamos entrar em detalhe sobre como pode tirar partido do streaming no MCP.

Compreender como o streaming funciona dentro do framework MCP é essencial para construir aplicações responsivas que fornecem feedback em tempo real aos utilizadores durante operações demoradas.

No MCP, streaming não significa enviar a resposta principal em pedaços, mas sim enviar **notificações** para o cliente enquanto uma ferramenta está a processar um pedido. Estas notificações podem incluir atualizações de progresso, logs ou outros eventos.

### Como funciona

O resultado principal é enviado como uma única resposta. No entanto, as notificações podem ser enviadas como mensagens separadas durante o processamento, atualizando assim o cliente em tempo real. O cliente deve ser capaz de tratar e apresentar estas notificações.

## O que é uma Notificação?

Falámos de "Notificação", o que significa isso no contexto do MCP?

Uma notificação é uma mensagem enviada do servidor para o cliente para informar sobre progresso, estado ou outros eventos durante uma operação longa. As notificações melhoram a transparência e a experiência do utilizador.

Por exemplo, um cliente deve enviar uma notificação assim que o handshake inicial com o servidor for concluído.

Uma notificação tem a seguinte aparência numa mensagem JSON:

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

| Nível     | Descrição                    | Exemplo de Uso                |
|-----------|------------------------------|------------------------------|
| debug     | Informação detalhada de debugging | Pontos de entrada/saída de funções |
| info      | Mensagens informativas gerais | Atualizações de progresso da operação |
| notice    | Eventos normais mas significativos | Alterações de configuração    |
| warning   | Condições de aviso            | Uso de funcionalidades obsoletas |
| error     | Condições de erro             | Falhas na operação            |
| critical  | Condições críticas            | Falhas em componentes do sistema |
| alert     | Ação imediata necessária      | Detecção de corrupção de dados |
| emergency | Sistema inutilizável          | Falha completa do sistema     |

## Implementação de Notificações no MCP

Para implementar notificações no MCP, precisa configurar tanto o lado do servidor como do cliente para lidar com atualizações em tempo real. Isto permite que a sua aplicação forneça feedback imediato aos utilizadores durante operações demoradas.

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

No exemplo anterior, o transporte `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

</details>

### Lado do Cliente: Receção de Notificações

O cliente deve implementar um manipulador de mensagens para processar e mostrar as notificações assim que chegarem.

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

No código anterior, o `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) e o seu cliente implementa um manipulador de mensagens para processar notificações.

## Notificações de Progresso & Cenários

Esta secção explica o conceito de notificações de progresso no MCP, porque são importantes e como implementá-las usando Streamable HTTP. Também encontrará um exercício prático para reforçar o seu entendimento.

As notificações de progresso são mensagens em tempo real enviadas do servidor para o cliente durante operações demoradas. Em vez de esperar que todo o processo termine, o servidor mantém o cliente atualizado sobre o estado atual. Isto melhora a transparência, a experiência do utilizador e facilita a depuração.

**Exemplo:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Porque Usar Notificações de Progresso?

As notificações de progresso são essenciais por várias razões:

- **Melhor experiência do utilizador:** Os utilizadores veem atualizações à medida que o trabalho avança, não só no final.
- **Feedback em tempo real:** Os clientes podem mostrar barras de progresso ou logs, tornando a aplicação mais responsiva.
- **Depuração e monitorização facilitadas:** Desenvolvedores e utilizadores podem ver onde um processo pode estar lento ou bloqueado.

### Como Implementar Notificações de Progresso

Aqui está como pode implementar notificações de progresso no MCP:

- **No servidor:** Use `ctx.info()` or `ctx.log()` para enviar notificações à medida que cada item é processado. Isto envia uma mensagem ao cliente antes do resultado principal estar pronto.
- **No cliente:** Implemente um manipulador de mensagens que escute e mostre notificações assim que chegam. Este manipulador distingue entre notificações e o resultado final.

**Exemplo de Servidor:**

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

Ao implementar servidores MCP com transportes baseados em HTTP, a segurança torna-se uma preocupação fundamental que requer atenção cuidadosa a múltiplos vetores de ataque e mecanismos de proteção.

### Visão Geral

A segurança é crítica ao expor servidores MCP via HTTP. O Streamable HTTP introduz novas superfícies de ataque e requer configuração cuidadosa.

### Pontos-Chave
- **Validação do Header Origin**: Sempre valide o `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` em vez do cliente SSE.
3. **Implemente um manipulador de mensagens** no cliente para processar notificações.
4. **Teste a compatibilidade** com ferramentas e fluxos de trabalho existentes.

### Manutenção da Compatibilidade

Recomenda-se manter compatibilidade com clientes SSE existentes durante o processo de migração. Aqui estão algumas estratégias:

- Pode suportar ambos SSE e Streamable HTTP executando ambos os transportes em endpoints diferentes.
- Migre os clientes gradualmente para o novo transporte.

### Desafios

Assegure que aborda os seguintes desafios durante a migração:

- Garantir que todos os clientes são atualizados
- Lidar com diferenças na entrega de notificações

### Exercício: Construa a Sua Própria Aplicação MCP com Streaming

**Cenário:**
Construa um servidor e cliente MCP onde o servidor processa uma lista de itens (ex.: ficheiros ou documentos) e envia uma notificação para cada item processado. O cliente deve mostrar cada notificação assim que chega.

**Passos:**

1. Implemente uma ferramenta no servidor que processe uma lista e envie notificações para cada item.
2. Implemente um cliente com um manipulador de mensagens para mostrar notificações em tempo real.
3. Teste a sua implementação executando servidor e cliente e observe as notificações.

[Solução](./solution/README.md)

## Leitura Adicional & Próximos Passos

Para continuar a sua jornada com o streaming MCP e expandir o seu conhecimento, esta secção fornece recursos adicionais e sugestões para construir aplicações mais avançadas.

### Leitura Adicional

- [Microsoft: Introdução ao HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS no ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Próximos Passos

- Experimente construir ferramentas MCP mais avançadas que usem streaming para análises em tempo real, chat ou edição colaborativa.
- Explore a integração do streaming MCP com frameworks frontend (React, Vue, etc.) para atualizações ao vivo da interface.
- A seguir: [Utilização do AI Toolkit para VSCode](../07-aitk/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos por garantir a precisão, por favor tenha em atenção que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações erradas decorrentes da utilização desta tradução.