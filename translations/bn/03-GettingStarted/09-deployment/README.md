<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:28:20+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "bn"
}
-->
# MCP সার্ভার ডিপ্লয়মেন্ট

আপনার MCP সার্ভার ডিপ্লয় করলে অন্যরা আপনার টুলস এবং রিসোর্সগুলো আপনার লোকাল পরিবেশের বাইরে থেকে ব্যবহার করতে পারবে। স্কেলেবিলিটি, নির্ভরযোগ্যতা, এবং ব্যবস্থাপনার সহজতার উপর নির্ভর করে বিভিন্ন ডিপ্লয়মেন্ট স্ট্র্যাটেজি বিবেচনা করা যায়। নিচে আপনি MCP সার্ভারগুলো লোকালি, কন্টেইনারে, এবং ক্লাউডে ডিপ্লয় করার নির্দেশনা পাবেন।

## ওভারভিউ

এই লেসনে আপনি শিখবেন কিভাবে আপনার MCP Server অ্যাপ ডিপ্লয় করতে হয়।

## শেখার লক্ষ্যসমূহ

এই লেসন শেষ হলে, আপনি সক্ষম হবেন:

- বিভিন্ন ডিপ্লয়মেন্ট পদ্ধতি মূল্যায়ন করতে।
- আপনার অ্যাপ ডিপ্লয় করতে।

## লোকাল ডেভেলপমেন্ট এবং ডিপ্লয়মেন্ট

যদি আপনার সার্ভারটি ব্যবহারকারীর মেশিনে রান করার জন্য হয়, তাহলে নিচের ধাপগুলো অনুসরণ করতে পারেন:

1. **সার্ভার ডাউনলোড করুন**। যদি আপনি সার্ভারটি নিজে লিখে না থাকেন, তাহলে প্রথমে সেটি আপনার মেশিনে ডাউনলোড করুন।  
1. **সার্ভার প্রসেস শুরু করুন**: আপনার MCP সার্ভার অ্যাপ্লিকেশন চালু করুন।

SSE এর জন্য (stdio টাইপ সার্ভারের জন্য দরকার নেই)

1. **নেটওয়ার্কিং কনফিগার করুন**: নিশ্চিত করুন সার্ভারটি প্রত্যাশিত পোর্টে অ্যাক্সেসযোগ্য।  
1. **ক্লায়েন্ট কানেক্ট করুন**: লোকাল কানেকশন URL যেমন `http://localhost:3000` ব্যবহার করুন।

## ক্লাউড ডিপ্লয়মেন্ট

MCP সার্ভারগুলো বিভিন্ন ক্লাউড প্ল্যাটফর্মে ডিপ্লয় করা যেতে পারে:

- **Serverless Functions**: হালকা MCP সার্ভারগুলো serverless functions হিসেবে ডিপ্লয় করুন।  
- **Container Services**: Azure Container Apps, AWS ECS, অথবা Google Cloud Run এর মতো সার্ভিস ব্যবহার করুন।  
- **Kubernetes**: উচ্চ প্রাপ্যতার জন্য Kubernetes ক্লাস্টারে MCP সার্ভার ডিপ্লয় এবং ম্যানেজ করুন।

### উদাহরণ: Azure Container Apps

Azure Container Apps MCP সার্ভার ডিপ্লয়মেন্ট সাপোর্ট করে। এটি এখনও উন্নয়নের মধ্যে রয়েছে এবং বর্তমানে SSE সার্ভারগুলো সাপোর্ট করে।

কিভাবে করবেন:

1. একটি রিপো ক্লোন করুন:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. লোকালি রান করে পরীক্ষা করুন:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. লোকালি ট্রাই করার জন্য, *.vscode* ডিরেক্টরিতে একটি *mcp.json* ফাইল তৈরি করুন এবং নিচের কনটেন্ট যুক্ত করুন:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  SSE সার্ভার শুরু হওয়ার পর, JSON ফাইলে প্লে আইকনে ক্লিক করুন, আপনি দেখতে পাবেন সার্ভারের টুলগুলো GitHub Copilot দ্বারা সনাক্ত হচ্ছে, Tool আইকন দেখুন।

1. ডিপ্লয় করার জন্য, নিচের কমান্ড রান করুন:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

এইভাবে, আপনি লোকালি ডিপ্লয় করতে পারেন, এবং Azure এ ডিপ্লয় করতে পারেন এই ধাপগুলো অনুসরণ করে।

## অতিরিক্ত রিসোর্স

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)  
- [Azure Container Apps article](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)  
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)  


## পরবর্তী ধাপ

- পরবর্তী: [Practical Implementation](/04-PracticalImplementation/README.md)

**দায়িত্ববিমুক্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা সঠিকতার জন্য চেষ্টা করি, তবে দয়া করে জানুন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথি তার নিজস্ব ভাষায় কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদের ব্যবহারে যে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।