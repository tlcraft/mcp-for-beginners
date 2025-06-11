<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:26:38+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "tr"
}
-->
# Calculator LLM Client

LangChain4j kullanarak GitHub Models entegrasyonlu bir MCP (Model Context Protocol) hesap makinesi servisine nasıl bağlanılacağını gösteren bir Java uygulaması.

## Gereksinimler

- Java 21 veya üzeri
- Maven 3.6+ (veya dahil edilen Maven wrapper'ı kullanabilirsiniz)
- GitHub Models erişimine sahip bir GitHub hesabı
- `http://localhost:8080` adresinde çalışan bir MCP hesap makinesi servisi

## GitHub Token'ını Alma

Bu uygulama GitHub Models kullanır ve GitHub kişisel erişim token’ı gerektirir. Token’ınızı almak için şu adımları izleyin:

### 1. GitHub Models'a Erişin
1. [GitHub Models](https://github.com/marketplace/models) adresine gidin  
2. GitHub hesabınızla giriş yapın  
3. Eğer daha önce erişim talep etmediyseniz, GitHub Models için erişim isteğinde bulunun  

### 2. Kişisel Erişim Token’ı Oluşturun
1. [GitHub Ayarları → Geliştirici ayarları → Kişisel erişim tokenları → Tokenlar (klasik)](https://github.com/settings/tokens) sayfasına gidin  
2. "Yeni token oluştur" → "Yeni token oluştur (klasik)" seçeneğine tıklayın  
3. Token’ınıza anlamlı bir isim verin (örneğin, "MCP Calculator Client")  
4. Gerekirse sona erme tarihini belirleyin  
5. Aşağıdaki izinleri seçin:  
   - `repo` (özel depolara erişim için)  
   - `user:email`  
6. "Token oluştur" butonuna tıklayın  
7. **Önemli**: Token’ı hemen kopyalayın - bir daha göremeyeceksiniz!

### 3. Ortam Değişkenini Ayarlayın

#### Windows (Komut İstemi) için:
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell) için:
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux için:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Kurulum ve Yükleme

1. **Projeyi klonlayın veya proje dizinine gidin**

2. **Bağımlılıkları yükleyin**:  
   ```cmd
   mvnw clean install
   ```  
   Ya da Maven global olarak yüklüyse:  
   ```cmd
   mvn clean install
   ```

3. **Ortam değişkenini ayarlayın** (yukarıdaki "GitHub Token’ını Alma" bölümüne bakın)

4. **MCP Calculator Servisini Başlatın**:  
   1. bölümdeki MCP hesap makinesi servisini `http://localhost:8080/sse` adresinde çalıştırdığınızdan emin olun. İstemciyi başlatmadan önce servis aktif olmalı.

## Uygulamayı Çalıştırma

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Uygulamanın Yaptıkları

Uygulama hesap makinesi servisiyle üç temel etkileşimi gösterir:

1. **Toplama**: 24.5 ile 17.3’ün toplamını hesaplar  
2. **Karekök**: 144’ün karekökünü hesaplar  
3. **Yardım**: Kullanılabilir hesap makinesi fonksiyonlarını gösterir  

## Beklenen Çıktı

Başarıyla çalıştığında, aşağıdakine benzer bir çıktı görmelisiniz:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Sorun Giderme

### Yaygın Sorunlar

1. **"GITHUB_TOKEN ortam değişkeni ayarlanmadı"**  
   - `GITHUB_TOKEN` ortam değişkenini doğru şekilde ayarladığınızdan emin olun  

### Hata Ayıklama

Hata ayıklama kayıtlarını etkinleştirmek için uygulamayı çalıştırırken aşağıdaki JVM argümanını ekleyin:  
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfigürasyon

Uygulama şu şekilde yapılandırılmıştır:  
- GitHub Models kullanır: `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`  
- İstekler için 60 saniyelik zaman aşımı  
- Hata ayıklama için istek/yanıt kayıtları etkin  

## Bağımlılıklar

Projede kullanılan önemli bağımlılıklar:  
- **LangChain4j**: Yapay zeka entegrasyonu ve araç yönetimi için  
- **LangChain4j MCP**: Model Context Protocol desteği için  
- **LangChain4j GitHub Models**: GitHub Models entegrasyonu için  
- **Spring Boot**: Uygulama çerçevesi ve bağımlılık yönetimi için  

## Lisans

Bu proje Apache Lisansı 2.0 altında lisanslanmıştır - detaylar için [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) dosyasına bakınız.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilindeki haliyle yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.