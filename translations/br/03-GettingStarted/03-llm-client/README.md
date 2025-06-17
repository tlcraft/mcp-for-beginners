<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:48:21+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "br"
}
-->
Ótimo, para o nosso próximo passo, vamos listar as capacidades no servidor.

### -2 Listar capacidades do servidor

Agora vamos nos conectar ao servidor e pedir suas capacidades:

### -3- Converter capacidades do servidor para ferramentas do LLM

O próximo passo após listar as capacidades do servidor é convertê-las em um formato que o LLM entenda. Uma vez feito isso, podemos fornecer essas capacidades como ferramentas para o nosso LLM.

Ótimo, agora estamos prontos para lidar com quaisquer solicitações do usuário, então vamos para essa etapa.

### -4- Tratar solicitação de prompt do usuário

Nesta parte do código, vamos tratar as solicitações dos usuários.

Parabéns, você conseguiu!

## Tarefa

Pegue o código do exercício e expanda o servidor com mais ferramentas. Depois, crie um cliente com um LLM, como no exercício, e teste com diferentes prompts para garantir que todas as ferramentas do servidor sejam chamadas dinamicamente. Essa forma de construir um cliente proporciona uma ótima experiência para o usuário final, pois ele poderá usar prompts em linguagem natural, em vez de comandos exatos do cliente, sem perceber que um servidor MCP está sendo chamado.

## Solução

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Principais aprendizados

- Adicionar um LLM ao seu cliente oferece uma forma melhor para os usuários interagirem com servidores MCP.
- É necessário converter a resposta do servidor MCP para algo que o LLM possa entender.

## Exemplos

- [Calculadora em Java](../samples/java/calculator/README.md)
- [Calculadora em .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora em JavaScript](../samples/javascript/README.md)
- [Calculadora em TypeScript](../samples/typescript/README.md)
- [Calculadora em Python](../../../../03-GettingStarted/samples/python)

## Recursos adicionais

## Próximos passos

- Próximo: [Consumindo um servidor usando Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.