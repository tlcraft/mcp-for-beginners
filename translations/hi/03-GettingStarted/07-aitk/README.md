<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:29:24+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "hi"
}
-->
# Visual Studio Code के AI Toolkit एक्सटेंशन से सर्वर का उपयोग करना

जब आप एक AI एजेंट बना रहे होते हैं, तो केवल स्मार्ट जवाब देने की बात नहीं होती; बल्कि अपने एजेंट को कार्रवाई करने की क्षमता देना भी जरूरी होता है। यहीं पर Model Context Protocol (MCP) काम आता है। MCP एजेंट्स को बाहरी टूल्स और सेवाओं तक एक समान तरीके से पहुंचने में मदद करता है। इसे ऐसे समझें जैसे आप अपने एजेंट को एक ऐसा टूलबॉक्स देते हैं जिसे वह *वास्तव में* इस्तेमाल कर सकता है।

मान लीजिए आप अपने एजेंट को एक कैलकुलेटर MCP सर्वर से जोड़ते हैं। अचानक, आपका एजेंट गणितीय ऑपरेशन कर सकता है बस एक प्रॉम्प्ट जैसे “47 गुना 89 कितना होता है?” मिलने पर—कोई हार्डकोडेड लॉजिक या कस्टम API बनाने की जरूरत नहीं।

## अवलोकन

यह पाठ Visual Studio Code में [AI Toolkit](https://aka.ms/AIToolkit) एक्सटेंशन के साथ एक कैलकुलेटर MCP सर्वर को एजेंट से जोड़ने के बारे में है, जिससे आपका एजेंट प्राकृतिक भाषा के माध्यम से जोड़, घटाव, गुणा और भाग जैसे गणितीय ऑपरेशन कर सके।

AI Toolkit Visual Studio Code के लिए एक शक्तिशाली एक्सटेंशन है जो एजेंट विकास को सरल बनाता है। AI इंजीनियर आसानी से स्थानीय या क्लाउड में जनरेटिव AI मॉडल विकसित और परीक्षण कर सकते हैं। यह एक्सटेंशन आज उपलब्ध अधिकांश प्रमुख जनरेटिव मॉडल का समर्थन करता है।

*Note*: AI Toolkit वर्तमान में Python और TypeScript का समर्थन करता है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- AI Toolkit के माध्यम से MCP सर्वर का उपयोग करना।
- एजेंट कॉन्फ़िगरेशन सेट करना ताकि वह MCP सर्वर द्वारा प्रदान किए गए टूल्स को खोज और उपयोग कर सके।
- प्राकृतिक भाषा के जरिए MCP टूल्स का उपयोग करना।

## दृष्टिकोण

उच्च स्तर पर हमें इस तरह आगे बढ़ना है:

- एक एजेंट बनाएं और उसका सिस्टम प्रॉम्प्ट परिभाषित करें।
- कैलकुलेटर टूल्स के साथ एक MCP सर्वर बनाएं।
- Agent Builder को MCP सर्वर से कनेक्ट करें।
- प्राकृतिक भाषा के जरिए एजेंट के टूल इनवोकेशन का परीक्षण करें।

बहुत बढ़िया, अब जब हमें प्रक्रिया समझ आ गई है, तो चलिए MCP के माध्यम से बाहरी टूल्स का उपयोग करने के लिए AI एजेंट को कॉन्फ़िगर करते हैं और उसकी क्षमताओं को बढ़ाते हैं!

## आवश्यकताएँ

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## अभ्यास: सर्वर का उपयोग करना

इस अभ्यास में, आप Visual Studio Code में AI Toolkit का उपयोग करके MCP सर्वर से टूल्स के साथ एक AI एजेंट बनाएंगे, चलाएंगे और बेहतर बनाएंगे।

### -0- प्रारंभिक चरण, OpenAI GPT-4o मॉडल को My Models में जोड़ें

यह अभ्यास **GPT-4o** मॉडल का उपयोग करता है। एजेंट बनाने से पहले यह मॉडल **My Models** में जोड़ा जाना चाहिए।

![Visual Studio Code के AI Toolkit एक्सटेंशन में मॉडल चयन इंटरफ़ेस का स्क्रीनशॉट। शीर्षक है "Find the right model for your AI Solution" और उपशीर्षक उपयोगकर्ताओं को AI मॉडल खोजने, परीक्षण करने और तैनात करने के लिए प्रोत्साहित करता है। "Popular Models" के तहत छह मॉडल कार्ड दिखाए गए हैं: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), और DeepSeek-R1 (Ollama-hosted)। प्रत्येक कार्ड में "Add" और "Try in Playground" विकल्प हैं।](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.hi.png)

