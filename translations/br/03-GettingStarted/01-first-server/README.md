<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T16:59:47+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "br"
}
-->
### -2- Criar projeto

Agora que você instalou o SDK, vamos criar um projeto em seguida:

### -3- Criar arquivos do projeto

### -4- Criar o código do servidor

### -5- Adicionando uma ferramenta e um recurso

Adicione uma ferramenta e um recurso adicionando o seguinte código:

### -6 Código final

Vamos adicionar o último código que precisamos para que o servidor possa iniciar:

### -7- Testar o servidor

Inicie o servidor com o seguinte comando:

### -8- Executar usando o inspector

O inspector é uma ótima ferramenta que pode iniciar seu servidor e permite que você interaja com ele para testar se está funcionando. Vamos iniciá-lo:

> [!NOTE]
> pode parecer diferente no campo "command", pois contém o comando para rodar um servidor com seu runtime específico/

Você deve ver a seguinte interface de usuário:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.br.png)

1. Conecte-se ao servidor selecionando o botão Connect  
   Depois de se conectar ao servidor, você deverá ver o seguinte:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.br.png)

2. Selecione "Tools" e "listTools", você verá "Add" aparecer, selecione "Add" e preencha os valores dos parâmetros.

   Você deverá ver a seguinte resposta, ou seja, um resultado da ferramenta "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.br.png)

Parabéns, você conseguiu criar e executar seu primeiro servidor!

### SDKs Oficiais

O MCP oferece SDKs oficiais para várias linguagens:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantido em colaboração com a Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantido em colaboração com a Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementação oficial em TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementação oficial em Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementação oficial em Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantido em colaboração com a Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementação oficial em Rust

## Principais pontos

- Configurar um ambiente de desenvolvimento MCP é simples com SDKs específicos para cada linguagem
- Construir servidores MCP envolve criar e registrar ferramentas com esquemas claros
- Testar e depurar são essenciais para implementações MCP confiáveis

## Exemplos

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tarefa

Crie um servidor MCP simples com uma ferramenta de sua escolha:
1. Implemente a ferramenta na linguagem que preferir (.NET, Java, Python ou JavaScript).
2. Defina os parâmetros de entrada e os valores de retorno.
3. Execute a ferramenta inspector para garantir que o servidor funciona como esperado.
4. Teste a implementação com diferentes entradas.

## Solução

[Solution](./solution/README.md)

## Recursos adicionais

- [Repositório MCP no GitHub](https://github.com/microsoft/mcp-for-beginners)

## Próximos passos

Próximo: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.