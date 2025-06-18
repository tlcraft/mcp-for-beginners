<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:46:17+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "br"
}
-->
# Demonstração de Streaming HTTP da Calculadora

Este projeto demonstra streaming HTTP usando Server-Sent Events (SSE) com Spring Boot WebFlux. Ele consiste em duas aplicações:

- **Calculator Server**: Um serviço web reativo que realiza cálculos e transmite os resultados usando SSE
- **Calculator Client**: Uma aplicação cliente que consome o endpoint de streaming

## Pré-requisitos

- Java 17 ou superior
- Maven 3.6 ou superior

## Estrutura do Projeto

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## Como Funciona

1. O **Calculator Server** expõe um endpoint `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Consome a resposta em streaming
   - Imprime cada evento no console

## Executando as Aplicações

### Opção 1: Usando Maven (Recomendado)

#### 1. Inicie o Calculator Server

Abra um terminal e navegue até o diretório do servidor:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

O servidor iniciará em `http://localhost:8080`

Você verá uma saída semelhante a:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Execute o Calculator Client

Abra um **novo terminal** e navegue até o diretório do cliente:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

O cliente se conectará ao servidor, realizará o cálculo e exibirá os resultados em streaming.

### Opção 2: Usando Java diretamente

#### 1. Compile e execute o servidor:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Compile e execute o cliente:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Testando o Servidor Manualmente

Você também pode testar o servidor usando um navegador ou curl:

### Usando um navegador:
Acesse: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Usando curl:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Saída Esperada

Ao executar o cliente, você deverá ver uma saída em streaming semelhante a:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Operações Suportadas

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- Retorna Server-Sent Events com o progresso do cálculo e o resultado

**Exemplo de Requisição:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Exemplo de Resposta:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Solução de Problemas

### Problemas Comuns

1. **Porta 8080 já em uso**
   - Pare qualquer outra aplicação que esteja usando a porta 8080
   - Ou altere a porta do servidor em `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` caso esteja rodando como processo em background

## Stack de Tecnologia

- **Spring Boot 3.3.1** - Framework de aplicação
- **Spring WebFlux** - Framework web reativo
- **Project Reactor** - Biblioteca de streams reativos
- **Netty** - Servidor I/O não bloqueante
- **Maven** - Ferramenta de build
- **Java 17+** - Linguagem de programação

## Próximos Passos

Tente modificar o código para:
- Adicionar mais operações matemáticas
- Incluir tratamento de erros para operações inválidas
- Adicionar logging de requisições/respostas
- Implementar autenticação
- Adicionar testes unitários

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.