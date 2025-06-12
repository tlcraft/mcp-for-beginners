<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-12T22:21:33+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "pt"
}
-->
# Executando este exemplo

Aqui está como executar o servidor e cliente de streaming HTTP clássico, assim como o servidor e cliente de streaming MCP usando Python.

### Visão geral

- Você irá configurar um servidor MCP que envia notificações de progresso para o cliente enquanto processa os itens.
- O cliente exibirá cada notificação em tempo real.
- Este guia cobre pré-requisitos, configuração, execução e solução de problemas.

### Pré-requisitos

- Python 3.9 ou superior
- O pacote Python `mcp` (instale com `pip install mcp`)

### Instalação e Configuração

1. Clone o repositório ou baixe os arquivos da solução.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Crie e ative um ambiente virtual (recomendado):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Instale as dependências necessárias:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Arquivos

- **Servidor:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Cliente:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Executando o Servidor de Streaming HTTP Clássico

1. Navegue até o diretório da solução:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Inicie o servidor de streaming HTTP clássico:

   ```pwsh
   python server.py
   ```

3. O servidor será iniciado e exibirá:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Executando o Cliente de Streaming HTTP Clássico

1. Abra um novo terminal (ative o mesmo ambiente virtual e diretório):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Você deverá ver as mensagens transmitidas impressas em sequência:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### Executando o Servidor de Streaming MCP

1. Navegue até o diretório da solução:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Inicie o servidor MCP com o transporte streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. O servidor será iniciado e exibirá:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Executando o Cliente de Streaming MCP

1. Abra um novo terminal (ative o mesmo ambiente virtual e diretório):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Você verá as notificações sendo exibidas em tempo real conforme o servidor processa cada item:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### Principais Etapas da Implementação

1. **Crie o servidor MCP usando FastMCP.**
2. **Defina uma ferramenta que processa uma lista e envia notificações usando `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` para operações não bloqueantes.**
- Sempre trate exceções tanto no servidor quanto no cliente para garantir robustez.
- Teste com múltiplos clientes para observar as atualizações em tempo real.
- Se encontrar erros, verifique sua versão do Python e confirme se todas as dependências estão instaladas.

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se a tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.