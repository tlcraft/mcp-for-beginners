<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:11:16+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "mr"
}
-->
# Security Best Practices

Model Context Protocol (MCP) स्वीकारल्याने AI-चालित अनुप्रयोगांना शक्तिशाली नवीन क्षमता मिळतात, पण त्याचबरोबर पारंपरिक सॉफ्टवेअर धोके ओलांडून अनोखे सुरक्षा आव्हाने देखील निर्माण होतात. सुरक्षित कोडिंग, किमान अधिकार आणि पुरवठा साखळी सुरक्षा यांसारख्या स्थापित चिंतांव्यतिरिक्त, MCP आणि AI कार्यभारांना नवीन धोके जसे की prompt injection, tool poisoning, आणि dynamic tool modification यांचा सामना करावा लागतो. योग्यरित्या व्यवस्थापित न केल्यास हे धोके डेटा चोरी, गोपनीयतेचे उल्लंघन आणि अनपेक्षित प्रणाली वर्तनाला कारणीभूत ठरू शकतात.

ही धडा MCP शी संबंधित सर्वात महत्त्वाच्या सुरक्षा धोके - ज्यामध्ये प्रमाणीकरण, प्राधिकरण, अत्यधिक परवानग्या, अप्रत्यक्ष prompt injection आणि पुरवठा साखळीतील कमकुवतपणा यांचा समावेश आहे - यांचा अभ्यास करतो आणि त्यांना कमी करण्यासाठी कृतीक्षम नियंत्रण व सर्वोत्तम पद्धती प्रदान करतो. तुम्हाला Microsoft च्या Prompt Shields, Azure Content Safety, आणि GitHub Advanced Security सारख्या उपायांचा वापर करून तुमच्या MCP अंमलबजावणीला कसे बळकट करायचे ते देखील शिकवले जाईल. हे नियंत्रण समजून आणि लागू करून तुम्ही सुरक्षा भंग होण्याची शक्यता लक्षणीयरीत्या कमी करू शकता आणि तुमची AI प्रणाली मजबूत व विश्वासार्ह राहील याची खात्री करू शकता.

# Learning Objectives

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- Model Context Protocol (MCP) मुळे उद्भवणाऱ्या अनोख्या सुरक्षा धोके ओळखणे आणि समजावून सांगणे, ज्यात prompt injection, tool poisoning, अत्यधिक परवानग्या, आणि पुरवठा साखळीतील कमकुवतपणा यांचा समावेश आहे.
- MCP सुरक्षा धोके कमी करण्यासाठी प्रभावी नियंत्रण जसे की मजबूत प्रमाणीकरण, किमान अधिकार, सुरक्षित टोकन व्यवस्थापन, आणि पुरवठा साखळीची पडताळणी यांचा वापर करणे.
- Microsoft चे Prompt Shields, Azure Content Safety, आणि GitHub Advanced Security यांसारख्या उपायांचा वापर करून MCP आणि AI कार्यभारांचे संरक्षण कसे करायचे ते समजून घेणे.
- टूल मेटाडेटाची पडताळणी करणे, डायनॅमिक बदलांवर लक्ष ठेवणे, आणि अप्रत्यक्ष prompt injection हल्ल्यांपासून संरक्षण करणे याचे महत्त्व ओळखणे.
- सुरक्षित कोडिंग, सर्व्हर हार्डनिंग, आणि झिरो ट्रस्ट आर्किटेक्चर यांसारख्या स्थापित सुरक्षा सर्वोत्तम पद्धती MCP अंमलबजावणीत कशा समाविष्ट करायच्या ते समजून घेणे, ज्यामुळे सुरक्षा भंग होण्याची शक्यता आणि परिणाम कमी होतात.

# MCP security controls

कोणत्याही प्रणालीला महत्त्वाच्या संसाधनांवर प्रवेश असल्यास सुरक्षा आव्हाने उद्भवतात. सामान्यतः योग्य मूलभूत सुरक्षा नियंत्रण आणि संकल्पनांच्या योग्य वापराने सुरक्षा आव्हाने हाताळली जातात. MCP नवीन परिभाषित प्रोटोकॉल असल्यामुळे त्याचा तपशील जलदगतीने बदलत आहे आणि प्रोटोकॉल विकसित होत आहे. अखेरीस त्यातील सुरक्षा नियंत्रण परिपक्व होतील, ज्यामुळे एंटरप्राइझ आणि स्थापित सुरक्षा आर्किटेक्चर आणि सर्वोत्तम पद्धतींसह चांगली एकत्रता साधता येईल.

