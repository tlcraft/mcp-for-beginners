<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:58:35+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "tr"
}
-->
# Temel Hesap Makinesi MCP Servisi

Bu servis, Model Context Protocol (MCP) üzerinden temel hesap makinesi işlemleri sağlar. MCP uygulamalarını öğrenen yeni başlayanlar için basit bir örnek olarak tasarlanmıştır.

Daha fazla bilgi için bkz. [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Özellikler

Bu hesap makinesi servisi aşağıdaki özellikleri sunar:

1. **Temel Aritmetik İşlemler**:
   - İki sayının toplanması
   - Bir sayının diğerinden çıkarılması
   - İki sayının çarpılması
   - Bir sayının diğerine bölünmesi (sıfıra bölme kontrolü ile)

## `stdio` Türünü Kullanma

## Yapılandırma

1. **MCP Sunucularını Yapılandırma**:
   - Çalışma alanınızı VS Code’da açın.
   - MCP sunucularını yapılandırmak için çalışma alanı klasörünüzde `.vscode/mcp.json` dosyası oluşturun. Örnek yapılandırma:

     ```jsonc
     {
       "inputs": [
         {
           "type": "promptString",
           "id": "repository-root",
           "description": "The absolute path to the repository root"
         }
       ],
       "servers": {
         "calculator-mcp-dotnet": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
             "run",
             "--project",
             "${input:repository-root}/03-GettingStarted/samples/csharp/src/calculator.csproj"
           ]
         }
       }
     }
     ```

   - GitHub depo kökünü girmeniz istenecek, bu değeri `git rev-parse --show-toplevel` komutuyla alabilirsiniz.  
     ``.

## Using the Service

The service exposes the following API endpoints through the MCP protocol:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` ifadesindeki `<YOUR-DOCKER-USERNAME>` kısmını Docker Hub kullanıcı adınızla değiştirin:  
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 

1. İmaj oluşturulduktan sonra, bunu Docker Hub’a yükleyelim. Aşağıdaki komutu çalıştırın:  
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Dockerize Edilmiş Versiyonu Kullanma

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
   Yapılandırmaya baktığınızda, komutun `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `` olduğunu görebilirsiniz ve tıpkı öncekiler gibi hesap makinesi servisine matematik işlemleri yaptırabilirsiniz.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek herhangi bir yanlış anlama veya yorumlama nedeniyle sorumluluk kabul edilmemektedir.