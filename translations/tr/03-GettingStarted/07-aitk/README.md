<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:19:41+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "tr"
}
-->
# Visual Studio Code için AI Toolkit uzantısından bir sunucuyu kullanma

Bir AI ajanı oluştururken, sadece akıllı yanıtlar üretmekle kalmaz, aynı zamanda ajanın harekete geçme yeteneğine sahip olması da önemlidir. İşte burada Model Context Protocol (MCP) devreye girer. MCP, ajanların dış araçlara ve servislere tutarlı bir şekilde erişmesini kolaylaştırır. Bunu, ajanın gerçekten kullanabileceği bir araç kutusuna bağlanmak gibi düşünebilirsiniz.

Diyelim ki bir ajanı hesap makinesi MCP sunucunuza bağladınız. Birdenbire, ajanınız “47 çarpı 89 nedir?” gibi bir komut alarak matematik işlemleri yapabilir—mantığı kodlamaya veya özel API’ler geliştirmeye gerek kalmaz.

## Genel Bakış

Bu ders, Visual Studio Code’daki [AI Toolkit](https://aka.ms/AIToolkit) uzantısı ile bir hesap makinesi MCP sunucusunu bir ajana bağlamayı ve ajanın toplama, çıkarma, çarpma ve bölme gibi matematik işlemlerini doğal dil aracılığıyla yapmasını sağlamayı kapsar.

AI Toolkit, Visual Studio Code için güçlü bir uzantıdır ve ajan geliştirmeyi kolaylaştırır. AI mühendisleri, üretken AI modellerini yerel veya bulutta geliştirip test ederek kolayca AI uygulamaları oluşturabilir. Uzantı, günümüzde mevcut olan çoğu büyük üretken modeli destekler.

*Not*: AI Toolkit şu anda Python ve TypeScript’i desteklemektedir.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- AI Toolkit üzerinden bir MCP sunucusunu kullanmak.
- MCP sunucusunun sağladığı araçları keşfetmek ve kullanmak için bir ajan yapılandırması oluşturmak.
- Doğal dil aracılığıyla MCP araçlarını kullanmak.

## Yaklaşım

Yüksek seviyede nasıl ilerleyeceğimiz:

- Bir ajan oluşturup sistem komutunu tanımlamak.
- Hesap makinesi araçlarına sahip bir MCP sunucusu oluşturmak.
- Agent Builder’ı MCP sunucusuna bağlamak.
- Ajanın doğal dil ile araç çağrısını test etmek.

Harika, akışı anladığımıza göre, MCP aracılığıyla dış araçları kullanacak şekilde bir AI ajanı yapılandıralım ve yeteneklerini geliştirelim!

## Ön Koşullar

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code için AI Toolkit](https://aka.ms/AIToolkit)

## Alıştırma: Bir sunucuyu kullanma

Bu alıştırmada, AI Toolkit kullanarak Visual Studio Code içinde bir MCP sunucusundan araçlar alan, çalışan ve geliştiren bir AI ajanı oluşturacaksınız.

### -0- Ön adım, OpenAI GPT-4o modelini My Models’e ekleyin

Alıştırma, **GPT-4o** modelini kullanır. Ajanı oluşturmadan önce modelin **My Models** listesine eklenmiş olması gerekir.

![Visual Studio Code AI Toolkit uzantısında model seçimi arayüzü ekran görüntüsü. Başlık “AI Çözümünüz için doğru modeli bulun” ve alt başlık AI modellerini keşfetme, test etme ve dağıtma çağrısı içeriyor. “Popüler Modeller” altında altı model kartı var: DeepSeek-R1 (GitHub barındırmalı), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Küçük, Hızlı) ve DeepSeek-R1 (Ollama barındırmalı). Her kartta “Ekle” ve “Oyun Alanında Deneyin” seçenekleri var.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.tr.png)

1. **Activity Bar**’dan **AI Toolkit** uzantısını açın.
1. **Catalog** bölümünde **Models**’i seçin; bu, **Model Catalog**’u yeni bir editör sekmesinde açar.
1. **Model Catalog** arama çubuğuna **OpenAI GPT-4o** yazın.
1. Modeli **My Models** listenize eklemek için **+ Add** butonuna tıklayın. Modelin **GitHub tarafından barındırılan** olduğundan emin olun.
1. **Activity Bar**’da **OpenAI GPT-4o** modelinin listede göründüğünü kontrol edin.

