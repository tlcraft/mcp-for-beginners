<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:32:40+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "mr"
}
-->
# Visual Studio Code साठी AI Toolkit एक्स्टेंशनमधून सर्व्हर वापरणे

जेव्हा तुम्ही AI एजंट तयार करत असता, तेव्हा फक्त स्मार्ट प्रतिसाद निर्माण करणेच महत्त्वाचे नसते; तुमच्या एजंटला क्रिया घेण्याची क्षमता देणे देखील गरजेचे असते. यासाठी Model Context Protocol (MCP) वापरले जाते. MCP एजंटना बाह्य साधने आणि सेवा सुसंगत पद्धतीने वापरण्यास सोपे करते. याला असं समजा की तुमचा एजंट एका टूलबॉक्समध्ये जोडला आहे ज्याचा तो *खरंच* वापर करू शकतो.

समजा तुम्ही तुमचा एजंट calculator MCP सर्व्हरशी जोडता. अचानक तुमचा एजंट "47 गुणिले 89 किती?" असा प्रॉम्प्ट मिळवून गणिती ऑपरेशन्स करू शकतो—कोडमध्ये हार्डकोडिंग करण्याची किंवा कस्टम API तयार करण्याची गरज नाही.

## आढावा

या धड्यात आपण Visual Studio Code मधील [AI Toolkit](https://aka.ms/AIToolkit) एक्स्टेंशन वापरून कॅल्क्युलेटर MCP सर्व्हर एजंटशी कसे जोडायचे हे शिकणार आहोत, ज्यामुळे तुमचा एजंट नैसर्गिक भाषेतून बेरीज, वजाबाकी, गुणाकार आणि भागाकार यांसारखे गणिती ऑपरेशन्स करू शकतो.

AI Toolkit हे Visual Studio Code साठी एक शक्तिशाली एक्स्टेंशन आहे जे एजंट विकास सुलभ करते. AI अभियंते स्थानिक किंवा क्लाउडमध्ये जनरेटिव्ह AI मॉडेल तयार करून आणि चाचणी करून AI अनुप्रयोग सहज तयार करू शकतात. हे एक्स्टेंशन आज उपलब्ध बहुतेक प्रमुख जनरेटिव्ह मॉडेल्सना समर्थन देते.

*टीप*: AI Toolkit सध्या Python आणि TypeScript ला समर्थन देते.

## शिकण्याचे उद्दिष्ट

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- AI Toolkit वापरून MCP सर्व्हर वापरणे.
- एजंट कॉन्फिगरेशन तयार करणे ज्यामुळे तो MCP सर्व्हरद्वारे दिलेली साधने शोधून वापरू शकतो.
- नैसर्गिक भाषेतून MCP साधने वापरणे.

## पद्धत

सर्वसाधारणपणे आपण पुढीलप्रमाणे पुढे जाऊ:

- एजंट तयार करा आणि त्याचा सिस्टम प्रॉम्प्ट निश्चित करा.
- कॅल्क्युलेटर टूल्ससह MCP सर्व्हर तयार करा.
- Agent Builder ला MCP सर्व्हरशी जोडा.
- नैसर्गिक भाषेतून एजंटचे टूल वापरून तपासा.

छान, आता आपण प्रवाह समजून घेतला आहे, चला MCP द्वारे बाह्य साधने वापरण्यासाठी AI एजंट सेटअप करू, ज्यामुळे त्याची क्षमता वाढेल!

## पूर्वतयारी

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## सराव: सर्व्हर वापरणे

या सरावात, तुम्ही Visual Studio Code मध्ये AI Toolkit वापरून MCP सर्व्हरमधील टूल्ससह AI एजंट तयार, चालवणं आणि सुधारणा करणार आहात.

### -0- पूर्वपायरी, OpenAI GPT-4o मॉडेल My Models मध्ये जोडा

सरावासाठी **GPT-4o** मॉडेल वापरले जाते. एजंट तयार करण्यापूर्वी हे मॉडेल **My Models** मध्ये जोडलेले असावे.

![Visual Studio Code च्या AI Toolkit एक्स्टेंशनमधील मॉडेल निवड इंटरफेसचा स्क्रीनशॉट. शीर्षक "Find the right model for your AI Solution" आहे, ज्यात वापरकर्त्यांना AI मॉडेल्स शोधण्याचे, चाचणी करण्याचे आणि तैनात करण्याचे प्रोत्साहन दिले आहे. खाली “Popular Models” अंतर्गत सहा मॉडेल कार्ड्स दिसतात: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), आणि DeepSeek-R1 (Ollama-hosted). प्रत्येक कार्डवर “Add” आणि “Try in Playground” पर्याय आहेत.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.mr.png)

