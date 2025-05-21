<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:38:35+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tr"
}
-->
# Vaka İncelemesi: Azure AI Seyahat Acenteleri – Referans Uygulaması

## Genel Bakış

[Azure AI Seyahat Acenteleri](https://github.com/Azure-Samples/azure-ai-travel-agents), Microsoft tarafından geliştirilen kapsamlı bir referans çözüm olup, Model Context Protocol (MCP), Azure OpenAI ve Azure AI Search kullanarak çoklu ajanlı, yapay zeka destekli bir seyahat planlama uygulamasının nasıl oluşturulacağını gösterir. Bu proje, birden fazla yapay zeka ajanının koordinasyonu, kurumsal verilerin entegrasyonu ve gerçek dünya senaryoları için güvenli, genişletilebilir bir platform sağlama konusundaki en iyi uygulamaları sergiler.

## Temel Özellikler
- **Çoklu Ajan Koordinasyonu:** MCP kullanarak, karmaşık seyahat planlama görevlerini yerine getirmek için iş birliği yapan uzmanlaşmış ajanları (örneğin, uçuş, otel ve güzergah ajanları) koordine eder.
- **Kurumsal Veri Entegrasyonu:** Seyahat önerileri için güncel ve ilgili bilgileri sağlamak amacıyla Azure AI Search ve diğer kurumsal veri kaynaklarına bağlanır.
- **Güvenli, Ölçeklenebilir Mimari:** Kimlik doğrulama, yetkilendirme ve ölçeklenebilir dağıtım için Azure servislerinden yararlanır ve kurumsal güvenlik en iyi uygulamalarını takip eder.
- **Genişletilebilir Araçlar:** Yeniden kullanılabilir MCP araçları ve istem şablonları uygular, böylece yeni alanlara veya iş gereksinimlerine hızlı uyum sağlar.
- **Kullanıcı Deneyimi:** Kullanıcıların Azure OpenAI ve MCP tarafından desteklenen seyahat acenteleriyle sohbet ederek etkileşim kurmasını sağlayan bir arayüz sunar.

## Mimari
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Mimari Diyagram Açıklaması

Azure AI Seyahat Acenteleri çözümü, çoklu yapay zeka ajanlarının ve kurumsal veri kaynaklarının modüler, ölçeklenebilir ve güvenli entegrasyonu için tasarlanmıştır. Ana bileşenler ve veri akışı şu şekildedir:

- **Kullanıcı Arayüzü:** Kullanıcılar, bir web sohbeti veya Teams botu gibi konuşma tabanlı bir arayüz üzerinden sisteme sorgular gönderir ve seyahat önerileri alır.
- **MCP Sunucusu:** Kullanıcı girdisini alan, bağlamı yöneten ve Model Context Protocol aracılığıyla uzmanlaşmış ajanların (örneğin FlightAgent, HotelAgent, ItineraryAgent) işlemlerini koordine eden merkezi düzenleyicidir.
- **Yapay Zeka Ajanları:** Her ajan belirli bir alandan (uçuşlar, oteller, güzergahlar) sorumludur ve MCP aracı olarak uygulanmıştır. Ajanlar, istekleri işlemek ve yanıtlar oluşturmak için istem şablonları ve mantık kullanır.
- **Azure OpenAI Hizmeti:** Gelişmiş doğal dil anlama ve üretim sağlar, ajanların kullanıcı niyetini yorumlamasına ve sohbet diliyle yanıt vermesine olanak tanır.
- **Azure AI Search & Kurumsal Veri:** Ajanlar, uçuşlar, oteller ve seyahat seçenekleri hakkında güncel bilgileri almak için Azure AI Search ve diğer kurumsal veri kaynaklarına sorgu yapar.
- **Kimlik Doğrulama & Güvenlik:** Microsoft Entra ID ile güvenli kimlik doğrulama sağlar ve tüm kaynaklar için en az ayrıcalık erişim kontrolleri uygular.
- **Dağıtım:** Azure Container Apps üzerinde dağıtım için tasarlanmıştır; bu sayede ölçeklenebilirlik, izleme ve operasyonel verimlilik sağlanır.

Bu mimari, çoklu yapay zeka ajanlarının sorunsuz koordinasyonunu, kurumsal veri ile güvenli entegrasyonu ve alan spesifik yapay zeka çözümleri oluşturmak için sağlam, genişletilebilir bir platform sunar.

## Mimari Diyagramın Adım Adım Açıklaması
Büyük bir seyahat planladığınızı ve her detayıyla ilgilenen uzman bir ekip olduğunu hayal edin. Azure AI Seyahat Acenteleri sistemi benzer şekilde çalışır; her biri özel bir göreve sahip farklı parçalar (ekip üyeleri gibi) vardır. İşte nasıl bir araya geldikleri:

### Kullanıcı Arayüzü (UI):
Bunu seyahat acentenizin ön masası gibi düşünün. Siz (kullanıcı) burada “Paris’e uçuş bul” gibi sorular sorar veya isteklerde bulunursunuz. Bu, bir web sitesindeki sohbet penceresi veya bir mesajlaşma uygulaması olabilir.

### MCP Sunucusu (Koordinatör):
MCP Sunucusu, ön masada isteğinizi dinleyen ve hangi uzmanın hangi kısmı halledeceğine karar veren yönetici gibidir. Sohbetinizi takip eder ve her şeyin sorunsuz ilerlemesini sağlar.

### Yapay Zeka Ajanları (Uzman Asistanlar):
Her ajan belirli bir konuda uzmandır—biri uçuşlar hakkında, diğeri oteller hakkında, bir diğeri de güzergah planlaması hakkında bilgi sahibidir. Seyahat isteğinizi MCP Sunucusu ilgili ajan(lar)a iletir. Bu ajanlar bilgilerini ve araçlarını kullanarak sizin için en iyi seçenekleri bulur.

### Azure OpenAI Hizmeti (Dil Uzmanı):
Bu, ne şekilde ifade ederseniz edin tam olarak ne istediğinizi anlayan bir dil uzmanı gibidir. Ajanların isteklerinizi anlamasına ve doğal, sohbet dilinde yanıt vermesine yardımcı olur.

### Azure AI Search & Kurumsal Veri (Bilgi Kütüphanesi):
Devasa, güncel bir kütüphane düşünün; içinde uçuş programları, otel müsaitlikleri ve daha fazlası vardır. Ajanlar bu kütüphanede arama yaparak size en doğru yanıtları getirir.

### Kimlik Doğrulama & Güvenlik (Güvenlik Görevlisi):
Bir güvenlik görevlisinin belirli alanlara kimlerin girebileceğini kontrol etmesi gibi, bu bölüm sadece yetkili kişilerin ve ajanların hassas bilgilere erişmesini sağlar. Verilerinizi güvende ve gizli tutar.

### Azure Container Apps Üzerinde Dağıtım (Bina):
Tüm bu asistanlar ve araçlar, güvenli ve ölçeklenebilir bir bina (bulut) içinde birlikte çalışır. Bu, sistemin aynı anda çok sayıda kullanıcıyı destekleyebilmesini ve her zaman erişilebilir olmasını sağlar.

## Hepsi Birlikte Nasıl Çalışır:

Ön masada (UI) bir soru sorarak başlarsınız.  
Yönetici (MCP Sunucusu), hangi uzmanın (ajanın) size yardımcı olacağını belirler.  
Uzman, isteğinizi anlamak için dil uzmanını (OpenAI) ve en iyi yanıtı bulmak için kütüphaneyi (AI Search) kullanır.  
Güvenlik görevlisi (Kimlik Doğrulama), her şeyin güvenli olduğundan emin olur.  
Tüm bunlar güvenilir, ölçeklenebilir bir binada (Azure Container Apps) gerçekleşir, böylece deneyiminiz sorunsuz ve güvenli olur.  
Bu ekip çalışması sayesinde sistem, uzman seyahat acenteleri gibi hızlı ve güvenli bir şekilde seyahatinizi planlamanıza yardımcı olur!

## Teknik Uygulama
- **MCP Sunucusu:** Çekirdek koordinasyon mantığını barındırır, ajan araçlarını açığa çıkarır ve çok adımlı seyahat planlama iş akışları için bağlamı yönetir.
- **Ajanlar:** Her ajan (örneğin FlightAgent, HotelAgent), kendi istem şablonları ve mantığıyla MCP aracı olarak uygulanmıştır.
- **Azure Entegrasyonu:** Doğal dil anlama için Azure OpenAI ve veri erişimi için Azure AI Search kullanılır.
- **Güvenlik:** Microsoft Entra ID ile kimlik doğrulama entegre edilmiştir ve tüm kaynaklar için en az ayrıcalık erişim kontrolleri uygulanır.
- **Dağıtım:** Ölçeklenebilirlik ve operasyonel verimlilik için Azure Container Apps üzerinde dağıtımı destekler.

## Sonuçlar ve Etki
- MCP’nin gerçek dünya, üretim kalitesinde bir senaryoda çoklu yapay zeka ajanlarını koordine etmek için nasıl kullanılabileceğini gösterir.
- Ajan koordinasyonu, veri entegrasyonu ve güvenli dağıtım için yeniden kullanılabilir kalıplar sunarak çözüm geliştirmeyi hızlandırır.
- MCP ve Azure servislerini kullanarak alan spesifik, yapay zeka destekli uygulamalar geliştirmek için bir şablon görevi görür.

## Referanslar
- [Azure AI Travel Agents GitHub Deposu](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Hizmeti](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda oluşabilecek yanlış anlamalar veya yorum farklılıklarından sorumlu değiliz.