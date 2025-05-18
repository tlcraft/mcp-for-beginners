<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T13:00:18+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "tr"
}
-->
# Temel Hesap Makinesi MCP Hizmeti

Bu hizmet, Model Context Protocol (MCP) aracılığıyla temel hesap makinesi işlemleri sağlar. MCP uygulamaları hakkında öğrenen yeni başlayanlar için basit bir örnek olarak tasarlanmıştır.

Daha fazla bilgi için [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) adresine bakın.

## Özellikler

Bu hesap makinesi hizmeti aşağıdaki yetenekleri sunar:

1. **Temel Aritmetik İşlemler**:
   - İki sayının toplaması
   - Bir sayıdan diğerinin çıkarılması
   - İki sayının çarpılması
   - Bir sayının diğerine bölünmesi (sıfıra bölme kontrolü ile)

## `stdio` Türünü Kullanma
  
## Yapılandırma

1. **MCP Sunucularını Yapılandırma**:
   - VS Code'da çalışma alanınızı açın.
   - MCP sunucularını yapılandırmak için çalışma alanı klasörünüzde bir `.vscode/mcp.json` dosyası oluşturun. Örnek yapılandırma:
     ```json
     {
       "servers": {
         "MyCalculator": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
                "run",
                "--project",
                "D:\\source\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj"
            ],
           "env": {}
         }
       }
     }
     ```
	- Yolu, projenizin yolu ile değiştirin. Yol, çalışma alanı klasörüne göre değil, mutlak olmalıdır. (Örnek: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Hizmeti Kullanma

Hizmet, MCP protokolü aracılığıyla aşağıdaki API uç noktalarını sunar:

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- isPrime(n): Check if a number is prime

## Test with Github Copilot Chat in VS Code

1. Try making a request to the service using the MCP protocol. For example, you can ask:
   - "Add 5 and 3"
   - "Subtract 10 from 4"
   - "Multiply 6 and 7"
   - "Divide 8 by 2"
   - "Does 37854 prime?"
   - "What are the 3 prime numbers before after 4242?"
2. To make sure it's using the tools add #MyCalculator to the prompt. For example:
   - "Add 5 and 3 #MyCalculator"
   - "Subtract 10 from 4 #MyCalculator


## Containerized Version

The previous soultion is great when you have the .NET SDK installed, and all the dependencies are in place. However, if you would like to share the solution or run it in a different environment, you can use the containerized version.

1. Start Docker and make sure it's running.
1. From a terminal, navigate in the folder `03-GettingStarted\samples\csharp\src` 
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` ile Docker Hub kullanıcı adınızı değiştirin):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Görüntü oluşturulduktan sonra, bunu Docker Hub'a yükleyelim. Aşağıdaki komutu çalıştırın:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Dockerlaştırılmış Versiyonu Kullanma

1. `.vscode/mcp.json` dosyasında, sunucu yapılandırmasını aşağıdaki ile değiştirin:
   ```json
    "mcp-calc": {
      "command": "docker",
      "args": [
        "run",
        "--rm",
        "-i",
        "<YOUR-DOCKER-USERNAME>/mcp-calc"
      ],
      "envFile": "",
      "env": {}
    }
   ```
   Yapılandırmaya bakarak, komutun `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` olduğunu görebilirsiniz ve daha önce olduğu gibi hesap makinesi hizmetinden sizin için bazı matematik işlemleri yapmasını isteyebilirsiniz.

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini unutmayın. Orijinal belgenin kendi dilinde olan hali yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalardan dolayı sorumluluk kabul etmiyoruz.