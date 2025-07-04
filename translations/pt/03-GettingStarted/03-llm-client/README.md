<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-04T16:58:29+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "pt"
}
-->
Ótimo, para o nosso próximo passo, vamos listar as capacidades no servidor.

### -2 Listar capacidades do servidor

Agora vamos conectar ao servidor e pedir as suas capacidades:

### -3- Converter capacidades do servidor em ferramentas para o LLM

O próximo passo após listar as capacidades do servidor é convertê-las para um formato que o LLM compreenda. Depois de fazermos isso, podemos fornecer essas capacidades como ferramentas para o nosso LLM.

Ótimo, agora estamos prontos para lidar com pedidos dos utilizadores, por isso vamos tratar disso a seguir.

### -4- Lidar com pedidos de prompt do utilizador

Nesta parte do código, vamos tratar os pedidos dos utilizadores.

Ótimo, conseguiste!

## Tarefa

Pega no código do exercício e desenvolve o servidor com mais algumas ferramentas. Depois cria um cliente com um LLM, como no exercício, e testa com diferentes prompts para garantir que todas as ferramentas do servidor são chamadas dinamicamente. Esta forma de construir um cliente significa que o utilizador final terá uma ótima experiência, pois pode usar prompts em linguagem natural, em vez de comandos exatos do cliente, sem se aperceber de que está a ser chamado um servidor MCP.

## Solução

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Principais conclusões

- Adicionar um LLM ao teu cliente oferece uma forma melhor para os utilizadores interagirem com servidores MCP.
- É necessário converter a resposta do servidor MCP para algo que o LLM consiga entender.

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Recursos adicionais

## O que vem a seguir

- Seguinte: [Consumir um servidor usando Visual Studio Code](../04-vscode/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações erradas decorrentes da utilização desta tradução.