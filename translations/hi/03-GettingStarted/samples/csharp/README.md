<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:53:00+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "hi"
}
-->
# Basic Calculator MCP सेवा

यह सेवा Model Context Protocol (MCP) के माध्यम से बुनियादी कैलकुलेटर ऑपरेशन्स प्रदान करती है। इसे MCP इम्प्लीमेंटेशन सीखने वाले शुरुआती लोगों के लिए एक सरल उदाहरण के रूप में डिजाइन किया गया है।

अधिक जानकारी के लिए देखें [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## विशेषताएँ

यह कैलकुलेटर सेवा निम्नलिखित क्षमताएँ प्रदान करती है:

1. **बुनियादी अंकगणितीय ऑपरेशन्स**:
   - दो संख्याओं का जोड़
   - एक संख्या से दूसरी संख्या को घटाना
   - दो संख्याओं का गुणा
   - एक संख्या को दूसरी संख्या से भाग देना (शून्य से भाग देने की जांच के साथ)

## `stdio` प्रकार का उपयोग करना

## कॉन्फ़िगरेशन

1. **MCP सर्वरों को कॉन्फ़िगर करें**:
   - अपने वर्कस्पेस को VS Code में खोलें।
   - अपने वर्कस्पेस फ़ोल्डर में एक `.vscode/mcp.json` फ़ाइल बनाएं ताकि MCP सर्वरों को कॉन्फ़िगर किया जा सके। उदाहरण कॉन्फ़िगरेशन:

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

   - आपसे GitHub रिपॉजिटरी रूट दर्ज करने को कहा जाएगा, जिसे आप कमांड `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` से प्राप्त कर सकते हैं (यहाँ `<YOUR-DOCKER-USERNAME>` को अपने Docker Hub यूजरनेम से बदलें):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
2. इमेज बनने के बाद, इसे Docker Hub पर अपलोड करें। इसके लिए निम्न कमांड चलाएं:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Docker संस्करण का उपयोग करें

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
   कॉन्फ़िगरेशन को देखकर आप देख सकते हैं कि कमांड `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` है, और पहले की तरह आप कैलकुलेटर सेवा से गणना करवाने के लिए कह सकते हैं।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।