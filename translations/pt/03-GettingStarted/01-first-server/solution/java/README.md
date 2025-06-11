<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:31:40+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "pt"
}
-->
# Serviço Básico de Calculadora MCP

Este serviço oferece operações básicas de calculadora através do Model Context Protocol (MCP) usando Spring Boot com transporte WebFlux. Foi criado como um exemplo simples para iniciantes que estão aprendendo sobre implementações MCP.

Para mais informações, consulte a documentação de referência do [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html).

## Usando o Serviço

O serviço expõe os seguintes endpoints de API através do protocolo MCP:

- `add(a, b)`: Somar dois números
- `subtract(a, b)`: Subtrair o segundo número do primeiro
- `multiply(a, b)`: Multiplicar dois números
- `divide(a, b)`: Dividir o primeiro número pelo segundo (com verificação de zero)
- `power(base, exponent)`: Calcular a potência de um número
- `squareRoot(number)`: Calcular a raiz quadrada (com verificação para números negativos)
- `modulus(a, b)`: Calcular o resto da divisão
- `absolute(number)`: Calcular o valor absoluto

## Dependências

O projeto requer as seguintes dependências principais:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## Construindo o Projeto

Construa o projeto usando Maven:
```bash
./mvnw clean install -DskipTests
```

## Executando o Servidor

### Usando Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Usando o MCP Inspector

O MCP Inspector é uma ferramenta útil para interagir com serviços MCP. Para usá-lo com este serviço de calculadora:

1. **Instale e execute o MCP Inspector** em uma nova janela do terminal:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Acesse a interface web** clicando na URL exibida pelo aplicativo (normalmente http://localhost:6274)

3. **Configure a conexão**:
   - Defina o tipo de transporte para "SSE"
   - Defina a URL para o endpoint SSE do seu servidor em execução: `http://localhost:8080/sse`
   - Clique em "Connect"

4. **Use as ferramentas**:
   - Clique em "List Tools" para ver as operações de calculadora disponíveis
   - Selecione uma ferramenta e clique em "Run Tool" para executar uma operação

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.pt.png)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, por favor, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.