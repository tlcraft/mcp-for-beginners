<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:31:06+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "hi"
}
-->
# Visual Studio Code के AI Toolkit एक्सटेंशन से सर्वर का उपयोग करना

जब आप एक AI एजेंट बना रहे होते हैं, तो यह सिर्फ स्मार्ट जवाब देने तक सीमित नहीं होता; बल्कि आपके एजेंट को कार्रवाई करने की क्षमता देना भी जरूरी है। यहीं Model Context Protocol (MCP) काम आता है। MCP एजेंट्स को बाहरी टूल्स और सेवाओं तक एक समान तरीके से पहुंचने में मदद करता है। इसे ऐसे समझिए जैसे आप अपने एजेंट को एक ऐसा टूलबॉक्स दे रहे हैं जिसका वह सचमुच इस्तेमाल कर सके।

मान लीजिए आप अपने एजेंट को आपके कैलकुलेटर MCP सर्वर से जोड़ते हैं। अचानक, आपका एजेंट सिर्फ “47 गुना 89 क्या है?” जैसे प्रॉम्प्ट पाने पर गणितीय ऑपरेशन कर सकता है—लॉजिक हार्डकोड करने या कस्टम API बनाने की जरूरत नहीं।

## अवलोकन

यह पाठ यह सिखाता है कि Visual Studio Code में [AI Toolkit](https://aka.ms/AIToolkit) एक्सटेंशन के साथ कैलकुलेटर MCP सर्वर को एजेंट से कैसे जोड़ा जाए, जिससे आपका एजेंट प्राकृतिक भाषा के जरिए जोड़, घटाव, गुणा और भाग जैसे गणितीय ऑपरेशन कर सके।

AI Toolkit Visual Studio Code के लिए एक शक्तिशाली एक्सटेंशन है जो एजेंट डेवलपमेंट को सरल बनाता है। AI इंजीनियर स्थानीय या क्लाउड में जनरेटिव AI मॉडल विकसित और परीक्षण करके आसानी से AI एप्लिकेशन बना सकते हैं। यह एक्सटेंशन आज उपलब्ध अधिकांश प्रमुख जनरेटिव मॉडल्स का समर्थन करता है।

*Note*: AI Toolkit वर्तमान में Python और TypeScript का समर्थन करता है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- AI Toolkit के माध्यम से MCP सर्वर का उपयोग करना।
- एजेंट कॉन्फ़िगरेशन सेट करना ताकि वह MCP सर्वर द्वारा प्रदान किए गए टूल्स को खोज और उपयोग कर सके।
- प्राकृतिक भाषा के जरिए MCP टूल्स का उपयोग करना।

## दृष्टिकोण

उच्च स्तर पर हमें इस प्रकार आगे बढ़ना है:

- एक एजेंट बनाएं और उसका सिस्टम प्रॉम्प्ट परिभाषित करें।
- कैलकुलेटर टूल्स के साथ एक MCP सर्वर बनाएं।
- एजेंट बिल्डर को MCP सर्वर से जोड़ें।
- प्राकृतिक भाषा के माध्यम से एजेंट के टूल इनवोकेशन का परीक्षण करें।

बहुत बढ़िया, अब जब हमें प्रवाह समझ में आ गया है, तो चलिए MCP के जरिए बाहरी टूल्स का उपयोग करने के लिए AI एजेंट को कॉन्फ़िगर करते हैं और इसकी क्षमताओं को बढ़ाते हैं!

## आवश्यकताएँ

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## अभ्यास: एक सर्वर का उपयोग करना

इस अभ्यास में, आप Visual Studio Code में AI Toolkit का उपयोग करके MCP सर्वर से टूल्स के साथ एक AI एजेंट बनाएंगे, चलाएंगे और बेहतर बनाएंगे।

### -0- प्रारंभिक कदम, My Models में OpenAI GPT-4o मॉडल जोड़ें

यह अभ्यास **GPT-4o** मॉडल का उपयोग करता है। एजेंट बनाने से पहले यह मॉडल **My Models** में जोड़ा जाना चाहिए।

![Visual Studio Code के AI Toolkit एक्सटेंशन में मॉडल चयन इंटरफ़ेस का स्क्रीनशॉट। शीर्षक में लिखा है "Find the right model for your AI Solution" और सबटाइटल में उपयोगकर्ताओं को AI मॉडल खोजने, परीक्षण करने और तैनात करने के लिए प्रोत्साहित किया गया है। "Popular Models" के अंतर्गत छह मॉडल कार्ड दिखाए गए हैं: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), और DeepSeek-R1 (Ollama-hosted)। प्रत्येक कार्ड में मॉडल को "Add" करने या "Try in Playground" विकल्प मौजूद हैं।](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.hi.png)

1. **Activity Bar** से **AI Toolkit** एक्सटेंशन खोलें।
2. **Catalog** सेक्शन में **Models** चुनें ताकि **Model Catalog** खुले। Models चुनने पर नया एडिटर टैब खुलता है।
3. **Model Catalog** के सर्च बार में **OpenAI GPT-4o** टाइप करें।
4. **+ Add** पर क्लिक करें ताकि मॉडल आपकी **My Models** सूची में जुड़ जाए। सुनिश्चित करें कि आपने GitHub-hosted मॉडल चुना है।
5. **Activity Bar** में पुष्टि करें कि **OpenAI GPT-4o** मॉडल सूची में दिखाई दे रहा है।

