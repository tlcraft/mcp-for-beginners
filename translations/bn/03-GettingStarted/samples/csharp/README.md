<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T12:58:52+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "bn"
}
-->
# বেসিক ক্যালকুলেটর এমসিপি সার্ভিস

এই সার্ভিসটি মডেল কনটেক্সট প্রোটোকল (এমসিপি) এর মাধ্যমে বেসিক ক্যালকুলেটর অপারেশন প্রদান করে। এটি এমসিপি বাস্তবায়ন সম্পর্কে শিখতে আগ্রহী শিক্ষার্থীদের জন্য একটি সাধারণ উদাহরণ হিসেবে তৈরি করা হয়েছে।

আরও তথ্যের জন্য, দেখুন [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## বৈশিষ্ট্যসমূহ

এই ক্যালকুলেটর সার্ভিস নিম্নলিখিত ক্ষমতাসমূহ প্রদান করে:

1. **বেসিক অ্যারিথমেটিক অপারেশন**:
   - দুটি সংখ্যার যোগফল
   - একটি সংখ্যা থেকে অন্য একটি সংখ্যা বিয়োগ
   - দুটি সংখ্যার গুণফল
   - একটি সংখ্যা দ্বারা অন্য একটি সংখ্যা ভাগ (শূন্য দ্বারা ভাগ করার পরীক্ষা সহ)

## `stdio` টাইপ ব্যবহার করা হচ্ছে
  
## কনফিগারেশন

1. **এমসিপি সার্ভার কনফিগার করুন**:
   - আপনার ওয়ার্কস্পেসটি VS Code এ খুলুন।
   - আপনার ওয়ার্কস্পেস ফোল্ডারে একটি `.vscode/mcp.json` ফাইল তৈরি করুন এমসিপি সার্ভার কনফিগার করার জন্য। উদাহরণ কনফিগারেশন:
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
	- পথটি আপনার প্রকল্পের পথে প্রতিস্থাপন করুন। পথটি অবশ্যই সম্পূর্ণ হতে হবে এবং ওয়ার্কস্পেস ফোল্ডারের সাথে সম্পর্কিত হওয়া উচিত নয়। (উদাহরণ: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## সার্ভিস ব্যবহার করা

এই সার্ভিসটি এমসিপি প্রোটোকলের মাধ্যমে নিম্নলিখিত এপিআই এন্ডপয়েন্টগুলি উন্মুক্ত করে:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` আপনার ডকার হাব ব্যবহারকারীর নামের সাথে প্রতিস্থাপন করুন):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. ইমেজটি তৈরি হওয়ার পর, আসুন এটি ডকার হাবে আপলোড করি। নিম্নলিখিত কমান্ডটি চালান:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## ডকারাইজড ভার্সন ব্যবহার করুন

1. `.vscode/mcp.json` ফাইলে, সার্ভার কনফিগারেশনটি নিম্নলিখিত দ্বারা প্রতিস্থাপন করুন:
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
   কনফিগারেশনটি দেখে, আপনি দেখতে পাবেন যে কমান্ডটি `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, এবং আগের মতোই আপনি ক্যালকুলেটর সার্ভিসকে কিছু গণনা করতে বলতে পারেন।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ পরিষেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসম্ভব নির্ভুলতার জন্য চেষ্টা করি, তবে অনুগ্রহ করে সচেতন থাকুন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল ভাষায় থাকা নথিটি প্রামাণ্য উৎস হিসাবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদের ব্যবহার থেকে উদ্ভূত কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী থাকবো না।