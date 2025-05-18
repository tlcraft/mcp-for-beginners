<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:21:42+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "tr"
}
-->
# Visual Studio Code için AI Toolkit uzantısından bir sunucu tüketmek

Bir AI ajanı oluştururken, sadece akıllı yanıtlar üretmekle kalmamalı, aynı zamanda ajanın eylem yapabilme yeteneğini de sağlamalısınız. İşte burada Model Context Protocol (MCP) devreye girer. MCP, ajanların harici araçlara ve hizmetlere tutarlı bir şekilde erişmesini kolaylaştırır. Ajanınızı gerçekten kullanabileceği bir alet çantasına bağlamak gibi düşünebilirsiniz.

Diyelim ki ajanınızı bir hesap makinesi MCP sunucusuna bağladınız. Aniden, ajanın "47 çarpı 89 nedir?" gibi bir istem aldığında matematik işlemleri yapabilir—mantığı sabitlemeye veya özel API'ler oluşturmaya gerek yok.

## Genel Bakış

Bu ders, Visual Studio Code'daki [AI Toolkit](https://aka.ms/AIToolkit) uzantısı ile bir hesap makinesi MCP sunucusunu bir ajana nasıl bağlayacağınızı ve ajanın toplama, çıkarma, çarpma ve bölme gibi matematik işlemlerini doğal dil aracılığıyla gerçekleştirmesini sağlar.

AI Toolkit, Visual Studio Code için güçlü bir uzantıdır ve ajan geliştirmeyi kolaylaştırır. AI Mühendisleri, generatif AI modelleri geliştirip test ederek—yerel veya bulutta—kolayca AI uygulamaları oluşturabilir. Uzantı, günümüzde mevcut olan en büyük generatif modellerin çoğunu destekler.

*Not*: AI Toolkit şu anda Python ve TypeScript'i desteklemektedir.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- AI Toolkit aracılığıyla bir MCP sunucusu tüketmek.
- MCP sunucusu tarafından sağlanan araçları keşfetmek ve kullanmak için bir ajan yapılandırması ayarlamak.
- MCP araçlarını doğal dil aracılığıyla kullanmak.

## Yaklaşım

Bunu yüksek seviyede nasıl ele almanız gerektiği aşağıda açıklanmıştır:

- Bir ajan oluşturun ve sistem istemini tanımlayın.
- Hesap makinesi araçları ile bir MCP sunucusu oluşturun.
- Agent Builder'ı MCP sunucusuna bağlayın.
- Ajanın araç çağrısını doğal dil aracılığıyla test edin.

Harika, şimdi akışı anladığımıza göre, MCP aracılığıyla harici araçlardan yararlanmak için bir AI ajanını yapılandırarak yeteneklerini artırmaya başlayalım!

