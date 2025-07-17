<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:34:01+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "br"
}
-->
# Exemplos Completos de Cliente MCP

Este diretório contém exemplos completos e funcionais de clientes MCP em diferentes linguagens de programação. Cada cliente demonstra toda a funcionalidade descrita no tutorial principal do README.md.

## Clientes Disponíveis

### 1. Cliente Java (`client_example_java.java`)
- **Transporte**: SSE (Server-Sent Events) via HTTP
- **Servidor Alvo**: `http://localhost:8080`
- **Recursos**: 
  - Estabelecimento de conexão e ping
  - Listagem de ferramentas
  - Operações de calculadora (adicionar, subtrair, multiplicar, dividir, ajuda)
  - Tratamento de erros e extração de resultados

**Para executar:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. Cliente C# (`client_example_csharp.cs`)
- **Transporte**: Stdio (Entrada/Saída padrão)
- **Servidor Alvo**: Servidor MCP .NET local via dotnet run
- **Recursos**:
  - Inicialização automática do servidor via transporte stdio
  - Listagem de ferramentas e recursos
  - Operações de calculadora
  - Análise de resultados em JSON
  - Tratamento abrangente de erros

**Para executar:**
```bash
dotnet run
```

### 3. Cliente TypeScript (`client_example_typescript.ts`)
- **Transporte**: Stdio (Entrada/Saída padrão)
- **Servidor Alvo**: Servidor MCP Node.js local
- **Recursos**:
  - Suporte completo ao protocolo MCP
  - Operações com ferramentas, recursos e prompts
  - Operações de calculadora
  - Leitura de recursos e execução de prompts
  - Tratamento robusto de erros

**Para executar:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Cliente Python (`client_example_python.py`)
- **Transporte**: Stdio (Entrada/Saída padrão)  
- **Servidor Alvo**: Servidor MCP Python local
- **Recursos**:
  - Padrão async/await para operações
  - Descoberta de ferramentas e recursos
  - Testes de operações de calculadora
  - Leitura de conteúdo de recursos
  - Organização baseada em classes

**Para executar:**
```bash
python client_example_python.py
```

## Recursos Comuns em Todos os Clientes

Cada implementação de cliente demonstra:

1. **Gerenciamento de Conexão**
   - Estabelecimento de conexão com o servidor MCP
   - Tratamento de erros de conexão
   - Limpeza adequada e gerenciamento de recursos

2. **Descoberta do Servidor**
   - Listagem de ferramentas disponíveis
   - Listagem de recursos disponíveis (quando suportado)
   - Listagem de prompts disponíveis (quando suportado)

3. **Invocação de Ferramentas**
   - Operações básicas de calculadora (adicionar, subtrair, multiplicar, dividir)
   - Comando de ajuda para informações do servidor
   - Passagem correta de argumentos e tratamento de resultados

4. **Tratamento de Erros**
   - Erros de conexão
   - Erros na execução das ferramentas
   - Falhas controladas e feedback ao usuário

5. **Processamento de Resultados**
   - Extração do conteúdo textual das respostas
   - Formatação da saída para melhor leitura
   - Tratamento de diferentes formatos de resposta

## Pré-requisitos

Antes de executar esses clientes, certifique-se de que:

1. **O servidor MCP correspondente esteja em execução** (a partir de `../01-first-server/`)
2. **As dependências necessárias estejam instaladas** para a linguagem escolhida
3. **A conectividade de rede esteja adequada** (para transportes baseados em HTTP)

## Principais Diferenças Entre as Implementações

| Linguagem  | Transporte | Inicialização do Servidor | Modelo Async | Bibliotecas Principais |
|------------|------------|---------------------------|--------------|-----------------------|
| Java       | SSE/HTTP   | Externa                   | Síncrono     | WebFlux, MCP SDK      |
| C#         | Stdio      | Automática                | Async/Await  | .NET MCP SDK          |
| TypeScript | Stdio      | Automática                | Async/Await  | Node MCP SDK          |
| Python     | Stdio      | Automática                | AsyncIO      | Python MCP SDK        |

## Próximos Passos

Após explorar esses exemplos de clientes:

1. **Modifique os clientes** para adicionar novos recursos ou operações
2. **Crie seu próprio servidor** e teste com esses clientes
3. **Experimente diferentes transportes** (SSE vs. Stdio)
4. **Construa uma aplicação mais complexa** que integre a funcionalidade MCP

## Solução de Problemas

### Problemas Comuns

1. **Conexão recusada**: Verifique se o servidor MCP está rodando na porta/caminho esperado
2. **Módulo não encontrado**: Instale o MCP SDK necessário para sua linguagem
3. **Permissão negada**: Verifique as permissões de arquivo para o transporte stdio
4. **Ferramenta não encontrada**: Confirme se o servidor implementa as ferramentas esperadas

### Dicas de Depuração

1. **Ative o log detalhado** no seu MCP SDK
2. **Verifique os logs do servidor** para mensagens de erro
3. **Confirme se os nomes e assinaturas das ferramentas** coincidem entre cliente e servidor
4. **Teste primeiro com o MCP Inspector** para validar a funcionalidade do servidor

## Documentação Relacionada

- [Tutorial Principal do Cliente](./README.md)
- [Exemplos de Servidor MCP](../../../../03-GettingStarted/01-first-server)
- [MCP com Integração LLM](../../../../03-GettingStarted/03-llm-client)
- [Documentação Oficial MCP](https://modelcontextprotocol.io/)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.