<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:19:03+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "mr"
}
-->
# Visual Studio Code साठी AI टूलकिट विस्तारातून सर्व्हर वापरणे

जेव्हा तुम्ही AI एजंट तयार करत असता, तेव्हा फक्त स्मार्ट प्रतिसाद निर्माण करणे महत्त्वाचे नसते; तुमच्या एजंटला कृती करण्याची क्षमता देणे देखील महत्त्वाचे आहे. इथेच मॉडेल कॉन्टेक्स्ट प्रोटोकॉल (MCP) कामी येतो. MCP एजंट्सना बाह्य साधने आणि सेवा सुसंगत मार्गाने वापरण्यास सोपे करते. हे तुमच्या एजंटला एक टूलबॉक्समध्ये जोडल्यासारखे आहे ज्याचा तो *खरंच* उपयोग करू शकतो.

मानूया तुम्ही तुमच्या कॅल्क्युलेटर MCP सर्व्हरशी एजंट जोडला आहे. अचानक, तुमचा एजंट गणितीय ऑपरेशन्स फक्त "47 गुणिले 89 किती?" सारख्या प्रॉम्प्ट मिळाल्यावर करू शकतो—लॉजिक हार्डकोड करण्याची किंवा कस्टम API तयार करण्याची गरज नाही.

## आढावा

हे धडा कॅल्क्युलेटर MCP सर्व्हरला AI टूलकिट विस्ताराच्या मदतीने एजंटशी जोडण्याचे आणि तुमच्या एजंटला नैसर्गिक भाषेद्वारे बेरीज, वजाबाकी, गुणाकार आणि भागाकार सारख्या गणितीय ऑपरेशन्स करण्यास सक्षम करण्याचे समाविष्ट आहे.

AI टूलकिट हे Visual Studio Code साठी एक शक्तिशाली विस्तार आहे जे एजंट विकास सुलभ करते. AI अभियंते स्थानिक किंवा क्लाउडमध्ये जनरेटिव्ह AI मॉडेल विकसित करून आणि परीक्षण करून AI अनुप्रयोग सहजपणे तयार करू शकतात. विस्तार आज उपलब्ध असलेल्या प्रमुख जनरेटिव्ह मॉडेल्सना समर्थन देतो.

*टिप*: AI टूलकिट सध्या Python आणि TypeScript ला समर्थन देते.

## शिकण्याची उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- AI टूलकिटद्वारे MCP सर्व्हर वापरणे.
- MCP सर्व्हरद्वारे प्रदान केलेली साधने शोधणे आणि वापरणे सक्षम करण्यासाठी एजंट कॉन्फिगरेशन कॉन्फिगर करणे.
- नैसर्गिक भाषेद्वारे MCP साधने वापरणे.

## दृष्टिकोन

उच्च स्तरावर हे कसे करायचे आहे:

- एजंट तयार करा आणि त्याचे सिस्टम प्रॉम्प्ट निश्चित करा.
- कॅल्क्युलेटर साधनांसह MCP सर्व्हर तयार करा.
- एजंट बिल्डरला MCP सर्व्हरशी जोडा.
- नैसर्गिक भाषेद्वारे एजंटच्या साधनांच्या वापराची चाचणी करा.

छान, आता आपल्याला प्रवाह समजला आहे, चला MCP द्वारे बाह्य साधने वापरण्यासाठी AI एजंट कॉन्फिगर करूया, त्याच्या क्षमतांचा विस्तार करूया!

