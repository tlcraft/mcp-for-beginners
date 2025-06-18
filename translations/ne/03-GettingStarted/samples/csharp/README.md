<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:54:47+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "ne"
}
-->
# Basic Calculator MCP सेवा

यो सेवा Model Context Protocol (MCP) मार्फत आधारभूत क्याल्कुलेटर अपरेसनहरू प्रदान गर्छ। यो MCP कार्यान्वयनहरू सिक्दै गरेका सुरुवातीहरूका लागि सरल उदाहरणको रूपमा डिजाइन गरिएको हो।

थप जानकारीको लागि, हेर्नुहोस् [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## विशेषताहरू

यस क्याल्कुलेटर सेवाले निम्न क्षमताहरू प्रदान गर्दछ:

1. **आधारभूत अंकगणितीय अपरेसनहरू**:
   - दुई संख्याको जोड
   - एउटा संख्या अर्कोबाट घटाउने
   - दुई संख्याको गुणा
   - एउटा संख्या अर्कोले भाग गर्ने (शून्यले भाग गर्ने जाँचसहित)

## `stdio` प्रकार प्रयोग गर्दै

## कन्फिगरेसन

1. **MCP सर्भरहरू कन्फिगर गर्नुहोस्**:
   - आफ्नो कार्यक्षेत्र VS Code मा खोल्नुहोस्।
   - आफ्नो कार्यक्षेत्र फोल्डरमा MCP सर्भरहरू कन्फिगर गर्न `.vscode/mcp.json` फाइल बनाउनुहोस्। कन्फिगरेसनको उदाहरण:

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

   - तपाईंसँग GitHub रिपोजिटरी रुट प्रविष्टि मागिनेछ, जुन कमाण्ड `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` बाट प्राप्त गर्न सकिन्छ (यहाँ आफ्नो Docker Hub प्रयोगकर्ता नाम राख्नुहोस्):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ```  
1. इमेज तयार भएपछि, यसलाई Docker Hub मा अपलोड गरौं। तलको कमाण्ड चलाउनुहोस्:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Dockerized संस्करण प्रयोग गर्नुहोस्

1. `.vscode/mcp.json` फाइलमा, सर्भर कन्फिगरेसनलाई तलकोसँग प्रतिस्थापन गर्नुहोस्:
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
   कन्फिगरेसन हेर्दा, कमाण्ड `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` छ, र पहिलेझैं तपाईं क्याल्कुलेटर सेवालाई गणित गराउन अनुरोध गर्न सक्नुहुन्छ।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) को प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा गलतफहमी हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै आधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।