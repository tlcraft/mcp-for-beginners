<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:38:01+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tr"
}
-->
# Bir istemci oluşturma

İstemciler, kaynaklar, araçlar ve istemler talep etmek için doğrudan bir MCP Sunucusu ile iletişim kuran özel uygulamalar veya betiklerdir. Sunucu ile etkileşim için grafik arayüz sağlayan denetleyici aracını kullanmaktan farklı olarak, kendi istemcinizi yazmak programatik ve otomatik etkileşimler sağlar. Bu, geliştiricilerin MCP yeteneklerini kendi iş akışlarına entegre etmelerine, görevleri otomatikleştirmelerine ve belirli ihtiyaçlara yönelik özel çözümler oluşturmalarına olanak tanır.

## Genel Bakış

Bu ders, Model Context Protocol (MCP) ekosisteminde istemci kavramını tanıtır. Kendi istemcinizi nasıl yazacağınızı ve bir MCP Sunucusuna nasıl bağlanacağınızı öğreneceksiniz.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Bir istemcinin neler yapabileceğini anlayın.
- Kendi istemcinizi yazın.
- İstemciyi bir MCP sunucusuna bağlayın ve test edin, böylece sunucunun beklendiği gibi çalıştığından emin olun.

## Bir istemci yazarken neler gerekir?

Bir istemci yazmak için aşağıdakileri yapmanız gerekecek:

- **Doğru kütüphaneleri içe aktarın**. Daha önce kullandığınız kütüphaneyi kullanacaksınız, sadece farklı yapılarla.
- **Bir istemci oluşturun**. Bu, bir istemci örneği oluşturmayı ve seçilen taşıma yöntemine bağlamayı içerecektir.
- **Hangi kaynakları listeleyeceğinize karar verin**. MCP sunucunuz kaynaklar, araçlar ve istemlerle birlikte gelir, hangisini listeleyeceğinize karar vermeniz gerekir.
- **İstemciyi bir ana uygulamaya entegre edin**. Sunucunun yeteneklerini öğrendikten sonra, bunu ana uygulamanıza entegre etmelisiniz, böylece bir kullanıcı bir istem veya başka bir komut yazdığında, ilgili sunucu özelliği çağrılır.

Şimdi yüksek düzeyde ne yapacağımızı anladığımıza göre, bir sonraki örneğe bakalım.

### Bir örnek istemci

Bu örnek istemciye bakalım:
Ekim 2023'e kadar olan veriler üzerinde eğitildiniz.

Önceki kodda:

- Kütüphaneleri içe aktarıyoruz
- Bir istemci örneği oluşturuyoruz ve iletişim için stdio kullanarak bağlıyoruz.
- İstemleri, kaynakları ve araçları listeliyoruz ve hepsini çağırıyoruz.

İşte karşınızda, bir MCP Sunucusu ile konuşabilen bir istemci.

Bir sonraki alıştırma bölümünde kod parçacıklarını parçalayarak ne olduğunu açıklayalım.

## Alıştırma: Bir istemci yazma

Yukarıda belirtildiği gibi, kodu açıklamak için zaman ayıralım ve isterseniz kodu birlikte yazabilirsiniz.

### -1- Kütüphaneleri içe aktarma

İhtiyacımız olan kütüphaneleri içe aktaralım, bir istemciye ve seçtiğimiz taşıma protokolüne, stdio'ya referanslara ihtiyacımız olacak. stdio, yerel makinenizde çalışması amaçlanan şeyler için bir protokoldür. SSE, gelecekteki bölümlerde göstereceğimiz başka bir taşıma protokolüdür, ancak bu sizin diğer seçeneğiniz. Şimdilik, stdio ile devam edelim.

Hadi istemciyi oluşturmaya geçelim.

### -2- İstemci ve taşıma oluşturma

Taşıma ve istemcimizin bir örneğini oluşturmamız gerekecek:

### -3- Sunucu özelliklerini listeleme

Şimdi, program çalıştırıldığında bağlanabilen bir istemcimiz var. Ancak, aslında özelliklerini listelemiyor, bunu bir sonraki adımda yapalım:

Harika, şimdi tüm özellikleri yakaladık. Şimdi soru şu: onları ne zaman kullanacağız? Bu istemci oldukça basit, basit derken, özellikleri istediğimizde açıkça çağırmamız gerekecek. Bir sonraki bölümde, kendi büyük dil modeline, LLM'ye erişimi olan daha gelişmiş bir istemci oluşturacağız. Şimdilik, sunucudaki özellikleri nasıl çağırabileceğimizi görelim:

### -4- Özellikleri çağırma

Özellikleri çağırmak için doğru argümanları ve bazı durumlarda neyi çağırmaya çalıştığımızın adını belirtmemiz gerektiğinden emin olmalıyız.

### -5- İstemciyi çalıştırma

İstemciyi çalıştırmak için terminalde şu komutu yazın:

## Ödev

Bu ödevde, öğrendiklerinizi kullanarak kendi istemcinizi oluşturacaksınız.

İşte istemci kodunuz aracılığıyla çağırmanız gereken bir sunucu, sunucuya daha fazla özellik ekleyip daha ilginç hale getirip getiremeyeceğinizi görün.

## Çözüm

[Çözüm](./solution/README.md)

## Temel Çıkarımlar

Bu bölümde istemciler hakkında şu temel çıkarımlar vardır:

- Sunucuda özellikleri keşfetmek ve çağırmak için kullanılabilir.
- Kendisi başlarken bir sunucu başlatabilir (bu bölümde olduğu gibi), ancak istemciler çalışmakta olan sunuculara da bağlanabilir.
- Sunucu yeteneklerini denemek için, önceki bölümde açıklandığı gibi Denetleyici gibi alternatiflerin yanında harika bir yoldur.

## Ek Kaynaklar

- [MCP'de istemci oluşturma](https://modelcontextprotocol.io/quickstart/client)

## Örnekler

- [Java Hesap Makinesi](../samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python)

## Sıradaki Ne

- Sonraki: [Bir LLM ile istemci oluşturma](/03-GettingStarted/03-llm-client/README.md)

**Feragatname**:  
Bu belge, [Co-op Translator](https://github.com/Azure/co-op-translator) adlı yapay zeka çeviri hizmeti kullanılarak çevrilmiştir. Doğruluğu sağlamak için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Belgenin orijinal dilindeki hali yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından doğabilecek yanlış anlama veya yanlış yorumlamalardan sorumlu değiliz.