### -1- Bir ajan oluşturun

**Agent (Prompt) Builder**, kendi AI destekli ajanlarınızı oluşturup özelleştirmenizi sağlar. Bu bölümde yeni bir ajan oluşturup, sohbeti güçlendirmek için bir model atayacaksınız.

![Visual Studio Code AI Toolkit uzantısında “Calculator Agent” yapılandırıcısı ekran görüntüsü. Sol panelde seçili model "OpenAI GPT-4o (via GitHub)". Sistem komutu “Üniversitede matematik dersi veren bir profesörsünüz.” Kullanıcı komutu “Fourier denklemini basitçe açıkla.” Araç ekleme, MCP Server etkinleştirme ve yapılandırılmış çıktı seçenekleri mevcut. Alt kısımda mavi “Çalıştır” butonu. Sağ panelde “Örneklerle Başlayın” başlığı altında Web Developer gibi üç örnek ajan listelenmiş, her biri kısa açıklamalarla.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.tr.png)

1. **Activity Bar**’dan **AI Toolkit** uzantısını açın.
1. **Tools** bölümünden **Agent (Prompt) Builder**’ı seçin; bu, yeni bir editör sekmesinde açılır.
1. **+ New Agent** butonuna tıklayın. Uzantı, **Command Palette** aracılığıyla bir kurulum sihirbazı başlatacak.
1. Ad olarak **Calculator Agent** girin ve **Enter** tuşuna basın.
1. **Agent (Prompt) Builder** içinde **Model** alanında **OpenAI GPT-4o (via GitHub)** modelini seçin.

### -2- Ajan için bir sistem komutu oluşturun

Ajan iskeleti hazır, şimdi kişiliğini ve amacını tanımlama zamanı. Bu bölümde, ajanınızın davranışını tanımlamak için **Generate system prompt** özelliğini kullanacak ve modelin sistem komutunu sizin için yazmasını sağlayacaksınız.

![Visual Studio Code AI Toolkit’te “Calculator Agent” arayüzü ekran görüntüsü. Açılan “Generate a prompt” penceresinde, basit ayrıntılar paylaşarak bir komut şablonu oluşturulabileceği belirtiliyor. Metin kutusunda örnek sistem komutu: “You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.” Altında “Kapat” ve “Oluştur” butonları var. Arka planda model ve sistem ile kullanıcı komutları görünmekte.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.tr.png)

1. **Prompts** bölümünde **Generate system prompt** butonuna tıklayın. Bu buton, AI kullanarak ajan için sistem komutu oluşturan komut oluşturucuyu açar.
1. **Generate a prompt** penceresine şu metni girin: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** butonuna tıklayın. Sağ alt köşede sistem komutunun oluşturulduğuna dair bir bildirim görünecek. Oluşturma tamamlandığında, komut **Agent (Prompt) Builder**’daki **System prompt** alanında görünecek.
1. **System prompt**u inceleyin ve gerekirse düzenleyin.

### -3- Bir MCP sunucusu oluşturun

Artık ajanınızın sistem komutunu belirlediniz—davranışını ve yanıtlarını yönlendiren—şimdi ajana pratik yetenekler kazandırma zamanı. Bu bölümde, toplama, çıkarma, çarpma ve bölme işlemlerini gerçekleştirecek araçlara sahip bir hesap makinesi MCP sunucusu oluşturacaksınız. Bu sunucu, ajanın doğal dil komutlarına gerçek zamanlı matematiksel yanıtlar vermesini sağlayacak.

![Visual Studio Code AI Toolkit uzantısında Calculator Agent arayüzünün alt bölümü ekran görüntüsü. “Tools” ve “Structure output” genişletilebilir menüleri, “Choose output format” açılır menüsü “text” olarak seçili. Sağda “+ MCP Server” butonu var. Araçlar bölümünün üstünde resim simgesi yer tutucu.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.tr.png)

AI Toolkit, kendi MCP sunucunuzu oluşturmayı kolaylaştıran şablonlarla donatılmıştır. Hesap makinesi MCP sunucusunu oluşturmak için Python şablonunu kullanacağız.

