<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:33:39+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "ne"
}
-->
# Visual Studio Code को लागि AI Toolkit विस्तारबाट सर्भर कसरी प्रयोग गर्ने

जब तपाईं AI एजेन्ट बनाउँदै हुनुहुन्छ, केवल स्मार्ट जवाफहरू सिर्जना गर्नु मात्र होइन; तपाईंको एजेन्टलाई कार्य गर्न सक्ने क्षमता दिनु पनि आवश्यक हुन्छ। त्यहीँ Model Context Protocol (MCP) आउँछ। MCP ले एजेन्टहरूलाई बाह्य उपकरण र सेवाहरू सुसंगत तरिकाले पहुँच गर्न सजिलो बनाउँछ। यसलाई यसरी सोच्नुस् कि तपाईंको एजेन्टलाई एक यस्तो उपकरण बाकसमा जोड्दै हुनुहुन्छ जुन उसले *साँचो रूपमा* प्रयोग गर्न सक्छ।

मानौं तपाईंले एजेन्टलाई तपाईंको क्याल्कुलेटर MCP सर्भरसँग जोड्नुभयो। अचानक, तपाईंको एजेन्टले “47 गुणा 89 कति हुन्छ?” जस्तो सोधपुछ पाएर गणितीय अपरेसनहरू गर्न सक्छ—कुनै हार्डकोड गरिएको लॉजिक वा कस्टम API बनाउनु पर्दैन।

## अवलोकन

यो पाठले कसरी क्याल्कुलेटर MCP सर्भरलाई Visual Studio Code मा [AI Toolkit](https://aka.ms/AIToolkit) विस्तारमार्फत एजेन्टसँग जोड्ने सिकाउँछ, जसले एजेन्टलाई प्राकृतिक भाषामा जोड, घटाउ, गुणा, र भाग जस्ता गणितीय अपरेसनहरू गर्न सक्षम बनाउँछ।

AI Toolkit Visual Studio Code को लागि एक शक्तिशाली विस्तार हो जसले एजेन्ट विकासलाई सजिलो बनाउँछ। AI इन्जिनियरहरूले सजिलैसँग स्थानीय वा क्लाउडमा जेनेरेटिभ AI मोडेलहरू विकास र परीक्षण गरेर AI एप्लिकेसनहरू बनाउन सक्छन्। यो विस्तारले आज उपलब्ध अधिकांश प्रमुख जेनेरेटिभ मोडेलहरूलाई समर्थन गर्दछ।

*Note*: AI Toolkit हाल Python र TypeScript लाई समर्थन गर्छ।

## सिकाइका उद्देश्यहरू

यो पाठको अन्त्यसम्म तपाईं सक्षम हुनुहुनेछ:

- AI Toolkit मार्फत MCP सर्भर कसरी प्रयोग गर्ने।
- एजेन्ट कन्फिगरेसन सेटअप गर्ने जसले MCP सर्भरले प्रदान गरेको उपकरणहरू पत्ता लगाउन र प्रयोग गर्न सक्षम बनाउँछ।
- प्राकृतिक भाषामा MCP उपकरणहरू प्रयोग गर्ने।

## दृष्टिकोण

यहाँ उच्च स्तरमा कसरी अगाडि बढ्ने हो:

- एजेन्ट सिर्जना गरी यसको सिस्टम प्रॉम्प्ट परिभाषित गर्ने।
- क्याल्कुलेटर उपकरणहरू सहित MCP सर्भर बनाउने।
- Agent Builder लाई MCP सर्भरसँग जडान गर्ने।
- प्राकृतिक भाषाबाट एजेन्टको उपकरण प्रयोग परीक्षण गर्ने।

अति राम्रो, अब जब हामीले प्रक्रिया बुझ्यौं, आउनुहोस् MCP मार्फत बाह्य उपकरणहरू प्रयोग गर्न AI एजेन्ट कन्फिगर गरौं र यसको क्षमताहरू बढाऔं!

## आवश्यकताहरू

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## अभ्यास: सर्भर प्रयोग गर्ने

यस अभ्यासमा, तपाईं Visual Studio Code भित्र AI Toolkit प्रयोग गरी MCP सर्भरका उपकरणहरूसँग AI एजेन्ट बनाउने, चलाउने, र सुधार गर्नेछौं।

### -0- पूर्वतयारी, OpenAI GPT-4o मोडेल My Models मा थप्नुहोस्

अभ्यासले **GPT-4o** मोडेल प्रयोग गर्छ। एजेन्ट बनाउनुअघि यो मोडेल **My Models** मा थप्नुपर्छ।

![Visual Studio Code को AI Toolkit विस्तारमा मोडेल चयन इन्टरफेसको स्क्रिनशट। शीर्षकमा “Find the right model for your AI Solution” लेखिएको छ र उपशीर्षकले AI मोडेलहरू पत्ता लगाउन, परीक्षण गर्न, र तैनाथ गर्न प्रोत्साहित गर्दछ। “Popular Models” अन्तर्गत छ वटा मोडेल कार्डहरू छन्: DeepSeek-R1 (GitHub होस्ट गरिएको), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - सानो, छिटो), र DeepSeek-R1 (Ollama होस्ट गरिएको)। प्रत्येक कार्डमा “Add” र “Try in Playground” विकल्पहरू छन्।](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.ne.png)

