<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5f321ea583cf087a94e47ee74c62b504",
  "translation_date": "2025-07-17T09:50:40+00:00",
  "source_file": "study_guide.md",
  "language_code": "hi"
}
-->
# Model Context Protocol (MCP) for Beginners - अध्ययन मार्गदर्शिका

यह अध्ययन मार्गदर्शिका "Model Context Protocol (MCP) for Beginners" पाठ्यक्रम के लिए रिपॉजिटरी की संरचना और सामग्री का अवलोकन प्रदान करती है। इस मार्गदर्शिका का उपयोग रिपॉजिटरी में कुशलतापूर्वक नेविगेट करने और उपलब्ध संसाधनों का अधिकतम लाभ उठाने के लिए करें।

## रिपॉजिटरी का अवलोकन

Model Context Protocol (MCP) AI मॉडल और क्लाइंट एप्लिकेशन के बीच इंटरैक्शन के लिए एक मानकीकृत फ्रेमवर्क है। इसे प्रारंभ में Anthropic द्वारा बनाया गया था, और अब इसे आधिकारिक GitHub संगठन के माध्यम से व्यापक MCP समुदाय द्वारा मेंटेन किया जाता है। यह रिपॉजिटरी C#, Java, JavaScript, Python, और TypeScript में व्यावहारिक कोड उदाहरणों के साथ एक व्यापक पाठ्यक्रम प्रदान करती है, जो AI डेवलपर्स, सिस्टम आर्किटेक्ट्स, और सॉफ्टवेयर इंजीनियरों के लिए डिज़ाइन किया गया है।

## विज़ुअल पाठ्यक्रम मानचित्र

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

## रिपॉजिटरी संरचना

रिपॉजिटरी को दस मुख्य भागों में व्यवस्थित किया गया है, जो MCP के विभिन्न पहलुओं पर केंद्रित हैं:

1. **Introduction (00-Introduction/)**
   - Model Context Protocol का परिचय
   - AI पाइपलाइनों में मानकीकरण क्यों महत्वपूर्ण है
   - व्यावहारिक उपयोग के मामले और लाभ

2. **Core Concepts (01-CoreConcepts/)**
   - क्लाइंट-सर्वर आर्किटेक्चर
   - प्रमुख प्रोटोकॉल घटक
   - MCP में मैसेजिंग पैटर्न

3. **Security (02-Security/)**
   - MCP-आधारित सिस्टम में सुरक्षा खतरें
   - सुरक्षित कार्यान्वयन के लिए सर्वोत्तम प्रथाएं
   - प्रमाणीकरण और प्राधिकरण रणनीतियाँ

4. **Getting Started (03-GettingStarted/)**
   - पर्यावरण सेटअप और कॉन्फ़िगरेशन
   - बेसिक MCP सर्वर और क्लाइंट बनाना
   - मौजूदा एप्लिकेशन के साथ एकीकरण
   - इसमें शामिल हैं:
     - पहला सर्वर इम्प्लीमेंटेशन
     - क्लाइंट विकास
     - LLM क्लाइंट एकीकरण
     - VS Code एकीकरण
     - Server-Sent Events (SSE) सर्वर
     - HTTP स्ट्रीमिंग
     - AI Toolkit एकीकरण
     - परीक्षण रणनीतियाँ
     - डिप्लॉयमेंट दिशानिर्देश

5. **Practical Implementation (04-PracticalImplementation/)**
   - विभिन्न प्रोग्रामिंग भाषाओं में SDK का उपयोग
   - डिबगिंग, परीक्षण, और सत्यापन तकनीकें
   - पुन: उपयोग योग्य प्रॉम्प्ट टेम्पलेट और वर्कफ़्लो बनाना
   - कार्यान्वयन उदाहरणों के साथ नमूना प्रोजेक्ट्स

6. **Advanced Topics (05-AdvancedTopics/)**
   - कॉन्टेक्स्ट इंजीनियरिंग तकनीकें
   - Foundry एजेंट एकीकरण
   - मल्टी-मोडल AI वर्कफ़्लोज़
   - OAuth2 प्रमाणीकरण डेमो
   - रियल-टाइम सर्च क्षमताएं
   - रियल-टाइम स्ट्रीमिंग
   - रूट कॉन्टेक्स्ट्स का कार्यान्वयन
   - रूटिंग रणनीतियाँ
   - सैंपलिंग तकनीकें
   - स्केलिंग दृष्टिकोण
   - सुरक्षा विचार
   - Entra ID सुरक्षा एकीकरण
   - वेब सर्च एकीकरण

7. **Community Contributions (06-CommunityContributions/)**
   - कोड और दस्तावेज़ में योगदान कैसे करें
   - GitHub के माध्यम से सहयोग
   - समुदाय-चालित सुधार और प्रतिक्रिया
   - विभिन्न MCP क्लाइंट्स का उपयोग (Claude Desktop, Cline, VSCode)
   - लोकप्रिय MCP सर्वरों के साथ काम करना, जिसमें इमेज जनरेशन शामिल है

8. **Lessons from Early Adoption (07-LessonsfromEarlyAdoption/)**
   - वास्तविक दुनिया के कार्यान्वयन और सफलता की कहानियां
   - MCP-आधारित समाधान बनाना और डिप्लॉय करना
   - रुझान और भविष्य की रूपरेखा

