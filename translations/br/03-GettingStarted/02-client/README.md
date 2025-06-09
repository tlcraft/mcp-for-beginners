<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-29T20:24:47+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "br"
}
-->
No código anterior nós:

- Importamos as bibliotecas
- Criamos uma instância de um client e conectamos usando stdio para transporte.
- Listamos prompts, recursos e ferramentas e invocamos todos eles.

Pronto, um client que pode se comunicar com um MCP Server.

Vamos dedicar um tempo na próxima seção de exercícios para analisar cada trecho de código e explicar o que está acontecendo.

## Exercício: Escrevendo um client

Como dito acima, vamos com calma explicando o código, e sinta-se à vontade para programar junto se quiser.

### -1- Importando as bibliotecas

Vamos importar as bibliotecas que precisamos, precisaremos de referências para um client e para o protocolo de transporte escolhido, stdio. stdio é um protocolo para coisas que rodam na sua máquina local. SSE é outro protocolo de transporte que mostraremos em capítulos futuros, mas essa é a outra opção. Por enquanto, vamos continuar com stdio.

Vamos avançar para a instanciação.

### -2- Instanciando client e transporte

Precisamos criar uma instância do transporte e outra do nosso client:

### -3- Listando as funcionalidades do servidor

Agora temos um client que pode se conectar quando o programa for executado. No entanto, ele não lista suas funcionalidades, então vamos fazer isso agora:

Ótimo, agora capturamos todas as funcionalidades. A pergunta é: quando as usamos? Bem, este client é bem simples, no sentido de que precisaremos chamar explicitamente as funcionalidades quando quisermos. No próximo capítulo, criaremos um client mais avançado que terá acesso ao seu próprio modelo de linguagem grande, LLM. Por enquanto, vamos ver como invocar as funcionalidades no servidor:

### -4- Invocando funcionalidades

Para invocar as funcionalidades, precisamos garantir que especificamos os argumentos corretos e, em alguns casos, o nome do que estamos tentando invocar.

### -5- Executando o client

Para executar o client, digite o seguinte comando no terminal:

## Tarefa

Nesta tarefa, você usará o que aprendeu para criar um client, mas crie um client próprio.

Aqui está um servidor que você pode usar e que precisa ser chamado via seu código client, veja se consegue adicionar mais funcionalidades ao servidor para torná-lo mais interessante.

## Solução

[Solução](./solution/README.md)

## Principais Aprendizados

Os principais aprendizados deste capítulo sobre clients são:

- Podem ser usados tanto para descobrir quanto para invocar funcionalidades no servidor.
- Podem iniciar um servidor enquanto se iniciam (como neste capítulo), mas clients também podem se conectar a servidores já em execução.
- São uma ótima maneira de testar as capacidades do servidor além de alternativas como o Inspector, conforme descrito no capítulo anterior.

## Recursos Adicionais

- [Construindo clients em MCP](https://modelcontextprotocol.io/quickstart/client)

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## O que vem a seguir

- Próximo: [Criando um client com um LLM](/03-GettingStarted/03-llm-client/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.