## पूर्वापेक्षिते

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code साठी AI टूलकिट](https://aka.ms/AIToolkit)

## व्यायाम: सर्व्हर वापरणे

या व्यायामात, तुम्ही AI टूलकिट वापरून Visual Studio Code मध्ये MCP सर्व्हरमधून साधनांसह AI एजंट तयार, चालवणे आणि वाढवणे कराल.

### -0- पूर्वपायरी, OpenAI GPT-4o मॉडेलला My Models मध्ये जोडा

व्यायाम **GPT-4o** मॉडेलचा उपयोग करतो. एजंट तयार करण्यापूर्वी मॉडेलला **My Models** मध्ये जोडले पाहिजे.

1. **AI टूलकिट** विस्तार **Activity Bar** मधून उघडा.
1. **Catalog** विभागात, **Models** निवडा ज्यामुळे **Model Catalog** उघडेल. **Models** निवडल्यावर **Model Catalog** नवीन संपादक टॅबमध्ये उघडते.
1. **Model Catalog** शोध पट्टीत **OpenAI GPT-4o** प्रविष्ट करा.
1. मॉडेलला तुमच्या **My Models** यादीत जोडण्यासाठी **+ Add** क्लिक करा. तुम्ही **Hosted by GitHub** मॉडेल निवडले असल्याचे सुनिश्चित करा.
1. **Activity Bar** मध्ये, **OpenAI GPT-4o** मॉडेल यादीत दिसत असल्याचे पुष्टी करा.

### -1- एजंट तयार करा

**Agent (Prompt) Builder** तुम्हाला स्वतःचे AI-सक्षम एजंट्स तयार आणि सानुकूलित करण्यास सक्षम करते. या विभागात, तुम्ही नवीन एजंट तयार कराल आणि संभाषणाची शक्ती देण्यासाठी मॉडेल असाइन कराल.

1. **AI टूलकिट** विस्तार **Activity Bar** मधून उघडा.
1. **Tools** विभागात, **Agent (Prompt) Builder** निवडा. **Agent (Prompt) Builder** निवडल्यावर **Agent (Prompt) Builder** नवीन संपादक टॅबमध्ये उघडते.
1. **+ New Builder** बटण क्लिक करा. विस्तार **Command Palette** द्वारे सेटअप विजार्ड सुरू करेल.
1. **Calculator Agent** नाव प्रविष्ट करा आणि **Enter** दाबा.
1. **Agent (Prompt) Builder** मध्ये, **Model** फील्डसाठी, **OpenAI GPT-4o (via GitHub)** मॉडेल निवडा.

### -2- एजंटसाठी सिस्टम प्रॉम्प्ट तयार करा

एजंटची संरचना झाल्यावर, त्याचे व्यक्तिमत्व आणि उद्देश निश्चित करण्याची वेळ आली आहे. या विभागात, तुम्ही **Generate system prompt** वैशिष्ट्याचा उपयोग करून एजंटच्या अपेक्षित वर्तनाचे वर्णन कराल—या प्रकरणात, एक कॅल्क्युलेटर एजंट—आणि मॉडेलला तुमच्यासाठी सिस्टम प्रॉम्प्ट लिहायला लावाल.

1. **Prompts** विभागासाठी, **Generate system prompt** बटण क्लिक करा. हे बटण प्रॉम्प्ट बिल्डर उघडते जे एजंटसाठी सिस्टम प्रॉम्प्ट तयार करण्यासाठी AI चा उपयोग करते.
1. **Generate a prompt** विंडोमध्ये, खालील प्रविष्ट करा: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** बटण क्लिक करा. सिस्टम प्रॉम्प्ट तयार होत असल्याचे पुष्टी करणारे एक सूचना तळाच्या-उजव्या कोपर्यात दिसेल. प्रॉम्प्ट तयार झाल्यावर, प्रॉम्प्ट **Agent (Prompt) Builder** च्या **System prompt** फील्डमध्ये दिसेल.
1. **System prompt** पुनरावलोकन करा आणि आवश्यक असल्यास बदल करा.

### -3- MCP सर्व्हर तयार करा

आता तुम्ही तुमच्या एजंटच्या सिस्टम प्रॉम्प्टला परिभाषित केले आहे—त्याच्या वर्तन आणि प्रतिसादांना मार्गदर्शन करून—त्याला व्यावहारिक क्षमतांनी सुसज्ज करण्याची वेळ आली आहे. या विभागात, तुम्ही कॅल्क्युलेटर MCP सर्व्हर तयार कराल ज्यात बेरीज, वजाबाकी, गुणाकार आणि भागाकार गणना करण्याची साधने असतील. हा सर्व्हर तुमच्या एजंटला नैसर्गिक भाषेतील प्रॉम्प्ट्सना प्रतिसाद म्हणून रिअल-टाइम गणितीय ऑपरेशन्स करण्यास सक्षम करेल.

AI टूलकिटमध्ये स्वतःचे MCP सर्व्हर तयार करण्याची सुलभता देण्यासाठी टेम्पलेट्स आहेत. आम्ही कॅल्क्युलेटर MCP सर्व्हर तयार करण्यासाठी Python टेम्पलेटचा उपयोग करू.

*टिप*: AI टूलकिट सध्या Python आणि TypeScript ला समर्थन देते.

1. **Agent (Prompt) Builder** च्या **Tools** विभागात, **+ MCP Server** बटण क्लिक करा. विस्तार **Command Palette** द्वारे सेटअप विजार्ड सुरू करेल.
1. **+ Add Server** निवडा.
1. **Create a New MCP Server** निवडा.
1. टेम्पलेट म्हणून **python-weather** निवडा.
1. MCP सर्व्हर टेम्पलेट जतन करण्यासाठी **Default folder** निवडा.
1. सर्व्हरसाठी खालील नाव प्रविष्ट करा: **Calculator**
1. नवीन Visual Studio Code विंडो उघडेल. **Yes, I trust the authors** निवडा.
1. टर्मिनलचा उपयोग करून (**Terminal** > **New Terminal**), वर्च्युअल एन्व्हायर्नमेंट तयार करा: `python -m venv .venv`
1. टर्मिनलचा उपयोग करून, वर्च्युअल एन्व्हायर्नमेंट सक्रिय करा:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. टर्मिनलचा उपयोग करून, डिपेंडन्सी स्थापित करा: `pip install -e .[dev]`
1. **Activity Bar** च्या **Explorer** दृश्यात, **src** निर्देशिका विस्तृत करा आणि **server.py** निवडा ज्यामुळे फाइल संपादकात उघडेल.
1. **server.py** फाइलमधील कोड खालीलप्रमाणे बदला आणि जतन करा:

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

आता तुमच्या एजंटकडे साधने आहेत, त्यांचा उपयोग करण्याची वेळ आली आहे! या विभागात, तुम्ही एजंटला प्रॉम्प्ट्स सबमिट कराल जेणेकरून एजंट कॅल्क्युलेटर MCP सर्व्हरमधून योग्य साधनाचा उपयोग करतो की नाही याची चाचणी आणि पडताळणी करता येईल.

तुम्ही तुमच्या स्थानिक विकास मशीनवर **Agent Builder** द्वारे MCP क्लायंट म्हणून कॅल्क्युलेटर MCP सर्व्हर चालवाल.

1. `F5` दाबा. **Tools** विभागात, **local-server-calculator_server** MCP सर्व्हर जोडलेला आहे हे सुनिश्चित करा आणि त्यात चार उपलब्ध साधने आहेत: add, subtract, multiply, आणि divide.
1. **User prompt** फील्डमध्ये खालील प्रविष्ट करा: ` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` मूल्ये **subtract** साधनासाठी असाइन केले जातात.
    - प्रत्येक साधनाचा प्रतिसाद संबंधित **Tool Response** मध्ये प्रदान केला जातो.
    - मॉडेलचा अंतिम आउटपुट अंतिम **Model Response** मध्ये प्रदान केला जातो.
1. एजंटची चाचणी करण्यासाठी अतिरिक्त प्रॉम्प्ट्स सबमिट करा. तुम्ही **User prompt** फील्डमध्ये क्लिक करून आणि विद्यमान प्रॉम्प्ट बदलून विद्यमान प्रॉम्प्ट बदलू शकता.
1. एजंटची चाचणी पूर्ण झाल्यावर, तुम्ही **terminal** मधून **CTRL/CMD+C** प्रविष्ट करून सर्व्हर थांबवू शकता.

## असाइनमेंट

तुमच्या **server.py** फाइलमध्ये अतिरिक्त साधन एंट्री जोडण्याचा प्रयत्न करा (उदा: एका संख्येचा वर्गमूळ परत करा). तुमच्या नवीन साधनाचा (किंवा विद्यमान साधनांचा) उपयोग करण्यासाठी एजंटला आवश्यक असणारे अतिरिक्त प्रॉम्प्ट्स सबमिट करा. नव्याने जोडलेल्या साधनांना लोड करण्यासाठी सर्व्हर रीस्टार्ट करण्याचे सुनिश्चित करा.

## उपाय

[Solution](./solution/README.md)

## मुख्य मुद्दे

या अध्यायाचे मुख्य मुद्दे खालीलप्रमाणे आहेत:

- AI टूलकिट विस्तार MCP सर्व्हर्स आणि त्यांची साधने वापरण्यासाठी एक उत्कृष्ट क्लायंट आहे.
- तुम्ही MCP सर्व्हर्सना नवीन साधने जोडू शकता, एजंटच्या क्षमतांचा विस्तार करून बदलत्या आवश्यकतांची पूर्तता करू शकता.
- AI टूलकिटमध्ये सानुकूल साधने तयार करण्यासाठी टेम्पलेट्स (उदा: Python MCP सर्व्हर टेम्पलेट्स) समाविष्ट आहेत.

## अतिरिक्त संसाधने

- [AI टूलकिट डॉक](https://aka.ms/AIToolkit/doc)

## पुढे काय

पुढे: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) चा वापर करून अनुवादित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये त्रुटी किंवा अचूकतेचा अभाव असू शकतो. मूळ भाषेतील दस्तऐवज हा अधिकृत स्रोत मानला जावा. महत्वाची माहिती साठी, व्यावसायिक मानवी अनुवादाची शिफारस केली जाते. या अनुवादाचा वापर करून उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार नाही.