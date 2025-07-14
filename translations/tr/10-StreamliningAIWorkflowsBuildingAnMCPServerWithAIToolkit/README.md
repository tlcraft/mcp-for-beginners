<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-07-14T07:07:01+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "tr"
}
-->
# Yapay Zeka İş Akışlarını Kolaylaştırma: AI Toolkit ile MCP Sunucusu Kurma

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.tr.png)

## 🎯 Genel Bakış

**Model Context Protocol (MCP) Atölyesine** hoş geldiniz! Bu kapsamlı uygulamalı atölye, yapay zeka uygulama geliştirmeyi dönüştürmek için iki ileri teknoloji bir araya getiriyor:

- **🔗 Model Context Protocol (MCP)**: Yapay zeka araçlarının sorunsuz entegrasyonu için açık standart
- **🛠️ Visual Studio Code için AI Toolkit (AITK)**: Microsoft’un güçlü yapay zeka geliştirme eklentisi

### 🎓 Neler Öğreneceksiniz

Bu atölyenin sonunda, yapay zeka modellerini gerçek dünya araçları ve servislerle birleştiren akıllı uygulamalar geliştirme becerisi kazanacaksınız. Otomatik testlerden özel API entegrasyonlarına kadar, karmaşık iş problemlerini çözmek için pratik yetkinlikler edineceksiniz.

## 🏗️ Teknoloji Yığını

### 🔌 Model Context Protocol (MCP)

MCP, yapay zeka modellerini dış araçlar ve veri kaynaklarına bağlayan **"Yapay Zeka için USB-C"** evrensel bir standarttır.

**✨ Temel Özellikler:**
- 🔄 **Standartlaştırılmış Entegrasyon**: Yapay zeka araç bağlantıları için evrensel arayüz
- 🏛️ **Esnek Mimari**: stdio/SSE taşıma ile yerel ve uzak sunucular
- 🧰 **Zengin Ekosistem**: Araçlar, istemler ve kaynaklar tek protokolde
- 🔒 **Kurumsal Hazır**: Yerleşik güvenlik ve güvenilirlik

**🎯 MCP’nin Önemi:**
USB-C kablo karmaşasını ortadan kaldırdığı gibi, MCP de yapay zeka entegrasyonlarının karmaşıklığını giderir. Tek protokol, sonsuz imkan.

### 🤖 Visual Studio Code için AI Toolkit (AITK)

Microsoft’un amiral gemisi yapay zeka geliştirme eklentisi, VS Code’u güçlü bir yapay zeka merkezine dönüştürür.

**🚀 Temel Yetenekler:**
- 📦 **Model Kataloğu**: Azure AI, GitHub, Hugging Face, Ollama modellerine erişim
- ⚡ **Yerel Çıkarım**: ONNX optimize edilmiş CPU/GPU/NPU çalıştırma
- 🏗️ **Agent Builder**: MCP entegrasyonlu görsel yapay zeka ajan geliştirme
- 🎭 **Çok Modlu Destek**: Metin, görsel ve yapılandırılmış çıktı desteği

**💡 Geliştirme Avantajları:**
- Sıfır yapılandırma ile model dağıtımı
- Görsel istem mühendisliği
- Gerçek zamanlı test ortamı
- Sorunsuz MCP sunucu entegrasyonu

## 📚 Öğrenme Yolculuğu

### [🚀 Modül 1: AI Toolkit Temelleri](./lab1/README.md)
**Süre**: 15 dakika
- 🛠️ VS Code için AI Toolkit kurulumu ve yapılandırması
- 🗂️ Model Kataloğunu keşfetme (GitHub, ONNX, OpenAI, Anthropic, Google’dan 100+ model)
- 🎮 Gerçek zamanlı model testi için Etkileşimli Oyun Alanı kullanımı
- 🤖 Agent Builder ile ilk yapay zeka ajanınızı oluşturma
- 📊 Yerleşik metriklerle model performansını değerlendirme (F1, alaka, benzerlik, tutarlılık)
- ⚡ Toplu işlem ve çok modlu destek özelliklerini öğrenme

