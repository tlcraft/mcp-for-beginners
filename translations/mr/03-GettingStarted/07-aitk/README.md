<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:17:05+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "mr"
}
-->
# Visual Studio Code साठी AI Toolkit विस्तारातून सर्व्हर वापरणे

जेव्हा तुम्ही AI एजंट तयार करत असता, तेव्हा फक्त हुशार प्रतिसाद तयार करणेच नव्हे, तर तुमच्या एजंटला क्रिया करण्याची क्षमता देणे देखील महत्त्वाचे असते. यासाठी Model Context Protocol (MCP) मदतीला येतो. MCP एजंटना बाह्य साधने आणि सेवा सुसंगत पद्धतीने वापरणे सोपे करते. याला असा समजा की तुमचा एजंट एका अशा टूलबॉक्सशी जोडला आहे ज्याचा तो *खरंच* वापर करू शकतो.

समजा तुम्ही तुमच्या एजंटला calculator MCP सर्व्हरशी जोडता. अचानक, तुमचा एजंट “47 गुणिले 89 किती?” असा प्रश्न मिळाल्यावर गणिती क्रिया करू शकतो—काही हार्डकोडिंग किंवा कस्टम API बनवण्याची गरज नाही.

## आढावा

या धड्यात आपण Visual Studio Code मधील [AI Toolkit](https://aka.ms/AIToolkit) विस्तार वापरून एजंटला calculator MCP सर्व्हरशी कसे जोडायचे हे शिकणार आहोत, ज्यामुळे एजंट नैसर्गिक भाषेत बेरीज, वजाबाकी, गुणाकार आणि भागाकार यांसारख्या गणिती क्रिया करू शकेल.

AI Toolkit हा Visual Studio Code साठी एक शक्तिशाली विस्तार आहे जो एजंट विकास सुलभ करतो. AI अभियंते स्थानिक किंवा क्लाउडमध्ये जनरेटिव्ह AI मॉडेल्स विकसित आणि चाचणी करू शकतात. हा विस्तार आज उपलब्ध असलेल्या बहुतेक प्रमुख जनरेटिव्ह मॉडेल्सना समर्थन देतो.

*टीप*: AI Toolkit सध्या Python आणि TypeScript ला समर्थन देतो.

## शिकण्याचे उद्दिष्ट

या धड्याच्या शेवटी तुम्ही सक्षम असाल:

- AI Toolkit वापरून MCP सर्व्हर कसे वापरायचे.
- एजंट कॉन्फिगरेशन कसे सेट करायचे ज्यामुळे तो MCP सर्व्हरद्वारे उपलब्ध साधने शोधू आणि वापरू शकेल.
- नैसर्गिक भाषेतून MCP साधने वापरणे.

## दृष्टिकोन

वरच्या पातळीवर आपल्याला पुढीलप्रमाणे पुढे जायचे आहे:

- एक एजंट तयार करा आणि त्याचा सिस्टम प्रॉम्प्ट ठरवा.
- गणक साधनांसह MCP सर्व्हर तयार करा.
- Agent Builder ला MCP सर्व्हरशी जोडा.
- नैसर्गिक भाषेतून एजंटच्या साधन वापराची चाचणी करा.

छान, आता आपण प्रवाह समजला आहे, तर MCP द्वारे बाह्य साधने वापरून AI एजंट कसा कॉन्फिगर करायचा ते पाहू, ज्यामुळे त्याच्या क्षमतांमध्ये वाढ होईल!

## पूर्वतयारी

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## सराव: सर्व्हर वापरणे

या सरावात, तुम्ही Visual Studio Code मधील AI Toolkit वापरून MCP सर्व्हरमधील साधनांसह AI एजंट तयार, चालवणं आणि सुधारणा करणार आहात.

### -0- पूर्वचरण, OpenAI GPT-4o मॉडेल My Models मध्ये जोडा

सरावासाठी **GPT-4o** मॉडेल वापरले जाते. एजंट तयार करण्यापूर्वी हे मॉडेल **My Models** मध्ये जोडलेले असावे.

![Visual Studio Code च्या AI Toolkit विस्तारातील मॉडेल निवड इंटरफेसची स्क्रीनशॉट. शीर्षक "Find the right model for your AI Solution" आहे आणि उपशीर्षक वापरकर्त्यांना AI मॉडेल शोधा, चाचणी करा, आणि तैनात करा असे सांगते. “Popular Models” अंतर्गत सहा मॉडेल कार्ड्स दिसतात: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), आणि DeepSeek-R1 (Ollama-hosted). प्रत्येक कार्डवर “Add” आणि “Try in Playground” पर्याय आहेत.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.mr.png)

