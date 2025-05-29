<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1446979020432f512c883848d7eca144",
  "translation_date": "2025-05-29T21:47:54+00:00",
  "source_file": "00-Introduction/README.md",
  "language_code": "tr"
}
-->
# Model Context Protocol (MCP) Giriş: Ölçeklenebilir Yapay Zeka Uygulamaları İçin Neden Önemlidir?

Üretken yapay zeka uygulamaları, kullanıcıların doğal dil komutlarıyla uygulamayla etkileşim kurmasını sağladığı için büyük bir ilerlemedir. Ancak, bu tür uygulamalara daha fazla zaman ve kaynak yatırıldıkça, işlevsellikleri ve kaynakları kolayca entegre edebilmek, uygulamanızın birden fazla modeli destekleyebilmesi ve farklı model karmaşıklıklarını yönetebilmesi önem kazanır. Kısacası, üretken yapay zeka uygulamaları başlamak için kolaydır, ancak büyüdükçe ve karmaşıklaştıkça bir mimari tanımlamanız ve uygulamalarınızın tutarlı bir şekilde inşa edilmesini sağlamak için bir standarda dayanmanız gerekir. İşte MCP, işleri organize etmek ve bir standart sağlamak için devreye girer.

---

## **🔍 Model Context Protocol (MCP) Nedir?**

