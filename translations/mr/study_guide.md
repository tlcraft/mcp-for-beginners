<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5f321ea583cf087a94e47ee74c62b504",
  "translation_date": "2025-07-17T05:25:16+00:00",
  "source_file": "study_guide.md",
  "language_code": "mr"
}
-->
# Model Context Protocol (MCP) for Beginners - अभ्यास मार्गदर्शक

हा अभ्यास मार्गदर्शक "Model Context Protocol (MCP) for Beginners" अभ्यासक्रमासाठी रिपॉझिटरीची रचना आणि सामग्री याचा आढावा देतो. रिपॉझिटरीमध्ये सहजपणे नेव्हिगेट करण्यासाठी आणि उपलब्ध संसाधनांचा पूर्ण फायदा घेण्यासाठी हा मार्गदर्शक वापरा.

## रिपॉझिटरीचा आढावा

Model Context Protocol (MCP) हा AI मॉडेल्स आणि क्लायंट अ‍ॅप्लिकेशन्समधील संवादासाठी एक मानकीकृत फ्रेमवर्क आहे. सुरुवातीला Anthropic ने तयार केलेला MCP आता अधिक व्यापक MCP समुदायाद्वारे अधिकृत GitHub संस्थेद्वारे देखभाल केला जातो. ही रिपॉझिटरी C#, Java, JavaScript, Python, आणि TypeScript मध्ये हाताळणीसाठी कोड उदाहरणांसह एक संपूर्ण अभ्यासक्रम प्रदान करते, जो AI विकसक, सिस्टीम आर्किटेक्ट्स आणि सॉफ्टवेअर अभियंत्यांसाठी डिझाइन केलेला आहे.

## व्हिज्युअल अभ्यासक्रम नकाशा

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization)
      (Use Cases)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
    02. Security
      ::icon(fa fa-shield)
      (Threat Models)
      (Best Practices)
      (Auth Strategies)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server)
      (Client)
      (LLM Client)
      (VS Code Integration)
      (SSE Server)
      (HTTP Streaming)
      (AI Toolkit)
      (Testing)
      (Deployment)
    04. Practical Implementation
      ::icon(fa fa-code)
      (SDKs)
      (Testing/Debugging)
      (Prompt Templates)
      (Sample Projects)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Integration)
      (Multi-modal AI)
      (OAuth2 Demo)
      (Real-time Search)
      (Streaming)
      (Root Contexts)
      (Routing)
      (Sampling)
      (Scaling)
      (Security)
      (Entra ID)
      (Web Search)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Clients)
      (MCP Servers)
      (Image Generation)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Real-world Examples)
      (Deployment Stories)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance)
      (Fault Tolerance)
      (Resilience)
    09. Case Studies
      ::icon(fa fa-file-text)
      (API Management)
      (Travel Agent)
      (Azure DevOps)
      (Documentation MCP)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (AI Toolkit Integration)
      (Custom Server Development)
      (Production Deployment)
