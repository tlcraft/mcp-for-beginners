<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-12T23:46:38+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "tr"
}
-->
Şimdi SSE hakkında biraz daha bilgi sahibi olduğumuza göre, bir SSE sunucusu oluşturalım.

## Alıştırma: Bir SSE Sunucusu Oluşturma

Sunucumuzu oluştururken iki şeyi akılda tutmamız gerekiyor:

- Bağlantı ve mesajlar için uç noktaları açmak üzere bir web sunucusu kullanmalıyız.
- Sunucumuzu, stdio kullanırken yaptığımız gibi araçlar, kaynaklar ve istemlerle normal şekilde inşa etmeliyiz.

### -1- Bir sunucu örneği oluşturma

Sunucumuzu oluşturmak için stdio ile aynı türleri kullanıyoruz. Ancak, taşıma için SSE'yi seçmemiz gerekiyor.

---

Gerekli rotaları ekleyelim.

### -2- Rotalar ekleme

Bağlantı ve gelen mesajları yönetecek rotaları ekleyelim:

---

Sunucuya yetenekler ekleyelim.

### -3- Sunucu yeteneklerini ekleme

Artık SSE'ye özgü her şeyi tanımladığımıza göre, araçlar, istemler ve kaynaklar gibi sunucu yeteneklerini ekleyelim.

---

Tam kodunuz şu şekilde olmalı:

---

Harika, SSE kullanan bir sunucumuz var, şimdi onu çalıştıralım.

## Alıştırma: Inspector ile Bir SSE Sunucusunu Hata Ayıklama

Inspector, önceki derste gördüğümüz harika bir araçtı [İlk sunucunuzu oluşturmak](/03-GettingStarted/01-first-server/README.md). Burada da Inspector'ü kullanabilir miyiz bakalım:

### -1- Inspectörü çalıştırmak

Inspectörü çalıştırmak için önce bir SSE sunucusunun çalışıyor olması gerekir, hadi bunu yapalım:

1. Sunucuyu çalıştırın

---

1. Inspectörü çalıştırın

    > ![NOTE]
    > Bu komutu, sunucunun çalıştığı terminal penceresinden farklı bir terminalde çalıştırın. Ayrıca, aşağıdaki komutu sunucunuzun çalıştığı URL'ye göre uyarlamanız gerektiğini unutmayın.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspectörü çalıştırmak tüm çalışma ortamlarında aynıdır. Sunucu başlatmak için bir yol ve komut vermek yerine, sunucunun çalıştığı URL'yi ve `/sse` rotasını belirttiğimize dikkat edin.

### -2- Aracı denemek

Sunucuya bağlanmak için açılır listeden SSE'yi seçin ve sunucunuzun çalıştığı URL alanını doldurun, örneğin http:localhost:4321/sse. Ardından "Connect" düğmesine tıklayın. Önceki gibi, araçları listeleyin, bir araç seçin ve giriş değerlerini sağlayın. Aşağıdaki gibi bir sonuç görmelisiniz:

![Inspector'da çalışan SSE Sunucusu](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.tr.png)

Harika, Inspector ile çalışabiliyorsunuz, şimdi Visual Studio Code ile nasıl çalışabileceğimize bakalım.

## Ödev

Sunucunuzu daha fazla yetenekle geliştirmeyi deneyin. Örneğin, bir API çağıran bir araç eklemek için [bu sayfaya](https://api.chucknorris.io/) bakabilirsiniz, sunucunun nasıl görünmesi gerektiğine siz karar verin. İyi eğlenceler :)

## Çözüm

[Çözüm](./solution/README.md) Çalışan kodla olası bir çözüm burada.

## Ana Noktalar

Bu bölümden çıkarılacak ana noktalar şunlardır:

- SSE, stdio'nun yanında desteklenen ikinci taşıma türüdür.
- SSE'yi desteklemek için gelen bağlantıları ve mesajları bir web çerçevesi kullanarak yönetmeniz gerekir.
- SSE sunucusunu tüketmek için Inspector ve Visual Studio Code'u stdio sunucularında olduğu gibi kullanabilirsiniz. Ancak stdio ve SSE arasında biraz fark vardır. SSE için sunucuyu ayrı başlatmanız ve ardından inspector aracınızı çalıştırmanız gerekir. Inspector aracı için ayrıca URL belirtmeniz gerekir.

## Örnekler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Sonraki Adım

- Sonraki: [MCP ile HTTP Akışı (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.