1. **Activity Bar** बाट **AI Toolkit** विस्तार खोल्नुहोस्।
1. **Catalog** सेक्सनमा गएर **Models** चयन गर्नुहोस्, जसले **Model Catalog** नयाँ एडिटर ट्याबमा खोल्छ।
1. **Model Catalog** को सर्च बारमा **OpenAI GPT-4o** टाइप गर्नुहोस्।
1. **+ Add** क्लिक गरी मोडेललाई **My Models** सूचीमा थप्नुहोस्। पक्का गर्नुहोस् कि तपाईंले **GitHub होस्ट गरिएको** मोडेल चयन गर्नुभएको छ।
1. **Activity Bar** मा हेर्नुहोस् कि **OpenAI GPT-4o** मोडेल सूचीमा देखिन्छ।

### -1- एजेन्ट बनाउने

**Agent (Prompt) Builder** ले तपाईंलाई आफ्नै AI-सञ्चालित एजेन्टहरू सिर्जना र अनुकूलन गर्न सक्षम बनाउँछ। यस खण्डमा, नयाँ एजेन्ट बनाउने र संवादका लागि मोडेल चयन गर्नेछौं।

![AI Toolkit विस्तारमा "Calculator Agent" बिल्डर इन्टरफेसको स्क्रिनशट। बाँया प्यानलमा मोडेल "OpenAI GPT-4o (via GitHub)" चयन गरिएको छ। सिस्टम प्रॉम्प्टमा "You are a professor in university teaching math" लेखिएको छ, र युजर प्रॉम्प्टमा "Explain to me the Fourier equation in simple terms" छ। थप विकल्पहरूमा उपकरणहरू थप्ने, MCP Server सक्षम गर्ने, र संरचित आउटपुट चयन गर्ने बटनहरू छन्। तल नीलो “Run” बटन छ। दाहिने प्यानलमा "Get Started with Examples" अन्तर्गत तीन नमुना एजेन्टहरू छन्: Web Developer (MCP Server सहित), Second-Grade Simplifier, र Dream Interpreter, प्रत्येकको छोटो वर्णनसहित।](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.ne.png)

1. **Activity Bar** बाट **AI Toolkit** विस्तार खोल्नुहोस्।
1. **Tools** सेक्सनमा गएर **Agent (Prompt) Builder** चयन गर्नुहोस्। यसले नयाँ एडिटर ट्याबमा खोल्छ।
1. **+ New Agent** बटन क्लिक गर्नुहोस्। विस्तारले **Command Palette** मार्फत सेटअप विजार्ड सुरु गर्नेछ।
1. नाम **Calculator Agent** टाइप गरी **Enter** थिच्नुहोस्।
1. **Agent (Prompt) Builder** मा **Model** फिल्डमा **OpenAI GPT-4o (via GitHub)** मोडेल चयन गर्नुहोस्।

### -2- एजेन्टको लागि सिस्टम प्रॉम्प्ट बनाउने

एजेन्ट तयार भएपछि, यसको व्यक्तित्व र उद्देश्य निर्धारण गर्ने बेला आयो। यस खण्डमा, **Generate system prompt** सुविधा प्रयोग गरेर एजेन्टको व्यवहार वर्णन गर्ने प्रॉम्प्ट मोडेललाई लेख्न लगाउनेछौं—यस अवस्थामा, क्याल्कुलेटर एजेन्टको लागि।

