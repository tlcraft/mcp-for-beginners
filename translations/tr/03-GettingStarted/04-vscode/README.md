<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T15:46:17+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "tr"
}
-->
Görsel arayüzü nasıl kullanacağımızı sonraki bölümlerde daha ayrıntılı konuşalım.

## Yaklaşım

Yüksek seviyede bu konuya nasıl yaklaşmamız gerektiği şöyle:

- MCP Server'ımızı bulmak için bir dosya yapılandırmak.
- Söz konusu sunucuyu başlatmak/bağlanmak ve yeteneklerini listelemesini sağlamak.
- Bu yetenekleri GitHub Copilot Chat arayüzü üzerinden kullanmak.

Harika, akışı anladığımıza göre, şimdi bir egzersizle Visual Studio Code üzerinden bir MCP Server kullanmayı deneyelim.

## Egzersiz: Bir sunucuyu kullanmak

Bu egzersizde, MCP sunucunuzu GitHub Copilot Chat arayüzünden kullanılabilir hale getirmek için Visual Studio Code'un sunucunuzu bulmasını sağlayacak şekilde yapılandıracağız.

### -0- Ön adım, MCP Server keşfini etkinleştirme

MCP Server keşfini etkinleştirmeniz gerekebilir.

1. `File -> Preferences -> Settings` yolunu izleyin ve settings.json dosyasında ` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled ayarını bulun.

### -1- Konfigürasyon dosyası oluşturma

Proje kök dizininizde bir konfigürasyon dosyası oluşturarak başlayın, MCP.json adında bir dosya oluşturmanız ve bunu .vscode adlı bir klasöre yerleştirmeniz gerekiyor. Dosya şu şekilde görünmeli:

```text
.vscode
|-- mcp.json
```

Sonra, bir sunucu girdisinin nasıl ekleneceğine bakalım.

### -2- Sunucu yapılandırma

*mcp.json* dosyasına aşağıdaki içeriği ekleyin:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

Yukarıda Node.js ile yazılmış bir sunucunun nasıl başlatılacağına dair basit bir örnek var, diğer çalışma zamanları için `command` and `args` kullanarak sunucuyu başlatmak için doğru komutu belirtin.

### -3- Sunucuyu başlatma

Bir girdi eklediğinize göre, şimdi sunucuyu başlatalım:

1. *mcp.json* dosyanızdaki girdinizi bulun ve "play" simgesini gördüğünüzden emin olun:

  ![Visual Studio Code'da sunucu başlatma](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.tr.png)  

1. "play" simgesine tıklayın, GitHub Copilot Chat'teki araçlar simgesinin kullanılabilir araç sayısını artırdığını görmelisiniz. Bu araçlar simgesine tıkladığınızda kayıtlı araçların listesini göreceksiniz. GitHub Copilot'un bu araçları bağlam olarak kullanmasını isteyip istemediğinize göre her aracı işaretleyip kaldırabilirsiniz:

  ![Visual Studio Code'da araçlar](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.tr.png)

1. Bir aracı çalıştırmak için, araçlarınızdan birinin açıklamasıyla eşleşeceğini bildiğiniz bir istem yazın, örneğin "add 22 to 1" gibi bir istem:

  ![GitHub Copilot'dan bir aracı çalıştırma](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.tr.png)

  23 cevabını görmelisiniz.

## Ödev

*mcp.json* dosyanıza bir sunucu girdisi eklemeyi deneyin ve sunucuyu başlatıp durdurabildiğinizden emin olun. Ayrıca GitHub Copilot Chat arayüzü üzerinden sunucunuzdaki araçlarla iletişim kurabildiğinizi doğrulayın.

## Çözüm

[Çözüm](./solution/README.md)

## Ana Noktalar

Bu bölümden çıkarılacak ana noktalar şunlardır:

- Visual Studio Code, birden fazla MCP Server ve araçlarını kullanmanızı sağlayan harika bir istemcidir.
- GitHub Copilot Chat arayüzü, sunucularla etkileşim kurduğunuz yerdir.
- Kullanıcıdan API anahtarları gibi girdiler isteyebilir ve bunları *mcp.json* dosyasındaki sunucu girdisi yapılandırılırken MCP Server'a iletebilirsiniz.

## Örnekler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

- [Visual Studio belgeleri](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Sonraki Adım

- Sonraki: [Bir SSE Sunucusu Oluşturma](/03-GettingStarted/05-sse-server/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.