**🎯 Öğrenme Hedefi**: AITK yeteneklerini kapsamlı şekilde anlayarak işlevsel bir yapay zeka ajanı oluşturmak

### [🌐 Modül 2: MCP ve AI Toolkit Temelleri](./lab2/README.md)
**Süre**: 20 dakika
- 🧠 Model Context Protocol (MCP) mimarisi ve kavramlarını öğrenme
- 🌐 Microsoft’un MCP sunucu ekosistemini keşfetme
- 🤖 Playwright MCP sunucusu kullanarak tarayıcı otomasyon ajanı geliştirme
- 🔧 MCP sunucularını AI Toolkit Agent Builder ile entegre etme
- 📊 Ajanlarınızda MCP araçlarını yapılandırma ve test etme
- 🚀 MCP destekli ajanları üretim için dışa aktarma ve dağıtma

**🎯 Öğrenme Hedefi**: MCP ile dış araçlarla güçlendirilmiş yapay zeka ajanı dağıtmak

### [🔧 Modül 3: AI Toolkit ile İleri MCP Geliştirme](./lab3/README.md)
**Süre**: 20 dakika
- 💻 AI Toolkit kullanarak özel MCP sunucuları oluşturma
- 🐍 En güncel MCP Python SDK’sını (v1.9.3) yapılandırma ve kullanma
- 🔍 MCP Inspector ile hata ayıklama kurulum ve kullanımı
- 🛠️ Profesyonel hata ayıklama iş akışlarıyla Hava Durumu MCP Sunucusu geliştirme
- 🧪 Agent Builder ve Inspector ortamlarında MCP sunucularını hata ayıklama

**🎯 Öğrenme Hedefi**: Modern araçlarla özel MCP sunucuları geliştirme ve hata ayıklama

### [🐙 Modül 4: Pratik MCP Geliştirme - Özel GitHub Clone Sunucusu](./lab4/README.md)
**Süre**: 30 dakika
- 🏗️ Gerçek dünya geliştirme iş akışları için GitHub Clone MCP Sunucusu oluşturma
- 🔄 Doğrulama ve hata yönetimi ile akıllı depo klonlama uygulama
- 📁 Akıllı dizin yönetimi ve VS Code entegrasyonu oluşturma
- 🤖 Özel MCP araçlarıyla GitHub Copilot Agent Modunu kullanma
- 🛡️ Üretim hazır güvenilirlik ve çok platform uyumluluğu sağlama

**🎯 Öğrenme Hedefi**: Gerçek geliştirme iş akışlarını kolaylaştıran üretim hazır MCP sunucusu dağıtmak

## 💡 Gerçek Dünya Uygulamaları ve Etkisi

### 🏢 Kurumsal Kullanım Senaryoları

#### 🔄 DevOps Otomasyonu
Geliştirme iş akışınızı akıllı otomasyonla dönüştürün:
- **Akıllı Depo Yönetimi**: Yapay zeka destekli kod inceleme ve birleştirme kararları
- **Akıllı CI/CD**: Kod değişikliklerine dayalı otomatik pipeline optimizasyonu
- **Sorun Sınıflandırma**: Otomatik hata sınıflandırma ve atama

#### 🧪 Kalite Güvencesinde Devrim
Yapay zeka destekli otomasyonla testleri yükseltin:
- **Akıllı Test Üretimi**: Kapsamlı test setleri otomatik oluşturma
- **Görsel Regresyon Testi**: Yapay zeka destekli kullanıcı arayüzü değişiklik tespiti
- **Performans İzleme**: Proaktif sorun tespiti ve çözümü

