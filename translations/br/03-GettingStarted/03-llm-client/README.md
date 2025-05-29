<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-29T20:20:48+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "br"
}
-->
Ótimo, para o nosso próximo passo, vamos listar as capacidades no servidor.

### -2 Listar capacidades do servidor

Agora vamos nos conectar ao servidor e pedir suas capacidades:

### -3- Converter capacidades do servidor para ferramentas LLM

O próximo passo após listar as capacidades do servidor é convertê-las para um formato que o LLM entenda. Uma vez feito isso, podemos fornecer essas capacidades como ferramentas para o nosso LLM.

Ótimo, agora estamos prontos para lidar com qualquer solicitação do usuário, então vamos para essa parte.

### -4- Lidar com solicitação de prompt do usuário

Nesta parte do código, vamos tratar as solicitações dos usuários.

Parabéns, você conseguiu!

## Tarefa

Pegue o código do exercício e desenvolva o servidor com mais ferramentas. Depois, crie um cliente com um LLM, como no exercício, e teste com diferentes prompts para garantir que todas as ferramentas do servidor sejam chamadas dinamicamente. Essa forma de construir um cliente proporciona uma ótima experiência para o usuário final, pois ele pode usar prompts em linguagem natural, em vez de comandos exatos do cliente, sem se preocupar com a existência de um servidor MCP sendo chamado.

## Solução

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Principais aprendizados

- Adicionar um LLM ao seu cliente oferece uma forma melhor para os usuários interagirem com servidores MCP.
- É necessário converter a resposta do servidor MCP para algo que o LLM possa entender.

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../../../../03-GettingStarted/samples/javascript)
- [Calculadora TypeScript](../../../../03-GettingStarted/samples/typescript)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Recursos adicionais

## Próximos passos

- Próximo: [Consumindo um servidor usando Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se a tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.