### -1- एक एजेंट बनाएं

**Agent (Prompt) Builder** आपको अपना AI-पावर्ड एजेंट बनाने और कस्टमाइज़ करने की सुविधा देता है। इस भाग में, आप एक नया एजेंट बनाएंगे और बातचीत के लिए एक मॉडल असाइन करेंगे।

![AI Toolkit एक्सटेंशन में "Calculator Agent" बिल्डर इंटरफ़ेस का स्क्रीनशॉट। बाएं पैनल में चुना गया मॉडल "OpenAI GPT-4o (via GitHub)" है। सिस्टम प्रॉम्प्ट में लिखा है "You are a professor in university teaching math," और यूज़र प्रॉम्प्ट में "Explain to me the Fourier equation in simple terms." टूल्स जोड़ने, MCP Server सक्षम करने और संरचित आउटपुट चुनने के विकल्प भी हैं। नीचे नीला “Run” बटन है। दाएं पैनल में "Get Started with Examples" के अंतर्गत तीन नमूना एजेंट्स सूचीबद्ध हैं: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter के साथ)।](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.hi.png)

1. **Activity Bar** से **AI Toolkit** एक्सटेंशन खोलें।
2. **Tools** सेक्शन में **Agent (Prompt) Builder** चुनें। यह नया एडिटर टैब खोलता है।
3. **+ New Agent** बटन पर क्लिक करें। सेटअप विज़ार्ड **Command Palette** के माध्यम से खुलेगा।
4. नाम के रूप में **Calculator Agent** दर्ज करें और **Enter** दबाएं।
5. **Agent (Prompt) Builder** में **Model** फ़ील्ड के लिए **OpenAI GPT-4o (via GitHub)** मॉडल चुनें।

### -2- एजेंट के लिए सिस्टम प्रॉम्प्ट बनाएं

एजेंट तैयार हो गया है, अब उसकी पर्सनालिटी और उद्देश्य निर्धारित करने का समय है। इस भाग में, आप **Generate system prompt** फीचर का उपयोग करेंगे ताकि एजेंट के व्यवहार का वर्णन किया जा सके—यहाँ एक कैलकुलेटर एजेंट के रूप में—और मॉडल आपके लिए सिस्टम प्रॉम्प्ट लिखेगा।

