<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:48:08+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "pt"
}
-->
Ótimo, para o próximo passo, vamos listar as capacidades no servidor.

### -2 Listar capacidades do servidor

Agora vamos conectar ao servidor e pedir as suas capacidades:

### -3- Converter capacidades do servidor para ferramentas LLM

O próximo passo após listar as capacidades do servidor é convertê-las para um formato que o LLM compreenda. Depois disso, podemos fornecer essas capacidades como ferramentas para o nosso LLM.

Ótimo, agora estamos prontos para lidar com quaisquer pedidos do utilizador, por isso vamos tratar disso a seguir.

### -4- Lidar com pedido de prompt do utilizador

Nesta parte do código, vamos tratar dos pedidos do utilizador.

Ótimo, conseguiste!

## Tarefa

Pega no código do exercício e desenvolve o servidor com mais algumas ferramentas. Depois cria um cliente com um LLM, como no exercício, e testa com diferentes prompts para garantir que todas as ferramentas do servidor são chamadas dinamicamente. Esta forma de construir um cliente garante uma ótima experiência para o utilizador final, pois pode usar prompts em linguagem natural, em vez de comandos exatos do cliente, sem se preocupar com a chamada a um servidor MCP.

## Solução

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Principais conclusões

- Adicionar um LLM ao cliente proporciona uma forma melhor para os utilizadores interagirem com servidores MCP.
- É necessário converter a resposta do servidor MCP para algo que o LLM consiga entender.

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Recursos adicionais

## O que vem a seguir

- Seguinte: [Consumir um servidor usando o Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.