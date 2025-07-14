<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:33:39+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "tr"
}
-->
# Visual Studio Code için AI Toolkit uzantısından bir sunucu kullanmak

Bir AI ajanı oluştururken, sadece akıllı yanıtlar üretmekle kalmaz, aynı zamanda ajanın harekete geçme yeteneğine sahip olması da önemlidir. İşte burada Model Context Protocol (MCP) devreye girer. MCP, ajanların dış araçlara ve hizmetlere tutarlı bir şekilde erişmesini kolaylaştırır. Bunu, ajanın gerçekten kullanabileceği bir araç kutusuna bağlanması gibi düşünebilirsiniz.

Diyelim ki bir ajanı hesap makinesi MCP sunucunuza bağladınız. Birdenbire, ajanın “47 çarpı 89 nedir?” gibi bir istem alarak matematik işlemleri yapabilmesi mümkün olur—mantığı kodlamak ya da özel API’ler oluşturmak gerekmez.

## Genel Bakış

Bu derste, Visual Studio Code’daki [AI Toolkit](https://aka.ms/AIToolkit) uzantısı ile bir hesap makinesi MCP sunucusunu bir ajana nasıl bağlayacağınızı öğreneceksiniz. Böylece ajanın toplama, çıkarma, çarpma ve bölme gibi matematik işlemlerini doğal dil yoluyla yapabilmesi sağlanacak.

AI Toolkit, Visual Studio Code için güçlü bir uzantıdır ve ajan geliştirmeyi kolaylaştırır. AI mühendisleri, üretken AI modellerini yerel ya da bulutta geliştirip test ederek AI uygulamaları oluşturabilir. Uzantı, günümüzde yaygın olarak kullanılan çoğu üretken modeli destekler.

*Not*: AI Toolkit şu anda Python ve TypeScript’i desteklemektedir.

## Öğrenme Hedefleri

Bu dersi tamamladıktan sonra şunları yapabileceksiniz:

- AI Toolkit aracılığıyla bir MCP sunucusunu kullanmak.
- Bir ajan yapılandırması oluşturarak MCP sunucusunun sağladığı araçları keşfetmesini ve kullanmasını sağlamak.
- MCP araçlarını doğal dil yoluyla kullanmak.

## Yaklaşım

Yüksek seviyede şu adımları izlemeliyiz:

- Bir ajan oluşturup sistem istemini tanımlamak.
- Hesap makinesi araçları içeren bir MCP sunucusu oluşturmak.
- Agent Builder’ı MCP sunucusuna bağlamak.
- Ajanın araç çağrısını doğal dil yoluyla test etmek.

Harika, akışı anladığımıza göre, MCP aracılığıyla dış araçları kullanacak şekilde bir AI ajanı yapılandıralım ve yeteneklerini geliştirelim!

## Ön Koşullar

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code için AI Toolkit](https://aka.ms/AIToolkit)

## Alıştırma: Bir sunucu kullanmak

Bu alıştırmada, Visual Studio Code içinde AI Toolkit kullanarak bir MCP sunucusundan araçlar alan, çalıştıran ve geliştiren bir AI ajanı oluşturacaksınız.

### -0- Ön adım, OpenAI GPT-4o modelini My Models’a ekleyin

Alıştırma, **GPT-4o** modelini kullanır. Ajanı oluşturmadan önce modelin **My Models** listesine eklenmiş olması gerekir.

![Visual Studio Code AI Toolkit uzantısında model seçimi arayüzünün ekran görüntüsü. Başlık “AI Çözümünüz için doğru modeli bulun” ve alt başlık AI modellerini keşfetme, test etme ve dağıtma çağrısı yapıyor. “Popüler Modeller” altında altı model kartı var: DeepSeek-R1 (GitHub barındırmalı), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Küçük, Hızlı) ve DeepSeek-R1 (Ollama barındırmalı). Her kartta “Ekle” ve “Playground’da Deneyin” seçenekleri bulunuyor.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.tr.png)

1. **Activity Bar**’dan **AI Toolkit** uzantısını açın.
1. **Catalog** bölümünde **Models** seçeneğini seçin. Bu, **Model Catalog**’u yeni bir editör sekmesinde açar.
1. **Model Catalog** arama çubuğuna **OpenAI GPT-4o** yazın.
1. Modeli **My Models** listenize eklemek için **+ Add** butonuna tıklayın. Modelin **GitHub tarafından barındırılan** olduğundan emin olun.
1. **Activity Bar**’da **OpenAI GPT-4o** modelinin listede göründüğünü doğrulayın.

