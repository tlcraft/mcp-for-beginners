<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:31:08+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "tr"
}
-->
Harika, bir sonraki adımımız olarak sunucudaki yetenekleri listeleyelim.

### -2 Sunucu yeteneklerini listeleme

Şimdi sunucuya bağlanacağız ve yeteneklerini isteyeceğiz:

### -3- Sunucu yeteneklerini LLM araçlarına dönüştürme

Sunucu yeteneklerini listeledikten sonraki adım, bunları LLM'nin anlayacağı bir formata dönüştürmektir. Bunu yaptıktan sonra, bu yetenekleri LLM'imize araçlar olarak sağlayabiliriz.

Harika, şimdi kullanıcı isteklerini işlemek için hazırız, o zaman ona geçelim.

### -4- Kullanıcı istemi isteğini işleme

Kodun bu kısmında, kullanıcı isteklerini işleyeceğiz.

Harika, başardınız!

## Ödev

Egzersizdeki kodu alarak sunucuyu birkaç araçla genişletin. Ardından egzersizde olduğu gibi bir LLM ile bir istemci oluşturun ve tüm sunucu araçlarınızın dinamik olarak çağrıldığından emin olmak için farklı istemlerle test edin. Bu şekilde bir istemci oluşturmak, son kullanıcının tam istemci komutları yerine istemleri kullanabilmesini ve herhangi bir MCP sunucusunun çağrıldığının farkında olmamasını sağlayarak harika bir kullanıcı deneyimi sunar.

## Çözüm

[Çözüm](/03-GettingStarted/03-llm-client/solution/README.md)

## Önemli Noktalar

- İstemcinize bir LLM eklemek, kullanıcıların MCP Sunucuları ile etkileşim kurmasının daha iyi bir yolunu sağlar.
- MCP Sunucu yanıtını LLM'nin anlayabileceği bir şeye dönüştürmeniz gerekir.

## Örnekler

- [Java Hesap Makinesi](../samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

## Sırada Ne Var

- Sonraki: [Visual Studio Code kullanarak sunucu tüketme](/03-GettingStarted/04-vscode/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı nedeniyle oluşabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.