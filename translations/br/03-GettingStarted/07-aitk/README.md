<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:32:30+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "br"
}
-->
# Consumindo um servidor da extensão AI Toolkit para Visual Studio Code

Quando você está construindo um agente de IA, não se trata apenas de gerar respostas inteligentes; é também sobre dar ao seu agente a capacidade de agir. É aí que entra o Model Context Protocol (MCP). O MCP facilita o acesso dos agentes a ferramentas e serviços externos de forma consistente. Pense nisso como conectar seu agente a uma caixa de ferramentas que ele pode *realmente* usar.

Suponha que você conecte um agente ao seu servidor MCP de calculadora. De repente, seu agente pode realizar operações matemáticas apenas recebendo um comando como “Quanto é 47 vezes 89?” — sem precisar codificar a lógica ou criar APIs personalizadas.

## Visão geral

Esta lição aborda como conectar um servidor MCP de calculadora a um agente com a extensão [AI Toolkit](https://aka.ms/AIToolkit) no Visual Studio Code, permitindo que seu agente realize operações matemáticas como adição, subtração, multiplicação e divisão por meio de linguagem natural.

O AI Toolkit é uma extensão poderosa para Visual Studio Code que simplifica o desenvolvimento de agentes. Engenheiros de IA podem facilmente construir aplicações de IA desenvolvendo e testando modelos generativos de IA — localmente ou na nuvem. A extensão suporta a maioria dos principais modelos generativos disponíveis atualmente.

*Nota*: O AI Toolkit atualmente suporta Python e TypeScript.

## Objetivos de aprendizagem

Ao final desta lição, você será capaz de:

- Consumir um servidor MCP via AI Toolkit.
- Configurar uma configuração de agente para permitir que ele descubra e utilize ferramentas fornecidas pelo servidor MCP.
- Utilizar ferramentas MCP por meio de linguagem natural.

## Abordagem

Aqui está como devemos abordar isso em um nível geral:

- Criar um agente e definir seu prompt de sistema.
- Criar um servidor MCP com ferramentas de calculadora.
- Conectar o Agent Builder ao servidor MCP.
- Testar a invocação das ferramentas do agente via linguagem natural.

Ótimo, agora que entendemos o fluxo, vamos configurar um agente de IA para aproveitar ferramentas externas através do MCP, ampliando suas capacidades!

## Pré-requisitos

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit para Visual Studio Code](https://aka.ms/AIToolkit)

## Exercício: Consumindo um servidor

Neste exercício, você vai construir, executar e aprimorar um agente de IA com ferramentas de um servidor MCP dentro do Visual Studio Code usando o AI Toolkit.

### -0- Passo prévio, adicione o modelo OpenAI GPT-4o em Meus Modelos

O exercício utiliza o modelo **GPT-4o**. O modelo deve ser adicionado em **Meus Modelos** antes de criar o agente.

![Screenshot da interface de seleção de modelo na extensão AI Toolkit do Visual Studio Code. O título diz "Encontre o modelo certo para sua solução de IA" com um subtítulo incentivando os usuários a descobrir, testar e implantar modelos de IA. Abaixo, em “Modelos Populares,” seis cards de modelos são exibidos: DeepSeek-R1 (hospedado no GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Pequeno, Rápido) e DeepSeek-R1 (hospedado no Ollama). Cada card inclui opções para “Adicionar” o modelo ou “Testar no Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.br.png)

1. Abra a extensão **AI Toolkit** na **Barra de Atividades**.
1. Na seção **Catálogo**, selecione **Modelos** para abrir o **Catálogo de Modelos**. Selecionar **Modelos** abre o **Catálogo de Modelos** em uma nova aba do editor.
1. Na barra de busca do **Catálogo de Modelos**, digite **OpenAI GPT-4o**.
1. Clique em **+ Adicionar** para incluir o modelo na sua lista **Meus Modelos**. Certifique-se de que selecionou o modelo que está **Hospedado pelo GitHub**.
1. Na **Barra de Atividades**, confirme que o modelo **OpenAI GPT-4o** aparece na lista.

### -1- Criar um agente

O **Agent (Prompt) Builder** permite criar e personalizar seus próprios agentes movidos a IA. Nesta seção, você criará um novo agente e atribuirá um modelo para conduzir a conversa.

![Screenshot da interface do construtor "Calculator Agent" na extensão AI Toolkit para Visual Studio Code. No painel esquerdo, o modelo selecionado é "OpenAI GPT-4o (via GitHub)." Um prompt de sistema diz "Você é um professor universitário que ensina matemática," e o prompt do usuário diz, "Explique para mim a equação de Fourier em termos simples." Opções adicionais incluem botões para adicionar ferramentas, ativar MCP Server e selecionar saída estruturada. Um botão azul “Executar” está na parte inferior. No painel direito, em "Comece com Exemplos," três agentes de exemplo são listados: Desenvolvedor Web (com MCP Server, Simplificador de Segunda Série e Intérprete de Sonhos, cada um com breves descrições de suas funções).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.br.png)

1. Abra a extensão **AI Toolkit** na **Barra de Atividades**.
1. Na seção **Ferramentas**, selecione **Agent (Prompt) Builder**. Selecionar **Agent (Prompt) Builder** abre o construtor em uma nova aba do editor.
1. Clique no botão **+ Novo Agente**. A extensão iniciará um assistente de configuração via **Command Palette**.
1. Digite o nome **Calculator Agent** e pressione **Enter**.
1. No **Agent (Prompt) Builder**, no campo **Model**, selecione o modelo **OpenAI GPT-4o (via GitHub)**.

### -2- Criar um prompt de sistema para o agente

Com o agente criado, é hora de definir sua personalidade e propósito. Nesta seção, você usará o recurso **Gerar prompt de sistema** para descrever o comportamento pretendido do agente — neste caso, um agente calculadora — e deixar o modelo escrever o prompt de sistema para você.

![Screenshot da interface "Calculator Agent" no AI Toolkit para Visual Studio Code com uma janela modal aberta intitulada "Gerar um prompt." A modal explica que um template de prompt pode ser gerado compartilhando detalhes básicos e inclui uma caixa de texto com o prompt de sistema de exemplo: "Você é um assistente de matemática útil e eficiente. Quando receber um problema envolvendo aritmética básica, responda com o resultado correto." Abaixo da caixa de texto estão os botões "Fechar" e "Gerar". Ao fundo, parte da configuração do agente está visível, incluindo o modelo selecionado "OpenAI GPT-4o (via GitHub)" e campos para prompts de sistema e usuário.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.br.png)

1. Na seção **Prompts**, clique no botão **Gerar prompt de sistema**. Esse botão abre o construtor de prompt que usa IA para gerar um prompt de sistema para o agente.
1. Na janela **Gerar um prompt**, digite o seguinte: `Você é um assistente de matemática útil e eficiente. Quando receber um problema envolvendo aritmética básica, responda com o resultado correto.`
1. Clique no botão **Gerar**. Uma notificação aparecerá no canto inferior direito confirmando que o prompt de sistema está sendo gerado. Quando a geração for concluída, o prompt aparecerá no campo **Prompt de sistema** do **Agent (Prompt) Builder**.
1. Revise o **Prompt de sistema** e modifique se necessário.

### -3- Criar um servidor MCP

Agora que você definiu o prompt de sistema do seu agente — orientando seu comportamento e respostas — é hora de equipar o agente com capacidades práticas. Nesta seção, você criará um servidor MCP de calculadora com ferramentas para executar cálculos de adição, subtração, multiplicação e divisão. Esse servidor permitirá que seu agente realize operações matemáticas em tempo real em resposta a comandos em linguagem natural.

![Screenshot da seção inferior da interface do Calculator Agent na extensão AI Toolkit para Visual Studio Code. Mostra menus expansíveis para “Ferramentas” e “Saída estruturada,” junto com um menu suspenso rotulado “Escolher formato de saída” definido como “texto.” À direita, há um botão rotulado “+ MCP Server” para adicionar um servidor Model Context Protocol. Um ícone de imagem está acima da seção Ferramentas.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.br.png)

O AI Toolkit vem equipado com templates para facilitar a criação do seu próprio servidor MCP. Usaremos o template Python para criar o servidor MCP de calculadora.

*Nota*: O AI Toolkit atualmente suporta Python e TypeScript.

1. Na seção **Ferramentas** do **Agent (Prompt) Builder**, clique no botão **+ MCP Server**. A extensão iniciará um assistente de configuração via **Command Palette**.
1. Selecione **+ Adicionar Servidor**.
1. Selecione **Criar um Novo Servidor MCP**.
1. Selecione **python-weather** como template.
1. Selecione **Pasta padrão** para salvar o template do servidor MCP.
1. Digite o seguinte nome para o servidor: **Calculator**
1. Uma nova janela do Visual Studio Code será aberta. Selecione **Sim, confio nos autores**.
1. Usando o terminal (**Terminal** > **Novo Terminal**), crie um ambiente virtual: `python -m venv .venv`
1. No terminal, ative o ambiente virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. No terminal, instale as dependências: `pip install -e .[dev]`
1. Na visualização **Explorer** da **Barra de Atividades**, expanda o diretório **src** e selecione **server.py** para abrir o arquivo no editor.
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

Agora que seu agente tem ferramentas, é hora de usá-las! Nesta seção, você enviará comandos ao agente para testar e validar se ele utiliza a ferramenta apropriada do servidor MCP de calculadora.

![Screenshot da interface do Calculator Agent na extensão AI Toolkit para Visual Studio Code. No painel esquerdo, em “Ferramentas,” um servidor MCP chamado local-server-calculator_server está adicionado, mostrando quatro ferramentas disponíveis: add, subtract, multiply e divide. Um selo indica que quatro ferramentas estão ativas. Abaixo está uma seção “Saída estruturada” recolhida e um botão azul “Executar.” No painel direito, em “Resposta do Modelo,” o agente invoca as ferramentas multiply e subtract com entradas {"a": 3, "b": 25} e {"a": 75, "b": 20} respectivamente. A “Resposta da Ferramenta” final é mostrada como 75.0. Um botão “Ver Código” aparece na parte inferior.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.br.png)

Você executará o servidor MCP de calculadora na sua máquina local de desenvolvimento via o **Agent Builder** como cliente MCP.

1. Pressione `F5` para iniciar a depuração do servidor MCP. O **Agent (Prompt) Builder** abrirá em uma nova aba do editor. O status do servidor é visível no terminal.
1. No campo **Prompt do usuário** do **Agent (Prompt) Builder**, digite o seguinte comando: `Comprei 3 itens a $25 cada, e depois usei um desconto de $20. Quanto paguei?`
1. Clique no botão **Executar** para gerar a resposta do agente.
1. Revise a saída do agente. O modelo deve concluir que você pagou **$55**.
1. Aqui está o que deve acontecer:
    - O agente seleciona as ferramentas **multiply** e **subtract** para ajudar no cálculo.
    - Os valores `a` e `b` são atribuídos para a ferramenta **multiply**.
    - Os valores `a` e `b` são atribuídos para a ferramenta **subtract**.
    - A resposta de cada ferramenta é fornecida na respectiva **Resposta da Ferramenta**.
    - A saída final do modelo é apresentada na **Resposta do Modelo**.
1. Envie comandos adicionais para testar mais o agente. Você pode modificar o prompt existente no campo **Prompt do usuário** clicando nele e substituindo o texto.
1. Quando terminar de testar o agente, você pode parar o servidor pelo **terminal** pressionando **CTRL/CMD+C** para sair.

## Tarefa

Tente adicionar uma ferramenta extra no seu arquivo **server.py** (ex: retornar a raiz quadrada de um número). Envie comandos adicionais que exijam que o agente utilize sua nova ferramenta (ou ferramentas existentes). Lembre-se de reiniciar o servidor para carregar as ferramentas adicionadas.

## Solução

[Solution](./solution/README.md)

## Principais aprendizados

Os principais aprendizados deste capítulo são:

- A extensão AI Toolkit é um ótimo cliente que permite consumir servidores MCP e suas ferramentas.
- Você pode adicionar novas ferramentas aos servidores MCP, ampliando as capacidades do agente para atender a requisitos em evolução.
- O AI Toolkit inclui templates (ex: templates de servidor MCP em Python) para simplificar a criação de ferramentas personalizadas.

## Recursos adicionais

- [Documentação do AI Toolkit](https://aka.ms/AIToolkit/doc)

## O que vem a seguir
- Próximo: [Testes e Depuração](../08-testing/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.