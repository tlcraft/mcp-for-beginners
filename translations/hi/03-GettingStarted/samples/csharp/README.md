<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T12:58:37+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "hi"
}
-->
# बेसिक कैलकुलेटर MCP सेवा

यह सेवा मॉडल कॉन्टेक्स्ट प्रोटोकॉल (MCP) के माध्यम से बेसिक कैलकुलेटर ऑपरेशन्स प्रदान करती है। यह MCP इम्प्लीमेंटेशन के बारे में सीखने वाले शुरुआती लोगों के लिए एक सरल उदाहरण के रूप में डिज़ाइन की गई है।

अधिक जानकारी के लिए देखें [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## विशेषताएँ

यह कैलकुलेटर सेवा निम्नलिखित क्षमताएँ प्रदान करती है:

1. **बेसिक अंकगणितीय ऑपरेशन्स**:
   - दो संख्याओं का योग
   - एक संख्या को दूसरी संख्या से घटाना
   - दो संख्याओं का गुणन
   - एक संख्या को दूसरी संख्या से भाग देना (शून्य भाग की जांच के साथ)

## `stdio` प्रकार का उपयोग करना
  
## कॉन्फ़िगरेशन

1. **MCP सर्वर कॉन्फ़िगर करें**:
   - VS कोड में अपना वर्कस्पेस खोलें।
   - MCP सर्वर कॉन्फ़िगर करने के लिए अपने वर्कस्पेस फ़ोल्डर में एक `.vscode/mcp.json` फ़ाइल बनाएँ। उदाहरण कॉन्फ़िगरेशन:
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
	- पथ को अपने प्रोजेक्ट के पथ के साथ बदलें। पथ को पूर्ण होना चाहिए और वर्कस्पेस फ़ोल्डर के सापेक्ष नहीं होना चाहिए। (उदाहरण: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## सेवा का उपयोग करना

सेवा MCP प्रोटोकॉल के माध्यम से निम्नलिखित API एंडपॉइंट्स प्रदान करती है:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` अपने Docker Hub उपयोगकर्ता नाम के साथ):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. इमेज बनने के बाद, इसे Docker Hub पर अपलोड करें। निम्नलिखित कमांड चलाएँ:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## डॉकरीकृत संस्करण का उपयोग करें

1. `.vscode/mcp.json` फ़ाइल में, सर्वर कॉन्फ़िगरेशन को निम्नलिखित से बदलें:
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
   कॉन्फ़िगरेशन को देखकर, आप देख सकते हैं कि कमांड `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` है, और पहले की तरह आप कैलकुलेटर सेवा से कुछ गणित करने के लिए कह सकते हैं।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या गलतियाँ हो सकती हैं। इसकी मूल भाषा में मूल दस्तावेज़ को प्राधिकृत स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।