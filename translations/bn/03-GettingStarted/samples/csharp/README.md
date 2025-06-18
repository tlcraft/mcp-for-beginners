<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:53:36+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "bn"
}
-->
# বেসিক ক্যালকুলেটর MCP সার্ভিস

এই সার্ভিসটি Model Context Protocol (MCP) এর মাধ্যমে বেসিক ক্যালকুলেটর অপারেশন প্রদান করে। এটি MCP ইমপ্লিমেন্টেশন শেখার জন্য নতুনদের জন্য একটি সহজ উদাহরণ হিসেবে ডিজাইন করা হয়েছে।

অধিক তথ্যের জন্য দেখুন [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## বৈশিষ্ট্যসমূহ

এই ক্যালকুলেটর সার্ভিস নিম্নলিখিত ক্ষমতা প্রদান করে:

1. **বেসিক আরিথমেটিক অপারেশন**:
   - দুইটি সংখ্যার যোগ
   - এক সংখ্যা থেকে অন্য সংখ্যার বিয়োগ
   - দুইটি সংখ্যার গুণ
   - এক সংখ্যা দ্বারা অন্য সংখ্যার ভাগ (শূন্য দ্বারা ভাগের চেকসহ)

## `stdio` টাইপ ব্যবহার করা

## কনফিগারেশন

1. **MCP সার্ভার কনফিগার করুন**:
   - VS Code এ আপনার ওয়ার্কস্পেস খুলুন।
   - আপনার ওয়ার্কস্পেস ফোল্ডারে একটি `.vscode/mcp.json` ফাইল তৈরি করুন MCP সার্ভার কনফিগার করার জন্য। উদাহরণ কনফিগারেশন:

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

   - আপনাকে GitHub রিপোজিটরির রুট ইনপুট করতে বলা হবে, যা আপনি কমান্ড `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` থেকে পেতে পারেন (আপনার Docker Hub ইউজারনেম দিয়ে প্রতিস্থাপন করুন):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. ইমেজ তৈরি হওয়ার পর, এটি Docker Hub-এ আপলোড করুন। নিচের কমান্ডটি চালান:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Dockerized সংস্করণ ব্যবহার করা

1. `.vscode/mcp.json` ফাইলে সার্ভার কনফিগারেশন নিম্নরূপ প্রতিস্থাপন করুন:
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
   কনফিগারেশন দেখে আপনি বুঝতে পারবেন যে কমান্ডটি হলো `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, এবং আগের মতোই আপনি ক্যালকুলেটর সার্ভিসকে কিছু গণনা করতে বলতে পারেন।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা ভুল থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই সর্বোত্তম এবং প্রামাণিক উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।