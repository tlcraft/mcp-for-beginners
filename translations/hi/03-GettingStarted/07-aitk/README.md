<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-12T22:30:23+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "hi"
}
-->
# Visual Studio Code के AI Toolkit एक्सटेंशन से सर्वर का उपयोग करना

जब आप एक AI एजेंट बना रहे होते हैं, तो सिर्फ स्मार्ट जवाब देना ही महत्वपूर्ण नहीं होता; आपके एजेंट को कार्रवाई करने की क्षमता भी होनी चाहिए। यहीं Model Context Protocol (MCP) काम आता है। MCP एजेंट्स को बाहरी टूल्स और सेवाओं तक एक समान तरीके से पहुंचने में मदद करता है। इसे ऐसे समझें जैसे आप अपने एजेंट को एक ऐसा टूलबॉक्स देते हैं जिसे वह *वास्तव में* इस्तेमाल कर सके।

मान लीजिए आप अपने एजेंट को आपके कैलकुलेटर MCP सर्वर से कनेक्ट करते हैं। अचानक, आपका एजेंट सिर्फ एक प्रॉम्प्ट जैसे “47 गुना 89 कितना होता है?” प्राप्त करके गणितीय ऑपरेशन कर सकता है—कोडिंग करने या कस्टम API बनाने की जरूरत नहीं।

## अवलोकन