[Microsoft Digital Defense Report](https://aka.ms/mddr) मध्ये प्रकाशित संशोधनानुसार, नोंदवलेल्या ९८% सुरक्षा भंगांना मजबूत सुरक्षा स्वच्छतेने प्रतिबंध केला जाऊ शकतो आणि कोणत्याही प्रकारच्या भंगापासून सर्वोत्तम संरक्षण म्हणजे मूलभूत सुरक्षा स्वच्छता, सुरक्षित कोडिंग सर्वोत्तम पद्धती आणि पुरवठा साखळी सुरक्षा यांचा योग्य वापर होय -- ज्या प्रथितयश पद्धती आपल्याला आधीपासून माहीत आहेत त्या अजूनही सुरक्षा धोका कमी करण्यात सर्वाधिक परिणामकारक आहेत.

MCP स्वीकारताना सुरक्षा धोके कसे हाताळायचे यावर काही मार्ग पाहूया.

> **Note:** खालील माहिती **29 मे 2025** पर्यंत योग्य आहे. MCP प्रोटोकॉल सतत विकसित होत आहे आणि भविष्यातील अंमलबजावणीत नवीन प्रमाणीकरण नमुने आणि नियंत्रण येऊ शकतात. नवीनतम अद्यतने आणि मार्गदर्शनासाठी नेहमी [MCP Specification](https://spec.modelcontextprotocol.io/) आणि अधिकृत [MCP GitHub repository](https://github.com/modelcontextprotocol) व [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices) पहा.

### Problem statement 
मूळ MCP तपशीलनुसार विकासकांनी स्वतःचे प्रमाणीकरण सर्व्हर लिहिणे अपेक्षित होते. यासाठी OAuth आणि संबंधित सुरक्षा निर्बंधांची माहिती आवश्यक होती. MCP सर्व्हर OAuth 2.0 Authorization Servers प्रमाणे काम करत होते, ज्यामुळे वापरकर्त्यांचे प्रमाणीकरण थेट व्यवस्थापित केले जात होते, Microsoft Entra ID सारख्या बाह्य सेवेकडे ते सोपवले जात नव्हते. **26 एप्रिल 2025** पासून MCP तपशीलनाम्यात बदल करून MCP सर्व्हरला वापरकर्त्यांचे प्रमाणीकरण बाह्य सेवेकडे सोपवण्याची परवानगी देण्यात आली आहे.

### Risks
- MCP सर्व्हरमधील चुकीची authorization लॉजिक संवेदनशील डेटाचा उघड होण्यास आणि चुकीच्या प्रवेश नियंत्रणांमुळे धोके निर्माण करू शकते.
- स्थानिक MCP सर्व्हरवर OAuth टोकन चोरी होणे. चोरी झाल्यास टोकनचा वापर करून MCP सर्व्हरची नक्कल करून त्या टोकनसाठी असलेल्या सेवेमधील संसाधने आणि डेटा मिळवता येऊ शकतो.

#### Token Passthrough
Token passthrough authorization तपशीलनाम्यात स्पष्टपणे निषिद्ध आहे कारण यामुळे अनेक सुरक्षा धोके निर्माण होतात, ज्यात:

#### Security Control Circumvention
MCP सर्व्हर किंवा downstream API महत्त्वपूर्ण सुरक्षा नियंत्रण जसे की rate limiting, request validation, किंवा traffic monitoring यांचा वापर करतात, जे टोकनच्या audience किंवा इतर क्रेडेन्शियल निर्बंधांवर अवलंबून असतात. जर क्लायंट्सना थेट downstream API सोबत टोकन वापरण्याची परवानगी दिली गेली आणि MCP सर्व्हरने त्यांची योग्य पडताळणी केली नाही किंवा टोकन योग्य सेवेकरिता जारी केले आहेत याची खात्री केली नाही, तर हे नियंत्रण बायपास होतात.

#### Accountability and Audit Trail Issues
MCP सर्व्हर upstream-issued access token वापरून कॉल केल्यावर MCP Clients ओळखणे किंवा वेगळे करणे शक्य नसते.
Downstream Resource Server च्या लॉगमध्ये विनंत्या वेगळ्या स्रोताकडून किंवा वेगळ्या ओळखीने आल्या असल्याचे दिसू शकते, ज्या प्रत्यक्षात MCP सर्व्हरकडून पुढे पाठवलेल्या असतात.
हे दोन्ही घटक घटना तपासणी, नियंत्रण आणि लेखापरीक्षण अधिक कठीण करतात.
जर MCP सर्व्हर टोकनचे दावे (उदा., भूमिका, विशेषाधिकार, किंवा audience) किंवा इतर मेटाडेटा तपासले नाहीत आणि टोकन पास करत असेल, तर चोरी झालेला टोकन असलेला दुर्भावनायुक्त व्यक्ती डेटा चोरीसाठी MCP सर्व्हरचा प्रॉक्सी म्हणून वापर करू शकतो.

#### Trust Boundary Issues
Downstream Resource Server विशिष्ट संस्थांवर विश्वास ठेवतो. हा विश्वास मूळ किंवा क्लायंटच्या वर्तनावर आधारित असू शकतो. हा विश्वास भंग होणे अनपेक्षित समस्या निर्माण करू शकते.
जर टोकन योग्य पडताळणीशिवाय अनेक सेवा स्वीकारल्या गेल्या, तर एक सेवा भंग झाल्यास त्या टोकनचा वापर करून इतर जोडलेल्या सेवांमध्ये प्रवेश केला जाऊ शकतो.

#### Future Compatibility Risk
आज MCP सर्व्हर "pure proxy" म्हणून सुरू झाला तरी भविष्यात सुरक्षा नियंत्रण जोडण्याची गरज भासू शकते. योग्य टोकन audience वेगळेपणाने सुरुवात केल्यास सुरक्षा मॉडेल विकसित करणे सोपे होते.

### Mitigating controls

**MCP servers MUST NOT accept any tokens that were not explicitly issued for the MCP server**

- **Review and Harden Authorization Logic:** तुमच्या MCP सर्व्हरच्या authorization अंमलबजावणीचे काळजीपूर्वक ऑडिट करा, जेणेकरून फक्त इच्छित वापरकर्ते आणि क्लायंट्स संवेदनशील संसाधनांपर्यंत प्रवेश करू शकतील. व्यावहारिक मार्गदर्शनासाठी, पहा [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) आणि [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Enforce Secure Token Practices:** [Microsoft’s best practices for token validation and lifetime](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) चे पालन करा जेणेकरून access token चा गैरवापर, पुनर्वापर किंवा चोरीचा धोका कमी होईल.
- **Protect Token Storage:** टोकन नेहमी सुरक्षितपणे संग्रहित करा आणि ते ट्रान्झिटमध्ये आणि विश्रांतीत असताना एन्क्रिप्शनचा वापर करा. अंमलबजावणी टिप्ससाठी, पहा [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement
MCP सर्व्हरला कदाचित ते वापरत असलेल्या सेवा/संसाधनासाठी जास्त परवानग्या दिल्या गेल्या असतील. उदाहरणार्थ, AI विक्री अनुप्रयोगाचा भाग असलेला MCP सर्व्हर एंटरप्राइझ डेटा स्टोअरशी कनेक्ट करत असल्यास, त्याला फक्त विक्री डेटा वापरण्याची परवानगी असावी, स्टोअरमधील सर्व फायलींवर प्रवेश नको. किमान अधिकाराचा सिद्धांत लक्षात घेतल्यास, कोणत्याही संसाधनाला त्याला आवश्यक असलेल्या कामांसाठी आवश्यक त्या पातळीपेक्षा जास्त परवानग्या नसाव्यात. AI मध्ये हा आव्हान अधिक आहे कारण त्याला लवचिक बनवण्यासाठी अचूक परवानग्या निश्चित करणे कठीण असते.

### Risks 
- जास्त परवानग्या दिल्यास MCP सर्व्हरला अनधिकृत डेटा चोरी किंवा बदल करण्याची परवानगी मिळू शकते. हे वैयक्तिक ओळख पटवणारी माहिती (PII) असल्यास गोपनीयतेचा प्रश्न देखील निर्माण होऊ शकतो.

### Mitigating controls
- **Apply the Principle of Least Privilege:** MCP सर्व्हरला फक्त त्याच्या आवश्यक कार्यांसाठी किमान परवानग्या द्या. नियमितपणे या परवानग्यांचे पुनरावलोकन करा आणि त्यात अनावश्यक वाढ झाली आहे का ते तपासा. सविस्तर मार्गदर्शनासाठी, पहा [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Use Role-Based Access Control (RBAC):** MCP सर्व्हरला विशिष्ट संसाधने आणि क्रियांशी संबंधित काटेकोरपणे व्याप्त असलेले रोल्स द्या, विस्तृत किंवा अनावश्यक परवानग्या टाळा.
- **Monitor and Audit Permissions:** परवानग्यांचा वापर सतत मॉनिटर करा आणि प्रवेश लॉगचे ऑडिट करा जेणेकरून जास्त किंवा न वापरलेल्या परवानग्या तात्काळ ओळखता येतील आणि दुरुस्त केल्या जातील.

# Indirect prompt injection attacks

### Problem statement

दुर्भावनायुक्त किंवा भंग झालेल्या MCP सर्व्हरमुळे ग्राहक डेटा उघड होण्याचा किंवा अनपेक्षित क्रिया होण्याचा धोका मोठ्या प्रमाणावर वाढतो. हे धोके विशेषतः AI आणि MCP-आधारित कार्यभारांमध्ये महत्त्वाचे असतात, जिथे:

- **Prompt Injection Attacks**: हल्लेखोर malicious सूचना prompts किंवा बाह्य सामग्रीमध्ये लपवून AI प्रणालीला अनपेक्षित क्रिया करण्यास किंवा संवेदनशील डेटा उघड करण्यास प्रवृत्त करतात. अधिक वाचा: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: हल्लेखोर टूल मेटाडेटा (उदा., वर्णने किंवा पॅरामीटर्स) मध्ये फेरफार करून AI च्या वर्तनावर परिणाम करतात, सुरक्षा नियंत्रण बायपास करणे किंवा डेटा चोरी करणे शक्य होते. तपशील: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: दस्तऐवज, वेबपृष्ठे किंवा ईमेलमध्ये लपवलेल्या दुर्भावनायुक्त सूचना AI द्वारे प्रक्रिया केल्यावर डेटा लीक किंवा फेरफार होतो.
- **Dynamic Tool Modification (Rug Pulls)**: वापरकर्त्याच्या मान्यतेनंतर टूल परिभाषा बदलल्या जाऊ शकतात, ज्यामुळे वापरकर्त्याला न कळता नवीन दुर्भावनायुक्त वर्तन येते.

हे कमकुवतपण MCP सर्व्हर आणि टूल्स एकत्रित करताना मजबूत पडताळणी, मॉनिटरिंग आणि सुरक्षा नियंत्रणांची गरज अधोरेखित करतात. सविस्तर माहितीसाठी वरील संदर्भ पहा.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.mr.png)

**Indirect Prompt Injection** (ज्याला cross-domain prompt injection किंवा XPIA असेही म्हणतात) हा जनरेटिव्ह AI प्रणालींमधील गंभीर कमकुवतपणा आहे, ज्यात Model Context Protocol (MCP) वापरले जाते. या हल्ल्यात, दुर्भावनायुक्त सूचना बाह्य सामग्रीमध्ये लपविल्या जातात—जसे की दस्तऐवज, वेबपृष्ठे, किंवा ईमेल. जेव्हा AI प्रणाली ही सामग्री प्रक्रिया करते, तेव्हा ती अंतर्निहित सूचना वैध वापरकर्ता आदेश म्हणून समजून अनपेक्षित क्रिया करू शकते जसे की डेटा लीक, हानिकारक सामग्री तयार करणे किंवा वापरकर्ता संवादात फेरफार करणे. सविस्तर समज आणि प्रत्यक्ष उदाहरणांसाठी पाहा [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

या हल्ल्याचा विशेषतः धोकादायक प्रकार म्हणजे **Tool Poisoning**. यात हल्लेखोर MCP टूल्सच्या मेटाडेटामध्ये (उदा., टूल वर्णने किंवा पॅरामीटर्स) दुर्भावनायुक्त सूचना इंजेक्ट करतात. मोठ्या भाषिक मॉडेल्स (LLMs) या मेटाडेटावर अवलंबून असतात की कोणते टूल वापरायचे, त्यामुळे खराब केलेल्या वर्णनांमुळे मॉडेल अनधिकृत टूल कॉल्स करण्यास किंवा सुरक्षा नियंत्रण बायपास करण्यास फसवले जाऊ शकते. हे बदल वापरकर्त्यांना दिसत नाहीत पण AI प्रणाली त्यावर प्रक्रिया करते. हा धोका होस्ट केलेल्या MCP सर्व्हर पर्यावरणात अधिक वाढतो, जिथे वापरकर्त्याच्या मान्यतेनंतर टूल परिभाषा बदलल्या जाऊ शकतात—याला "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" म्हणतात. अशा परिस्थितीत, पूर्वी सुरक्षित असलेले टूल नंतर डेटा चोरी किंवा प्रणाली वर्तन बदलण्यासाठी दुर्भावनायुक्त केले जाऊ शकते, वापरकर्त्याला कळत न देता. या हल्ल्याविषयी अधिक माहितीसाठी पाहा [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.mr.png)

## Risks
अनपेक्षित AI क्रिया विविध सुरक्षा धोके निर्माण करतात ज्यात डेटा चोरी आणि गोपनीयतेचे उल्लंघन यांचा समावेश आहे.

### Mitigating controls
### Using prompt shields to protect against Indirect Prompt Injection attacks
-----------------------------------------------------------------------------

**AI Prompt Shields** हे Microsoft ने विकसित केलेले एक उपाय आहे जे थेट आणि अप्रत्यक्ष prompt injection हल्ल्यांपासून संरक्षण करतो. हे खालील प्रकारे मदत करतात:

1.  **Detection and Filtering**: Prompt Shields प्रगत मशीन लर्निंग अल्गोरिदम आणि नैसर्गिक भाषा प्रक्रिया वापरून बाह्य सामग्रीतील दुर्भावनायुक्त सूचना शोधून फिल्टर करतात, जसे की दस्तऐवज, वेबपृष्ठे, किंवा ईमेल.
    
2.  **Spotlighting**: ही तंत्रज्ञान AI प्रणालीला वैध प्रणाली सूचना आणि शक्यतो अविश्वसनीय बाह्य इनपुट यामध्ये फरक ओळखण्यास मदत करते. इनपुट मजकूर अशा प्रकारे रूपांतरित केला जातो की मॉडेलला ते अधिक संबंधित वाटते, ज्यामुळे AI दुर्भावनायुक्त सूचना ओळखून दुर्लक्षित करू शकते.
    
3.  **Delimiters and Datamarking**: सिस्टम मेसेजमध्ये delimiters समाविष्ट करून इनपुट मजकुराचा स्थान स्पष्टपणे दर्शविला जातो, ज्यामुळे AI प्रणाली वापरकर्ता इनपुट आणि संभाव्य हानिकारक बाह्य सामग्री वेगळ्या करू शकते. Datamarking या संकल्पनेचा विस्तार आहे ज्यात विशिष्ट मार्कर्स वापरून विश्वासार्ह आणि अविश्वसनीय डेटाच्या सीमांचे ठळकपणे चिन्हांकन केले जाते.
    
4.  **Continuous Monitoring and Updates**: Microsoft सतत Prompt Shields चे मॉनिटरिंग आणि अद्यतने करते जेणेकरून नवीन आणि विकसित होत
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### पुढे

पुढे: [अध्याय 3: सुरुवात करणे](/03-GettingStarted/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेत त्रुटी असू शकतात. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला पाहिजे. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.