1. **Activity Bar** से **AI Toolkit** एक्सटेंशन खोलें।
2. **Catalog** सेक्शन में, **Models** चुनें ताकि **Model Catalog** खुले। Models चुनने पर Model Catalog एक नए एडिटर टैब में खुलता है।
3. Model Catalog के सर्च बार में **OpenAI GPT-4o** टाइप करें।
4. **+ Add** पर क्लिक करें ताकि मॉडल आपकी **My Models** सूची में जुड़ जाए। सुनिश्चित करें कि आपने GitHub द्वारा होस्ट किया गया मॉडल चुना है।
5. Activity Bar में पुष्टि करें कि **OpenAI GPT-4o** मॉडल सूची में दिखाई दे रहा है।

### -1- एक एजेंट बनाएं

**Agent (Prompt) Builder** आपको अपने AI-संचालित एजेंट बनाने और कस्टमाइज़ करने की सुविधा देता है। इस भाग में, आप एक नया एजेंट बनाएंगे और बातचीत के लिए एक मॉडल असाइन करेंगे।

![AI Toolkit एक्सटेंशन में "Calculator Agent" बिल्डर इंटरफ़ेस का स्क्रीनशॉट। बाएं पैनल में चुना गया मॉडल "OpenAI GPT-4o (via GitHub)" है। सिस्टम प्रॉम्प्ट में लिखा है "You are a professor in university teaching math," और यूजर प्रॉम्प्ट में "Explain to me the Fourier equation in simple terms." अतिरिक्त विकल्पों में टूल जोड़ना, MCP Server सक्षम करना, और संरचित आउटपुट चुनना शामिल हैं। नीचे नीला "Run" बटन है। दाएं पैनल में "Get Started with Examples" के तहत तीन नमूना एजेंट सूचीबद्ध हैं: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter के साथ)।](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.hi.png)

1. **Activity Bar** से **AI Toolkit** एक्सटेंशन खोलें।
2. **Tools** सेक्शन में, **Agent (Prompt) Builder** चुनें। यह एक नए एडिटर टैब में खुलेगा।
3. **+ New Agent** बटन पर क्लिक करें। एक्सटेंशन **Command Palette** के माध्यम से सेटअप विज़ार्ड लॉन्च करेगा।
4. नाम के रूप में **Calculator Agent** दर्ज करें और **Enter** दबाएं।
5. **Agent (Prompt) Builder** में, **Model** फ़ील्ड के लिए **OpenAI GPT-4o (via GitHub)** मॉडल चुनें।

### -2- एजेंट के लिए सिस्टम प्रॉम्प्ट बनाएं

एजेंट तैयार हो गया है, अब उसकी पर्सनैलिटी और उद्देश्य निर्धारित करने का समय है। इस भाग में, आप **Generate system prompt** फीचर का उपयोग करके एजेंट के व्यवहार का वर्णन करेंगे—यहाँ एक कैलकुलेटर एजेंट के रूप में—और मॉडल से सिस्टम प्रॉम्प्ट लिखवाएंगे।