#### 📊 Veri Boru Hattı Zekası
Daha akıllı veri işleme iş akışları oluşturun:
- **Uyarlanabilir ETL Süreçleri**: Kendi kendini optimize eden veri dönüşümleri
- **Anomali Tespiti**: Gerçek zamanlı veri kalitesi izleme
- **Akıllı Yönlendirme**: Veri akışının akıllı yönetimi

#### 🎧 Müşteri Deneyimi İyileştirme
Olağanüstü müşteri etkileşimleri yaratın:
- **Bağlam Odaklı Destek**: Müşteri geçmişine erişimi olan yapay zeka ajanları
- **Proaktif Sorun Çözümü**: Öngörücü müşteri hizmetleri
- **Çok Kanallı Entegrasyon**: Platformlar arası birleşik yapay zeka deneyimi

## 🛠️ Gereksinimler ve Kurulum

### 💻 Sistem Gereksinimleri

| Bileşen | Gereksinim | Notlar |
|---------|------------|--------|
| **İşletim Sistemi** | Windows 10+, macOS 10.15+, Linux | Herhangi modern işletim sistemi |
| **Visual Studio Code** | En son kararlı sürüm | AITK için gerekli |
| **Node.js** | v18.0+ ve npm | MCP sunucu geliştirme için |
| **Python** | 3.10+ | Python MCP sunucuları için isteğe bağlı |
| **Bellek** | En az 8GB RAM | Yerel modeller için 16GB önerilir |

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

## 🎖️ Öğrenme Çıktıları ve Sertifikasyon Yolu

### 🏆 Beceri Ustalık Kontrol Listesi

Bu atölyeyi tamamlayarak aşağıdaki alanlarda ustalık kazanacaksınız:

#### 🎯 Temel Yetkinlikler
- [ ] **MCP Protokolü Ustalığı**: Mimari ve uygulama kalıplarını derinlemesine anlama
- [ ] **AITK Yetkinliği**: AI Toolkit’i hızlı geliştirme için uzman düzeyinde kullanma
- [ ] **Özel Sunucu Geliştirme**: Üretim MCP sunucuları oluşturma, dağıtma ve bakım
- [ ] **Araç Entegrasyonu Mükemmelliği**: Yapay zekayı mevcut geliştirme iş akışlarına sorunsuz bağlama
- [ ] **Problem Çözme Uygulaması**: Öğrenilen becerileri gerçek iş problemlerine uygulama

#### 🔧 Teknik Beceriler
- [ ] VS Code’da AI Toolkit kurulumu ve yapılandırması
- [ ] Özel MCP sunucuları tasarlama ve uygulama
- [ ] GitHub Modellerini MCP mimarisiyle entegre etme
- [ ] Playwright ile otomatik test iş akışları oluşturma
- [ ] Üretim için yapay zeka ajanları dağıtma
- [ ] MCP sunucu performansını hata ayıklama ve optimize etme

#### 🚀 İleri Düzey Yetenekler
- [ ] Kurumsal ölçekli yapay zeka entegrasyonları tasarlama
- [ ] Yapay zeka uygulamaları için güvenlik en iyi uygulamalarını uygulama
- [ ] Ölçeklenebilir MCP sunucu mimarileri tasarlama
- [ ] Belirli alanlar için özel araç zincirleri oluşturma
- [ ] Yapay zeka tabanlı geliştirmede başkalarına rehberlik etme

## 📖 Ek Kaynaklar
- [MCP Spesifikasyonu](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Deposu](https://github.com/microsoft/vscode-ai-toolkit)
- [Örnek MCP Sunucuları Koleksiyonu](https://github.com/modelcontextprotocol/servers)
- [En İyi Uygulamalar Kılavuzu](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 Yapay zeka geliştirme iş akışınızı devrim niteliğinde değiştirmeye hazır mısınız?**

MCP ve AI Toolkit ile akıllı uygulamaların geleceğini birlikte inşa edelim!

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi ana dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.