<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T12:59:07+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "mr"
}
-->
# बेसिक कॅल्क्युलेटर MCP सेवा

ही सेवा मॉडेल कॉन्टेक्स्ट प्रोटोकॉल (MCP) द्वारे बेसिक कॅल्क्युलेटर ऑपरेशन्स प्रदान करते. MCP अंमलबजावणी शिकणाऱ्या नवशिक्यांसाठी हे एक सोपे उदाहरण म्हणून डिझाइन केले आहे.

अधिक माहितीसाठी, [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) पहा.

## वैशिष्ट्ये

या कॅल्क्युलेटर सेवेमध्ये खालील क्षमता आहेत:

1. **मूलभूत अंकगणितीय ऑपरेशन्स**:
   - दोन संख्यांची बेरीज
   - एका संख्येचा दुसऱ्या संख्येतून वजाबाकी
   - दोन संख्यांचा गुणाकार
   - एका संख्येचा दुसऱ्या संख्येने भागाकार (शून्य विभागणी तपासणीसह)

## `stdio` प्रकार वापरणे

## कॉन्फिगरेशन

1. **MCP सर्व्हर्स कॉन्फिगर करा**:
   - VS Code मध्ये आपले कार्यक्षेत्र उघडा.
   - MCP सर्व्हर्स कॉन्फिगर करण्यासाठी आपल्या कार्यक्षेत्र फोल्डरमध्ये `.vscode/mcp.json` फाइल तयार करा. उदाहरण कॉन्फिगरेशन:
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
   - मार्ग आपल्या प्रोजेक्टच्या मार्गाने बदला. मार्ग पूर्ण असावा आणि कार्यक्षेत्र फोल्डरच्या तुलनेत सापेक्ष नसावा. (उदाहरण: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## सेवा वापरणे

सेवा MCP प्रोटोकॉलद्वारे खालील API एन्डपॉइंट्स उघडते:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` आपल्या Docker Hub वापरकर्तानावासह):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. प्रतिमा तयार झाल्यानंतर, चला ती Docker Hub वर अपलोड करूया. खालील आदेश चालवा:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## डॉकरीकृत आवृत्ती वापरा

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
   कॉन्फिगरेशन पाहून, आपण पाहू शकता की आदेश `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` आहे, आणि अगदी पूर्वीप्रमाणे आपण कॅल्क्युलेटर सेवेला काही गणित करण्यासाठी विचारू शकता.

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात ठेवा की स्वयंचलित भाषांतरात त्रुटी किंवा अपूर्णता असू शकते. मूळ भाषेतील दस्तऐवज हा प्रामाणिक स्रोत म्हणून विचारात घ्यावा. गंभीर माहिती साठी, व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थाबद्दल आम्ही जबाबदार नाही.