## Ön Koşullar

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code için AI Toolkit](https://aka.ms/AIToolkit)

## Alıştırma: Bir sunucu tüketmek

Bu alıştırmada, Visual Studio Code içinde AI Toolkit kullanarak bir MCP sunucusundan araçlarla bir AI ajanı oluşturacak, çalıştıracak ve geliştireceksiniz.

### -0- Ön Adım, OpenAI GPT-4o modelini Modellerim'e ekleyin

Alıştırma **GPT-4o** modelinden yararlanır. Model, ajan oluşturmadan önce **Modellerim**'e eklenmelidir.

1. **AI Toolkit** uzantısını **Activity Bar**'dan açın.
1. **Katalog** bölümünde, **Modeller**'i seçerek **Model Kataloğu**'nu açın. **Modeller**'i seçmek, **Model Kataloğu**'nu yeni bir düzenleyici sekmesinde açar.
1. **Model Kataloğu** arama çubuğuna **OpenAI GPT-4o** girin.
1. Modeli **Modellerim** listesine eklemek için **+ Add**'a tıklayın. Modelin **GitHub tarafından barındırıldığını** seçtiğinizden emin olun.
1. **Activity Bar**'da, **OpenAI GPT-4o** modelinin listede göründüğünü doğrulayın.

### -1- Bir ajan oluşturun

**Agent (Prompt) Builder** kendi AI destekli ajanlarınızı oluşturmanıza ve özelleştirmenize olanak tanır. Bu bölümde, yeni bir ajan oluşturacak ve sohbeti güçlendirmek için bir model atayacaksınız.

1. **AI Toolkit** uzantısını **Activity Bar**'dan açın.
1. **Araçlar** bölümünde, **Agent (Prompt) Builder**'ı seçin. **Agent (Prompt) Builder**'ı seçmek, yeni bir düzenleyici sekmesinde **Agent (Prompt) Builder**'ı açar.
1. **+ New Builder** düğmesine tıklayın. Uzantı, **Komut Paleti** aracılığıyla bir kurulum sihirbazı başlatacaktır.
1. **Calculator Agent** adını girin ve **Enter**'a basın.
1. **Agent (Prompt) Builder**'da, **Model** alanı için **OpenAI GPT-4o (via GitHub)** modelini seçin.

### -2- Ajan için bir sistem istemi oluşturun

Ajanınızın iskeletini oluşturduktan sonra, kişiliğini ve amacını tanımlama zamanı. Bu bölümde, ajanın amaçlanan davranışını tanımlamak için **Sistem istemi oluştur** özelliğini kullanacaksınız—bu durumda, bir hesap makinesi ajanı—ve modelin sizin için sistem istemini yazmasını sağlayacaksınız.

1. **İstemler** bölümünde, **Sistem istemi oluştur** düğmesine tıklayın. Bu düğme, ajana bir sistem istemi oluşturmak için AI'dan yararlanan istem oluşturucuyu açar.
1. **Bir istem oluştur** penceresinde, şu bilgileri girin: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Oluştur** düğmesine tıklayın. Sistem isteminin oluşturulduğunu doğrulayan bir bildirim sağ alt köşede görünecektir. İstem oluşturma tamamlandığında, istem **Agent (Prompt) Builder**'ın **Sistem istemi** alanında görünecektir.
1. **Sistem istemi**'ni gözden geçirin ve gerekirse değiştirin.

### -3- Bir MCP sunucusu oluşturun

Artık ajanın sistem istemini tanımladığınıza göre—davranışını ve yanıtlarını yönlendiren—ajana pratik yetenekler kazandırma zamanı. Bu bölümde, toplama, çıkarma, çarpma ve bölme hesaplamalarını gerçekleştirecek araçlarla bir hesap makinesi MCP sunucusu oluşturacaksınız. Bu sunucu, ajanın doğal dil istemlerine yanıt olarak gerçek zamanlı matematik işlemleri yapmasını sağlayacaktır.

AI Toolkit, kendi MCP sunucunuzu kolaylıkla oluşturmanıza olanak tanıyan şablonlarla donatılmıştır. Hesap makinesi MCP sunucusunu oluşturmak için Python şablonunu kullanacağız.

*Not*: AI Toolkit şu anda Python ve TypeScript'i desteklemektedir.

1. **Agent (Prompt) Builder**'ın **Araçlar** bölümünde, **+ MCP Server** düğmesine tıklayın. Uzantı, **Komut Paleti** aracılığıyla bir kurulum sihirbazı başlatacaktır.
1. **+ Sunucu Ekle**'yi seçin.
1. **Yeni bir MCP Sunucusu oluştur**'u seçin.
1. **python-weather**'ı şablon olarak seçin.
1. MCP sunucu şablonunu kaydetmek için **Varsayılan klasör**'ü seçin.
1. Sunucu için şu adı girin: **Calculator**
1. Yeni bir Visual Studio Code penceresi açılacaktır. **Evet, yazarlara güveniyorum**'u seçin.
1. Terminali kullanarak (**Terminal** > **Yeni Terminal**), sanal bir ortam oluşturun: `python -m venv .venv`
1. Terminali kullanarak sanal ortamı etkinleştirin:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Terminali kullanarak bağımlılıkları yükleyin: `pip install -e .[dev]`
1. **Activity Bar**'ın **Explorer** görünümünde, **src** dizinini genişletin ve **server.py**'yi seçerek dosyayı düzenleyicide açın.
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

Artık ajanın araçları var, onları kullanma zamanı! Bu bölümde, ajanın hesap makinesi MCP sunucusundan uygun aracı kullanıp kullanmadığını test etmek ve doğrulamak için ajana istemler göndereceksiniz.

Hesap makinesi MCP sunucusunu yerel geliştirme makinenizde **Agent Builder** aracılığıyla MCP istemcisi olarak çalıştıracaksınız.

1. `F5` tuşuna basın ve **User prompt** alanına şu istemi girin: "3 adet $25 fiyatlı ürün aldım ve ardından $20 indirim kullandım. Ne kadar ödedim?"
    - Her araç için yanıt, ilgili **Araç Yanıtı**'nda sağlanır.
    - Modelden gelen nihai çıktı, nihai **Model Yanıtı**'nda sağlanır.
1. Ajanı daha fazla test etmek için ek istemler gönderin. **User prompt** alanındaki mevcut istemi değiştirerek alanın içine tıklayıp mevcut istemi değiştirerek düzenleyebilirsiniz.
1. Ajanı test etmeyi bitirdiğinizde, **terminal** aracılığıyla sunucuyu durdurmak için **CTRL/CMD+C** girerek çıkabilirsiniz.

## Ödev

**server.py** dosyanıza ek bir araç girişi eklemeyi deneyin (örneğin: bir sayının karekökünü döndürün). Ajanın yeni aracınızı (veya mevcut araçları) kullanmasını gerektirecek ek istemler gönderin. Yeni eklenen araçları yüklemek için sunucuyu yeniden başlatmayı unutmayın.

## Çözüm

[Çözüm](./solution/README.md)

## Anahtar Çıkarımlar

Bu bölümden çıkarımlar şunlardır:

- AI Toolkit uzantısı, MCP Sunucularını ve araçlarını tüketmenizi sağlayan harika bir istemcidir.
- MCP sunucularına yeni araçlar ekleyebilir, ajanın yeteneklerini gelişen gereksinimleri karşılamak için genişletebilirsiniz.
- AI Toolkit, özel araçlar oluşturmayı basitleştiren şablonlar (örneğin, Python MCP sunucu şablonları) içerir.

## Ek Kaynaklar

- [AI Toolkit belgeleri](https://aka.ms/AIToolkit/doc)

## Sıradaki Ne?

Sıradaki: [Ders 4 Pratik Uygulama](/04-PracticalImplementation/README.md)

**Feragatname**: 
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluğu sağlamak için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalardan dolayı sorumluluk kabul etmiyoruz.