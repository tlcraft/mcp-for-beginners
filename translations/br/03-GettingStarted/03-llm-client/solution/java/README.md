<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:25:36+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "br"
}
-->
# Calculator LLM Client

Uma aplicação Java que demonstra como usar LangChain4j para conectar a um serviço de calculadora MCP (Model Context Protocol) com integração dos GitHub Models.

## Pré-requisitos

- Java 21 ou superior
- Maven 3.6+ (ou use o Maven wrapper incluído)
- Uma conta GitHub com acesso aos GitHub Models
- Um serviço de calculadora MCP rodando em `http://localhost:8080`

## Obtendo o Token do GitHub

Esta aplicação usa GitHub Models, que requer um token de acesso pessoal do GitHub. Siga os passos para obter seu token:

### 1. Acesse os GitHub Models
1. Vá para [GitHub Models](https://github.com/marketplace/models)
2. Faça login com sua conta GitHub
3. Solicite acesso aos GitHub Models, caso ainda não tenha

### 2. Crie um Token de Acesso Pessoal
1. Vá para [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Clique em "Generate new token" → "Generate new token (classic)"
3. Dê um nome descritivo para seu token (ex: "MCP Calculator Client")
4. Defina a expiração conforme necessário
5. Selecione os seguintes escopos:
   - `repo` (se acessar repositórios privados)
   - `user:email`
6. Clique em "Generate token"
7. **Importante**: Copie o token imediatamente - você não poderá vê-lo novamente!

### 3. Configure a Variável de Ambiente

#### No Windows (Prompt de Comando):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### No Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### No macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Configuração e Instalação

1. **Clone ou navegue até o diretório do projeto**

2. **Instale as dependências**:
   ```cmd
   mvnw clean install
   ```
   Ou, se você tem o Maven instalado globalmente:
   ```cmd
   mvn clean install
   ```

3. **Configure a variável de ambiente** (veja a seção "Obtendo o Token do GitHub" acima)

4. **Inicie o Serviço MCP Calculator**:
   Certifique-se de que o serviço MCP calculator do capítulo 1 esteja rodando em `http://localhost:8080/sse`. Ele deve estar ativo antes de iniciar o cliente.

## Executando a Aplicação

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## O que a Aplicação Faz

A aplicação demonstra três interações principais com o serviço de calculadora:

1. **Adição**: Calcula a soma de 24.5 e 17.3  
2. **Raiz Quadrada**: Calcula a raiz quadrada de 144  
3. **Ajuda**: Mostra as funções disponíveis na calculadora

## Saída Esperada

Quando executado com sucesso, você verá uma saída semelhante a:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Solução de Problemas

### Problemas Comuns

1. **"GITHUB_TOKEN environment variable not set"**  
   - Verifique se você configurou a variável `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`

### Depuração

Para ativar o log de depuração, adicione o seguinte argumento JVM ao executar:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Configuração

A aplicação está configurada para:  
- Usar GitHub Models com o `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`  
- Usar timeout de 60 segundos para requisições  
- Habilitar log de requisição/resposta para depuração

## Dependências

Principais dependências usadas neste projeto:  
- **LangChain4j**: Para integração com IA e gerenciamento de ferramentas  
- **LangChain4j MCP**: Para suporte ao Model Context Protocol  
- **LangChain4j GitHub Models**: Para integração com GitHub Models  
- **Spring Boot**: Para framework da aplicação e injeção de dependências

## Licença

Este projeto está licenciado sob a Apache License 2.0 - veja o arquivo [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) para mais detalhes.

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.