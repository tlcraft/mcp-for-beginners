<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:35:18+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "sl"
}
-->
# Calculator LLM Client

Java uygulaması, LangChain4j kullanarak MCP (Model Context Protocol) hesap makinesi servisine GitHub Models entegrasyonu ile nasıl bağlanılacağını gösterir.

## Ön Koşullar

- Java 21 veya üzeri
- Maven 3.6+ (veya dahil edilen Maven wrapper)
- GitHub Models erişimine sahip bir GitHub hesabı
- `http://localhost:8080` üzerinde çalışan bir MCP hesap makinesi servisi

## GitHub Token Alma

Bu uygulama, GitHub Models kullanır ve GitHub kişisel erişim token'ı gerektirir. Token'ınızı almak için şu adımları izleyin:

### 1. GitHub Models'a Erişim
1. [GitHub Models](https://github.com/marketplace/models) sayfasına gidin  
2. GitHub hesabınızla giriş yapın  
3. Henüz erişiminiz yoksa GitHub Models için erişim isteğinde bulunun  

### 2. Kişisel Erişim Token'ı Oluşturma
1. [GitHub Ayarları → Geliştirici ayarları → Kişisel erişim tokenları → Tokenlar (klasik)](https://github.com/settings/tokens) sayfasına gidin  
2. "Generate new token" → "Generate new token (classic)" seçeneğine tıklayın  
3. Token'a anlamlı bir isim verin (örneğin, "MCP Calculator Client")  
4. Süre sonunu ihtiyacınıza göre ayarlayın  
5. Aşağıdaki izinleri seçin:  
   - `repo` (özel depolara erişim için)  
   - `user:email`  
6. "Generate token" butonuna basın  
7. **Önemli**: Token'ı hemen kopyalayın - tekrar göremeyeceksiniz!

### 3. Ortam Değişkenini Ayarlama

#### Windows (Komut İstemi):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Kurulum ve Yükleme

1. **Projeyi klonlayın veya proje dizinine gidin**

2. **Bağımlılıkları yükleyin**:  
   ```cmd
   mvnw clean install
   ```  
   Ya da Maven global kuruluysa:  
   ```cmd
   mvn clean install
   ```

3. **Ortam değişkenini ayarlayın** ("GitHub Token Alma" bölümüne bakınız)

4. **MCP Calculator Servisini Başlatın**:  
   1. bölümdeki MCP hesap makinesi servisini `http://localhost:8080/sse` adresinde çalıştırdığınızdan emin olun. Bu servis çalışmadan istemciyi başlatmayın.

## Uygulamayı Çalıştırma

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Uygulamanın Yaptıkları

Uygulama, hesap makinesi servisiyle üç temel etkileşimi gösterir:

1. **Toplama**: 24.5 ile 17.3 sayılarının toplamını hesaplar  
2. **Karekök**: 144 sayısının karekökünü hesaplar  
3. **Yardım**: Kullanılabilir hesap makinesi fonksiyonlarını gösterir  

## Beklenen Çıktı

Başarıyla çalıştığında aşağıdakine benzer bir çıktı görmelisiniz:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Sorun Giderme

### Yaygın Sorunlar

1. **"GITHUB_TOKEN environment variable not set"**  
   - `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean` komutlarını doğru şekilde çalıştırdığınızdan emin olun  

### Hata Ayıklama

Hata ayıklama günlüklerini etkinleştirmek için çalıştırırken aşağıdaki JVM argümanını ekleyin:  
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfigürasyon

Uygulama şu şekilde yapılandırılmıştır:  
- GitHub Models `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse` kullanır  
- İstekler için 60 saniyelik zaman aşımı  
- Hata ayıklama için istek/yanıt günlüklemesi etkin  

## Bağımlılıklar

Projede kullanılan temel bağımlılıklar:  
- **LangChain4j**: AI entegrasyonu ve araç yönetimi için  
- **LangChain4j MCP**: Model Context Protocol desteği için  
- **LangChain4j GitHub Models**: GitHub Models entegrasyonu için  
- **Spring Boot**: Uygulama çatısı ve bağımlılık yönetimi için  

## Lisans

Bu proje Apache Lisansı 2.0 altında lisanslanmıştır - detaylar için [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) dosyasına bakınız.

**Opozorilo**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.