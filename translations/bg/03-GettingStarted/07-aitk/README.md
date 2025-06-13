<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:28:22+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "bg"
}
-->
# Използване на сървър от AI Toolkit разширението за Visual Studio Code

Когато създавате AI агент, не става въпрос само за генериране на умни отговори; важно е и агентът ви да може да предприема действия. Тук влиза в игра Model Context Protocol (MCP). MCP улеснява агентите да имат достъп до външни инструменти и услуги по последователен начин. Представете си го като включване на агента ви в куфар с инструменти, който той *наистина* може да използва.

Да кажем, че свържете агент с вашия MCP сървър за калкулатор. Изведнъж агентът може да извършва математически операции само като получи въпрос като „Колко е 47 по 89?“ — без нужда от ръчно кодиране на логика или създаване на специални API.

## Преглед

В този урок ще научите как да свържете MCP сървър за калкулатор с агент чрез [AI Toolkit](https://aka.ms/AIToolkit) разширението във Visual Studio Code, което позволява на агента да извършва математически операции като събиране, изваждане, умножение и деление чрез естествен език.

AI Toolkit е мощно разширение за Visual Studio Code, което улеснява разработката на агенти. AI инженерите могат лесно да създават AI приложения, като разработват и тестват генеративни AI модели — локално или в облака. Разширението поддържа повечето от основните генеративни модели, налични днес.

*Забележка*: AI Toolkit в момента поддържа Python и TypeScript.

## Учебни цели

След края на този урок ще можете да:

- Използвате MCP сървър чрез AI Toolkit.
- Конфигурирате агент, така че да може да открива и използва инструментите, предоставени от MCP сървъра.
- Използвате MCP инструменти чрез естествен език.

## Подход

Ето как трябва да подходите на високо ниво:

- Създайте агент и дефинирайте неговия системен prompt.
- Създайте MCP сървър с калкулаторни инструменти.
- Свържете Agent Builder със MCP сървъра.
- Тествайте извикването на инструменти от агента чрез естествен език.

Страхотно, сега когато разбираме потока, нека конфигурираме AI агент да използва външни инструменти чрез MCP, за да разширим възможностите му!

## Изисквания

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit за Visual Studio Code](https://aka.ms/AIToolkit)

## Упражнение: Използване на сървър

В това упражнение ще създадете, стартирате и подобрите AI агент с инструменти от MCP сървър във Visual Studio Code, използвайки AI Toolkit.

### -0- Предварителна стъпка, добавете OpenAI GPT-4o модела в My Models

Упражнението използва **GPT-4o** модела. Трябва да добавите модела в **My Models** преди да създадете агента.

![Screenshot of a model selection interface in Visual Studio Code's AI Toolkit extension. The heading reads "Find the right model for your AI Solution" with a subtitle encouraging users to discover, test, and deploy AI models. Below, under “Popular Models,” six model cards are displayed: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), and DeepSeek-R1 (Ollama-hosted). Each card includes options to “Add” the model or “Try in Playground](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.bg.png)

1. Отворете **AI Toolkit** разширението от **Activity Bar**.
1. В секцията **Catalog** изберете **Models**, за да отворите **Model Catalog**. Изборът на **Models** отваря **Model Catalog** в нов редакторски таб.
1. В полето за търсене на **Model Catalog** въведете **OpenAI GPT-4o**.
1. Натиснете **+ Add**, за да добавите модела към списъка си **My Models**. Уверете се, че сте избрали модела, който е **Hosted by GitHub**.
1. В **Activity Bar** потвърдете, че моделът **OpenAI GPT-4o** се появява в списъка.

### -1- Създайте агент

**Agent (Prompt) Builder** ви позволява да създавате и персонализирате собствени AI агенти. В този раздел ще създадете нов агент и ще му зададете модел, който да захранва разговора.

![Screenshot of the "Calculator Agent" builder interface in the AI Toolkit extension for Visual Studio Code. On the left panel, the model selected is "OpenAI GPT-4o (via GitHub)." A system prompt reads "You are a professor in university teaching math," and the user prompt says, "Explain to me the Fourier equation in simple terms." Additional options include buttons for adding tools, enabling MCP Server, and selecting structured output. A blue “Run” button is at the bottom. On the right panel, under "Get Started with Examples," three sample agents are listed: Web Developer (with MCP Server, Second-Grade Simplifier, and Dream Interpreter, each with brief descriptions of their functions.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.bg.png)

1. Отворете **AI Toolkit** разширението от **Activity Bar**.
1. В секцията **Tools** изберете **Agent (Prompt) Builder**. Това отваря **Agent (Prompt) Builder** в нов редакторски таб.
1. Натиснете бутона **+ New Agent**. Разширението ще стартира настройващ съветник през **Command Palette**.
1. Въведете името **Calculator Agent** и натиснете **Enter**.
1. В полето **Model** в **Agent (Prompt) Builder** изберете модела **OpenAI GPT-4o (via GitHub)**.

### -2- Създайте системен prompt за агента

След като агентът е създаден, време е да дефинирате неговата личност и цел. В този раздел ще използвате функцията **Generate system prompt**, за да опишете желаното поведение на агента — в случая калкулатор — и моделът ще генерира системния prompt за вас.

![Screenshot of the "Calculator Agent" interface in the AI Toolkit for Visual Studio Code with a modal window open titled "Generate a prompt." The modal explains that a prompt template can be generated by sharing basic details and includes a text box with the sample system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Below the text box are "Close" and "Generate" buttons. In the background, part of the agent configuration is visible, including the selected model "OpenAI GPT-4o (via GitHub)" and fields for system and user prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.bg.png)

1. В секцията **Prompts** натиснете бутона **Generate system prompt**. Този бутон отваря генератора на prompt, който използва AI, за да създаде системен prompt за агента.
1. В прозореца **Generate a prompt** въведете следното: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Натиснете бутона **Generate**. В долния десен ъгъл ще се появи известие, че системният prompt се генерира. След като генерирането завърши, prompt-ът ще се появи в полето **System prompt** на **Agent (Prompt) Builder**.
1. Прегледайте **System prompt** и го променете, ако е необходимо.

### -3- Създайте MCP сървър

След като сте дефинирали системния prompt на агента — който задава поведението и отговорите му — е време да го оборудвате с реални възможности. В този раздел ще създадете MCP сървър за калкулатор с инструменти за събиране, изваждане, умножение и деление. Този сървър ще позволи на агента да извършва реални математически операции в отговор на заявки на естествен език.

!["Screenshot of the lower section of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. It shows expandable menus for “Tools” and “Structure output,” along with a dropdown menu labeled “Choose output format” set to “text.” To the right, there is a button labeled “+ MCP Server” for adding a Model Context Protocol server. An image icon placeholder is shown above the Tools section.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.bg.png)

AI Toolkit разполага с шаблони, които улесняват създаването на ваш собствен MCP сървър. Ще използваме Python шаблона за създаване на калкулаторния MCP сървър.

*Забележка*: AI Toolkit в момента поддържа Python и TypeScript.

1. В секцията **Tools** на **Agent (Prompt) Builder** натиснете бутона **+ MCP Server**. Разширението ще стартира настройващ съветник през **Command Palette**.
1. Изберете **+ Add Server**.
1. Изберете **Create a New MCP Server**.
1. Изберете шаблона **python-weather**.
1. Изберете **Default folder**, където да се запази MCP сървър шаблона.
1. Въведете следното име за сървъра: **Calculator**
1. Ще се отвори нов прозорец на Visual Studio Code. Изберете **Yes, I trust the authors**.
1. В терминала (**Terminal** > **New Terminal**) създайте виртуална среда: `python -m venv .venv`
1. В терминала активирайте виртуалната среда:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. В терминала инсталирайте зависимостите: `pip install -e .[dev]`
1. В изгледа **Explorer** на **Activity Bar**, разширете директорията **src** и отворете файла **server.py**.
1. Заменете кода в **server.py** с следния и запазете:

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

### -4- Стартирайте агента с калкулаторния MCP сървър

Сега, когато агентът ви има инструменти, е време да ги използва! В този раздел ще изпращате заявки към агента, за да тествате и проверите дали той използва подходящия инструмент от калкулаторния MCP сървър.

![Screenshot of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. On the left panel, under “Tools,” an MCP server named local-server-calculator_server is added, showing four available tools: add, subtract, multiply, and divide. A badge shows that four tools are active. Below is a collapsed “Structure output” section and a blue “Run” button. On the right panel, under “Model Response,” the agent invokes the multiply and subtract tools with inputs {"a": 3, "b": 25} and {"a": 75, "b": 20} respectively. The final “Tool Response” is shown as 75.0. A “View Code” button appears at the bottom.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.bg.png)

Ще стартирате калкулаторния MCP сървър на локалната си машина чрез **Agent Builder** като MCP клиент.

1. Натиснете `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` стойности се задават за инструмента **subtract**.
    - Отговорът от всеки инструмент се показва в съответното поле **Tool Response**.
    - Крайният резултат от модела се показва в полето **Model Response**.
1. Изпратете допълнителни заявки, за да тествате агента по-нататък. Можете да промените съществуващия prompt в полето **User prompt**, като кликнете в полето и замените текущия prompt.
1. След като приключите с тестването, можете да спрете сървъра чрез терминала, като натиснете **CTRL/CMD+C**.

## Задача

Опитайте да добавите допълнителен инструмент във вашия файл **server.py** (например: връщане на квадратен корен от число). Изпратете допълнителни заявки, които изискват агентът да използва новия инструмент (или съществуващите). Не забравяйте да рестартирате сървъра, за да заредите новите инструменти.

## Решение

[Решение](./solution/README.md)

## Основни изводи

Основните изводи от тази глава са:

- AI Toolkit разширението е отличен клиент, който ви позволява да използвате MCP сървъри и техните инструменти.
- Можете да добавяте нови инструменти към MCP сървърите, разширявайки възможностите на агента според нуждите.
- AI Toolkit включва шаблони (например Python MCP сървър шаблони), които улесняват създаването на персонализирани инструменти.

## Допълнителни ресурси

- [AI Toolkit документация](https://aka.ms/AIToolkit/doc)

## Какво следва
- Следва: [Тестване и отстраняване на грешки](/03-GettingStarted/08-testing/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.