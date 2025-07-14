<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "222e01c3002a33355806d60d558d9429",
  "translation_date": "2025-07-14T09:34:17+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "tr"
}
-->
Görsel arayüzü nasıl kullanacağımızı sonraki bölümlerde daha detaylı konuşalım.

## Yaklaşım

Yüksek seviyede nasıl yaklaşmamız gerektiği şöyle:

- MCP Sunucumuzu bulmak için bir dosya yapılandırmak.
- Söz konusu sunucuyu başlatmak/bağlanmak ve yeteneklerini listelemesini sağlamak.
- Bu yetenekleri GitHub Copilot Chat arayüzü üzerinden kullanmak.

Harika, akışı anladığımıza göre, bir egzersizle Visual Studio Code üzerinden bir MCP Sunucusu kullanmayı deneyelim.

## Egzersiz: Bir sunucuyu kullanmak

Bu egzersizde, Visual Studio Code'u MCP sunucunuzu bulacak şekilde yapılandıracağız, böylece GitHub Copilot Chat arayüzünden kullanılabilir olacak.

### -0- Ön adım, MCP Sunucu keşfini etkinleştirme

MCP Sunucularının keşfini etkinleştirmeniz gerekebilir.

1. Visual Studio Code'da `File -> Preferences -> Settings` menüsüne gidin.

1. "MCP" araması yapın ve settings.json dosyasında `chat.mcp.discovery.enabled` seçeneğini etkinleştirin.

### -1- Konfigürasyon dosyası oluşturma

Proje kök dizininizde bir konfigürasyon dosyası oluşturarak başlayın, MCP.json adında bir dosyaya ve bunu .vscode adlı bir klasöre yerleştirmeniz gerekiyor. Dosya şöyle görünmeli:

```text
.vscode
|-- mcp.json
```

Şimdi, bir sunucu girişi nasıl eklenir görelim.

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

Yukarıda Node.js ile yazılmış bir sunucuyu başlatmak için basit bir örnek var, diğer çalışma zamanları için `command` ve `args` kullanarak sunucuyu başlatmak için uygun komutu belirtin.

### -3- Sunucuyu başlatma

Bir giriş eklediğinize göre, şimdi sunucuyu başlatalım:

1. *mcp.json* dosyanızdaki girişinizi bulun ve "play" simgesini görebildiğinizden emin olun:

  ![Visual Studio Code'da sunucu başlatma](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.tr.png)  

1. "play" simgesine tıklayın, GitHub Copilot Chat'teki araçlar simgesinin kullanılabilir araç sayısını artırdığını görmelisiniz. Bu araçlar simgesine tıklarsanız, kayıtlı araçların bir listesini göreceksiniz. GitHub Copilot'un bunları bağlam olarak kullanmasını isteyip istemediğinize göre her aracı işaretleyip kaldırabilirsiniz:

  ![Visual Studio Code'da araçlar](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.tr.png)

1. Bir aracı çalıştırmak için, araçlarınızdan birinin açıklamasıyla eşleşeceğini bildiğiniz bir komut yazın, örneğin "add 22 to 1" gibi bir komut:

  ![GitHub Copilot'dan bir aracı çalıştırma](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.tr.png)

  23 cevabını görmelisiniz.

## Ödev

*mcp.json* dosyanıza bir sunucu girişi eklemeyi deneyin ve sunucuyu başlatıp durdurabildiğinizden emin olun. Ayrıca GitHub Copilot Chat arayüzü üzerinden sunucunuzdaki araçlarla iletişim kurabildiğinizi kontrol edin.

## Çözüm

[Çözüm](./solution/README.md)

## Önemli Noktalar

Bu bölümden çıkarılacak önemli noktalar şunlardır:

- Visual Studio Code, birden fazla MCP Sunucusunu ve araçlarını kullanmanızı sağlayan harika bir istemcidir.
- GitHub Copilot Chat arayüzü, sunucularla etkileşim kurduğunuz yerdir.
- Kullanıcıdan API anahtarları gibi girdiler istemek ve bunları *mcp.json* dosyasındaki sunucu girişini yapılandırırken MCP Sunucusuna iletmek mümkündür.

## Örnekler

- [Java Hesap Makinesi](../samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

- [Visual Studio dokümanları](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Sonraki Adım

- Sonraki: [Bir SSE Sunucusu Oluşturma](../05-sse-server/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.