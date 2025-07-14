<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:40:19+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "tr"
}
-->
# Chainlit & Microsoft Learn Docs MCP ile Çalışma Planı Oluşturucu

## Gereksinimler

- Python 3.8 veya üzeri
- pip (Python paket yöneticisi)
- Microsoft Learn Docs MCP sunucusuna bağlanmak için internet erişimi

## Kurulum

1. Bu depoyu klonlayın veya proje dosyalarını indirin.
2. Gerekli bağımlılıkları yükleyin:

   ```bash
   pip install -r requirements.txt
   ```

## Kullanım

### Senaryo 1: Docs MCP’ye Basit Sorgu
Docs MCP sunucusuna bağlanan, bir sorgu gönderen ve sonucu yazdıran komut satırı istemcisi.

1. Scripti çalıştırın:
   ```bash
   python scenario1.py
   ```
2. İstekte dokümantasyon sorunuz girin.

### Senaryo 2: Çalışma Planı Oluşturucu (Chainlit Web Uygulaması)
Kullanıcıların herhangi bir teknik konu için kişiselleştirilmiş, haftalık çalışma planı oluşturmasına olanak tanıyan web tabanlı arayüz (Chainlit kullanılarak).

1. Chainlit uygulamasını başlatın:
   ```bash
   chainlit run scenario2.py
   ```
2. Terminalde verilen yerel URL’yi (örneğin http://localhost:8000) tarayıcınızda açın.
3. Sohbet penceresine çalışma konunuzu ve çalışmak istediğiniz hafta sayısını girin (örneğin, "AI-900 sertifikası, 8 hafta").
4. Uygulama, ilgili Microsoft Learn dokümantasyonuna bağlantılar içeren haftalık çalışma planını yanıt olarak verecektir.

**Gerekli Ortam Değişkenleri:**

Senaryo 2’yi (Azure OpenAI ile Chainlit web uygulaması) kullanmak için, `python` dizininde `.env` dosyasına aşağıdaki ortam değişkenlerini eklemelisiniz:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Uygulamayı çalıştırmadan önce bu değerleri Azure OpenAI kaynak bilgilerinizle doldurun.

> **İpucu:** Kendi modellerinizi kolayca [Azure AI Foundry](https://ai.azure.com/) kullanarak dağıtabilirsiniz.

### Senaryo 3: VS Code İçinde MCP Sunucusu ile Dokümanlar

Tarayıcı sekmeleri arasında geçiş yapmak yerine, Microsoft Learn Docs’u doğrudan VS Code’a MCP sunucusu ile getirebilirsiniz. Bu sayede:
- Kodlama ortamınızı terk etmeden VS Code içinde doküman arayabilir ve okuyabilirsiniz.
- Dokümantasyona referans verip, bağlantıları doğrudan README veya kurs dosyalarınıza ekleyebilirsiniz.
- GitHub Copilot ve MCP’yi birlikte kullanarak kesintisiz, yapay zekâ destekli dokümantasyon akışı sağlayabilirsiniz.

**Örnek Kullanım Durumları:**
- Bir kurs veya proje dokümantasyonu yazarken README’ye hızlıca referans bağlantıları eklemek.
- Copilot ile kod üretirken MCP ile ilgili dokümanları anında bulup alıntılamak.
- Editörünüzde odaklanarak verimliliği artırmak.

> [!IMPORTANT]
> Çalışma alanınızda geçerli bir [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) yapılandırmasının olduğundan emin olun (konum `.vscode/mcp.json`).

## Neden Senaryo 2 için Chainlit?

Chainlit, sohbet tabanlı web uygulamaları oluşturmak için modern ve açık kaynaklı bir çerçevedir. Microsoft Learn Docs MCP sunucusu gibi arka uç servislerine bağlanan sohbet arayüzleri oluşturmayı kolaylaştırır. Bu proje, kişiselleştirilmiş çalışma planlarını gerçek zamanlı ve etkileşimli şekilde oluşturmak için Chainlit’i kullanır. Chainlit sayesinde, üretkenliği ve öğrenmeyi artıran sohbet tabanlı araçları hızlıca geliştirebilir ve dağıtabilirsiniz.

## Bu Ne Yapar?

Bu uygulama, kullanıcıların sadece bir konu ve süre girerek kişiselleştirilmiş bir çalışma planı oluşturmasını sağlar. Girdiğiniz bilgiyi analiz eder, Microsoft Learn Docs MCP sunucusuna ilgili içerik için sorgu gönderir ve sonuçları yapılandırılmış, haftalık plan halinde düzenler. Her haftanın önerileri sohbet penceresinde gösterilir, böylece ilerlemenizi kolayca takip edebilirsiniz. En güncel ve ilgili öğrenme kaynaklarını her zaman almanızı sağlar.

## Örnek Sorgular

Uygulamanın yanıtlarını görmek için sohbet penceresine şu sorguları deneyin:

- `AI-900 sertifikası, 8 hafta`
- `Azure Functions öğren, 4 hafta`
- `Azure DevOps, 6 hafta`
- `Azure’da veri mühendisliği, 10 hafta`
- `Microsoft güvenlik temelleri, 5 hafta`
- `Power Platform, 7 hafta`
- `Azure AI servisleri, 12 hafta`
- `Bulut mimarisi, 9 hafta`

Bu örnekler, uygulamanın farklı öğrenme hedefleri ve süreleri için ne kadar esnek olduğunu gösterir.

## Kaynaklar

- [Chainlit Dokümantasyonu](https://docs.chainlit.io/)
- [MCP Dokümantasyonu](https://github.com/MicrosoftDocs/mcp)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.