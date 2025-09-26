<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "719117a0a5f34ade7b5dfb61ee06fb13",
  "translation_date": "2025-09-26T18:00:37+00:00",
  "source_file": "study_guide.md",
  "language_code": "hi"
}
-->
# मॉडल कॉन्टेक्स्ट प्रोटोकॉल (MCP) शुरुआती लोगों के लिए - अध्ययन गाइड

यह अध्ययन गाइड "मॉडल कॉन्टेक्स्ट प्रोटोकॉल (MCP) शुरुआती लोगों के लिए" पाठ्यक्रम की रिपॉजिटरी संरचना और सामग्री का अवलोकन प्रदान करता है। इस गाइड का उपयोग रिपॉजिटरी को कुशलतापूर्वक नेविगेट करने और उपलब्ध संसाधनों का अधिकतम लाभ उठाने के लिए करें।

## रिपॉजिटरी का अवलोकन

मॉडल कॉन्टेक्स्ट प्रोटोकॉल (MCP) AI मॉडल और क्लाइंट एप्लिकेशन के बीच इंटरैक्शन के लिए एक मानकीकृत फ्रेमवर्क है। इसे मूल रूप से Anthropic द्वारा बनाया गया था और अब व्यापक MCP समुदाय द्वारा आधिकारिक GitHub संगठन के माध्यम से बनाए रखा जाता है। यह रिपॉजिटरी AI डेवलपर्स, सिस्टम आर्किटेक्ट्स और सॉफ्टवेयर इंजीनियरों के लिए C#, Java, JavaScript, Python, और TypeScript में हैंड्स-ऑन कोड उदाहरणों के साथ एक व्यापक पाठ्यक्रम प्रदान करती है।

## विजुअल पाठ्यक्रम मानचित्र

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization Benefits)
      (Real-world Use Cases)
      (AI Integration Fundamentals)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
      (Transport Mechanisms)
    02. Security
      ::icon(fa fa-shield)
      (AI-Specific Threats)
      (Best Practices 2025)
      (Azure Content Safety)
      (Auth & Authorization)
      (Microsoft Prompt Shields)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server Implementation)
      (Client Development)
      (LLM Client Integration)
      (VS Code Extensions)
      (SSE Server Setup)
      (HTTP Streaming)
      (AI Toolkit Integration)
      (Testing Frameworks)
      (Deployment Strategies)
    04. Practical Implementation
      ::icon(fa fa-code)
      (Multi-Language SDKs)
      (Testing & Debugging)
      (Prompt Templates)
      (Sample Projects)
      (Production Patterns)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Agent Integration)
      (Multi-modal AI Workflows)
      (OAuth2 Authentication)
      (Real-time Search)
      (Streaming Protocols)
      (Root Contexts)
      (Routing Strategies)
      (Sampling Techniques)
      (Scaling Solutions)
      (Security Hardening)
      (Entra ID Integration)
      (Web Search MCP)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Client Ecosystem)
      (MCP Server Registry)
      (Image Generation Tools)
      (GitHub Collaboration)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Production Deployments)
      (Microsoft MCP Servers)
      (Azure MCP Service)
      (Enterprise Case Studies)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance Optimization)
      (Fault Tolerance)
      (System Resilience)
      (Monitoring & Observability)
    09. Case Studies
      ::icon(fa fa-file-text)
      (Azure API Management)
      (AI Travel Agent)
      (Azure DevOps Integration)
      (Documentation MCP)
      (GitHub MCP Registry)
      (VS Code Integration)
      (Real-world Implementations)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (MCP Server Fundamentals)
      (Advanced Development)
      (AI Toolkit Integration)
      (Production Deployment)
      (4-Lab Structure)
