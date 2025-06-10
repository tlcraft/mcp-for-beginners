<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:26:59+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "bn"
}
-->
# Weather MCP Server

এটি একটি নমুনা MCP Server যা Python এ তৈরি করা হয়েছে এবং আবহাওয়া টুলস সহ মক রেসপন্স প্রদান করে। এটি আপনার নিজস্ব MCP Server তৈরি করার জন্য একটি ভিত্তি হিসেবে ব্যবহার করা যেতে পারে। এতে নিম্নলিখিত বৈশিষ্ট্যগুলো রয়েছে:

- **Weather Tool**: একটি টুল যা নির্দিষ্ট অবস্থানের ভিত্তিতে মক করা আবহাওয়ার তথ্য প্রদান করে।
- **Connect to Agent Builder**: একটি বৈশিষ্ট্য যা MCP সার্ভারকে Agent Builder এর সাথে সংযুক্ত করে পরীক্ষা ও ডিবাগিং করার সুযোগ দেয়।
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: MCP Inspector ব্যবহার করে MCP Server ডিবাগ করার সুবিধা।

## Weather MCP Server টেমপ্লেট দিয়ে শুরু করুন

> **প্রয়োজনীয়তা**
>
> আপনার লোকাল ডেভ মেশিনে MCP Server চালানোর জন্য আপনার প্রয়োজন হবে:
>
> - [Python](https://www.python.org/)
> - (*ঐচ্ছিক - যদি uv পছন্দ করেন*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## পরিবেশ প্রস্তুত করুন

এই প্রোজেক্টের জন্য পরিবেশ সেটআপ করার দুটি পদ্ধতি আছে। আপনি আপনার পছন্দ অনুসারে যেকোনো একটি বেছে নিতে পারেন।

> নোট: ভার্চুয়াল এনভায়রনমেন্ট তৈরি করার পর VSCode বা টার্মিনাল রিলোড করুন যাতে ভার্চুয়াল এনভায়রনমেন্টের পাইথন ব্যবহার হয়।

| পদ্ধতি | ধাপসমূহ |
| -------- | ----- |
| `uv` ব্যবহার করে | 1. ভার্চুয়াল এনভায়রনমেন্ট তৈরি করুন: `uv venv` <br>2. VSCode কমান্ড "***Python: Select Interpreter***" চালিয়ে তৈরি ভার্চুয়াল এনভায়রনমেন্ট থেকে পাইথন নির্বাচন করুন <br>3. ডিপেন্ডেন্সি ইনস্টল করুন (ডেভ ডিপেন্ডেন্সিসহ): `uv pip install -r pyproject.toml --extra dev` |
| `pip` ব্যবহার করে | 1. ভার্চুয়াল এনভায়রনমেন্ট তৈরি করুন: `python -m venv .venv` <br>2. VSCode কমান্ড "***Python: Select Interpreter***" চালিয়ে তৈরি ভার্চুয়াল এনভায়রনমেন্ট থেকে পাইথন নির্বাচন করুন<br>3. ডিপেন্ডেন্সি ইনস্টল করুন (ডেভ ডিপেন্ডেন্সিসহ): `pip install -e .[dev]` |

পরিবেশ সেটআপের পর, Agent Builder কে MCP Client হিসেবে ব্যবহার করে আপনার লোকাল ডেভ মেশিনে সার্ভার চালাতে পারেন:
1. VS Code এর Debug প্যানেল খুলুন। MCP সার্ভার ডিবাগ শুরু করতে `Debug in Agent Builder` নির্বাচন করুন অথবা `F5` চাপুন।
2. AI Toolkit Agent Builder ব্যবহার করে [এই প্রম্পট](../../../../../../../../../../../open_prompt_builder) দিয়ে সার্ভার পরীক্ষা করুন। সার্ভার স্বয়ংক্রিয়ভাবে Agent Builder এর সাথে সংযুক্ত হবে।
3. প্রম্পট দিয়ে সার্ভার পরীক্ষা করতে `Run` ক্লিক করুন।

**অভিনন্দন**! আপনি সফলভাবে Agent Builder এর মাধ্যমে MCP Client হিসেবে আপনার লোকাল ডেভ মেশিনে Weather MCP Server চালিয়েছেন।
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## টেমপ্লেটে কি কি রয়েছে

| ফোল্ডার / ফাইল | বিষয়বস্তু                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | ডিবাগিং এর জন্য VSCode ফাইলসমূহ                   |
| `.aitk`      | AI Toolkit এর জন্য কনফিগারেশন                     |
| `src`        | Weather MCP Server এর সোর্স কোড                    |

## Weather MCP Server কিভাবে ডিবাগ করবেন

> নোটস:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) একটি ভিজ্যুয়াল ডেভেলপার টুল MCP সার্ভার টেস্ট এবং ডিবাগ করার জন্য।
> - সব ডিবাগ মোডে ব্রেকপয়েন্ট সমর্থিত, তাই আপনি টুল ইমপ্লিমেন্টেশন কোডে ব্রেকপয়েন্ট যোগ করতে পারেন।

| ডিবাগ মোড | বর্ণনা | ডিবাগ করার ধাপসমূহ |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit এর মাধ্যমে Agent Builder এ MCP সার্ভার ডিবাগ করুন। | 1. VS Code Debug প্যানেল খুলুন। MCP সার্ভার ডিবাগ শুরু করতে `Debug in Agent Builder` নির্বাচন করুন এবং `F5` চাপুন।<br>2. AI Toolkit Agent Builder ব্যবহার করে [এই প্রম্পট](../../../../../../../../../../../open_prompt_builder) দিয়ে সার্ভার পরীক্ষা করুন। সার্ভার স্বয়ংক্রিয়ভাবে Agent Builder এর সাথে সংযুক্ত হবে।<br>3. প্রম্পট দিয়ে সার্ভার পরীক্ষা করতে `Run` ক্লিক করুন। |
| MCP Inspector | MCP Inspector ব্যবহার করে MCP সার্ভার ডিবাগ করুন। | 1. [Node.js](https://nodejs.org/) ইনস্টল করুন।<br>2. Inspector সেটআপ করুন: `cd inspector` && `npm install` <br>3. VS Code Debug প্যানেল খুলুন। `Debug SSE in Inspector (Edge)` অথবা `Debug SSE in Inspector (Chrome)` নির্বাচন করুন। F5 চাপুন ডিবাগ শুরু করতে।<br>4. MCP Inspector ব্রাউজারে লঞ্চ হলে, এই MCP সার্ভার সংযোগ করার জন্য `Connect` বোতামটি ক্লিক করুন।<br>5. এরপর আপনি `List Tools` করতে পারবেন, একটি টুল নির্বাচন করুন, প্যারামিটার ইনপুট দিন, এবং `Run Tool` করে আপনার সার্ভার কোড ডিবাগ করুন।<br> |

## ডিফল্ট পোর্ট এবং কাস্টমাইজেশন

| ডিবাগ মোড | পোর্টসমূহ | সংজ্ঞাসমূহ | কাস্টমাইজেশন | নোট |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | উপরের পোর্ট পরিবর্তনের জন্য [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) সম্পাদনা করুন। | প্রযোজ্য নয় |
| MCP Inspector | 3001 (সার্ভার); 5173 এবং 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | উপরের পোর্ট পরিবর্তনের জন্য [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) সম্পাদনা করুন। | প্রযোজ্য নয় |

## মতামত

এই টেমপ্লেট সম্পর্কে আপনার কোনো মতামত বা পরামর্শ থাকলে, অনুগ্রহ করে [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) তে একটি ইস্যু খুলুন।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা সঠিকতার জন্য চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ভুল বা অমিল থাকতে পারে তা দয়া করে মনে রাখবেন। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।