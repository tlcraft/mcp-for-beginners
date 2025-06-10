<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-06-10T04:56:10+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "tr"
}
-->
# AI İş Akışlarını Kolaylaştırma: AI Toolkit ile MCP Sunucusu Oluşturma

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.tr.png)

## 🎯 Genel Bakış

**Model Context Protocol (MCP) Atölyesi’ne hoş geldiniz!** Bu kapsamlı uygulamalı atölye, AI uygulama geliştirmeyi dönüştürmek için iki ileri teknoloji bir araya getiriyor:

- **🔗 Model Context Protocol (MCP)**: AI araçlarının sorunsuz entegrasyonu için açık standart
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**: Microsoft’un güçlü AI geliştirme eklentisi

### 🎓 Neler Öğreneceksiniz

Bu atölyenin sonunda, AI modellerini gerçek dünya araçları ve servislerle birleştiren akıllı uygulamalar geliştirme konusunda uzmanlaşacaksınız. Otomatik testlerden özel API entegrasyonlarına kadar, karmaşık iş sorunlarını çözmek için pratik beceriler kazanacaksınız.

## 🏗️ Teknoloji Yığını

### 🔌 Model Context Protocol (MCP)

MCP, AI için **"USB-C"** gibidir — AI modellerini dış araçlar ve veri kaynaklarıyla bağlayan evrensel bir standart.

**✨ Temel Özellikler:**
- 🔄 **Standartlaştırılmış Entegrasyon**: AI araç bağlantıları için evrensel arayüz
- 🏛️ **Esnek Mimari**: stdio/SSE üzerinden yerel ve uzak sunucular
- 🧰 **Zengin Ekosistem**: Araçlar, istemler ve kaynaklar tek protokolde
- 🔒 **Kurumsal Hazır**: Yerleşik güvenlik ve güvenilirlik

**🎯 MCP’nin Önemi:**
USB-C’nin kablo karmaşasını ortadan kaldırması gibi, MCP de AI entegrasyonlarının karmaşıklığını kaldırır. Tek protokol, sonsuz imkan.

### 🤖 AI Toolkit for Visual Studio Code (AITK)

Microsoft’un amiral gemisi AI geliştirme eklentisi, VS Code’u güçlü bir AI merkezine dönüştürür.

**🚀 Temel Yetkinlikler:**
- 📦 **Model Kataloğu**: Azure AI, GitHub, Hugging Face, Ollama modellerine erişim
- ⚡ **Yerel Çıkarım**: ONNX optimize edilmiş CPU/GPU/NPU çalıştırma
- 🏗️ **Agent Builder**: MCP entegrasyonlu görsel AI ajan geliştirme
- 🎭 **Çok Modlu Destek**: Metin, görsel ve yapılandırılmış çıktı desteği

**💡 Geliştirme Avantajları:**
- Sıfır konfigürasyonla model dağıtımı
- Görsel istem mühendisliği
- Gerçek zamanlı test ortamı
- Sorunsuz MCP sunucu entegrasyonu

## 📚 Öğrenme Yolculuğu

### [🚀 Modül 1: AI Toolkit Temelleri](./lab1/README.md)
**Süre**: 15 dakika
- 🛠️ AI Toolkit’i VS Code’a kur ve yapılandır
- 🗂️ Model Kataloğunu keşfet (GitHub, ONNX, OpenAI, Anthropic, Google’dan 100+ model)
- 🎮 Gerçek zamanlı model testi için Etkileşimli Oyun Alanı’nı kullan
- 🤖 Agent Builder ile ilk AI ajanını oluştur
- 📊 Dahili metriklerle model performansını değerlendir (F1, alaka, benzerlik, tutarlılık)
- ⚡ Toplu işleme ve çok modlu destek özelliklerini öğren

**🎯 Öğrenme Hedefi**: AITK yeteneklerini kapsamlı şekilde kullanarak işlevsel bir AI ajan oluştur

### [🌐 Modül 2: MCP ile AI Toolkit Temelleri](./lab2/README.md)
**Süre**: 20 dakika
- 🧠 Model Context Protocol (MCP) mimarisi ve kavramlarını öğren
- 🌐 Microsoft’un MCP sunucu ekosistemini keşfet
- 🤖 Playwright MCP sunucusunu kullanarak tarayıcı otomasyon ajanı oluştur
- 🔧 MCP sunucularını AI Toolkit Agent Builder ile entegre et
- 📊 MCP araçlarını ajanlarında yapılandır ve test et
- 🚀 MCP destekli ajanları üretime hazır hale getir ve dağıt

**🎯 Öğrenme Hedefi**: MCP ile dış araçlarla güçlendirilmiş AI ajanı dağıt

### [🔧 Modül 3: AI Toolkit ile İleri MCP Geliştirme](./lab3/README.md)
**Süre**: 20 dakika
- 💻 AI Toolkit kullanarak özel MCP sunucuları oluştur
- 🐍 En güncel MCP Python SDK’sını (v1.9.3) yapılandır ve kullan
- 🔍 MCP Inspector ile hata ayıklamayı ayarla ve kullan
- 🛠️ Profesyonel hata ayıklama iş akışlarıyla Hava Durumu MCP Sunucusu oluştur
- 🧪 Agent Builder ve Inspector ortamlarında MCP sunucularını hata ayıkla

**🎯 Öğrenme Hedefi**: Modern araçlarla özel MCP sunucuları geliştir ve hata ayıkla