यह पाठ Visual Studio Code में [AI Toolkit](https://aka.ms/AIToolkit) एक्सटेंशन के साथ एक कैलकुलेटर MCP सर्वर को एजेंट से कनेक्ट करने के बारे में है, जिससे आपका एजेंट प्राकृतिक भाषा के जरिए जोड़, घटाव, गुणा, और भाग जैसे गणितीय ऑपरेशन कर सके।

AI Toolkit Visual Studio Code के लिए एक शक्तिशाली एक्सटेंशन है जो एजेंट विकास को सरल बनाता है। AI इंजीनियर स्थानीय या क्लाउड में जेनरेटिव AI मॉडल विकसित और परीक्षण करके आसानी से AI एप्लिकेशन बना सकते हैं। यह एक्सटेंशन आज उपलब्ध अधिकांश प्रमुख जेनरेटिव मॉडल का समर्थन करता है।

*Note*: AI Toolkit फिलहाल Python और TypeScript का समर्थन करता है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- AI Toolkit के माध्यम से MCP सर्वर का उपयोग करना।
- एजेंट कॉन्फ़िगरेशन सेट करना ताकि वह MCP सर्वर द्वारा प्रदान किए गए टूल्स को खोज और उपयोग कर सके।
- प्राकृतिक भाषा के जरिए MCP टूल्स का उपयोग करना।

## दृष्टिकोण

हम इसे उच्च स्तर पर इस तरह करेंगे:

- एक एजेंट बनाएं और उसका सिस्टम प्रॉम्प्ट परिभाषित करें।
- कैलकुलेटर टूल्स के साथ MCP सर्वर बनाएं।
- Agent Builder को MCP सर्वर से कनेक्ट करें।
- प्राकृतिक भाषा के जरिए एजेंट के टूल इनवोकेशन का परीक्षण करें।

बहुत बढ़िया, अब जब हमें प्रक्रिया समझ आ गई है, तो चलिए MCP के माध्यम से बाहरी टूल्स का उपयोग करने के लिए AI एजेंट को कॉन्फ़िगर करते हैं और उसकी क्षमताओं को बढ़ाते हैं!

## पूर्वापेक्षाएँ

- [Visual Studio Code](https://code.visualstudio.microsoft.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## अभ्यास: एक सर्वर का उपयोग करना

इस अभ्यास में, आप Visual Studio Code में AI Toolkit का उपयोग करके MCP सर्वर से टूल्स वाले एक AI एजेंट को बनाएंगे, चलाएंगे और बेहतर बनाएंगे।

### -0- प्रीस्टेप, OpenAI GPT-4o मॉडल को My Models में जोड़ें

यह अभ्यास **GPT-4o** मॉडल का उपयोग करता है। एजेंट बनाने से पहले इस मॉडल को **My Models** में जोड़ना चाहिए।

![Visual Studio Code के AI Toolkit एक्सटेंशन में मॉडल चयन इंटरफ़ेस का स्क्रीनशॉट। शीर्षक है "Find the right model for your AI Solution" और सबटाइटल में AI मॉडल खोजने, परीक्षण करने और डिप्लॉय करने के लिए प्रोत्साहित किया गया है। नीचे “Popular Models” के अंतर्गत छह मॉडल कार्ड दिखाए गए हैं: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), और DeepSeek-R1 (Ollama-hosted)। हर कार्ड में “Add” और “Try in Playground” विकल्प हैं।](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.hi.png)

1. **Activity Bar** से **AI Toolkit** एक्सटेंशन खोलें।
1. **Catalog** सेक्शन में **Models** चुनें, जिससे **Model Catalog** एक नए एडिटर टैब में खुलेगा।
1. **Model Catalog** के सर्च बार में **OpenAI GPT-4o** टाइप करें।
1. **+ Add** पर क्लिक करके मॉडल को अपनी **My Models** सूची में जोड़ें। सुनिश्चित करें कि आपने **Hosted by GitHub** मॉडल चुना है।
1. **Activity Bar** में पुष्टि करें कि **OpenAI GPT-4o** मॉडल सूची में दिखाई दे रहा है।

### -1- एक एजेंट बनाएं

**Agent (Prompt) Builder** आपको अपना AI-पावर्ड एजेंट बनाने और कस्टमाइज़ करने देता है। इस चरण में, आप एक नया एजेंट बनाएंगे और बातचीत के लिए एक मॉडल असाइन करेंगे।

![Visual Studio Code के AI Toolkit एक्सटेंशन में "Calculator Agent" बिल्डर इंटरफ़ेस का स्क्रीनशॉट। बाएं पैनल में चुना गया मॉडल "OpenAI GPT-4o (via GitHub)" है। एक सिस्टम प्रॉम्प्ट में लिखा है "You are a professor in university teaching math," और यूजर प्रॉम्प्ट में "Explain to me the Fourier equation in simple terms." अतिरिक्त विकल्पों में टूल्स जोड़ना, MCP Server सक्षम करना, और स्ट्रक्चर्ड आउटपुट चुनना शामिल हैं। नीचे नीला “Run” बटन है। दाएं पैनल में "Get Started with Examples" के तहत तीन नमूना एजेंट सूचीबद्ध हैं: Web Developer (MCP Server के साथ), Second-Grade Simplifier, और Dream Interpreter, जिनके कार्यों का संक्षिप्त विवरण है।](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.hi.png)

1. **Activity Bar** से **AI Toolkit** एक्सटेंशन खोलें।
1. **Tools** सेक्शन में **Agent (Prompt) Builder** चुनें। यह एक नए एडिटर टैब में खुलेगा।
1. **+ New Agent** बटन पर क्लिक करें। यह कमांड पैलेट के जरिए सेटअप विज़ार्ड शुरू करेगा।
1. नाम के रूप में **Calculator Agent** दर्ज करें और **Enter** दबाएं।
1. **Agent (Prompt) Builder** में, **Model** फील्ड के लिए **OpenAI GPT-4o (via GitHub)** मॉडल चुनें।

### -2- एजेंट के लिए सिस्टम प्रॉम्प्ट बनाएं

एजेंट तैयार हो गया है, अब इसकी पर्सनैलिटी और उद्देश्य निर्धारित करने का समय है। इस चरण में, आप **Generate system prompt** फीचर का उपयोग करके एजेंट के व्यवहार का विवरण देंगे—यहाँ एक कैलकुलेटर एजेंट—और मॉडल से सिस्टम प्रॉम्प्ट लिखवाएंगे।

![Visual Studio Code के AI Toolkit में "Calculator Agent" इंटरफ़ेस का स्क्रीनशॉट जिसमें "Generate a prompt" शीर्षक वाली एक मोडल विंडो खुली है। मोडल बताती है कि प्रॉम्प्ट टेम्पलेट साझा करके बनाया जा सकता है। टेक्स्ट बॉक्स में उदाहरण सिस्टम प्रॉम्प्ट है: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." नीचे "Close" और "Generate" बटन हैं। पृष्ठभूमि में एजेंट कॉन्फ़िगरेशन का हिस्सा दिखाई दे रहा है जिसमें चुना गया मॉडल "OpenAI GPT-4o (via GitHub)" और सिस्टम व यूजर प्रॉम्प्ट फील्ड्स हैं।](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.hi.png)

1. **Prompts** सेक्शन में **Generate system prompt** बटन पर क्लिक करें। यह AI की मदद से सिस्टम प्रॉम्प्ट जनरेट करने वाला प्रॉम्प्ट बिल्डर खोलेगा।
1. **Generate a prompt** विंडो में निम्नलिखित दर्ज करें: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** बटन दबाएं। नीचे-दाएं कोने में एक नोटिफिकेशन दिखेगा कि सिस्टम प्रॉम्प्ट बन रहा है। प्रॉम्प्ट बनने के बाद यह **Agent (Prompt) Builder** के **System prompt** फील्ड में दिखेगा।
1. **System prompt** की समीक्षा करें और ज़रूरत हो तो संशोधित करें।

### -3- MCP सर्वर बनाएं

अब जब आपने एजेंट का सिस्टम प्रॉम्प्ट निर्धारित कर दिया है—जो इसके व्यवहार और जवाबों को निर्देशित करता है—तो इसे व्यावहारिक क्षमताओं से लैस करने का समय है। इस चरण में, आप जोड़, घटाव, गुणा, और भाग के लिए टूल्स वाले एक कैलकुलेटर MCP सर्वर बनाएंगे। यह सर्वर आपके एजेंट को प्राकृतिक भाषा प्रॉम्प्ट के जवाब में वास्तविक समय गणितीय ऑपरेशन करने में सक्षम करेगा।

![Visual Studio Code के AI Toolkit एक्सटेंशन में Calculator Agent इंटरफ़ेस के निचले हिस्से का स्क्रीनशॉट। इसमें “Tools” और “Structure output” के लिए एक्सपैंडेबल मेनू, “Choose output format” ड्रॉपडाउन (जिसमें “text” चुना हुआ है), और दाईं ओर "+ MCP Server" बटन दिख रहा है। टूल्स सेक्शन के ऊपर एक इमेज आइकन प्लेसहोल्डर भी है।](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.hi.png)

AI Toolkit में अपने MCP सर्वर बनाने के लिए टेम्प्लेट्स उपलब्ध हैं। हम कैलकुलेटर MCP सर्वर बनाने के लिए Python टेम्प्लेट का उपयोग करेंगे।

*Note*: AI Toolkit फिलहाल Python और TypeScript का समर्थन करता है।

1. **Agent (Prompt) Builder** के **Tools** सेक्शन में **+ MCP Server** बटन पर क्लिक करें। यह कमांड पैलेट के जरिए सेटअप विज़ार्ड शुरू करेगा।
1. **+ Add Server** चुनें।
1. **Create a New MCP Server** चुनें।
1. टेम्प्लेट के रूप में **python-weather** चुनें।
1. MCP सर्वर टेम्प्लेट को सेव करने के लिए **Default folder** चुनें।
1. सर्वर का नाम दर्ज करें: **Calculator**
1. एक नया Visual Studio Code विंडो खुलेगा। चुनें **Yes, I trust the authors**।
1. टर्मिनल (Terminal > New Terminal) में वर्चुअल एनवायरनमेंट बनाएं: `python -m venv .venv`
1. टर्मिनल में वर्चुअल एनवायरनमेंट एक्टिवेट करें:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. टर्मिनल में डिपेंडेंसीज़ इंस्टॉल करें: `pip install -e .[dev]`
1. **Activity Bar** में **Explorer** व्यू खोलें, **src** डायरेक्टरी एक्सपैंड करें और **server.py** फाइल खोलें।
1. **server.py** की पूरी कोड को नीचे दिए गए कोड से बदलें और सेव करें:

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

### -4- कैलकुलेटर MCP सर्वर के साथ एजेंट चलाएं

अब जब आपके एजेंट के पास टूल्स हैं, तो इन्हें इस्तेमाल करने का समय है! इस चरण में, आप एजेंट को प्रॉम्प्ट भेजेंगे ताकि यह जांच सकें कि एजेंट कैलकुलेटर MCP सर्वर के सही टूल का उपयोग करता है या नहीं।

![Visual Studio Code के AI Toolkit एक्सटेंशन में Calculator Agent इंटरफ़ेस का स्क्रीनशॉट। बाएं पैनल में “Tools” के अंतर्गत एक MCP सर्वर local-server-calculator_server जोड़ा गया है, जिसमें चार टूल्स उपलब्ध हैं: add, subtract, multiply, और divide। एक बैज दिखाता है कि चार टूल्स सक्रिय हैं। नीचे “Structure output” सेक्शन कॉलैप्स्ड है और नीला “Run” बटन है। दाएं पैनल में “Model Response” के तहत एजेंट ने multiply और subtract टूल्स को क्रमशः इनपुट {"a": 3, "b": 25} और {"a": 75, "b": 20} के साथ इनवोक किया है। अंतिम “Tool Response” 75.0 दिखा रहा है। नीचे “View Code” बटन भी है।](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.hi.png)

आप अपने लोकल डेव मशीन पर **Agent Builder** के माध्यम से MCP क्लाइंट के रूप में कैलकुलेटर MCP सर्वर चलाएंगे।

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` मान **subtract** टूल के लिए असाइन किए गए हैं।
    - हर टूल का जवाब संबंधित **Tool Response** में दिया जाएगा।
    - मॉडल का अंतिम आउटपुट अंतिम **Model Response** में दिखेगा।
1. एजेंट का और परीक्षण करने के लिए अतिरिक्त प्रॉम्प्ट सबमिट करें। आप **User prompt** फील्ड में क्लिक करके मौजूदा प्रॉम्प्ट को बदल सकते हैं।
1. परीक्षण पूरा होने पर, आप टर्मिनल में **CTRL/CMD+C** दबाकर सर्वर बंद कर सकते हैं।

## असाइनमेंट

अपने **server.py** फाइल में एक अतिरिक्त टूल एंट्री जोड़ने की कोशिश करें (जैसे किसी संख्या का वर्गमूल निकालना)। ऐसे अतिरिक्त प्रॉम्प्ट सबमिट करें जिनके लिए एजेंट को आपका नया टूल (या मौजूदा टूल) इस्तेमाल करना पड़े। नए टूल्स लोड करने के लिए सर्वर को पुनः शुरू करना न भूलें।

## समाधान

[Solution](./solution/README.md)

## मुख्य बातें

इस अध्याय से मुख्य बातें निम्नलिखित हैं:

- AI Toolkit एक्सटेंशन एक बेहतरीन क्लाइंट है जो आपको MCP सर्वर और उनके टूल्स का उपयोग करने देता है।
- आप MCP सर्वर में नए टूल्स जोड़ सकते हैं, जिससे एजेंट की क्षमताएं बढ़ती हैं और वह बदलती जरूरतों को पूरा कर सकता है।
- AI Toolkit में कस्टम टूल बनाने को आसान बनाने के लिए टेम्प्लेट्स (जैसे Python MCP सर्वर टेम्प्लेट्स) शामिल हैं।

## अतिरिक्त संसाधन

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## आगे क्या है
- अगला: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या गलतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।