<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:18:08+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "hi"
}
-->
# Visual Studio Code के लिए AI Toolkit एक्सटेंशन से सर्वर का उपभोग करना

जब आप एक AI एजेंट बना रहे हैं, तो यह सिर्फ स्मार्ट प्रतिक्रियाएं उत्पन्न करने के बारे में नहीं है; यह आपके एजेंट को कार्रवाई करने की क्षमता देने के बारे में भी है। यही वह जगह है जहां मॉडल कॉन्टेक्स्ट प्रोटोकॉल (MCP) आता है। MCP एजेंटों के लिए बाहरी उपकरणों और सेवाओं तक सुसंगत तरीके से पहुंच बनाना आसान बनाता है। इसे ऐसे समझें जैसे आप अपने एजेंट को एक टूलबॉक्स में प्लग कर रहे हैं जिसे वह वास्तव में उपयोग कर सकता है।

मान लें कि आप अपने एजेंट को अपने कैलकुलेटर MCP सर्वर से जोड़ते हैं। अचानक, आपका एजेंट गणितीय ऑपरेशन कर सकता है, बस एक प्रॉम्प्ट प्राप्त करके जैसे "47 का 89 से गुणा क्या है?"—लॉजिक को हार्डकोड करने या कस्टम APIs बनाने की कोई आवश्यकता नहीं है।

## अवलोकन

