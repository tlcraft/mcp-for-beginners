<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:47:24+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "tr"
}
-->
# Vaka İncelemesi: Azure AI Seyahat Acenteleri – Referans Uygulama

## Genel Bakış

[Azure AI Seyahat Acenteleri](https://github.com/Azure-Samples/azure-ai-travel-agents), Microsoft tarafından geliştirilen kapsamlı bir referans çözüm olup, Model Context Protocol (MCP), Azure OpenAI ve Azure AI Search kullanarak çoklu ajanlı, yapay zeka destekli seyahat planlama uygulamasının nasıl oluşturulacağını gösterir. Bu proje, birden fazla AI ajanının koordinasyonu, kurumsal verilerin entegrasyonu ve gerçek dünya senaryoları için güvenli, genişletilebilir bir platform sunma konusundaki en iyi uygulamaları sergiler.

## Temel Özellikler
- **Çoklu Ajan Koordinasyonu:** MCP kullanarak, karmaşık seyahat planlama görevlerini yerine getirmek için iş birliği yapan uzman ajanları (örneğin, uçuş, otel ve güzergah ajanları) koordine eder.
- **Kurumsal Veri Entegrasyonu:** Seyahat önerileri için güncel ve ilgili bilgileri sağlamak amacıyla Azure AI Search ve diğer kurumsal veri kaynaklarına bağlanır.
- **Güvenli, Ölçeklenebilir Mimari:** Kimlik doğrulama, yetkilendirme ve ölçeklenebilir dağıtım için Azure hizmetlerinden yararlanır ve kurumsal güvenlik en iyi uygulamalarını takip eder.
- **Genişletilebilir Araçlar:** Yeniden kullanılabilir MCP araçları ve prompt şablonları uygular, böylece yeni alanlara veya iş gereksinimlerine hızlı uyum sağlar.
- **Kullanıcı Deneyimi:** Kullanıcıların Azure OpenAI ve MCP tarafından desteklenen seyahat acenteleriyle etkileşim kurmasını sağlayan sohbet tabanlı bir arayüz sunar.

## Mimari
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Mimari Diyagram Açıklaması

Azure AI Seyahat Acenteleri çözümü, çoklu AI ajanları ve kurumsal veri kaynaklarının modüler, ölçeklenebilir ve güvenli entegrasyonu için tasarlanmıştır. Ana bileşenler ve veri akışı şu şekildedir:

- **Kullanıcı Arayüzü:** Kullanıcılar, seyahat önerilerini almak ve sorgularını göndermek için web sohbeti veya Teams botu gibi sohbet tabanlı bir UI aracılığıyla sistemi kullanır.
- **MCP Sunucusu:** Merkezi koordinatör olarak görev yapar; kullanıcı girdilerini alır, bağlamı yönetir ve Model Context Protocol üzerinden FlightAgent, HotelAgent, ItineraryAgent gibi uzman ajanların eylemlerini koordine eder.
- **AI Ajanları:** Her ajan belirli bir alandan sorumludur (uçuşlar, oteller, güzergahlar) ve MCP aracı olarak uygulanır. Ajanlar, talepleri işlemek ve yanıtlar oluşturmak için prompt şablonları ve mantık kullanır.
- **Azure OpenAI Hizmeti:** Gelişmiş doğal dil anlama ve üretim sağlar; ajanların kullanıcı niyetini yorumlamasına ve sohbet tarzında yanıtlar oluşturmasına olanak tanır.
- **Azure AI Search & Kurumsal Veri:** Ajanlar, uçuşlar, oteller ve seyahat seçenekleri hakkında güncel bilgileri almak için Azure AI Search ve diğer kurumsal veri kaynaklarına sorgular gönderir.
- **Kimlik Doğrulama & Güvenlik:** Microsoft Entra ID ile güvenli kimlik doğrulama sağlar ve tüm kaynaklara en az ayrıcalık prensibiyle erişim kontrolleri uygular.
- **Dağıtım:** Azure Container Apps üzerinde dağıtım için tasarlanmıştır; ölçeklenebilirlik, izleme ve operasyonel verimlilik sağlar.

Bu mimari, birden fazla AI ajanının sorunsuz koordinasyonunu, kurumsal verilerle güvenli entegrasyonu ve alan bazlı AI çözümleri oluşturmak için sağlam, genişletilebilir bir platformu mümkün kılar.

## Mimari Diyagramın Adım Adım Açıklaması
Büyük bir seyahat planladığınızı ve her detayda size yardımcı olan uzman bir ekip olduğunu hayal edin. Azure AI Seyahat Acenteleri sistemi de benzer şekilde çalışır; her biri özel bir görev yapan farklı parçalar (ekip üyeleri gibi) vardır. İşte nasıl bir araya geldiği:

### Kullanıcı Arayüzü (UI):
Bunu seyahat acentenizin ön bürosu gibi düşünün. Burada siz (kullanıcı) “Paris’e uçuş bul” gibi sorular sorar veya isteklerde bulunursunuz. Bu bir web sitesindeki sohbet penceresi veya mesajlaşma uygulaması olabilir.

### MCP Sunucusu (Koordinatör):
MCP Sunucusu, ön büroda isteğinizi dinleyen ve hangi uzmanın hangi kısmı halledeceğine karar veren yönetici gibidir. Konuşmanızı takip eder ve her şeyin sorunsuz ilerlemesini sağlar.

### AI Ajanları (Uzman Yardımcılar):
Her ajan belirli bir konuda uzmandır—biri uçuşları, diğeri otelleri, bir diğeri ise güzergah planlamayı bilir. Seyahat isteğiniz geldiğinde MCP Sunucusu talebinizi ilgili ajan(lar)a gönderir. Bu ajanlar bilgi ve araçlarını kullanarak sizin için en iyi seçenekleri bulur.

### Azure OpenAI Hizmeti (Dil Uzmanı):
Bu, ne şekilde sorarsanız sorun tam olarak ne istediğinizi anlayan bir dil uzmanı gibidir. Ajanların isteklerinizi anlamasına ve doğal, sohbet tarzı yanıtlar vermesine yardımcı olur.

### Azure AI Search & Kurumsal Veri (Bilgi Kütüphanesi):
Devasa, güncel bir kütüphane düşünün; içinde uçuş tarifeleri, otel müsaitlikleri ve daha fazlası var. Ajanlar, size en doğru yanıtları vermek için bu kütüphanede arama yapar.

### Kimlik Doğrulama & Güvenlik (Güvenlik Görevlisi):
Tıpkı bir güvenlik görevlisinin belirli alanlara kimin girebileceğini kontrol etmesi gibi, bu kısım sadece yetkili kişilerin ve ajanların hassas bilgilere erişmesini sağlar. Verilerinizi güvenli ve gizli tutar.

### Azure Container Apps Üzerinde Dağıtım (Bina):
Tüm bu yardımcılar ve araçlar, güvenli ve ölçeklenebilir bir binada (bulut ortamında) birlikte çalışır. Bu, sistemin aynı anda çok sayıda kullanıcıyı desteklemesini ve her zaman erişilebilir olmasını sağlar.

## Hepsi Birlikte Nasıl Çalışır:

Ön büroda (UI) bir soru sorarak başlarsınız.  
Yönetici (MCP Sunucusu), hangi uzmanın (ajan) size yardım edeceğine karar verir.  
Uzman, isteğinizi anlamak için dil uzmanını (OpenAI) ve en iyi cevabı bulmak için kütüphaneyi (AI Search) kullanır.  
Güvenlik görevlisi (Kimlik Doğrulama), her şeyin güvende olduğundan emin olur.  
Tüm bunlar güvenilir, ölçeklenebilir bir binada (Azure Container Apps) gerçekleşir, böylece deneyiminiz sorunsuz ve güvenli olur.  
Bu iş birliği, sistemin seyahatinizi hızlı ve güvenli bir şekilde planlamasına olanak tanır; tıpkı modern bir ofiste birlikte çalışan uzman seyahat acenteleri ekibi gibi!

## Teknik Uygulama
- **MCP Sunucusu:** Temel koordinasyon mantığını barındırır, ajan araçlarını sunar ve çok adımlı seyahat planlama iş akışları için bağlam yönetir.
- **Ajanlar:** Her ajan (ör. FlightAgent, HotelAgent), kendi prompt şablonları ve mantığı ile MCP aracı olarak uygulanır.
- **Azure Entegrasyonu:** Doğal dil anlama için Azure OpenAI ve veri erişimi için Azure AI Search kullanır.
- **Güvenlik:** Microsoft Entra ID ile kimlik doğrulama entegre edilir ve tüm kaynaklara en az ayrıcalık prensibi uygulanır.
- **Dağıtım:** Ölçeklenebilirlik ve operasyonel verimlilik için Azure Container Apps’e dağıtımı destekler.

## Sonuçlar ve Etki
- MCP’nin gerçek dünya, üretim kalitesinde bir senaryoda birden fazla AI ajanını koordine etmek için nasıl kullanılabileceğini gösterir.
- Ajan koordinasyonu, veri entegrasyonu ve güvenli dağıtım için yeniden kullanılabilir kalıplar sağlayarak çözüm geliştirmeyi hızlandırır.
- MCP ve Azure hizmetleri kullanarak alan bazlı, yapay zeka destekli uygulamalar oluşturmak için bir şablon görevi görür.

## Referanslar
- [Azure AI Travel Agents GitHub Deposu](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Servisi](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.