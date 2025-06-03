<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:38:20+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "tr"
}
-->
# Visual Studio Code için AI Toolkit uzantısından bir sunucu kullanma

Bir AI ajanı oluştururken, sadece akıllı yanıtlar üretmekle kalmaz, aynı zamanda ajanın harekete geçme yeteneğine sahip olması da önemlidir. İşte burada Model Context Protocol (MCP) devreye girer. MCP, ajanların dış araçlara ve hizmetlere tutarlı bir şekilde erişmesini kolaylaştırır. Bunu, ajanın gerçekten kullanabileceği bir araç kutusuna bağlanması gibi düşünebilirsiniz.

Diyelim ki bir ajanı hesap makinesi MCP sunucunuza bağladınız. Aniden, ajanın “47 çarpı 89 kaçtır?” gibi bir istem alarak matematik işlemleri yapabilir—mantığı kodlamaya ya da özel API'ler oluşturmaya gerek kalmaz.

## Genel Bakış

Bu ders, Visual Studio Code’daki [AI Toolkit](https://aka.ms/AIToolkit) uzantısıyla bir hesap makinesi MCP sunucusunu bir ajana nasıl bağlayacağınızı anlatıyor. Böylece ajanınız toplama, çıkarma, çarpma ve bölme gibi matematik işlemlerini doğal dil aracılığıyla yapabilir.

AI Toolkit, Visual Studio Code için güçlü bir uzantıdır ve ajan geliştirmeyi kolaylaştırır. AI mühendisleri, üretken AI modellerini yerel veya bulutta geliştirip test ederek AI uygulamaları oluşturabilir. Uzantı, günümüzde mevcut olan çoğu büyük üretken modeli destekler.

*Not*: AI Toolkit şu anda Python ve TypeScript’i desteklemektedir.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- AI Toolkit aracılığıyla bir MCP sunucusunu kullanmak.
- Ajan yapılandırmasını, MCP sunucusunun sağladığı araçları keşfetmek ve kullanmak için yapılandırmak.
- MCP araçlarını doğal dil kullanarak kullanmak.

## Yaklaşım

Yüksek seviyede şu adımları izlemeliyiz:

- Bir ajan oluşturup sistem istemini tanımlamak.
- Hesap makinesi araçlarına sahip bir MCP sunucusu oluşturmak.
- Agent Builder’ı MCP sunucusuna bağlamak.
- Ajanın araç çağrısını doğal dil ile test etmek.

Harika, akışı anladığımıza göre MCP aracılığıyla dış araçlardan yararlanacak bir AI ajanı yapılandıralım ve yeteneklerini geliştirelim!

## Gereksinimler

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Alıştırma: Bir sunucu kullanma

Bu alıştırmada, Visual Studio Code içinde AI Toolkit kullanarak bir MCP sunucusundan araçlar alan bir AI ajanı oluşturacak, çalıştıracak ve geliştireceksiniz.

### -0- Ön adım, OpenAI GPT-4o modelini My Models’a ekleyin

Alıştırma **GPT-4o** modelini kullanıyor. Ajanı oluşturmadan önce modelin **My Models** listesine eklenmiş olması gerekiyor.

![Visual Studio Code AI Toolkit uzantısında model seçimi arayüzünün ekran görüntüsü. Başlık: "Find the right model for your AI Solution" ve alt başlık kullanıcıları AI modellerini keşfetmeye, test etmeye ve dağıtmaya teşvik ediyor. “Popular Models” altında altı model kartı var: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) ve DeepSeek-R1 (Ollama-hosted). Her kartta “Add” ve “Try in Playground” seçenekleri bulunuyor.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.tr.png)

1. **Activity Bar**’dan **AI Toolkit** uzantısını açın.
1. **Catalog** bölümünde **Models**’ı seçin. Bu, **Model Catalog**’u yeni bir editör sekmesinde açar.
1. **Model Catalog** arama çubuğuna **OpenAI GPT-4o** yazın.
1. Modeli **My Models** listenize eklemek için **+ Add** butonuna tıklayın. Modelin **GitHub tarafından barındırılan** olduğundan emin olun.
1. **Activity Bar**’da **OpenAI GPT-4o** modelinin listede göründüğünü kontrol edin.

### -1- Bir ajan oluşturun