यह पाठ यह कवर करता है कि कैसे एक कैलकुलेटर MCP सर्वर को Visual Studio Code में [AI Toolkit](https://aka.ms/AIToolkit) एक्सटेंशन के साथ एक एजेंट से जोड़ा जाए, जिससे आपका एजेंट प्राकृतिक भाषा के माध्यम से जोड़, घटाना, गुणा और भाग जैसे गणितीय ऑपरेशन कर सके।

AI Toolkit Visual Studio Code के लिए एक शक्तिशाली एक्सटेंशन है जो एजेंट विकास को सरल बनाता है। AI इंजीनियर आसानी से स्थानीय या क्लाउड में जनरेटिव AI मॉडल विकसित और परीक्षण करके AI एप्लिकेशन बना सकते हैं। एक्सटेंशन आज उपलब्ध अधिकांश प्रमुख जनरेटिव मॉडल का समर्थन करता है।

*नोट*: AI Toolkit वर्तमान में Python और TypeScript का समर्थन करता है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- AI Toolkit के माध्यम से एक MCP सर्वर का उपभोग करना।
- MCP सर्वर द्वारा प्रदान किए गए उपकरणों को खोजने और उपयोग करने के लिए एक एजेंट कॉन्फ़िगरेशन को कॉन्फ़िगर करना।
- प्राकृतिक भाषा के माध्यम से MCP उपकरणों का उपयोग करना।

## दृष्टिकोण

हमें इसे उच्च स्तर पर कैसे दृष्टिकोण करना है:

- एक एजेंट बनाएं और उसकी सिस्टम प्रॉम्प्ट को परिभाषित करें।
- कैलकुलेटर उपकरणों के साथ एक MCP सर्वर बनाएं।
- एजेंट बिल्डर को MCP सर्वर से कनेक्ट करें।
- प्राकृतिक भाषा के माध्यम से एजेंट के टूल इनवोकेशन का परीक्षण करें।

बहुत अच्छा, अब जब हम प्रवाह को समझते हैं, तो चलिए MCP के माध्यम से बाहरी उपकरणों का लाभ उठाने के लिए एक AI एजेंट कॉन्फ़िगर करते हैं, इसकी क्षमताओं को बढ़ाते हैं!

## आवश्यकताएँ

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code के लिए AI Toolkit](https://aka.ms/AIToolkit)

## अभ्यास: सर्वर का उपभोग करना

इस अभ्यास में, आप AI Toolkit का उपयोग करके Visual Studio Code के अंदर एक MCP सर्वर से उपकरणों के साथ एक AI एजेंट बनाएंगे, चलाएंगे और बढ़ाएंगे।

### -0- प्रीस्टेप, OpenAI GPT-4o मॉडल को My Models में जोड़ें

अभ्यास **GPT-4o** मॉडल का लाभ उठाता है। एजेंट बनाने से पहले मॉडल को **My Models** में जोड़ा जाना चाहिए।

1. **Activity Bar** से **AI Toolkit** एक्सटेंशन खोलें।
1. **Catalog** सेक्शन में, **Models** का चयन करें ताकि **Model Catalog** खुल सके। **Models** का चयन करने से **Model Catalog** एक नए एडिटर टैब में खुलता है।
1. **Model Catalog** सर्च बार में **OpenAI GPT-4o** दर्ज करें।
1. **+ Add** पर क्लिक करें ताकि मॉडल आपके **My Models** सूची में जुड़ सके। सुनिश्चित करें कि आपने मॉडल चुना है जो **Hosted by GitHub** है।
1. **Activity Bar** में, पुष्टि करें कि **OpenAI GPT-4o** मॉडल सूची में दिखाई देता है।

### -1- एक एजेंट बनाएं

**Agent (Prompt) Builder** आपको अपने AI-पावर्ड एजेंटों को बनाने और कस्टमाइज़ करने की अनुमति देता है। इस सेक्शन में, आप एक नया एजेंट बनाएंगे और बातचीत को शक्ति देने के लिए एक मॉडल असाइन करेंगे।

1. **Activity Bar** से **AI Toolkit** एक्सटेंशन खोलें।
1. **Tools** सेक्शन में, **Agent (Prompt) Builder** का चयन करें। **Agent (Prompt) Builder** का चयन करने से **Agent (Prompt) Builder** एक नए एडिटर टैब में खुलता है।
1. **+ New Builder** बटन पर क्लिक करें। एक्सटेंशन **Command Palette** के माध्यम से एक सेटअप विज़ार्ड लॉन्च करेगा।
1. नाम **Calculator Agent** दर्ज करें और **Enter** दबाएं।
1. **Agent (Prompt) Builder** में, **Model** फ़ील्ड के लिए, **OpenAI GPT-4o (via GitHub)** मॉडल चुनें।

### -2- एजेंट के लिए एक सिस्टम प्रॉम्प्ट बनाएं

एजेंट को संरचित करने के बाद, अब इसके व्यक्तित्व और उद्देश्य को परिभाषित करने का समय है। इस सेक्शन में, आप **Generate system prompt** फीचर का उपयोग करेंगे ताकि एजेंट के इरादे व्यवहार का वर्णन किया जा सके—इस मामले में, एक कैलकुलेटर एजेंट—और मॉडल आपके लिए सिस्टम प्रॉम्प्ट लिखेगा।

1. **Prompts** सेक्शन के लिए, **Generate system prompt** बटन पर क्लिक करें। यह बटन प्रॉम्प्ट बिल्डर में खुलता है जो एजेंट के लिए सिस्टम प्रॉम्प्ट उत्पन्न करने के लिए AI का लाभ उठाता है।
1. **Generate a prompt** विंडो में, निम्नलिखित दर्ज करें: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** बटन पर क्लिक करें। नीचे-दाएं कोने में एक सूचना दिखाई देगी जो पुष्टि करती है कि सिस्टम प्रॉम्प्ट उत्पन्न किया जा रहा है। एक बार प्रॉम्प्ट उत्पन्न हो जाने के बाद, प्रॉम्प्ट **Agent (Prompt) Builder** के **System prompt** फ़ील्ड में दिखाई देगा।
1. **System prompt** की समीक्षा करें और आवश्यकतानुसार संशोधित करें।

### -3- एक MCP सर्वर बनाएं

अब जब आपने अपने एजेंट के सिस्टम प्रॉम्प्ट को परिभाषित कर दिया है—इसके व्यवहार और प्रतिक्रियाओं को मार्गदर्शन करते हुए—अब एजेंट को व्यावहारिक क्षमताओं से लैस करने का समय है। इस सेक्शन में, आप एक कैलकुलेटर MCP सर्वर बनाएंगे जिसमें जोड़, घटाना, गुणा, और भाग गणनाओं को निष्पादित करने के लिए उपकरण होंगे। यह सर्वर आपके एजेंट को प्राकृतिक भाषा प्रॉम्प्ट के जवाब में वास्तविक समय में गणितीय ऑपरेशन करने की अनुमति देगा।

AI Toolkit आपके स्वयं के MCP सर्वर बनाने की सुविधा के लिए टेम्पलेट्स के साथ सुसज्जित है। हम कैलकुलेटर MCP सर्वर बनाने के लिए Python टेम्पलेट का उपयोग करेंगे।

*नोट*: AI Toolkit वर्तमान में Python और TypeScript का समर्थन करता है।

1. **Agent (Prompt) Builder** के **Tools** सेक्शन में, **+ MCP Server** बटन पर क्लिक करें। एक्सटेंशन **Command Palette** के माध्यम से एक सेटअप विज़ार्ड लॉन्च करेगा।
1. **+ Add Server** चुनें।
1. **Create a New MCP Server** चुनें।
1. **python-weather** को टेम्पलेट के रूप में चुनें।
1. MCP सर्वर टेम्पलेट को सहेजने के लिए **Default folder** चुनें।
1. सर्वर के लिए निम्नलिखित नाम दर्ज करें: **Calculator**
1. एक नया Visual Studio Code विंडो खुलेगा। **Yes, I trust the authors** चुनें।
1. टर्मिनल का उपयोग करते हुए (**Terminal** > **New Terminal**), एक वर्चुअल एनवायरनमेंट बनाएं: `python -m venv .venv`
1. टर्मिनल का उपयोग करते हुए, वर्चुअल एनवायरनमेंट को सक्रिय करें:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. टर्मिनल का उपयोग करते हुए, निर्भरताएं स्थापित करें: `pip install -e .[dev]`
1. **Activity Bar** के **Explorer** दृश्य में, **src** डायरेक्टरी का विस्तार करें और **server.py** को चुनें ताकि फ़ाइल एडिटर में खुल सके।
1. **server.py** फ़ाइल में कोड को निम्नलिखित से बदलें और सहेजें:

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

अब जब आपके एजेंट के पास उपकरण हैं, तो उन्हें उपयोग करने का समय है! इस सेक्शन में, आप एजेंट को प्रॉम्प्ट सबमिट करेंगे ताकि परीक्षण और सत्यापन किया जा सके कि एजेंट कैलकुलेटर MCP सर्वर से उपयुक्त उपकरण का लाभ उठाता है या नहीं।

आप अपने स्थानीय डेवलपमेंट मशीन पर **Agent Builder** के माध्यम से कैलकुलेटर MCP सर्वर को MCP क्लाइंट के रूप में चलाएंगे।

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `मैंने 3 आइटम खरीदे जिनकी कीमत $25 प्रति थी, और फिर $20 की छूट का उपयोग किया। मैंने कितना भुगतान किया?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` मान **subtract** टूल के लिए असाइन किए गए हैं।
    - प्रत्येक टूल से प्रतिक्रिया संबंधित **Tool Response** में प्रदान की जाती है।
    - मॉडल से अंतिम आउटपुट अंतिम **Model Response** में प्रदान किया जाता है।
1. एजेंट का आगे परीक्षण करने के लिए अतिरिक्त प्रॉम्प्ट सबमिट करें। आप **User prompt** फ़ील्ड में मौजूदा प्रॉम्प्ट को क्लिक करके और मौजूदा प्रॉम्प्ट को बदलकर संशोधित कर सकते हैं।
1. एक बार जब आप एजेंट का परीक्षण कर लें, तो आप सर्वर को **terminal** के माध्यम से **CTRL/CMD+C** दर्ज करके बंद कर सकते हैं।

## असाइनमेंट

अपने **server.py** फ़ाइल में एक अतिरिक्त टूल एंट्री जोड़ने का प्रयास करें (उदाहरण: एक संख्या का वर्गमूल लौटाएं)। अतिरिक्त प्रॉम्प्ट सबमिट करें जो आपके नए टूल (या मौजूदा टूल) का लाभ उठाने के लिए एजेंट की आवश्यकता होगी। सुनिश्चित करें कि नए जोड़े गए टूल को लोड करने के लिए सर्वर को पुनः प्रारंभ करें।

## समाधान

[Solution](./solution/README.md)

## मुख्य निष्कर्ष

इस अध्याय के निष्कर्ष निम्नलिखित हैं:

- AI Toolkit एक्सटेंशन एक शानदार क्लाइंट है जो आपको MCP सर्वर और उनके उपकरणों का उपभोग करने देता है।
- आप MCP सर्वरों में नए उपकरण जोड़ सकते हैं, एजेंट की क्षमताओं को बढ़ाकर बदलते आवश्यकताओं को पूरा कर सकते हैं।
- AI Toolkit में टेम्पलेट्स (जैसे, Python MCP सर्वर टेम्पलेट्स) शामिल हैं ताकि कस्टम टूल बनाने को सरल बनाया जा सके।

## अतिरिक्त संसाधन

- [AI Toolkit डॉक](https://aka.ms/AIToolkit/doc)

## आगे क्या है

अगला: [पाठ 4 व्यावहारिक कार्यान्वयन](/04-PracticalImplementation/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ को उसकी मूल भाषा में प्राधिकृत स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।