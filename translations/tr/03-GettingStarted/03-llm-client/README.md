<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-04T17:19:15+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "tr"
}
-->
Harika, bir sonraki adımımız olarak, sunucudaki yetenekleri listeleyelim.

### -2 Sunucu yeteneklerini listele

Şimdi sunucuya bağlanacağız ve yeteneklerini isteyeceğiz:

### -3- Sunucu yeteneklerini LLM araçlarına dönüştür

Sunucu yeteneklerini listeledikten sonraki adım, bunları LLM'nin anlayacağı bir formata dönüştürmektir. Bunu yaptıktan sonra, bu yetenekleri LLM'mize araç olarak sağlayabiliriz.

Harika, şimdi kullanıcı isteklerini işlemek için hazırız, o halde buna geçelim.

### -4- Kullanıcı istemi isteğini işle

Kodun bu bölümünde kullanıcı isteklerini işleyeceğiz.

Harika, başardınız!

## Ödev

Egzersizdeki kodu alın ve sunucuyu birkaç araçla daha genişletin. Ardından, egzersizdeki gibi bir LLM ile bir istemci oluşturun ve farklı istemlerle test edin, böylece tüm sunucu araçlarınızın dinamik olarak çağrıldığından emin olun. Bu şekilde bir istemci oluşturmak, son kullanıcının tam istemci komutları yerine istemleri kullanabilmesini sağlar ve herhangi bir MCP sunucusunun çağrıldığından habersiz olur, böylece harika bir kullanıcı deneyimi sunar.

## Çözüm

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Temel Çıkarımlar

- İstemcinize bir LLM eklemek, kullanıcıların MCP Sunucularıyla daha iyi etkileşim kurmasını sağlar.
- MCP Sunucu yanıtını, LLM'nin anlayabileceği bir şeye dönüştürmeniz gerekir.

## Örnekler

- [Java Hesap Makinesi](../samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

## Sonraki Adım

- Sonraki: [Visual Studio Code kullanarak bir sunucuyu tüketmek](../04-vscode/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi ana dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.