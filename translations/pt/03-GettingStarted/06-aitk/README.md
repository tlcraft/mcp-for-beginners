<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:35:23+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "pt"
}
-->
# Consumindo um servidor da extensão AI Toolkit para Visual Studio Code

Quando você está construindo um agente de IA, não se trata apenas de gerar respostas inteligentes; é também sobre dar ao seu agente a capacidade de agir. É aí que entra o Model Context Protocol (MCP). O MCP facilita o acesso dos agentes a ferramentas e serviços externos de maneira consistente. Pense nisso como conectar seu agente a uma caixa de ferramentas que ele pode *realmente* usar.

Vamos supor que você conecte um agente ao seu servidor MCP de calculadora. De repente, seu agente pode realizar operações matemáticas apenas recebendo um comando como “Quanto é 47 vezes 89?” — sem precisar codificar a lógica ou criar APIs personalizadas.

## Visão Geral

Esta lição explica como conectar um servidor MCP de calculadora a um agente com a extensão [AI Toolkit](https://aka.ms/AIToolkit) no Visual Studio Code, permitindo que seu agente execute operações matemáticas como adição, subtração, multiplicação e divisão por meio de linguagem natural.

O AI Toolkit é uma extensão poderosa para o Visual Studio Code que simplifica o desenvolvimento de agentes. Engenheiros de IA podem facilmente construir aplicações de IA desenvolvendo e testando modelos generativos de IA — localmente ou na nuvem. A extensão suporta a maioria dos principais modelos generativos disponíveis hoje.

*Nota*: Atualmente, o AI Toolkit suporta Python e TypeScript.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Consumir um servidor MCP via AI Toolkit.
- Configurar uma configuração de agente para habilitar a descoberta e utilização das ferramentas fornecidas pelo servidor MCP.
- Utilizar ferramentas MCP via linguagem natural.

## Abordagem

Aqui está como devemos abordar isso em alto nível:

- Criar um agente e definir seu prompt de sistema.
- Criar um servidor MCP com ferramentas de calculadora.
- Conectar o Agent Builder ao servidor MCP.
- Testar a invocação das ferramentas do agente via linguagem natural.

Ótimo, agora que entendemos o fluxo, vamos configurar um agente de IA para aproveitar ferramentas externas através do MCP, ampliando suas capacidades!

## Pré-requisitos

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit para Visual Studio Code](https://aka.ms/AIToolkit)

## Exercício: Consumindo um servidor

Neste exercício, você irá construir, executar e aprimorar um agente de IA com ferramentas de um servidor MCP dentro do Visual Studio Code usando o AI Toolkit.

### -0- Passo prévio, adicione o modelo OpenAI GPT-4o aos Meus Modelos

O exercício utiliza o modelo **GPT-4o**. O modelo deve ser adicionado aos **Meus Modelos** antes de criar o agente.

![Screenshot da interface de seleção de modelo na extensão AI Toolkit do Visual Studio Code. O título diz "Find the right model for your AI Solution" com um subtítulo incentivando a descobrir, testar e implantar modelos de IA. Abaixo, em “Popular Models,” seis cards de modelos são exibidos: DeepSeek-R1 (hospedado no GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Pequeno, Rápido), e DeepSeek-R1 (hospedado no Ollama). Cada card inclui opções para “Add” o modelo ou “Try in Playground](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.pt.png)

1. Abra a extensão **AI Toolkit** na **Barra de Atividades**.
1. Na seção **Catalog**, selecione **Models** para abrir o **Model Catalog**. Selecionar **Models** abre o **Model Catalog** em uma nova aba do editor.
1. Na barra de busca do **Model Catalog**, digite **OpenAI GPT-4o**.
1. Clique em **+ Add** para adicionar o modelo à sua lista **Meus Modelos**. Certifique-se de selecionar o modelo que está **Hospedado pelo GitHub**.
1. Na **Barra de Atividades**, confirme que o modelo **OpenAI GPT-4o** aparece na lista.

### -1- Crie um agente

O **Agent (Prompt) Builder** permite criar e personalizar seus próprios agentes alimentados por IA. Nesta seção, você criará um novo agente e atribuirá um modelo para conduzir a conversa.

![Screenshot da interface do "Calculator Agent" no AI Toolkit para Visual Studio Code. No painel esquerdo, o modelo selecionado é "OpenAI GPT-4o (via GitHub)." Um prompt de sistema diz "You are a professor in university teaching math," e o prompt do usuário diz, "Explain to me the Fourier equation in simple terms." Opções adicionais incluem botões para adicionar ferramentas, habilitar MCP Server e selecionar saída estruturada. Um botão azul “Run” está na parte inferior. No painel direito, em "Get Started with Examples," três agentes de exemplo são listados: Web Developer (com MCP Server, Simplificador de Segunda Série e Intérprete de Sonhos, cada um com descrições breves de suas funções.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.pt.png)

1. Abra a extensão **AI Toolkit** na **Barra de Atividades**.
1. Na seção **Tools**, selecione **Agent (Prompt) Builder**. Selecionar **Agent (Prompt) Builder** abre o construtor em uma nova aba do editor.
1. Clique no botão **+ New Agent**. A extensão iniciará um assistente via **Command Palette**.
1. Digite o nome **Calculator Agent** e pressione **Enter**.
1. No **Agent (Prompt) Builder**, no campo **Model**, selecione o modelo **OpenAI GPT-4o (via GitHub)**.

### -2- Crie um prompt de sistema para o agente

Com o agente criado, é hora de definir sua personalidade e propósito. Nesta seção, você usará o recurso **Generate system prompt** para descrever o comportamento esperado do agente — neste caso, um agente calculadora — e deixar o modelo escrever o prompt do sistema para você.

![Screenshot da interface do "Calculator Agent" no AI Toolkit para Visual Studio Code com uma janela modal aberta intitulada "Generate a prompt." A modal explica que um template de prompt pode ser gerado compartilhando detalhes básicos e inclui uma caixa de texto com o prompt de sistema de exemplo: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Abaixo da caixa de texto há os botões "Close" e "Generate." Ao fundo, parte da configuração do agente está visível, incluindo o modelo selecionado "OpenAI GPT-4o (via GitHub)" e campos para prompts de sistema e usuário.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.pt.png)

1. Na seção **Prompts**, clique no botão **Generate system prompt**. Esse botão abre o construtor de prompts que usa IA para gerar um prompt de sistema para o agente.
1. Na janela **Generate a prompt**, insira o seguinte: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Clique no botão **Generate**. Uma notificação aparecerá no canto inferior direito confirmando que o prompt do sistema está sendo gerado. Quando a geração for concluída, o prompt aparecerá no campo **System prompt** do **Agent (Prompt) Builder**.
1. Revise o **System prompt** e modifique se necessário.

### -3- Crie um servidor MCP

Agora que você definiu o prompt do sistema do seu agente — que orienta seu comportamento e respostas — é hora de equipá-lo com capacidades práticas. Nesta seção, você criará um servidor MCP de calculadora com ferramentas para executar cálculos de adição, subtração, multiplicação e divisão. Esse servidor permitirá que seu agente realize operações matemáticas em tempo real em resposta a comandos em linguagem natural.

!["Screenshot da seção inferior da interface do Calculator Agent no AI Toolkit para Visual Studio Code. Mostra menus expansíveis para “Tools” e “Structure output,” junto com um menu suspenso rotulado “Choose output format” configurado para “text.” À direita, há um botão rotulado “+ MCP Server” para adicionar um servidor Model Context Protocol. Um ícone de imagem está acima da seção Tools.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.pt.png)

O AI Toolkit vem com templates para facilitar a criação do seu próprio servidor MCP. Usaremos o template Python para criar o servidor MCP de calculadora.

*Nota*: Atualmente, o AI Toolkit suporta Python e TypeScript.

1. Na seção **Tools** do **Agent (Prompt) Builder**, clique no botão **+ MCP Server**. A extensão iniciará um assistente via **Command Palette**.
1. Selecione **+ Add Server**.
1. Selecione **Create a New MCP Server**.
1. Selecione o template **python-weather**.
1. Selecione **Default folder** para salvar o template do servidor MCP.
1. Digite o seguinte nome para o servidor: **Calculator**
1. Uma nova janela do Visual Studio Code será aberta. Selecione **Yes, I trust the authors**.
1. Usando o terminal (**Terminal** > **New Terminal**), crie um ambiente virtual: `python -m venv .venv`
1. No terminal, ative o ambiente virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. No terminal, instale as dependências: `pip install -e .[dev]`
1. Na visualização **Explorer** da **Barra de Atividades**, expanda o diretório **src** e selecione o arquivo **server.py** para abri-lo no editor.
1. Substitua o código no arquivo **server.py** pelo seguinte e salve:

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

### -4- Execute o agente com o servidor MCP de calculadora

Agora que seu agente tem ferramentas, é hora de usá-las! Nesta seção, você enviará comandos para o agente para testar e validar se ele utiliza a ferramenta correta do servidor MCP de calculadora.

![Screenshot da interface do Calculator Agent na extensão AI Toolkit para Visual Studio Code. No painel esquerdo, sob “Tools,” um servidor MCP chamado local-server-calculator_server foi adicionado, mostrando quatro ferramentas disponíveis: add, subtract, multiply e divide. Um badge mostra que quatro ferramentas estão ativas. Abaixo está a seção “Structure output” recolhida e um botão azul “Run.” No painel direito, em “Model Response,” o agente invoca as ferramentas multiply e subtract com entradas {"a": 3, "b": 25} e {"a": 75, "b": 20} respectivamente. A “Tool Response” final é mostrada como 75.0. Um botão “View Code” aparece na parte inferior.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.pt.png)

Você executará o servidor MCP de calculadora na sua máquina local via o **Agent Builder** como cliente MCP.

1. Pressione `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` valores são atribuídos para a ferramenta **subtract**.
    - A resposta de cada ferramenta é exibida na respectiva **Tool Response**.
    - A saída final do modelo é exibida na **Model Response** final.
1. Envie prompts adicionais para testar mais o agente. Você pode modificar o prompt existente no campo **User prompt** clicando nele e substituindo o texto.
1. Quando terminar de testar o agente, você pode parar o servidor via **terminal** pressionando **CTRL/CMD+C** para sair.

## Tarefa

Tente adicionar uma entrada de ferramenta adicional ao seu arquivo **server.py** (ex: retornar a raiz quadrada de um número). Envie prompts adicionais que exijam que o agente utilize sua nova ferramenta (ou ferramentas existentes). Lembre-se de reiniciar o servidor para carregar as ferramentas adicionadas.

## Solução

[Solution](./solution/README.md)

## Principais Lições

As lições principais deste capítulo são as seguintes:

- A extensão AI Toolkit é um ótimo cliente que permite consumir servidores MCP e suas ferramentas.
- Você pode adicionar novas ferramentas a servidores MCP, ampliando as capacidades do agente para atender a requisitos em evolução.
- O AI Toolkit inclui templates (ex: templates de servidores MCP em Python) para simplificar a criação de ferramentas personalizadas.

## Recursos Adicionais

- [Documentação do AI Toolkit](https://aka.ms/AIToolkit/doc)

## Próximos Passos

Próximo: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, por favor, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.