```

## रिपॉझिटरीची रचना

रिपॉझिटरी दहा मुख्य विभागांमध्ये विभागलेली आहे, ज्यामध्ये MCP च्या विविध पैलूंवर लक्ष केंद्रित केले आहे:

1. **Introduction (00-Introduction/)**
   - Model Context Protocol चे आढावा
   - AI पाइपलाइनमध्ये मानकीकरण का महत्त्वाचे आहे
   - व्यावहारिक वापर आणि फायदे

2. **Core Concepts (01-CoreConcepts/)**
   - क्लायंट-सर्व्हर आर्किटेक्चर
   - मुख्य प्रोटोकॉल घटक
   - MCP मधील मेसेजिंग पॅटर्न्स

3. **Security (02-Security/)**
   - MCP-आधारित प्रणालींमधील सुरक्षा धोके
   - सुरक्षित अंमलबजावणीसाठी सर्वोत्तम पद्धती
   - प्रमाणीकरण आणि अधिकृतरण धोरणे

4. **Getting Started (03-GettingStarted/)**
   - पर्यावरण सेटअप आणि कॉन्फिगरेशन
   - मूलभूत MCP सर्व्हर आणि क्लायंट तयार करणे
   - विद्यमान अ‍ॅप्लिकेशन्सशी एकत्रीकरण
   - यामध्ये समाविष्ट विभाग:
     - पहिल्या सर्व्हरची अंमलबजावणी
     - क्लायंट विकास
     - LLM क्लायंट एकत्रीकरण
     - VS Code एकत्रीकरण
     - Server-Sent Events (SSE) सर्व्हर
     - HTTP स्ट्रीमिंग
     - AI Toolkit एकत्रीकरण
     - चाचणी धोरणे
     - तैनाती मार्गदर्शक

5. **Practical Implementation (04-PracticalImplementation/)**
   - विविध प्रोग्रामिंग भाषांमध्ये SDK वापरणे
   - डीबगिंग, चाचणी आणि प्रमाणीकरण तंत्रे
   - पुनर्वापरयोग्य प्रॉम्प्ट टेम्पलेट्स आणि वर्कफ्लोज तयार करणे
   - अंमलबजावणीसह नमुना प्रकल्प

6. **Advanced Topics (05-AdvancedTopics/)**
   - संदर्भ अभियांत्रिकी तंत्रे
   - Foundry एजंट एकत्रीकरण
   - मल्टी-मोडल AI वर्कफ्लोज
   - OAuth2 प्रमाणीकरण डेमो
   - रिअल-टाइम शोध क्षमता
   - रिअल-टाइम स्ट्रीमिंग
   - रूट संदर्भांची अंमलबजावणी
   - राउटिंग धोरणे
   - सॅम्पलिंग तंत्रे
   - स्केलिंग पद्धती
   - सुरक्षा विचार
   - Entra ID सुरक्षा एकत्रीकरण
   - वेब शोध एकत्रीकरण

7. **Community Contributions (06-CommunityContributions/)**
   - कोड आणि दस्तऐवज कसे योगदान द्यायचे
   - GitHub द्वारे सहकार्य करणे
   - समुदाय-चालित सुधारणा आणि अभिप्राय
   - विविध MCP क्लायंट्स वापरणे (Claude Desktop, Cline, VSCode)
   - लोकप्रिय MCP सर्व्हर्ससह काम करणे, ज्यात इमेज जनरेशन देखील आहे

8. **Lessons from Early Adoption (07-LessonsfromEarlyAdoption/)**
   - प्रत्यक्ष अंमलबजावणी आणि यशोगाथा
   - MCP-आधारित सोल्यूशन्स तयार करणे आणि तैनात करणे
   - ट्रेंड्स आणि भविष्यातील रोडमॅप

9. **Best Practices (08-BestPractices/)**
   - कार्यक्षमता ट्यूनिंग आणि ऑप्टिमायझेशन
   - दोष सहनशील MCP प्रणाली डिझाइन करणे
   - चाचणी आणि टिकाऊपणा धोरणे

10. **Case Studies (09-CaseStudy/)**
    - केस स्टडी: Azure API Management एकत्रीकरण
    - केस स्टडी: ट्रॅव्हल एजंट अंमलबजावणी
    - केस स्टडी: Azure DevOps चे YouTube सह एकत्रीकरण
    - सविस्तर दस्तऐवजासह अंमलबजावणी उदाहरणे

11. **Hands-on Workshop (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - MCP आणि AI Toolkit यांचा समावेश असलेली सर्वसमावेशक व्यावहारिक कार्यशाळा
    - AI मॉडेल्सना प्रत्यक्ष जगातील साधनांशी जोडणाऱ्या बुद्धिमान अ‍ॅप्लिकेशन्सची निर्मिती
    - मूलभूत गोष्टी, कस्टम सर्व्हर विकास आणि उत्पादन तैनाती धोरणे यांचा समावेश असलेले व्यावहारिक मॉड्यूल्स
    - टप्प्याटप्प्याने मार्गदर्शनासह लॅब-आधारित शिक्षण पद्धत

## अतिरिक्त संसाधने

रिपॉझिटरीमध्ये खालील सहाय्यक संसाधने आहेत:

- **Images फोल्डर**: अभ्यासक्रमात वापरलेली आकृत्या आणि चित्रे
- **Translations**: दस्तऐवजांचे स्वयंचलित बहुभाषिक अनुवाद
- **अधिकृत MCP संसाधने**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## ही रिपॉझिटरी कशी वापरावी

1. **क्रमिक शिक्षण**: अध्याय 00 ते 10 पर्यंत क्रमाने वाचा, ज्यामुळे संरचित शिकण्याचा अनुभव मिळेल.
2. **भाषा-विशिष्ट लक्ष**: जर तुम्हाला एखाद्या विशिष्ट प्रोग्रामिंग भाषेत रस असेल, तर तुमच्या पसंतीच्या भाषेतील अंमलबजावणीसाठी नमुना निर्देशिकांचा अभ्यास करा.
3. **व्यावहारिक अंमलबजावणी**: "Getting Started" विभागापासून सुरुवात करा, पर्यावरण सेटअप करा आणि तुमचा पहिला MCP सर्व्हर व क्लायंट तयार करा.
4. **प्रगत अभ्यास**: मूलभूत गोष्टी समजल्यावर, प्रगत विषयांमध्ये खोलवर जा आणि तुमचे ज्ञान वाढवा.
5. **समुदाय सहभाग**: GitHub चर्चा आणि Discord चॅनेल्सद्वारे MCP समुदायात सहभागी व्हा, तज्ञ आणि इतर विकसकांशी संपर्क साधा.

## MCP क्लायंट्स आणि साधने

अभ्यासक्रमात विविध MCP क्लायंट्स आणि साधने समाविष्ट आहेत:

1. **अधिकृत क्लायंट्स**:
   - Visual Studio Code
   - MCP in Visual Studio Code
   - Claude Desktop
   - Claude in VSCode
   - Claude API

2. **समुदाय क्लायंट्स**:
   - Cline (टर्मिनल-आधारित)
   - Cursor (कोड संपादक)
   - ChatMCP
   - Windsurf

3. **MCP व्यवस्थापन साधने**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## लोकप्रिय MCP सर्व्हर्स

रिपॉझिटरीमध्ये विविध MCP सर्व्हर्सची ओळख करून दिली आहे, ज्यात:

1. **अधिकृत संदर्भ सर्व्हर्स**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

2. **इमेज जनरेशन**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

3. **विकास साधने**:
   - Git MCP
   - Terminal Control
   - Code Assistant

4. **विशेषीकृत सर्व्हर्स**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## योगदान देणे

ही रिपॉझिटरी समुदायाकडून योगदानांचे स्वागत करते. MCP परिसंस्थेत प्रभावी योगदान कसे द्यायचे यासाठी Community Contributions विभाग पहा.

## बदलनोंची नोंद

| तारीख | बदल |
|-------|-------|
| July 16, 2025 | - वर्तमान सामग्री प्रतिबिंबित करण्यासाठी रिपॉझिटरी रचना अद्ययावत केली<br>- MCP Clients आणि Tools विभाग जोडला<br>- लोकप्रिय MCP सर्व्हर्स विभाग जोडला<br>- सर्व वर्तमान विषयांसह व्हिज्युअल अभ्यासक्रम नकाशा सुधारित केला<br>- सर्व विशेष क्षेत्रांसह Advanced Topics विभाग वाढविला<br>- प्रत्यक्ष उदाहरणांसह Case Studies अद्ययावत केल्या<br>- MCP ची सुरुवात Anthropic कडून झाली असल्याचे स्पष्ट केले |
| June 11, 2025 | - अभ्यास मार्गदर्शकाची प्राथमिक निर्मिती<br>- व्हिज्युअल अभ्यासक्रम नकाशा जोडला<br>- रिपॉझिटरी रचना मांडली<br>- नमुना प्रकल्प आणि अतिरिक्त संसाधने समाविष्ट केली |

---

*हा अभ्यास मार्गदर्शक 16 जुलै 2025 रोजी अद्ययावत करण्यात आला असून त्या तारखेपर्यंतच्या रिपॉझिटरीचा आढावा देतो. त्यानंतर रिपॉझिटरीची सामग्री अद्ययावत केली जाऊ शकते.*

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.