1. **Activity Bar** मधून **AI Toolkit** विस्तार उघडा.
1. **Catalog** विभागात **Models** निवडा, ज्यामुळे **Model Catalog** नवीन एडिटर टॅबमध्ये उघडेल.
1. **Model Catalog** च्या शोध बारमध्ये **OpenAI GPT-4o** टाका.
1. **+ Add** क्लिक करून मॉडेल **My Models** मध्ये जोडा. खात्री करा की तुम्ही **Hosted by GitHub** मॉडेल निवडलं आहे.
1. **Activity Bar** मध्ये तपासा की **OpenAI GPT-4o** मॉडेल यादीत दिसत आहे.

### -1- एजंट तयार करा

**Agent (Prompt) Builder** तुम्हाला तुमचे AI-शक्तिशाली एजंट तयार आणि सानुकूल करण्याची परवानगी देतो. या विभागात, तुम्ही नवीन एजंट तयार करून त्याला संभाषणासाठी मॉडेल नियुक्त कराल.

![AI Toolkit विस्तारातील "Calculator Agent" बिल्डर इंटरफेसची स्क्रीनशॉट. डाव्या पॅनेलमध्ये निवडलेले मॉडेल "OpenAI GPT-4o (via GitHub)" आहे. सिस्टम प्रॉम्प्टमध्ये "You are a professor in university teaching math" आहे, आणि यूजर प्रॉम्प्टमध्ये "Explain to me the Fourier equation in simple terms." टूल्स जोडण्याचे, MCP Server सक्षम करण्याचे आणि स्ट्रक्चर्ड आउटपुट निवडण्याचे पर्याय आहेत. खाली निळा “Run” बटण आहे. उजव्या पॅनेलमध्ये "Get Started with Examples" अंतर्गत तीन नमुना एजंट्स दिसतात: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter यांसह).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.mr.png)

1. **Activity Bar** मधून **AI Toolkit** विस्तार उघडा.
1. **Tools** विभागात **Agent (Prompt) Builder** निवडा, ज्यामुळे नवीन एडिटर टॅबमध्ये उघडेल.
1. **+ New Agent** बटण क्लिक करा. विस्तार **Command Palette** द्वारे सेटअप विजार्ड सुरू करेल.
1. नाव म्हणून **Calculator Agent** टाका आणि **Enter** दाबा.
1. **Agent (Prompt) Builder** मध्ये, **Model** फील्डमध्ये **OpenAI GPT-4o (via GitHub)** मॉडेल निवडा.

### -2- एजंटसाठी सिस्टम प्रॉम्प्ट तयार करा

एजंट तयार झाल्यानंतर, त्याचा व्यक्तिमत्त्व आणि उद्दिष्ट ठरवायचा आहे. या विभागात, तुम्ही **Generate system prompt** फिचर वापरून एजंटच्या वर्तनाचे वर्णन कराल—या प्रकरणात, एक गणक एजंट—आणि मॉडेलला सिस्टम प्रॉम्प्ट लिहायला सांगाल.