1. **Activity Bar** मधून **AI Toolkit** एक्स्टेंशन उघडा.
2. **Catalog** विभागात **Models** निवडा. याने **Model Catalog** नवीन एडिटर टॅबमध्ये उघडेल.
3. **Model Catalog** च्या शोध पट्टीत **OpenAI GPT-4o** लिहा.
4. **+ Add** वर क्लिक करा जेणेकरून मॉडेल तुमच्या **My Models** यादीत जोडले जाईल. खात्री करा की तुम्ही GitHub-hosted मॉडेल निवडले आहे.
5. **Activity Bar** मध्ये तपासा की **OpenAI GPT-4o** मॉडेल यादीत दिसत आहे.

### -1- एजंट तयार करा

**Agent (Prompt) Builder** तुम्हाला तुमचे स्वतःचे AI-शक्ती असलेले एजंट तयार आणि सानुकूल करण्यास मदत करतो. या विभागात, तुम्ही नवीन एजंट तयार करून त्याला संभाषणासाठी मॉडेल असाइन कराल.

![AI Toolkit एक्स्टेंशनमधील "Calculator Agent" बिल्डर इंटरफेसचा स्क्रीनशॉट. डाव्या पॅनेलमध्ये निवडलेले मॉडेल "OpenAI GPT-4o (via GitHub)" आहे. सिस्टम प्रॉम्प्टमध्ये "You are a professor in university teaching math," आणि युजर प्रॉम्प्टमध्ये "Explain to me the Fourier equation in simple terms." यांसारखे टेक्स्ट दिसतात. इतर पर्यायांमध्ये टूल्स जोडण्याचे बटण, MCP Server सक्षम करण्याचा पर्याय आणि स्ट्रक्चर्ड आउटपुट निवडण्याचे पर्याय आहेत. खाली निळा “Run” बटण आहे. उजव्या पॅनेलमध्ये "Get Started with Examples" अंतर्गत तीन सॅम्पल एजंट्स आहेत: Web Developer (MCP Serverसह), Second-Grade Simplifier, आणि Dream Interpreter, प्रत्येकाच्या कार्याचे संक्षिप्त वर्णन आहे.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.mr.png)

1. **Activity Bar** मधून **AI Toolkit** एक्स्टेंशन उघडा.
2. **Tools** विभागात **Agent (Prompt) Builder** निवडा. याने नवीन एडिटर टॅबमध्ये **Agent (Prompt) Builder** उघडेल.
3. **+ New Agent** बटणावर क्लिक करा. यामुळे **Command Palette** द्वारे सेटअप विजार्ड सुरू होईल.
4. नाव म्हणून **Calculator Agent** टाका आणि **Enter** दाबा.
5. **Agent (Prompt) Builder** मध्ये **Model** फील्डमध्ये **OpenAI GPT-4o (via GitHub)** मॉडेल निवडा.

### -2- एजंटसाठी सिस्टम प्रॉम्प्ट तयार करा

एजंट तयार झाल्यावर त्याची व्यक्तिमत्व आणि उद्दिष्ट निश्चित करण्याची वेळ आली आहे. या विभागात, तुम्ही **Generate system prompt** फिचर वापरून एजंटच्या अपेक्षित वर्तनाचे वर्णन कराल—इथे कॅल्क्युलेटर एजंटसाठी—आणि मॉडेलला सिस्टम प्रॉम्प्ट लिहिण्यास सांगाल.