**Model Context Protocol (MCP)**, Büyük Dil Modellerinin (LLM'ler) dış araçlar, API’ler ve veri kaynaklarıyla sorunsuz etkileşim kurmasını sağlayan **açık ve standart bir arayüzdür**. Eğitim verilerinin ötesinde AI model işlevselliğini geliştirmek için tutarlı bir mimari sunar ve daha akıllı, ölçeklenebilir ve yanıt verebilir yapay zeka sistemleri oluşturmayı mümkün kılar.

---

## **🎯 Yapay Zekada Standardizasyon Neden Önemlidir**

Üretken yapay zeka uygulamaları daha karmaşık hale geldikçe, **ölçeklenebilirlik, genişletilebilirlik** ve **bakım kolaylığı** sağlayan standartları benimsemek şarttır. MCP bu ihtiyaçları şu şekilde karşılar:

- Model-aracı entegrasyonlarını birleştirir
- Kırılgan, tek seferlik özel çözümleri azaltır
- Bir ekosistem içinde birden fazla modelin birlikte var olmasına izin verir

---

## **📚 Öğrenme Hedefleri**

Bu makalenin sonunda şunları yapabileceksiniz:

- **Model Context Protocol (MCP)**’yi ve kullanım alanlarını tanımlamak
- MCP’nin model-aracı iletişimini nasıl standartlaştırdığını anlamak
- MCP mimarisinin temel bileşenlerini belirlemek
- MCP’nin kurumsal ve geliştirme bağlamlarındaki gerçek dünya uygulamalarını keşfetmek

---

## **💡 Model Context Protocol (MCP) Neden Oyunun Kurallarını Değiştirir?**

### **🔗 MCP, Yapay Zeka Etkileşimlerindeki Parçalanmayı Çözüyor**

MCP öncesinde, modelleri araçlarla entegre etmek için:

- Her araç-model çifti için özel kod yazılması gerekiyordu
- Her satıcı için standart dışı API’ler kullanılıyordu
- Güncellemeler nedeniyle sık sık kopmalar yaşanıyordu
- Daha fazla araçla ölçeklenebilirlik zayıftı

### **✅ MCP Standardizasyonunun Faydaları**

| **Fayda**                | **Açıklama**                                                                   |
|--------------------------|--------------------------------------------------------------------------------|
| Birlikte Çalışabilirlik  | LLM’ler farklı satıcıların araçlarıyla sorunsuz çalışır                       |
| Tutarlılık               | Platformlar ve araçlar arasında uniform davranış sağlar                        |
| Yeniden Kullanılabilirlik| Bir kez geliştirilen araçlar projeler ve sistemler arasında kullanılabilir    |
| Hızlandırılmış Gelişim   | Standart, tak-çalıştır arayüzler sayesinde geliştirme süresi azalır           |

---

## **🧱 Yüksek Seviyede MCP Mimari Genel Bakış**

MCP, **istemci-sunucu modeli**ni takip eder; burada:

- **MCP Hostları** AI modellerini çalıştırır
- **MCP İstemcileri** istek başlatır
- **MCP Sunucuları** bağlam, araçlar ve yetenekleri sağlar

### **Temel Bileşenler:**

- **Kaynaklar** – Modeller için statik veya dinamik veriler  
- **İstemler (Prompts)** – Yönlendirilmiş üretim için ön tanımlı iş akışları  
- **Araçlar** – Arama, hesaplama gibi çalıştırılabilir fonksiyonlar  
- **Örnekleme (Sampling)** – Özyinelemeli etkileşimlerle ajan davranışı

---

## MCP Sunucuları Nasıl Çalışır

MCP sunucuları şu şekilde çalışır:

- **İstek Akışı**:  
    1. MCP İstemcisi, MCP Host’ta çalışan AI Modeline bir istek gönderir.  
    2. AI Model, dış araçlara veya verilere ihtiyaç duyduğunu belirler.  
    3. Model, standart protokolü kullanarak MCP Sunucusuyla iletişim kurar.

- **MCP Sunucu İşlevleri**:  
    - Araç Kataloğu: Mevcut araçların ve yeteneklerinin listesini tutar.  
    - Doğrulama: Araç erişim izinlerini kontrol eder.  
    - İstek İşleyici: Modelden gelen araç isteklerini işler.  
    - Yanıt Formatlayıcı: Araç çıktısını modelin anlayacağı biçime dönüştürür.

- **Araç Çalıştırma**:  
    - Sunucu, istekleri uygun dış araçlara yönlendirir  
    - Araçlar uzmanlık gerektiren işlevlerini (arama, hesaplama, veri tabanı sorguları vb.) gerçekleştirir  
    - Sonuçlar modele tutarlı bir formatta iletilir

- **Yanıt Tamamlama**:  
    - AI model araç çıktısını yanıtına entegre eder  
    - Son yanıt istemci uygulamasına gönderilir

```mermaid
---
title: MCP Server Architecture and Component Interactions
description: A diagram showing how AI models interact with MCP servers and various tools, depicting the request flow and server components including Tool Registry, Authentication, Request Handler, and Response Formatter
---
graph TD
    A[AI Model in MCP Host] <-->|MCP Protocol| B[MCP Server]
    B <-->|Tool Interface| C[Tool 1: Web Search]
    B <-->|Tool Interface| D[Tool 2: Calculator]
    B <-->|Tool Interface| E[Tool 3: Database Access]
    B <-->|Tool Interface| F[Tool 4: File System]
    
    Client[MCP Client/Application] -->|Sends Request| A
    A -->|Returns Response| Client
    
    subgraph "MCP Server Components"
        B
        G[Tool Registry]
        H[Authentication]
        I[Request Handler]
        J[Response Formatter]
    end
    
    B <--> G
    B <--> H
    B <--> I
    B <--> J
    
    style A fill:#f9d5e5,stroke:#333,stroke-width:2px
    style B fill:#eeeeee,stroke:#333,stroke-width:2px
    style Client fill:#d5e8f9,stroke:#333,stroke-width:2px
    style C fill:#c2f0c2,stroke:#333,stroke-width:1px
    style D fill:#c2f0c2,stroke:#333,stroke-width:1px
    style E fill:#c2f0c2,stroke:#333,stroke-width:1px
    style F fill:#c2f0c2,stroke:#333,stroke-width:1px    
```

## 👨‍💻 MCP Sunucusu Nasıl Kurulur (Örneklerle)

MCP sunucuları, LLM yeteneklerini veri ve işlevsellik sağlayarak genişletmenize olanak tanır.

Denemeye hazır mısınız? İşte farklı dillerde basit bir MCP sunucusu oluşturma örnekleri:

- **Python Örneği**: https://github.com/modelcontextprotocol/python-sdk

- **TypeScript Örneği**: https://github.com/modelcontextprotocol/typescript-sdk

- **Java Örneği**: https://github.com/modelcontextprotocol/java-sdk

- **C#/.NET Örneği**: https://github.com/modelcontextprotocol/csharp-sdk


## 🌍 MCP’nin Gerçek Dünya Kullanım Alanları

MCP, AI yeteneklerini genişleterek çok çeşitli uygulamalara olanak sağlar:

| **Uygulama**                 | **Açıklama**                                                                   |
|-----------------------------|--------------------------------------------------------------------------------|
| Kurumsal Veri Entegrasyonu  | LLM’leri veri tabanları, CRM’ler veya dahili araçlarla bağlamak               |
| Ajanik AI Sistemleri        | Araç erişimi ve karar alma iş akışlarıyla otonom ajanlar oluşturmak            |
| Çok Modlu Uygulamalar       | Metin, görüntü ve ses araçlarını tek bir birleşik AI uygulamasında birleştirmek|
| Gerçek Zamanlı Veri Entegrasyonu | Daha doğru, güncel çıktılar için canlı veriyi AI etkileşimlerine dahil etmek |

### 🧠 MCP = Yapay Zeka Etkileşimleri İçin Evrensel Standart

Model Context Protocol (MCP), USB-C’nin cihazlar için fiziksel bağlantıları standartlaştırması gibi yapay zeka etkileşimleri için evrensel bir standart görevi görür. AI dünyasında MCP, modellerin (istemciler) dış araçlar ve veri sağlayıcılarla (sunucular) sorunsuz entegre olmasını sağlayan tutarlı bir arayüz sunar. Bu, her API veya veri kaynağı için farklı, özel protokollere olan ihtiyacı ortadan kaldırır.

MCP uyumlu bir araç (MCP sunucusu olarak adlandırılır) birleşik bir standardı takip eder. Bu sunucular sundukları araçları veya eylemleri listeleyebilir ve AI ajanının talebi üzerine bu eylemleri gerçekleştirebilir. MCP destekleyen AI ajan platformları, sunuculardaki mevcut araçları keşfedebilir ve bu standart protokol aracılığıyla çağırabilir.

### 💡 Bilgiye Erişimi Kolaylaştırır

Araçlar sunmanın ötesinde, MCP aynı zamanda bilgiye erişimi kolaylaştırır. Uygulamaların büyük dil modellerine (LLM) çeşitli veri kaynaklarıyla bağlanarak bağlam sağlamasına olanak tanır. Örneğin, bir MCP sunucusu bir şirketin doküman deposunu temsil edebilir ve ajanların talep üzerine ilgili bilgileri almasını sağlar. Başka bir sunucu e-posta gönderme veya kayıt güncelleme gibi belirli işlemleri yönetebilir. Ajan açısından bunlar sadece kullanabileceği araçlardır — bazıları veri (bilgi bağlamı) dönerken, diğerleri eylem gerçekleştirir. MCP her ikisini de etkin şekilde yönetir.

Bir ajan MCP sunucusuna bağlandığında, sunucunun mevcut yeteneklerini ve erişilebilir verilerini standart bir formatla otomatik olarak öğrenir. Bu standartlaşma, dinamik araç kullanılabilirliğini mümkün kılar. Örneğin, bir ajanın sistemine yeni bir MCP sunucusu eklemek, fonksiyonlarının hemen kullanılabilir olmasını sağlar; ajanın talimatlarını yeniden özelleştirmeye gerek kalmaz.

Bu kolaylaştırılmış entegrasyon, sunucuların hem araçları hem de bilgiyi sağladığı mermaid diyagramında gösterilen akışla uyumludur ve sistemler arası sorunsuz iş birliği sağlar.

### 👉 Örnek: Ölçeklenebilir Ajan Çözümü

```mermaid
---
title: Scalable Agent Solution with MCP
description: A diagram illustrating how a user interacts with an LLM that connects to multiple MCP servers, with each server providing both knowledge and tools, creating a scalable AI system architecture
---
graph TD
    User -->|Prompt| LLM
    LLM -->|Response| User
    LLM -->|MCP| ServerA
    LLM -->|MCP| ServerB
    ServerA -->|Universal connector| ServerB
    ServerA --> KnowledgeA
    ServerA --> ToolsA
    ServerB --> KnowledgeB
    ServerB --> ToolsB

    subgraph Server A
        KnowledgeA[Knowledge]
        ToolsA[Tools]
    end

    subgraph Server B
        KnowledgeB[Knowledge]
        ToolsB[Tools]
    end
```

### 🔄 İstemci Tarafı LLM Entegrasyonu ile Gelişmiş MCP Senaryoları

Temel MCP mimarisinin ötesinde, hem istemci hem de sunucuda LLM’lerin bulunduğu daha karmaşık etkileşimleri mümkün kılan gelişmiş senaryolar vardır:

```mermaid
---
title: Advanced MCP Scenarios with Client-Server LLM Integration
description: A sequence diagram showing the detailed interaction flow between user, client application, client LLM, multiple MCP servers, and server LLM, illustrating tool discovery, user interaction, direct tool calling, and feature negotiation phases
---
sequenceDiagram
    autonumber
    actor User as 👤 User
    participant ClientApp as 🖥️ Client App
    participant ClientLLM as 🧠 Client LLM
    participant Server1 as 🔧 MCP Server 1
    participant Server2 as 📚 MCP Server 2
    participant ServerLLM as 🤖 Server LLM
    
    %% Discovery Phase
    rect rgb(220, 240, 255)
        Note over ClientApp, Server2: TOOL DISCOVERY PHASE
        ClientApp->>+Server1: Request available tools/resources
        Server1-->>-ClientApp: Return tool list (JSON)
        ClientApp->>+Server2: Request available tools/resources
        Server2-->>-ClientApp: Return tool list (JSON)
        Note right of ClientApp: Store combined tool<br/>catalog locally
    end
    
    %% User Interaction
    rect rgb(255, 240, 220)
        Note over User, ClientLLM: USER INTERACTION PHASE
        User->>+ClientApp: Enter natural language prompt
        ClientApp->>+ClientLLM: Forward prompt + tool catalog
        ClientLLM->>-ClientLLM: Analyze prompt & select tools
    end
    
    %% Scenario A: Direct Tool Calling
    alt Direct Tool Calling
        rect rgb(220, 255, 220)
            Note over ClientApp, Server1: SCENARIO A: DIRECT TOOL CALLING
            ClientLLM->>+ClientApp: Request tool execution
            ClientApp->>+Server1: Execute specific tool
            Server1-->>-ClientApp: Return results
            ClientApp->>+ClientLLM: Process results
            ClientLLM-->>-ClientApp: Generate response
            ClientApp-->>-User: Display final answer
        end
    
    %% Scenario B: Feature Negotiation (VS Code style)
    else Feature Negotiation (VS Code style)
        rect rgb(255, 220, 220)
            Note over ClientApp, ServerLLM: SCENARIO B: FEATURE NEGOTIATION
            ClientLLM->>+ClientApp: Identify needed capabilities
            ClientApp->>+Server2: Negotiate features/capabilities
            Server2->>+ServerLLM: Request additional context
            ServerLLM-->>-Server2: Provide context
            Server2-->>-ClientApp: Return available features
            ClientApp->>+Server2: Call negotiated tools
            Server2-->>-ClientApp: Return results
            ClientApp->>+ClientLLM: Process results
            ClientLLM-->>-ClientApp: Generate response
            ClientApp-->>-User: Display final answer
        end
    end
```

## 🔐 MCP’nin Pratik Faydaları

MCP kullanmanın pratik faydaları şunlardır:

- **Güncellik**: Modeller eğitim verilerinin ötesinde güncel bilgilere erişebilir  
- **Yetenek Genişletme**: Modeller, eğitilmedikleri görevler için özel araçları kullanabilir  
- **Halüsinasyonların Azalması**: Dış veri kaynakları gerçekçi temel sağlar  
- **Gizlilik**: Hassas veriler, istemlere gömülmek yerine güvenli ortamlarda kalabilir

## 📌 Önemli Noktalar

MCP kullanımı için önemli noktalar:

- **MCP**, AI modellerinin araçlar ve verilerle etkileşimini standartlaştırır  
- **Genişletilebilirlik, tutarlılık ve birlikte çalışabilirlik** teşvik edilir  
- MCP, **geliştirme süresini azaltır, güvenilirliği artırır ve model yeteneklerini genişletir**  
- İstemci-sunucu mimarisi, **esnek ve genişletilebilir AI uygulamalarına olanak tanır**

## 🧠 Alıştırma

İlgi duyduğunuz bir AI uygulaması hakkında düşünün.

- Hangi **dış araçlar veya veriler** yeteneklerini artırabilir?  
- MCP, entegrasyonu nasıl **daha basit ve güvenilir** hale getirebilir?

## Ek Kaynaklar

- [MCP GitHub Deposu](https://github.com/modelcontextprotocol)


## Sonraki Adım

Sonraki: [Bölüm 1: Temel Kavramlar](/01-CoreConcepts/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi ana dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı nedeniyle oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.