**Agent (Prompt) Builder** kendi AI destekli ajanlarınızı oluşturup özelleştirmenizi sağlar. Bu bölümde yeni bir ajan oluşturacak ve konuşmayı güçlendirmek için bir model atayacaksınız.

![Visual Studio Code AI Toolkit uzantısında "Calculator Agent" yapılandırıcısının ekran görüntüsü. Sol panelde seçili model "OpenAI GPT-4o (via GitHub)." Sistem istemi “You are a professor in university teaching math” ve kullanıcı istemi “Explain to me the Fourier equation in simple terms.” Araç ekleme, MCP Server’ı etkinleştirme ve yapılandırılmış çıktı seçenekleri butonları var. Alt kısımda mavi “Run” butonu. Sağ panelde örnek ajanlar listelenmiş: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter ile) ve işlev açıklamaları.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.tr.png)

1. **Activity Bar**’dan **AI Toolkit** uzantısını açın.
1. **Tools** bölümünde **Agent (Prompt) Builder**’ı seçin. Bu, yeni bir editör sekmesinde **Agent (Prompt) Builder**’ı açar.
1. **+ New Agent** butonuna tıklayın. Uzantı, **Command Palette** üzerinden bir kurulum sihirbazı başlatacak.
1. **Calculator Agent** adını girip **Enter** tuşuna basın.
1. **Agent (Prompt) Builder**’da **Model** alanından **OpenAI GPT-4o (via GitHub)** modelini seçin.

### -2- Ajan için bir sistem istemi oluşturun

Ajan hazırlandı, şimdi kişiliğini ve amacını tanımlama zamanı. Bu bölümde, ajanınızın davranışını (burada bir hesap makinesi ajanı) tanımlamak için **Generate system prompt** özelliğini kullanacak ve modelin sizin için sistem istemini yazmasını sağlayacaksınız.

![Visual Studio Code AI Toolkit’te "Calculator Agent" arayüzü, "Generate a prompt" başlıklı modal pencere açık. Modal, temel bilgileri paylaşarak bir istem şablonu oluşturulabileceğini açıklıyor. Metin kutusunda örnek sistem istemi: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Altında “Close” ve “Generate” butonları var. Arka planda model seçimi ve sistem ile kullanıcı istem alanları görünüyor.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.tr.png)

1. **Prompts** bölümünde **Generate system prompt** butonuna tıklayın. Bu buton, ajan için sistem istemi oluşturmak üzere AI kullanan istem oluşturucuyu açar.
1. **Generate a prompt** penceresine şu metni girin: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** butonuna tıklayın. Sağ alt köşede sistem isteminin oluşturulduğunu belirten bir bildirim çıkacak. İstem oluşturulduktan sonra, istem **Agent (Prompt) Builder** içindeki **System prompt** alanında görünecektir.
1. **System prompt**’u gözden geçirin ve gerekirse düzenleyin.

### -3- Bir MCP sunucusu oluşturun

Artık ajanın sistem istemini tanımladığınıza göre—davranışını ve yanıtlarını yönlendiren—ajanı pratik yeteneklerle donatma zamanı. Bu bölümde, toplama, çıkarma, çarpma ve bölme işlemlerini yapabilen araçlara sahip bir hesap makinesi MCP sunucusu oluşturacaksınız. Bu sunucu, ajanın doğal dil komutlarına gerçek zamanlı matematik işlemleriyle yanıt vermesini sağlayacak.

![Visual Studio Code AI Toolkit uzantısında Calculator Agent arayüzünün alt bölümü ekran görüntüsü. “Tools” ve “Structure output” açılır menüleri, “Choose output format” açılır menüsü “text” olarak ayarlanmış. Sağda “+ MCP Server” butonu, araçlar bölümünün üstünde bir resim simgesi yer alıyor.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.tr.png)

AI Toolkit, kendi MCP sunucunuzu oluşturmayı kolaylaştıran şablonlarla donatılmıştır. Hesap makinesi MCP sunucusunu oluşturmak için Python şablonunu kullanacağız.

*Not*: AI Toolkit şu anda Python ve TypeScript’i desteklemektedir.

