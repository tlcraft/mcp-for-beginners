<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a8086dc4bf89448f83e7936db972c42",
  "translation_date": "2025-05-17T11:33:09+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "pt"
}
-->
Agora que sabemos um pouco mais sobre SSE, vamos construir um servidor SSE em seguida.

## Exercício: Criando um Servidor SSE

Para criar nosso servidor, precisamos ter duas coisas em mente:

- Precisamos usar um servidor web para expor endpoints para conexão e mensagens.
- Construir nosso servidor como normalmente fazemos com ferramentas, recursos e prompts quando estávamos usando stdio.

### -1- Criar uma instância do servidor

Para criar nosso servidor, usamos os mesmos tipos que com stdio. No entanto, para o transporte, precisamos escolher SSE.

Vamos adicionar as rotas necessárias a seguir.

### -2- Adicionar rotas

Vamos adicionar as rotas a seguir que lidam com a conexão e mensagens recebidas:

Vamos adicionar capacidades ao servidor a seguir.

### -3- Adicionando capacidades ao servidor

Agora que definimos tudo o que é específico do SSE, vamos adicionar capacidades ao servidor como ferramentas, prompts e recursos.

Seu código completo deve se parecer com isso:

Ótimo, temos um servidor usando SSE, vamos testá-lo em seguida.

## Exercício: Depurando um Servidor SSE com o Inspector

Inspector é uma ótima ferramenta que vimos em uma lição anterior [Criando seu primeiro servidor](/03-GettingStarted/01-first-server/README.md). Vamos ver se podemos usar o Inspector mesmo aqui:

### -1- Executando o inspector

Para executar o inspector, você deve primeiro ter um servidor SSE em execução, então vamos fazer isso em seguida:

1. Execute o servidor

1. Execute o inspector

    > ![NOTE]
    > Execute isso em uma janela de terminal separada daquela em que o servidor está em execução. Observe também que você precisa ajustar o comando abaixo para se adequar à URL onde seu servidor está rodando.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Executar o inspector parece o mesmo em todos os runtimes. Note como, em vez de passar um caminho para o nosso servidor e um comando para iniciar o servidor, passamos a URL onde o servidor está rodando e também especificamos a rota `/sse`.

### -2- Testando a ferramenta

Conecte-se ao servidor selecionando SSE na lista suspensa e preencha o campo de URL onde seu servidor está rodando, por exemplo, http:localhost:4321/sse. Agora clique no botão "Connect". Como antes, selecione listar ferramentas, escolha uma ferramenta e forneça valores de entrada. Você deve ver um resultado como abaixo:

![Servidor SSE em execução no inspector](../../../../translated_images/sse-inspector.12861eb95abecbfc82610f480b55901524fed1a6aca025bb948e09e882c48428.pt.png)

Ótimo, você conseguiu trabalhar com o inspector, vamos ver como podemos trabalhar com o Visual Studio Code em seguida.

## Tarefa

Tente expandir seu servidor com mais capacidades. Veja [esta página](https://api.chucknorris.io/) para, por exemplo, adicionar uma ferramenta que chama uma API, você decide como o servidor deve ser. Divirta-se :)

## Solução

[Solução](./solution/README.md) Aqui está uma solução possível com código funcionando.

## Principais Aprendizados

Os aprendizados deste capítulo são os seguintes:

- SSE é o segundo transporte suportado ao lado de stdio.
- Para suportar SSE, você precisa gerenciar conexões e mensagens recebidas usando um framework web.
- Você pode usar tanto o Inspector quanto o Visual Studio Code para consumir o servidor SSE, assim como servidores stdio. Observe como difere um pouco entre stdio e SSE. Para SSE, você precisa iniciar o servidor separadamente e depois executar sua ferramenta inspector. Para a ferramenta inspector, também há algumas diferenças em que você precisa especificar a URL.

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Recursos Adicionais

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## O que vem a seguir

- Próximo: [Introdução ao AI Toolkit para VSCode](/03-GettingStarted/06-aitk/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se uma tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações errôneas decorrentes do uso desta tradução.