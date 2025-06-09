<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:19:09+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "br"
}
-->
Ótimo, para o próximo passo, vamos listar as capacidades no servidor.

### -2 Listar capacidades do servidor

Agora vamos conectar ao servidor e solicitar suas capacidades:

### -3- Converter capacidades do servidor em ferramentas para LLM

O próximo passo após listar as capacidades do servidor é convertê-las em um formato que o LLM compreenda. Depois disso, podemos fornecer essas capacidades como ferramentas para o nosso LLM.

Ótimo, agora estamos prontos para lidar com qualquer solicitação do usuário, então vamos para essa etapa.

### -4- Tratar solicitação do usuário

Nesta parte do código, vamos lidar com as solicitações dos usuários.

Parabéns, você conseguiu!

## Tarefa

Pegue o código do exercício e expanda o servidor com mais ferramentas. Depois, crie um cliente com um LLM, como no exercício, e teste com diferentes prompts para garantir que todas as ferramentas do servidor sejam chamadas dinamicamente. Essa forma de construir um cliente proporciona uma ótima experiência para o usuário final, pois ele pode usar prompts em linguagem natural, ao invés de comandos exatos do cliente, sem se preocupar com a chamada ao servidor MCP.

## Solução

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Principais Aprendizados

- Adicionar um LLM ao seu cliente oferece uma maneira melhor para os usuários interagirem com servidores MCP.
- É necessário converter a resposta do servidor MCP para algo que o LLM consiga entender.

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Recursos Adicionais

## Próximos Passos

- Próximo: [Consumindo um servidor usando Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.