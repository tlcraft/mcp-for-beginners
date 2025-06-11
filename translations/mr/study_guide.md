<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a607d4febc94caee9a12b77795f7fc9a",
  "translation_date": "2025-06-11T16:40:52+00:00",
  "source_file": "study_guide.md",
  "language_code": "mr"
}
-->
# Model Context Protocol (MCP) for Beginners - अभ्यास मार्गदर्शक

हा अभ्यास मार्गदर्शक "Model Context Protocol (MCP) for Beginners" अभ्यासक्रमासाठी रिपॉझिटरीच्या रचनेचा आणि सामग्रीचा आढावा देतो. उपलब्ध संसाधनांचा प्रभावी वापर करण्यासाठी आणि रिपॉझिटरीमध्ये सहज नेव्हिगेट करण्यासाठी हा मार्गदर्शक वापरा.

## रिपॉझिटरीचा आढावा

Model Context Protocol (MCP) हा AI मॉडेल्स आणि क्लायंट अॅप्लिकेशन्समधील संवादासाठी एक मानकीकृत फ्रेमवर्क आहे. ही रिपॉझिटरी C#, Java, JavaScript, Python, आणि TypeScript मध्ये व्यावहारिक कोड उदाहरणांसह व्यापक अभ्यासक्रम प्रदान करते, जो AI डेव्हलपर्स, सिस्टम आर्किटेक्ट्स, आणि सॉफ्टवेअर इंजिनियर्ससाठी तयार केला आहे.

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
      (First Client)
      (LLM Client)
      (VS Code Integration)
      (SSE Server)
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
      (Multi-modal AI)
      (Scaling)
      (Enterprise Integration)
      (Azure Integration)
      (OAuth2)
      (Root Contexts)
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (Feedback)
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
      (Solution Architectures)
      (Deployment Blueprints)
      (Project Walkthroughs)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (AI Toolkit Integration)
      (Custom Server Development)
      (Production Deployment)
