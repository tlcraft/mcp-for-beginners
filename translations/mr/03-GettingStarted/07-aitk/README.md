<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T16:39:08+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "mr"
}
-->
# Visual Studio Code साठी AI Toolkit विस्तारातून सर्व्हर वापरणे

जेव्हा तुम्ही AI एजंट तयार करत असता, तेव्हा फक्त हुशार प्रतिसाद तयार करणेच महत्त्वाचे नसते; तुमच्या एजंटला कृती करण्याची क्षमता देणे देखील गरजेचे असते. यासाठी Model Context Protocol (MCP) मदत करते. MCP एजंटना बाह्य साधने आणि सेवा सुसंगत पद्धतीने वापरण्यास सोपे करते. याला असं समजा की तुमचा एजंट एका अशा टूलबॉक्समध्ये जोडला आहे ज्याचा तो खरोखर वापर करू शकतो.

समजा तुम्ही तुमच्या एजंटला कॅल्क्युलेटर MCP सर्व्हरशी जोडता. अचानक, तुमचा एजंट “47 गुणिले 89 किती?” असा प्रश्न मिळाल्यावर गणिती क्रिया करू शकतो—कोडमध्ये लॉजिक लिहिण्याची किंवा कस्टम API तयार करण्याची गरज नाही.

## आढावा

या धड्यात, Visual Studio Code मधील [AI Toolkit](https://aka.ms/AIToolkit) विस्तार वापरून कॅल्क्युलेटर MCP सर्व्हर एजंटशी कसा जोडायचा हे शिकवले आहे, ज्यामुळे तुमचा एजंट नैसर्गिक भाषेतून बेरीज, वजाबाकी, गुणाकार आणि भागाकार यांसारख्या गणिती क्रिया करू शकतो.

AI Toolkit हा Visual Studio Code साठी एक शक्तिशाली विस्तार आहे जो एजंट विकास सुलभ करतो. AI अभियंते स्थानिक किंवा क्लाउडमध्ये जनरेटिव्ह AI मॉडेल विकसित आणि चाचणी करून AI अनुप्रयोग सहज तयार करू शकतात. हा विस्तार आज उपलब्ध बहुतेक प्रमुख जनरेटिव्ह मॉडेलना समर्थन देतो.

*टीप*: AI Toolkit सध्या Python आणि TypeScript ला समर्थन देतो.

## शिकण्याचे उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही खालील गोष्टी करू शकाल:

- AI Toolkit द्वारे MCP सर्व्हर वापरणे.
- एजंट कॉन्फिगरेशन सेट करणे जेणेकरून तो MCP सर्व्हरद्वारे दिलेली साधने शोधू आणि वापरू शकेल.
- नैसर्गिक भाषेतून MCP साधने वापरणे.

## दृष्टिकोन

उच्चस्तरीय पातळीवर आपण कसे पुढे जावे:

- एजंट तयार करा आणि त्याचा सिस्टम प्रॉम्प्ट निश्चित करा.
- कॅल्क्युलेटर साधनांसह MCP सर्व्हर तयार करा.
- Agent Builder ला MCP सर्व्हरशी जोडा.
- नैसर्गिक भाषेतून एजंटच्या साधन वापराची चाचणी करा.

छान, आता आपण प्रवाह समजला आहे, चला MCP द्वारे बाह्य साधने वापरण्यासाठी AI एजंट कॉन्फिगर करू, ज्यामुळे त्याच्या क्षमतांमध्ये वाढ होईल!

## पूर्वअट

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code साठी AI Toolkit](https://aka.ms/AIToolkit)

## सराव: सर्व्हर वापरणे

या सरावात, तुम्ही Visual Studio Code मध्ये AI Toolkit वापरून MCP सर्व्हरमधील साधने वापरून AI एजंट तयार, चालवणं आणि सुधारणा कराल.

### -0- पूर्वतयारी, OpenAI GPT-4o मॉडेल My Models मध्ये जोडा

सरावासाठी **GPT-4o** मॉडेल वापरले जाते. एजंट तयार करण्यापूर्वी हे मॉडेल **My Models** मध्ये जोडलेले असावे.

![Visual Studio Code च्या AI Toolkit विस्तारातील मॉडेल निवड इंटरफेसचा स्क्रीनशॉट. शीर्षक आहे "Find the right model for your AI Solution" आणि उपशीर्षक वापरकर्त्यांना AI मॉडेल शोधण्यास, चाचणी करण्यास आणि तैनात करण्यास प्रोत्साहित करतो. “Popular Models” अंतर्गत सहा मॉडेल कार्ड्स दिसत आहेत: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), आणि DeepSeek-R1 (Ollama-hosted). प्रत्येक कार्डवर “Add” आणि “Try in Playground” पर्याय आहेत.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.mr.png)

