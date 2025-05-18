<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T12:59:17+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "ne"
}
-->
# बेसिक क्यालकुलेटर MCP सेवा

यो सेवा मोडल कन्टेक्स्ट प्रोटोकल (MCP) मार्फत बेसिक क्यालकुलेटर अपरेसनहरू प्रदान गर्छ। यो MCP कार्यान्वयनहरू सिक्दै गरेका नवशिक्षार्थीहरूको लागि एक साधारण उदाहरणको रूपमा डिजाइन गरिएको हो।

अधिक जानकारीको लागि [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) हेर्नुहोस्।

## विशेषताहरू

यो क्यालकुलेटर सेवाले निम्न क्षमताहरू प्रदान गर्दछ:

1. **बेसिक अंकगणितीय अपरेसनहरू**:
   - दुई संख्याको योग
   - एक संख्याबाट अर्को संख्या घटाउने
   - दुई संख्याको गुणन
   - एक संख्यालाई अर्को संख्याले भाग गर्ने (शून्य विभाजन जाँच सहित)

## `stdio` प्रकार प्रयोग गर्दै

## कन्फिगरेसन

1. **MCP सर्भरहरू कन्फिगर गर्नुहोस्**:
   - VS कोडमा आफ्नो कार्यक्षेत्र खोल्नुहोस्।
   - आफ्नो कार्यक्षेत्र फोल्डरमा `.vscode/mcp.json` फाइल सिर्जना गरेर MCP सर्भरहरू कन्फिगर गर्नुहोस्। उदाहरण कन्फिगरेसन:
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
   - बाटो आफ्नो प्रोजेक्टको बाटोमा प्रतिस्थापन गर्नुहोस्। बाटो पूर्ण हुनुपर्छ र कार्यक्षेत्र फोल्डरमा सापेक्षिक हुनु हुँदैन। (उदाहरण: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## सेवा प्रयोग गर्दै

सेवाले MCP प्रोटोकल मार्फत निम्न API अन्तर्क्रिया प्रदान गर्छ:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` आफ्नो Docker Hub प्रयोगकर्ता नामसँग:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. इमेज बनिसकेपछि, यसलाई Docker Hub मा अपलोड गरौं। निम्न आदेश चलाउनुहोस्:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Dockerized संस्करण प्रयोग गर्नुहोस्

1. `.vscode/mcp.json` फाइलमा, सर्भर कन्फिगरेसनलाई निम्न अनुसार प्रतिस्थापन गर्नुहोस्:
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
   कन्फिगरेसन हेर्दा, तपाईं देख्न सक्नुहुन्छ कि आदेश `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` हो, र पहिले जस्तै तपाईं क्यालकुलेटर सेवालाई केही गणित गर्न सोध्न सक्नुहुन्छ।

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको हो। हामी यथार्थताको लागि प्रयास गर्छौं, कृपया सचेत रहनुहोस् कि स्वचालित अनुवादहरूले त्रुटिहरू वा असत्यताहरू समावेश गर्न सक्छ। यसको मूल भाषामा रहेको मूल दस्तावेज़लाई आधिकारिक स्रोत मान्नुपर्छ। महत्त्वपूर्ण जानकारीको लागि, पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।