```

## रिपॉझिटरीची रचना

ही रिपॉझिटरी दहा मुख्य विभागांमध्ये विभागलेली आहे, ज्यामध्ये MCP च्या विविध पैलूंवर लक्ष केंद्रित केले आहे:

1. **परिचय (00-Introduction/)**
   - Model Context Protocol ची ओळख
   - AI पाइपलाइनमधील मानकीकरण का महत्त्वाचे आहे
   - व्यावहारिक वापर आणि फायदे

2. **मूलभूत संकल्पना (01-CoreConcepts/)**
   - क्लायंट-सर्व्हर आर्किटेक्चर
   - मुख्य प्रोटोकॉल घटक
   - MCP मधील मेसेजिंग पॅटर्न्स

3. **सुरक्षा (02-Security/)**
   - MCP-आधारित प्रणालीतील सुरक्षा धोके
   - सुरक्षित अंमलबजावणीसाठी सर्वोत्तम पद्धती
   - प्रमाणीकरण आणि अधिकृतरण धोरणे

4. **प्रारंभ करणे (03-GettingStarted/)**
   - वातावरण सेटअप आणि कॉन्फिगरेशन
   - मूलभूत MCP सर्व्हर आणि क्लायंट तयार करणे
   - विद्यमान अॅप्लिकेशन्ससह एकत्रीकरण
   - पहिले सर्व्हर, पहिले क्लायंट, LLM क्लायंट, VS Code एकत्रीकरण, SSE सर्व्हर, AI Toolkit, चाचणी, आणि डिप्लॉयमेंटसाठी उपविभाग

5. **व्यावहारिक अंमलबजावणी (04-PracticalImplementation/)**
   - वेगवेगळ्या प्रोग्रामिंग भाषांमध्ये SDK वापरणे
   - डीबगिंग, चाचणी, आणि वैधता तंत्रे
   - पुनर्वापरयोग्य प्रॉम्प्ट टेम्पलेट्स आणि वर्कफ्लोज तयार करणे
   - अंमलबजावणी उदाहरणांसह नमुना प्रकल्प

6. **प्रगत विषय (05-AdvancedTopics/)**
   - मल्टी-मोडल AI वर्कफ्लोज आणि विस्तारक्षमतेवर लक्ष
   - सुरक्षित स्केलिंग धोरणे
   - एंटरप्राइझ इकोसिस्टममधील MCP
   - Azure एकत्रीकरण, मल्टी-मोडॅलिटी, OAuth2, रूट कॉन्टेक्स्ट्स, राउटिंग, सॅम्पलिंग, स्केलिंग, सुरक्षा, वेब शोध एकत्रीकरण, आणि स्ट्रीमिंगसह विशेष विषय

7. **समुदाय योगदान (06-CommunityContributions/)**
   - कोड आणि दस्तऐवजीकरणात कसे योगदान द्यावे
   - GitHub द्वारे सहकार्य करणे
   - समुदाय-चालित सुधारणा आणि अभिप्राय

8. **प्रारंभिक स्वीकारातून धडे (07-LessonsfromEarlyAdoption/)**
   - प्रत्यक्ष अंमलबजावणी आणि यशोगाथा
   - MCP-आधारित सोल्यूशन्स तयार करणे आणि तैनात करणे
   - ट्रेंड्स आणि भविष्यातील रोडमॅप

9. **सर्वोत्तम पद्धती (08-BestPractices/)**
   - कामगिरी tuning आणि ऑप्टिमायझेशन
   - दोष सहन करणाऱ्या MCP प्रणालींचे डिझाइन
   - चाचणी आणि लवचीकता धोरणे

10. **केस स्टडीज (09-CaseStudy/)**
    - MCP सोल्यूशन आर्किटेक्चरमध्ये सखोल अभ्यास
    - डिप्लॉयमेंट ब्लूप्रिंट्स आणि एकत्रीकरण टिप्स
    - टिप्पणीसहित आकृत्या आणि प्रकल्प मार्गदर्शन

11. **हाताळणी कार्यशाळा (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Microsoft च्या AI Toolkit सह MCP एकत्र करणारी सर्वसमावेशक हाताळणी कार्यशाळा
    - AI मॉडेल्सना प्रत्यक्ष साधनांशी जोडणाऱ्या बुद्धिमान अॅप्लिकेशन्सची निर्मिती
    - मूलभूत तत्त्वे, कस्टम सर्व्हर विकास, आणि उत्पादन डिप्लॉयमेंट धोरणे यांचा समावेश असलेले व्यावहारिक मॉड्यूल्स

## नमुना प्रकल्प

ही रिपॉझिटरी विविध प्रोग्रामिंग भाषांमध्ये MCP अंमलबजावणी दाखवणारे अनेक नमुना प्रकल्प समाविष्ट करते:

### मूलभूत MCP कॅल्क्युलेटर नमुने
- C# MCP सर्व्हर उदाहरण
- Java MCP कॅल्क्युलेटर
- JavaScript MCP डेमो
- Python MCP सर्व्हर
- TypeScript MCP उदाहरण

### प्रगत MCP कॅल्क्युलेटर प्रकल्प
- प्रगत C# नमुना
- Java कंटेनर अॅप उदाहरण
- JavaScript प्रगत नमुना
- Python क्लिष्ट अंमलबजावणी
- TypeScript कंटेनर नमुना

## अतिरिक्त संसाधने

ही रिपॉझिटरी खालील सहाय्यक संसाधने समाविष्ट करते:

- **Images फोल्डर**: अभ्यासक्रमात वापरलेली आकृत्या आणि चित्रे
- **Translations**: दस्तऐवजीकरणाच्या स्वयंचलित भाषांतरांसह बहुभाषिक समर्थन
- **अधिकृत MCP संसाधने**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## या रिपॉझिटरीचा कसा वापर करावा

1. **सुसंगत शिकणे**: 00 ते 10 पर्यंतचे अध्याय क्रमाने फॉलो करा जेणेकरून शिस्तबद्ध शिकण्याचा अनुभव मिळेल.
2. **भाषानिहाय लक्ष केंद्रित करणे**: जर तुम्हाला विशिष्ट प्रोग्रामिंग भाषेमध्ये रस असेल तर त्या भाषेतील अंमलबजावणीसाठी नमुना निर्देशिकांचा अभ्यास करा.
3. **व्यावहारिक अंमलबजावणी**: वातावरण सेटअप करण्यासाठी आणि तुमचा पहिला MCP सर्व्हर आणि क्लायंट तयार करण्यासाठी "Getting Started" विभागातून सुरुवात करा.
4. **प्रगत अन्वेषण**: मूलभूत गोष्टी समजल्यावर, प्रगत विषयांमध्ये खोलवर जा आणि तुमचे ज्ञान वाढवा.
5. **समुदायात सहभागी व्हा**: तज्ञ आणि सह-डेव्हलपर्सशी जोडण्यासाठी [Azure AI Foundry Discord](https://discord.com/invite/ByRwuEEgH4) मध्ये सामील व्हा.

## योगदान देणे

ही रिपॉझिटरी समुदायाकडून योगदानाला स्वागत करते. योगदान कसे द्यायचे यासाठी Community Contributions विभाग पहा.

---

*हा अभ्यास मार्गदर्शक 11 जून 2025 रोजी तयार केला गेला असून त्या तारखेपर्यंतच्या रिपॉझिटरीचा आढावा प्रदान करतो. त्यानंतर रिपॉझिटरीची सामग्री अद्यतनित झाली असू शकते.*

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात घ्या की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.