1. **Activity Bar** मधून **AI Toolkit** विस्तार उघडा.
2. **Catalog** विभागात **Models** निवडा, ज्यामुळे नवीन एडिटर टॅबमध्ये **Model Catalog** उघडेल.
3. **Model Catalog** च्या शोध पट्टीत **OpenAI GPT-4o** टाका.
4. **+ Add** क्लिक करून मॉडेल **My Models** मध्ये जोडा. खात्री करा की तुम्ही **GitHub-hosted** मॉडेल निवडले आहे.
5. **Activity Bar** मध्ये **OpenAI GPT-4o** मॉडेल यादीत दिसत असल्याची खात्री करा.

### -1- एजंट तयार करा

**Agent (Prompt) Builder** तुम्हाला तुमचे स्वतःचे AI-शक्तीशाली एजंट तयार आणि सानुकूल करण्याची परवानगी देतो. या विभागात, तुम्ही नवीन एजंट तयार कराल आणि संभाषणासाठी मॉडेल निवडाल.

![Visual Studio Code साठी AI Toolkit विस्तारातील "Calculator Agent" बिल्डर इंटरफेसचा स्क्रीनशॉट. डाव्या पॅनेलवर निवडलेले मॉडेल "OpenAI GPT-4o (via GitHub)" आहे. सिस्टम प्रॉम्प्टमध्ये "You are a professor in university teaching math" आणि युजर प्रॉम्प्टमध्ये "Explain to me the Fourier equation in simple terms." साधने जोडण्याचे, MCP Server सक्षम करण्याचे आणि संरचित आउटपुट निवडण्याचे पर्याय आहेत. खाली निळा “Run” बटण आहे. उजव्या पॅनेलवर "Get Started with Examples" अंतर्गत तीन नमुना एजंट्स आहेत: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter यांसह).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.mr.png)

1. **Activity Bar** मधून **AI Toolkit** विस्तार उघडा.
2. **Tools** विभागात **Agent (Prompt) Builder** निवडा, ज्यामुळे नवीन एडिटर टॅबमध्ये तो उघडेल.
3. **+ New Agent** बटण क्लिक करा. विस्तार **Command Palette** द्वारे सेटअप विजार्ड सुरू करेल.
4. नाव म्हणून **Calculator Agent** टाका आणि **Enter** दाबा.
5. **Agent (Prompt) Builder** मध्ये **Model** फील्डसाठी **OpenAI GPT-4o (via GitHub)** मॉडेल निवडा.

### -2- एजंटसाठी सिस्टम प्रॉम्प्ट तयार करा

एजंट तयार झाल्यानंतर, त्याची व्यक्तिमत्व आणि उद्दिष्ट निश्चित करण्याची वेळ आली आहे. या विभागात, तुम्ही **Generate system prompt** फिचर वापरून एजंटच्या अपेक्षित वर्तनाचे वर्णन कराल—या प्रकरणात, कॅल्क्युलेटर एजंट—आणि मॉडेलला सिस्टम प्रॉम्प्ट लिहायला सांगाल.