### -1- Bir ajan oluşturun

**Agent (Prompt) Builder**, kendi AI destekli ajanlarınızı oluşturup özelleştirmenizi sağlar. Bu bölümde yeni bir ajan oluşturacak ve konuşmayı yönlendirmek için bir model atayacaksınız.

![Visual Studio Code AI Toolkit uzantısında "Calculator Agent" oluşturucu arayüzünün ekran görüntüsü. Sol panelde seçili model "OpenAI GPT-4o (via GitHub)". Sistem istemi “Üniversitede matematik öğreten bir profesörsünüz” diyor, kullanıcı istemi “Fourier denklemini basit terimlerle açıkla” şeklinde. Araç ekleme, MCP Server etkinleştirme ve yapılandırılmış çıktı seçenekleri var. Alt kısımda mavi “Run” butonu. Sağ panelde “Örneklerle Başlayın” altında Web Developer, Second-Grade Simplifier ve Dream Interpreter gibi örnek ajanlar listelenmiş.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.tr.png)

1. **Activity Bar**’dan **AI Toolkit** uzantısını açın.
1. **Tools** bölümünde **Agent (Prompt) Builder**’ı seçin. Bu, **Agent (Prompt) Builder**’ı yeni bir editör sekmesinde açar.
1. **+ New Agent** butonuna tıklayın. Uzantı, **Command Palette** üzerinden bir kurulum sihirbazı başlatacak.
1. Ajan adı olarak **Calculator Agent** yazın ve **Enter** tuşuna basın.
1. **Agent (Prompt) Builder** içinde **Model** alanında **OpenAI GPT-4o (via GitHub)** modelini seçin.

### -2- Ajan için bir sistem istemi oluşturun

Ajan iskeletini oluşturduğunuza göre, şimdi kişiliğini ve amacını tanımlama zamanı. Bu bölümde, ajanınızın davranışını tanımlamak için **Generate system prompt** özelliğini kullanacak ve modelin sizin için sistem istemini yazmasını sağlayacaksınız. Bu örnekte, bir hesap makinesi ajanı olacak.

![Visual Studio Code AI Toolkit’te "Calculator Agent" arayüzünün ekran görüntüsü. Açılan "Generate a prompt" başlıklı modal pencerede, temel bilgileri paylaşarak bir istem şablonu oluşturulabileceği açıklanıyor. Metin kutusunda örnek sistem istemi: “You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.” Altında “Close” ve “Generate” butonları var. Arka planda seçili model “OpenAI GPT-4o (via GitHub)” ve sistem ile kullanıcı istemi alanları görünüyor.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.tr.png)

1. **Prompts** bölümünde **Generate system prompt** butonuna tıklayın. Bu buton, ajan için sistem istemi oluşturmak üzere AI kullanan istem oluşturucuyu açar.
1. **Generate a prompt** penceresine şu metni girin: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** butonuna tıklayın. Sağ alt köşede sistem isteminin oluşturulduğuna dair bir bildirim görünecek. İstem oluşturma tamamlandığında, istem **Agent (Prompt) Builder** içindeki **System prompt** alanında belirecek.
1. **System prompt**’u gözden geçirin ve gerekirse düzenleyin.

### -3- Bir MCP sunucusu oluşturun

Ajanınızın sistem istemini tanımladığınıza göre—davranışını ve yanıtlarını yönlendiren—şimdi ajana pratik yetenekler kazandırma zamanı. Bu bölümde, toplama, çıkarma, çarpma ve bölme işlemlerini yapabilen araçlar içeren bir hesap makinesi MCP sunucusu oluşturacaksınız. Bu sunucu, ajanın doğal dil istemlerine gerçek zamanlı matematik işlemleri yapmasını sağlayacak.

![Visual Studio Code AI Toolkit uzantısında Calculator Agent arayüzünün alt kısmının ekran görüntüsü. “Tools” ve “Structure output” için açılır menüler, “Choose output format” açılır menüsü “text” olarak seçili. Sağda “+ MCP Server” butonu var. Araçlar bölümünün üstünde bir resim simgesi yer tutucu olarak görünüyor.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.tr.png)

AI Toolkit, kendi MCP sunucunuzu kolayca oluşturmanız için şablonlar sunar. Hesap makinesi MCP sunucusunu oluşturmak için Python şablonunu kullanacağız.

*Not*: AI Toolkit şu anda Python ve TypeScript’i desteklemektedir.