![AI Toolkit मा "Calculator Agent" इन्टरफेसको स्क्रिनशट, जहाँ "Generate a prompt" शीर्षकको मोडल विन्डो खुल्ला छ। मोडलले बताउँछ कि आधारभूत विवरण साझेदारी गरेर प्रॉम्प्ट टेम्प्लेट सिर्जना गर्न सकिन्छ। टेक्स्ट बक्समा नमुना सिस्टम प्रॉम्प्ट छ: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." तल "Close" र "Generate" बटनहरू छन्। पृष्ठभूमिमा एजेन्ट कन्फिगरेसन देखिन्छ, चयन गरिएको मोडेल "OpenAI GPT-4o (via GitHub)" सहित, र सिस्टम तथा युजर प्रॉम्प्ट फिल्डहरू।](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.ne.png)

1. **Prompts** सेक्सनमा **Generate system prompt** बटन क्लिक गर्नुहोस्। यसले AI प्रयोग गरेर सिस्टम प्रॉम्प्ट सिर्जना गर्ने प्रॉम्प्ट बिल्डर खोल्छ।
1. **Generate a prompt** विन्डोमा निम्न लेख्नुहोस्: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** बटन क्लिक गर्नुहोस्। तल-दायाँ कुनामा एक सूचना देखिनेछ कि सिस्टम प्रॉम्प्ट सिर्जना भइरहेको छ। प्रक्रिया पूरा भएपछि प्रॉम्प्ट **Agent (Prompt) Builder** को **System prompt** फिल्डमा देखा पर्नेछ।
1. सिस्टम प्रॉम्प्ट समीक्षा गरी आवश्यक परे परिवर्तन गर्नुहोस्।

### -3- MCP सर्भर बनाउने

अब तपाईंले एजेन्टको सिस्टम प्रॉम्प्ट परिभाषित गर्नुभयो—यसले यसको व्यवहार र जवाफहरू निर्देशन गर्छ—अब एजेन्टलाई व्यवहारिक क्षमता दिनु पर्छ। यस खण्डमा, गणना गर्ने उपकरणहरू सहित क्याल्कुलेटर MCP सर्भर बनाउनेछौं जसले जोड, घटाउ, गुणा, र भाग गर्न सक्छ। यसले एजेन्टलाई प्राकृतिक भाषाबाट गणितीय अपरेसनहरू वास्तविक समयमा गर्न सक्षम बनाउँछ।

![AI Toolkit विस्तारमा Calculator Agent इन्टरफेसको तल भागको स्क्रिनशट। “Tools” र “Structure output” विस्तारयोग्य मेनुहरू देखिन्छन्, साथै “Choose output format” ड्रपडाउन “text” मा सेट गरिएको छ। दाहिनेपट्टि “+ MCP Server” बटन छ। उपकरण सेक्सनमाथि एउटा इमेज आइकन प्लेसहोल्डर छ।](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.ne.png)

AI Toolkit मा आफ्नै MCP सर्भर बनाउन सजिलो बनाउन टेम्प्लेटहरू उपलब्ध छन्। हामी Python टेम्प्लेट प्रयोग गर्नेछौं।

*Note*: AI Toolkit हाल Python र TypeScript समर्थन गर्छ।

1. **Agent (Prompt) Builder** को **Tools** सेक्सनमा **+ MCP Server** बटन क्लिक गर्नुहोस्। विस्तारले **Command Palette** मार्फत सेटअप विजार्ड सुरु गर्नेछ।
1. **+ Add Server** चयन गर्नुहोस्।
1. **Create a New MCP Server** चयन गर्नुहोस्।
1. टेम्प्लेटको रूपमा **python-weather** चयन गर्नुहोस्।
1. MCP सर्भर टेम्प्लेट सुरक्षित गर्न **Default folder** चयन गर्नुहोस्।
1. सर्भरको नाम **Calculator** राख्नुहोस्।
1. नयाँ Visual Studio Code विन्डो खुल्नेछ। **Yes, I trust the authors** चयन गर्नुहोस्।
1. टर्मिनल खोल्नुहोस् (**Terminal** > **New Terminal**) र भर्चुअल वातावरण सिर्जना गर्नुहोस्: `python -m venv .venv`
1. टर्मिनलबाट भर्चुअल वातावरण सक्रिय गर्नुहोस्:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. निर्भरता इन्स्टल गर्नुहोस्: `pip install -e .[dev]`
1. **Explorer** दृश्यमा **src** डाइरेक्टरी विस्तार गरी **server.py** फाइल खोल्नुहोस्।
1. **server.py** को कोड तल दिइएकोसँग प्रतिस्थापन गरी सुरक्षित गर्नुहोस्:

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

अब एजेन्टसँग उपकरणहरू छन्, तिनीहरू प्रयोग गर्ने बेला आयो! यस खण्डमा, एजेन्टलाई सोधेर परीक्षण गर्नेछौं कि एजेन्टले क्याल्कुलेटर MCP सर्भरबाट उपयुक्त उपकरण प्रयोग गरिरहेको छ कि छैन।

![AI Toolkit विस्तारमा Calculator Agent इन्टरफेसको स्क्रिनशट। बाँया प्यानलमा “Tools” अन्तर्गत local-server-calculator_server नामको MCP सर्भर थपिएको छ जसमा चार उपकरणहरू छन्: add, subtract, multiply, र divide। एउटा ब्याज देखिन्छ जसले चार उपकरणहरू सक्रिय छन् भन्छ। तल “Structure output” सेक्सन संकुचित छ र नीलो “Run” बटन छ। दाहिने प्यानलमा “Model Response” अन्तर्गत एजेन्टले multiply र subtract उपकरणहरू क्रमशः {"a": 3, "b": 25} र {"a": 75, "b": 20} इनपुटसहित कल गरेको छ। अन्तिम “Tool Response” 75.0 देखाइएको छ। तल “View Code” बटन छ।](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.ne.png)

तपाईंले आफ्नो स्थानीय विकास मेसिनमा **Agent Builder** मार्फत क्याल्कुलेटर MCP सर्भर चलाउनेछौं जुन MCP क्लाइन्टको रूपमा काम गर्छ।

1. `F5` थिच्नुहोस्।
2. तल दिइएको उदाहरण जस्तो सोधपुछ पठाउनुहोस्:  
   `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`  
   यहाँ `a` र `b` मानहरू **subtract** उपकरणका लागि निर्दिष्ट गरिएका छन्।  
   - प्रत्येक उपकरणबाट प्राप्त प्रतिक्रिया **Tool Response** मा देखिनेछ।  
   - मोडेलबाट अन्तिम जवाफ **Model Response** मा देखिनेछ।
3. थप सोधपुछहरू पठाएर एजेन्ट परीक्षण गर्नुहोस्। **User prompt** फिल्डमा क्लिक गरी वर्तमान प्रॉम्प्ट परिवर्तन गर्न सक्नुहुन्छ।
4. परीक्षण सकिएपछि, टर्मिनलमा **CTRL/CMD+C** थिचेर सर्भर बन्द गर्न सक्नुहुन्छ।

## कार्य

तपाईंको **server.py** फाइलमा एउटा नयाँ उपकरण थप्ने प्रयास गर्नुहोस् (जस्तै: कुनै सङ्ख्याको वर्गमूल फर्काउने)। एजेन्टलाई नयाँ उपकरण (वा अवस्थित उपकरणहरू) प्रयोग गर्नुपर्ने थप सोधपुछहरू पठाउनुहोस्। नयाँ उपकरणहरू लोड गर्न सर्भर पुनः सुरु गर्न नबिर्सनुहोस्।

## समाधान

[Solution](./solution/README.md)

## मुख्य बुँदाहरू

यस अध्यायका मुख्य बुँदाहरू:

- AI Toolkit विस्तारले MCP सर्भर र उपकरणहरू सजिलै प्रयोग गर्न सकिन्छ।
- MCP सर्भरमा नयाँ उपकरणहरू थपेर एजेन्टका क्षमता विस्तार गर्न सकिन्छ।
- AI Toolkit मा Python MCP सर्भर टेम्प्लेट जस्ता टेम्प्लेटहरू छन् जसले कस्टम उपकरणहरू सिर्जना गर्न सजिलो बनाउँछ।

## थप स्रोतहरू

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## के गर्ने अर्को

अर्को: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धता हुनसक्छ। मूल दस्तावेज यसको मूल भाषामा अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याहरूको लागि हामी जिम्मेवार छैनौं।