![AI Toolkit मधील "Calculator Agent" इंटरफेसची स्क्रीनशॉट ज्यात "Generate a prompt" नावाची मोडेल विंडो उघडलेली आहे. मोडेल विंडो सांगते की बेसिक माहिती शेअर करून प्रॉम्प्ट टेम्पलेट तयार करता येतो आणि त्यात एक टेक्स्ट बॉक्स आहे ज्यात नमुना सिस्टम प्रॉम्प्ट आहे: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." खाली "Close" आणि "Generate" बटणे आहेत. पार्श्वभूमीमध्ये एजंट कॉन्फिगरेशन आणि निवडलेले मॉडेल "OpenAI GPT-4o (via GitHub)" दिसते.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.mr.png)

1. **Prompts** विभागात **Generate system prompt** बटण क्लिक करा. हे AI वापरून सिस्टम प्रॉम्प्ट तयार करणारा प्रॉम्प्ट बिल्डर उघडेल.
1. **Generate a prompt** विंडोमध्ये खालील मजकूर टाका: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** बटण क्लिक करा. खाली उजव्या कोपऱ्यात एक सूचना येईल की सिस्टम प्रॉम्प्ट तयार होत आहे. पूर्ण झाल्यावर तो **Agent (Prompt) Builder** च्या **System prompt** फील्डमध्ये दिसेल.
1. सिस्टम प्रॉम्प्ट तपासा आणि आवश्यक असल्यास सुधारणा करा.

### -3- MCP सर्व्हर तयार करा

आता तुम्ही एजंटचा सिस्टम प्रॉम्प्ट तयार केला आहे—जो त्याच्या वर्तनाला मार्गदर्शन करतो—तेव्हा एजंटला व्यवहार्य क्षमता देण्याची वेळ आली आहे. या विभागात, तुम्ही बेरीज, वजाबाकी, गुणाकार आणि भागाकार करणाऱ्या साधनांसह एक गणक MCP सर्व्हर तयार कराल. हा सर्व्हर एजंटला नैसर्गिक भाषेतील प्रश्नांना त्वरित गणिती उत्तर देण्यास सक्षम करेल.

![Calculator Agent इंटरफेसचा खालचा भाग दाखवणारी स्क्रीनशॉट, ज्यात “Tools” आणि “Structure output” या विस्तारता येणाऱ्या मेन्यूज आहेत, आणि “Choose output format” ड्रॉपडाउन “text” वर सेट आहे. उजवीकडे "+ MCP Server" नावाचा बटण आहे ज्याद्वारे Model Context Protocol सर्व्हर जोडता येतो.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.mr.png)

AI Toolkit मध्ये स्वतःचा MCP सर्व्हर तयार करणे सोपे करणारे टेम्पलेट्स आहेत. आपण Python टेम्पलेट वापरून calculator MCP सर्व्हर तयार करू.

*टीप*: AI Toolkit सध्या Python आणि TypeScript ला समर्थन देतो.

1. **Agent (Prompt) Builder** च्या **Tools** विभागात **+ MCP Server** बटण क्लिक करा. विस्तार **Command Palette** द्वारे सेटअप विजार्ड सुरू करेल.
1. **+ Add Server** निवडा.
1. **Create a New MCP Server** निवडा.
1. **python-weather** टेम्पलेट निवडा.
1. MCP सर्व्हर टेम्पलेट जतन करण्यासाठी **Default folder** निवडा.
1. सर्व्हरसाठी नाव म्हणून **Calculator** टाका.
1. नवीन Visual Studio Code विंडो उघडेल. **Yes, I trust the authors** निवडा.
1. टर्मिनलमध्ये (**Terminal** > **New Terminal**) खालीलप्रमाणे वर्च्युअल एन्व्हायर्नमेंट तयार करा: `python -m venv .venv`
1. टर्मिनलमध्ये वर्च्युअल एन्व्हायर्नमेंट सक्रिय करा:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. टर्मिनलमध्ये अवलंबित्वे इंस्टॉल करा: `pip install -e .[dev]`
1. **Activity Bar** मधील **Explorer** मध्ये **src** फोल्डर उघडा आणि **server.py** फाईल एडिटरमध्ये उघडा.
1. **server.py** मधील कोड खालीलप्रमाणे बदला आणि जतन करा:

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

### -4- calculator MCP सर्व्हरसह एजंट चालवा

आता तुमच्याकडे साधने आहेत, ती वापरण्याची वेळ आली आहे! या विभागात, तुम्ही एजंटला प्रॉम्प्ट सबमिट करून तपासाल की एजंट योग्य साधन वापरत आहे का.

![Calculator Agent इंटरफेसची स्क्रीनशॉट, ज्यात डाव्या पॅनेलमध्ये “Tools” अंतर्गत local-server-calculator_server नावाचा MCP सर्व्हर जोडलेला आहे ज्यात add, subtract, multiply, divide अशी चार साधने आहेत. चार साधनांसाठी बॅज आहे. खाली “Structure output” विभाग संक्षिप्त आहे आणि निळा “Run” बटण आहे. उजव्या पॅनेलमध्ये “Model Response” अंतर्गत एजंटने multiply आणि subtract साधने वापरली आहेत, इनपुट्स {"a": 3, "b": 25} आणि {"a": 75, "b": 20} आहेत. अंतिम “Tool Response” 75.0 दाखवते. खाली “View Code” बटण आहे.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.mr.png)

तुम्ही तुमच्या स्थानिक विकास मशीनवर calculator MCP सर्व्हर **Agent Builder** च्या माध्यमातून MCP क्लायंट म्हणून चालवणार आहात.

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` या मूल्यांनी **subtract** टूलसाठी मूल्ये दिली जातात.
    - प्रत्येक टूलकडून मिळणारा प्रतिसाद **Tool Response** मध्ये दिसतो.
    - मॉडेलकडून अंतिम आउटपुट **Model Response** मध्ये दिसतो.
1. एजंट अधिक चाचणीसाठी अतिरिक्त प्रॉम्प्ट सबमिट करा. **User prompt** फील्डमध्ये क्लिक करून विद्यमान प्रॉम्प्ट बदला.
1. चाचणी पूर्ण झाल्यावर, टर्मिनलमध्ये **CTRL/CMD+C** दाबून सर्व्हर बंद करा.

## असाइनमेंट

तुमच्या **server.py** फाईलमध्ये एक अतिरिक्त टूल जोडा (उदा. एखाद्या संख्येचा वर्गमुळ परत करा). एजंटला तुमच्या नव्या टूलचा (किंवा विद्यमान टूलचा) वापर करण्यासाठी प्रॉम्प्ट सबमिट करा. नवीन टूल लोड होण्यासाठी सर्व्हर पुन्हा सुरू करायला विसरू नका.

## सोल्यूशन

[Solution](./solution/README.md)

## महत्त्वाच्या गोष्टी

या प्रकरणातून शिकण्यासारखे:

- AI Toolkit विस्तार एक उत्कृष्ट क्लायंट आहे जो तुम्हाला MCP Servers आणि त्यांची साधने वापरण्याची परवानगी देतो.
- तुम्ही MCP सर्व्हरमध्ये नवीन साधने जोडू शकता, ज्यामुळे एजंटच्या क्षमतांमध्ये वाढ होते.
- AI Toolkit मध्ये टेम्पलेट्स आहेत (उदा. Python MCP सर्व्हर टेम्पलेट्स) जे कस्टम साधने तयार करणे सोपे करतात.

## अतिरिक्त संसाधने

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## पुढे काय
- पुढे: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेत फरक असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला पाहिजे. महत्त्वाची माहिती असल्यास व्यावसायिक मानवी भाषांतर करण्याची शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थसंग्रहासाठी आम्ही जबाबदार नाही.