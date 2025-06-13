<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:45:09+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tr"
}
-->
Önceki kodda şunları yaptık:

- Kütüphaneleri içe aktardık
- Bir client örneği oluşturup stdio kullanarak bağlantı kurduk.
- Prompts, kaynaklar ve araçları listeledik ve hepsini çağırdık.

İşte bu kadar, MCP Server ile iletişim kurabilen bir client.

Bir sonraki alıştırma bölümünde her kod parçasını tek tek inceleyip ne olup bittiğini detaylıca açıklayacağız.

## Alıştırma: Bir client yazmak

Yukarıda söylediğimiz gibi, kodu açıklamak için zaman ayıralım ve isterseniz kodu beraber yazalım.

### -1- Kütüphaneleri içe aktarma

İhtiyacımız olan kütüphaneleri içe aktaralım, bir client ve seçtiğimiz taşıma protokolü olan stdio için referanslara ihtiyacımız olacak. stdio, yerel makinenizde çalışması amaçlanan şeyler için bir protokoldür. SSE başka bir taşıma protokolüdür, bunu ileriki bölümlerde göstereceğiz ama şimdilik stdio ile devam edelim.

---

Şimdi örneklemeye geçelim.

### -2- Client ve taşıma örneği oluşturma

Taşıma için ve client için birer örnek oluşturmanız gerekecek:

---

### -3- Sunucu özelliklerini listeleme

Artık programa çalıştırıldığında bağlanabilecek bir client'ımız var. Ancak özelliklerini henüz listelemiyor, şimdi bunu yapalım:

---

Harika, şimdi tüm özellikleri yakaladık. Peki, ne zaman kullanacağız? Bu client oldukça basit; özellikleri kullanmak istediğimizde açıkça çağırmamız gerekecek. Bir sonraki bölümde kendi büyük dil modeline (LLM) erişimi olan daha gelişmiş bir client oluşturacağız. Şimdilik, sunucudaki özellikleri nasıl çağırabileceğimize bakalım:

### -4- Özellikleri çağırma

Özellikleri çağırmak için doğru argümanları ve bazı durumlarda çağırmaya çalıştığımız şeyin adını belirtmemiz gerekiyor.

---

### -5- Client'ı çalıştırma

Client'ı çalıştırmak için terminalde aşağıdaki komutu yazın:

---

## Ödev

Bu ödevde, client oluşturma konusunda öğrendiklerinizi kullanarak kendi client'ınızı yazacaksınız.

İşte kullanabileceğiniz bir sunucu var; client kodunuz aracılığıyla çağırmanız gerekiyor. Sunucuyu daha ilginç hale getirmek için daha fazla özellik ekleyip ekleyemeyeceğinize bakın.

---

## Çözüm

[Çözüm](./solution/README.md)

## Önemli Noktalar

Bu bölümde client'lar hakkında akılda kalması gerekenler:

- Sunucudaki özellikleri keşfetmek ve çağırmak için kullanılabilir.
- Kendi kendini başlatırken (bu bölümde olduğu gibi) aynı zamanda çalışan sunuculara da bağlanabilir.
- Önceki bölümde anlatıldığı gibi Inspector gibi alternatiflerin yanında sunucu yeteneklerini test etmek için harika bir yoldur.

## Ek Kaynaklar

- [MCP'de client oluşturma](https://modelcontextprotocol.io/quickstart/client)

## Örnekler

- [Java Hesap Makinesi](../samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python)

## Sonraki Adım

- Sonraki: [LLM ile client oluşturma](/03-GettingStarted/03-llm-client/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek herhangi bir yanlış anlama veya yorum hatasından sorumlu değiliz.