### [🐙 Modül 4: Pratik MCP Geliştirme - Özel GitHub Clone Sunucusu](./lab4/README.md)
**Süre**: 30 dakika
- 🏗️ Geliştirme iş akışları için gerçek dünya GitHub Clone MCP Sunucusu oluştur
- 🔄 Doğrulama ve hata yönetimi ile akıllı depo klonlama uygula
- 📁 Akıllı dizin yönetimi ve VS Code entegrasyonu yarat
- 🤖 Özel MCP araçları ile GitHub Copilot Agent Modunu kullan
- 🛡️ Üretime hazır güvenilirlik ve çapraz platform uyumluluğu sağla

**🎯 Öğrenme Hedefi**: Gerçek geliştirme iş akışlarını kolaylaştıran üretime hazır MCP sunucusu dağıt

## 💡 Gerçek Dünya Uygulamaları & Etki

### 🏢 Kurumsal Kullanım Senaryoları

#### 🔄 DevOps Otomasyonu
Geliştirme iş akışınızı akıllı otomasyonla dönüştürün:
- **Akıllı Depo Yönetimi**: AI destekli kod inceleme ve birleştirme kararları
- **Akıllı CI/CD**: Kod değişikliklerine göre otomatik pipeline optimizasyonu
- **Sorun Sınıflandırma**: Otomatik hata sınıflandırma ve atama

#### 🧪 Kalite Güvencesinde Devrim
AI destekli otomasyonla test süreçlerini geliştirin:
- **Akıllı Test Oluşturma**: Kapsamlı test setleri otomatik oluşturma
- **Görsel Regresyon Testi**: AI destekli UI değişiklik tespiti
- **Performans İzleme**: Proaktif sorun tespiti ve çözümü

#### 📊 Veri İşleme Akıllılığı
Daha akıllı veri işleme iş akışları oluşturun:
- **Uyarlanabilir ETL Süreçleri**: Kendi kendini optimize eden veri dönüşümleri
- **Anomali Tespiti**: Gerçek zamanlı veri kalitesi izleme
- **Akıllı Yönlendirme**: Veri akışının akıllı yönetimi

#### 🎧 Müşteri Deneyimi İyileştirme
Olağanüstü müşteri etkileşimleri yaratın:
- **Bağlam Farkındalıklı Destek**: Müşteri geçmişine erişen AI ajanları
- **Proaktif Sorun Çözümü**: Öngörücü müşteri hizmetleri
- **Çok Kanallı Entegrasyon**: Platformlar arası birleşik AI deneyimi

## 🛠️ Gereksinimler & Kurulum

### 💻 Sistem Gereksinimleri

| Bileşen               | Gereksinim                | Notlar                     |
|-----------------------|---------------------------|----------------------------|
| **İşletim Sistemi**    | Windows 10+, macOS 10.15+, Linux | Güncel herhangi bir OS    |
| **Visual Studio Code** | En son kararlı sürüm      | AITK için gerekli          |
| **Node.js**            | v18.0+ ve npm             | MCP sunucu geliştirme için |
| **Python**             | 3.10+                     | Python MCP sunucuları için isteğe bağlı |
| **Bellek**             | En az 8GB RAM             | Yerel modeller için 16GB önerilir |

### 🔧 Geliştirme Ortamı

#### Önerilen VS Code Eklentileri
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) - İsteğe bağlı ama faydalı

#### İsteğe Bağlı Araçlar
- **uv**: Modern Python paket yöneticisi
- **MCP Inspector**: MCP sunucuları için görsel hata ayıklama aracı
- **Playwright**: Web otomasyon örnekleri için

## 🎖️ Öğrenme Kazanımları & Sertifika Yolu

### 🏆 Beceri Ustalık Kontrol Listesi

Bu atölyeyi tamamlayarak aşağıdaki konularda uzmanlaşacaksınız:

#### 🎯 Temel Yetkinlikler
- [ ] **MCP Protokolü Ustalığı**: Mimari ve uygulama kalıplarını derinlemesine anlama
- [ ] **AITK Yetkinliği**: AI Toolkit’i hızlı geliştirme için uzman düzeyde kullanma
- [ ] **Özel Sunucu Geliştirme**: Üretim MCP sunucuları oluşturma, dağıtma ve sürdürme
- [ ] **Araç Entegrasyonu Mükemmelliği**: AI’yı mevcut geliştirme iş akışlarına sorunsuz bağlama
- [ ] **Sorun Çözme Uygulaması**: Öğrenilen becerileri gerçek iş sorunlarına uygulama

#### 🔧 Teknik Beceriler
- [ ] VS Code’da AI Toolkit’i kurma ve yapılandırma
- [ ] Özel MCP sunucuları tasarlama ve uygulama
- [ ] GitHub Modellerini MCP mimarisi ile entegre etme
- [ ] Playwright ile otomatik test iş akışları oluşturma
- [ ] Üretim için AI ajanları dağıtma
- [ ] MCP sunucu performansını hata ayıklama ve optimize etme

#### 🚀 İleri Yetkinlikler
- [ ] Kurumsal ölçekli AI entegrasyonları tasarlama
- [ ] AI uygulamaları için güvenlik en iyi uygulamalarını uygulama
- [ ] Ölçeklenebilir MCP sunucu mimarileri tasarlama
- [ ] Belirli alanlar için özel araç zincirleri oluşturma
- [ ] AI yerel geliştirmede başkalarına rehberlik etme

## 📖 Ek Kaynaklar
- [MCP Specification](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)
- [Sample MCP Servers Collection](https://github.com/modelcontextprotocol/servers)
- [Best Practices Guide](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 AI geliştirme iş akışınızı devrim niteliğinde değiştirmeye hazır mısınız?**

MCP ve AI Toolkit ile akıllı uygulamaların geleceğini birlikte inşa edelim!

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba sarf etsek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi ana dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorumlamalardan sorumlu değiliz.