*Not*: AI Toolkit şu anda Python ve TypeScript’i desteklemektedir.

1. **Agent (Prompt) Builder**’daki **Tools** bölümünde **+ MCP Server** butonuna tıklayın. Uzantı, **Command Palette** üzerinden kurulum sihirbazını başlatacak.
1. **+ Add Server** seçeneğini seçin.
1. **Create a New MCP Server** seçeneğini seçin.
1. Şablon olarak **python-weather** seçin.
1. MCP sunucu şablonunu kaydetmek için **Default folder** seçin.
1. Sunucu için şu adı girin: **Calculator**
1. Yeni bir Visual Studio Code penceresi açılacak. **Yes, I trust the authors** seçeneğini seçin.
1. Terminali açın (**Terminal** > **New Terminal**) ve sanal ortam oluşturun: `python -m venv .venv`
1. Terminalde sanal ortamı aktif edin:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Terminalde bağımlılıkları yükleyin: `pip install -e .[dev]`
1. **Activity Bar**’daki **Explorer** görünümünde **src** klasörünü genişletin ve **server.py** dosyasını seçerek editörde açın.
1. **server.py** dosyasındaki kodu aşağıdaki ile değiştirin ve kaydedin:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- Hesap makinesi MCP sunucusu ile ajanı çalıştırın

Ajanınızın artık araçları var, kullanma zamanı! Bu bölümde, ajana komutlar göndererek ajanın hesap makinesi MCP sunucusundaki uygun aracı kullanıp kullanmadığını test edip doğrulayacaksınız.

![Visual Studio Code AI Toolkit uzantısında Calculator Agent arayüzü ekran görüntüsü. Sol panelde “Tools” altında local-server-calculator_server adlı bir MCP sunucusu eklenmiş, dört araç listelenmiş: add, subtract, multiply ve divide. Dört araç aktif olduğunu gösteren bir rozet var. Altında kapalı “Structure output” bölümü ve mavi “Run” butonu. Sağ panelde “Model Response” altında ajan, multiply ve subtract araçlarını sırasıyla {"a": 3, "b": 25} ve {"a": 75, "b": 20} girdileriyle çağırıyor. Son “Tool Response” 75.0 olarak görünüyor. Alt kısımda “View Code” butonu var.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.tr.png)

Hesap makinesi MCP sunucusunu yerel geliştirme makinenizde **Agent Builder** üzerinden MCP istemcisi olarak çalıştıracaksınız.

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` değerleri **subtract** aracı için atanmıştır.
    - Her aracın yanıtı ilgili **Tool Response** bölümünde verilir.
    - Modelin son çıktısı ise **Model Response** bölümünde sunulur.
1. Ajanı daha fazla test etmek için ek komutlar gönderin. Mevcut komutu **User prompt** alanına tıklayıp değiştirerek düzenleyebilirsiniz.
1. Testiniz bittiğinde, terminalden **CTRL/CMD+C** ile sunucuyu durdurabilirsiniz.

## Ödev

**server.py** dosyanıza ek bir araç eklemeyi deneyin (örneğin, bir sayının karekökünü döndüren bir fonksiyon). Ajanın yeni (veya mevcut) aracı kullanmasını gerektiren ek komutlar gönderin. Yeni araçların yüklenmesi için sunucuyu yeniden başlatmayı unutmayın.

## Çözüm

[Solution](./solution/README.md)

## Önemli Noktalar

Bu bölümden çıkarılacak ana noktalar:

- AI Toolkit uzantısı, MCP Sunucularını ve araçlarını kullanmanızı sağlayan harika bir istemcidir.
- MCP sunucularına yeni araçlar ekleyerek ajanın yeteneklerini gelişen ihtiyaçlara göre genişletebilirsiniz.
- AI Toolkit, özel araçlar oluşturmayı kolaylaştıran (örneğin, Python MCP sunucu şablonları gibi) şablonlar içerir.

## Ek Kaynaklar

- [AI Toolkit dokümanları](https://aka.ms/AIToolkit/doc)

## Sonraki Adım
- Sonraki: [Test & Hata Ayıklama](/03-GettingStarted/08-testing/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.