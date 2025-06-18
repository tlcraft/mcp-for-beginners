<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:54:10+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "mr"
}
-->
# बेसिक कॅल्क्युलेटर MCP सेवा

ही सेवा Model Context Protocol (MCP) द्वारे बेसिक कॅल्क्युलेटर ऑपरेशन्स प्रदान करते. ही सेवा MCP अंमलबजावणी शिकणाऱ्या नवशिक्यांसाठी एक सोपं उदाहरण म्हणून तयार करण्यात आली आहे.

अधिक माहितीसाठी, पहा [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## वैशिष्ट्ये

ही कॅल्क्युलेटर सेवा खालील क्षमता देते:

1. **मूलभूत अंकगणित ऑपरेशन्स**:
   - दोन संख्यांची बेरीज
   - एका संख्येतून दुसरी संख्या वजा करणे
   - दोन संख्यांची गुणाकार
   - एका संख्येचे दुसऱ्या संख्येने भागाकार (शून्याने भाग देण्याची तपासणी सह)

## `stdio` प्रकार वापरणे
  
## कॉन्फिगरेशन

1. **MCP सर्व्हर्स कॉन्फिगर करा**:
   - तुमचं वर्कस्पेस VS Code मध्ये उघडा.
   - तुमच्या वर्कस्पेस फोल्डरमध्ये MCP सर्व्हर्स कॉन्फिगर करण्यासाठी `.vscode/mcp.json` फाइल तयार करा. उदाहरण कॉन्फिगरेशन:

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

   - तुम्हाला GitHub रिपॉझिटरी रूट टाकायला सांगितलं जाईल, जे कमांड `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` वापरून मिळवता येऊ शकते (तुमच्या Docker Hub वापरकर्तानावासह):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. इमेज तयार झाल्यानंतर, ती Docker Hub वर अपलोड करूया. खालील कमांड चालवा:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Dockerized आवृत्ती वापरा

1. `.vscode/mcp.json` फाइलमध्ये, सर्व्हर कॉन्फिगरेशन खालीलप्रमाणे बदला:
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
   कॉन्फिगरेशन पाहता, कमांड `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` आहे, आणि अगदी पूर्वीप्रमाणे तुम्ही कॅल्क्युलेटर सेवेला गणिती गणना करण्यासाठी विचारू शकता.

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, परंतु कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाची माहिती असल्यास, व्यावसायिक मानवी अनुवाद करणे शिफारसीय आहे. या अनुवादाच्या वापरामुळे होणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.