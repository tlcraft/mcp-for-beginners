<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:06:31+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "bn"
}
-->
# Weather MCP Server

এটি Python এ একটি নমুনা MCP Server যা mock উত্তর সহ আবহাওয়া টুলস বাস্তবায়ন করে। এটি আপনার নিজস্ব MCP Server এর জন্য একটি কাঠামো হিসেবে ব্যবহার করা যেতে পারে। এতে নিম্নলিখিত বৈশিষ্ট্যগুলি অন্তর্ভুক্ত রয়েছে:

- **Weather Tool**: একটি টুল যা প্রদত্ত অবস্থানের উপর ভিত্তি করে mock আবহাওয়া তথ্য প্রদান করে।
- **Git Clone Tool**: একটি টুল যা একটি git রিপোজিটরি নির্দিষ্ট ফোল্ডারে ক্লোন করে।
- **VS Code Open Tool**: একটি টুল যা একটি ফোল্ডার VS Code বা VS Code Insiders-এ খুলে।
- **Connect to Agent Builder**: একটি বৈশিষ্ট্য যা MCP সার্ভারকে Agent Builder-এ সংযোগ করার সুযোগ দেয় টেস্ট এবং ডিবাগ করার জন্য।
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: একটি বৈশিষ্ট্য যা MCP Inspector ব্যবহার করে MCP Server ডিবাগ করার সুযোগ দেয়।

## Weather MCP Server টেমপ্লেট দিয়ে শুরু করুন

