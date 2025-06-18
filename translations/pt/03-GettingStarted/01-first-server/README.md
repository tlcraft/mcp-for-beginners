<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:19:36+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "pt"
}
-->
### -2- Criar projeto

Agora que tem o SDK instalado, vamos criar um projeto a seguir:

### -3- Criar ficheiros do projeto

### -4- Criar o código do servidor

### -5- Adicionar uma ferramenta e um recurso

Adicione uma ferramenta e um recurso adicionando o seguinte código:

### -6 Código final

Vamos adicionar o último código necessário para que o servidor possa arrancar:

### -7- Testar o servidor

Inicie o servidor com o seguinte comando:

### -8- Executar usando o inspector

O inspector é uma ótima ferramenta que pode iniciar o seu servidor e permitir que interaja com ele para testar se está a funcionar. Vamos arrancá-lo:

> [!NOTE]
> pode parecer diferente no campo "command" pois contém o comando para executar um servidor com o seu runtime específico/

Deverá ver a seguinte interface de utilizador:

![Conectar](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pt.png)

1. Conecte-se ao servidor selecionando o botão Conectar  
   Depois de se conectar ao servidor, deverá ver o seguinte:

   ![Conectado](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.pt.png)

2. Selecione "Tools" e "listTools", deverá ver aparecer "Add", selecione "Add" e preencha os valores dos parâmetros.

   Deverá ver a seguinte resposta, ou seja, um resultado da ferramenta "add":

   ![Resultado da execução do add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.pt.png)

Parabéns, conseguiu criar e executar o seu primeiro servidor!

### SDKs Oficiais

O MCP fornece SDKs oficiais para várias linguagens:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantido em colaboração com a Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantido em colaboração com a Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementação oficial em TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementação oficial em Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementação oficial em Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantido em colaboração com a Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementação oficial em Rust

## Principais pontos a reter

- Configurar um ambiente de desenvolvimento MCP é simples com SDKs específicos para cada linguagem
- Construir servidores MCP envolve criar e registar ferramentas com esquemas claros
- Testar e depurar são essenciais para implementações MCP fiáveis

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Exercício

Crie um servidor MCP simples com uma ferramenta à sua escolha:

1. Implemente a ferramenta na sua linguagem preferida (.NET, Java, Python ou JavaScript).
2. Defina os parâmetros de entrada e os valores de retorno.
3. Execute a ferramenta inspector para garantir que o servidor funciona como esperado.
4. Teste a implementação com vários inputs.

## Solução

[Solução](./solution/README.md)

## Recursos Adicionais

- [Criar Agentes usando Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP Remoto com Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agente MCP OpenAI .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Próximos passos

Seguinte: [Começar com Clientes MCP](/03-GettingStarted/02-client/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original, na sua língua nativa, deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional realizada por um humano. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.