![AI Toolkit मधील "Calculator Agent" इंटरफेसचा स्क्रीनशॉट ज्यात "Generate a prompt" नावाची मोडल विंडो उघडलेली आहे. मोडलमध्ये सांगितले आहे की बेसिक तपशील शेअर करून प्रॉम्प्ट टेम्प्लेट तयार करता येतो. टेक्स्ट बॉक्समध्ये नमुना सिस्टम प्रॉम्प्ट आहे: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." खाली "Close" आणि "Generate" बटणे आहेत. पार्श्वभूमीत एजंट कॉन्फिगरेशनचा भाग दिसतो, ज्यात निवडलेले मॉडेल "OpenAI GPT-4o (via GitHub)" आणि सिस्टम व युजर प्रॉम्प्ट फील्ड्स आहेत.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.mr.png)

1. **Prompts** विभागात **Generate system prompt** बटणावर क्लिक करा. हे बटण AI वापरून सिस्टम प्रॉम्प्ट तयार करणाऱ्या प्रॉम्प्ट बिल्डरला उघडेल.
2. **Generate a prompt** विंडोत खालील लिहा: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. **Generate** बटणावर क्लिक करा. डाव्या खालच्या कोपऱ्यात सूचना येईल की सिस्टम प्रॉम्प्ट तयार होत आहे. पूर्ण झाल्यावर तो **Agent (Prompt) Builder** च्या **System prompt** फील्डमध्ये दिसेल.
4. **System prompt** पाहा आणि आवश्यक असल्यास बदल करा.

### -3- MCP सर्व्हर तयार करा

आता तुम्ही एजंटचा सिस्टम प्रॉम्प्ट तयार केला आहे—जो त्याच्या वर्तनाला मार्गदर्शन करतो—आता एजंटला व्यावहारिक क्षमता द्यायची आहे. या विभागात, तुम्ही बेरीज, वजाबाकी, गुणाकार आणि भागाकार करण्यासाठी टूल्ससह कॅल्क्युलेटर MCP सर्व्हर तयार कराल. हा सर्व्हर एजंटला नैसर्गिक भाषेतील प्रॉम्प्ट्सवर वास्तविक वेळेत गणिती ऑपरेशन्स करण्यास सक्षम करेल.

![Calculator Agent इंटरफेसचा खालचा भाग दाखवणारा स्क्रीनशॉट ज्यात “Tools” आणि “Structure output” या विस्तारण्यायोग्य मेनू दाखवले आहेत. “Choose output format” नावाचा ड्रॉपडाउन “text” वर सेट आहे. उजवीकडे “+ MCP Server” नावाचा बटण आहे ज्याद्वारे Model Context Protocol सर्व्हर जोडता येतो. Tools विभागावर एक इमेज आयकॉन प्लेसहोल्डर दिसतो.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.mr.png)

AI Toolkit मध्ये स्वतःचा MCP सर्व्हर तयार करण्यासाठी टेम्प्लेट्स आहेत. आपण Python टेम्प्लेट वापरून कॅल्क्युलेटर MCP सर्व्हर तयार करू.

*टीप*: AI Toolkit सध्या Python आणि TypeScript ला समर्थन देते.

1. **Agent (Prompt) Builder** च्या **Tools** विभागात **+ MCP Server** बटणावर क्लिक करा. यामुळे **Command Palette** द्वारे सेटअप विजार्ड सुरू होईल.
2. **+ Add Server** निवडा.
3. **Create a New MCP Server** निवडा.
4. टेम्प्लेट म्हणून **python-weather** निवडा.
5. MCP सर्व्हर टेम्प्लेट जतन करण्यासाठी **Default folder** निवडा.
6. सर्व्हरसाठी नाव म्हणून **Calculator** टाका.
7. नवीन Visual Studio Code विंडो उघडेल. **Yes, I trust the authors** निवडा.
8. टर्मिनलमध्ये (**Terminal** > **New Terminal**) खालीलप्रमाणे वर्चुअल एन्व्हायर्नमेंट तयार करा: `python -m venv .venv`
9. टर्मिनलमध्ये वर्चुअल एन्व्हायर्नमेंट सक्रिय करा:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. टर्मिनलमध्ये आवश्यक dependencies इंस्टॉल करा: `pip install -e .[dev]`
11. **Explorer** मध्ये **src** डायरेक्टरी विस्तारून **server.py** फाइल उघडा.
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

आता तुमच्या एजंटकडे टूल्स आहेत, ते वापरण्याची वेळ आली आहे! या विभागात, तुम्ही एजंटला प्रॉम्प्ट्स देऊन तपासाल की एजंट योग्य टूल वापरतोय की नाही.

![Calculator Agent इंटरफेसचा स्क्रीनशॉट ज्यात डाव्या पॅनेलमध्ये “Tools” अंतर्गत local-server-calculator_server नावाचा MCP सर्व्हर जोडलेला आहे, ज्यात चार टूल्स आहेत: add, subtract, multiply, आणि divide. चार टूल्स सक्रिय असल्याचे बॅज दिसते. खाली “Structure output” विभाग संक्षिप्त आहे आणि निळा “Run” बटण आहे. उजव्या पॅनेलमध्ये “Model Response” अंतर्गत एजंटने multiply आणि subtract टूल्स वापरले आहेत, ज्यात इनपुट्स {"a": 3, "b": 25} आणि {"a": 75, "b": 20} आहेत. अंतिम “Tool Response” 75.0 आहे. खाली “View Code” बटण आहे.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.mr.png)

तुम्ही तुमच्या स्थानिक विकास मशीनवर calculator MCP सर्व्हर **Agent Builder** द्वारे MCP क्लायंट म्हणून चालवाल.

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` या **subtract** टूलसाठी मूल्ये दिली आहेत.
    - प्रत्येक टूलकडून मिळालेला प्रतिसाद **Tool Response** मध्ये दिसेल.
    - अंतिम आउटपुट **Model Response** मध्ये दिसेल.
2. एजंट आणखी तपासण्यासाठी नवीन प्रॉम्प्ट्स सबमिट करा. **User prompt** फील्डमध्ये क्लिक करून विद्यमान प्रॉम्प्ट बदलू शकता.
3. तपासणी पूर्ण झाल्यावर, **terminal** मध्ये **CTRL/CMD+C** दाबून सर्व्हर थांबवा.

## असाईनमेंट

तुमच्या **server.py** फाइलमध्ये एक अतिरिक्त टूल जोडा (उदा. एखाद्या संख्येचा वर्गमुळ काढणे). अशा प्रॉम्प्ट्स सबमिट करा ज्यामुळे एजंट तुमचा नवीन टूल (किंवा विद्यमान टूल्स) वापरायला भाग पडेल. नवीन टूल लोड करण्यासाठी सर्व्हर पुन्हा सुरू करायला विसरू नका.

## समाधान

[Solution](./solution/README.md)

## मुख्य मुद्दे

या प्रकरणातून पुढील गोष्टी शिकायला मिळतात:

- AI Toolkit एक्स्टेंशन हे MCP सर्व्हर आणि त्यांची साधने वापरण्यासाठी उत्कृष्ट क्लायंट आहे.
- तुम्ही MCP सर्व्हरमध्ये नवीन टूल्स जोडू शकता, ज्यामुळे एजंटच्या क्षमतांमध्ये वाढ होते.
- AI Toolkit मध्ये टेम्प्लेट्स आहेत (उदा. Python MCP सर्व्हर टेम्प्लेट्स) ज्यामुळे कस्टम टूल्स तयार करणे सोपे होते.

## अतिरिक्त स्रोत

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## पुढे काय

पुढील: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) चा वापर करून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये चुका किंवा अपूर्णता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुतीसाठी किंवा चुकीच्या अर्थसंग्रहासाठी आम्ही जबाबदार नाही.