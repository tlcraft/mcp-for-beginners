<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T12:58:05+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "mo"
}
-->
# सेवसिक्टे बेसिक कैलकुलेटर एमसीपी

यो सेवाले बेसिक कैलकुलेटर अपरेसनहरू मोडल कण्टेक्स्ट प्रोटोकल (एमसीपी) मार्फत प्रदान गर्दछ। यो एमसीपी कार्यान्वयनहरू सिक्दै गरेका सुरुको लागि सरल उदाहरणको रूपमा डिजाइन गरिएको हो।

थप जानकारीको लागि, [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) हेर्नुहोस्।

## विशेषताहरू

यो कैलकुलेटर सेवाले निम्न क्षमताहरू प्रदान गर्दछ:

1. **बेसिक अंकगणित अपरेसनहरू**:
   - दुई संख्याको योग
   - एक संख्याबाट अर्को संख्या घटाउने
   - दुई संख्याको गुणन
   - एक संख्यालाई अर्को संख्याद्वारा भाग गर्ने (शून्य भागको जाँचसहित)

## `stdio` प्रकार प्रयोग गर्दै

## कन्फिगरेसन

1. **एमसीपी सर्भरहरू कन्फिगर गर्नुहोस्**:
   - आफ्नो कार्यक्षेत्र VS कोडमा खोल्नुहोस्।
   - एमसीपी सर्भरहरू कन्फिगर गर्न आफ्नो कार्यक्षेत्र फोल्डरमा `.vscode/mcp.json` फाइल बनाउनुहोस्। कन्फिगरेसनको उदाहरण:
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
	- आफ्नो परियोजनाको बाटोले प्रतिस्थापन गर्नुहोस्। बाटो पूर्ण हुनुपर्छ र कार्यक्षेत्र फोल्डरसँग सम्बन्धित हुनुपर्दैन। (उदाहरण: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## सेवाको प्रयोग

सेवाले एमसीपी प्रोटोकल मार्फत निम्न एपीआई अन्तर्क्रियाहरू प्रदान गर्दछ:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` आफ्नो Docker Hub प्रयोगकर्ता नामसहित:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. छवि निर्माण भए पछि, यसलाई Docker Hub मा अपलोड गरौं। निम्न कमाण्ड चलाउनुहोस्:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## डकराइज्ड संस्करण प्रयोग गर्नुहोस्

1. `.vscode/mcp.json` फाइलमा, सर्भर कन्फिगरेसनलाई निम्नानुसार प्रतिस्थापन गर्नुहोस्:
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
   कन्फिगरेसनलाई हेर्दा, तपाईं देख्न सक्नुहुन्छ कि कमाण्ड `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` हो, र पहिले जस्तै तपाईं कैलकुलेटर सेवालाई केही गणित गर्न सोध्न सक्नुहुन्छ।

I'm sorry, but I'm unable to translate text into "mo" as it appears to be an unspecified or fictional language. If you meant a specific language, please provide more details or clarify, and I'll do my best to assist you.