![AI Toolkit के Calculator Agent इंटरफ़ेस का स्क्रीनशॉट जिसमें "Generate a prompt" नामक एक मोडल विंडो खुली है। मोडल में बताया गया है कि बेसिक जानकारी साझा करके प्रॉम्प्ट टेम्पलेट बनाया जा सकता है। टेक्स्ट बॉक्स में नमूना सिस्टम प्रॉम्प्ट है: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." नीचे "Close" और "Generate" बटन हैं। पृष्ठभूमि में एजेंट कॉन्फ़िगरेशन का हिस्सा दिख रहा है, जिसमें चुना गया मॉडल "OpenAI GPT-4o (via GitHub)" और सिस्टम व यूजर प्रॉम्प्ट फील्ड्स हैं।](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.hi.png)

1. **Prompts** सेक्शन में, **Generate system prompt** बटन पर क्लिक करें। यह प्रॉम्प्ट बिल्डर खोलेगा जो AI का उपयोग करके सिस्टम प्रॉम्प्ट बनाएगा।
2. **Generate a prompt** विंडो में निम्नलिखित दर्ज करें: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** बटन पर क्लिक करें। नीचे-दाएं कोने में एक नोटिफिकेशन आएगा जो पुष्टि करेगा कि सिस्टम प्रॉम्प्ट बन रहा है। प्रॉम्प्ट बनने के बाद यह **Agent (Prompt) Builder** के **System prompt** फ़ील्ड में दिखेगा।
4. सिस्टम प्रॉम्प्ट की समीक्षा करें और आवश्यकतानुसार संशोधित करें।

### -3- एक MCP सर्वर बनाएं

अब जब आपने एजेंट का सिस्टम प्रॉम्प्ट परिभाषित कर दिया है—जो उसके व्यवहार और प्रतिक्रियाओं को निर्देशित करता है—तो इसे व्यावहारिक क्षमताओं से लैस करने का समय है। इस भाग में, आप एक कैलकुलेटर MCP सर्वर बनाएंगे जिसमें जोड़, घटाव, गुणा और भाग के टूल होंगे। यह सर्वर आपके एजेंट को प्राकृतिक भाषा प्रॉम्प्ट के जवाब में वास्तविक समय गणितीय ऑपरेशन करने में सक्षम बनाएगा।

![AI Toolkit एक्सटेंशन में Calculator Agent इंटरफ़ेस के निचले हिस्से का स्क्रीनशॉट। इसमें “Tools” और “Structure output” के लिए एक्सपैंडेबल मेनू हैं, साथ ही “Choose output format” ड्रॉपडाउन है जो “text” पर सेट है। दाईं ओर “+ MCP Server” बटन है जो Model Context Protocol सर्वर जोड़ने के लिए है। टूल्स सेक्शन के ऊपर एक इमेज आइकन प्लेसहोल्डर भी दिख रहा है।](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.hi.png)

AI Toolkit में अपने MCP सर्वर बनाने के लिए टेम्प्लेट उपलब्ध हैं। हम कैलकुलेटर MCP सर्वर बनाने के लिए Python टेम्प्लेट का उपयोग करेंगे।

*Note*: AI Toolkit वर्तमान में Python और TypeScript का समर्थन करता है।

1. **Agent (Prompt) Builder** के **Tools** सेक्शन में, **+ MCP Server** बटन पर क्लिक करें। एक्सटेंशन **Command Palette** के माध्यम से सेटअप विज़ार्ड लॉन्च करेगा।
2. **+ Add Server** चुनें।
3. **Create a New MCP Server** चुनें।
4. टेम्प्लेट के रूप में **python-weather** चुनें।
5. MCP सर्वर टेम्प्लेट को सेव करने के लिए **Default folder** चुनें।
6. सर्वर का नाम दर्ज करें: **Calculator**
7. एक नया Visual Studio Code विंडो खुलेगा। **Yes, I trust the authors** चुनें।
8. टर्मिनल में (Terminal > New Terminal) वर्चुअल एनवायरनमेंट बनाएं: `python -m venv .venv`
9. टर्मिनल में वर्चुअल एनवायरनमेंट सक्रिय करें:
    - Windows - `.venv\Scripts\activate`
    - macOS/Linux - `source venv/bin/activate`
10. टर्मिनल में डिपेंडेंसी इंस्टॉल करें: `pip install -e .[dev]`
11. **Activity Bar** के **Explorer** व्यू में, **src** डायरेक्टरी को एक्सपैंड करें और **server.py** फाइल खोलें।
12. **server.py** की कोड को नीचे दिए गए कोड से बदलें और सेव करें:

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

अब जब आपके एजेंट के पास टूल्स हैं, तो उन्हें इस्तेमाल करने का समय है! इस भाग में, आप एजेंट को प्रॉम्प्ट भेजेंगे ताकि यह जांचा जा सके कि एजेंट कैलकुलेटर MCP सर्वर के सही टूल का उपयोग कर रहा है या नहीं।

![AI Toolkit एक्सटेंशन में Calculator Agent इंटरफ़ेस का स्क्रीनशॉट। बाएं पैनल में “Tools” के तहत एक MCP सर्वर local-server-calculator_server जोड़ा गया है, जिसमें चार टूल्स हैं: add, subtract, multiply, और divide। एक बैज दिखाता है कि चार टूल सक्रिय हैं। नीचे “Structure output” सेक्शन कोलैप्स्ड है और नीला “Run” बटन है। दाएं पैनल में “Model Response” के तहत एजेंट ने multiply और subtract टूल्स को इनपुट {"a": 3, "b": 25} और {"a": 75, "b": 20} के साथ इनवोक किया है। अंतिम “Tool Response” 75.0 दिखा रहा है। नीचे “View Code” बटन है।](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.hi.png)

आप अपने लोकल डेव मशीन पर **Agent Builder** के माध्यम से MCP क्लाइंट के रूप में कैलकुलेटर MCP सर्वर चलाएंगे।

1. `F5` दबाएं ताकि MCP सर्वर डिबगिंग शुरू हो। **Agent (Prompt) Builder** एक नए एडिटर टैब में खुलेगा। टर्मिनल में सर्वर की स्थिति देखी जा सकती है।
2. **Agent (Prompt) Builder** के **User prompt** फ़ील्ड में निम्नलिखित प्रॉम्प्ट दर्ज करें: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. एजेंट की प्रतिक्रिया उत्पन्न करने के लिए **Run** बटन पर क्लिक करें।
4. एजेंट आउटपुट की समीक्षा करें। मॉडल को यह निष्कर्ष निकालना चाहिए कि आपने **$55** का भुगतान किया।
5. यहाँ क्या होना चाहिए इसका विवरण:
    - एजेंट गणना में मदद के लिए **multiply** और **subtract** टूल्स का चयन करता है।
    - **multiply** टूल के लिए `a` और `b` मान निर्धारित किए जाते हैं।
    - **subtract** टूल के लिए `a` और `b` मान निर्धारित किए जाते हैं।
    - प्रत्येक टूल से प्रतिक्रिया संबंधित **Tool Response** में दी जाती है।
    - अंतिम आउटपुट मॉडल के अंतिम **Model Response** में दिया जाता है।
6. एजेंट का और परीक्षण करने के लिए अतिरिक्त प्रॉम्प्ट सबमिट करें। आप **User prompt** फ़ील्ड में जाकर मौजूदा प्रॉम्प्ट को बदल सकते हैं।
7. परीक्षण पूरा होने पर, आप टर्मिनल में **CTRL/CMD+C** दबाकर सर्वर बंद कर सकते हैं।

## असाइनमेंट

अपने **server.py** फाइल में एक अतिरिक्त टूल एंट्री जोड़ने का प्रयास करें (जैसे: किसी संख्या का वर्गमूल लौटाना)। ऐसे अतिरिक्त प्रॉम्प्ट सबमिट करें जिनके लिए एजेंट को आपके नए टूल (या मौजूदा टूल्स) का उपयोग करना पड़े। नए टूल्स लोड करने के लिए सर्वर को पुनः शुरू करना न भूलें।

## समाधान

[Solution](./solution/README.md)

## मुख्य बातें

इस अध्याय से मुख्य बातें निम्नलिखित हैं:

- AI Toolkit एक्सटेंशन एक बेहतरीन क्लाइंट है जो आपको MCP सर्वर और उनके टूल्स का उपयोग करने देता है।
- आप MCP सर्वर में नए टूल जोड़ सकते हैं, जिससे एजेंट की क्षमताएं बढ़ती हैं और बदलती आवश्यकताओं को पूरा करती हैं।
- AI Toolkit में टेम्प्लेट शामिल हैं (जैसे Python MCP सर्वर टेम्प्लेट) जो कस्टम टूल्स बनाने को सरल बनाते हैं।

## अतिरिक्त संसाधन

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## आगे क्या है
- अगला: [Testing & Debugging](../08-testing/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।