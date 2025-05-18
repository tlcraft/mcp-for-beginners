<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a8086dc4bf89448f83e7936db972c42",
  "translation_date": "2025-05-17T11:33:36+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "br"
}
-->
Agora que sabemos um pouco mais sobre SSE, vamos construir um servidor SSE a seguir.

## Exercício: Criando um Servidor SSE

Para criar nosso servidor, precisamos ter duas coisas em mente:

- Precisamos usar um servidor web para expor endpoints para conexão e mensagens.
- Construir nosso servidor como normalmente fazemos com ferramentas, recursos e prompts quando usamos stdio.

### -1- Criar uma instância do servidor

Para criar nosso servidor, usamos os mesmos tipos que com stdio. No entanto, para o transporte, precisamos escolher SSE.

Vamos adicionar as rotas necessárias a seguir.

### -2- Adicionar rotas

Vamos adicionar rotas a seguir que lidam com a conexão e mensagens recebidas:

Vamos adicionar capacidades ao servidor a seguir.

### -3- Adicionando capacidades ao servidor

Agora que temos tudo específico do SSE definido, vamos adicionar capacidades ao servidor como ferramentas, prompts e recursos.

Seu código completo deve ficar assim:

Ótimo, temos um servidor usando SSE, vamos testá-lo a seguir.

## Exercício: Debugando um Servidor SSE com o Inspector

O Inspector é uma ótima ferramenta que vimos em uma lição anterior [Criando seu primeiro servidor](/03-GettingStarted/01-first-server/README.md). Vamos ver se podemos usar o Inspector aqui também:

### -1- Executando o inspector

Para executar o inspector, primeiro você deve ter um servidor SSE em execução, então vamos fazer isso a seguir:

1. Execute o servidor

1. Execute o inspector

    > ![NOTE]
    > Execute isso em uma janela de terminal separada daquela em que o servidor está rodando. Além disso, observe que você precisa ajustar o comando abaixo para se adequar à URL onde seu servidor está rodando.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Executar o inspector parece o mesmo em todos os ambientes de execução. Note como, em vez de passar um caminho para nosso servidor e um comando para iniciar o servidor, passamos a URL onde o servidor está rodando e também especificamos a rota `/sse`.

### -2- Testando a ferramenta

Conecte o servidor selecionando SSE na lista suspensa e preencha o campo de URL onde seu servidor está rodando, por exemplo http:localhost:4321/sse. Agora clique no botão "Connect". Como antes, selecione listar ferramentas, selecione uma ferramenta e forneça valores de entrada. Você deve ver um resultado como abaixo:

![Servidor SSE rodando no inspector](../../../../translated_images/sse-inspector.12861eb95abecbfc82610f480b55901524fed1a6aca025bb948e09e882c48428.br.png)

Ótimo, você consegue trabalhar com o inspector, vamos ver como podemos trabalhar com o Visual Studio Code a seguir.

## Tarefa

Tente construir seu servidor com mais capacidades. Veja [esta página](https://api.chucknorris.io/) para, por exemplo, adicionar uma ferramenta que chama uma API, você decide como o servidor deve ser. Divirta-se :)

## Solução

[Solução](./solution/README.md) Aqui está uma possível solução com código funcionando.

## Principais Conclusões

As conclusões deste capítulo são as seguintes:

- SSE é o segundo transporte suportado ao lado de stdio.
- Para suportar SSE, você precisa gerenciar conexões e mensagens recebidas usando um framework web.
- Você pode usar tanto o Inspector quanto o Visual Studio Code para consumir servidores SSE, assim como servidores stdio. Note como ele difere um pouco entre stdio e SSE. Para SSE, você precisa iniciar o servidor separadamente e então executar sua ferramenta inspector. Para a ferramenta inspector, há também algumas diferenças em que você precisa especificar a URL.

## Exemplos

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Recursos Adicionais

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## O Que Vem a Seguir

- Próximo: [Introdução ao AI Toolkit para VSCode](/03-GettingStarted/06-aitk/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automatizadas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.