![AI Toolkit के Calculator Agent इंटरफ़ेस का स्क्रीनशॉट जिसमें "Generate a prompt" शीर्षक वाली एक मोडल विंडो खुली है। मोडल में बताया गया है कि बेसिक विवरण साझा करके प्रॉम्प्ट टेम्प्लेट बनाया जा सकता है। एक टेक्स्ट बॉक्स में नमूना सिस्टम प्रॉम्प्ट है: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." नीचे "Close" और "Generate" बटन हैं। पृष्ठभूमि में एजेंट कॉन्फ़िगरेशन का हिस्सा दिख रहा है, जिसमें चुना गया मॉडल "OpenAI GPT-4o (via GitHub)" और सिस्टम तथा यूज़र प्रॉम्प्ट फ़ील्ड्स हैं।](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.hi.png)

1. **Prompts** सेक्शन में **Generate system prompt** बटन पर क्लिक करें। यह बटन प्रॉम्प्ट बिल्डर खोलता है जो AI की मदद से सिस्टम प्रॉम्प्ट जनरेट करता है।
2. **Generate a prompt** विंडो में निम्नलिखित दर्ज करें: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** बटन पर क्लिक करें। नीचे-दाएं कोने में एक नोटिफिकेशन आएगा कि सिस्टम प्रॉम्प्ट जनरेट हो रहा है। पूरा होने पर प्रॉम्प्ट **Agent (Prompt) Builder** के **System prompt** फ़ील्ड में दिखेगा।
4. **System prompt** की समीक्षा करें और जरूरत हो तो संशोधन करें।

### -3- MCP सर्वर बनाएं

अब जब आपने एजेंट का सिस्टम प्रॉम्प्ट परिभाषित कर दिया है—जो उसके व्यवहार और प्रतिक्रियाओं का मार्गदर्शन करता है—तो इसे व्यावहारिक क्षमताओं से लैस करने का समय है। इस भाग में, आप जोड़, घटाव, गुणा और भाग करने वाले टूल्स के साथ एक कैलकुलेटर MCP सर्वर बनाएंगे। यह सर्वर आपके एजेंट को प्राकृतिक भाषा के प्रॉम्प्ट पर वास्तविक समय में गणितीय ऑपरेशन करने में सक्षम करेगा।

![Calculator Agent इंटरफ़ेस के निचले हिस्से का स्क्रीनशॉट जिसमें “Tools” और “Structure output” के लिए विस्तारित मेनू, “Choose output format” ड्रॉपडाउन (जो “text” पर सेट है) और दाईं ओर “+ MCP Server” बटन दिख रहा है। टूल्स सेक्शन के ऊपर एक इमेज आइकन प्लेसहोल्डर भी है।](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.hi.png)

AI Toolkit आपके लिए MCP सर्वर बनाने के लिए टेम्प्लेट प्रदान करता है। हम कैलकुलेटर MCP सर्वर बनाने के लिए Python टेम्प्लेट का उपयोग करेंगे।

*Note*: AI Toolkit वर्तमान में Python और TypeScript का समर्थन करता है।

1. **Agent (Prompt) Builder** के **Tools** सेक्शन में **+ MCP Server** बटन पर क्लिक करें। सेटअप विज़ार्ड **Command Palette** के माध्यम से खुलेगा।
2. **+ Add Server** चुनें।
3. **Create a New MCP Server** चुनें।
4. टेम्प्लेट के रूप में **python-weather** चुनें।
5. MCP सर्वर टेम्प्लेट सेव करने के लिए **Default folder** चुनें।
6. सर्वर का नाम दर्ज करें: **Calculator**
7. एक नया Visual Studio Code विंडो खुलेगा। चुनें **Yes, I trust the authors**।
8. टर्मिनल में जाएं (**Terminal** > **New Terminal**) और वर्चुअल एन्वायरनमेंट बनाएं: `python -m venv .venv`
9. टर्मिनल में वर्चुअल एन्वायरनमेंट सक्रिय करें:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. टर्मिनल में डिपेंडेंसियां इंस्टॉल करें: `pip install -e .[dev]`
11. **Activity Bar** के **Explorer** व्यू में **src** डायरेक्टरी को एक्सपैंड करें और **server.py** खोलें।
12. **server.py** में मौजूद कोड को निम्नलिखित से बदलें और सेव करें:

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

अब जब आपके एजेंट के पास टूल्स हैं, तो उनका उपयोग करने का समय है! इस भाग में, आप एजेंट को प्रॉम्प्ट भेजेंगे ताकि यह जांचा जा सके कि एजेंट कैलकुलेटर MCP सर्वर के उपयुक्त टूल का सही तरीके से उपयोग करता है या नहीं।

![Calculator Agent इंटरफ़ेस का स्क्रीनशॉट जिसमें बाएं पैनल में “Tools” के तहत एक MCP सर्वर local-server-calculator_server जोड़ा गया है, जिसमें चार टूल्स हैं: add, subtract, multiply, और divide। चार टूल्स सक्रिय होने का बैज दिख रहा है। नीचे “Structure output” सेक्शन को कोलैप्स किया गया है और नीला “Run” बटन है। दाएं पैनल में “Model Response” के तहत एजेंट multiply और subtract टूल्स को इनपुट्स {"a": 3, "b": 25} और {"a": 75, "b": 20} के साथ इनवोक करता है। अंतिम “Tool Response” 75.0 दिखाया गया है। नीचे “View Code” बटन है।](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.hi.png)

आप अपने लोकल डेवलपमेंट मशीन पर **Agent Builder** के माध्यम से MCP क्लाइंट के रूप में कैलकुलेटर MCP सर्वर चलाएंगे।

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` मान **subtract** टूल के लिए असाइन किए गए हैं।
    - प्रत्येक टूल की प्रतिक्रिया संबंधित **Tool Response** में दी जाती है।
    - मॉडल से अंतिम आउटपुट अंतिम **Model Response** में दिखाया जाता है।
2. एजेंट का और परीक्षण करने के लिए अतिरिक्त प्रॉम्प्ट सबमिट करें। आप **User prompt** फ़ील्ड में मौजूदा प्रॉम्प्ट पर क्लिक करके इसे बदल सकते हैं।
3. परीक्षण पूरा होने पर, टर्मिनल में **CTRL/CMD+C** दबाकर सर्वर बंद करें।

## असाइनमेंट

अपने **server.py** फाइल में एक अतिरिक्त टूल एंट्री जोड़ने की कोशिश करें (जैसे किसी संख्या का वर्गमूल निकालना)। ऐसे प्रॉम्प्ट सबमिट करें जिनके लिए एजेंट को आपके नए टूल (या मौजूदा टूल्स) का उपयोग करना पड़े। नए टूल्स लोड करने के लिए सर्वर को पुनः चालू करना न भूलें।

## समाधान

[Solution](./solution/README.md)

## मुख्य बातें

इस अध्याय से मुख्य सीख निम्नलिखित हैं:

- AI Toolkit एक्सटेंशन एक बढ़िया क्लाइंट है जो आपको MCP सर्वर और उनके टूल्स का उपयोग करने देता है।
- आप MCP सर्वर में नए टूल्स जोड़ सकते हैं, जिससे एजेंट की क्षमताएं बढ़ती हैं और आवश्यकताओं के अनुसार विकसित होती हैं।
- AI Toolkit में टेम्प्लेट्स (जैसे Python MCP सर्वर टेम्प्लेट्स) शामिल हैं जो कस्टम टूल्स बनाने को आसान बनाते हैं।

## अतिरिक्त संसाधन

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## आगे क्या है

अगला: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**अस्वीकरण**:  
इस दस्तावेज़ का अनुवाद AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।