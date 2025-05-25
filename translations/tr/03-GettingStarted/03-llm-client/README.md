<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:20:33+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "tr"
}
-->
# LLM ile bir istemci oluşturma

Şimdiye kadar, bir sunucu ve bir istemci nasıl oluşturulacağını gördünüz. İstemci, sunucunun araçlarını, kaynaklarını ve istemlerini listelemek için sunucuyu açıkça çağırabiliyordu. Ancak, bu çok pratik bir yaklaşım değil. Kullanıcınız ajanlık çağında yaşıyor ve bunu yapmak için istemleri kullanmayı ve bir LLM ile iletişim kurmayı bekliyor. Kullanıcınız için, yeteneklerinizi depolamak için MCP kullanıp kullanmadığınız önemli değil, ancak doğal dil kullanarak etkileşimde bulunmayı bekliyorlar. Peki bunu nasıl çözeriz? Çözüm, istemciye bir LLM eklemekle ilgilidir.

## Genel Bakış

Bu derste, istemcinize bir LLM eklemeye odaklanacağız ve bunun kullanıcı için nasıl daha iyi bir deneyim sağladığını göstereceğiz.

## Öğrenme Hedefleri

Bu dersin sonunda, şunları yapabileceksiniz:

- LLM ile bir istemci oluşturun.
- LLM kullanarak MCP sunucusuyla sorunsuz etkileşimde bulunun.
- İstemci tarafında daha iyi bir son kullanıcı deneyimi sağlayın.

## Yaklaşım

Uygulamamız gereken yaklaşımı anlamaya çalışalım. Bir LLM eklemek basit görünüyor, ancak bunu gerçekten yapacak mıyız?

İşte istemcinin sunucu ile nasıl etkileşimde bulunacağı:

1. Sunucu ile bağlantı kurun.

1. Yetenekleri, istemleri, kaynakları ve araçları listeleyin ve bunların şemasını kaydedin.

1. Bir LLM ekleyin ve kaydedilen yetenekleri ve şemalarını LLM'nin anlayabileceği bir formatta iletin.

1. Kullanıcı istemini, istemci tarafından listelenen araçlarla birlikte LLM'ye ileterek işleyin.

Harika, şimdi bunu üst düzeyde nasıl yapabileceğimizi anladık, aşağıdaki alıştırmada bunu deneyelim.

## Alıştırma: LLM ile bir istemci oluşturma

Bu alıştırmada, istemcimize bir LLM eklemeyi öğreneceğiz.

### -1- Sunucuya bağlanın

Önce istemcimizi oluşturalım:
Ekim 2023'e kadar olan veriler üzerinde eğitildiniz.

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çabalasak da, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için, profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından doğabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.