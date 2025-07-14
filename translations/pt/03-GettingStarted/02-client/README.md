<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:14:05+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "pt"
}
-->
No código anterior nós:

- Importamos as bibliotecas
- Criámos uma instância de um cliente e ligámo-lo usando stdio para transporte.
- Listámos prompts, recursos e ferramentas e invocámo-los todos.

E está feito, um cliente que pode comunicar com um Servidor MCP.

Vamos dedicar algum tempo na próxima secção de exercícios para analisar cada trecho de código e explicar o que está a acontecer.

## Exercício: Escrever um cliente

Como foi dito acima, vamos dedicar tempo a explicar o código, e claro, sinta-se à vontade para programar juntamente connosco se quiser.

### -1- Importar as bibliotecas

Vamos importar as bibliotecas de que precisamos, vamos precisar de referências a um cliente e ao protocolo de transporte escolhido, stdio. stdio é um protocolo para coisas que se destinam a correr na sua máquina local. SSE é outro protocolo de transporte que mostraremos em capítulos futuros, mas essa é a sua outra opção. Por agora, vamos continuar com stdio.

Vamos avançar para a instanciação.

### -2- Instanciar cliente e transporte

Vamos precisar de criar uma instância do transporte e outra do nosso cliente:

### -3- Listar as funcionalidades do servidor

Agora, temos um cliente que pode ligar-se ao servidor caso o programa seja executado. No entanto, ele não lista realmente as suas funcionalidades, por isso vamos fazer isso a seguir:

Ótimo, agora capturámos todas as funcionalidades. Agora a questão é: quando as usamos? Bem, este cliente é bastante simples, simples no sentido de que teremos de chamar explicitamente as funcionalidades quando as quisermos. No próximo capítulo, vamos criar um cliente mais avançado que tem acesso ao seu próprio modelo de linguagem grande, LLM. Por agora, vamos ver como podemos invocar as funcionalidades no servidor:

### -4- Invocar funcionalidades

Para invocar as funcionalidades, precisamos de garantir que especificamos os argumentos corretos e, em alguns casos, o nome do que estamos a tentar invocar.

### -5- Executar o cliente

Para executar o cliente, escreva o seguinte comando no terminal:

## Tarefa

Nesta tarefa, vai usar o que aprendeu na criação de um cliente, mas criar um cliente seu próprio.

Aqui está um servidor que pode usar e que precisa de chamar através do seu código cliente, veja se consegue adicionar mais funcionalidades ao servidor para o tornar mais interessante.

## Solução

[Solução](./solution/README.md)

## Principais Conclusões

As principais conclusões deste capítulo sobre clientes são as seguintes:

- Podem ser usados tanto para descobrir como para invocar funcionalidades no servidor.
- Podem iniciar um servidor enquanto se iniciam a si próprios (como neste capítulo), mas os clientes também podem ligar-se a servidores em execução.
- São uma ótima forma de testar as capacidades do servidor, ao lado de alternativas como o Inspector, conforme descrito no capítulo anterior.

## Recursos Adicionais

- [Construir clientes em MCP](https://modelcontextprotocol.io/quickstart/client)

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## O que vem a seguir

- A seguir: [Criar um cliente com um LLM](../03-llm-client/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.