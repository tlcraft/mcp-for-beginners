<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T15:45:58+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tr"
}
-->
Önceki kodda şunları yaptık:

- Kütüphaneleri içe aktardık
- Bir client örneği oluşturduk ve stdio transportu ile bağladık.
- Prompts, kaynaklar ve araçları listeledik ve hepsini çağırdık.

İşte bu kadar, MCP Server ile iletişim kurabilen bir client.

Bir sonraki egzersiz bölümünde her kod parçasını tek tek inceleyip ne olduğunu açıklayalım, acele etmeyelim.

## Egzersiz: Bir client yazmak

Yukarıda söylediğimiz gibi, kodu açıklamak için zaman ayıralım ve isterseniz kodu birlikte yazabilirsiniz.

### -1- Kütüphaneleri içe aktarma

İhtiyacımız olan kütüphaneleri içe aktaralım, client ve seçtiğimiz transport protokolü olan stdio’ya referanslara ihtiyacımız olacak. stdio, yerel makinenizde çalışması amaçlanan şeyler için bir protokoldür. SSE ise gelecekteki bölümlerde göstereceğimiz başka bir transport protokolüdür ama şimdilik diğer seçeneğiniz o. Şimdilik stdio ile devam edelim.

### -2- Client ve transport örneği oluşturma

Transport ve client örneği oluşturmamız gerekecek:

### -3- Sunucu özelliklerini listeleme

Artık program çalıştırıldığında bağlanabilen bir client’ımız var. Ancak özelliklerini listelemiyor, bunu şimdi yapalım:

Harika, şimdi tüm özellikleri yakaladık. Peki, ne zaman kullanacağız? Bu client oldukça basit, yani özellikleri kullanmak istediğimizde açıkça çağırmamız gerekiyor. Bir sonraki bölümde kendi büyük dil modeline (LLM) erişimi olan daha gelişmiş bir client oluşturacağız. Şimdilik, sunucudaki özellikleri nasıl çağırabileceğimize bakalım:

### -4- Özellikleri çağırma

Özellikleri çağırmak için doğru argümanları ve bazı durumlarda çağırmak istediğimiz şeyin adını belirtmemiz gerekiyor.

### -5- Client’ı çalıştırma

Client’ı çalıştırmak için terminalde aşağıdaki komutu yazın:

## Ödev

Bu ödevde, öğrendiklerinizi kullanarak kendi client’ınızı oluşturacaksınız.

Kullanabileceğiniz bir sunucu burada, client kodunuzla çağırmanız gerekiyor; sunucuyu daha ilginç hale getirmek için daha fazla özellik ekleyip ekleyemeyeceğinize bakın.

## Çözüm

[Çözüm](./solution/README.md)

## Ana Noktalar

Bu bölümün ana noktaları client’lar hakkında şunlardır:

- Sunucudaki özellikleri keşfetmek ve çağırmak için kullanılabilirler.
- Kendi kendini başlatırken sunucuyu da başlatabilir (bu bölümde olduğu gibi) ancak client’lar çalışan sunuculara da bağlanabilir.
- Önceki bölümde anlatılan Inspector gibi alternatiflerin yanında sunucu yeteneklerini test etmek için harika bir yoldur.

## Ek Kaynaklar

- [MCP’de client oluşturma](https://modelcontextprotocol.io/quickstart/client)

## Örnekler

- [Java Hesap Makinesi](../samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python)

## Sonraki Adım

- Sonraki: [LLM ile client oluşturma](/03-GettingStarted/03-llm-client/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi ana dilindeki haliyle yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.