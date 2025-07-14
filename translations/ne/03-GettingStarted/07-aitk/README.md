<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:30:42+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "ne"
}
-->
# Visual Studio Code को AI Toolkit एक्सटेन्सनबाट सर्भर प्रयोग गर्ने तरिका

जब तपाईं AI एजेन्ट बनाउँदै हुनुहुन्छ, यो केवल बुद्धिमानी जवाफहरू सिर्जना गर्ने कुरा मात्र होइन; तपाईंको एजेन्टलाई कार्य गर्न सक्ने क्षमता दिनु पनि हो। त्यहीँ Model Context Protocol (MCP) को भूमिका आउँछ। MCP ले एजेन्टहरूलाई बाह्य उपकरण र सेवाहरूलाई एक समान तरिकाले पहुँच गर्न सजिलो बनाउँछ। यसलाई यस्तो सोच्नुहोस् कि तपाईंको एजेन्टलाई एउटा उपकरण बाकसमा जडान गरिदिएको छ जुन उसले साँच्चिकै प्रयोग गर्न सक्छ।

मानौं तपाईंले एजेन्टलाई तपाईंको क्याल्कुलेटर MCP सर्भरसँग जडान गर्नुभयो। अचानक, तपाईंको एजेन्टले “47 गुणा 89 कति हुन्छ?” जस्तो सोध्दा मात्र गणितीय अपरेसनहरू गर्न सक्छ—कुनै कडा कोडिङ वा कस्टम API बनाउन आवश्यक छैन।

## अवलोकन

यस पाठले Visual Studio Code मा [AI Toolkit](https://aka.ms/AIToolkit) एक्सटेन्सन प्रयोग गरी क्याल्कुलेटर MCP सर्भरलाई एजेन्टसँग कसरी जडान गर्ने भन्ने सिकाउँछ, जसले तपाईंको एजेन्टलाई प्राकृतिक भाषाबाट जोड, घटाउ, गुणा, र भाग जस्ता गणितीय अपरेसनहरू गर्न सक्षम बनाउँछ।

AI Toolkit Visual Studio Code को लागि एक शक्तिशाली एक्सटेन्सन हो जसले एजेन्ट विकासलाई सहज बनाउँछ। AI इन्जिनियरहरूले सजिलैसँग स्थानीय वा क्लाउडमा जेनेरेटिभ AI मोडेलहरू विकास र परीक्षण गरेर AI एप्लिकेसनहरू बनाउन सक्छन्। यो एक्सटेन्सनले आज उपलब्ध अधिकांश प्रमुख जेनेरेटिभ मोडेलहरूलाई समर्थन गर्दछ।

*Note*: AI Toolkit हाल Python र TypeScript लाई समर्थन गर्दछ।

## सिकाइका उद्देश्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- AI Toolkit मार्फत MCP सर्भर प्रयोग गर्न।
- एजेन्ट कन्फिगरेसन सेटअप गर्न जसले MCP सर्भरले प्रदान गरेका उपकरणहरू पत्ता लगाउन र प्रयोग गर्न सक्षम बनाउँछ।
- प्राकृतिक भाषाबाट MCP उपकरणहरू प्रयोग गर्न।

## दृष्टिकोण

हामीले उच्च स्तरमा यसरी अघि बढ्नुपर्छ:

- एउटा एजेन्ट बनाउने र यसको सिस्टम प्रॉम्प्ट परिभाषित गर्ने।
- क्याल्कुलेटर उपकरणहरू सहित MCP सर्भर बनाउने।
- Agent Builder लाई MCP सर्भरसँग जडान गर्ने।
- प्राकृतिक भाषाबाट एजेन्टको उपकरण प्रयोग परीक्षण गर्ने।

उत्तम, अब हामी प्रवाह बुझिसकेपछि, MCP मार्फत बाह्य उपकरणहरू प्रयोग गर्न AI एजेन्ट कन्फिगर गरौं र यसको क्षमता बढाऔं!

## पूर्वआवश्यकताहरू

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## अभ्यास: सर्भर प्रयोग गर्ने

यस अभ्यासमा, तपाईं Visual Studio Code भित्र AI Toolkit प्रयोग गरी MCP सर्भरबाट उपकरणहरू सहित AI एजेन्ट बनाउने, चलाउने, र सुधार गर्नेछौं।

### -0- प्रारम्भिक चरण, My Models मा OpenAI GPT-4o मोडेल थप्ने

यस अभ्यासले **GPT-4o** मोडेल प्रयोग गर्दछ। एजेन्ट बनाउनुअघि यो मोडेल **My Models** मा थपिएको हुनुपर्छ।

![Visual Studio Code को AI Toolkit एक्सटेन्सनमा मोडेल चयन इन्टरफेसको स्क्रिनशट। शीर्षकमा लेखिएको छ "Find the right model for your AI Solution" र उपशीर्षकले प्रयोगकर्तालाई AI मोडेलहरू पत्ता लगाउन, परीक्षण गर्न, र तैनाथ गर्न प्रोत्साहित गर्दछ। “Popular Models” अन्तर्गत छ वटा मोडेल कार्डहरू देखिएका छन्: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - सानो, छिटो), र DeepSeek-R1 (Ollama-hosted)। प्रत्येक कार्डमा “Add” र “Try in Playground” विकल्पहरू छन्।](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.ne.png)

