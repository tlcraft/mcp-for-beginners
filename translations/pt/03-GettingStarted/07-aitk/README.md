<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:32:07+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "pt"
}
-->
# Consumir um servidor da extensão AI Toolkit para Visual Studio Code

Quando está a construir um agente de IA, não se trata apenas de gerar respostas inteligentes; trata-se também de dar ao seu agente a capacidade de agir. É aqui que entra o Model Context Protocol (MCP). O MCP facilita o acesso dos agentes a ferramentas e serviços externos de forma consistente. Pense nisso como ligar o seu agente a uma caixa de ferramentas que ele pode *realmente* usar.

Suponha que liga um agente ao seu servidor MCP de calculadora. De repente, o seu agente pode realizar operações matemáticas apenas ao receber um prompt como “Quanto é 47 vezes 89?” — sem necessidade de codificar lógica ou criar APIs personalizadas.

## Visão geral

Esta lição explica como ligar um servidor MCP de calculadora a um agente com a extensão [AI Toolkit](https://aka.ms/AIToolkit) no Visual Studio Code, permitindo que o seu agente realize operações matemáticas como adição, subtração, multiplicação e divisão através de linguagem natural.

O AI Toolkit é uma extensão poderosa para o Visual Studio Code que simplifica o desenvolvimento de agentes. Os Engenheiros de IA podem facilmente construir aplicações de IA desenvolvendo e testando modelos generativos de IA — localmente ou na cloud. A extensão suporta a maioria dos principais modelos generativos disponíveis atualmente.

*Nota*: O AI Toolkit suporta atualmente Python e TypeScript.

## Objetivos de aprendizagem

No final desta lição, será capaz de:

- Consumir um servidor MCP através do AI Toolkit.
- Configurar uma configuração de agente para permitir que descubra e utilize ferramentas fornecidas pelo servidor MCP.
- Utilizar ferramentas MCP através de linguagem natural.

## Abordagem

Aqui está como devemos abordar isto a um nível elevado:

- Criar um agente e definir o seu prompt de sistema.
- Criar um servidor MCP com ferramentas de calculadora.
- Ligar o Agent Builder ao servidor MCP.
- Testar a invocação das ferramentas do agente via linguagem natural.

Ótimo, agora que entendemos o fluxo, vamos configurar um agente de IA para tirar partido de ferramentas externas através do MCP, aumentando as suas capacidades!

## Pré-requisitos

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit para Visual Studio Code](https://aka.ms/AIToolkit)

## Exercício: Consumir um servidor

Neste exercício, irá construir, executar e melhorar um agente de IA com ferramentas de um servidor MCP dentro do Visual Studio Code usando o AI Toolkit.

### -0- Passo prévio, adicionar o modelo OpenAI GPT-4o a My Models

O exercício utiliza o modelo **GPT-4o**. O modelo deve ser adicionado a **My Models** antes de criar o agente.

![Screenshot da interface de seleção de modelo na extensão AI Toolkit do Visual Studio Code. O título diz "Find the right model for your AI Solution" com um subtítulo a incentivar os utilizadores a descobrir, testar e implementar modelos de IA. Abaixo, em “Popular Models,” são exibidos seis cartões de modelo: DeepSeek-R1 (hospedado no GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Pequeno, Rápido), e DeepSeek-R1 (hospedado no Ollama). Cada cartão inclui opções para “Add” o modelo ou “Try in Playground](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.pt.png)

1. Abra a extensão **AI Toolkit** a partir da **Activity Bar**.
1. Na secção **Catalog**, selecione **Models** para abrir o **Model Catalog**. Selecionar **Models** abre o **Model Catalog** numa nova aba do editor.
1. Na barra de pesquisa do **Model Catalog**, escreva **OpenAI GPT-4o**.
1. Clique em **+ Add** para adicionar o modelo à sua lista **My Models**. Certifique-se de que selecionou o modelo que está **Hospedado no GitHub**.
1. Na **Activity Bar**, confirme que o modelo **OpenAI GPT-4o** aparece na lista.

### -1- Criar um agente

O **Agent (Prompt) Builder** permite criar e personalizar os seus próprios agentes alimentados por IA. Nesta secção, irá criar um novo agente e atribuir um modelo para alimentar a conversa.

![Screenshot da interface do "Calculator Agent" no AI Toolkit para Visual Studio Code. No painel esquerdo, o modelo selecionado é "OpenAI GPT-4o (via GitHub)." Um prompt de sistema diz "You are a professor in university teaching math," e o prompt do utilizador diz, "Explain to me the Fourier equation in simple terms." Opções adicionais incluem botões para adicionar ferramentas, ativar MCP Server e selecionar output estruturado. Um botão azul “Run” está na parte inferior. No painel direito, em "Get Started with Examples," estão listados três agentes de exemplo: Web Developer (com MCP Server, Second-Grade Simplifier, e Dream Interpreter, cada um com breves descrições das suas funções.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.pt.png)

1. Abra a extensão **AI Toolkit** a partir da **Activity Bar**.
1. Na secção **Tools**, selecione **Agent (Prompt) Builder**. Selecionar **Agent (Prompt) Builder** abre o **Agent (Prompt) Builder** numa nova aba do editor.
1. Clique no botão **+ New Agent**. A extensão irá iniciar um assistente de configuração via **Command Palette**.
1. Introduza o nome **Calculator Agent** e pressione **Enter**.
1. No **Agent (Prompt) Builder**, no campo **Model**, selecione o modelo **OpenAI GPT-4o (via GitHub)**.

### -2- Criar um prompt de sistema para o agente

Com o agente criado, é hora de definir a sua personalidade e propósito. Nesta secção, irá usar a funcionalidade **Generate system prompt** para descrever o comportamento pretendido do agente — neste caso, um agente calculadora — e deixar que o modelo escreva o prompt de sistema por si.

![Screenshot da interface do "Calculator Agent" no AI Toolkit para Visual Studio Code com uma janela modal aberta intitulada "Generate a prompt." A modal explica que um template de prompt pode ser gerado ao partilhar detalhes básicos e inclui uma caixa de texto com o prompt de sistema de exemplo: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Abaixo da caixa de texto estão os botões "Close" e "Generate". Ao fundo, parte da configuração do agente está visível, incluindo o modelo selecionado "OpenAI GPT-4o (via GitHub)" e campos para prompts de sistema e utilizador.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.pt.png)

1. Na secção **Prompts**, clique no botão **Generate system prompt**. Este botão abre o construtor de prompts que usa IA para gerar um prompt de sistema para o agente.
1. Na janela **Generate a prompt**, escreva o seguinte: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Clique no botão **Generate**. Aparecerá uma notificação no canto inferior direito a confirmar que o prompt de sistema está a ser gerado. Quando a geração estiver concluída, o prompt aparecerá no campo **System prompt** do **Agent (Prompt) Builder**.
1. Reveja o **System prompt** e modifique se necessário.

### -3- Criar um servidor MCP

Agora que definiu o prompt de sistema do seu agente — orientando o seu comportamento e respostas — é hora de equipar o agente com capacidades práticas. Nesta secção, irá criar um servidor MCP de calculadora com ferramentas para executar cálculos de adição, subtração, multiplicação e divisão. Este servidor permitirá que o seu agente realize operações matemáticas em tempo real em resposta a prompts em linguagem natural.

!["Screenshot da secção inferior da interface do Calculator Agent na extensão AI Toolkit para Visual Studio Code. Mostra menus expansíveis para “Tools” e “Structure output,” juntamente com um menu dropdown rotulado “Choose output format” definido para “text.” À direita, há um botão rotulado “+ MCP Server” para adicionar um servidor Model Context Protocol. Um ícone de imagem está acima da secção Tools.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.pt.png)

O AI Toolkit está equipado com templates para facilitar a criação do seu próprio servidor MCP. Vamos usar o template Python para criar o servidor MCP de calculadora.

*Nota*: O AI Toolkit suporta atualmente Python e TypeScript.

1. Na secção **Tools** do **Agent (Prompt) Builder**, clique no botão **+ MCP Server**. A extensão irá iniciar um assistente de configuração via **Command Palette**.
1. Selecione **+ Add Server**.
1. Selecione **Create a New MCP Server**.
1. Selecione **python-weather** como template.
1. Selecione **Default folder** para guardar o template do servidor MCP.
1. Introduza o seguinte nome para o servidor: **Calculator**
1. Abrir-se-á uma nova janela do Visual Studio Code. Selecione **Yes, I trust the authors**.
1. Usando o terminal (**Terminal** > **New Terminal**), crie um ambiente virtual: `python -m venv .venv`
1. No terminal, ative o ambiente virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. No terminal, instale as dependências: `pip install -e .[dev]`
1. Na vista **Explorer** da **Activity Bar**, expanda o diretório **src** e selecione **server.py** para abrir o ficheiro no editor.
1. Substitua o código no ficheiro **server.py** pelo seguinte e guarde:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- Executar o agente com o servidor MCP de calculadora

Agora que o seu agente tem ferramentas, é hora de as usar! Nesta secção, irá submeter prompts ao agente para testar e validar se o agente utiliza a ferramenta apropriada do servidor MCP de calculadora.

![Screenshot da interface do Calculator Agent na extensão AI Toolkit para Visual Studio Code. No painel esquerdo, em “Tools,” um servidor MCP chamado local-server-calculator_server está adicionado, mostrando quatro ferramentas disponíveis: add, subtract, multiply, e divide. Um distintivo mostra que quatro ferramentas estão ativas. Abaixo está uma secção “Structure output” recolhida e um botão azul “Run.” No painel direito, em “Model Response,” o agente invoca as ferramentas multiply e subtract com inputs {"a": 3, "b": 25} e {"a": 75, "b": 20} respetivamente. A “Tool Response” final é mostrada como 75.0. Um botão “View Code” aparece na parte inferior.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.pt.png)

Irá executar o servidor MCP de calculadora na sua máquina local de desenvolvimento via o **Agent Builder** como cliente MCP.

1. Pressione `F5` para iniciar a depuração do servidor MCP. O **Agent (Prompt) Builder** abrir-se-á numa nova aba do editor. O estado do servidor é visível no terminal.
1. No campo **User prompt** do **Agent (Prompt) Builder**, introduza o seguinte prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Clique no botão **Run** para gerar a resposta do agente.
1. Reveja a saída do agente. O modelo deverá concluir que pagou **$55**.
1. Aqui está uma explicação do que deverá acontecer:
    - O agente seleciona as ferramentas **multiply** e **subtract** para ajudar no cálculo.
    - Os valores `a` e `b` são atribuídos respetivamente para a ferramenta **multiply**.
    - Os valores `a` e `b` são atribuídos respetivamente para a ferramenta **subtract**.
    - A resposta de cada ferramenta é fornecida na respetiva **Tool Response**.
    - A saída final do modelo é apresentada na **Model Response** final.
1. Submeta prompts adicionais para testar mais o agente. Pode modificar o prompt existente no campo **User prompt** clicando no campo e substituindo o prompt atual.
1. Quando terminar de testar o agente, pode parar o servidor via o **terminal** pressionando **CTRL/CMD+C** para sair.

## Tarefa

Tente adicionar uma entrada de ferramenta adicional ao seu ficheiro **server.py** (ex: retornar a raiz quadrada de um número). Submeta prompts adicionais que exijam que o agente utilize a sua nova ferramenta (ou ferramentas existentes). Certifique-se de reiniciar o servidor para carregar as ferramentas adicionadas.

## Solução

[Solution](./solution/README.md)

## Principais conclusões

As principais conclusões deste capítulo são as seguintes:

- A extensão AI Toolkit é um excelente cliente que permite consumir servidores MCP e as suas ferramentas.
- Pode adicionar novas ferramentas a servidores MCP, expandindo as capacidades do agente para responder a requisitos em evolução.
- O AI Toolkit inclui templates (ex: templates de servidor MCP em Python) para simplificar a criação de ferramentas personalizadas.

## Recursos adicionais

- [Documentação do AI Toolkit](https://aka.ms/AIToolkit/doc)

## O que vem a seguir
- Seguinte: [Testes e Depuração](../08-testing/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos por garantir a precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações erradas decorrentes da utilização desta tradução.