9. **Best Practices (08-BestPractices/)**
   - प्रदर्शन ट्यूनिंग और अनुकूलन
   - फॉल्ट-टॉलरेंट MCP सिस्टम डिज़ाइन करना
   - परीक्षण और लचीलापन रणनीतियाँ

10. **Case Studies (09-CaseStudy/)**
    - केस स्टडी: Azure API Management एकीकरण
    - केस स्टडी: ट्रैवल एजेंट कार्यान्वयन
    - केस स्टडी: Azure DevOps का YouTube के साथ एकीकरण
    - विस्तृत दस्तावेज़ के साथ कार्यान्वयन उदाहरण

11. **Hands-on Workshop (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - MCP और AI Toolkit को मिलाकर व्यापक हैंड्स-ऑन वर्कशॉप
    - AI मॉडल्स को वास्तविक दुनिया के टूल्स से जोड़ने वाले बुद्धिमान एप्लिकेशन बनाना
    - मूल बातें, कस्टम सर्वर विकास, और प्रोडक्शन डिप्लॉयमेंट रणनीतियों को कवर करने वाले व्यावहारिक मॉड्यूल
    - चरण-दर-चरण निर्देशों के साथ लैब-आधारित सीखने का तरीका

## अतिरिक्त संसाधन

रिपॉजिटरी में सहायक संसाधन शामिल हैं:

- **Images फ़ोल्डर**: पाठ्यक्रम में उपयोग किए गए आरेख और चित्र
- **Translations**: दस्तावेज़ों के स्वचालित बहुभाषी अनुवाद
- **Official MCP Resources**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## इस रिपॉजिटरी का उपयोग कैसे करें

1. **क्रमिक सीखना**: संरचित सीखने के लिए अध्यायों को क्रम से (00 से 10 तक) पढ़ें।
2. **भाषा-विशिष्ट फोकस**: यदि आप किसी विशेष प्रोग्रामिंग भाषा में रुचि रखते हैं, तो अपनी पसंदीदा भाषा में कार्यान्वयन के लिए samples डायरेक्टरी देखें।
3. **व्यावहारिक कार्यान्वयन**: "Getting Started" सेक्शन से शुरू करें, अपना पर्यावरण सेटअप करें और अपना पहला MCP सर्वर और क्लाइंट बनाएं।
4. **उन्नत अन्वेषण**: मूल बातें समझने के बाद उन्नत विषयों में गहराई से जाएं।
5. **समुदाय में भागीदारी**: GitHub डिस्कशन और Discord चैनलों के माध्यम से MCP समुदाय से जुड़ें और विशेषज्ञों तथा अन्य डेवलपर्स के साथ संवाद करें।

## MCP क्लाइंट्स और टूल्स

पाठ्यक्रम में विभिन्न MCP क्लाइंट्स और टूल्स शामिल हैं:

1. **Official Clients**:
   - Visual Studio Code
   - MCP in Visual Studio Code
   - Claude Desktop
   - Claude in VSCode
   - Claude API

2. **Community Clients**:
   - Cline (टर्मिनल-आधारित)
   - Cursor (कोड एडिटर)
   - ChatMCP
   - Windsurf

3. **MCP Management Tools**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## लोकप्रिय MCP सर्वर

रिपॉजिटरी विभिन्न MCP सर्वरों का परिचय कराती है, जिनमें शामिल हैं:

1. **Official Reference Servers**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

2. **Image Generation**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

3. **Development Tools**:
   - Git MCP
   - Terminal Control
   - Code Assistant

4. **Specialized Servers**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## योगदान

यह रिपॉजिटरी समुदाय से योगदान का स्वागत करती है। MCP इकोसिस्टम में प्रभावी योगदान के लिए Community Contributions सेक्शन देखें।

## परिवर्तन विवरण

| तारीख | परिवर्तन |
|-------|----------|
| 16 जुलाई, 2025 | - वर्तमान सामग्री को दर्शाने के लिए रिपॉजिटरी संरचना अपडेट की गई<br>- MCP Clients और Tools सेक्शन जोड़ा गया<br>- लोकप्रिय MCP सर्वर सेक्शन जोड़ा गया<br>- सभी वर्तमान विषयों के साथ विज़ुअल पाठ्यक्रम मानचित्र अपडेट किया गया<br>- सभी विशेष क्षेत्रों के साथ Advanced Topics सेक्शन को बेहतर बनाया गया<br>- वास्तविक उदाहरणों को दर्शाने के लिए Case Studies अपडेट की गईं<br>- MCP की उत्पत्ति को Anthropic द्वारा बनाए जाने के रूप में स्पष्ट किया गया |
| 11 जून, 2025 | - अध्ययन मार्गदर्शिका का प्रारंभिक निर्माण<br>- विज़ुअल पाठ्यक्रम मानचित्र जोड़ा गया<br>- रिपॉजिटरी संरचना का खाका तैयार किया गया<br>- नमूना प्रोजेक्ट्स और अतिरिक्त संसाधन शामिल किए गए |

---

*यह अध्ययन मार्गदर्शिका 16 जुलाई, 2025 को अपडेट की गई थी और उस तारीख तक की रिपॉजिटरी का अवलोकन प्रदान करती है। इस तारीख के बाद रिपॉजिटरी की सामग्री अपडेट हो सकती है।*

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।