1. **Agent (Prompt) Builder** içindeki **Tools** bölümünde **+ MCP Server** butonuna tıklayın. Uzantı, **Command Palette** üzerinden bir kurulum sihirbazı başlatacak.
1. **+ Add Server** seçeneğini seçin.
1. **Create a New MCP Server** seçeneğini seçin.
1. Şablon olarak **python-weather**’ı seçin.
1. MCP sunucu şablonunu kaydetmek için **Default folder**’ı seçin.
1. Sunucu için şu adı girin: **Calculator**
1. Yeni bir Visual Studio Code penceresi açılacak. **Yes, I trust the authors** seçeneğini seçin.
1. Terminalde (**Terminal** > **New Terminal**) sanal ortam oluşturun: `python -m venv .venv`
1. Terminalde sanal ortamı etkinleştirin:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Terminalde bağımlılıkları yükleyin: `pip install -e .[dev]`
1. **Activity Bar**’daki **Explorer** görünümünde **src** klasörünü genişletin ve **server.py** dosyasını açın.
1. **server.py** dosyasındaki kodu aşağıdakiyle değiştirin ve kaydedin:

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

### -4- Hesap makinesi MCP sunucusuyla ajanı çalıştırın

Ajanınız artık araçlara sahip, şimdi onları kullanma zamanı! Bu bölümde, ajana istemler göndererek hesap makinesi MCP sunucusundaki uygun aracı kullanıp kullanmadığını test edip doğrulayacaksınız.

![Visual Studio Code AI Toolkit uzantısında Calculator Agent arayüzü ekran görüntüsü. Sol panelde “Tools” altında local-server-calculator_server adlı bir MCP sunucusu eklenmiş, dört araç listelenmiş: add, subtract, multiply ve divide. Bir rozet dört aracın aktif olduğunu gösteriyor. Altında kapalı “Structure output” bölümü ve mavi “Run” butonu var. Sağ panelde “Model Response” altında ajan, multiply ve subtract araçlarını sırasıyla {"a": 3, "b": 25} ve {"a": 75, "b": 20} girdileriyle çağırıyor. Son “Tool Response” 75.0 olarak görünüyor. Alt kısımda “View Code” butonu var.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.tr.png)

Hesap makinesi MCP sunucusunu yerel geliştirme makinenizde **Agent Builder** aracılığıyla MCP istemcisi olarak çalıştıracaksınız.

1. `F5` tuşuna basın` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `3 adet, birim fiyatı 25 dolar olan ürün aldım ve ardından 20 dolarlık indirim kullandım. Ne kadar ödedim?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` değerleri **subtract** aracı için atanmıştır.
    - Her aracın yanıtı ilgili **Tool Response** bölümünde verilir.
    - Modelin nihai çıktısı **Model Response** bölümünde sunulur.
1. Ajanı daha fazla test etmek için ek istemler gönderin. Mevcut istemi **User prompt** alanına tıklayarak değiştirebilirsiniz.
1. Testi bitirdiğinizde, terminalden **CTRL/CMD+C** tuşlarına basarak sunucuyu durdurabilirsiniz.

## Ödev

**server.py** dosyanıza ek bir araç eklemeyi deneyin (örneğin, bir sayının karekökünü döndüren bir fonksiyon). Ajanın yeni aracınızı (veya mevcut araçları) kullanmasını gerektiren ek istemler gönderin. Yeni araçların yüklenmesi için sunucuyu yeniden başlatmayı unutmayın.

## Çözüm

[Solution](./solution/README.md)

## Önemli Noktalar

Bu bölümden çıkarılacak önemli noktalar şunlardır:

- AI Toolkit uzantısı, MCP Sunucularını ve araçlarını kullanmanızı sağlayan harika bir istemcidir.
- MCP sunucularına yeni araçlar ekleyerek ajanınızın yeteneklerini gelişen ihtiyaçlara göre genişletebilirsiniz.
- AI Toolkit, özel araçların oluşturulmasını kolaylaştıran Python MCP sunucu şablonları gibi şablonlar içerir.

## Ek Kaynaklar

- [AI Toolkit dokümanları](https://aka.ms/AIToolkit/doc)

## Sonraki Adım

Sonraki: [Ders 4 Pratik Uygulama](/04-PracticalImplementation/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı nedeniyle oluşabilecek yanlış anlamalar veya yanlış yorumlamalar için sorumluluk kabul edilmemektedir.