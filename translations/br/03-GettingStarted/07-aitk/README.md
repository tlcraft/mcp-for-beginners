<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:18:39+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "br"
}
-->
# Consumindo um servidor da extensão AI Toolkit para Visual Studio Code

Quando você está criando um agente de IA, não se trata apenas de gerar respostas inteligentes; é também sobre dar ao seu agente a capacidade de agir. É aí que entra o Model Context Protocol (MCP). O MCP facilita o acesso dos agentes a ferramentas e serviços externos de forma consistente. Pense nisso como conectar seu agente a uma caixa de ferramentas que ele *realmente* pode usar.

Suponha que você conecte um agente ao seu servidor MCP de calculadora. De repente, seu agente pode realizar operações matemáticas apenas recebendo um comando como “Quanto é 47 vezes 89?” — sem necessidade de lógica codificada manualmente ou APIs personalizadas.

## Visão geral

Esta lição mostra como conectar um servidor MCP de calculadora a um agente com a extensão [AI Toolkit](https://aka.ms/AIToolkit) no Visual Studio Code, permitindo que seu agente execute operações matemáticas como adição, subtração, multiplicação e divisão por meio de linguagem natural.

O AI Toolkit é uma extensão poderosa para Visual Studio Code que simplifica o desenvolvimento de agentes. Engenheiros de IA podem criar e testar modelos generativos de IA facilmente — localmente ou na nuvem. A extensão suporta a maioria dos principais modelos generativos disponíveis hoje.

*Nota*: O AI Toolkit atualmente suporta Python e TypeScript.

## Objetivos de aprendizagem

Ao final desta lição, você será capaz de:

- Consumir um servidor MCP via AI Toolkit.
- Configurar a configuração de um agente para que ele descubra e utilize ferramentas fornecidas pelo servidor MCP.
- Utilizar ferramentas MCP por meio de linguagem natural.

## Abordagem

Aqui está como devemos proceder em alto nível:

- Criar um agente e definir seu prompt do sistema.
- Criar um servidor MCP com ferramentas de calculadora.
- Conectar o Agent Builder ao servidor MCP.
- Testar a invocação das ferramentas do agente via linguagem natural.

Ótimo, agora que entendemos o fluxo, vamos configurar um agente de IA para aproveitar ferramentas externas via MCP, ampliando suas capacidades!

## Pré-requisitos

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit para Visual Studio Code](https://aka.ms/AIToolkit)

## Exercício: Consumindo um servidor

Neste exercício, você vai construir, executar e aprimorar um agente de IA com ferramentas de um servidor MCP dentro do Visual Studio Code usando o AI Toolkit.

### -0- Passo inicial, adicione o modelo OpenAI GPT-4o aos Meus Modelos

O exercício utiliza o modelo **GPT-4o**. O modelo deve ser adicionado aos **Meus Modelos** antes de criar o agente.

![Screenshot da interface de seleção de modelos na extensão AI Toolkit do Visual Studio Code. O título diz "Find the right model for your AI Solution" com um subtítulo incentivando a descoberta, teste e implantação de modelos de IA. Abaixo, na seção “Popular Models,” são exibidos seis cards de modelo: DeepSeek-R1 (hospedado no GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Pequeno, Rápido) e DeepSeek-R1 (hospedado no Ollama). Cada card inclui opções para “Add” o modelo ou “Try in Playground](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.br.png)

1. Abra a extensão **AI Toolkit** na **Activity Bar**.
1. Na seção **Catalog**, selecione **Models** para abrir o **Model Catalog**. Selecionar **Models** abre o **Model Catalog** em uma nova aba do editor.
1. Na barra de busca do **Model Catalog**, digite **OpenAI GPT-4o**.
1. Clique em **+ Add** para adicionar o modelo à sua lista de **Meus Modelos**. Certifique-se de ter selecionado o modelo **Hosted by GitHub**.
1. Na **Activity Bar**, confirme que o modelo **OpenAI GPT-4o** aparece na lista.

### -1- Criar um agente

O **Agent (Prompt) Builder** permite criar e personalizar seus próprios agentes alimentados por IA. Nesta seção, você criará um novo agente e atribuirá um modelo para conduzir a conversa.

![Screenshot da interface do "Calculator Agent" no AI Toolkit para Visual Studio Code. No painel esquerdo, o modelo selecionado é "OpenAI GPT-4o (via GitHub)." Um prompt do sistema diz "You are a professor in university teaching math," e o prompt do usuário é "Explain to me the Fourier equation in simple terms." Opções adicionais incluem botões para adicionar ferramentas, habilitar MCP Server e selecionar saída estruturada. Um botão azul “Run” está na parte inferior. No painel direito, em "Get Started with Examples," três agentes de exemplo são listados: Web Developer (com MCP Server, Simplificador de 2ª série e Interpretador de Sonhos, cada um com breves descrições de suas funções.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.br.png)

1. Abra a extensão **AI Toolkit** na **Activity Bar**.
1. Na seção **Tools**, selecione **Agent (Prompt) Builder**. Selecionar **Agent (Prompt) Builder** abre o construtor em uma nova aba do editor.
1. Clique no botão **+ New Agent**. A extensão abrirá um assistente via **Command Palette**.
1. Digite o nome **Calculator Agent** e pressione **Enter**.
1. No **Agent (Prompt) Builder**, no campo **Model**, selecione o modelo **OpenAI GPT-4o (via GitHub)**.

### -2- Criar um prompt do sistema para o agente

Com o agente criado, é hora de definir sua personalidade e propósito. Nesta seção, você usará o recurso **Generate system prompt** para descrever o comportamento esperado do agente — neste caso, um agente calculadora — e deixar o modelo gerar o prompt do sistema para você.

![Screenshot da interface do "Calculator Agent" no AI Toolkit para Visual Studio Code com uma janela modal aberta intitulada "Generate a prompt." A modal explica que um template de prompt pode ser gerado compartilhando detalhes básicos e inclui uma caixa de texto com o prompt de sistema exemplo: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Abaixo da caixa de texto há botões "Close" e "Generate". Ao fundo, parte da configuração do agente é visível, incluindo o modelo selecionado "OpenAI GPT-4o (via GitHub)" e campos para prompts do sistema e do usuário.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.br.png)

1. Na seção **Prompts**, clique no botão **Generate system prompt**. Esse botão abre o construtor de prompt que usa IA para gerar um prompt do sistema para o agente.
1. Na janela **Generate a prompt**, insira o seguinte: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Clique no botão **Generate**. Uma notificação aparecerá no canto inferior direito confirmando que o prompt do sistema está sendo gerado. Quando a geração for concluída, o prompt aparecerá no campo **System prompt** do **Agent (Prompt) Builder**.
1. Revise o **System prompt** e modifique se necessário.

### -3- Criar um servidor MCP

Agora que você definiu o prompt do sistema do seu agente — guiando seu comportamento e respostas — é hora de equipar o agente com capacidades práticas. Nesta seção, você criará um servidor MCP de calculadora com ferramentas para executar cálculos de adição, subtração, multiplicação e divisão. Esse servidor permitirá que seu agente realize operações matemáticas em tempo real em resposta a comandos em linguagem natural.

!["Screenshot da seção inferior da interface do Calculator Agent na extensão AI Toolkit para Visual Studio Code. Mostra menus expansíveis para “Tools” e “Structure output,” junto com um menu suspenso “Choose output format” definido como “text.” À direita, há um botão “+ MCP Server” para adicionar um servidor Model Context Protocol. Um ícone de imagem é mostrado acima da seção Tools.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.br.png)

O AI Toolkit vem com templates para facilitar a criação do seu próprio servidor MCP. Usaremos o template Python para criar o servidor MCP de calculadora.

*Nota*: O AI Toolkit atualmente suporta Python e TypeScript.

1. Na seção **Tools** do **Agent (Prompt) Builder**, clique no botão **+ MCP Server**. A extensão abrirá um assistente via **Command Palette**.
1. Selecione **+ Add Server**.
1. Selecione **Create a New MCP Server**.
1. Selecione **python-weather** como template.
1. Selecione **Default folder** para salvar o template do servidor MCP.
1. Insira o seguinte nome para o servidor: **Calculator**
1. Uma nova janela do Visual Studio Code será aberta. Selecione **Yes, I trust the authors**.
1. Usando o terminal (**Terminal** > **New Terminal**), crie um ambiente virtual: `python -m venv .venv`
1. No terminal, ative o ambiente virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. No terminal, instale as dependências: `pip install -e .[dev]`
1. Na visualização **Explorer** da **Activity Bar**, expanda o diretório **src** e selecione o arquivo **server.py** para abrir no editor.
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

Agora que seu agente tem ferramentas, é hora de usá-las! Nesta seção, você enviará comandos para o agente testar e validar se ele utiliza a ferramenta adequada do servidor MCP de calculadora.

![Screenshot da interface do Calculator Agent na extensão AI Toolkit para Visual Studio Code. No painel esquerdo, em “Tools,” um servidor MCP chamado local-server-calculator_server está adicionado, mostrando quatro ferramentas disponíveis: add, subtract, multiply e divide. Um badge indica que quatro ferramentas estão ativas. Abaixo há uma seção “Structure output” recolhida e um botão azul “Run.” No painel direito, em “Model Response,” o agente invoca as ferramentas multiply e subtract com entradas {"a": 3, "b": 25} e {"a": 75, "b": 20}, respectivamente. A “Tool Response” final é mostrada como 75.0. Um botão “View Code” aparece na parte inferior.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.br.png)

Você vai rodar o servidor MCP de calculadora na sua máquina local como cliente MCP via **Agent Builder**.

1. Pressione `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` valores são atribuídos para a ferramenta **subtract**.
    - A resposta de cada ferramenta é mostrada na respectiva **Tool Response**.
    - O resultado final do modelo aparece na **Model Response** final.
1. Envie comandos adicionais para testar mais o agente. Você pode modificar o prompt existente no campo **User prompt** clicando nele e substituindo o texto.
1. Quando terminar de testar, você pode parar o servidor pelo **terminal** pressionando **CTRL/CMD+C** para encerrar.

## Tarefa

Tente adicionar uma nova entrada de ferramenta no seu arquivo **server.py** (ex: retornar a raiz quadrada de um número). Envie comandos adicionais que exijam que o agente utilize sua nova ferramenta (ou as ferramentas existentes). Não esqueça de reiniciar o servidor para carregar as ferramentas adicionadas.

## Solução

[Solution](./solution/README.md)

## Principais aprendizados

Os principais aprendizados deste capítulo são:

- A extensão AI Toolkit é um ótimo cliente que permite consumir servidores MCP e suas ferramentas.
- Você pode adicionar novas ferramentas a servidores MCP, ampliando as capacidades do agente para atender a requisitos em evolução.
- O AI Toolkit inclui templates (ex: templates Python para servidores MCP) que simplificam a criação de ferramentas personalizadas.

## Recursos adicionais

- [Documentação do AI Toolkit](https://aka.ms/AIToolkit/doc)

## Próximos passos
- Próximo: [Testes & Depuração](/03-GettingStarted/08-testing/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.