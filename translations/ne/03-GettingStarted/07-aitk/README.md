<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:17:34+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "ne"
}
-->
# Visual Studio Code का AI Toolkit एक्सटेंशनबाट सर्भर कसरी प्रयोग गर्ने

जब तपाईं AI एजेन्ट बनाउँदै हुनुहुन्छ, यो केवल बुद्धिमान जवाफहरू सिर्जना गर्ने कुरा मात्र होइन; तपाईंको एजेन्टलाई कार्य गर्न सक्ने क्षमता दिनु पनि महत्त्वपूर्ण हुन्छ। त्यसैले Model Context Protocol (MCP) आएको हो। MCP ले एजेन्टहरूलाई बाह्य उपकरण र सेवाहरूमा समान तरिकाले पहुँच दिन सजिलो बनाउँछ। यसलाई यस्तो सोच्नुहोस् कि तपाईंको एजेन्टलाई एउटा यस्तो उपकरण बक्समा जोड्नु जुन उसले साँच्चै प्रयोग गर्न सक्छ।

मानौं तपाईंले एजेन्टलाई आफ्नो क्याल्कुलेटर MCP सर्भरसँग जोड्नुभयो। अचानक, तपाईंको एजेन्टले “47 गुणा 89 कति हुन्छ?” जस्तो सोध्दा गणितीय अपरेशनहरू गर्न सक्छ—कुनै कडा कोडिङ वा कस्टम API बनाउन आवश्यक छैन।

## अवलोकन

यस पाठले कसरी Visual Studio Code मा [AI Toolkit](https://aka.ms/AIToolkit) एक्सटेंशनको माध्यमबाट क्याल्कुलेटर MCP सर्भरलाई एजेन्टसँग जोड्ने र एजेन्टलाई प्राकृतिक भाषाबाट जोड, घटाउ, गुणा, र भाग जस्ता गणितीय अपरेशनहरू गर्न सक्षम बनाउने बारे सिकाउँछ।

AI Toolkit Visual Studio Code को लागि एक शक्तिशाली एक्सटेंशन हो जसले एजेन्ट विकासलाई सजिलो बनाउँछ। AI इन्जिनियरहरूले सजिलै स्थानीय वा क्लाउडमा जेनेरेटिभ AI मोडेलहरू विकास र परीक्षण गरेर AI एप्लिकेशनहरू बनाउन सक्छन्। यो एक्सटेंशन आज उपलब्ध अधिकांश प्रमुख जेनेरेटिभ मोडेलहरूलाई समर्थन गर्दछ।

*Note*: AI Toolkit हाल Python र TypeScript लाई समर्थन गर्दछ।

## सिकाइका उद्देश्यहरू

यस पाठको अन्त्यमा, तपाईं सक्षम हुनुहुनेछ:

- AI Toolkit मार्फत MCP सर्भर कसरी प्रयोग गर्ने।
- एजेन्ट कन्फिगरेसन सेटअप गरेर MCP सर्भरले प्रदान गरेका उपकरणहरू पत्ता लगाउन र प्रयोग गर्न सक्षम बनाउने।
- प्राकृतिक भाषाबाट MCP उपकरणहरू प्रयोग गर्ने।

## दृष्टिकोण

हामीले माथिल्लो स्तरमा यसरी अघि बढ्नुपर्छ:

- एउटा एजेन्ट सिर्जना गरी यसको सिस्टम प्रम्प्ट परिभाषित गर्ने।
- क्याल्कुलेटर उपकरणहरूसहित MCP सर्भर बनाउने।
- Agent Builder लाई MCP सर्भरसँग जोड्ने।
- प्राकृतिक भाषाबाट एजेन्टको उपकरण प्रयोग परीक्षण गर्ने।

ठिक छ, अब जब हामीले प्रक्रिया बुझ्यौं, आउनुहोस् AI एजेन्टलाई MCP मार्फत बाह्य उपकरणहरू प्रयोग गर्न कन्फिगर गरौं र यसको क्षमता बढाऔं!

## पूर्वआवश्यकताहरू

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## अभ्यास: सर्भर प्रयोग गर्ने

यस अभ्यासमा, तपाईं Visual Studio Code भित्र AI Toolkit प्रयोग गरेर MCP सर्भरका उपकरणहरूसँग AI एजेन्ट निर्माण, चलाउने, र सुधार गर्नेछौं।

### -0- प्रारम्भिक चरण, OpenAI GPT-4o मोडेललाई My Models मा थप्नुहोस्

यस अभ्यासले **GPT-4o** मोडेल प्रयोग गर्दछ। एजेन्ट सिर्जना गर्नु अघि मोडेललाई **My Models** मा थप्नुपर्छ।

![Visual Studio Code को AI Toolkit एक्सटेंशनमा मोडेल चयन इन्टरफेसको स्क्रीनसट। शीर्षकमा "Find the right model for your AI Solution" लेखिएको छ र उपशीर्षकले AI मोडेलहरू पत्ता लगाउन, परीक्षण गर्न र डिप्लोय गर्न प्रोत्साहित गर्छ। "Popular Models" अन्तर्गत छ वटा मोडेल कार्डहरू देखिएका छन्: DeepSeek-R1 (GitHub होस्टेड), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - सानो, छिटो), र DeepSeek-R1 (Ollama होस्टेड)। प्रत्येक कार्डमा “Add” र “Try in Playground” विकल्पहरू छन्।](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.ne.png)

