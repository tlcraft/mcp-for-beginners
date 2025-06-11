<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:09:52+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "br"
}
-->
# MCP Java Client - Demonstração da Calculadora

Este projeto demonstra como criar um cliente Java que se conecta e interage com um servidor MCP (Model Context Protocol). Neste exemplo, vamos conectar ao servidor da calculadora do Capítulo 01 e realizar várias operações matemáticas.

## Pré-requisitos

Antes de executar este cliente, você precisa:

1. **Iniciar o Servidor da Calculadora** do Capítulo 01:
   - Navegue até o diretório do servidor da calculadora: `03-GettingStarted/01-first-server/solution/java/`
   - Compile e execute o servidor da calculadora:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - O servidor deve estar rodando em `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` é uma aplicação Java que demonstra como:
- Conectar a um servidor MCP usando transporte Server-Sent Events (SSE)
- Listar as ferramentas disponíveis no servidor
- Chamar diversas funções da calculadora remotamente
- Tratar respostas e exibir resultados

## Como Funciona

O cliente utiliza o framework Spring AI MCP para:

1. **Estabelecer Conexão**: Cria um transporte WebFlux SSE para se conectar ao servidor da calculadora
2. **Inicializar Cliente**: Configura o cliente MCP e estabelece a conexão
3. **Descobrir Ferramentas**: Lista todas as operações disponíveis na calculadora
4. **Executar Operações**: Chama várias funções matemáticas com dados de exemplo
5. **Exibir Resultados**: Mostra os resultados de cada cálculo

## Estrutura do Projeto

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## Dependências Principais

O projeto utiliza as seguintes dependências principais:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Esta dependência fornece:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - transporte SSE para comunicação web
- Esquemas do protocolo MCP e tipos de requisição/resposta

## Construindo o Projeto

Construa o projeto usando o wrapper do Maven:

```cmd
.\mvnw clean install
```

## Executando o Cliente

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: Certifique-se de que o servidor da calculadora está rodando em `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Listar Ferramentas** - Exibe todas as operações disponíveis na calculadora
3. **Realizar Cálculos**:
   - Adição: 5 + 3 = 8
   - Subtração: 10 - 4 = 6
   - Multiplicação: 6 × 7 = 42
   - Divisão: 20 ÷ 4 = 5
   - Potência: 2^8 = 256
   - Raiz Quadrada: √16 = 4
   - Valor Absoluto: |-5.5| = 5.5
   - Ajuda: Exibe as operações disponíveis

## Saída Esperada

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Note**: Você pode ver avisos do Maven sobre threads pendentes no final - isso é normal para aplicações reativas e não indica erro.

## Entendendo o Código

### 1. Configuração do Transporte
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Isso cria um transporte SSE (Server-Sent Events) que conecta ao servidor da calculadora.

### 2. Criação do Cliente
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Cria um cliente MCP síncrono e inicializa a conexão.

### 3. Chamando Ferramentas
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Chama a ferramenta "add" com os parâmetros a=5.0 e b=3.0.

## Solução de Problemas

### Servidor Não Está Rodando
Se ocorrerem erros de conexão, verifique se o servidor da calculadora do Capítulo 01 está em execução:
```
Error: Connection refused
```
**Solução**: Inicie o servidor da calculadora primeiro.

### Porta Já Está Em Uso
Se a porta 8080 estiver ocupada:
```
Error: Address already in use
```
**Solução**: Pare outras aplicações que estejam usando a porta 8080 ou altere o servidor para usar outra porta.

### Erros na Construção
Se encontrar erros na construção:
```cmd
.\mvnw clean install -DskipTests
```

## Saiba Mais

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.