1. **Agent (Prompt) Builder** içindeki **Tools** bölümünde **+ MCP Server** butonuna tıklayın. Uzantı, **Command Palette** üzerinden bir kurulum sihirbazı başlatacak.
1. **+ Add Server** seçeneğini seçin.
1. **Create a New MCP Server** seçeneğini seçin.
1. Şablon olarak **python-weather**’ı seçin.
1. MCP sunucu şablonunu kaydetmek için **Default folder**’ı seçin.
1. Sunucu için şu adı girin: **Calculator**
1. Yeni bir Visual Studio Code penceresi açılacak. **Yes, I trust the authors** seçeneğini seçin.
1. Terminali açın (**Terminal** > **New Terminal**) ve sanal ortam oluşturun: `python -m venv .venv`
1. Terminalde sanal ortamı etkinleştirin:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Terminalde bağımlılıkları yükleyin: `pip install -e .[dev]`
1. **Activity Bar**’daki **Explorer** görünümünde **src** klasörünü genişletin ve **server.py** dosyasını açın.
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

Ajanınız artık araçlara sahip, şimdi onları kullanma zamanı! Bu bölümde, ajana istemler göndererek ajanın hesap makinesi MCP sunucusundaki uygun aracı kullanıp kullanmadığını test edeceksiniz.

![Visual Studio Code AI Toolkit uzantısında Calculator Agent arayüzünün ekran görüntüsü. Sol panelde “Tools” altında local-server-calculator_server adlı bir MCP sunucusu eklenmiş, dört araç listelenmiş: add, subtract, multiply ve divide. Bir rozet dört aracın aktif olduğunu gösteriyor. Altında kapalı “Structure output” bölümü ve mavi “Run” butonu var. Sağ panelde “Model Response” altında ajan multiply ve subtract araçlarını sırasıyla {"a": 3, "b": 25} ve {"a": 75, "b": 20} girdileriyle çağırıyor. Son “Tool Response” 75.0 olarak gösteriliyor. Alt kısımda “View Code” butonu var.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.tr.png)

Hesap makinesi MCP sunucusunu yerel geliştirme makinenizde **Agent Builder** aracılığıyla MCP istemcisi olarak çalıştıracaksınız.

1. MCP sunucusunu hata ayıklama modunda başlatmak için `F5` tuşuna basın. **Agent (Prompt) Builder** yeni bir editör sekmesinde açılacak. Sunucu durumu terminalde görünecek.
1. **Agent (Prompt) Builder** içindeki **User prompt** alanına şu istemi yazın: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Ajanın yanıtını oluşturmak için **Run** butonuna tıklayın.
1. Ajan çıktısını inceleyin. Model, ödediğiniz tutarın **$55** olduğunu sonuçlandırmalıdır.
1. İşleyişin özeti şöyle olmalı:
    - Ajan, hesaplamaya yardımcı olmak için **multiply** ve **subtract** araçlarını seçer.
    - **multiply** aracı için `a` ve `b` değerleri atanır.
    - **subtract** aracı için `a` ve `b` değerleri atanır.
    - Her aracın yanıtı ilgili **Tool Response** alanında verilir.
    - Modelin nihai çıktısı **Model Response** alanında gösterilir.
1. Ajanı daha fazla test etmek için ek istemler gönderin. Mevcut istemi değiştirmek için **User prompt** alanına tıklayıp yeni istemi yazabilirsiniz.
1. Testi tamamladıktan sonra, terminalde **CTRL/CMD+C** tuşlarına basarak sunucuyu durdurabilirsiniz.

## Ödev

**server.py** dosyanıza ek bir araç eklemeyi deneyin (örneğin: bir sayının karekökünü döndüren bir fonksiyon). Ajanın yeni aracınızı (veya mevcut araçları) kullanmasını gerektiren ek istemler gönderin. Yeni eklenen araçların yüklenmesi için sunucuyu yeniden başlatmayı unutmayın.

## Çözüm

[Çözüm](./solution/README.md)

## Önemli Noktalar

Bu bölümden çıkarılacak önemli noktalar şunlardır:

- AI Toolkit uzantısı, MCP Sunucularını ve araçlarını kullanmanızı sağlayan harika bir istemcidir.
- MCP sunucularına yeni araçlar ekleyerek ajanın yeteneklerini gelişen ihtiyaçlara göre genişletebilirsiniz.
- AI Toolkit, özel araçlar oluşturmayı kolaylaştıran şablonlar (örneğin Python MCP sunucu şablonları) içerir.

## Ek Kaynaklar

- [AI Toolkit dokümanları](https://aka.ms/AIToolkit/doc)

## Sonraki Adım
- Sonraki: [Test Etme ve Hata Ayıklama](../08-testing/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.