1. **Activity Bar** बाट **AI Toolkit** एक्सटेंशन खोल्नुहोस्।
2. **Catalog** सेक्सनमा गएर **Models** चयन गर्नुहोस्, जसले **Model Catalog** नयाँ एडिटर ट्याबमा खोल्छ।
3. **Model Catalog** को सर्च बारमा **OpenAI GPT-4o** टाइप गर्नुहोस्।
4. **+ Add** क्लिक गरी मोडेललाई **My Models** सूचीमा थप्नुहोस्। निश्चित गर्नुहोस् कि तपाईंले **GitHub होस्टेड** मोडेल चयन गर्नुभएको छ।
5. **Activity Bar** मा **OpenAI GPT-4o** मोडेल सूचीमा देखिन्छ कि छैन भनेर जाँच गर्नुहोस्।

### -1- एजेन्ट सिर्जना गर्ने

**Agent (Prompt) Builder** ले तपाईंलाई आफ्नै AI-शक्तिशाली एजेन्टहरू सिर्जना र अनुकूलन गर्न मद्दत गर्छ। यस खण्डमा, तपाईं नयाँ एजेन्ट बनाउनुहुनेछ र कुराकानी चलाउन मोडेल चयन गर्नुहुनेछ।

![Visual Studio Code को AI Toolkit एक्सटेंशनमा "Calculator Agent" बिल्डर इन्टरफेसको स्क्रीनसट। बायाँ प्यानलमा मोडेल "OpenAI GPT-4o (via GitHub)" चयन गरिएको छ। सिस्टम प्रम्प्टमा "You are a professor in university teaching math" लेखिएको छ र युजर प्रम्प्टमा "Explain to me the Fourier equation in simple terms" छ। थप विकल्पहरूमा उपकरण थप्ने, MCP Server सक्षम गर्ने, र संरचित आउटपुट चयन गर्ने बटनहरू छन्। तल निलो “Run” बटन छ। दायाँ प्यानलमा "Get Started with Examples" अन्तर्गत तीन नमूना एजेन्टहरू छन्: Web Developer (MCP Server सहित), Second-Grade Simplifier, र Dream Interpreter, प्रत्येकको छोटो विवरण सहित।](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.ne.png)

1. **Activity Bar** बाट **AI Toolkit** एक्सटेंशन खोल्नुहोस्।
2. **Tools** सेक्सनमा गएर **Agent (Prompt) Builder** चयन गर्नुहोस्, जसले नयाँ एडिटर ट्याबमा खोल्छ।
3. **+ New Agent** बटन क्लिक गर्नुहोस्। यसले **Command Palette** मार्फत सेटअप विजार्ड सुरु गर्नेछ।
4. नाम **Calculator Agent** टाइप गरी **Enter** थिच्नुहोस्।
5. **Agent (Prompt) Builder** मा **Model** फिल्डमा **OpenAI GPT-4o (via GitHub)** मोडेल चयन गर्नुहोस्।

### -2- एजेन्टका लागि सिस्टम प्रम्प्ट बनाउने

एजेन्ट तयार भएपछि, यसको व्यक्तित्व र उद्देश्य परिभाषित गर्ने बेला हो। यस खण्डमा, तपाईंले **Generate system prompt** सुविधा प्रयोग गरी एजेन्टको व्यवहार वर्णन गर्नुहुनेछ—यस अवस्थामा क्याल्कुलेटर एजेन्ट—र मोडेललाई सिस्टम प्रम्प्ट लेख्न लगाउनुहुनेछ।

