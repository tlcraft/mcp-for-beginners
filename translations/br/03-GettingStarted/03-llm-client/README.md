<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:19:36+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "br"
}
-->
# Criando um cliente com LLM

Até agora, você viu como criar um servidor e um cliente. O cliente foi capaz de chamar o servidor explicitamente para listar suas ferramentas, recursos e prompts. No entanto, essa não é uma abordagem muito prática. Seu usuário vive na era agentica e espera usar prompts e se comunicar com um LLM para fazer isso. Para seu usuário, não importa se você usa MCP ou não para armazenar suas capacidades, mas eles esperam usar linguagem natural para interagir. Então, como resolvemos isso? A solução é adicionar um LLM ao cliente.

## Visão Geral

Nesta lição, focamos em adicionar um LLM ao seu cliente e mostramos como isso proporciona uma experiência muito melhor para seu usuário.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Criar um cliente com um LLM.
- Interagir perfeitamente com um servidor MCP usando um LLM.
- Proporcionar uma melhor experiência ao usuário final no lado do cliente.

## Abordagem

Vamos tentar entender a abordagem que precisamos adotar. Adicionar um LLM parece simples, mas realmente faremos isso?

Veja como o cliente irá interagir com o servidor:

1. Estabelecer conexão com o servidor.

1. Listar capacidades, prompts, recursos e ferramentas, e salvar seus esquemas.

1. Adicionar um LLM e passar as capacidades salvas e seus esquemas em um formato que o LLM entenda.

1. Lidar com um prompt de usuário passando-o para o LLM junto com as ferramentas listadas pelo cliente.

Ótimo, agora entendemos como podemos fazer isso em um nível alto, vamos tentar isso no exercício abaixo.

## Exercício: Criando um cliente com um LLM

Neste exercício, aprenderemos a adicionar um LLM ao nosso cliente.

### -1- Conectar ao servidor

Vamos criar nosso cliente primeiro:
Você foi treinado com dados até outubro de 2023.

Ótimo, para nosso próximo passo, vamos listar as capacidades no servidor.

### -2- Listar capacidades do servidor

Agora vamos conectar ao servidor e pedir suas capacidades.

### -3- Converter capacidades do servidor em ferramentas para LLM

O próximo passo após listar as capacidades do servidor é convertê-las em um formato que o LLM entenda. Uma vez feito isso, podemos fornecer essas capacidades como ferramentas para nosso LLM.

Ótimo, agora estamos preparados para lidar com qualquer solicitação do usuário, então vamos enfrentar isso a seguir.

### -4- Lidar com solicitação de prompt do usuário

Nesta parte do código, lidaremos com solicitações de usuário.

Ótimo, você conseguiu!

## Tarefa

Pegue o código do exercício e construa o servidor com algumas ferramentas a mais. Então, crie um cliente com um LLM, como no exercício, e teste com diferentes prompts para garantir que todas as ferramentas do seu servidor sejam chamadas dinamicamente. Esse jeito de construir um cliente significa que o usuário final terá uma ótima experiência, pois poderá usar prompts, em vez de comandos exatos do cliente, e não perceberá qualquer servidor MCP sendo chamado.

## Solução

[Solução](/03-GettingStarted/03-llm-client/solution/README.md)

## Principais Conclusões

- Adicionar um LLM ao seu cliente proporciona uma maneira melhor para os usuários interagirem com Servidores MCP.
- Você precisa converter a resposta do Servidor MCP para algo que o LLM possa entender.

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Recursos Adicionais

## O que vem a seguir

- Próximo: [Consumindo um servidor usando Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.