1. **Activity Bar** बाट **AI Toolkit** एक्सटेन्सन खोल्नुहोस्।
2. **Catalog** सेक्सनमा गएर **Models** चयन गर्नुहोस् जसले नयाँ एडिटर ट्याबमा **Model Catalog** खोल्छ।
3. **Model Catalog** को खोज पट्टीमा **OpenAI GPT-4o** टाइप गर्नुहोस्।
4. **+ Add** मा क्लिक गरी मोडेललाई **My Models** सूचीमा थप्नुहोस्। सुनिश्चित गर्नुहोस् कि तपाईंले **GitHub द्वारा होस्ट गरिएको** मोडेल चयन गर्नुभएको छ।
5. **Activity Bar** मा **OpenAI GPT-4o** मोडेल सूचीमा देखिन्छ कि छैन जाँच गर्नुहोस्।

### -1- एजेन्ट बनाउने

**Agent (Prompt) Builder** ले तपाईंलाई आफ्नै AI-संचालित एजेन्टहरू सिर्जना र अनुकूलन गर्न अनुमति दिन्छ। यस भागमा, तपाईं नयाँ एजेन्ट बनाउनुहुनेछ र कुराकानीलाई शक्ति दिन मोडेल चयन गर्नुहुनेछ।

![Visual Studio Code को AI Toolkit एक्सटेन्सनमा "Calculator Agent" बिल्डर इन्टरफेसको स्क्रिनशट। बाँया प्यानलमा चयन गरिएको मोडेल "OpenAI GPT-4o (via GitHub)" छ। सिस्टम प्रॉम्प्टमा लेखिएको छ "You are a professor in university teaching math," र प्रयोगकर्ता प्रॉम्प्टमा छ "Explain to me the Fourier equation in simple terms." थप विकल्पहरूमा उपकरण थप्ने, MCP Server सक्षम गर्ने, र संरचित आउटपुट चयन गर्ने बटनहरू छन्। तल नीलो “Run” बटन छ। दायाँ प्यानलमा "Get Started with Examples" अन्तर्गत तीन नमूना एजेन्टहरू सूचीबद्ध छन्: Web Developer (MCP Server, Second-Grade Simplifier, र Dream Interpreter सहित, प्रत्येकको संक्षिप्त विवरणसहित।](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.ne.png)

1. **Activity Bar** बाट **AI Toolkit** एक्सटेन्सन खोल्नुहोस्।
2. **Tools** सेक्सनमा गएर **Agent (Prompt) Builder** चयन गर्नुहोस्। यसले नयाँ एडिटर ट्याबमा **Agent (Prompt) Builder** खोल्छ।
3. **+ New Agent** बटनमा क्लिक गर्नुहोस्। एक्सटेन्सनले **Command Palette** मार्फत सेटअप विजार्ड सुरु गर्नेछ।
4. नाम **Calculator Agent** टाइप गरी **Enter** थिच्नुहोस्।
5. **Agent (Prompt) Builder** मा **Model** फिल्डमा **OpenAI GPT-4o (via GitHub)** मोडेल चयन गर्नुहोस्।

### -2- एजेन्टको लागि सिस्टम प्रॉम्प्ट बनाउने

एजेन्ट तयार भएपछि, यसको व्यक्तित्व र उद्देश्य परिभाषित गर्ने समय आएको छ। यस भागमा, तपाईं **Generate system prompt** सुविधा प्रयोग गरी एजेन्टको व्यवहार वर्णन गर्नुहुनेछ—यस अवस्थामा, क्याल्कुलेटर एजेन्ट—र मोडेललाई सिस्टम प्रॉम्प्ट लेख्न लगाउनुहुनेछ।

![Visual Studio Code को AI Toolkit मा "Calculator Agent" इन्टरफेसको स्क्रिनशट, जहाँ "Generate a prompt" शीर्षक भएको मोडल विन्डो खुल्ला छ। मोडलले बताउँछ कि आधारभूत विवरणहरू साझा गरेर प्रॉम्प्ट टेम्प्लेट सिर्जना गर्न सकिन्छ। एउटा टेक्स्ट बक्समा नमूना सिस्टम प्रॉम्प्ट छ: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." तल "Close" र "Generate" बटनहरू छन्। पृष्ठभूमिमा एजेन्ट कन्फिगरेसनको केही भाग देखिन्छ, चयन गरिएको मोडेल "OpenAI GPT-4o (via GitHub)" सहित।](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.ne.png)

1. **Prompts** सेक्सनमा **Generate system prompt** बटनमा क्लिक गर्नुहोस्। यसले AI प्रयोग गरी एजेन्टको लागि सिस्टम प्रॉम्प्ट सिर्जना गर्ने प्रॉम्प्ट बिल्डर खोल्छ।
2. **Generate a prompt** विन्डोमा तलको पाठ टाइप गर्नुहोस्: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** बटनमा क्लिक गर्नुहोस्। तल-दायाँ कुनामा एउटा सूचना देखिनेछ जसले सिस्टम प्रॉम्प्ट सिर्जना भइरहेको पुष्टि गर्नेछ। प्रॉम्प्ट तयार भएपछि, यो **Agent (Prompt) Builder** को **System prompt** फिल्डमा देखिनेछ।
4. **System prompt** समीक्षा गर्नुहोस् र आवश्यक परे संशोधन गर्नुहोस्।

### -3- MCP सर्भर बनाउने

अब तपाईंले एजेन्टको सिस्टम प्रॉम्प्ट परिभाषित गर्नुभयो—यसले यसको व्यवहार र जवाफहरू निर्देशित गर्छ—अब एजेन्टलाई व्यावहारिक क्षमता दिनु पर्नेछ। यस भागमा, तपाईं जोड, घटाउ, गुणा, र भाग गणना गर्ने उपकरणहरू सहित क्याल्कुलेटर MCP सर्भर बनाउनुहुनेछ। यसले एजेन्टलाई प्राकृतिक भाषाबाट आएको अनुरोधमा वास्तविक समयमा गणितीय अपरेसनहरू गर्न सक्षम बनाउनेछ।

![Visual Studio Code को AI Toolkit एक्सटेन्सनमा Calculator Agent इन्टरफेसको तल्लो भागको स्क्रिनशट। यसमा “Tools” र “Structure output” को लागि विस्तार गर्न मिल्ने मेनुहरू छन्, साथै “Choose output format” ड्रपडाउन मेनु “text” मा सेट गरिएको छ। दायाँपट्टि “+ MCP Server” बटन छ जसले Model Context Protocol सर्भर थप्न प्रयोग हुन्छ।](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.ne.png)

AI Toolkit ले आफ्नै MCP सर्भर बनाउन सजिलो बनाउन टेम्प्लेटहरू प्रदान गर्दछ। हामी क्याल्कुलेटर MCP सर्भर बनाउन Python टेम्प्लेट प्रयोग गर्नेछौं।

*Note*: AI Toolkit हाल Python र TypeScript लाई समर्थन गर्दछ।

1. **Agent (Prompt) Builder** को **Tools** सेक्सनमा **+ MCP Server** बटनमा क्लिक गर्नुहोस्। एक्सटेन्सनले **Command Palette** मार्फत सेटअप विजार्ड सुरु गर्नेछ।
2. **+ Add Server** चयन गर्नुहोस्।
3. **Create a New MCP Server** चयन गर्नुहोस्।
4. टेम्प्लेटको रूपमा **python-weather** चयन गर्नुहोस्।
5. MCP सर्भर टेम्प्लेट बचत गर्न **Default folder** चयन गर्नुहोस्।
6. सर्भरको नाम **Calculator** राख्नुहोस्।
7. नयाँ Visual Studio Code विन्डो खुल्नेछ। **Yes, I trust the authors** चयन गर्नुहोस्।
8. टर्मिनलमा गएर भर्चुअल वातावरण बनाउनुहोस्: `python -m venv .venv`
9. टर्मिनलमा भर्चुअल वातावरण सक्रिय गर्नुहोस्:
    - Windows: `.venv\Scripts\activate`
    - macOS/Linux: `source venv/bin/activate`
10. टर्मिनलमा निर्भरता स्थापना गर्नुहोस्: `pip install -e .[dev]`
11. **Activity Bar** को **Explorer** दृश्यमा **src** डाइरेक्टरी विस्तार गरी **server.py** फाइल खोल्नुहोस्।
12. **server.py** फाइलको कोड तल दिइएको कोडले प्रतिस्थापन गरी बचत गर्नुहोस्:

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

अब तपाईंको एजेन्टसँग उपकरणहरू छन्, तिनीहरू प्रयोग गर्ने समय आएको छ! यस भागमा, तपाईं एजेन्टलाई प्रॉम्प्टहरू पठाएर परीक्षण गर्नुहुनेछ कि एजेन्टले क्याल्कुलेटर MCP सर्भरबाट उपयुक्त उपकरण प्रयोग गर्छ कि गर्दैन।

![Visual Studio Code को AI Toolkit एक्सटेन्सनमा Calculator Agent इन्टरफेसको स्क्रिनशट। बाँया प्यानलमा “Tools” अन्तर्गत local-server-calculator_server नामक MCP सर्भर थपिएको छ, जसमा चार उपकरणहरू छन्: add, subtract, multiply, र divide। चार उपकरणहरू सक्रिय भएको देखाउने ब्याज छ। तल “Structure output” सेक्सन संकुचित छ र नीलो “Run” बटन छ। दायाँ प्यानलमा “Model Response” अन्तर्गत एजेन्टले multiply र subtract उपकरणहरू क्रमशः {"a": 3, "b": 25} र {"a": 75, "b": 20} इनपुटसहित प्रयोग गरेको देखिन्छ। अन्तिम “Tool Response” 75.0 देखाइएको छ। तल “View Code” बटन छ।](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.ne.png)

तपाईंले आफ्नो स्थानीय विकास मेसिनमा **Agent Builder** मार्फत MCP सर्भर चलाउनु हुनेछ।

1. `F5` थिचेर MCP सर्भर डिबगिङ सुरु गर्नुहोस्। **Agent (Prompt) Builder** नयाँ एडिटर ट्याबमा खुल्नेछ। टर्मिनलमा सर्भरको स्थिति देखिनेछ।
2. **Agent (Prompt) Builder** को **User prompt** फिल्डमा यो प्रॉम्प्ट टाइप गर्नुहोस्: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. **Run** बटनमा क्लिक गरी एजेन्टको जवाफ उत्पन्न गर्नुहोस्।
4. एजेन्टको आउटपुट समीक्षा गर्नुहोस्। मोडेलले तपाईंले **$55** तिरेको निष्कर्ष निकाल्नुपर्छ।
5. यहाँ के हुन्छ भन्ने विवरण:
    - एजेन्टले गणना गर्न **multiply** र **subtract** उपकरणहरू चयन गर्छ।
    - **multiply** उपकरणका लागि `a` र `b` मानहरू सेट गरिन्छ।
    - **subtract** उपकरणका लागि `a` र `b` मानहरू सेट गरिन्छ।
    - प्रत्येक उपकरणबाट प्राप्त जवाफ **Tool Response** मा दिइन्छ।
    - अन्तिम मोडेल जवाफ **Model Response** मा देखाइन्छ।
6. थप प्रॉम्प्टहरू पठाएर एजेन्टलाई थप परीक्षण गर्नुहोस्। **User prompt** फिल्डमा क्लिक गरी हालको प्रॉम्प्ट परिवर्तन गर्न सक्नुहुन्छ।
7. परीक्षण सकिएपछि, टर्मिनलमा **CTRL/CMD+C** थिचेर सर्भर बन्द गर्नुहोस्।

## असाइनमेन्ट

तपाईंको **server.py** फाइलमा थप एउटा उपकरण थप्ने प्रयास गर्नुहोस् (जस्तै: कुनै संख्याको वर्गमूल फर्काउने)। थप प्रॉम्प्टहरू पठाएर एजेन्टलाई तपाईंको नयाँ उपकरण (वा अवस्थित उपकरणहरू) प्रयोग गर्न लगाउनुहोस्। नयाँ उपकरणहरू लोड गर्न सर्भर पुनः सुरु गर्न नबिर्सनुहोस्।

## समाधान

[Solution](./solution/README.md)

## मुख्य सिकाइहरू

यस अध्यायबाट सिक्ने मुख्य कुरा:

- AI Toolkit एक्सटेन्सन एक उत्कृष्ट क्लाइन्ट हो जसले तपाईंलाई MCP सर्भर र तिनका उपकरणहरू प्रयोग गर्न दिन्छ।
- तपाईं MCP सर्भरहरूमा नयाँ उपकरणहरू थप्न सक्नुहुन्छ, जसले एजेन्टको क्षमता विस्तार गर्छ।
- AI Toolkit मा Python MCP सर्भर टेम्प्लेटहरू जस्ता टेम्प्लेटहरू छन् जसले कस्टम उपकरणहरू बनाउन सजिलो बनाउँछ।

## थप स्रोतहरू

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## के छ अर्को
- अर्को: [Testing & Debugging](../08-testing/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुनसक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।