```

## रिपॉजिटरी संरचना

रिपॉजिटरी दस मुख्य अनुभागों में संगठित है, प्रत्येक MCP के विभिन्न पहलुओं पर केंद्रित है:

1. **परिचय (00-Introduction/)**
   - मॉडल कॉन्टेक्स्ट प्रोटोकॉल का अवलोकन
   - AI पाइपलाइनों में मानकीकरण क्यों महत्वपूर्ण है
   - व्यावहारिक उपयोग के मामले और लाभ

2. **मुख्य अवधारणाएँ (01-CoreConcepts/)**
   - क्लाइंट-सर्वर आर्किटेक्चर
   - प्रमुख प्रोटोकॉल घटक
   - MCP में मैसेजिंग पैटर्न

3. **सुरक्षा (02-Security/)**
   - MCP-आधारित सिस्टम में सुरक्षा खतरों
   - कार्यान्वयन को सुरक्षित करने के लिए सर्वोत्तम प्रथाएँ
   - प्रमाणीकरण और प्राधिकरण रणनीतियाँ
   - **व्यापक सुरक्षा दस्तावेज़ीकरण**:
     - MCP सुरक्षा सर्वोत्तम प्रथाएँ 2025
     - Azure सामग्री सुरक्षा कार्यान्वयन गाइड
     - MCP सुरक्षा नियंत्रण और तकनीकें
     - MCP सर्वोत्तम प्रथाएँ त्वरित संदर्भ
   - **मुख्य सुरक्षा विषय**:
     - प्रॉम्प्ट इंजेक्शन और टूल पॉइज़निंग हमले
     - सत्र अपहरण और भ्रमित डिप्टी समस्याएँ
     - टोकन पासथ्रू कमजोरियाँ
     - अत्यधिक अनुमतियाँ और एक्सेस नियंत्रण
     - AI घटकों के लिए सप्लाई चेन सुरक्षा
     - Microsoft प्रॉम्प्ट शील्ड्स एकीकरण

4. **शुरुआत करना (03-GettingStarted/)**
   - पर्यावरण सेटअप और कॉन्फ़िगरेशन
   - बुनियादी MCP सर्वर और क्लाइंट बनाना
   - मौजूदा एप्लिकेशन के साथ एकीकरण
   - इसमें शामिल हैं:
     - पहला सर्वर कार्यान्वयन
     - क्लाइंट विकास
     - LLM क्लाइंट एकीकरण
     - VS Code एकीकरण
     - सर्वर-सेंट इवेंट्स (SSE) सर्वर
     - HTTP स्ट्रीमिंग
     - AI टूलकिट एकीकरण
     - परीक्षण रणनीतियाँ
     - परिनियोजन दिशानिर्देश

5. **व्यावहारिक कार्यान्वयन (04-PracticalImplementation/)**
   - विभिन्न प्रोग्रामिंग भाषाओं में SDKs का उपयोग
   - डिबगिंग, परीक्षण, और सत्यापन तकनीकें
   - पुन: उपयोग योग्य प्रॉम्प्ट टेम्पलेट और वर्कफ़्लो तैयार करना
   - कार्यान्वयन उदाहरणों के साथ नमूना परियोजनाएँ

6. **उन्नत विषय (05-AdvancedTopics/)**
   - कॉन्टेक्स्ट इंजीनियरिंग तकनीकें
   - Foundry एजेंट एकीकरण
   - मल्टी-मोडल AI वर्कफ़्लो
   - OAuth2 प्रमाणीकरण डेमो
   - रियल-टाइम सर्च क्षमताएँ
   - रियल-टाइम स्ट्रीमिंग
   - रूट कॉन्टेक्स्ट कार्यान्वयन
   - रूटिंग रणनीतियाँ
   - सैंपलिंग तकनीकें
   - स्केलिंग दृष्टिकोण
   - सुरक्षा विचार
   - Entra ID सुरक्षा एकीकरण
   - वेब सर्च एकीकरण

7. **समुदाय योगदान (06-CommunityContributions/)**
   - कोड और दस्तावेज़ीकरण में योगदान कैसे करें
   - GitHub के माध्यम से सहयोग करना
   - सामुदायिक-संचालित सुधार और प्रतिक्रिया
   - विभिन्न MCP क्लाइंट का उपयोग करना (Claude Desktop, Cline, VSCode)
   - लोकप्रिय MCP सर्वरों के साथ काम करना, जिसमें इमेज जनरेशन शामिल है

8. **प्रारंभिक अपनाने से सीख (07-LessonsfromEarlyAdoption/)**
   - वास्तविक दुनिया के कार्यान्वयन और सफलता की कहानियाँ
   - MCP-आधारित समाधान बनाना और परिनियोजित करना
   - रुझान और भविष्य का रोडमैप
   - **Microsoft MCP सर्वर गाइड**: 10 प्रोडक्शन-रेडी Microsoft MCP सर्वरों का व्यापक गाइड, जिसमें शामिल हैं:
     - Microsoft Learn Docs MCP Server
     - Azure MCP Server (15+ विशेषीकृत कनेक्टर)
     - GitHub MCP Server
     - Azure DevOps MCP Server
     - MarkItDown MCP Server
     - SQL Server MCP Server
     - Playwright MCP Server
     - Dev Box MCP Server
     - Azure AI Foundry MCP Server
     - Microsoft 365 Agents Toolkit MCP Server

9. **सर्वोत्तम प्रथाएँ (08-BestPractices/)**
   - प्रदर्शन ट्यूनिंग और अनुकूलन
   - दोष-सहिष्णु MCP सिस्टम डिज़ाइन करना
   - परीक्षण और लचीलापन रणनीतियाँ

10. **केस स्टडीज (09-CaseStudy/)**
    - **सात व्यापक केस स्टडीज** जो MCP की बहुमुखी प्रतिभा को विभिन्न परिदृश्यों में प्रदर्शित करती हैं:
    - **Azure AI Travel Agents**: Azure OpenAI और AI सर्च के साथ मल्टी-एजेंट ऑर्केस्ट्रेशन
    - **Azure DevOps Integration**: YouTube डेटा अपडेट के साथ वर्कफ़्लो प्रक्रियाओं को स्वचालित करना
    - **रियल-टाइम डॉक्यूमेंटेशन रिट्रीवल**: स्ट्रीमिंग HTTP के साथ Python कंसोल क्लाइंट
    - **इंटरएक्टिव स्टडी प्लान जनरेटर**: Chainlit वेब ऐप के साथ संवादात्मक AI
    - **इन-एडिटर डॉक्यूमेंटेशन**: GitHub Copilot वर्कफ़्लो के साथ VS Code एकीकरण
    - **Azure API Management**: MCP सर्वर निर्माण के साथ एंटरप्राइज़ API एकीकरण
    - **GitHub MCP Registry**: इकोसिस्टम विकास और एजेंटिक एकीकरण प्लेटफ़ॉर्म
    - कार्यान्वयन उदाहरण जो एंटरप्राइज़ एकीकरण, डेवलपर उत्पादकता, और इकोसिस्टम विकास को कवर करते हैं

11. **हैंड्स-ऑन वर्कशॉप (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - MCP को AI टूलकिट के साथ जोड़ने वाली व्यापक हैंड्स-ऑन वर्कशॉप
    - AI मॉडल को वास्तविक दुनिया के टूल्स के साथ जोड़ने वाले बुद्धिमान एप्लिकेशन बनाना
    - व्यावहारिक मॉड्यूल जो मूलभूत बातें, कस्टम सर्वर विकास, और प्रोडक्शन परिनियोजन रणनीतियों को कवर करते हैं
    - **लैब संरचना**:
      - लैब 1: MCP सर्वर मूलभूत बातें
      - लैब 2: उन्नत MCP सर्वर विकास
      - लैब 3: AI टूलकिट एकीकरण
      - लैब 4: प्रोडक्शन परिनियोजन और स्केलिंग
    - चरण-दर-चरण निर्देशों के साथ लैब-आधारित शिक्षण दृष्टिकोण

## अतिरिक्त संसाधन

रिपॉजिटरी में सहायक संसाधन शामिल हैं:

- **इमेजेस फ़ोल्डर**: पाठ्यक्रम में उपयोग किए गए आरेख और चित्र शामिल हैं
- **अनुवाद**: दस्तावेज़ीकरण के स्वचालित अनुवाद के साथ बहु-भाषा समर्थन
- **आधिकारिक MCP संसाधन**:
  - [MCP दस्तावेज़ीकरण](https://modelcontextprotocol.io/)
  - [MCP विनिर्देश](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub रिपॉजिटरी](https://github.com/modelcontextprotocol)

## इस रिपॉजिटरी का उपयोग कैसे करें

1. **क्रमिक शिक्षण**: संरचित शिक्षण अनुभव के लिए अध्यायों को क्रम में (00 से 10 तक) पढ़ें।
2. **भाषा-विशिष्ट ध्यान**: यदि आप किसी विशेष प्रोग्रामिंग भाषा में रुचि रखते हैं, तो अपनी पसंदीदा भाषा में कार्यान्वयन के लिए नमूना निर्देशिका का अन्वेषण करें।
3. **व्यावहारिक कार्यान्वयन**: अपना पर्यावरण सेटअप करने और अपना पहला MCP सर्वर और क्लाइंट बनाने के लिए "शुरुआत करना" अनुभाग से शुरू करें।
4. **उन्नत अन्वेषण**: मूल बातें समझने के बाद, अपने ज्ञान को बढ़ाने के लिए उन्नत विषयों में गहराई से जाएं।
5. **समुदाय सहभागिता**: विशेषज्ञों और अन्य डेवलपर्स से जुड़ने के लिए GitHub चर्चाओं और Discord चैनलों के माध्यम से MCP समुदाय में शामिल हों।

## MCP क्लाइंट और टूल्स

पाठ्यक्रम विभिन्न MCP क्लाइंट और टूल्स को कवर करता है:

1. **आधिकारिक क्लाइंट**:
   - Visual Studio Code 
   - MCP in Visual Studio Code
   - Claude Desktop
   - Claude in VSCode 
   - Claude API

2. **समुदाय क्लाइंट**:
   - Cline (टर्मिनल-आधारित)
   - Cursor (कोड संपादक)
   - ChatMCP
   - Windsurf

3. **MCP प्रबंधन टूल्स**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## लोकप्रिय MCP सर्वर

रिपॉजिटरी विभिन्न MCP सर्वरों को पेश करती है, जिनमें शामिल हैं:

1. **आधिकारिक Microsoft MCP सर्वर**:
   - Microsoft Learn Docs MCP Server
   - Azure MCP Server (15+ विशेषीकृत कनेक्टर)
   - GitHub MCP Server
   - Azure DevOps MCP Server
   - MarkItDown MCP Server
   - SQL Server MCP Server
   - Playwright MCP Server
   - Dev Box MCP Server
   - Azure AI Foundry MCP Server
   - Microsoft 365 Agents Toolkit MCP Server

2. **आधिकारिक संदर्भ सर्वर**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **इमेज जनरेशन**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **विकास टूल्स**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **विशेषीकृत सर्वर**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## योगदान

यह रिपॉजिटरी समुदाय से योगदान का स्वागत करती है। MCP इकोसिस्टम में प्रभावी ढंग से योगदान करने के लिए सामुदायिक योगदान अनुभाग देखें।

## चेंजलॉग

| तारीख | परिवर्तन |
|------|---------|
| 26 सितंबर, 2025 | - GitHub MCP Registry केस स्टडी को 09-CaseStudy अनुभाग में जोड़ा<br>- सात व्यापक केस स्टडीज को दर्शाने के लिए केस स्टडीज को अपडेट किया<br>- केस स्टडी विवरण को विशिष्ट कार्यान्वयन विवरणों के साथ बढ़ाया<br>- GitHub MCP Registry को शामिल करने के लिए विजुअल पाठ्यक्रम मानचित्र को अपडेट किया<br>- अध्ययन गाइड संरचना को इकोसिस्टम विकास फोकस को दर्शाने के लिए संशोधित किया |
| 18 जुलाई, 2025 | - Microsoft MCP Servers Guide को शामिल करने के लिए रिपॉजिटरी संरचना को अपडेट किया<br>- 10 प्रोडक्शन-रेडी Microsoft MCP सर्वरों की व्यापक सूची जोड़ी<br>- आधिकारिक Microsoft MCP सर्वरों के साथ लोकप्रिय MCP सर्वरों अनुभाग को बढ़ाया<br>- वास्तविक फ़ाइल उदाहरणों के साथ केस स्टडीज अनुभाग को अपडेट किया<br>- हैंड्स-ऑन वर्कशॉप के लिए लैब संरचना विवरण जोड़ा |
| 16 जुलाई, 2025 | - वर्तमान सामग्री को दर्शाने के लिए रिपॉजिटरी संरचना को अपडेट किया<br>- MCP क्लाइंट और टूल्स अनुभाग जोड़ा<br>- लोकप्रिय MCP सर्वरों अनुभाग जोड़ा<br>- वर्तमान विषयों के साथ विजुअल पाठ्यक्रम मानचित्र को अपडेट किया<br>- सभी विशेषीकृत क्षेत्रों के साथ उन्नत विषय अनुभाग को बढ़ाया<br>- वास्तविक उदाहरणों को दर्शाने के लिए केस स्टडीज को अपडेट किया<br>- MCP की उत्पत्ति को Anthropic द्वारा बनाया गया स्पष्ट किया |
| 11 जून, 2025 | - अध्ययन गाइड का प्रारंभिक निर्माण<br>- विजुअल पाठ्यक्रम मानचित्र जोड़ा<br>- रिपॉजिटरी संरचना की रूपरेखा तैयार की<br>- नमूना परियोजनाएँ और अतिरिक्त संसाधन शामिल किए |

---

*यह अध्ययन गाइड 26 सितंबर, 2025 को अपडेट किया गया था और उस तारीख तक रिपॉजिटरी का अवलोकन प्रदान करता है। इस तारीख के बाद रिपॉजिटरी सामग्री को अपडेट किया जा सकता है।*

---

