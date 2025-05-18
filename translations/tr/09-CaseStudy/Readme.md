<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:27:58+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "tr"
}
-->
# Vaka Çalışması: Azure AI Seyahat Acenteleri – Referans Uygulama

## Genel Bakış

[Azure AI Seyahat Acenteleri](https://github.com/Azure-Samples/azure-ai-travel-agents), Microsoft tarafından geliştirilen ve Model Context Protocol (MCP), Azure OpenAI ve Azure AI Search kullanarak çok ajanlı, yapay zeka destekli seyahat planlama uygulaması oluşturmayı gösteren kapsamlı bir referans çözümüdür. Bu proje, birden fazla yapay zeka ajanını düzenleme, kurumsal verileri entegre etme ve gerçek dünya senaryoları için güvenli, genişletilebilir bir platform sağlama konusunda en iyi uygulamaları sergilemektedir.

## Ana Özellikler
- **Çok Ajanlı Orkestrasyon:** MCP kullanarak karmaşık seyahat planlama görevlerini yerine getirmek için işbirliği yapan uzman ajanları (örneğin, uçuş, otel ve güzergah ajanları) koordine eder.
- **Kurumsal Veri Entegrasyonu:** Seyahat önerileri için güncel ve ilgili bilgileri sağlamak amacıyla Azure AI Search ve diğer kurumsal veri kaynaklarına bağlanır.
- **Güvenli, Ölçeklenebilir Mimari:** Kimlik doğrulama, yetkilendirme ve ölçeklenebilir dağıtım için Azure hizmetlerinden yararlanır ve kurumsal güvenlik en iyi uygulamalarını takip eder.
- **Genişletilebilir Araçlar:** Yeniden kullanılabilir MCP araçları ve istem şablonları uygular, yeni alanlara veya iş gereksinimlerine hızlı uyum sağlar.
- **Kullanıcı Deneyimi:** Azure OpenAI ve MCP ile güçlendirilmiş seyahat acenteleriyle etkileşim için kullanıcıya konuşma arayüzü sağlar.

## Mimari
![Mimari](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Mimari Diyagram Açıklaması

Azure AI Seyahat Acenteleri çözümü, birden fazla yapay zeka ajanı ve kurumsal veri kaynaklarının modüler, ölçeklenebilir ve güvenli entegrasyonu için tasarlanmıştır. Ana bileşenler ve veri akışı şu şekildedir:

- **Kullanıcı Arayüzü:** Kullanıcılar, sistemle konuşma UI (web sohbeti veya Teams bot gibi) aracılığıyla etkileşime girer, kullanıcı sorgularını gönderir ve seyahat önerilerini alır.
- **MCP Sunucusu:** Merkezi düzenleyici olarak hizmet verir, kullanıcı girdilerini alır, bağlamı yönetir ve Model Context Protocol aracılığıyla uzman ajanların (örneğin, FlightAgent, HotelAgent, ItineraryAgent) eylemlerini koordine eder.
- **AI Ajanları:** Her ajan belirli bir alandan (uçuşlar, oteller, güzergahlar) sorumludur ve bir MCP aracı olarak uygulanır. Ajanlar, istekleri işlemek ve yanıtlar üretmek için istem şablonlarını ve mantığını kullanır.
- **Azure OpenAI Hizmeti:** Kullanıcı niyetini yorumlamak ve konuşma yanıtları oluşturmak için gelişmiş doğal dil anlama ve üretimi sağlar.
- **Azure AI Search & Kurumsal Veri:** Ajanlar, uçuşlar, oteller ve seyahat seçenekleri hakkında güncel bilgileri almak için Azure AI Search ve diğer kurumsal veri kaynaklarını sorgular.
- **Kimlik Doğrulama & Güvenlik:** Microsoft Entra ID ile güvenli kimlik doğrulama entegre eder ve tüm kaynaklara en az ayrıcalık erişim kontrolleri uygular.
- **Dağıtım:** Azure Container Apps üzerinde dağıtım için tasarlanmış, ölçeklenebilirlik, izleme ve operasyonel verimlilik sağlar.

Bu mimari, birden fazla yapay zeka ajanının sorunsuz orkestrasyonunu, kurumsal verilerle güvenli entegrasyonu ve alan spesifik yapay zeka çözümleri oluşturmak için sağlam, genişletilebilir bir platform sağlar.

## Mimari Diyagramının Adım Adım Açıklaması
Büyük bir seyahat planladığınızı ve her detayı sizinle birlikte planlayan uzman asistanlardan oluşan bir ekibiniz olduğunu hayal edin. Azure AI Seyahat Acenteleri sistemi benzer şekilde çalışır, her biri özel bir görevi olan farklı parçaları (ekip üyeleri gibi) kullanır. İşte nasıl bir araya geldikleri:

### Kullanıcı Arayüzü (UI):
Bunu seyahat acentenizin ön masası olarak düşünün. Burada siz (kullanıcı) soru sorar veya isteklerde bulunursunuz, örneğin “Bana Paris'e bir uçuş bul.” Bu, bir web sitesindeki sohbet penceresi veya bir mesajlaşma uygulaması olabilir.

### MCP Sunucusu (Koordinatör):
MCP Sunucusu, ön masadaki isteğinizi dinleyen ve her bölümü hangi uzmanın ele alması gerektiğine karar veren yönetici gibidir. Konuşmanızı takip eder ve her şeyin sorunsuz ilerlemesini sağlar.

### AI Ajanları (Uzman Asistanlar):
Her ajan belirli bir alanda uzmandır—biri uçuşlar hakkında her şeyi bilir, diğeri otelleri, bir diğeri güzergahınızı planlamayı bilir. Bir seyahat talep ettiğinizde, MCP Sunucusu isteğinizi doğru ajan(lar)a gönderir. Bu ajanlar, sizin için en iyi seçenekleri bulmak için bilgi ve araçlarını kullanır.

### Azure OpenAI Hizmeti (Dil Uzmanı):
Bu, nasıl ifade ettiğiniz önemli olmaksızın tam olarak ne istediğinizi anlayan bir dil uzmanı gibi. Ajanların isteklerinizi anlamalarına ve doğal, konuşma dilinde yanıt vermelerine yardımcı olur.

### Azure AI Search & Kurumsal Veri (Bilgi Kütüphanesi):
Uçuş tarifeleri, otel müsaitliği ve daha fazlasıyla dolu, en güncel seyahat bilgilerine sahip devasa bir kütüphane hayal edin. Ajanlar, size en doğru cevapları vermek için bu kütüphaneyi araştırır.

### Kimlik Doğrulama & Güvenlik (Güvenlik Görevlisi):
Tıpkı bir güvenlik görevlisinin belirli alanlara kimlerin girebileceğini kontrol etmesi gibi, bu bölüm yalnızca yetkilendirilmiş kişilerin ve ajanların hassas bilgilere erişmesini sağlar. Verilerinizi güvende ve özel tutar.

### Azure Container Apps Üzerinde Dağıtım (Bina):
Tüm bu asistanlar ve araçlar, güvenli, ölçeklenebilir bir binanın (bulut) içinde birlikte çalışır. Bu, sistemin aynı anda birçok kullanıcıyı idare edebileceği ve ihtiyaç duyduğunuzda her zaman kullanılabilir olduğu anlamına gelir.

## Nasıl Birlikte Çalışıyor:

Ön masada (UI) bir soru sorarak başlarsınız.
Yönetici (MCP Sunucusu), hangi uzmanın (ajan) size yardımcı olması gerektiğini belirler.
Uzman, isteğinizi anlamak için dil uzmanını (OpenAI) ve en iyi cevabı bulmak için kütüphaneyi (AI Search) kullanır.
Güvenlik görevlisi (Kimlik Doğrulama), her şeyin güvenli olmasını sağlar.
Tüm bunlar, deneyiminizin sorunsuz ve güvenli olması için güvenilir, ölçeklenebilir bir binanın içinde (Azure Container Apps) gerçekleşir.
Bu ekip çalışması, sistemin seyahatinizi planlamada hızlı ve güvenli bir şekilde size yardımcı olmasını sağlar, tıpkı modern bir ofiste birlikte çalışan uzman seyahat acenteleri ekibi gibi!

## Teknik Uygulama
- **MCP Sunucusu:** Temel orkestrasyon mantığını barındırır, ajan araçlarını sunar ve çok aşamalı seyahat planlama iş akışları için bağlamı yönetir.
- **Ajanlar:** Her ajan (örneğin, FlightAgent, HotelAgent), kendi istem şablonları ve mantığı ile bir MCP aracı olarak uygulanır.
- **Azure Entegrasyonu:** Doğal dil anlama için Azure OpenAI ve veri alma için Azure AI Search kullanır.
- **Güvenlik:** Kimlik doğrulama için Microsoft Entra ID ile entegre eder ve tüm kaynaklara en az ayrıcalık erişim kontrolleri uygular.
- **Dağıtım:** Ölçeklenebilirlik ve operasyonel verimlilik için Azure Container Apps'e dağıtımı destekler.

## Sonuçlar ve Etki
- MCP'nin gerçek dünya, üretim kalitesinde bir senaryoda birden fazla yapay zeka ajanını düzenlemek için nasıl kullanılabileceğini gösterir.
- Ajan koordinasyonu, veri entegrasyonu ve güvenli dağıtım için yeniden kullanılabilir kalıplar sağlayarak çözüm geliştirmeyi hızlandırır.
- MCP ve Azure hizmetlerini kullanarak alan spesifik, yapay zeka destekli uygulamalar oluşturmak için bir plan görevi görür.

## Referanslar
- [Azure AI Seyahat Acenteleri GitHub Deposu](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Hizmeti](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Feragatname**: 
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösteriyoruz, ancak otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalar için sorumluluk kabul etmiyoruz.