![Visual Studio Code साठी AI Toolkit मधील "Calculator Agent" इंटरफेसचा स्क्रीनशॉट, ज्यात "Generate a prompt" नावाचा मोडेल विंडो उघडलेला आहे. मोडेलमध्ये नमुना सिस्टम प्रॉम्प्ट आहे: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." खाली "Close" आणि "Generate" बटणे आहेत. पार्श्वभूमीत एजंट कॉन्फिगरेशन दिसत आहे, ज्यात निवडलेले मॉडेल "OpenAI GPT-4o (via GitHub)" आणि सिस्टम व युजर प्रॉम्प्ट फील्ड्स आहेत.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.mr.png)

1. **Prompts** विभागात **Generate system prompt** बटण क्लिक करा. हे बटण AI वापरून सिस्टम प्रॉम्प्ट तयार करणाऱ्या प्रॉम्प्ट बिल्डरला उघडेल.
2. **Generate a prompt** विंडोमध्ये खालील मजकूर टाका: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** बटण क्लिक करा. उजव्या खालच्या कोपऱ्यात एक सूचना येईल की सिस्टम प्रॉम्प्ट तयार होत आहे. तयार झाल्यावर तो **Agent (Prompt) Builder** च्या **System prompt** फील्डमध्ये दिसेल.
4. **System prompt** तपासा आणि आवश्यक असल्यास सुधारणा करा.

### -3- MCP सर्व्हर तयार करा

आता जेव्हा तुम्ही एजंटचा सिस्टम प्रॉम्प्ट निश्चित केला आहे—त्याच्या वर्तन आणि प्रतिसादांसाठी मार्गदर्शन—तेव्हा त्याला व्यावहारिक क्षमता देण्याची वेळ आली आहे. या विभागात, तुम्ही बेरीज, वजाबाकी, गुणाकार आणि भागाकार करण्यासाठी साधने असलेला कॅल्क्युलेटर MCP सर्व्हर तयार कराल. हा सर्व्हर तुमच्या एजंटला नैसर्गिक भाषेतील प्रॉम्प्ट्सवर रिअल-टाइम गणिती क्रिया करण्यास सक्षम करेल.

![Visual Studio Code साठी AI Toolkit विस्तारातील Calculator Agent इंटरफेसचा खालचा भाग दाखवणारा स्क्रीनशॉट. “Tools” आणि “Structure output” साठी विस्तारता येणारे मेनू, “Choose output format” ड्रॉपडाऊन “text” वर सेट केलेले, आणि उजवीकडे “+ MCP Server” बटण दिसत आहे. Tools विभागाच्या वर एक इमेज आयकॉन प्लेसहोल्डर आहे.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.mr.png)

AI Toolkit मध्ये स्वतःचा MCP सर्व्हर तयार करण्यासाठी टेम्पलेट्स उपलब्ध आहेत. आपण कॅल्क्युलेटर MCP सर्व्हर तयार करण्यासाठी Python टेम्पलेट वापरणार आहोत.

*टीप*: AI Toolkit सध्या Python आणि TypeScript ला समर्थन देतो.

1. **Agent (Prompt) Builder** च्या **Tools** विभागात **+ MCP Server** बटण क्लिक करा. विस्तार **Command Palette** द्वारे सेटअप विजार्ड सुरू करेल.
2. **+ Add Server** निवडा.
3. **Create a New MCP Server** निवडा.
4. **python-weather** टेम्पलेट निवडा.
5. MCP सर्व्हर टेम्पलेट जतन करण्यासाठी **Default folder** निवडा.
6. सर्व्हरसाठी नाव म्हणून **Calculator** टाका.
7. नवीन Visual Studio Code विंडो उघडेल. **Yes, I trust the authors** निवडा.
8. टर्मिनलमध्ये (`Terminal` > `New Terminal`) वर्चुअल एन्व्हायर्नमेंट तयार करा: `python -m venv .venv`
9. टर्मिनलमध्ये वर्चुअल एन्व्हायर्नमेंट सक्रिय करा:
    - Windows: `.venv\Scripts\activate`
    - macOS/Linux: `source venv/bin/activate`
10. टर्मिनलमध्ये अवलंबित्वे इन्स्टॉल करा: `pip install -e .[dev]`
11. **Activity Bar** मधील **Explorer** मध्ये **src** फोल्डर विस्तृत करा आणि **server.py** फाईल उघडा.
12. **server.py** मधील कोड खालीलप्रमाणे बदला आणि जतन करा:

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

### -4- कॅल्क्युलेटर MCP सर्व्हरसह एजंट चालवा

आता तुमच्या एजंटकडे साधने आहेत, ती वापरण्याची वेळ आली आहे! या विभागात, तुम्ही एजंटला प्रॉम्प्ट्स देऊन तपासाल की तो कॅल्क्युलेटर MCP सर्व्हरमधील योग्य साधन वापरत आहे का.

![Visual Studio Code साठी AI Toolkit विस्तारातील Calculator Agent इंटरफेसचा स्क्रीनशॉट. डाव्या पॅनेलमध्ये “Tools” अंतर्गत local-server-calculator_server नावाचा MCP सर्व्हर जोडलेला आहे, ज्यात चार उपलब्ध साधने आहेत: add, subtract, multiply, आणि divide. चार साधने सक्रिय असल्याचा बॅज दिसतो. खाली “Structure output” विभाग संक्षिप्त आहे आणि निळा “Run” बटण आहे. उजव्या पॅनेलमध्ये “Model Response” अंतर्गत एजंटने multiply आणि subtract साधने वापरली आहेत, ज्यात इनपुट्स {"a": 3, "b": 25} आणि {"a": 75, "b": 20} आहेत. अंतिम “Tool Response” 75.0 दाखवले आहे. खाली “View Code” बटण आहे.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.mr.png)

तुम्ही तुमच्या स्थानिक विकास मशीनवर **Agent Builder** वापरून MCP सर्व्हर चालवणार आहात.

1. `F5` दाबून MCP सर्व्हर डिबगिंग सुरू करा. **Agent (Prompt) Builder** नवीन एडिटर टॅबमध्ये उघडेल. टर्मिनलमध्ये सर्व्हरची स्थिती दिसेल.
2. **Agent (Prompt) Builder** च्या **User prompt** फील्डमध्ये खालील प्रॉम्प्ट टाका: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. एजंटचा प्रतिसाद तयार करण्यासाठी **Run** बटण क्लिक करा.
4. एजंटचा आउटपुट तपासा. मॉडेलने तुम्ही **$55** दिले असल्याचा निष्कर्ष काढला पाहिजे.
5. काय घडले पाहिजे याचा तपशील:
    - एजंटने गणनेत मदत करण्यासाठी **multiply** आणि **subtract** साधने निवडली.
    - **multiply** साधनासाठी `a` आणि `b` मूल्ये दिली गेली.
    - **subtract** साधनासाठी `a` आणि `b` मूल्ये दिली गेली.
    - प्रत्येक साधनाचा प्रतिसाद संबंधित **Tool Response** मध्ये दिला गेला.
    - अंतिम आउटपुट **Model Response** मध्ये दिला गेला.
6. एजंटची अधिक चाचणी करण्यासाठी अतिरिक्त प्रॉम्प्ट सबमिट करा. **User prompt** फील्डमध्ये क्लिक करून विद्यमान प्रॉम्प्ट बदलू शकता.
7. चाचणी पूर्ण झाल्यावर, टर्मिनलमध्ये **CTRL/CMD+C** दाबून सर्व्हर थांबवा.

## असाइनमेंट

तुमच्या **server.py** फाईलमध्ये एक अतिरिक्त साधन जोडा (उदा. एखाद्या संख्येचा वर्गमूळ परत करा). तुमच्या नवीन साधनाचा (किंवा विद्यमान साधनांचा) वापर करणारे प्रॉम्प्ट सबमिट करा. नवीन साधने लोड होण्यासाठी सर्व्हर पुन्हा सुरू करणे विसरू नका.

## सोल्यूशन

[Solution](./solution/README.md)

## मुख्य मुद्दे

या प्रकरणातून मिळालेली मुख्य शिकवण:

- AI Toolkit विस्तार हा एक उत्कृष्ट क्लायंट आहे जो तुम्हाला MCP सर्व्हर आणि त्यांची साधने वापरण्याची परवानगी देतो.
- तुम्ही MCP सर्व्हरमध्ये नवीन साधने जोडू शकता, ज्यामुळे एजंटच्या क्षमतांमध्ये वाढ होते आणि बदलत्या गरजा पूर्ण होतात.
- AI Toolkit मध्ये टेम्पलेट्स (उदा. Python MCP सर्व्हर टेम्पलेट्स) आहेत जे कस्टम साधने तयार करणे सोपे करतात.

## अतिरिक्त संसाधने

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## पुढे काय
- पुढे: [Testing & Debugging](../08-testing/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.