![Visual Studio Code को AI Toolkit मा "Calculator Agent" इन्टरफेसको स्क्रीनसट जसमा "Generate a prompt" शीर्षक भएको मोडल विन्डो खुल्ला छ। मोडलले एउटा प्रम्प्ट टेम्प्लेट बनाउन आधारभूत विवरण साझा गर्न सकिने बताउँछ। टेक्स्ट बक्समा नमूना सिस्टम प्रम्प्ट छ: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." तल "Close" र "Generate" बटनहरू छन्। पृष्ठभूमिमा एजेन्ट कन्फिगरेसन देखिन्छ जसमा चयन गरिएको मोडेल "OpenAI GPT-4o (via GitHub)" र सिस्टम तथा युजर प्रम्प्ट फिल्डहरू छन्।](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.ne.png)

1. **Prompts** सेक्सनमा **Generate system prompt** बटन क्लिक गर्नुहोस्। यसले AI प्रयोग गरेर सिस्टम प्रम्प्ट बनाउन मद्दत गर्ने प्रम्प्ट बिल्डर खोल्नेछ।
2. **Generate a prompt** विन्डोमा तल दिइएको टेक्स्ट प्रविष्ट गर्नुहोस्: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** बटन क्लिक गर्नुहोस्। स्क्रीनको तल-दायाँ कुनामा सूचना देखिनेछ कि सिस्टम प्रम्प्ट बनाइँदैछ। तयार भएपछि प्रम्प्ट **Agent (Prompt) Builder** को **System prompt** फिल्डमा देखिनेछ।
4. सिस्टम प्रम्प्ट समीक्षा गरी आवश्यक भए संशोधन गर्नुहोस्।

### -3- MCP सर्भर बनाउने

अब तपाईंले एजेन्टको सिस्टम प्रम्प्ट परिभाषित गरिसक्नुभयो—यसले एजेन्टको व्यवहार र प्रतिक्रियाहरूलाई निर्देशित गर्छ—अब एजेन्टलाई व्यवहारिक क्षमता दिनु पर्छ। यस खण्डमा, तपाईंले क्याल्कुलेटर MCP सर्भर बनाउनुहुनेछ जसमा जोड, घटाउ, गुणा, र भागका उपकरणहरू हुनेछन्। यसले एजेन्टलाई प्राकृतिक भाषाबाट आएका गणितीय अपरेशनहरू तत्काल गर्न सक्षम बनाउनेछ।

![Visual Studio Code को AI Toolkit एक्सटेंशनमा Calculator Agent इन्टरफेसको तल्लो भागको स्क्रीनसट। यसमा “Tools” र “Structure output” को लागि विस्तार गर्न मिल्ने मेनुहरू छन्, साथै “Choose output format” ड्रपडाउन “text” मा सेट गरिएको छ। दायाँमा “+ MCP Server” बटन छ जसले Model Context Protocol सर्भर थप्न प्रयोग हुन्छ।](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.ne.png)

AI Toolkit ले आफ्नै MCP सर्भर बनाउन सजिलो बनाउन टेम्प्लेटहरू प्रदान गर्दछ। हामी क्याल्कुलेटर MCP सर्भर बनाउन Python टेम्प्लेट प्रयोग गर्नेछौं।

*Note*: AI Toolkit हाल Python र TypeScript लाई समर्थन गर्दछ।

1. **Agent (Prompt) Builder** को **Tools** सेक्सनमा **+ MCP Server** बटन क्लिक गर्नुहोस्। यसले **Command Palette** मार्फत सेटअप विजार्ड सुरु गर्नेछ।
2. **+ Add Server** चयन गर्नुहोस्।
3. **Create a New MCP Server** चयन गर्नुहोस्।
4. **python-weather** टेम्प्लेट चयन गर्नुहोस्।
5. **Default folder** चयन गरी MCP सर्भर टेम्प्लेट बचत गर्ने स्थान निर्धारण गर्नुहोस्।
6. सर्भरको नाम **Calculator** राख्नुहोस्।
7. नयाँ Visual Studio Code विन्डो खुल्नेछ। **Yes, I trust the authors** चयन गर्नुहोस्।
8. टर्मिनलमा गएर भर्चुअल वातावरण सिर्जना गर्नुहोस्: `python -m venv .venv`
9. टर्मिनलमा भर्चुअल वातावरण सक्रिय गर्नुहोस्:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. टर्मिनलमा निर्भरता स्थापना गर्नुहोस्: `pip install -e .[dev]`
11. **Explorer** भ्यूमा **src** फोल्डर विस्तार गरी **server.py** फाइल खोल्नुहोस्।
12. **server.py** फाइलको कोड तल दिइएको कोडले प्रतिस्थापन गरी सेभ गर्नुहोस्:

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

### -4- क्याल्कुलेटर MCP सर्भरसँग एजेन्ट चलाउने

अब तपाईंको एजेन्टसँग उपकरणहरू उपलब्ध छन्, तिनीहरू प्रयोग गर्ने बेला आयो! यस खण्डमा, तपाईंले एजेन्टलाई प्रम्प्ट पठाएर परीक्षण गर्नुहुनेछ कि एजेन्टले क्याल्कुलेटर MCP सर्भरबाट सही उपकरण प्रयोग गरिरहेको छ कि छैन।

![Visual Studio Code को AI Toolkit एक्सटेंशनमा Calculator Agent इन्टरफेसको स्क्रीनसट। बायाँ प्यानलमा “Tools” अन्तर्गत local-server-calculator_server नामको MCP सर्भर थपिएको छ, जसमा चार उपकरणहरू छन्: add, subtract, multiply, र divide। चार उपकरणहरू सक्रिय भएको ब्याज देखिन्छ। तल “Structure output” सेक्सन सङ्कुचित छ र निलो “Run” बटन छ। दायाँ प्यानलमा “Model Response” अन्तर्गत एजेन्टले multiply र subtract उपकरणहरू क्रमशः {"a": 3, "b": 25} र {"a": 75, "b": 20} इनपुटसहित कल गरेको छ। अन्तिम “Tool Response” 75.0 देखाइएको छ। तल “View Code” बटन छ।](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.ne.png)

तपाईंले आफ्नो स्थानीय विकास मेसिनमा **Agent Builder** मार्फत MCP क्लाइन्टको रूपमा क्याल्कुलेटर MCP सर्भर चलाउनु हुनेछ।

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` मानहरू **subtract** उपकरणको लागि निर्धारण गरिएको छ।
    - प्रत्येक उपकरणबाट प्राप्त प्रतिक्रिया सम्बन्धित **Tool Response** मा देखिन्छ।
    - मोडेलबाट अन्तिम आउटपुट अन्तिम **Model Response** मा देखाइन्छ।
2. थप प्रम्प्टहरू पठाएर एजेन्ट परीक्षण गर्नुहोस्। तपाईं **User prompt** फिल्डमा क्लिक गरी हालको प्रम्प्ट परिवर्तन गर्न सक्नुहुन्छ।
3. परीक्षण सकेपछि, टर्मिनलमा **CTRL/CMD+C** थिचेर सर्भर बन्द गर्न सक्नुहुन्छ।

## कार्य

तपाईंको **server.py** फाइलमा नयाँ उपकरण थप्ने प्रयास गर्नुहोस् (जस्तै: कुनै सङ्ख्याको वर्गमूल फर्काउने)। थप प्रम्प्टहरू पठाएर एजेन्टलाई तपाईंको नयाँ उपकरण (वा अवस्थित उपकरणहरू) प्रयोग गर्न लगाउनुहोस्। नयाँ उपकरणहरू लोड गर्न सर्भर पुनः सुरु गर्न नबिर्सनुहोस्।

## समाधान

[Solution](./solution/README.md)

## मुख्य बुँदाहरू

यस अध्यायबाट मुख्य कुरा:

- AI Toolkit एक्सटेंशन उत्कृष्ट क्लाइन्ट हो जसले तपाईंलाई MCP सर्भरहरू र तिनीहरूका उपकरणहरू प्रयोग गर्न दिन्छ।
- तपाईं MCP सर्भरहरूमा नयाँ उपकरणहरू थप्न सक्नुहुन्छ, जसले एजेन्टको क्षमता बढाउँछ र नयाँ आवश्यकताहरू पूरा गर्छ।
- AI Toolkit मा Python MCP सर्भर टेम्प्लेट जस्ता टेम्प्लेटहरू समावेश छन् जसले कस्टम उपकरणहरू बनाउन सजिलो बनाउँछ।

## थप स्रोतहरू

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## के गर्ने अर्को
- Next: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयास गर्छौं, तर कृपया जानकार हुनुहोस् कि स्वचालित अनुवादमा त्रुटि वा गलतफहमी हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट हुने कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।