> **প্রয়োজনীয়তা**
>
> আপনার লোকাল ডেভ মেশিনে MCP Server চালানোর জন্য আপনার প্রয়োজন হবে:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo টুলের জন্য প্রয়োজন)
> - [VS Code](https://code.visualstudio.com/) অথবা [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode টুলের জন্য প্রয়োজন)
> - (*ঐচ্ছিক - যদি uv পছন্দ করেন*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## পরিবেশ প্রস্তুত করুন

এই প্রজেক্টের জন্য পরিবেশ সেটআপ করার দুটি পদ্ধতি আছে। আপনি আপনার পছন্দ অনুযায়ী যেকোনো একটি পদ্ধতি বেছে নিতে পারেন।

> টিপস: ভার্চুয়াল এনভায়রনমেন্ট তৈরি করার পর নিশ্চিত করুন VSCode বা টার্মিনাল রিলোড হয়েছে যাতে ভার্চুয়াল এনভায়রনমেন্টের python ব্যবহার হয়।

| পদ্ধতি | ধাপসমূহ |
| -------- | ----- |
| `uv` ব্যবহার করে | ১. ভার্চুয়াল এনভায়রনমেন্ট তৈরি করুন: `uv venv` <br>২. VSCode কমান্ড "***Python: Select Interpreter***" চালান এবং তৈরি করা ভার্চুয়াল এনভায়রনমেন্ট থেকে python নির্বাচন করুন <br>৩. ডিপেনডেন্সি ইনস্টল করুন (ডেভ ডিপেনডেন্সি সহ): `uv pip install -r pyproject.toml --extra dev` |
| `pip` ব্যবহার করে | ১. ভার্চুয়াল এনভায়রনমেন্ট তৈরি করুন: `python -m venv .venv` <br>২. VSCode কমান্ড "***Python: Select Interpreter***" চালান এবং তৈরি করা ভার্চুয়াল এনভায়রনমেন্ট থেকে python নির্বাচন করুন<br>৩. ডিপেনডেন্সি ইনস্টল করুন (ডেভ ডিপেনডেন্সি সহ): `pip install -e .[dev]` |

পরিবেশ প্রস্তুত করার পর, আপনি Agent Builder কে MCP Client হিসেবে ব্যবহার করে আপনার লোকাল ডেভ মেশিনে সার্ভার চালাতে পারেন শুরু করার জন্য:
1. VS Code Debug প্যানেল খুলুন। `Debug in Agent Builder` নির্বাচন করুন অথবা `F5` চাপুন MCP সার্ভার ডিবাগ শুরু করতে।
2. AI Toolkit Agent Builder ব্যবহার করে সার্ভার টেস্ট করুন [এই প্রম্পট](../../../../../../../../../../../open_prompt_builder) দিয়ে। সার্ভার স্বয়ংক্রিয়ভাবে Agent Builder-এ সংযুক্ত হবে।
3. প্রম্পট দিয়ে সার্ভার টেস্ট করতে `Run` ক্লিক করুন।

**অভিনন্দন**! আপনি সফলভাবে Agent Builder কে MCP Client হিসেবে ব্যবহার করে আপনার লোকাল ডেভ মেশিনে Weather MCP Server চালিয়েছেন।
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## টেমপ্লেটে কি অন্তর্ভুক্ত আছে

| ফোল্ডার / ফাইল | বিষয়বস্তু                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | ডিবাগ করার জন্য VSCode ফাইলগুলি                   |
| `.aitk`      | AI Toolkit এর কনফিগারেশন                     |
| `src`        | Weather MCP Server এর সোর্স কোড                   |

## Weather MCP Server কিভাবে ডিবাগ করবেন

> টিপস:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) MCP সার্ভার টেস্ট এবং ডিবাগ করার জন্য একটি ভিজ্যুয়াল ডেভেলপার টুল।
> - সব ডিবাগ মোড ব্রেকপয়েন্ট সমর্থন করে, তাই আপনি টুল ইমপ্লিমেন্টেশনের কোডে ব্রেকপয়েন্ট যোগ করতে পারেন।

## উপলব্ধ টুলস

### Weather Tool
`get_weather` টুল একটি নির্দিষ্ট অবস্থানের জন্য mock আবহাওয়া তথ্য প্রদান করে।

| প্যারামিটার | টাইপ | বর্ণনা |
| --------- | ---- | ----------- |
| `location` | string | আবহাওয়া জানার জন্য অবস্থান (যেমন, শহরের নাম, রাজ্য, অথবা কোঅর্ডিনেট) |

### Git Clone Tool
`git_clone_repo` টুল একটি git রিপোজিটরি নির্দিষ্ট ফোল্ডারে ক্লোন করে।

| প্যারামিটার | টাইপ | বর্ণনা |
| --------- | ---- | ----------- |
| `repo_url` | string | ক্লোন করার git রিপোজিটরির URL |
| `target_folder` | string | ফোল্ডারের পাথ যেখানে রিপোজিটরি ক্লোন করা হবে |

টুল একটি JSON অবজেক্ট রিটার্ন করে যার মধ্যে:
- `success`: অপারেশন সফল হয়েছে কিনা তা নির্দেশ করে Boolean
- `target_folder` অথবা `error`: ক্লোন করা রিপোজিটরির পাথ অথবা একটি ত্রুটির বার্তা

### VS Code Open Tool
`open_in_vscode` টুল একটি ফোল্ডার VS Code বা VS Code Insiders অ্যাপ্লিকেশন-এ খুলে।

| প্যারামিটার | টাইপ | বর্ণনা |
| --------- | ---- | ----------- |
| `folder_path` | string | খুলতে চাওয়া ফোল্ডারের পাথ |
| `use_insiders` | boolean (ঐচ্ছিক) | সাধারণ VS Code এর পরিবর্তে VS Code Insiders ব্যবহার করা হবে কিনা |

টুল একটি JSON অবজেক্ট রিটার্ন করে যার মধ্যে:
- `success`: অপারেশন সফল হয়েছে কিনা তা নির্দেশ করে Boolean
- `message` অথবা `error`: একটি নিশ্চিতকরণ বার্তা অথবা ত্রুটির বার্তা

## ডিবাগ মোড | বর্ণনা | ডিবাগ করার ধাপসমূহ |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit এর মাধ্যমে Agent Builder-এ MCP সার্ভার ডিবাগ করুন। | ১. VS Code Debug প্যানেল খুলুন। `Debug in Agent Builder` নির্বাচন করুন এবং MCP সার্ভার ডিবাগ শুরু করতে `F5` চাপুন।<br>২. AI Toolkit Agent Builder ব্যবহার করে [এই প্রম্পট](../../../../../../../../../../../open_prompt_builder) দিয়ে সার্ভার টেস্ট করুন। সার্ভার স্বয়ংক্রিয়ভাবে Agent Builder-এ সংযুক্ত হবে।<br>৩. প্রম্পট দিয়ে সার্ভার টেস্ট করতে `Run` ক্লিক করুন। |
| MCP Inspector | MCP Inspector ব্যবহার করে MCP সার্ভার ডিবাগ করুন। | ১. [Node.js](https://nodejs.org/) ইনস্টল করুন<br> ২. Inspector সেটআপ করুন: `cd inspector` && `npm install` <br> ৩. VS Code Debug প্যানেল খুলুন। `Debug SSE in Inspector (Edge)` অথবা `Debug SSE in Inspector (Chrome)` নির্বাচন করুন। F5 চাপুন ডিবাগ শুরু করতে।<br> ৪. যখন MCP Inspector ব্রাউজারে চালু হবে, এই MCP সার্ভারের সাথে সংযোগ করতে `Connect` বোতামে ক্লিক করুন।<br> ৫. এরপর আপনি `List Tools` করতে পারবেন, একটি টুল নির্বাচন করুন, প্যারামিটার ইনপুট দিন, এবং `Run Tool` করে আপনার সার্ভার কোড ডিবাগ করুন।<br> |

## ডিফল্ট পোর্ট এবং কাস্টমাইজেশন

| ডিবাগ মোড | পোর্ট | সংজ্ঞা | কাস্টমাইজেশন | নোট |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | উপরের পোর্ট পরিবর্তন করতে [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) সম্পাদনা করুন। | প্রযোজ্য নয় |
| MCP Inspector | 3001 (সার্ভার); 5173 এবং 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | উপরের পোর্ট পরিবর্তন করতে [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) সম্পাদনা করুন। | প্রযোজ্য নয় |

## প্রতিক্রিয়া

যদি আপনার এই টেমপ্লেট সম্পর্কে কোনো প্রতিক্রিয়া বা পরামর্শ থাকে, অনুগ্রহ করে [AI Toolkit GitHub রিপোজিটরিতে](https://github.com/microsoft/vscode-ai-toolkit/issues) একটি ইস্যু খুলুন।

**দ্রষ্টব্য**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা সঠিকতার জন্য চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে উদ্ভূত কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়বদ্ধ নই।