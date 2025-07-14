<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:15:14+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tr"
}
-->
Önceki kodda şunları yaptık:

- Kütüphaneleri içe aktardık
- Bir client örneği oluşturduk ve stdio kullanarak bağlantı kurduk.
- Prompts, kaynaklar ve araçları listeledik ve hepsini çağırdık.

İşte bu kadar, MCP Server ile iletişim kurabilen bir client.

Şimdi bir sonraki alıştırma bölümünde her kod parçasını detaylıca inceleyip ne olup bittiğini açıklayalım.

## Alıştırma: Bir client yazmak

Yukarıda da belirtildiği gibi, kodu açıklamak için zaman ayıralım ve isterseniz kodu birlikte yazalım.

### -1- Kütüphaneleri içe aktarma

Gerekli kütüphaneleri içe aktaralım, bir client ve seçtiğimiz taşıma protokolü olan stdio için referanslara ihtiyacımız olacak. stdio, yerel makinenizde çalıştırılmak üzere tasarlanmış bir protokoldür. SSE ise başka bir taşıma protokolüdür ve ilerleyen bölümlerde göstereceğiz, ancak şu an için stdio ile devam edelim.

Şimdi örneklemeye geçelim.

### -2- Client ve taşıma örneği oluşturma

Taşıma ve client için birer örnek oluşturmamız gerekecek:

### -3- Sunucu özelliklerini listeleme

Artık program çalıştırıldığında bağlanabilen bir client'ımız var. Ancak, özelliklerini listelemiyor, bunu şimdi yapalım:

Harika, şimdi tüm özellikleri yakaladık. Peki, bunları ne zaman kullanacağız? Bu client oldukça basit, yani özellikleri kullanmak istediğimizde açıkça çağırmamız gerekiyor. Bir sonraki bölümde, kendi büyük dil modeline (LLM) erişimi olan daha gelişmiş bir client oluşturacağız. Şimdilik, sunucudaki özellikleri nasıl çağırabileceğimize bakalım:

### -4- Özellikleri çağırma

Özellikleri çağırmak için doğru argümanları ve bazı durumlarda çağırmak istediğimiz şeyin adını belirtmemiz gerekiyor.

### -5- Client'ı çalıştırma

Client'ı çalıştırmak için terminalde aşağıdaki komutu yazın:

## Ödev

Bu ödevde, öğrendiklerinizi kullanarak kendi client'ınızı oluşturacaksınız.

İşte kullanabileceğiniz bir sunucu, client kodunuz aracılığıyla çağırmanız gerekiyor. Sunucuyu daha ilginç hale getirmek için daha fazla özellik ekleyip ekleyemeyeceğinizi görün.

## Çözüm

[Çözüm](./solution/README.md)

## Önemli Noktalar

Bu bölümde client'lar hakkında önemli noktalar şunlardır:

- Sunucudaki özellikleri keşfetmek ve çağırmak için kullanılabilirler.
- Kendini başlatırken bir sunucuyu da başlatabilir (bu bölümde olduğu gibi), ancak client'lar çalışan sunuculara da bağlanabilir.
- Inspector gibi alternatiflerin yanında sunucu yeteneklerini test etmek için harika bir yoldur.

## Ek Kaynaklar

- [MCP'de client oluşturma](https://modelcontextprotocol.io/quickstart/client)

## Örnekler

- [Java Hesap Makinesi](../samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python)

## Sonraki Adım

- Sonraki: [LLM ile client oluşturma](../03-llm-client/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.